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
    public partial class ReportServiceInfrastructure_File : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceInfrastructure_File(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportInfrastructure_FileModel> GetReportInfrastructure_FileModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportInfrastructure_FileModel> reportInfrastructure_FileModelList = new List<ReportInfrastructure_FileModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Infrastructure_File";
            int Counter = 0;
            int Infrastructure_FileLevel = 8;
            IQueryable<ReportInfrastructure_FileModel> reportInfrastructure_FileModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportInfrastructure_FileModel>() { new ReportInfrastructure_FileModel() { Infrastructure_File_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportInfrastructure_FileModel>() { new ReportInfrastructure_FileModel() { Infrastructure_File_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
                return new List<ReportInfrastructure_FileModel>() { new ReportInfrastructure_FileModel() { Infrastructure_File_Error = ServiceRes.ParentTagItemShouldNotBeEmpty } };

            List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
            if (!AllowableParentTagItemList.Contains(ParentTagItem))
                return new List<ReportInfrastructure_FileModel>() { new ReportInfrastructure_FileModel() { Infrastructure_File_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportInfrastructure_FileModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportInfrastructure_FileModel>() { new ReportInfrastructure_FileModel() { Infrastructure_File_Error = retStr } };

            reportInfrastructure_FileModelQ =
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
             && c.TVLevel == Infrastructure_FileLevel
             && c.TVType == (int)TVTypeEnum.File
             && cl.Language == (int)Language
             && c.TVPath.StartsWith(tvItem.TVPath + "p")
             && pc.TVItemID == c.ParentID
             && pc.TVType == (int)TVTypeEnum.Infrastructure
             select new ReportInfrastructure_FileModel
             {
                 Infrastructure_File_Error = "",
                 Infrastructure_File_Counter = 0,
                 Infrastructure_File_ID = c.TVItemID,
                 Infrastructure_File_Language = (LanguageEnum)fl.Language,
                 Infrastructure_File_Purpose = (FilePurposeEnum)f.FilePurpose,
                 Infrastructure_File_Type = (FileTypeEnum)f.FileType,
                 Infrastructure_File_Description = fl.FileDescription,
                 Infrastructure_File_Size_kb = f.FileSize_kb,
                 Infrastructure_File_Info = f.FileInfo,
                 Infrastructure_File_Created_Date_UTC = f.FileCreatedDate_UTC,
                 Infrastructure_File_From_Water = f.FromWater,
                 Infrastructure_File_Server_File_Name = f.ServerFileName,
                 Infrastructure_File_Server_File_Path = f.ServerFilePath,
                 Infrastructure_File_Last_Update_Date_And_Time_UTC = f.LastUpdateDate_UTC,
                 Infrastructure_File_Last_Update_Contact_Name = contact.contactName,
                 Infrastructure_File_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportInfrastructure_FileModelQ = ReportServiceGeneratedInfrastructure_File(reportInfrastructure_FileModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportInfrastructure_FileModel>() { new ReportInfrastructure_FileModel() { Infrastructure_File_Error = retStr } };

                if (CountOnly)
                    return new List<ReportInfrastructure_FileModel>() { new ReportInfrastructure_FileModel() { Infrastructure_File_Counter = reportInfrastructure_FileModelQ.Count() } };

                reportInfrastructure_FileModelList = reportInfrastructure_FileModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportInfrastructure_FileModel>() { new ReportInfrastructure_FileModel() { Infrastructure_File_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportInfrastructure_FileModel reportInfrastructure_FileModel in reportInfrastructure_FileModelList)
            {
                Counter += 1;
                reportInfrastructure_FileModel.Infrastructure_File_Counter = Counter;
            }

            return reportInfrastructure_FileModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}