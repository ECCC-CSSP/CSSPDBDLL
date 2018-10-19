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
using CSSPReportWriterHelperDLL.Services;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public partial class ReportServiceMWQM_Run_Lab_Sheet_Detail : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMWQM_Run_Lab_Sheet_Detail(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMWQM_Run_Lab_Sheet_DetailModel> GetReportMWQM_Run_Lab_Sheet_DetailModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMWQM_Run_Lab_Sheet_DetailModel> reportMWQM_Run_Lab_Sheet_DetailModelList = new List<ReportMWQM_Run_Lab_Sheet_DetailModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MWQM_Run_Lab_Sheet_Detail";
            int Counter = 0;
            IQueryable<ReportMWQM_Run_Lab_Sheet_DetailModel> reportMWQM_Run_Lab_Sheet_DetailModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMWQM_Run_Lab_Sheet_DetailModel>() { new ReportMWQM_Run_Lab_Sheet_DetailModel() { MWQM_Run_Lab_Sheet_Detail_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            LabSheet labSheet = (from c in db.LabSheets
                                 where c.LabSheetID == UnderTVItemID
                                 select c).FirstOrDefault();

            if (labSheet == null)
                return new List<ReportMWQM_Run_Lab_Sheet_DetailModel>() { new ReportMWQM_Run_Lab_Sheet_DetailModel() { MWQM_Run_Lab_Sheet_Detail_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheet, ServiceRes.LabSheetID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem) || ParentTagItem != "MWQM_Run_Lab_Sheet")
                return new List<ReportMWQM_Run_Lab_Sheet_DetailModel>() { new ReportMWQM_Run_Lab_Sheet_DetailModel() { MWQM_Run_Lab_Sheet_Detail_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "MWQM_Run_Lab_Sheet", ParentTagItem) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMWQM_Run_Lab_Sheet_DetailModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_Run_Lab_Sheet_DetailModel>() { new ReportMWQM_Run_Lab_Sheet_DetailModel() { MWQM_Run_Lab_Sheet_Detail_Error = retStr } };

            reportMWQM_Run_Lab_Sheet_DetailModelQ =
            (from lsd in db.LabSheetDetails
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == lsd.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where lsd.LabSheetID == UnderTVItemID
             select new ReportMWQM_Run_Lab_Sheet_DetailModel
             {
                 MWQM_Run_Lab_Sheet_Detail_Error = "",
                 MWQM_Run_Lab_Sheet_Detail_Counter = 0,
                 MWQM_Run_Lab_Sheet_Detail_ID = lsd.LabSheetDetailID,
                 MWQM_Run_Lab_Sheet_Detail_Version = lsd.Version.ToString(),
                 MWQM_Run_Lab_Sheet_Detail_Run_Date = lsd.RunDate,
                 MWQM_Run_Lab_Sheet_Detail_Tides = lsd.Tides,
                 MWQM_Run_Lab_Sheet_Detail_Sample_Crew_Initials = lsd.SampleCrewInitials,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath1_Start_Time = lsd.IncubationBath1StartTime,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath2_Start_Time = lsd.IncubationBath2StartTime,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath3_Start_Time = lsd.IncubationBath3StartTime,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath1_End_Time = lsd.IncubationBath1EndTime,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath2_End_Time = lsd.IncubationBath2EndTime,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath3_End_Time = lsd.IncubationBath3EndTime,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath1_Time_Calculated_minutes = lsd.IncubationBath1TimeCalculated_minutes,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath2_Time_Calculated_minutes = lsd.IncubationBath2TimeCalculated_minutes,
                 MWQM_Run_Lab_Sheet_Detail_Incubation_Bath3_Time_Calculated_minutes = lsd.IncubationBath3TimeCalculated_minutes,
                 MWQM_Run_Lab_Sheet_Detail_Water_Bath1 = lsd.WaterBath1,
                 MWQM_Run_Lab_Sheet_Detail_Water_Bath2 = lsd.WaterBath2,
                 MWQM_Run_Lab_Sheet_Detail_Water_Bath3 = lsd.WaterBath3,
                 MWQM_Run_Lab_Sheet_Detail_TC_Field_1 = (float?)lsd.TCField1,
                 MWQM_Run_Lab_Sheet_Detail_TC_Lab_1 = (float?)lsd.TCLab1,
                 MWQM_Run_Lab_Sheet_Detail_TC_Field_2 = (float?)lsd.TCField2,
                 MWQM_Run_Lab_Sheet_Detail_TC_Lab_2 = (float?)lsd.TCLab2,
                 MWQM_Run_Lab_Sheet_Detail_TC_First = (float?)lsd.TCFirst,
                 MWQM_Run_Lab_Sheet_Detail_TC_Average = (float?)lsd.TCAverage,
                 MWQM_Run_Lab_Sheet_Detail_Control_Lot = lsd.ControlLot,
                 MWQM_Run_Lab_Sheet_Detail_Positive_35 = lsd.Positive35,
                 MWQM_Run_Lab_Sheet_Detail_Non_Target_35 = lsd.NonTarget35,
                 MWQM_Run_Lab_Sheet_Detail_Negative_35 = lsd.Negative35,
                 MWQM_Run_Lab_Sheet_Detail_Bath1_Positive_44_5 = lsd.Bath1Positive44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath2_Positive_44_5 = lsd.Bath2Positive44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath3_Positive_44_5 = lsd.Bath3Positive44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath1_Non_Target_44_5 = lsd.Bath1NonTarget44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath2_Non_Target_44_5 = lsd.Bath2NonTarget44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath3_Non_Target_44_5 = lsd.Bath3NonTarget44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath1_Negative_44_5 = lsd.Bath1Negative44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath2_Negative_44_5 = lsd.Bath2Negative44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath3_Negative_44_5 = lsd.Bath3Negative44_5,
                 MWQM_Run_Lab_Sheet_Detail_Blank_35 = lsd.Blank35,
                 MWQM_Run_Lab_Sheet_Detail_Bath1_Blank_44_5 = lsd.Bath1Blank44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath2_Blank_44_5 = lsd.Bath2Blank44_5,
                 MWQM_Run_Lab_Sheet_Detail_Bath3_Blank_44_5 = lsd.Bath3Blank44_5,
                 MWQM_Run_Lab_Sheet_Detail_Lot_35 = lsd.Lot35,
                 MWQM_Run_Lab_Sheet_Detail_Lot_44_5 = lsd.Lot44_5,
                 MWQM_Run_Lab_Sheet_Detail_Run_Comment = lsd.RunComment,
                 MWQM_Run_Lab_Sheet_Detail_Run_Weather_Comment = lsd.RunWeatherComment,
                 MWQM_Run_Lab_Sheet_Detail_Sample_Bottle_Lot_Number = lsd.SampleBottleLotNumber,
                 MWQM_Run_Lab_Sheet_Detail_Salinities_Read_By = lsd.SalinitiesReadBy,
                 MWQM_Run_Lab_Sheet_Detail_Salinities_Read_Date = lsd.SalinitiesReadDate,
                 MWQM_Run_Lab_Sheet_Detail_Results_Read_By = lsd.ResultsReadBy,
                 MWQM_Run_Lab_Sheet_Detail_Results_Read_Date = lsd.ResultsReadDate,
                 MWQM_Run_Lab_Sheet_Detail_Results_Recorded_By = lsd.ResultsRecordedBy,
                 MWQM_Run_Lab_Sheet_Detail_Results_Recorded_Date = lsd.ResultsRecordedDate,
                 MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_R_Log = (float?)lsd.DailyDuplicateRLog,
                 MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_Precision_Criteria = (float?)lsd.DailyDuplicatePrecisionCriteria,
                 MWQM_Run_Lab_Sheet_Detail_Daily_Duplicate_Acceptable = lsd.DailyDuplicateAcceptable,
                 MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_R_Log = (float?)lsd.IntertechDuplicateRLog,
                 MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_Precision_Criteria = (float?)lsd.IntertechDuplicatePrecisionCriteria,
                 MWQM_Run_Lab_Sheet_Detail_Intertech_Duplicate_Acceptable = lsd.IntertechDuplicateAcceptable,
                 MWQM_Run_Lab_Sheet_Detail_Intertech_Read_Acceptable = lsd.IntertechReadAcceptable,
                 MWQM_Run_Lab_Sheet_Detail_Last_Update_Date_UTC = lsd.LastUpdateDate_UTC,
                 MWQM_Run_Lab_Sheet_Detail_Last_Update_Contact_Name = contact.contactName,
                 MWQM_Run_Lab_Sheet_Detail_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportMWQM_Run_Lab_Sheet_DetailModelQ = ReportServiceGeneratedMWQM_Run_Lab_Sheet_Detail(reportMWQM_Run_Lab_Sheet_DetailModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMWQM_Run_Lab_Sheet_DetailModel>() { new ReportMWQM_Run_Lab_Sheet_DetailModel() { MWQM_Run_Lab_Sheet_Detail_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMWQM_Run_Lab_Sheet_DetailModel>() { new ReportMWQM_Run_Lab_Sheet_DetailModel() { MWQM_Run_Lab_Sheet_Detail_Counter = reportMWQM_Run_Lab_Sheet_DetailModelQ.Count() } };

                reportMWQM_Run_Lab_Sheet_DetailModelList = reportMWQM_Run_Lab_Sheet_DetailModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_Run_Lab_Sheet_DetailModel>() { new ReportMWQM_Run_Lab_Sheet_DetailModel() { MWQM_Run_Lab_Sheet_Detail_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_Run_Lab_Sheet_DetailModel reportMWQM_Run_Lab_Sheet_DetailModel in reportMWQM_Run_Lab_Sheet_DetailModelList)
            {
                Counter += 1;
                reportMWQM_Run_Lab_Sheet_DetailModel.MWQM_Run_Lab_Sheet_Detail_Counter = Counter;
            }

            return reportMWQM_Run_Lab_Sheet_DetailModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}