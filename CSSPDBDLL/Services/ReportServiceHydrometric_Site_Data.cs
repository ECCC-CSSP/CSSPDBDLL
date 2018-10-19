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
    public partial class ReportServiceHydrometric_Site_Data : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceHydrometric_Site_Data(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportHydrometric_Site_DataModel> GetReportHydrometric_Site_DataModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelList = new List<ReportHydrometric_Site_DataModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Hydrometric_Site_Data";
            int Counter = 0;
            IQueryable<ReportHydrometric_Site_DataModel> reportHydrometric_Site_DataModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportHydrometric_Site_DataModel>() { new ReportHydrometric_Site_DataModel() { Hydrometric_Site_Data_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (ParentTagItem != "Hydrometric_Site")
                return new List<ReportHydrometric_Site_DataModel>() { new ReportHydrometric_Site_DataModel() { Hydrometric_Site_Data_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Hydrometric_Site", ParentTagItem) } };

            HydrometricSite HydrometricSite = (from c in db.HydrometricSites
                                               where c.HydrometricSiteTVItemID == UnderTVItemID
                                               select c).FirstOrDefault();

            if (HydrometricSite == null)
                return new List<ReportHydrometric_Site_DataModel>() { new ReportHydrometric_Site_DataModel() { Hydrometric_Site_Data_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HydrometricSite, ServiceRes.HydrometricSiteTVItemID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportHydrometric_Site_DataModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportHydrometric_Site_DataModel>() { new ReportHydrometric_Site_DataModel() { Hydrometric_Site_Data_Error = retStr } };

            reportHydrometric_Site_DataModelQ =
                (from c in db.HydrometricSites
                 from cd in db.HydrometricDataValues
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cd.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.HydrometricSiteID == cd.HydrometricSiteID
                 && c.HydrometricSiteTVItemID == UnderTVItemID
                 select new ReportHydrometric_Site_DataModel
                 {
                     Hydrometric_Site_Data_Error = "",
                     Hydrometric_Site_Data_Counter = 0,
                     Hydrometric_Site_Data_ID = cd.HydrometricDataValueID,
                     Hydrometric_Site_Data_Date_Time_Local = cd.DateTime_Local,
                     Hydrometric_Site_Data_Hourly_Values = cd.HourlyValues,
                     Hydrometric_Site_Data_Keep = cd.Keep,
                     Hydrometric_Site_Data_Discharge_m3_s = (float?)cd.Discharge_m3_s,
                     Hydrometric_Site_Data_DischargeEntered_m3_s = (float?)cd.DischargeEntered_m3_s,
                     Hydrometric_Site_Data_Level_m = (float?)cd.Level_m,
                     Hydrometric_Site_Data_Last_Update_Date_UTC = cd.LastUpdateDate_UTC,
                     Hydrometric_Site_Data_Storage_Data_Type = (StorageDataTypeEnum)cd.StorageDataType,
                     Hydrometric_Site_Data_Last_Update_Contact_Name = contact.contactName,
                     Hydrometric_Site_Data_Last_Update_Contact_Initial = contact.contactInitial,
                 });

            try
            {
                reportHydrometric_Site_DataModelQ = ReportServiceGeneratedHydrometric_Site_Data(reportHydrometric_Site_DataModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportHydrometric_Site_DataModel>() { new ReportHydrometric_Site_DataModel() { Hydrometric_Site_Data_Error = retStr } };

                if (CountOnly)
                    return new List<ReportHydrometric_Site_DataModel>() { new ReportHydrometric_Site_DataModel() { Hydrometric_Site_Data_Counter = reportHydrometric_Site_DataModelQ.Count() } };

                reportHydrometric_Site_DataModelList = reportHydrometric_Site_DataModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportHydrometric_Site_DataModel>() { new ReportHydrometric_Site_DataModel() { Hydrometric_Site_Data_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportHydrometric_Site_DataModel reportHydrometric_Site_DataModel in reportHydrometric_Site_DataModelList)
            {
                Counter += 1;
                reportHydrometric_Site_DataModel.Hydrometric_Site_Data_Counter = Counter;
            }

            return reportHydrometric_Site_DataModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}