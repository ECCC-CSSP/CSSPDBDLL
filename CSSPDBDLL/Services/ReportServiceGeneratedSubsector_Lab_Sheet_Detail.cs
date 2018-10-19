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
    public partial class ReportServiceSubsector_Lab_Sheet_Detail
    {
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Subsector_Lab_Sheet_Detail_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Error);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Error);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Counter);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Counter);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_ID);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_ID);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Version":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Version);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Version);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Run_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Run_Date);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Run_Date);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Tides":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Tides);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Tides);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Sample_Crew_Initials":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Sample_Crew_Initials);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Sample_Crew_Initials);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Water_Bath1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Water_Bath1);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Water_Bath1);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Water_Bath2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Water_Bath2);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Water_Bath2);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Water_Bath3":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Water_Bath3);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Water_Bath3);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Field_1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_TC_Field_1);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_TC_Field_1);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Lab_1":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_1);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_1);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Field_2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_TC_Field_2);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_TC_Field_2);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Lab_2":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_2);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_2);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_First":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_TC_First);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_TC_First);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Average":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_TC_Average);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_TC_Average);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Control_Lot":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Control_Lot);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Control_Lot);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Positive_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Positive_35);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Positive_35);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Non_Target_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Non_Target_35);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Non_Target_35);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Negative_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Negative_35);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Negative_35);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Blank_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Blank_35);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Blank_35);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Lot_35":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Lot_35);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Lot_35);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Lot_44_5":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Lot_44_5);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Lot_44_5);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Run_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Run_Comment);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Run_Comment);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Run_Weather_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Run_Weather_Comment);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Run_Weather_Comment);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Salinities_Read_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_By);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_By);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Salinities_Read_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Results_Read_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Results_Read_By);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Results_Read_By);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Results_Read_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Results_Recorded_By":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_By);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_By);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Results_Recorded_Date":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderBy(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial);
                                else
                                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.OrderByDescending(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial);
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
                        case "Subsector_Lab_Sheet_Detail_Run_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Salinities_Read_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Results_Read_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Results_Recorded_Date":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_YEAR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_MONTH(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_DAY(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_HOUR(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_MINUTE(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Subsector_Lab_Sheet_Detail_Error":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Error(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Version":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Version(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Tides":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Tides(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Sample_Crew_Initials":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Sample_Crew_Initials(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Water_Bath1":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Water_Bath1(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Water_Bath2":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Water_Bath2(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Water_Bath3":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Water_Bath3(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Control_Lot":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Control_Lot(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Positive_35":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Positive_35(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Non_Target_35":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Non_Target_35(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Negative_35":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Negative_35(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Blank_35":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Blank_35(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Lot_35":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Lot_35(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Lot_44_5":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Lot_44_5(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Run_Comment":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Comment(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Run_Weather_Comment":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Weather_Comment(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Salinities_Read_By":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_By(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Results_Read_By":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_By(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Results_Recorded_By":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_By(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Subsector_Lab_Sheet_Detail_Counter":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Counter(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_ID":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_ID(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Field_1":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Field_1(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Lab_1":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Lab_1(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Field_2":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Field_2(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Lab_2":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Lab_2(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_First":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_First(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_TC_Average":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Average(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria":
                            reportSubsector_Lab_Sheet_DetailModelQ = ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria(reportSubsector_Lab_Sheet_DetailModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable == true);
                            else
                                reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Acceptable == false);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable == true);
                            else
                                reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable == false);
                            break;
                        case "Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable == true);
                            else
                                reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Read_Acceptable == false);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TrueFalse
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }

        // Date Functions
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_YEAR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_MONTH(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_DAY(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_HOUR(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Date_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Start_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_End_Time.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_Date_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_Date_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_Date_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_Date.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC_MINUTE(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportSubsector_Lab_Sheet_DetailModelQ;
        }

        // Text Functions
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Error(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Version(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Version.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Version.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Version.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Version.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Version.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Version.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Tides(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Tides.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Tides.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Tides.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Tides.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Tides.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Tides.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Sample_Crew_Initials(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Sample_Crew_Initials.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Water_Bath1(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath1.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath1.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath1.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath1.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Water_Bath1.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Water_Bath1.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Water_Bath2(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath2.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath2.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath2.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath2.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Water_Bath2.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Water_Bath2.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Water_Bath3(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath3.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath3.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath3.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Water_Bath3.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Water_Bath3.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Water_Bath3.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Control_Lot(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Control_Lot.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Control_Lot.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Control_Lot.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Control_Lot.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Control_Lot.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Control_Lot.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Positive_35(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Positive_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Positive_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Positive_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Positive_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Positive_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Positive_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Non_Target_35(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Non_Target_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Non_Target_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Non_Target_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Non_Target_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Non_Target_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Non_Target_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Negative_35(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Negative_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Negative_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Negative_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Negative_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Negative_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Negative_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath1_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath2_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath3_Positive_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath1_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath2_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath3_Non_Target_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath1_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath2_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath3_Negative_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Blank_35(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Blank_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Blank_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Blank_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Blank_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Blank_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Blank_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath1_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath2_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Bath3_Blank_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Lot_35(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Lot_35.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Lot_35.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Lot_35.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Lot_35.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Lot_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Lot_35.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Lot_44_5(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Lot_44_5.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Lot_44_5.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Lot_44_5.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Lot_44_5.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Lot_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Lot_44_5.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Comment(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Run_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Run_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Run_Weather_Comment(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Weather_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Weather_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Weather_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Run_Weather_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Run_Weather_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Run_Weather_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Sample_Bottle_Lot_Number.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Salinities_Read_By(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Salinities_Read_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Salinities_Read_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Salinities_Read_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Read_By(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Read_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Results_Read_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Results_Read_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Results_Recorded_By(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_By.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_By.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_By.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Results_Recorded_By.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Results_Recorded_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Results_Recorded_By.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => String.Compare(c.Subsector_Lab_Sheet_Detail_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }

        // Number Functions
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Counter(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_ID(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Field_1(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Field_1 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Field_1 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Field_1 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Lab_1(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_1 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_1 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_1 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Field_2(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Field_2 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Field_2 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Field_2 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Lab_2(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_2 > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_2 < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Lab_2 == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_First(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_First > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_First < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_First == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_TC_Average(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Average > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Average < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_TC_Average == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_R_Log == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_R_Log == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
        public IQueryable<ReportSubsector_Lab_Sheet_DetailModel> ReportServiceGeneratedSubsector_Lab_Sheet_Detail_Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria(IQueryable<ReportSubsector_Lab_Sheet_DetailModel> reportSubsector_Lab_Sheet_DetailModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportSubsector_Lab_Sheet_DetailModelQ = reportSubsector_Lab_Sheet_DetailModelQ.Where(c => c.Subsector_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportSubsector_Lab_Sheet_DetailModelQ;
        }
    }
}
