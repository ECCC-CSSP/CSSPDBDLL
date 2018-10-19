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
    public partial class ReportServiceSubsector_Tide_Site_Data : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector_Tide_Site_Data(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsector_Tide_Site_DataModel> GetReportSubsector_Tide_Site_DataModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelList = new List<ReportSubsector_Tide_Site_DataModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector_Tide_Site_Data";
            int Counter = 0;
            IQueryable<ReportSubsector_Tide_Site_DataModel> reportSubsector_Tide_Site_DataModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSubsector_Tide_Site_DataModel>() { new ReportSubsector_Tide_Site_DataModel() { Subsector_Tide_Site_Data_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (ParentTagItem != "Subsector_Tide_Site")
                return new List<ReportSubsector_Tide_Site_DataModel>() { new ReportSubsector_Tide_Site_DataModel() { Subsector_Tide_Site_Data_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Tide_Site", ParentTagItem) } };

            TideSite TideSite = (from c in db.TideSites
                                 where c.TideSiteTVItemID == UnderTVItemID
                                 select c).FirstOrDefault();

            if (TideSite == null)
                return new List<ReportSubsector_Tide_Site_DataModel>() { new ReportSubsector_Tide_Site_DataModel() { Subsector_Tide_Site_Data_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideSite, ServiceRes.TideSiteTVItemID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsector_Tide_Site_DataModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsector_Tide_Site_DataModel>() { new ReportSubsector_Tide_Site_DataModel() { Subsector_Tide_Site_Data_Error = retStr } };

            reportSubsector_Tide_Site_DataModelQ =
                (from c in db.TideSites
                 from cd in db.TideDataValues
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cd.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TideSiteTVItemID == cd.TideSiteTVItemID
                 && c.TideSiteTVItemID == UnderTVItemID
                 select new ReportSubsector_Tide_Site_DataModel
                 {
                     Subsector_Tide_Site_Data_Error = "",
                     Subsector_Tide_Site_Data_Counter = 0,
                     Subsector_Tide_Site_Data_ID = cd.TideDataValueID,
                     Subsector_Tide_Site_Data_Date_Time_Local = cd.DateTime_Local,
                     Subsector_Tide_Site_Data_Keep = cd.Keep,
                     Subsector_Tide_Site_Data_Tide_Data_Type = (TideDataTypeEnum?)cd.TideDataType,
                     Subsector_Tide_Site_Data_Storage_Data_Type = (StorageDataTypeEnum?)cd.StorageDataType,
                     Subsector_Tide_Site_Data_Depth_m = (float?)cd.Depth_m,
                     Subsector_Tide_Site_Data_U_Velocity_m_s = (float?)cd.UVelocity_m_s,
                     Subsector_Tide_Site_Data_V_Velocity_m_s = (float?)cd.VVelocity_m_s,
                     Subsector_Tide_Site_Data_Tide_Start = (TideTextEnum?)cd.TideStart,
                     Subsector_Tide_Site_Data_Tide_End = (TideTextEnum?)cd.TideEnd,
                     Subsector_Tide_Site_Data_Last_Update_Date_And_Time_UTC = cd.LastUpdateDate_UTC,
                     Subsector_Tide_Site_Data_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Tide_Site_Data_Last_Update_Contact_Initial = contact.contactInitial,
                 });

            try
            {
                reportSubsector_Tide_Site_DataModelQ = ReportServiceGeneratedSubsector_Tide_Site_Data(reportSubsector_Tide_Site_DataModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSubsector_Tide_Site_DataModel>() { new ReportSubsector_Tide_Site_DataModel() { Subsector_Tide_Site_Data_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSubsector_Tide_Site_DataModel>() { new ReportSubsector_Tide_Site_DataModel() { Subsector_Tide_Site_Data_Counter = reportSubsector_Tide_Site_DataModelQ.Count() } };

                reportSubsector_Tide_Site_DataModelList = reportSubsector_Tide_Site_DataModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSubsector_Tide_Site_DataModel>() { new ReportSubsector_Tide_Site_DataModel() { Subsector_Tide_Site_Data_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSubsector_Tide_Site_DataModel reportSubsector_Tide_Site_DataModel in reportSubsector_Tide_Site_DataModelList)
            {
                Counter += 1;
                reportSubsector_Tide_Site_DataModel.Subsector_Tide_Site_Data_Counter = Counter;
            }

            return reportSubsector_Tide_Site_DataModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}