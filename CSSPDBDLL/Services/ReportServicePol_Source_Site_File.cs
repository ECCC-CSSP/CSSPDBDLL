﻿using System.Linq;
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
    public partial class ReportServicePol_Source_Site_File : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServicePol_Source_Site_File(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportPol_Source_Site_FileModel> GetReportPol_Source_Site_FileModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportPol_Source_Site_FileModel> reportPol_Source_Site_FileModelList = new List<ReportPol_Source_Site_FileModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Pol_Source_Site_File";
            int Counter = 0;
            int Pol_Source_Site_FileLevel = 7;
            IQueryable<ReportPol_Source_Site_FileModel> reportPol_Source_Site_FileModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportPol_Source_Site_FileModel>() { new ReportPol_Source_Site_FileModel() { Pol_Source_Site_File_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportPol_Source_Site_FileModel>() { new ReportPol_Source_Site_FileModel() { Pol_Source_Site_File_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
                return new List<ReportPol_Source_Site_FileModel>() { new ReportPol_Source_Site_FileModel() { Pol_Source_Site_File_Error = ServiceRes.ParentTagItemShouldNotBeEmpty } };

            List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
            if (!AllowableParentTagItemList.Contains(ParentTagItem))
            {
                return new List<ReportPol_Source_Site_FileModel>() { new ReportPol_Source_Site_FileModel() { Pol_Source_Site_File_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportPol_Source_Site_FileModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportPol_Source_Site_FileModel>() { new ReportPol_Source_Site_FileModel() { Pol_Source_Site_File_Error = retStr } };

            reportPol_Source_Site_FileModelQ =
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
             && c.TVLevel == Pol_Source_Site_FileLevel
             && c.TVType == (int)TVTypeEnum.File
             && cl.Language == (int)Language
             && c.TVPath.StartsWith(tvItem.TVPath + "p")
             && pc.TVItemID == c.ParentID
             && pc.TVType == (int)TVTypeEnum.PolSourceSite
             select new ReportPol_Source_Site_FileModel
             {
                 Pol_Source_Site_File_Error = "",
                 Pol_Source_Site_File_Counter = 0,
                 Pol_Source_Site_File_ID = c.TVItemID,
                 Pol_Source_Site_File_Language = (LanguageEnum)fl.Language,
                 Pol_Source_Site_File_Purpose = (FilePurposeEnum)f.FilePurpose,
                 Pol_Source_Site_File_Type = (FileTypeEnum)f.FileType,
                 Pol_Source_Site_File_Description = fl.FileDescription,
                 Pol_Source_Site_File_Size_kb = f.FileSize_kb,
                 Pol_Source_Site_File_Info = f.FileInfo,
                 Pol_Source_Site_File_Created_Date_UTC = f.FileCreatedDate_UTC,
                 Pol_Source_Site_File_From_Water = f.FromWater,
                 Pol_Source_Site_File_Server_File_Name = f.ServerFileName,
                 Pol_Source_Site_File_Server_File_Path = f.ServerFilePath,
                 Pol_Source_Site_File_Last_Update_Date_And_Time_UTC = f.LastUpdateDate_UTC,
                 Pol_Source_Site_File_Last_Update_Contact_Name = contact.contactName,
                 Pol_Source_Site_File_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportPol_Source_Site_FileModelQ = ReportServiceGeneratedPol_Source_Site_File(reportPol_Source_Site_FileModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportPol_Source_Site_FileModel>() { new ReportPol_Source_Site_FileModel() { Pol_Source_Site_File_Error = retStr } };

                if (CountOnly)
                    return new List<ReportPol_Source_Site_FileModel>() { new ReportPol_Source_Site_FileModel() { Pol_Source_Site_File_Counter = reportPol_Source_Site_FileModelQ.Count() } };


                reportPol_Source_Site_FileModelList = reportPol_Source_Site_FileModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportPol_Source_Site_FileModel>() { new ReportPol_Source_Site_FileModel() { Pol_Source_Site_File_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportPol_Source_Site_FileModel reportPol_Source_Site_FileModel in reportPol_Source_Site_FileModelList)
            {
                Counter += 1;
                reportPol_Source_Site_FileModel.Pol_Source_Site_File_Counter = Counter;
            }

            return reportPol_Source_Site_FileModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}