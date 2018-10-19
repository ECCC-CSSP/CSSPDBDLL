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
    public partial class ReportServiceMWQM_Site_Sample : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMWQM_Site_Sample(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMWQM_Site_SampleModel> GetReportMWQM_Site_SampleModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelList = new List<ReportMWQM_Site_SampleModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MWQM_Site_Sample";
            int Counter = 0;
            IQueryable<ReportMWQM_Site_SampleModel> reportMWQM_Site_SampleModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMWQM_Site_SampleModel>() { new ReportMWQM_Site_SampleModel() { MWQM_Site_Sample_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMWQM_Site_SampleModel>() { new ReportMWQM_Site_SampleModel() { MWQM_Site_Sample_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMSite)
                    return new List<ReportMWQM_Site_SampleModel>() { new ReportMWQM_Site_SampleModel() { MWQM_Site_Sample_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.MWQMSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.MWQMSite)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportMWQM_Site_SampleModel>() { new ReportMWQM_Site_SampleModel() { MWQM_Site_Sample_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMWQM_Site_SampleModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_Site_SampleModel>() { new ReportMWQM_Site_SampleModel() { MWQM_Site_Sample_Error = retStr } };

            if (tvItem.TVType == (int)TVTypeEnum.MWQMSite)
            {
                reportMWQM_Site_SampleModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from s in db.MWQMSamples
                 from sl in db.MWQMSampleLanguages
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == s.MWQMSiteTVItemID
                 && s.MWQMSampleID == sl.MWQMSampleID
                 && c.TVType == (int)TVTypeEnum.MWQMSite
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 && sl.Language == (int)Language
                 select new ReportMWQM_Site_SampleModel
                 {
                     MWQM_Site_Sample_Error = "",
                     MWQM_Site_Sample_Counter = 0,
                     MWQM_Site_Sample_ID = s.MWQMSampleID,
                     MWQM_Site_Sample_Date_Time_Local = s.SampleDateTime_Local,
                     MWQM_Site_Sample_Depth_m = (float?)s.Depth_m,
                     MWQM_Site_Sample_Fec_Col_MPN_100_ml = (int)s.FecCol_MPN_100ml,
                     MWQM_Site_Sample_Salinity_PPT = (float?)s.Salinity_PPT,
                     MWQM_Site_Sample_Water_Temp_C = (float?)s.WaterTemp_C,
                     MWQM_Site_Sample_PH = (float?)s.PH,
                     MWQM_Site_Sample_Types = s.SampleTypesText,
                     MWQM_Site_Sample_Tube_10 = (int?)s.Tube_10,
                     MWQM_Site_Sample_Tube_1_0 = (int?)s.Tube_1_0,
                     MWQM_Site_Sample_Tube_0_1 = (int?)s.Tube_0_1,
                     MWQM_Site_Sample_Processed_By = s.ProcessedBy,
                     MWQM_Site_Sample_Note_Translation_Status = (TranslationStatusEnum?)sl.TranslationStatus,
                     MWQM_Site_Sample_Note = sl.MWQMSampleNote,
                     MWQM_Site_Sample_Last_Update_Date_And_Time_UTC = s.LastUpdateDate_UTC,
                     MWQM_Site_Sample_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Site_Sample_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportMWQM_Site_SampleModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from s in db.MWQMSamples
                 from sl in db.MWQMSampleLanguages
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == s.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == s.MWQMSiteTVItemID
                 && s.MWQMSampleID == sl.MWQMSampleID
                 && c.TVType == (int)TVTypeEnum.MWQMSite
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 && sl.Language == (int)Language
                 select new ReportMWQM_Site_SampleModel
                 {
                     MWQM_Site_Sample_Error = "",
                     MWQM_Site_Sample_Counter = 0,
                     MWQM_Site_Sample_ID = s.MWQMSampleID,
                     MWQM_Site_Sample_Date_Time_Local = s.SampleDateTime_Local,
                     MWQM_Site_Sample_Depth_m = (float?)s.Depth_m,
                     MWQM_Site_Sample_Fec_Col_MPN_100_ml = (int)s.FecCol_MPN_100ml,
                     MWQM_Site_Sample_Salinity_PPT = (float?)s.Salinity_PPT,
                     MWQM_Site_Sample_Water_Temp_C = (float?)s.WaterTemp_C,
                     MWQM_Site_Sample_PH = (float?)s.PH,
                     MWQM_Site_Sample_Types = s.SampleTypesText,
                     MWQM_Site_Sample_Tube_10 = (int?)s.Tube_10,
                     MWQM_Site_Sample_Tube_1_0 = (int?)s.Tube_1_0,
                     MWQM_Site_Sample_Tube_0_1 = (int?)s.Tube_0_1,
                     MWQM_Site_Sample_Processed_By = s.ProcessedBy,
                     MWQM_Site_Sample_Note_Translation_Status = (TranslationStatusEnum?)sl.TranslationStatus,
                     MWQM_Site_Sample_Note = sl.MWQMSampleNote,
                     MWQM_Site_Sample_Last_Update_Date_And_Time_UTC = s.LastUpdateDate_UTC,
                     MWQM_Site_Sample_Last_Update_Contact_Name = contact.contactName,
                     MWQM_Site_Sample_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            try
            {
                reportMWQM_Site_SampleModelQ = ReportServiceGeneratedMWQM_Site_Sample(reportMWQM_Site_SampleModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMWQM_Site_SampleModel>() { new ReportMWQM_Site_SampleModel() { MWQM_Site_Sample_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMWQM_Site_SampleModel>() { new ReportMWQM_Site_SampleModel() { MWQM_Site_Sample_Counter = reportMWQM_Site_SampleModelQ.Count() } };

                reportMWQM_Site_SampleModelList = reportMWQM_Site_SampleModelQ.ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_Site_SampleModel>() { new ReportMWQM_Site_SampleModel() { MWQM_Site_Sample_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_Site_SampleModel reportMWQM_Site_SampleModel in reportMWQM_Site_SampleModelList)
            {
                if (reportTreeNodeList.Where(c => c.Text == "MWQM_Site_Sample_Types").Any())
                {
                    List<string> NumbTextList = reportMWQM_Site_SampleModel.MWQM_Site_Sample_Types.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                    string NewSampleTypeText = "";
                    foreach (string s in NumbTextList)
                    {
                        NewSampleTypeText += _BaseEnumService.GetEnumText_SampleTypeEnum(((SampleTypeEnum)int.Parse(s))) + ", ";
                    }
                    reportMWQM_Site_SampleModel.MWQM_Site_Sample_Types = NewSampleTypeText.Substring(0, NewSampleTypeText.Length - 1);
                }
            }

            foreach (ReportMWQM_Site_SampleModel reportMWQM_Site_SampleModel in reportMWQM_Site_SampleModelList)
            {
                Counter += 1;
                reportMWQM_Site_SampleModel.MWQM_Site_Sample_Counter = Counter;
            }

            return reportMWQM_Site_SampleModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}