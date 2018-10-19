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
    public partial class ReportServiceSubsector_File : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector_File(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsector_FileModel> GetReportSubsector_FileModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsector_FileModel> reportSubsector_FileModelList = new List<ReportSubsector_FileModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector_File";
            int Counter = 0;
            int Subsector_FileLevel = 6;
            IQueryable<ReportSubsector_FileModel> reportSubsector_FileModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSubsector_FileModel>() { new ReportSubsector_FileModel() { Subsector_File_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportSubsector_FileModel>() { new ReportSubsector_FileModel() { Subsector_File_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
                return new List<ReportSubsector_FileModel>() { new ReportSubsector_FileModel() { Subsector_File_Error = ServiceRes.ParentTagItemShouldNotBeEmpty } };

            List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
            if (!AllowableParentTagItemList.Contains(ParentTagItem))
                return new List<ReportSubsector_FileModel>() { new ReportSubsector_FileModel() { Subsector_File_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsector_FileModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsector_FileModel>() { new ReportSubsector_FileModel() { Subsector_File_Error = retStr } };

            reportSubsector_FileModelQ =
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
             && c.TVLevel == Subsector_FileLevel
             && c.TVType == (int)TVTypeEnum.File
             && cl.Language == (int)Language
             && c.TVPath.StartsWith(tvItem.TVPath + "p")
             && pc.TVItemID == c.ParentID
             && pc.TVType == (int)TVTypeEnum.Subsector
             select new ReportSubsector_FileModel
             {
                 Subsector_File_Error = "",
                 Subsector_File_Counter = 0,
                 Subsector_File_ID = c.TVItemID,
                 Subsector_File_Language = (LanguageEnum)fl.Language,
                 Subsector_File_Purpose = (FilePurposeEnum)f.FilePurpose,
                 Subsector_File_Type = (FileTypeEnum)f.FileType,
                 Subsector_File_Description = fl.FileDescription,
                 Subsector_File_Size_kb = f.FileSize_kb,
                 Subsector_File_Info = f.FileInfo,
                 Subsector_File_Created_Date_UTC = f.FileCreatedDate_UTC,
                 Subsector_File_From_Water = f.FromWater,
                 Subsector_File_Server_File_Name = f.ServerFileName,
                 Subsector_File_Server_File_Path = f.ServerFilePath,
                 Subsector_File_Last_Update_Date_And_Time_UTC = f.LastUpdateDate_UTC,
                 Subsector_File_Last_Update_Contact_Name = contact.contactName,
                 Subsector_File_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportSubsector_FileModelQ = ReportServiceGeneratedSubsector_File(reportSubsector_FileModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSubsector_FileModel>() { new ReportSubsector_FileModel() { Subsector_File_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSubsector_FileModel>() { new ReportSubsector_FileModel() { Subsector_File_Counter = reportSubsector_FileModelQ.Count() } };

                reportSubsector_FileModelList = reportSubsector_FileModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSubsector_FileModel>() { new ReportSubsector_FileModel() { Subsector_File_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSubsector_FileModel reportSubsector_FileModel in reportSubsector_FileModelList)
            {
                Counter += 1;
                reportSubsector_FileModel.Subsector_File_Counter = Counter;
            }

            return reportSubsector_FileModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}