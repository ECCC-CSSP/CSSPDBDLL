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
    public partial class ReportServiceSubsector_Climate_Site_Data : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceSubsector_Climate_Site_Data(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportSubsector_Climate_Site_DataModel> GetReportSubsector_Climate_Site_DataModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelList = new List<ReportSubsector_Climate_Site_DataModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Subsector_Climate_Site_Data";
            int Counter = 0;
            IQueryable<ReportSubsector_Climate_Site_DataModel> reportSubsector_Climate_Site_DataModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportSubsector_Climate_Site_DataModel>() { new ReportSubsector_Climate_Site_DataModel() { Subsector_Climate_Site_Data_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (ParentTagItem != "Subsector_Climate_Site")
                return new List<ReportSubsector_Climate_Site_DataModel>() { new ReportSubsector_Climate_Site_DataModel() { Subsector_Climate_Site_Data_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Subsector_Climate_Site", ParentTagItem) } };

            ClimateSite climateSite = (from c in db.ClimateSites
                                       where c.ClimateSiteTVItemID == UnderTVItemID
                                       select c).FirstOrDefault();

            if (climateSite == null)
                return new List<ReportSubsector_Climate_Site_DataModel>() { new ReportSubsector_Climate_Site_DataModel() { Subsector_Climate_Site_Data_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ClimateSite, ServiceRes.ClimateSiteTVItemID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportSubsector_Climate_Site_DataModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportSubsector_Climate_Site_DataModel>() { new ReportSubsector_Climate_Site_DataModel() { Subsector_Climate_Site_Data_Error = retStr } };

            reportSubsector_Climate_Site_DataModelQ =
                (from c in db.ClimateSites
                 from cd in db.ClimateDataValues
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == cd.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where c.ClimateSiteID == cd.ClimateSiteID
                 && c.ClimateSiteTVItemID == UnderTVItemID
                 select new ReportSubsector_Climate_Site_DataModel
                 {
                     Subsector_Climate_Site_Data_Error = "",
                     Subsector_Climate_Site_Data_Counter = 0,
                     Subsector_Climate_Site_Data_ID = cd.ClimateDataValueID,
                     Subsector_Climate_Site_Data_Cool_Deg_Days_C = (float)cd.CoolDegDays_C,
                     Subsector_Climate_Site_Data_Date_Time_Local = cd.DateTime_Local,
                     Subsector_Climate_Site_Data_Dir_Max_Gust_0North = (float)cd.DirMaxGust_0North,
                     Subsector_Climate_Site_Data_Heat_Deg_Days_C = (float)cd.HeatDegDays_C,
                     Subsector_Climate_Site_Data_Hourly_Values = cd.HourlyValues,
                     Subsector_Climate_Site_Data_Keep = cd.Keep,
                     Subsector_Climate_Site_Data_Last_Update_Date_UTC = cd.LastUpdateDate_UTC,
                     Subsector_Climate_Site_Data_Max_Temp_C = (float)cd.MaxTemp_C,
                     Subsector_Climate_Site_Data_Min_Temp_C = (float)cd.MinTemp_C,
                     Subsector_Climate_Site_Data_Rainfall_Entered_mm = (float)cd.RainfallEntered_mm,
                     Subsector_Climate_Site_Data_Rainfall_mm = (float)cd.Rainfall_mm,
                     Subsector_Climate_Site_Data_Snow_cm = (float)cd.Snow_cm,
                     Subsector_Climate_Site_Data_Snow_On_Ground_cm = (float)cd.SnowOnGround_cm,
                     Subsector_Climate_Site_Data_Spd_Max_Gust_kmh = (float)cd.SpdMaxGust_kmh,
                     Subsector_Climate_Site_Data_Storage_Data_Type = (StorageDataTypeEnum)cd.StorageDataType,
                     Subsector_Climate_Site_Data_Total_Precip_mm_cm = (float)cd.TotalPrecip_mm_cm,
                     Subsector_Climate_Site_Data_Last_Update_Contact_Name = contact.contactName,
                     Subsector_Climate_Site_Data_Last_Update_Contact_Initial = contact.contactInitial,
                 });

            try
            {
                reportSubsector_Climate_Site_DataModelQ = ReportServiceGeneratedSubsector_Climate_Site_Data(reportSubsector_Climate_Site_DataModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportSubsector_Climate_Site_DataModel>() { new ReportSubsector_Climate_Site_DataModel() { Subsector_Climate_Site_Data_Error = retStr } };

                if (CountOnly)
                    return new List<ReportSubsector_Climate_Site_DataModel>() { new ReportSubsector_Climate_Site_DataModel() { Subsector_Climate_Site_Data_Counter = reportSubsector_Climate_Site_DataModelQ.Count() } };

                reportSubsector_Climate_Site_DataModelList = reportSubsector_Climate_Site_DataModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportSubsector_Climate_Site_DataModel>() { new ReportSubsector_Climate_Site_DataModel() { Subsector_Climate_Site_Data_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportSubsector_Climate_Site_DataModel reportSubsector_Climate_Site_DataModel in reportSubsector_Climate_Site_DataModelList)
            {
                Counter += 1;
                reportSubsector_Climate_Site_DataModel.Subsector_Climate_Site_Data_Counter = Counter;
            }

            return reportSubsector_Climate_Site_DataModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}