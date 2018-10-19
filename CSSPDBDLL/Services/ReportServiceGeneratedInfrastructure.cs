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
    public partial class ReportServiceInfrastructure
    {
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, List<ReportTreeNode> reportTreeNodeList)
        {
            #region Sorting
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbSortingField.ReportSorting != ReportSortingEnum.Error).OrderBy(c => c.dbSortingField.Ordinal))
            {
                if (reportTreeNode.dbSortingField.ReportSorting != ReportSortingEnum.Error)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Error":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Error);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Error);
                            }
                            break;
                        case "Infrastructure_Counter":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Counter);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Counter);
                            }
                            break;
                        case "Infrastructure_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_ID);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_ID);
                            }
                            break;
                        case "Infrastructure_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Name);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Name);
                            }
                            break;
                        case "Infrastructure_Name_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Name_Translation_Status);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Name_Translation_Status);
                            }
                            break;
                        case "Infrastructure_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Last_Update_Date_UTC);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Last_Update_Date_UTC);
                            }
                            break;
                        case "Infrastructure_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Last_Update_Contact_Name);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Last_Update_Contact_Name);
                            }
                            break;
                        case "Infrastructure_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Last_Update_Contact_Initial);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Infrastructure_Is_Active":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Is_Active);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Is_Active);
                            }
                            break;
                        case "Infrastructure_Comment_Translation_Status":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Comment_Translation_Status);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Comment_Translation_Status);
                            }
                            break;
                        case "Infrastructure_Comment_Last_Update_Date_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Comment_Last_Update_Date_UTC);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Comment_Last_Update_Date_UTC);
                            }
                            break;
                        case "Infrastructure_Comment_Last_Update_Contact_Name":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Comment_Last_Update_Contact_Name);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Comment_Last_Update_Contact_Name);
                            }
                            break;
                        case "Infrastructure_Comment_Last_Update_Contact_Initial":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Comment_Last_Update_Contact_Initial);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Comment_Last_Update_Contact_Initial);
                            }
                            break;
                        case "Infrastructure_Comment":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Comment);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Comment);
                            }
                            break;
                        case "Infrastructure_Prism_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Prism_ID);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Prism_ID);
                            }
                            break;
                        case "Infrastructure_TPID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_TPID);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_TPID);
                            }
                            break;
                        case "Infrastructure_LSID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_LSID);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_LSID);
                            }
                            break;
                        case "Infrastructure_Site_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Site_ID);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Site_ID);
                            }
                            break;
                        case "Infrastructure_Site":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Site);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Site);
                            }
                            break;
                        case "Infrastructure_Infrastructure_Category":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Infrastructure_Category);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Infrastructure_Category);
                            }
                            break;
                        case "Infrastructure_Infrastructure_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Infrastructure_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Infrastructure_Type);
                            }
                            break;
                        case "Infrastructure_Facility_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Facility_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Facility_Type);
                            }
                            break;
                        case "Infrastructure_Is_Mechanically_Aerated":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Is_Mechanically_Aerated);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Is_Mechanically_Aerated);
                            }
                            break;
                        case "Infrastructure_Number_Of_Cells":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Number_Of_Cells);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Number_Of_Cells);
                            }
                            break;
                        case "Infrastructure_Number_Of_Aerated_Cells":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Number_Of_Aerated_Cells);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Number_Of_Aerated_Cells);
                            }
                            break;
                        case "Infrastructure_Aeration_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Aeration_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Aeration_Type);
                            }
                            break;
                        case "Infrastructure_Preliminary_Treatment_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Preliminary_Treatment_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Preliminary_Treatment_Type);
                            }
                            break;
                        case "Infrastructure_Primary_Treatment_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Primary_Treatment_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Primary_Treatment_Type);
                            }
                            break;
                        case "Infrastructure_Secondary_Treatment_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Secondary_Treatment_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Secondary_Treatment_Type);
                            }
                            break;
                        case "Infrastructure_Tertiary_Treatment_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Tertiary_Treatment_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Tertiary_Treatment_Type);
                            }
                            break;
                        case "Infrastructure_Treatment_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Treatment_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Treatment_Type);
                            }
                            break;
                        case "Infrastructure_Disinfection_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Disinfection_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Disinfection_Type);
                            }
                            break;
                        case "Infrastructure_Collection_System_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Collection_System_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Collection_System_Type);
                            }
                            break;
                        case "Infrastructure_Alarm_System_Type":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Alarm_System_Type);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Alarm_System_Type);
                            }
                            break;
                        case "Infrastructure_Design_Flow_m3_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Design_Flow_m3_day);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Design_Flow_m3_day);
                            }
                            break;
                        case "Infrastructure_Average_Flow_m3_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Average_Flow_m3_day);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Average_Flow_m3_day);
                            }
                            break;
                        case "Infrastructure_Peak_Flow_m3_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Peak_Flow_m3_day);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Peak_Flow_m3_day);
                            }
                            break;
                        case "Infrastructure_Pop_Served":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Pop_Served);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Pop_Served);
                            }
                            break;
                        case "Infrastructure_Can_Overflow":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Can_Overflow);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Can_Overflow);
                            }
                            break;
                        case "Infrastructure_Perc_Flow_Of_Total":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Perc_Flow_Of_Total);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Perc_Flow_Of_Total);
                            }
                            break;
                        case "Infrastructure_Time_Offset_hour":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Time_Offset_hour);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Time_Offset_hour);
                            }
                            break;
                        case "Infrastructure_Temp_Catch_All_Remove_Later":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Temp_Catch_All_Remove_Later);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Temp_Catch_All_Remove_Later);
                            }
                            break;
                        case "Infrastructure_Average_Depth_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Average_Depth_m);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Average_Depth_m);
                            }
                            break;
                        case "Infrastructure_Number_Of_Ports":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Number_Of_Ports);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Number_Of_Ports);
                            }
                            break;
                        case "Infrastructure_Port_Diameter_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Port_Diameter_m);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Port_Diameter_m);
                            }
                            break;
                        case "Infrastructure_Port_Spacing_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Port_Spacing_m);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Port_Spacing_m);
                            }
                            break;
                        case "Infrastructure_Port_Elevation_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Port_Elevation_m);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Port_Elevation_m);
                            }
                            break;
                        case "Infrastructure_Vertical_Angle_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Vertical_Angle_deg);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Vertical_Angle_deg);
                            }
                            break;
                        case "Infrastructure_Horizontal_Angle_deg":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Horizontal_Angle_deg);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Horizontal_Angle_deg);
                            }
                            break;
                        case "Infrastructure_Decay_Rate_per_day":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Decay_Rate_per_day);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Decay_Rate_per_day);
                            }
                            break;
                        case "Infrastructure_Near_Field_Velocity_m_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Near_Field_Velocity_m_s);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Near_Field_Velocity_m_s);
                            }
                            break;
                        case "Infrastructure_Far_Field_Velocity_m_s":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Far_Field_Velocity_m_s);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Far_Field_Velocity_m_s);
                            }
                            break;
                        case "Infrastructure_Receiving_Water_Salinity_PSU":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Receiving_Water_Salinity_PSU);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Receiving_Water_Salinity_PSU);
                            }
                            break;
                        case "Infrastructure_Receiving_Water_Temperature_C":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Receiving_Water_Temperature_C);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Receiving_Water_Temperature_C);
                            }
                            break;
                        case "Infrastructure_Receiving_Water_MPN_per_100_ml":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Receiving_Water_MPN_per_100_ml);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Receiving_Water_MPN_per_100_ml);
                            }
                            break;
                        case "Infrastructure_Distance_From_Shore_m":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Distance_From_Shore_m);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Distance_From_Shore_m);
                            }
                            break;
                        case "Infrastructure_See_Other_ID":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_See_Other_ID);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_See_Other_ID);
                            }
                            break;
                        case "Infrastructure_Last_Update_Date_And_Time_UTC":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Last_Update_Date_And_Time_UTC);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Last_Update_Date_And_Time_UTC);
                            }
                            break;
                        case "Infrastructure_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Lat);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Lat);
                            }
                            break;
                        case "Infrastructure_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Lng);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Lng);
                            }
                            break;
                        case "Infrastructure_Outfall_Lat":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Outfall_Lat);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Outfall_Lat);
                            }
                            break;
                        case "Infrastructure_Outfall_Lng":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Outfall_Lng);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Outfall_Lng);
                            }
                            break;
                        case "Infrastructure_Civic_Address":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Civic_Address);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Civic_Address);
                            }
                            break;
                        case "Infrastructure_Google_Address":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Google_Address);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Google_Address);
                            }
                            break;
                        case "Infrastructure_Stat_Box_Model_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Stat_Box_Model_Scenario_Count);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Stat_Box_Model_Scenario_Count);
                            }
                            break;
                        case "Infrastructure_Stat_Visual_Plumes_Scenario_Count":
                            {
                                if (reportTreeNode.dbSortingField.ReportSorting == ReportSortingEnum.ReportSortingAscending)
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderBy(c => c.Infrastructure_Stat_Visual_Plumes_Scenario_Count);
                                else
                                    reportInfrastructureModelQ = reportInfrastructureModelQ.OrderByDescending(c => c.Infrastructure_Stat_Visual_Plumes_Scenario_Count);
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
                        case "Infrastructure_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_YEAR(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_MONTH(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_DAY(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_HOUR(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_MINUTE(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Infrastructure_Comment_Last_Update_Date_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_YEAR(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_MONTH(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_DAY(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_HOUR(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_MINUTE(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            break;
                        case "Infrastructure_Last_Update_Date_And_Time_UTC":
                            if (reportConditionDateField.DateTimeConditionYear != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_YEAR(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMonth != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_MONTH(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionDay != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_DAY(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionHour != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_HOUR(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
                            }
                            else if (reportConditionDateField.DateTimeConditionMinute != null)
                            {
                                reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_MINUTE(reportInfrastructureModelQ, reportTreeNode, reportConditionDateField);
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
                        case "Infrastructure_Error":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Error(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Name":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Name(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Last_Update_Contact_Name":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Contact_Name(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Last_Update_Contact_Initial":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Contact_Initial(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Comment_Last_Update_Contact_Name":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Contact_Name(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Comment_Last_Update_Contact_Initial":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Contact_Initial(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Comment":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Comment(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Infrastructure_Category":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Infrastructure_Category(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Temp_Catch_All_Remove_Later":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Temp_Catch_All_Remove_Later(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Civic_Address":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Civic_Address(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
                            break;
                        case "Infrastructure_Google_Address":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Google_Address(reportInfrastructureModelQ, reportTreeNode, dbFilteringTextField);
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
                        case "Infrastructure_Counter":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Counter(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_ID":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_ID(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Prism_ID":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Prism_ID(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_TPID":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_TPID(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_LSID":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_LSID(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Site_ID":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Site_ID(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Site":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Site(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Number_Of_Cells":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Number_Of_Cells(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Number_Of_Aerated_Cells":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Number_Of_Aerated_Cells(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Design_Flow_m3_day":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Design_Flow_m3_day(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Average_Flow_m3_day":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Average_Flow_m3_day(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Peak_Flow_m3_day":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Peak_Flow_m3_day(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Pop_Served":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Pop_Served(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Perc_Flow_Of_Total":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Perc_Flow_Of_Total(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Time_Offset_hour":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Time_Offset_hour(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Average_Depth_m":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Average_Depth_m(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Number_Of_Ports":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Number_Of_Ports(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Port_Diameter_m":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Port_Diameter_m(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Port_Spacing_m":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Port_Spacing_m(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Port_Elevation_m":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Port_Elevation_m(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Vertical_Angle_deg":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Vertical_Angle_deg(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Horizontal_Angle_deg":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Horizontal_Angle_deg(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Decay_Rate_per_day":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Decay_Rate_per_day(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Near_Field_Velocity_m_s":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Near_Field_Velocity_m_s(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Far_Field_Velocity_m_s":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Far_Field_Velocity_m_s(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Receiving_Water_Salinity_PSU":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Receiving_Water_Salinity_PSU(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Receiving_Water_Temperature_C":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Receiving_Water_Temperature_C(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Receiving_Water_MPN_per_100_ml":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Receiving_Water_MPN_per_100_ml(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Distance_From_Shore_m":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Distance_From_Shore_m(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_See_Other_ID":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_See_Other_ID(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Lat":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Lat(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Lng":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Lng(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Outfall_Lat":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Outfall_Lat(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Outfall_Lng":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Outfall_Lng(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Stat_Box_Model_Scenario_Count":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Stat_Box_Model_Scenario_Count(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
                            break;
                        case "Infrastructure_Stat_Visual_Plumes_Scenario_Count":
                            reportInfrastructureModelQ = ReportServiceGeneratedInfrastructure_Infrastructure_Stat_Visual_Plumes_Scenario_Count(reportInfrastructureModelQ, reportTreeNode, dbFilteringNumberField);
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
                        case "Infrastructure_Is_Active":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Is_Active == true);
                            else
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Is_Active == false);
                            break;
                        case "Infrastructure_Is_Mechanically_Aerated":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Is_Mechanically_Aerated == true);
                            else
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Is_Mechanically_Aerated == false);
                            break;
                        case "Infrastructure_Can_Overflow":
                            if (reportTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                               reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Can_Overflow == true);
                            else
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Can_Overflow == false);
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
                        case "Infrastructure_Name_Translation_Status":
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
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Infrastructure_Name_Translation_Status));
                            }
                            break;
                        case "Infrastructure_Comment_Translation_Status":
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
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => TranslationStatusEqualList.Contains((TranslationStatusEnum)c.Infrastructure_Comment_Translation_Status));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TranslationStatusEnum
            #region Filter InfrastructureTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.InfrastructureType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Infrastructure_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<InfrastructureTypeEnum> InfrastructureTypeEqualList = new List<InfrastructureTypeEnum>();
                                List<string> InfrastructureTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in InfrastructureTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(InfrastructureTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((InfrastructureTypeEnum)i).ToString())
                                        {
                                            InfrastructureTypeEqualList.Add((InfrastructureTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        InfrastructureTypeEqualList.Add(InfrastructureTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => InfrastructureTypeEqualList.Contains((InfrastructureTypeEnum)c.Infrastructure_Infrastructure_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter InfrastructureTypeEnum
            #region Filter FacilityTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.FacilityType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Facility_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<FacilityTypeEnum> FacilityTypeEqualList = new List<FacilityTypeEnum>();
                                List<string> FacilityTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in FacilityTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(FacilityTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((FacilityTypeEnum)i).ToString())
                                        {
                                            FacilityTypeEqualList.Add((FacilityTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        FacilityTypeEqualList.Add(FacilityTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => FacilityTypeEqualList.Contains((FacilityTypeEnum)c.Infrastructure_Facility_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter FacilityTypeEnum
            #region Filter AerationTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.AerationType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Aeration_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<AerationTypeEnum> AerationTypeEqualList = new List<AerationTypeEnum>();
                                List<string> AerationTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in AerationTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(AerationTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((AerationTypeEnum)i).ToString())
                                        {
                                            AerationTypeEqualList.Add((AerationTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        AerationTypeEqualList.Add(AerationTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => AerationTypeEqualList.Contains((AerationTypeEnum)c.Infrastructure_Aeration_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter AerationTypeEnum
            #region Filter PreliminaryTreatmentTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.PreliminaryTreatmentType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Preliminary_Treatment_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<PreliminaryTreatmentTypeEnum> PreliminaryTreatmentTypeEqualList = new List<PreliminaryTreatmentTypeEnum>();
                                List<string> PreliminaryTreatmentTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in PreliminaryTreatmentTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(PreliminaryTreatmentTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((PreliminaryTreatmentTypeEnum)i).ToString())
                                        {
                                            PreliminaryTreatmentTypeEqualList.Add((PreliminaryTreatmentTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        PreliminaryTreatmentTypeEqualList.Add(PreliminaryTreatmentTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => PreliminaryTreatmentTypeEqualList.Contains((PreliminaryTreatmentTypeEnum)c.Infrastructure_Preliminary_Treatment_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter PreliminaryTreatmentTypeEnum
            #region Filter PrimaryTreatmentTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.PrimaryTreatmentType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Primary_Treatment_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<PrimaryTreatmentTypeEnum> PrimaryTreatmentTypeEqualList = new List<PrimaryTreatmentTypeEnum>();
                                List<string> PrimaryTreatmentTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in PrimaryTreatmentTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(PrimaryTreatmentTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((PrimaryTreatmentTypeEnum)i).ToString())
                                        {
                                            PrimaryTreatmentTypeEqualList.Add((PrimaryTreatmentTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        PrimaryTreatmentTypeEqualList.Add(PrimaryTreatmentTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => PrimaryTreatmentTypeEqualList.Contains((PrimaryTreatmentTypeEnum)c.Infrastructure_Primary_Treatment_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter PrimaryTreatmentTypeEnum
            #region Filter SecondaryTreatmentTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.SecondaryTreatmentType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Secondary_Treatment_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<SecondaryTreatmentTypeEnum> SecondaryTreatmentTypeEqualList = new List<SecondaryTreatmentTypeEnum>();
                                List<string> SecondaryTreatmentTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in SecondaryTreatmentTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(SecondaryTreatmentTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((SecondaryTreatmentTypeEnum)i).ToString())
                                        {
                                            SecondaryTreatmentTypeEqualList.Add((SecondaryTreatmentTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        SecondaryTreatmentTypeEqualList.Add(SecondaryTreatmentTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => SecondaryTreatmentTypeEqualList.Contains((SecondaryTreatmentTypeEnum)c.Infrastructure_Secondary_Treatment_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter SecondaryTreatmentTypeEnum
            #region Filter TertiaryTreatmentTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.TertiaryTreatmentType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Tertiary_Treatment_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<TertiaryTreatmentTypeEnum> TertiaryTreatmentTypeEqualList = new List<TertiaryTreatmentTypeEnum>();
                                List<string> TertiaryTreatmentTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in TertiaryTreatmentTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(TertiaryTreatmentTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((TertiaryTreatmentTypeEnum)i).ToString())
                                        {
                                            TertiaryTreatmentTypeEqualList.Add((TertiaryTreatmentTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        TertiaryTreatmentTypeEqualList.Add(TertiaryTreatmentTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => TertiaryTreatmentTypeEqualList.Contains((TertiaryTreatmentTypeEnum)c.Infrastructure_Tertiary_Treatment_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TertiaryTreatmentTypeEnum
            #region Filter TreatmentTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.TreatmentType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Treatment_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<TreatmentTypeEnum> TreatmentTypeEqualList = new List<TreatmentTypeEnum>();
                                List<string> TreatmentTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in TreatmentTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(TreatmentTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((TreatmentTypeEnum)i).ToString())
                                        {
                                            TreatmentTypeEqualList.Add((TreatmentTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        TreatmentTypeEqualList.Add(TreatmentTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => TreatmentTypeEqualList.Contains((TreatmentTypeEnum)c.Infrastructure_Treatment_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter TreatmentTypeEnum
            #region Filter DisinfectionTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.DisinfectionType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Disinfection_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<DisinfectionTypeEnum> DisinfectionTypeEqualList = new List<DisinfectionTypeEnum>();
                                List<string> DisinfectionTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in DisinfectionTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(DisinfectionTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((DisinfectionTypeEnum)i).ToString())
                                        {
                                            DisinfectionTypeEqualList.Add((DisinfectionTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        DisinfectionTypeEqualList.Add(DisinfectionTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => DisinfectionTypeEqualList.Contains((DisinfectionTypeEnum)c.Infrastructure_Disinfection_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter DisinfectionTypeEnum
            #region Filter CollectionSystemTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.CollectionSystemType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Collection_System_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<CollectionSystemTypeEnum> CollectionSystemTypeEqualList = new List<CollectionSystemTypeEnum>();
                                List<string> CollectionSystemTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in CollectionSystemTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(CollectionSystemTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((CollectionSystemTypeEnum)i).ToString())
                                        {
                                            CollectionSystemTypeEqualList.Add((CollectionSystemTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        CollectionSystemTypeEqualList.Add(CollectionSystemTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => CollectionSystemTypeEqualList.Contains((CollectionSystemTypeEnum)c.Infrastructure_Collection_System_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter CollectionSystemTypeEnum
            #region Filter AlarmSystemTypeEnum
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringEnumFieldList.Count > 0 && c.ReportFieldType == ReportFieldTypeEnum.AlarmSystemType))
            {
                foreach (ReportConditionEnumField reportEnumField in reportTreeNode.dbFilteringEnumFieldList)
                {
                    switch (reportTreeNode.Text)
                    {
                        case "Infrastructure_Alarm_System_Type":
                            if (reportEnumField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                            {
                                List<AlarmSystemTypeEnum> AlarmSystemTypeEqualList = new List<AlarmSystemTypeEnum>();
                                List<string> AlarmSystemTypeTextList = reportEnumField.EnumConditionText.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                                foreach (string s in AlarmSystemTypeTextList)
                                {
                                    bool Found = false;
                                    for (int i = 1, count = Enum.GetNames(typeof(AlarmSystemTypeEnum)).Count(); i < count; i++)
                                    {
                                        if (s == ((AlarmSystemTypeEnum)i).ToString())
                                        {
                                            AlarmSystemTypeEqualList.Add((AlarmSystemTypeEnum)i);
                                        }
                                    }
                                    if (!Found)
                                        AlarmSystemTypeEqualList.Add(AlarmSystemTypeEnum.Error);
                                }
                                reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => AlarmSystemTypeEqualList.Contains((AlarmSystemTypeEnum)c.Infrastructure_Alarm_System_Type));
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion Filter AlarmSystemTypeEnum
            return reportInfrastructureModelQ;
        }

        // Date Functions
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_YEAR(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_YEAR(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_YEAR(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear != null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year > reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year < reportConditionDateField.DateTimeConditionYear);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Year == reportConditionDateField.DateTimeConditionYear);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_MONTH(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_MONTH(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_MONTH(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth != null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month > reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month < reportConditionDateField.DateTimeConditionMonth);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Month == reportConditionDateField.DateTimeConditionMonth);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_DAY(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_DAY(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_DAY(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay != null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour)
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day > reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day < reportConditionDateField.DateTimeConditionDay);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Day == reportConditionDateField.DateTimeConditionDay);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_HOUR(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_HOUR(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_HOUR(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour != null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour
                                                                     || (c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute));
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour
                                                                     && c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
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
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour > reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour < reportConditionDateField.DateTimeConditionHour);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Hour == reportConditionDateField.DateTimeConditionHour);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_UTC_MINUTE(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Date_UTC_MINUTE(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Date_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Date_And_Time_UTC_MINUTE(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionDateField reportConditionDateField)
        {
            if (reportConditionDateField.DateTimeConditionYear == null && reportConditionDateField.DateTimeConditionMonth == null && reportConditionDateField.DateTimeConditionDay == null && reportConditionDateField.DateTimeConditionHour == null && reportConditionDateField.DateTimeConditionMinute != null)
            {
                switch (reportConditionDateField.ReportCondition)
                {
                    case ReportConditionEnum.ReportConditionBigger:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute > reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionSmaller:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute < reportConditionDateField.DateTimeConditionMinute);
                        break;
                    case ReportConditionEnum.ReportConditionEqual:
                        reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Date_And_Time_UTC.Value.Minute == reportConditionDateField.DateTimeConditionMinute);
                        break;
                    default:
                        break;
                }
            }
            return reportInfrastructureModelQ;
        }

        // Text Functions
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Error(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Error.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Error.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Error.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Error.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Error.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Name(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Contact_Name(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Last_Update_Contact_Initial(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Contact_Name(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Contact_Name.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Contact_Name.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Contact_Name.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Contact_Name.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Comment_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Comment_Last_Update_Contact_Name.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Comment_Last_Update_Contact_Initial(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Contact_Initial.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Contact_Initial.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Contact_Initial.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment_Last_Update_Contact_Initial.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Comment_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Comment_Last_Update_Contact_Initial.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Comment(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Comment.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Comment.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Infrastructure_Category(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Infrastructure_Category.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Infrastructure_Category.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Infrastructure_Category.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Infrastructure_Category.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Infrastructure_Category.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Infrastructure_Category.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Temp_Catch_All_Remove_Later(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Temp_Catch_All_Remove_Later.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Temp_Catch_All_Remove_Later.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Temp_Catch_All_Remove_Later.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Temp_Catch_All_Remove_Later.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Temp_Catch_All_Remove_Later.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Temp_Catch_All_Remove_Later.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Civic_Address(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Civic_Address.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Civic_Address.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Civic_Address.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Civic_Address.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Civic_Address.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Civic_Address.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Google_Address(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionTextField dbFilteringTextField)
        {
            switch (dbFilteringTextField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionContain:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Google_Address.ToLower().Contains(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionStart:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Google_Address.ToLower().StartsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEnd:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Google_Address.ToLower().EndsWith(dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")));
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Google_Address.ToLower() == dbFilteringTextField.TextCondition.ToLower().Replace("*", " "));
                    break;
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Google_Address.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) > 0 );
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => String.Compare(c.Infrastructure_Google_Address.ToLower(), dbFilteringTextField.TextCondition.ToLower().Replace("*", " ")) < 0 );
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }

        // Number Functions
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Counter(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Counter > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Counter < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Counter == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_ID(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Prism_ID(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Prism_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Prism_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Prism_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_TPID(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_TPID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_TPID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_TPID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_LSID(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_LSID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_LSID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_LSID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Site_ID(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Site_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Site_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Site_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Site(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Site > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Site < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Site == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Number_Of_Cells(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Cells > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Cells < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Cells == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Number_Of_Aerated_Cells(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Aerated_Cells > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Aerated_Cells < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Aerated_Cells == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Design_Flow_m3_day(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Design_Flow_m3_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Design_Flow_m3_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Design_Flow_m3_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Average_Flow_m3_day(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Average_Flow_m3_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Average_Flow_m3_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Average_Flow_m3_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Peak_Flow_m3_day(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Peak_Flow_m3_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Peak_Flow_m3_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Peak_Flow_m3_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Pop_Served(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Pop_Served > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Pop_Served < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Pop_Served == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Perc_Flow_Of_Total(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Perc_Flow_Of_Total > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Perc_Flow_Of_Total < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Perc_Flow_Of_Total == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Time_Offset_hour(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Time_Offset_hour > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Time_Offset_hour < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Time_Offset_hour == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Average_Depth_m(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Average_Depth_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Average_Depth_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Average_Depth_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Number_Of_Ports(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Ports > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Ports < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Number_Of_Ports == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Port_Diameter_m(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Diameter_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Diameter_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Diameter_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Port_Spacing_m(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Spacing_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Spacing_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Spacing_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Port_Elevation_m(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Elevation_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Elevation_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Port_Elevation_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Vertical_Angle_deg(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Vertical_Angle_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Vertical_Angle_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Vertical_Angle_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Horizontal_Angle_deg(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Horizontal_Angle_deg > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Horizontal_Angle_deg < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Horizontal_Angle_deg == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Decay_Rate_per_day(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Decay_Rate_per_day > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Decay_Rate_per_day < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Decay_Rate_per_day == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Near_Field_Velocity_m_s(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Near_Field_Velocity_m_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Near_Field_Velocity_m_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Near_Field_Velocity_m_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Far_Field_Velocity_m_s(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Far_Field_Velocity_m_s > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Far_Field_Velocity_m_s < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Far_Field_Velocity_m_s == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Receiving_Water_Salinity_PSU(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_Salinity_PSU > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_Salinity_PSU < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_Salinity_PSU == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Receiving_Water_Temperature_C(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_Temperature_C > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_Temperature_C < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_Temperature_C == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Receiving_Water_MPN_per_100_ml(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_MPN_per_100_ml > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_MPN_per_100_ml < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Receiving_Water_MPN_per_100_ml == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Distance_From_Shore_m(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Distance_From_Shore_m > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Distance_From_Shore_m < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Distance_From_Shore_m == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_See_Other_ID(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_See_Other_ID > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_See_Other_ID < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_See_Other_ID == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Lat(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Lng(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Outfall_Lat(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Outfall_Lat > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Outfall_Lat < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Outfall_Lat == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Outfall_Lng(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Outfall_Lng > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Outfall_Lng < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Outfall_Lng == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Stat_Box_Model_Scenario_Count(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Stat_Box_Model_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Stat_Box_Model_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Stat_Box_Model_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
        public IQueryable<ReportInfrastructureModel> ReportServiceGeneratedInfrastructure_Infrastructure_Stat_Visual_Plumes_Scenario_Count(IQueryable<ReportInfrastructureModel> reportInfrastructureModelQ, ReportTreeNode reportTreeNode, ReportConditionNumberField dbFilteringNumberField)
        {
            switch (dbFilteringNumberField.ReportCondition)
            {
                case ReportConditionEnum.ReportConditionBigger:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Stat_Visual_Plumes_Scenario_Count > dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionSmaller:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Stat_Visual_Plumes_Scenario_Count < dbFilteringNumberField.NumberCondition);
                    break;
                case ReportConditionEnum.ReportConditionEqual:
                    reportInfrastructureModelQ = reportInfrastructureModelQ.Where(c => c.Infrastructure_Stat_Visual_Plumes_Scenario_Count == dbFilteringNumberField.NumberCondition);
                    break;
                default:
                    break;
            }

            return reportInfrastructureModelQ;
        }
    }
}
