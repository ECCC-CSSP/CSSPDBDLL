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
    public partial class ReportServiceMike_Scenario : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMike_Scenario(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMike_ScenarioModel> GetReportMike_ScenarioModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
            List<ReportMike_ScenarioModel> reportMike_ScenarioModelList = new List<ReportMike_ScenarioModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Mike_Scenario";
            int Counter = 0;
            IQueryable<ReportMike_ScenarioModel> ReportMike_ScenarioModelQ = null;

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMike_ScenarioModel>() { new ReportMike_ScenarioModel() { Mike_Scenario_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.MikeScenario)
                    return new List<ReportMike_ScenarioModel>() { new ReportMike_ScenarioModel() { Mike_Scenario_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Infrastructure.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.MikeScenario)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMike_ScenarioModel>() { new ReportMike_ScenarioModel() { Mike_Scenario_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMike_ScenarioModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMike_ScenarioModel>() { new ReportMike_ScenarioModel() { Mike_Scenario_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.MikeScenario)
            {
                ReportMike_ScenarioModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from ms in db.MikeScenarios
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == ms.MikeScenarioTVItemID
                 && c.TVType == (int)TVTypeEnum.MikeScenario
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 select new ReportMike_ScenarioModel
                 {
                     Mike_Scenario_Error = "",
                     Mike_Scenario_Counter = 0,
                     Mike_Scenario_Ambient_Salinity_PSU = (float)ms.AmbientSalinity_PSU,
                     Mike_Scenario_Ambient_Temperature_C = (float)ms.AmbientTemperature_C,
                     Mike_Scenario_Decay_Factor_Amplitude = (float)ms.DecayFactorAmplitude,
                     Mike_Scenario_Decay_Factor_per_day = (float)ms.DecayFactor_per_day,
                     Mike_Scenario_Decay_Is_Constant = ms.DecayIsConstant,
                     Mike_Scenario_End_Date_Time_Local = ms.MikeScenarioEndDateTime_Local,
                     Mike_Scenario_ErrorInfo = ms.ErrorInfo,
                     Mike_Scenario_Estimated_Hydro_File_Size = (int?)ms.EstimatedHydroFileSize,
                     Mike_Scenario_Estimated_Trans_File_Size = (int?)ms.EstimatedTransFileSize,
                     Mike_Scenario_Execution_Time_min = (float?)ms.MikeScenarioExecutionTime_min,
                     Mike_Scenario_ID = ms.MikeScenarioTVItemID,
                     Mike_Scenario_Is_Active = c.IsActive,
                     Mike_Scenario_Last_Update_Contact_Initial = contact.contactInitial,
                     Mike_Scenario_Last_Update_Contact_Name = contact.contactName,
                     Mike_Scenario_Last_Update_Date_And_Time_UTC = ms.LastUpdateDate_UTC,
                     Mike_Scenario_Manning_Number = (float?)ms.ManningNumber,
                     Mike_Scenario_Name = cl.TVText,
                     Mike_Scenario_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     Mike_Scenario_Number_Of_Elements = ms.NumberOfElements,
                     Mike_Scenario_Number_Of_Hydro_Output_Parameters = ms.NumberOfHydroOutputParameters,
                     Mike_Scenario_Number_Of_Sigma_Layers = ms.NumberOfSigmaLayers,
                     Mike_Scenario_Number_Of_Time_Steps = ms.NumberOfTimeSteps,
                     Mike_Scenario_Number_Of_Trans_Output_Parameters = ms.NumberOfTransOutputParameters,
                     Mike_Scenario_Number_Of_Z_Layers = ms.NumberOfZLayers,
                     Mike_Scenario_Result_Frequency_min = ms.ResultFrequency_min,
                     Mike_Scenario_Start_Date_Time_Local = ms.MikeScenarioStartDateTime_Local,
                     Mike_Scenario_Start_Execution_Date_Time_Local = ms.MikeScenarioStartExecutionDateTime_Local,
                     Mike_Scenario_Status = (ScenarioStatusEnum)ms.ScenarioStatus,
                     Mike_Scenario_Wind_Direction_deg = (float)ms.WindDirection_deg,
                     Mike_Scenario_Wind_Speed_km_h = (float)ms.WindSpeed_km_h,
                 });
            }
            else
            {
                ReportMike_ScenarioModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from ms in db.MikeScenarios
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == ms.MikeScenarioTVItemID
                 && c.TVType == (int)TVTypeEnum.MikeScenario
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportMike_ScenarioModel
                 {
                     Mike_Scenario_Error = "",
                     Mike_Scenario_Counter = 0,
                     Mike_Scenario_Ambient_Salinity_PSU = (float)ms.AmbientSalinity_PSU,
                     Mike_Scenario_Ambient_Temperature_C = (float)ms.AmbientTemperature_C,
                     Mike_Scenario_Decay_Factor_Amplitude = (float)ms.DecayFactorAmplitude,
                     Mike_Scenario_Decay_Factor_per_day = (float)ms.DecayFactor_per_day,
                     Mike_Scenario_Decay_Is_Constant = ms.DecayIsConstant,
                     Mike_Scenario_End_Date_Time_Local = ms.MikeScenarioEndDateTime_Local,
                     Mike_Scenario_ErrorInfo = ms.ErrorInfo,
                     Mike_Scenario_Estimated_Hydro_File_Size = (int?)ms.EstimatedHydroFileSize,
                     Mike_Scenario_Estimated_Trans_File_Size = (int?)ms.EstimatedTransFileSize,
                     Mike_Scenario_Execution_Time_min = (float?)ms.MikeScenarioExecutionTime_min,
                     Mike_Scenario_ID = ms.MikeScenarioTVItemID,
                     Mike_Scenario_Is_Active = c.IsActive,
                     Mike_Scenario_Last_Update_Contact_Initial = contact.contactInitial,
                     Mike_Scenario_Last_Update_Contact_Name = contact.contactName,
                     Mike_Scenario_Last_Update_Date_And_Time_UTC = ms.LastUpdateDate_UTC,
                     Mike_Scenario_Manning_Number = (float?)ms.ManningNumber,
                     Mike_Scenario_Name = cl.TVText,
                     Mike_Scenario_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                     Mike_Scenario_Number_Of_Elements = ms.NumberOfElements,
                     Mike_Scenario_Number_Of_Hydro_Output_Parameters = ms.NumberOfHydroOutputParameters,
                     Mike_Scenario_Number_Of_Sigma_Layers = ms.NumberOfSigmaLayers,
                     Mike_Scenario_Number_Of_Time_Steps = ms.NumberOfTimeSteps,
                     Mike_Scenario_Number_Of_Trans_Output_Parameters = ms.NumberOfTransOutputParameters,
                     Mike_Scenario_Number_Of_Z_Layers = ms.NumberOfZLayers,
                     Mike_Scenario_Result_Frequency_min = ms.ResultFrequency_min,
                     Mike_Scenario_Start_Date_Time_Local = ms.MikeScenarioStartDateTime_Local,
                     Mike_Scenario_Start_Execution_Date_Time_Local = ms.MikeScenarioStartExecutionDateTime_Local,
                     Mike_Scenario_Status = (ScenarioStatusEnum)ms.ScenarioStatus,
                     Mike_Scenario_Wind_Direction_deg = (float)ms.WindDirection_deg,
                     Mike_Scenario_Wind_Speed_km_h = (float)ms.WindSpeed_km_h,
                 });
            }

            try
            {
                ReportMike_ScenarioModelQ = ReportServiceGeneratedMike_Scenario(ReportMike_ScenarioModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMike_ScenarioModel>() { new ReportMike_ScenarioModel() { Mike_Scenario_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMike_ScenarioModel>() { new ReportMike_ScenarioModel() { Mike_Scenario_Counter = ReportMike_ScenarioModelQ.Count() } };

                reportMike_ScenarioModelList = ReportMike_ScenarioModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMike_ScenarioModel>() { new ReportMike_ScenarioModel() { Mike_Scenario_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMike_ScenarioModel ReportMike_ScenarioModel in reportMike_ScenarioModelList)
            {
                Counter += 1;
                ReportMike_ScenarioModel.Mike_Scenario_Counter = Counter;
            }

            return reportMike_ScenarioModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}