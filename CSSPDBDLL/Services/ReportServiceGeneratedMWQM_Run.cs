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
    public partial class ReportServiceMWQM_Run
    {
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Run_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Error);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Error);
                            }
                            break;
                        case "MWQM_Run_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Counter);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Counter);
                            }
                            break;
                        case "MWQM_Run_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_ID);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_ID);
                            }
                            break;
                        case "MWQM_Run_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Name_Translation_Status);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Name_Translation_Status);
                            }
                            break;
                        case "MWQM_Run_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Name);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Name);
                            }
                            break;
                        case "MWQM_Run_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Is_Active);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Is_Active);
                            }
                            break;
                        case "MWQM_Run_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Date_Time_Local);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Run_Start_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Start_Date_Time_Local);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Start_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Run_End_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_End_Date_Time_Local);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_End_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Run_Lab_Received_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Lab_Received_Date_Time_Local);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Received_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Run_Temperature_Control_1_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Temperature_Control_1_C);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Temperature_Control_1_C);
                            }
                            break;
                        case "MWQM_Run_Temperature_Control_2_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Temperature_Control_2_C);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Temperature_Control_2_C);
                            }
                            break;
                        case "MWQM_Run_Sea_State_At_Start_Beaufort_Scale":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Sea_State_At_Start_Beaufort_Scale);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Sea_State_At_Start_Beaufort_Scale);
                            }
                            break;
                        case "MWQM_Run_Sea_State_At_End_Beaufort_Scale":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Sea_State_At_End_Beaufort_Scale);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Sea_State_At_End_Beaufort_Scale);
                            }
                            break;
                        case "MWQM_Run_Water_Level_At_Brook_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Water_Level_At_Brook_m);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Water_Level_At_Brook_m);
                            }
                            break;
                        case "MWQM_Run_Wave_Hight_At_Start_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Wave_Hight_At_Start_m);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Wave_Hight_At_Start_m);
                            }
                            break;
                        case "MWQM_Run_Wave_Hight_At_End_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Wave_Hight_At_End_m);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Wave_Hight_At_End_m);
                            }
                            break;
                        case "MWQM_Run_Sample_Crew_Initials":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Sample_Crew_Initials);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Sample_Crew_Initials);
                            }
                            break;
                        case "MWQM_Run_Analyze_Method":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Analyze_Method);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Analyze_Method);
                            }
                            break;
                        case "MWQM_Run_Sample_Matrix":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Sample_Matrix);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Sample_Matrix);
                            }
                            break;
                        case "MWQM_Run_Laboratory":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Laboratory);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Laboratory);
                            }
                            break;
                        case "MWQM_Run_Sample_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Sample_Status);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Sample_Status);
                            }
                            break;
                        case "MWQM_Run_Lab_Sample_Approval_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Name);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Name);
                            }
                            break;
                        case "MWQM_Run_Lab_Sample_Approval_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Initial);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Initial);
                            }
                            break;
                        case "MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_0_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_0_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_0_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_1_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_1_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_1_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_2_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_2_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_2_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_3_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_3_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_3_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_4_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_4_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_4_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_5_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_5_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_5_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_6_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_6_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_6_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_7_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_7_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_7_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_8_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_8_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_8_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_9_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_9_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_9_mm);
                            }
                            break;
                        case "MWQM_Run_Rain_Day_10_mm":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Rain_Day_10_mm);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Rain_Day_10_mm);
                            }
                            break;
                        case "MWQM_Run_Comment_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Comment_Translation_Status);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Comment_Translation_Status);
                            }
                            break;
                        case "MWQM_Run_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Comment);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Comment);
                            }
                            break;
                        case "MWQM_Run_Weather_Comment_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Weather_Comment_Translation_Status);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Weather_Comment_Translation_Status);
                            }
                            break;
                        case "MWQM_Run_Weather_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Weather_Comment);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Weather_Comment);
                            }
                            break;
                        case "MWQM_Run_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "MWQM_Run_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Last_Update_Contact_Name);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Last_Update_Contact_Name);
                            }
                            break;
                        case "MWQM_Run_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Last_Update_Contact_Initial);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Last_Update_Contact_Initial);
                            }
                            break;
                        case "MWQM_Run_Stat_MWQM_Site_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Stat_MWQM_Site_Count);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Stat_MWQM_Site_Count);
                            }
                            break;
                        case "MWQM_Run_Stat_Sample_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderBy(c => c.MWQM_Run_Stat_Sample_Count);
                                else
                                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.OrderByDescending(c => c.MWQM_Run_Stat_Sample_Count);
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
                        case "MWQM_Run_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Start_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_End_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Lab_Received_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "MWQM_Run_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_YEAR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_MONTH(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_DAY(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_HOUR(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_MINUTE(reportMWQM_RunModelQ, reportTreeNode, reportConditionDateField);
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
                        case "MWQM_Run_Error":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Error(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Name":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Name(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Sample_Crew_Initials":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Sample_Crew_Initials(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sample_Approval_Contact_Name":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Sample_Approval_Contact_Name(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Lab_Sample_Approval_Contact_Initial":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Sample_Approval_Contact_Initial(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Comment":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Comment(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Weather_Comment":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Weather_Comment(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Last_Update_Contact_Name":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Contact_Name(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "MWQM_Run_Last_Update_Contact_Initial":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Contact_Initial(reportMWQM_RunModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "MWQM_Run_Counter":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Counter(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_ID":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_ID(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Temperature_Control_1_C":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Temperature_Control_1_C(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Temperature_Control_2_C":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Temperature_Control_2_C(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Water_Level_At_Brook_m":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Water_Level_At_Brook_m(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Wave_Hight_At_Start_m":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Wave_Hight_At_Start_m(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Wave_Hight_At_End_m":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Wave_Hight_At_End_m(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_0_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_0_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_1_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_1_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_2_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_2_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_3_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_3_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_4_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_4_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_5_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_5_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_6_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_6_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_7_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_7_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_8_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_8_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_9_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_9_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Rain_Day_10_mm":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_10_mm(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Stat_MWQM_Site_Count":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Stat_MWQM_Site_Count(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "MWQM_Run_Stat_Sample_Count":
                            reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run_MWQM_Run_Stat_Sample_Count(reportMWQM_RunModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "MWQM_Run_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Is_Active == true);
                            else
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Is_Active == false);
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
                        case "MWQM_Run_Name_Translation_Status":
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
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.MWQM_Run_Name_Translation_Status));
                            }
                            break;
                        case "MWQM_Run_Comment_Translation_Status":
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
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.MWQM_Run_Comment_Translation_Status));
                            }
                            break;
                        case "MWQM_Run_Weather_Comment_Translation_Status":
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
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.MWQM_Run_Weather_Comment_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            #region Filter BeaufortScaleEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.BeaufortScale))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Run_Sea_State_At_Start_Beaufort_Scale":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<BeaufortScaleEnum> BeaufortScaleEqualList = new List<BeaufortScaleEnum>();
                                List<string> BeaufortScaleTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in BeaufortScaleTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(BeaufortScaleEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((BeaufortScaleEnum)i).ToString())
                                        {
                                            BeaufortScaleEqualList.Add((BeaufortScaleEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        BeaufortScaleEqualList.Add(BeaufortScaleEnum.Error);
                                }
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => BeaufortScaleEqualList.Contains((BeaufortScaleEnum)c.MWQM_Run_Sea_State_At_Start_Beaufort_Scale));
                            }
                            break;
                        case "MWQM_Run_Sea_State_At_End_Beaufort_Scale":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<BeaufortScaleEnum> BeaufortScaleEqualList = new List<BeaufortScaleEnum>();
                                List<string> BeaufortScaleTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in BeaufortScaleTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(BeaufortScaleEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((BeaufortScaleEnum)i).ToString())
                                        {
                                            BeaufortScaleEqualList.Add((BeaufortScaleEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        BeaufortScaleEqualList.Add(BeaufortScaleEnum.Error);
                                }
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => BeaufortScaleEqualList.Contains((BeaufortScaleEnum)c.MWQM_Run_Sea_State_At_End_Beaufort_Scale));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter BeaufortScaleEnum
            #region Filter AnalyzeMethodEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.AnalyzeMethod))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Run_Analyze_Method":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<AnalyzeMethodEnum> AnalyzeMethodEqualList = new List<AnalyzeMethodEnum>();
                                List<string> AnalyzeMethodTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in AnalyzeMethodTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(AnalyzeMethodEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((AnalyzeMethodEnum)i).ToString())
                                        {
                                            AnalyzeMethodEqualList.Add((AnalyzeMethodEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        AnalyzeMethodEqualList.Add(AnalyzeMethodEnum.Error);
                                }
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => AnalyzeMethodEqualList.Contains((AnalyzeMethodEnum)c.MWQM_Run_Analyze_Method));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter AnalyzeMethodEnum
            #region Filter SampleMatrixEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.SampleMatrix))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Run_Sample_Matrix":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<SampleMatrixEnum> SampleMatrixEqualList = new List<SampleMatrixEnum>();
                                List<string> SampleMatrixTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in SampleMatrixTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(SampleMatrixEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((SampleMatrixEnum)i).ToString())
                                        {
                                            SampleMatrixEqualList.Add((SampleMatrixEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        SampleMatrixEqualList.Add(SampleMatrixEnum.Error);
                                }
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => SampleMatrixEqualList.Contains((SampleMatrixEnum)c.MWQM_Run_Sample_Matrix));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter SampleMatrixEnum
            #region Filter LaboratoryEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.Laboratory))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Run_Laboratory":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<LaboratoryEnum> LaboratoryEqualList = new List<LaboratoryEnum>();
                                List<string> LaboratoryTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in LaboratoryTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(LaboratoryEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((LaboratoryEnum)i).ToString())
                                        {
                                            LaboratoryEqualList.Add((LaboratoryEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        LaboratoryEqualList.Add(LaboratoryEnum.Error);
                                }
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => LaboratoryEqualList.Contains((LaboratoryEnum)c.MWQM_Run_Laboratory));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter LaboratoryEnum
            #region Filter SampleStatusEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.SampleStatus))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "MWQM_Run_Sample_Status":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<SampleStatusEnum> SampleStatusEqualList = new List<SampleStatusEnum>();
                                List<string> SampleStatusTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in SampleStatusTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(SampleStatusEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((SampleStatusEnum)i).ToString())
                                        {
                                            SampleStatusEqualList.Add((SampleStatusEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        SampleStatusEqualList.Add(SampleStatusEnum.Error);
                                }
                                reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => SampleStatusEqualList.Contains((SampleStatusEnum)c.MWQM_Run_Sample_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter SampleStatusEnum
            return reportMWQM_RunModelQ;
        }

        // Date Functions
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Start_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_End_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_End_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Received_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Received_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportMWQM_RunModelQ;
        }

        // Text Functions
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Error(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Name(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Sample_Crew_Initials(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Sample_Crew_Initials.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Sample_Crew_Initials.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Sample_Crew_Initials.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Sample_Crew_Initials.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Sample_Crew_Initials.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Sample_Crew_Initials.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Sample_Approval_Contact_Name(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sample_Approval_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sample_Approval_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Lab_Sample_Approval_Contact_Initial(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Lab_Sample_Approval_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sample_Approval_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Lab_Sample_Approval_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Comment(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Weather_Comment(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Weather_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Weather_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Weather_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Weather_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Weather_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Weather_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Contact_Name(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Last_Update_Contact_Initial(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => String.Compare(c.MWQM_Run_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }

        // Number Functions
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Counter(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_ID(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Temperature_Control_1_C(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Temperature_Control_1_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Temperature_Control_1_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Temperature_Control_1_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Temperature_Control_2_C(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Temperature_Control_2_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Temperature_Control_2_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Temperature_Control_2_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Water_Level_At_Brook_m(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Water_Level_At_Brook_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Water_Level_At_Brook_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Water_Level_At_Brook_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Wave_Hight_At_Start_m(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Wave_Hight_At_Start_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Wave_Hight_At_Start_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Wave_Hight_At_Start_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Wave_Hight_At_End_m(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Wave_Hight_At_End_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Wave_Hight_At_End_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Wave_Hight_At_End_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_0_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_0_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_0_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_0_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_1_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_1_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_1_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_1_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_2_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_2_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_2_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_2_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_3_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_3_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_3_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_3_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_4_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_4_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_4_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_4_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_5_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_5_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_5_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_5_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_6_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_6_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_6_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_6_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_7_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_7_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_7_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_7_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_8_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_8_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_8_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_8_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_9_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_9_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_9_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_9_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Rain_Day_10_mm(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_10_mm > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_10_mm < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Rain_Day_10_mm == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Stat_MWQM_Site_Count(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Stat_MWQM_Site_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Stat_MWQM_Site_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Stat_MWQM_Site_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
        public IQueryable<ReportMWQM_RunModel> ReportServiceGeneratedMWQM_Run_MWQM_Run_Stat_Sample_Count(IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Stat_Sample_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Stat_Sample_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportMWQM_RunModelQ = reportMWQM_RunModelQ.Where(c => c.MWQM_Run_Stat_Sample_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportMWQM_RunModelQ;
        }
    }
}
