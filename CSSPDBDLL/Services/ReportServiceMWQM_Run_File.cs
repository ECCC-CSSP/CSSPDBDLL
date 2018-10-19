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
    public partial class ReportServiceMWQM_Run_File : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceMWQM_Run_File(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportMWQM_Run_FileModel> GetReportMWQM_Run_FileModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportMWQM_Run_FileModel> reportMWQM_Run_FileModelList = new List<ReportMWQM_Run_FileModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "MWQM_Run_File";
            int Counter = 0;
            int MWQM_Run_FileLevel = 7;
            IQueryable<ReportMWQM_Run_FileModel> reportMWQM_Run_FileModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportMWQM_Run_FileModel>() { new ReportMWQM_Run_FileModel() { MWQM_Run_File_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportMWQM_Run_FileModel>() { new ReportMWQM_Run_FileModel() { MWQM_Run_File_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
                return new List<ReportMWQM_Run_FileModel>() { new ReportMWQM_Run_FileModel() { MWQM_Run_File_Error = ServiceRes.ParentTagItemShouldNotBeEmpty } };

            List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
            if (!AllowableParentTagItemList.Contains(ParentTagItem))
                return new List<ReportMWQM_Run_FileModel>() { new ReportMWQM_Run_FileModel() { MWQM_Run_File_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportMWQM_Run_FileModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportMWQM_Run_FileModel>() { new ReportMWQM_Run_FileModel() { MWQM_Run_File_Error = retStr } };

            reportMWQM_Run_FileModelQ =
            (from c in db.TVItems
             from cl in db.TVItemLanguages
             from f in db.TVFiles
             from fl in db.TVFileLanguages
             from pc in db.TVItems
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == fl.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where c.TVItemID == cl.TVItemID
             && c.TVItemID == f.TVFileTVItemID
             && f.TVFileID == fl.TVFileID
             && fl.Language == (int)Language
             && c.TVLevel == MWQM_Run_FileLevel
             && c.TVType == (int)TVTypeEnum.File
             && cl.Language == (int)Language
             && c.TVPath.StartsWith(tvItem.TVPath + "p")
             && pc.TVItemID == c.ParentID
             && pc.TVType == (int)TVTypeEnum.MWQMRun
             select new ReportMWQM_Run_FileModel
             {
                 MWQM_Run_File_Error = "",
                 MWQM_Run_File_Counter = 0,
                 MWQM_Run_File_ID = c.TVItemID,
                 MWQM_Run_File_Language = (LanguageEnum)fl.Language,
                 MWQM_Run_File_Purpose = (FilePurposeEnum)f.FilePurpose,
                 MWQM_Run_File_Type = (FileTypeEnum)f.FileType,
                 MWQM_Run_File_Description = fl.FileDescription,
                 MWQM_Run_File_Size_kb = f.FileSize_kb,
                 MWQM_Run_File_Info = f.FileInfo,
                 MWQM_Run_File_Created_Date_UTC = f.FileCreatedDate_UTC,
                 MWQM_Run_File_From_Water = f.FromWater,
                 MWQM_Run_File_Server_File_Name = f.ServerFileName,
                 MWQM_Run_File_Server_File_Path = f.ServerFilePath,
                 MWQM_Run_File_Last_Update_Date_And_Time_UTC = f.LastUpdateDate_UTC,
                 MWQM_Run_File_Last_Update_Contact_Name = contact.contactName,
                 MWQM_Run_File_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportMWQM_Run_FileModelQ = ReportServiceGeneratedMWQM_Run_File(reportMWQM_Run_FileModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportMWQM_Run_FileModel>() { new ReportMWQM_Run_FileModel() { MWQM_Run_File_Error = retStr } };

                if (CountOnly)
                    return new List<ReportMWQM_Run_FileModel>() { new ReportMWQM_Run_FileModel() { MWQM_Run_File_Counter = reportMWQM_Run_FileModelQ.Count() } };

                reportMWQM_Run_FileModelList = reportMWQM_Run_FileModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportMWQM_Run_FileModel>() { new ReportMWQM_Run_FileModel() { MWQM_Run_File_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportMWQM_Run_FileModel reportMWQM_Run_FileModel in reportMWQM_Run_FileModelList)
            {
                Counter += 1;
                reportMWQM_Run_FileModel.MWQM_Run_File_Counter = Counter;
            }

            return reportMWQM_Run_FileModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}