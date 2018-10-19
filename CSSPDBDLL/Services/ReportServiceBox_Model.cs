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
    public partial class ReportServiceBox_Model : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceBox_Model(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportBox_ModelModel> GetReportBox_ModelModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportBox_ModelModel> reportBox_ModelModelList = new List<ReportBox_ModelModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Box_Model";
            int Counter = 0;
            IQueryable<ReportBox_ModelModel> reportBox_ModelModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportBox_ModelModel>() { new ReportBox_ModelModel() { Box_Model_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportBox_ModelModel>() { new ReportBox_ModelModel() { Box_Model_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.Infrastructure)
                    return new List<ReportBox_ModelModel>() { new ReportBox_ModelModel() { Box_Model_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.Infrastructure)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportBox_ModelModel>() { new ReportBox_ModelModel() { Box_Model_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportBox_ModelModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportBox_ModelModel>() { new ReportBox_ModelModel() { Box_Model_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.Infrastructure)
            {
                reportBox_ModelModelQ =
                (from t in db.TVItems
                 from bm in db.BoxModels
                 from bml in db.BoxModelLanguages
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == bm.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where t.TVItemID == bm.InfrastructureTVItemID
                 && bm.BoxModelID == bml.BoxModelID
                 && t.TVType == (int)TVTypeEnum.Infrastructure
                 && t.TVItemID == UnderTVItemID
                 && bml.Language == (int)Language
                 select new ReportBox_ModelModel
                 {
                     Box_Model_Error = "",
                     Box_Model_Counter = 0,
                     Box_Model_ID = bm.BoxModelID,
                     Box_Model_Scenario_Name_Translation_Status = (TranslationStatusEnum)bml.TranslationStatus,
                     Box_Model_Scenario_Name = bml.ScenarioName,
                     Box_Model_Flow_m3_day = (float)bm.Flow_m3_day,
                     Box_Model_Depth_m = (float)bm.Depth_m,
                     Box_Model_Temperature_C = (float)bm.Temperature_C,
                     Box_Model_Dilution = (int)bm.Dilution,
                     Box_Model_Decay_Rate_per_day = (float)bm.DecayRate_per_day,
                     Box_Model_FC_Untreated_MPN_100ml = bm.FCUntreated_MPN_100ml,
                     Box_Model_FC_Pre_Disinfection_MPN_100_ml = bm.FCPreDisinfection_MPN_100ml,
                     Box_Model_Concentration_MPN_100_ml = bm.Concentration_MPN_100ml,
                     Box_Model_T90_hour = (float)bm.T90_hour,
                     Box_Model_Flow_Duration_hour = (float)bm.FlowDuration_hour,
                     Box_Model_Last_Update_Date_UTC = bm.LastUpdateDate_UTC,
                     Box_Model_Last_Update_Contact_Name = contact.contactName,
                     Box_Model_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportBox_ModelModelQ =
                (from t in db.TVItems
                 from bm in db.BoxModels
                 from bml in db.BoxModelLanguages
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == bm.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where t.TVItemID == bm.InfrastructureTVItemID
                 && bm.BoxModelID == bml.BoxModelID
                 && t.TVType == (int)TVTypeEnum.Infrastructure
                 && t.TVPath.StartsWith(tvItem.TVPath + "p")
                 && bml.Language == (int)Language
                 select new ReportBox_ModelModel
                 {
                     Box_Model_Error = "",
                     Box_Model_Counter = 0,
                     Box_Model_ID = bm.BoxModelID,
                     Box_Model_Scenario_Name_Translation_Status = (TranslationStatusEnum)bml.TranslationStatus,
                     Box_Model_Scenario_Name = bml.ScenarioName,
                     Box_Model_Flow_m3_day = (float)bm.Flow_m3_day,
                     Box_Model_Depth_m = (float)bm.Depth_m,
                     Box_Model_Temperature_C = (float)bm.Temperature_C,
                     Box_Model_Dilution = (int)bm.Dilution,
                     Box_Model_Decay_Rate_per_day = (float)bm.DecayRate_per_day,
                     Box_Model_FC_Untreated_MPN_100ml = bm.FCUntreated_MPN_100ml,
                     Box_Model_FC_Pre_Disinfection_MPN_100_ml = bm.FCPreDisinfection_MPN_100ml,
                     Box_Model_Concentration_MPN_100_ml = bm.Concentration_MPN_100ml,
                     Box_Model_T90_hour = (float)bm.T90_hour,
                     Box_Model_Flow_Duration_hour = (float)bm.FlowDuration_hour,
                     Box_Model_Last_Update_Date_UTC = bm.LastUpdateDate_UTC,
                     Box_Model_Last_Update_Contact_Name = contact.contactName,
                     Box_Model_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }

            try
            {
                reportBox_ModelModelQ = ReportServiceGeneratedBox_Model(reportBox_ModelModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportBox_ModelModel>() { new ReportBox_ModelModel() { Box_Model_Error = retStr } };

                if (CountOnly)
                    return new List<ReportBox_ModelModel>() { new ReportBox_ModelModel() { Box_Model_Counter = reportBox_ModelModelQ.Count() } };

                reportBox_ModelModelList = reportBox_ModelModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportBox_ModelModel>() { new ReportBox_ModelModel() { Box_Model_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportBox_ModelModel reportBox_ModelModel in reportBox_ModelModelList)
            {
                Counter += 1;
                reportBox_ModelModel.Box_Model_Counter = Counter;
            }

            return reportBox_ModelModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}