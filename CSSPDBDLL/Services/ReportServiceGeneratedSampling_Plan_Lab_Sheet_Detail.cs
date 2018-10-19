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
    public partial class ReportServiceSampling_Plan_Lab_Sheet_Detail
    {
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Sampling_Plan_Lab_Sheet_Detail_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Error);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Error);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Counter);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Counter);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_ID);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_ID);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Version":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Version);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Version);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Run_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Tides":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Tides);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Tides);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Water_Bath1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath1);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath1);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Water_Bath2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath2);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath2);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Water_Bath3":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath3);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath3);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Field_1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_1);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_1);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Field_2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_2);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_2);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_First":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_First);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_First);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Average":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Average);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Average);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Control_Lot":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Control_Lot);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Control_Lot);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Positive_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Positive_35);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Positive_35);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Non_Target_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Non_Target_35);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Non_Target_35);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Negative_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Negative_35);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Negative_35);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Blank_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Blank_35);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Blank_35);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Lot_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_35);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_35);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Lot_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_44_5);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_44_5);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Run_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Comment);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Comment);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Results_Read_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_By);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_By);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderBy(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial);
                                else
                                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial);
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
                        case "Sampling_Plan_Lab_Sheet_Detail_Run_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_YEAR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_MONTH(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_DAY(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_HOUR(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_MINUTE(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Sampling_Plan_Lab_Sheet_Detail_Error":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Error(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Version":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Version(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Tides":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Tides(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Water_Bath1":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Water_Bath1(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Water_Bath2":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Water_Bath2(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Water_Bath3":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Water_Bath3(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Control_Lot":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Control_Lot(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Positive_35":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Positive_35(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Non_Target_35":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Non_Target_35(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Negative_35":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Negative_35(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Blank_35":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Blank_35(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Lot_35":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Lot_35(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Lot_44_5":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Lot_44_5(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Run_Comment":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Comment(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Results_Read_By":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_By(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Sampling_Plan_Lab_Sheet_Detail_Counter":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Counter(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_ID":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_ID(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Field_1":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Field_1(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Field_2":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Field_2(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_First":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_First(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_TC_Average":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Average(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria":
                            reportSampling_Plan_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria(reportSampling_Plan_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable == true);
                            else
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Acceptable == false);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable == true);
                            else
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable == false);
                            break;
                        case "Sampling_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable == true);
                            else
                                reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Read_Acceptable == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }

        // Date Functions
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_YEAR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_MONTH(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_DAY(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_HOUR(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Date_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }

        // Text Functions
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Error(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Version(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Version.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Version.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Version.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Version.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Version.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Version.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Tides(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Tides.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Tides.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Tides.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Tides.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Tides.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Tides.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Water_Bath1(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath1.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath1.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath1.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath1.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath1.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath1.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Water_Bath2(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath2.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath2.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath2.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath2.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath2.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath2.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Water_Bath3(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath3.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath3.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath3.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath3.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath3.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Water_Bath3.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Control_Lot(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Control_Lot.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Control_Lot.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Control_Lot.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Control_Lot.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Control_Lot.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Control_Lot.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Positive_35(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Positive_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Positive_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Positive_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Positive_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Positive_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Positive_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Non_Target_35(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Non_Target_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Non_Target_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Non_Target_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Non_Target_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Non_Target_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Non_Target_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Negative_35(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Negative_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Negative_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Negative_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Negative_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Negative_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Negative_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Blank_35(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Blank_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Blank_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Blank_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Blank_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Blank_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Blank_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Lot_35(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Lot_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Lot_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Lot_44_5(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Lot_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Lot_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Lot_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Comment(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Run_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Run_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Run_Weather_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Salinities_Read_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Read_By(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Results_Read_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Results_Recorded_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Sampling_Plan_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }

        // Number Functions
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Counter(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_ID(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Field_1(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_1 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_1 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_1 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_1 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Field_2(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_2 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_2 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Field_2 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Lab_2 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_First(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_First > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_First < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_First == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_TC_Average(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Average > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Average < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_TC_Average == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_R_Log == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_R_Log == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> ReportServiceGeneratedSampling_Plan_Lab_Sheet_Detail_Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria(IQueryable<ReportSampling_Plan_Lab_Sheet_DetailModel> reportSampling_Plan_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSampling_Plan_Lab_Sheet_DetailModelQ = reportSampling_Plan_Lab_Sheet_DetailModelQ.Where(c => c.Sampling_Plan_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSampling_Plan_Lab_Sheet_DetailModelQ;
        }
    }
}
