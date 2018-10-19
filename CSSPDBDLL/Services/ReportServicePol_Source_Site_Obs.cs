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
    public partial class ReportServicePol_Source_Site_Obs : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServicePol_Source_Site_Obs(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportPol_Source_Site_ObsModel> GetReportPol_Source_Site_ObsModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelList = new List<ReportPol_Source_Site_ObsModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Pol_Source_Site_Obs";
            int Counter = 0;
            IQueryable<ReportPol_Source_Site_ObsModel> reportPol_Source_Site_ObsModelQ = null;
            bool OnlyLast = false;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportPol_Source_Site_ObsModel>() { new ReportPol_Source_Site_ObsModel() { Pol_Source_Site_Obs_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == UnderTVItemID
                             select c).FirstOrDefault();

            if (tvItem == null)
                return new List<ReportPol_Source_Site_ObsModel>() { new ReportPol_Source_Site_ObsModel() { Pol_Source_Site_Obs_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, UnderTVItemID.ToString()) } };

            if (string.IsNullOrWhiteSpace(ParentTagItem))
            {
                if (tvItem.TVType != (int)TVTypeEnum.PolSourceSite)
                    return new List<ReportPol_Source_Site_ObsModel>() { new ReportPol_Source_Site_ObsModel() { Pol_Source_Site_Obs_Error = string.Format(ServiceRes.UnderTVItemID_IsNotOfType_, UnderTVItemID.ToString(), TVTypeEnum.PolSourceSite.ToString()) } };
            }
            else
            {
                if (tvItem.TVType != (int)TVTypeEnum.PolSourceSite)
                {
                    List<string> AllowableParentTagItemList = _ReportBaseService.GetAllowableParentTagItem(TagItem);
                    if (!AllowableParentTagItemList.Contains(ParentTagItem))
                        return new List<ReportPol_Source_Site_ObsModel>() { new ReportPol_Source_Site_ObsModel() { Pol_Source_Site_Obs_Error = string.Format(ServiceRes.AllowableParentTagItemFor_Are_, TagItem, String.Join(",", AllowableParentTagItemList)) } };
                }
            }

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportPol_Source_Site_ObsModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportPol_Source_Site_ObsModel>() { new ReportPol_Source_Site_ObsModel() { Pol_Source_Site_Obs_Error = retStr } };

            ReportTreeNode reportTreeNode2 = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Obs_Only_Last").FirstOrDefault();

            if (reportTreeNode2 != null)
            {
                if (reportTreeNode2.dbFilteringTrueFalseFieldList.Count > 0)
                {
                    foreach (ReportConditionTrueFalseField dbFilteringTrueFalseField in reportTreeNode2.dbFilteringTrueFalseFieldList)
                    {
                        if (dbFilteringTrueFalseField.ReportCondition == ReportConditionEnum.ReportConditionTrue)
                        {
                            OnlyLast = true;
                        }
                    }
                }
            }

            if (tvItem.TVType == (int)TVTypeEnum.PolSourceSite)
            {
                reportPol_Source_Site_ObsModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from pso in db.PolSourceObservations
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == pso.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactInspector = (from cc in db.Contacts
                                         let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                         let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                         where cc.ContactTVItemID == pso.ContactTVItemID
                                         select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == (from pp in db.PolSourceSites where pp.PolSourceSiteID == pso.PolSourceSiteID select pp.PolSourceSiteTVItemID).FirstOrDefault()
                 && c.TVType == (int)TVTypeEnum.PolSourceSite
                 && cl.Language == (int)Language
                 && c.TVItemID == UnderTVItemID
                 select new ReportPol_Source_Site_ObsModel
                 {
                     Pol_Source_Site_Obs_Error = "",
                     Pol_Source_Site_Obs_Counter = 0,
                     Pol_Source_Site_Obs_ID = pso.PolSourceObservationID,
                     Pol_Source_Site_Obs_Only_Last = OnlyLast,
                     Pol_Source_Site_Obs_Inspector_Name = contactInspector.contactName,
                     Pol_Source_Site_Obs_Inspector_Initial = contactInspector.contactInitial,
                     Pol_Source_Site_Obs_Observation_Date_Local = pso.ObservationDate_Local,
                     Pol_Source_Site_Obs_Observation_To_Be_Deleted = pso.Observation_ToBeDeleted,
                     Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC = pso.LastUpdateDate_UTC,
                     Pol_Source_Site_Obs_Last_Update_Contact_Name = contact.contactName,
                     Pol_Source_Site_Obs_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }
            else
            {
                reportPol_Source_Site_ObsModelQ =
                (from c in db.TVItems
                 from cl in db.TVItemLanguages
                 from pso in db.PolSourceObservations
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == pso.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 let contactInspector = (from cc in db.Contacts
                                         let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                         let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                         where cc.ContactTVItemID == pso.ContactTVItemID
                                         select new { contactName, contactInitial }).FirstOrDefault()
                 where c.TVItemID == cl.TVItemID
                 && c.TVItemID == (from pp in db.PolSourceSites where pp.PolSourceSiteID == pso.PolSourceSiteID select pp.PolSourceSiteTVItemID).FirstOrDefault()
                 && c.TVType == (int)TVTypeEnum.PolSourceSite
                 && cl.Language == (int)Language
                 && c.TVPath.StartsWith(tvItem.TVPath + "p")
                 select new ReportPol_Source_Site_ObsModel
                 {
                     Pol_Source_Site_Obs_Error = "",
                     Pol_Source_Site_Obs_Counter = 0,
                     Pol_Source_Site_Obs_ID = pso.PolSourceObservationID,
                     Pol_Source_Site_Obs_Only_Last = OnlyLast,
                     Pol_Source_Site_Obs_Inspector_Name = contactInspector.contactName,
                     Pol_Source_Site_Obs_Inspector_Initial = contactInspector.contactInitial,
                     Pol_Source_Site_Obs_Observation_Date_Local = pso.ObservationDate_Local,
                     Pol_Source_Site_Obs_Observation_To_Be_Deleted = pso.Observation_ToBeDeleted,
                     Pol_Source_Site_Obs_Last_Update_Date_And_Time_UTC = pso.LastUpdateDate_UTC,
                     Pol_Source_Site_Obs_Last_Update_Contact_Name = contact.contactName,
                     Pol_Source_Site_Obs_Last_Update_Contact_Initial = contact.contactInitial,
                 });
            }

            try
            {
                reportPol_Source_Site_ObsModelQ = ReportServiceGeneratedPol_Source_Site_Obs(reportPol_Source_Site_ObsModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportPol_Source_Site_ObsModel>() { new ReportPol_Source_Site_ObsModel() { Pol_Source_Site_Obs_Error = retStr } };

                if (CountOnly)
                    return new List<ReportPol_Source_Site_ObsModel>() { new ReportPol_Source_Site_ObsModel() { Pol_Source_Site_Obs_Counter = reportPol_Source_Site_ObsModelQ.Count() } };

                if (OnlyLast)
                {
                    reportPol_Source_Site_ObsModelList = (from c in reportPol_Source_Site_ObsModelQ
                                                          orderby c.Pol_Source_Site_Obs_Observation_Date_Local descending
                                                          select c).Take(1).ToList();
                }
                else
                {
                    reportPol_Source_Site_ObsModelList = reportPol_Source_Site_ObsModelQ.Take(Take).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<ReportPol_Source_Site_ObsModel>() { new ReportPol_Source_Site_ObsModel() { Pol_Source_Site_Obs_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportPol_Source_Site_ObsModel reportPol_Source_Site_ObsModel in reportPol_Source_Site_ObsModelList)
            {
                Counter += 1;
                reportPol_Source_Site_ObsModel.Pol_Source_Site_Obs_Counter = Counter;
            }

            return reportPol_Source_Site_ObsModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}