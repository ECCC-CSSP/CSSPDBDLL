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
    public partial class ReportServiceRoot : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceRoot(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportRootModel> GetReportRootModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<TVItemStat> tvItemStatList = new List<TVItemStat>();
            List<ReportRootModel> reportRootModelList = new List<ReportRootModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Root";
            int Counter = 0;
            IQueryable<ReportRootModel> reportRootModelQ = null;

            if (!string.IsNullOrWhiteSpace(ParentTagItem))
                return new List<ReportRootModel>() { new ReportRootModel() { Root_Error = ServiceRes.ParentTagItemShouldNotBeEmpty } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportRootModel>() { new ReportRootModel() { Root_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (tvItem.TVType != (int)TVTypeEnum.Root)
                return new List<ReportRootModel>() { new ReportRootModel() { Root_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.Root.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportRootModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportRootModel>() { new ReportRootModel() { Root_Error = retStr } };

            reportRootModelList = (from c in db.TVItems
                                   from cl in db.TVItemLanguages
                                   let mp = (from m in db.MapInfos
                                             from mp in db.MapInfoPoints
                                             where m.MapInfoID == mp.MapInfoID
                                             && m.TVItemID == c.TVItemID
                                             && m.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                             select mp).FirstOrDefault()
                                   let contact = (from cc in db.Contacts
                                                  let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                                  let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                                  where cc.ContactTVItemID == cl.LastUpdateContactTVItemID
                                                  select new { contactName, contactInitial }).FirstOrDefault()
                                   where c.TVItemID == cl.TVItemID
                                   && c.TVType == (int)TVTypeEnum.Root
                                   && cl.Language == (int)Language
                                   && c.TVItemID == UnderTVItemID
                                   select new ReportRootModel
                                   {
                                       Root_Error = "",
                                       Root_Counter = 0,
                                       Root_ID = c.TVItemID,
                                       Root_Is_Active = c.IsActive,
                                       Root_Last_Update_Contact_Name = contact.contactName,
                                       Root_Last_Update_Contact_Initial = contact.contactInitial,
                                       Root_Last_Update_Date_And_Time_UTC = cl.LastUpdateDate_UTC,
                                       Root_Lat = (mp == null ? 0.0f : (float)mp.Lat),
                                       Root_Lng = (mp == null ? 0.0f : (float)mp.Lng),
                                       Root_Name = ServiceRes.AllLocations,
                                       Root_Name_Translation_Status = (TranslationStatusEnum)cl.TranslationStatus,
                                   }).ToList();

            foreach (ReportRootModel reportRootModel in reportRootModelList)
            {
                tvItemStatList = (from st in db.TVItemStats
                                  where st.TVItemID == reportRootModel.Root_ID
                                  select st).ToList();

                reportRootModel.Root_Stat_Area_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Area).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Box_Model_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.BoxModel).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Country_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Country).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Lift_Station_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.LiftStation).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Mike_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MikeScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Municipality_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Municipality).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_MWQM_Run_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMRun).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_MWQM_Sample_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMSiteSample).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_MWQM_Site_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.MWQMSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Pol_Source_Site_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.PolSourceSite).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Province_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Province).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Sector_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Sector).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Subsector_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.Subsector).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_Visual_Plumes_Scenario_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.VisualPlumesScenario).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
                reportRootModel.Root_Stat_WWTP_Count = tvItemStatList.Where(a => a.TVType == (int)TVTypeEnum.WasteWaterTreatmentPlant).Select(a => a.ChildCount).DefaultIfEmpty().FirstOrDefault();
            }

            try
            {
                reportRootModelQ = reportRootModelList.AsQueryable();
                reportRootModelQ = ReportServiceGeneratedRoot(reportRootModelQ, reportTreeNodeList.Where(c => c.Text != "Root_Counter").ToList());
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportRootModel>() { new ReportRootModel() { Root_Error = retStr } };

                if (CountOnly)
                    return new List<ReportRootModel>() { new ReportRootModel() { Root_Counter = reportRootModelQ.Count() } };

                reportRootModelList = reportRootModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportRootModel>() { new ReportRootModel() { Root_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportRootModel reportRootModel in reportRootModelList)
            {
                Counter += 1;
                reportRootModel.Root_Counter = Counter;
            }

            return reportRootModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}