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
    public partial class ReportServiceBox_Model_Result : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ReportServiceBox_Model_Result(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportBox_Model_ResultModel> GetReportBox_Model_ResultModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportBox_Model_ResultModel> reportBox_Model_ResultModelList = new List<ReportBox_Model_ResultModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Box_Model_Result";
            int Counter = 0;
            IQueryable<ReportBox_Model_ResultModel> reportBox_Model_ResultModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportBox_Model_ResultModel>() { new ReportBox_Model_ResultModel() { Box_Model_Result_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (ParentTagItem != "Box_Model")
                return new List<ReportBox_Model_ResultModel>() { new ReportBox_Model_ResultModel() { Box_Model_Result_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Box_Model", ParentTagItem) } };

            BoxModel boxModel = (from c in db.BoxModels
                                 where c.BoxModelID == UnderTVItemID
                                 select c).FirstOrDefault();

            if (boxModel == null)
                return new List<ReportBox_Model_ResultModel>() { new ReportBox_Model_ResultModel() { Box_Model_Result_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModel, ServiceRes.BoxModelID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportBox_Model_ResultModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportBox_Model_ResultModel>() { new ReportBox_Model_ResultModel() { Box_Model_Result_Error = retStr } };

            reportBox_Model_ResultModelQ =
                (from bmr in db.BoxModelResults
                 let contact = (from cc in db.Contacts
                                let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                                let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                                where cc.ContactTVItemID == bmr.LastUpdateContactTVItemID
                                select new { contactName, contactInitial }).FirstOrDefault()
                 where bmr.BoxModelID == UnderTVItemID
                 select new ReportBox_Model_ResultModel
                 {
                     Box_Model_Result_Error = "",
                     Box_Model_Result_Counter = 0, // will be replace once the querry is done
                     Box_Model_Result_ID = bmr.BoxModelResultID,
                     Box_Model_Result_Result_Type = (BoxModelResultTypeEnum)bmr.BoxModelResultType,
                     Box_Model_Result_Volume_m3 = (float)bmr.Volume_m3,
                     Box_Model_Result_Surface_m2 = (float)bmr.Surface_m2,
                     Box_Model_Result_Radius_m = (float)bmr.Radius_m,
                     Box_Model_Result_Left_Side_Diameter_Line_Angle_deg = (float)bmr.LeftSideDiameterLineAngle_deg,
                     Box_Model_Result_Circle_Center_Latitude = (float)bmr.CircleCenterLatitude,
                     Box_Model_Result_Circle_Center_Longitude = (float)bmr.CircleCenterLongitude,
                     Box_Model_Result_Fix_Length = bmr.FixLength,
                     Box_Model_Result_Fix_Width = bmr.FixWidth,
                     Box_Model_Result_Rect_Length_m = (float)bmr.RectLength_m,
                     Box_Model_Result_Rect_Width_m = (float)bmr.RectWidth_m,
                     Box_Model_Result_Left_Side_Line_Angle_deg = (float)bmr.LeftSideLineAngle_deg,
                     Box_Model_Result_Left_Side_Line_Start_Latitude = (float)bmr.LeftSideLineStartLatitude,
                     Box_Model_Result_Left_Side_Line_Start_Longitude = (float)bmr.LeftSideLineStartLongitude,
                     Box_Model_Result_Last_Update_Date_UTC = bmr.LastUpdateDate_UTC,
                     Box_Model_Result_Last_Update_Contact_Name = contact.contactName,
                     Box_Model_Result_Last_Update_Contact_Initial = contact.contactInitial,
                 });

            try
            {
                reportBox_Model_ResultModelQ = ReportServiceGeneratedBox_Model_Result(reportBox_Model_ResultModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportBox_Model_ResultModel>() { new ReportBox_Model_ResultModel() { Box_Model_Result_Error = retStr } };


                if (CountOnly)
                    return new List<ReportBox_Model_ResultModel>() { new ReportBox_Model_ResultModel() { Box_Model_Result_Counter = reportBox_Model_ResultModelQ.Count() } };

                reportBox_Model_ResultModelList = reportBox_Model_ResultModelQ.Take(Take).ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportBox_Model_ResultModel>() { new ReportBox_Model_ResultModel() { Box_Model_Result_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            foreach (ReportBox_Model_ResultModel reportBox_Model_Result_Model in reportBox_Model_ResultModelList)
            {
                Counter += 1;
                reportBox_Model_Result_Model.Box_Model_Result_Counter = Counter;
            }

            return reportBox_Model_ResultModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}