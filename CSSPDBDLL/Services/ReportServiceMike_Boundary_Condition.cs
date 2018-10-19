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
    public partial class ReportServiceMike_Boundary_Condition : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMike_Boundary_Condition(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMike_Boundary_ConditionModel> GetReportMike_Boundary_ConditionModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            //List<TVItemStat> tvItemStatList = new List<TVItemStat>();
            //List<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelList = new List<ReportMike_Boundary_ConditionModel>();
            //List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            //string TagItem = "Mike_Boundary_Condition";
            //int Counter = 0;
            //int Mike_Boundary_ConditionLevel = 8;
            //IQueryable<ReportMike_Boundary_ConditionModel> reportMike_Boundary_ConditionModelQ = null;

            //if (TagText.StartsWith("|||Start "))
            //    return new List<ReportMike_Boundary_ConditionModel>() { new ReportMike_Boundary_ConditionModel() { Mike_Boundary_Condition_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            //TVItem tvItem = (from c in db.TVItems
            //                 where c.TVItemID == UnderTVItemID
            //                 select c).FirstOrDefault();

            //if (tvItem == null)
            //    return new List<ReportMike_Boundary_ConditionModel>() { new ReportMike_Boundary_ConditionModel() { Mike_Boundary_Condition_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            //if (string.IsNullOrWhiteSpace(ParentTagItem))
            //    return new List<ReportMike_Boundary_ConditionModel>() { new ReportMike_Boundary_ConditionModel() { Mike_Boundary_Condition_Error = ServiceRes.ParentTagItemShouldNotBeEmpty } };

            //List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
            //if (!AllowableParentTagItemList.Contains(ParentTagItem))
            //    return new List<ReportMike_Boundary_ConditionModel>() { new ReportMike_Boundary_ConditionModel() { Mike_Boundary_Condition_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };


            //bool IsDBFiltering = true;
            //string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMike_Boundary_ConditionModel), reportTreeNodeList, IsDBFiltering);
            //if (!string.IsNullOrWhiteSpace(retStr))
            //    return new List<ReportMike_Boundary_ConditionModel>() { new ReportMike_Boundary_ConditionModel() { Mike_Boundary_Condition_Error = retStr } };

            //reportMike_Boundary_ConditionModelQ =
            //(from c in db.TVItems
            // from cl in db.TVItemLanguages
            // from mb in db.MikeBoundaryConditions
            // from pc in db.TVItems
            // let contact = (from cc in db.Contacts
            //                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
            //                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
            //                where cc.ContactTVItemID == mb.LastUpdateContactTVItemID
            //                select new { contactName, contactInitial }).FirstOrDefault()
            // where c.TVItemID == cl.TVItemID
            // && c.TVItemID == mb.MikeScenarioTVItemID
            // && (c.TVType == (int)TVTypeEnum.MikeBoundaryConditionMesh
            // || c.TVType == (int)TVTypeEnum.MikeBoundaryConditionWebTide)
            // && cl.Language == (int)Language
            // && c.TVPath.StartsWith(tvItem.TVPath + "p")
            // && pc.TVItemID == c.ParentID
            // && pc.TVType == (int)TVTypeEnum.MikeScenario
            // select new ReportMike_Boundary_ConditionModel
            // {
            //     Mike_Boundary_Condition_Error = "",
            //     Mike_Boundary_Condition_Counter = 0,
            //     Mike_Boundary_Condition_Last_Update_Date_UTC = 
            //     Mike_Boundary_Condition_Ambient_Salinity_PSU = (float)mb.AmbientSalinity_PSU,
            //     Mike_Boundary_Condition_Ambient_Temperature_C = (float)mb.AmbientTemperature_C,
            //     Mike_Boundary_Condition_Decay_Factor_Amplitude = (float)mb.DecayFactorAmplitude,
            //     Mike_Boundary_Condition_Decay_Factor_per_day = (float)mb.DecayFactor_per_day,
            //     Mike_Boundary_Condition_Decay_Is_Constant = mb.DecayIsConstant,
            //     Mike_Boundary_Condition_End_Date_Time_Local = mb.MikeScenarioEndDateTime_Local,
            //     Mike_Boundary_Condition_ErrorInfo = mb.ErrorInfo,
            //     Mike_Boundary_Condition_Estimated_Hydro_File_Size = (int?)mb.EstimatedHydroFileSize,
            //     Mike_Boundary_Condition_Estimated_Trans_File_Size = (int?)mb.EstimatedTransFileSize,
            //     Mike_Boundary_Condition_Execution_Time_min = (float?)mb.MikeScenarioExecutionTime_min,
            //     Mike_Boundary_Condition_ID = mb.MikeScenarioTVItemID,
            //     Mike_Boundary_Condition_Is_Active = c.IsActive,
            //     Mike_Boundary_Condition_Last_Update_Contact_Initial = contact.contactInitial,
            //     Mike_Boundary_Condition_Last_Update_Contact_Name = contact.contactName,
            //     Mike_Boundary_Condition_Last_Update_Date_And_Time_UTC = mb.LastUpdateDate_UTC,
            //     Mike_Boundary_Condition_Manning_Number = (float?)mb.ManningNumber,
            //     Mike_Boundary_Condition_Name = cl.TVText,
            //     Mike_Boundary_Condition_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
            //     Mike_Boundary_Condition_Number_Of_Elements = mb.NumberOfElements,
            //     Mike_Boundary_Condition_Number_Of_Hydro_Output_Parameters = mb.NumberOfHydroOutputParameters,
            //     Mike_Boundary_Condition_Number_Of_Sigma_Layers = mb.NumberOfSigmaLayers,
            //     Mike_Boundary_Condition_Number_Of_Time_Steps = mb.NumberOfTimeSteps,
            //     Mike_Boundary_Condition_Number_Of_Trans_Output_Parameters = mb.NumberOfTransOutputParameters,
            //     Mike_Boundary_Condition_Number_Of_Z_Layers = mb.NumberOfZLayers,
            //     Mike_Boundary_Condition_Result_Frequency_min = mb.ResultFrequency_min,
            //     Mike_Boundary_Condition_Start_Date_Time_Local = mb.MikeScenarioStartDateTime_Local,
            //     Mike_Boundary_Condition_Start_Execution_Date_Time_Local = mb.MikeScenarioStartExecutionDateTime_Local,
            //     Mike_Boundary_Condition_Status = (ScenarioStatusEnum)mb.MikeScenarioStatus,
            //     Mike_Boundary_Condition_Wind_Direction_deg = (float)mb.WindDirection_deg,
            //     Mike_Boundary_Condition_Wind_Speed_km_h = (float)mb.WindSpeed_km_h,
            // });

            //try
            //{
            //    reportMike_Boundary_ConditionModelQ = ReportServiceGeneratedMike_Boundary_Condition(reportMike_Boundary_ConditionModelQ, reportTreeNodeList);
            //    ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
            //    retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
            //    if (!string.IsNullOrWhiteSpace(retStr))
            //        return new List<ReportMike_Boundary_ConditionModel>() { new ReportMike_Boundary_ConditionModel() { Mike_Boundary_Condition_Error = retStr } };

            //    if (CountOnly)
            //        return new List<ReportMike_Boundary_ConditionModel>() { new ReportMike_Boundary_ConditionModel() { Mike_Boundary_Condition_Counter = reportMike_Boundary_ConditionModelQ.Count() } };

            //    reportMike_Boundary_ConditionModelList = reportMike_Boundary_ConditionModelQ.Take(Take).ToList();
            //}
            //catch (Exception ex)
            //{
            //    return new List<ReportMike_Boundary_ConditionModel>() { new ReportMike_Boundary_ConditionModel() { Mike_Boundary_Condition_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            //}

            //foreach (ReportMike_Boundary_ConditionModel ReportMike_Boundary_ConditionModel in reportMike_Boundary_ConditionModelList)
            //{
            //    Counter += 1;
            //    ReportMike_Boundary_ConditionModel.Mike_Boundary_Condition_Counter = Counter;
            //}

            //return reportMike_Boundary_ConditionModelList;

            return new List<ReportMike_Boundary_ConditionModel>();
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}