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
    public partial class ReportServiceMWQM_Run : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMWQM_Run(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMWQM_RunModel> GetReportMWQM_RunModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMWQM_RunModel> reportMWQM_RunModelList = new List<ReportMWQM_RunModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MWQM_Run";
            int Counter = 0;
            IQueryable<ReportMWQM_RunModel> reportMWQM_RunModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMWQM_RunModel>() { new ReportMWQM_RunModel() { MWQM_Run_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMRun)
                    return new List<ReportMWQM_RunModel>() { new ReportMWQM_RunModel() { MWQM_Run_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMRun.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMRun)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMWQM_RunModel>() { new ReportMWQM_RunModel() { MWQM_Run_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMWQM_RunModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_RunModel>() { new ReportMWQM_RunModel() { MWQM_Run_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.MWQMRun)
            {
                reportMWQM_RunModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from r in db.MWQMRuns
                 from rl in db.MWQMRunLanguages
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactApproval = (from cc in db.Contacts
                                        let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                        let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                        where cc.ContactTVItemID == r.LabSampleApprovalContactTVItemID
                                        select new { contactName, contactInitial }).FirstOrDefault()
                 let stat = (from st in db.TVItemStats
                             where st.TVItemID == c.TVItemID
                             select st)
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == r.MWQMRunTVItemID
                 && r.MWQMRunID == rl.MWQMRunID
                 && c.TVType == (int)TVTypeEnum.MWQMRun
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 && rl.Language == (int)Language
                 select new ReportMWQM_RunModel
                 {
                     MWQM_Run_Error = "",
                     MWQM_Run_Counter = 0,
                     MWQM_Run_ID = c.TVItemID,
                     MWQM_Run_Name = cl.TVText,
                     MWQM_Run_Is_Active = c.IsActive,
                     MWQM_Run_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     MWQM_Run_Date_Time_Local = r.DateTime_Local,
                     MWQM_Run_Start_Date_Time_Local = r.StartDateTime_Local,
                     MWQM_Run_End_Date_Time_Local = r.EndDateTime_Local,
                     MWQM_Run_Lab_Received_Date_Time_Local = r.LabRunSampleApprovalDateTime_Local,
                     MWQM_Run_Temperature_Control_1_C = (float?)r.TemperatureControl1_C,
                     MWQM_Run_Temperature_Control_2_C = (float?)r.TemperatureControl2_C,
                     MWQM_Run_Sea_State_At_Start_Beaufort_Scale = (BeaufortScaleEnum?)r.SeaStateAtStart_BeaufortScale,
                     MWQM_Run_Sea_State_At_End_Beaufort_Scale = (BeaufortScaleEnum?)r.SeaStateAtEnd_BeaufortScale,
                     MWQM_Run_Water_Level_At_Brook_m = (float?)r.WaterLevelAtBrook_m,
                     MWQM_Run_Wave_Hight_At_Start_m = (float?)r.WaveHightAtStart_m,
                     MWQM_Run_Wave_Hight_At_End_m = (float?)r.WaveHightAtEnd_m,
                     MWQM_Run_Sample_Crew_Initials = r.SampleCrewInitials,
                     MWQM_Run_Analyze_Method = (AnalyzeMethodEnum?)r.AnalyzeMethod,
                     MWQM_Run_Sample_Matrix = (SampleMatrixEnum?)r.SampleMatrix,
                     MWQM_Run_Laboratory = (LaboratoryEnum?)r.Laboratory,
                     MWQM_Run_Sample_Status = (SampleStatusEnum?)r.SampleStatus,
                     MWQM_Run_Lab_Sample_Approval_Contact_Name = contactApproval.contactName,
                     MWQM_Run_Lab_Sample_Approval_Contact_Initial = contactApproval.contactInitial,
                     MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local = r.LabAnalyzeBath1IncubationStartDateTime_Local,
                     MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local = r.LabAnalyzeBath2IncubationStartDateTime_Local,
                     MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local = r.LabAnalyzeBath3IncubationStartDateTime_Local,
                     MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local = r.LabRunSampleApprovalDateTime_Local,
                     MWQM_Run_Rain_Day_0_mm = (float?)r.RainDay0_mm,
                     MWQM_Run_Rain_Day_1_mm = (float?)r.RainDay1_mm,
                     MWQM_Run_Rain_Day_2_mm = (float?)r.RainDay2_mm,
                     MWQM_Run_Rain_Day_3_mm = (float?)r.RainDay3_mm,
                     MWQM_Run_Rain_Day_4_mm = (float?)r.RainDay4_mm,
                     MWQM_Run_Rain_Day_5_mm = (float?)r.RainDay5_mm,
                     MWQM_Run_Rain_Day_6_mm = (float?)r.RainDay6_mm,
                     MWQM_Run_Rain_Day_7_mm = (float?)r.RainDay7_mm,
                     MWQM_Run_Rain_Day_8_mm = (float?)r.RainDay8_mm,
                     MWQM_Run_Rain_Day_9_mm = (float?)r.RainDay9_mm,
                     MWQM_Run_Rain_Day_10_mm = (float?)r.RainDay10_mm,
                     MWQM_Run_Comment_Translation_Status = (TranslationStatusEnum?)rl.TranslationStatusRunComment,
                     MWQM_Run_Comment = rl.RunComment,
                     MWQM_Run_Weather_Comment_Translation_Status = (TranslationStatusEnum?)rl.TranslationStatusRunWeatherComment,
                     MWQM_Run_Weather_Comment = rl.RunWeatherComment,
                     MWQM_Run_Last_Update_Date_And_Time_UTC = r.LastUpdateDate_UTC,
                     MWQM_Run_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Run_Last_Update_Contact_Initial = contact.contactInitial,
                     MWQM_Run_Stat_MWQM_Site_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.MWQMSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     MWQM_Run_Stat_Sample_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.MWQMSiteSample).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                 });
            }
            else
            {
                reportMWQM_RunModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from r in db.MWQMRuns
                 from rl in db.MWQMRunLanguages
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactApproval = (from cc in db.Contacts
                                        let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                        let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                        where cc.ContactTVItemID == r.LabSampleApprovalContactTVItemID
                                        select new { contactName, contactInitial }).FirstOrDefault()
                 let stat = (from st in db.TVItemStats
                             where st.TVItemID == c.TVItemID
                             select st)
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == r.MWQMRunTVItemID
                 && r.MWQMRunID == rl.MWQMRunID
                 && c.TVType == (int)TVTypeEnum.MWQMRun
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 && rl.Language == (int)Language
                 select new ReportMWQM_RunModel
                 {
                     MWQM_Run_Error = "",
                     MWQM_Run_Counter = 0,
                     MWQM_Run_ID = c.TVItemID,
                     MWQM_Run_Name = cl.TVText,
                     MWQM_Run_Is_Active = c.IsActive,
                     MWQM_Run_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     MWQM_Run_Date_Time_Local = r.DateTime_Local,
                     MWQM_Run_Start_Date_Time_Local = r.StartDateTime_Local,
                     MWQM_Run_End_Date_Time_Local = r.EndDateTime_Local,
                     MWQM_Run_Lab_Received_Date_Time_Local = r.LabRunSampleApprovalDateTime_Local,
                     MWQM_Run_Temperature_Control_1_C = (float?)r.TemperatureControl1_C,
                     MWQM_Run_Temperature_Control_2_C = (float?)r.TemperatureControl2_C,
                     MWQM_Run_Sea_State_At_Start_Beaufort_Scale = (BeaufortScaleEnum?)r.SeaStateAtStart_BeaufortScale,
                     MWQM_Run_Sea_State_At_End_Beaufort_Scale = (BeaufortScaleEnum?)r.SeaStateAtEnd_BeaufortScale,
                     MWQM_Run_Water_Level_At_Brook_m = (float?)r.WaterLevelAtBrook_m,
                     MWQM_Run_Wave_Hight_At_Start_m = (float?)r.WaveHightAtStart_m,
                     MWQM_Run_Wave_Hight_At_End_m = (float?)r.WaveHightAtEnd_m,
                     MWQM_Run_Sample_Crew_Initials = r.SampleCrewInitials,
                     MWQM_Run_Analyze_Method = (AnalyzeMethodEnum?)r.AnalyzeMethod,
                     MWQM_Run_Sample_Matrix = (SampleMatrixEnum?)r.SampleMatrix,
                     MWQM_Run_Laboratory = (LaboratoryEnum?)r.Laboratory,
                     MWQM_Run_Sample_Status = (SampleStatusEnum?)r.SampleStatus,
                     MWQM_Run_Lab_Sample_Approval_Contact_Name = contactApproval.contactName,
                     MWQM_Run_Lab_Sample_Approval_Contact_Initial = contactApproval.contactInitial,
                     MWQM_Run_Lab_Analyze_Bath1_Incubation_Start_Date_Time_Local = r.LabAnalyzeBath1IncubationStartDateTime_Local,
                     MWQM_Run_Lab_Analyze_Bath2_Incubation_Start_Date_Time_Local = r.LabAnalyzeBath2IncubationStartDateTime_Local,
                     MWQM_Run_Lab_Analyze_Bath3_Incubation_Start_Date_Time_Local = r.LabAnalyzeBath3IncubationStartDateTime_Local,
                     MWQM_Run_Lab_Run_Sample_Approval_Date_Time_Local = r.LabRunSampleApprovalDateTime_Local,
                     MWQM_Run_Rain_Day_0_mm = (float?)r.RainDay0_mm,
                     MWQM_Run_Rain_Day_1_mm = (float?)r.RainDay1_mm,
                     MWQM_Run_Rain_Day_2_mm = (float?)r.RainDay2_mm,
                     MWQM_Run_Rain_Day_3_mm = (float?)r.RainDay3_mm,
                     MWQM_Run_Rain_Day_4_mm = (float?)r.RainDay4_mm,
                     MWQM_Run_Rain_Day_5_mm = (float?)r.RainDay5_mm,
                     MWQM_Run_Rain_Day_6_mm = (float?)r.RainDay6_mm,
                     MWQM_Run_Rain_Day_7_mm = (float?)r.RainDay7_mm,
                     MWQM_Run_Rain_Day_8_mm = (float?)r.RainDay8_mm,
                     MWQM_Run_Rain_Day_9_mm = (float?)r.RainDay9_mm,
                     MWQM_Run_Rain_Day_10_mm = (float?)r.RainDay10_mm,
                     MWQM_Run_Comment_Translation_Status = (TranslationStatusEnum?)rl.TranslationStatusRunComment,
                     MWQM_Run_Comment = rl.RunComment,
                     MWQM_Run_Weather_Comment_Translation_Status = (TranslationStatusEnum?)rl.TranslationStatusRunWeatherComment,
                     MWQM_Run_Weather_Comment = rl.RunWeatherComment,
                     MWQM_Run_Last_Update_Date_And_Time_UTC = r.LastUpdateDate_UTC,
                     MWQM_Run_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Run_Last_Update_Contact_Initial = contact.contactInitial,
                     MWQM_Run_Stat_MWQM_Site_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.MWQMSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                     MWQM_Run_Stat_Sample_Count = stat.Where(a => a.TVType == (int)TVTypeEnum.MWQMSiteSample).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault(),
                 });
            }

            try
            {
                reportMWQM_RunModelQ = ReportServiceGeneratedMWQM_Run(reportMWQM_RunModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMWQM_RunModel>() { new ReportMWQM_RunModel() { MWQM_Run_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMWQM_RunModel>() { new ReportMWQM_RunModel() { MWQM_Run_Counter = reportMWQM_RunModelQ.Count() } };

                reportMWQM_RunModelList = reportMWQM_RunModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_RunModel>() { new ReportMWQM_RunModel() { MWQM_Run_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_RunModel reportMWQM_RunModel in reportMWQM_RunModelList)
            {
                Counter += 1;
                reportMWQM_RunModel.MWQM_Run_Counter = Counter;
            }

            return reportMWQM_RunModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}