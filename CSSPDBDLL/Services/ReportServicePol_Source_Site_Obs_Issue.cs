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
    public partial class ReportServicePol_Source_Site_Obs_Issue : ReportService
    {
        #region Variables      
        #endregion Variables

        #region Properties
        public PolSourceObservationService _PolSourceObservationService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportServicePol_Source_Site_Obs_Issue(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _PolSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions Helper      
        #endregion Functions Helper

        #region Functions public
        public List<ReportPol_Source_Site_Obs_IssueModel> GetReportPol_Source_Site_Obs_IssueModelListUnderTVItemIDDB(LanguageEnum Language, string TagText, int UnderTVItemID, string ParentTagItem, bool CountOnly, int Take)
        {
            List<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelList = new List<ReportPol_Source_Site_Obs_IssueModel>();
            List<ReportTreeNode> reportTreeNodeList = new List<ReportTreeNode>();
            string TagItem = "Pol_Source_Site_Obs_Issue";
            int Counter = 0;
            IQueryable<ReportPol_Source_Site_Obs_IssueModel> reportPol_Source_Site_Obs_IssueModelQ = null;

            if (TagText.StartsWith("|||Start "))
                return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = string.Format(ServiceRes.Tag_IsNotAllowedPleaseUse_, "|||Start " + TagItem + "...", "|||Loop " + TagItem + "...") } };

            if (string.IsNullOrWhiteSpace(ParentTagItem) || ParentTagItem != "Pol_Source_Site_Obs")
                return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = string.Format(ServiceRes.ParentTagItemHasToBe_Its_, "Pol_Source_Site_Obs", ParentTagItem) } };

            PolSourceObservationModel polSourceObservationModel = _PolSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(UnderTVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
                return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservation, ServiceRes.PolSourceObservationID, UnderTVItemID.ToString()) } };

            bool IsDBFiltering = true;
            string retStr = _ReportBaseService.GetReportTreeNodesFromTagText(TagText, TagItem, typeof(ReportPol_Source_Site_Obs_IssueModel), reportTreeNodeList, IsDBFiltering);
            if (!string.IsNullOrWhiteSpace(retStr))
                return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = retStr } };

            string Pol_Source_Site_Obs_Issue_Filtering = "";
            ReportTreeNode reportTreeNodeFiltering = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Obs_Issue_Filtering").FirstOrDefault();
            if (reportTreeNodeFiltering != null)
            {
                if (reportTreeNodeFiltering.dbFilteringTextFieldList.Count > 0)
                {
                    Pol_Source_Site_Obs_Issue_Filtering = reportTreeNodeFiltering.dbFilteringTextFieldList[0].TextCondition;
                }
            }

            int? Pol_Source_Site_Obs_Issue_Items_Text_Start_Level = null;
            ReportTreeNode reportTreeNodeStartLevel = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Obs_Issue_Items_Text_Start_Level").FirstOrDefault();
            if (reportTreeNodeStartLevel != null)
            {
                if (reportTreeNodeStartLevel.dbFilteringNumberFieldList.Count > 0)
                {
                    Pol_Source_Site_Obs_Issue_Items_Text_Start_Level = (int)reportTreeNodeStartLevel.dbFilteringNumberFieldList[0].NumberCondition;
                }
            }

            int? Pol_Source_Site_Obs_Issue_Items_Text_End_Level = null;
            ReportTreeNode reportTreeNodeEndLevel = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Obs_Issue_Items_Text_End_Level").FirstOrDefault();
            if (reportTreeNodeEndLevel != null)
            {
                if (reportTreeNodeEndLevel.dbFilteringNumberFieldList.Count > 0)
                {
                    Pol_Source_Site_Obs_Issue_Items_Text_End_Level = (int)reportTreeNodeEndLevel.dbFilteringNumberFieldList[0].NumberCondition;
                }
            }

            if (Pol_Source_Site_Obs_Issue_Items_Text_Start_Level != null && Pol_Source_Site_Obs_Issue_Items_Text_End_Level == null)
            {
                return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = string.Format(ServiceRes._IsRequired, "Pol_Source_Site_Obs_Issue_Items_Text_End_Level") } };
            }

            if (Pol_Source_Site_Obs_Issue_Items_Text_Start_Level == null && Pol_Source_Site_Obs_Issue_Items_Text_End_Level != null)
            {
                return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = string.Format(ServiceRes._IsRequired, "Pol_Source_Site_Obs_Issue_Items_Text_Start_Level") } };
            }

            if (Pol_Source_Site_Obs_Issue_Items_Text_Start_Level != null && Pol_Source_Site_Obs_Issue_Items_Text_End_Level != null)
            {
                if ((int)Pol_Source_Site_Obs_Issue_Items_Text_Start_Level > (int)Pol_Source_Site_Obs_Issue_Items_Text_End_Level)
                {
                    return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = string.Format(ServiceRes._ShouldBeMoreThan_, "Pol_Source_Site_Obs_Issue_Items_Text_Start_Level", "Pol_Source_Site_Obs_Issue_Items_Text_End_Level") } };
                }
            }

            bool? Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal = null;
            ReportTreeNode reportTreeNodeReverseEqual = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal").FirstOrDefault();
            if (reportTreeNodeReverseEqual != null)
            {
                if (reportTreeNodeReverseEqual.dbFilteringTrueFalseFieldList.Count > 0)
                {
                    if (reportTreeNodeReverseEqual.dbFilteringTrueFalseFieldList[0].ReportCondition == ReportConditionEnum.ReportConditionTrue)
                    {
                        Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal = true;
                    }
                    else
                    {
                        Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal = false;
                    }
                }
            }

            if (Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal != null && Pol_Source_Site_Obs_Issue_Filtering.Length == 0)
            {
                return new List<ReportPol_Source_Site_Obs_IssueModel>()
                {
                    new ReportPol_Source_Site_Obs_IssueModel()
                    {
                        Pol_Source_Site_Obs_Issue_Error = string.Format(ServiceRes.ToUse_YouNeed_NotToBeEmpty,
                        "Pol_Source_Site_Obs_Issue_Sentence_Reverse_Equal", "Pol_Source_Site_Obs_Issue_Filtering")
                    }
                };
            }

            PolSourceIssueRiskEnum Pol_Source_Site_Obs_Issue_Risk = PolSourceIssueRiskEnum.Error;
            ReportTreeNode reportTreeNodeRisk = reportTreeNodeList.Where(c => c.Text == "Pol_Source_Site_Obs_Issue_Risk").FirstOrDefault();
            if (reportTreeNodeRisk != null)
            {
                if (reportTreeNodeRisk.dbFilteringEnumFieldList.Count > 0)
                {
                    string tempCondition = reportTreeNodeRisk.dbFilteringEnumFieldList[0].EnumConditionText;
                    switch (tempCondition)
                    {
                        case "HighRisk":
                            {
                                Pol_Source_Site_Obs_Issue_Risk = PolSourceIssueRiskEnum.HighRisk;
                            }
                            break;
                        case "ModerateRisk":
                            {
                                Pol_Source_Site_Obs_Issue_Risk = PolSourceIssueRiskEnum.ModerateRisk;
                            }
                            break;
                        case "LowRisk":
                            {
                                Pol_Source_Site_Obs_Issue_Risk = PolSourceIssueRiskEnum.LowRisk;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            reportPol_Source_Site_Obs_IssueModelQ =
            (from p in db.PolSourceObservationIssues
             let contact = (from cc in db.Contacts
                            let contactName = (cc.FirstName + " " + (cc.Initial != null && cc.Initial != "" ? cc.Initial + ". " : "") + cc.LastName)
                            let contactInitial = cc.FirstName.ToUpper().Substring(0, 1) + cc.LastName.ToUpper().Substring(0, 1)
                            where cc.ContactTVItemID == p.LastUpdateContactTVItemID
                            select new { contactName, contactInitial }).FirstOrDefault()
             where p.PolSourceObservationID == UnderTVItemID
             select new ReportPol_Source_Site_Obs_IssueModel
             {
                 Pol_Source_Site_Obs_Issue_Error = "",
                 Pol_Source_Site_Obs_Issue_Counter = 0,
                 Pol_Source_Site_Obs_Issue_ID = p.PolSourceObservationIssueID,
                 Pol_Source_Site_Obs_Issue_Items_Text = "",
                 Pol_Source_Site_Obs_Issue_Items_Text_First_Initial = "",
                 Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial = "",
                 Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial = "",
                 Pol_Source_Site_Obs_Issue_Items_Text_Start_Level = Pol_Source_Site_Obs_Issue_Items_Text_Start_Level,
                 Pol_Source_Site_Obs_Issue_Items_Text_End_Level = Pol_Source_Site_Obs_Issue_Items_Text_End_Level,
                 Pol_Source_Site_Obs_Issue_Enum_ID_List = p.ObservationInfo,
                 Pol_Source_Site_Obs_Issue_Risk = Pol_Source_Site_Obs_Issue_Risk,
                 Pol_Source_Site_Obs_Issue_Items_Risk_Text = "",
                 Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial = "",
                 Pol_Source_Site_Obs_Issue_Sentence = "",
                 Pol_Source_Site_Obs_Issue_Filtering = "",
                 Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal = Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal,
                 Pol_Source_Site_Obs_Issue_Last_Update_Date_And_Time_UTC = p.LastUpdateDate_UTC,
                 Pol_Source_Site_Obs_Issue_Last_Update_Contact_Name = contact.contactName,
                 Pol_Source_Site_Obs_Issue_Last_Update_Contact_Initial = contact.contactInitial,
             });

            try
            {
                reportPol_Source_Site_Obs_IssueModelQ = ReportServiceGeneratedPol_Source_Site_Obs_Issue(reportPol_Source_Site_Obs_IssueModelQ, reportTreeNodeList);
                ReportTreeNode reportTreeNode = reportTreeNodeList.Where(c => c.Error != "").FirstOrDefault();
                retStr = (reportTreeNode == null ? "" : reportTreeNode.Error);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = retStr } };

                if (CountOnly)
                    return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Counter = reportPol_Source_Site_Obs_IssueModelQ.Count() } };

                reportPol_Source_Site_Obs_IssueModelList = reportPol_Source_Site_Obs_IssueModelQ.ToList();
            }
            catch (Exception ex)
            {
                return new List<ReportPol_Source_Site_Obs_IssueModel>() { new ReportPol_Source_Site_Obs_IssueModel() { Pol_Source_Site_Obs_Issue_Error = "Error: [" + ex.Message + "]" + (ex.InnerException != null ? " InnerError: [" + ex.InnerException.Message + "]" : "") } };
            }

            List<string> PolSourceObsInfoEqualList = new List<string>();
            foreach (ReportTreeNode reportTreeNode in reportTreeNodeList.Where(c => c.dbFilteringTextFieldList.Count > 0
            && c.Text == "Pol_Source_Site_Obs_Issue_Filtering"))
            {
                foreach (ReportConditionTextField reportTextField in reportTreeNode.dbFilteringTextFieldList)
                {
                    if (reportTextField.ReportCondition == ReportConditionEnum.ReportConditionEqual)
                    {
                        List<string> PolSourceObsInfoTextList = reportTextField.TextCondition.Split("*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                        foreach (string s in PolSourceObsInfoTextList)
                        {
                            bool Found = false;
                            foreach (PolSourceObsInfoEnum polSourceObsInfo in Enum.GetValues(typeof(PolSourceObsInfoEnum)))
                            {
                                if (polSourceObsInfo.ToString() == s)
                                {
                                    PolSourceObsInfoEqualList.Add(((int)polSourceObsInfo).ToString());
                                    Found = true;
                                }
                            }

                            if (!Found)
                                PolSourceObsInfoEqualList.Add(PolSourceObsInfoEnum.Error.ToString());
                        }
                    }
                }
            }

            foreach (ReportPol_Source_Site_Obs_IssueModel reportPol_Source_Site_Obs_IssueModel in reportPol_Source_Site_Obs_IssueModelList)
            {
                PolSourceObservationIssue polSourceObservationIssue = (from c in db.PolSourceObservationIssues
                                                                       where c.PolSourceObservationIssueID == reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_ID
                                                                       select c).FirstOrDefault();

                PolSourceObservation polSourceObservation = new CSSPDBDLL.PolSourceObservation();
                if (polSourceObservationIssue != null)
                {
                    polSourceObservation = (from c in db.PolSourceObservations
                                            where c.PolSourceObservationID == polSourceObservationIssue.PolSourceObservationID
                                            select c).FirstOrDefault();
                }


                // check if one of the Issue contain ",91" or ",92" or ",93" --> Risk

                bool ContainRisk = false;
                if (polSourceObservationIssue.ObservationInfo.Contains(",91")
                                    || polSourceObservationIssue.ObservationInfo.Contains(",92")
                                    || polSourceObservationIssue.ObservationInfo.Contains(",93"))
                {
                    ContainRisk = true;
                }


                if (!ContainRisk)
                {
                    if (polSourceObservationIssue != null)
                    {
                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text = ServiceRes.WrittenDescription + " : " + polSourceObservation.Observation_ToBeDeleted;
                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Sentence = ServiceRes.WrittenDescription + " : " + polSourceObservation.Observation_ToBeDeleted;
                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Enum_ID_List = polSourceObservationIssue.ObservationInfo;
                    }
                    else
                    {
                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text = ServiceRes.WrittenDescription + " : " + ServiceRes.Empty;
                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Sentence = ServiceRes.WrittenDescription + " : " + ServiceRes.Empty;
                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Enum_ID_List = ServiceRes.Empty;
                    }
                    reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial = "";
                    reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial = "";
                    reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial = "";
                    reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Risk_Text = "";
                    reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial = "";
                }
                else
                {
                    bool EqualRisk = false;
                    if (Pol_Source_Site_Obs_Issue_Risk != PolSourceIssueRiskEnum.Error)
                    {
                        if (Pol_Source_Site_Obs_Issue_Risk == PolSourceIssueRiskEnum.HighRisk
                            && (polSourceObservationIssue.ObservationInfo.Contains(",93001")
                            || polSourceObservationIssue.ObservationInfo.Contains(",92002")))
                        {
                            EqualRisk = true;
                        }
                        else if (Pol_Source_Site_Obs_Issue_Risk == PolSourceIssueRiskEnum.ModerateRisk
                            && polSourceObservationIssue.ObservationInfo.Contains(",92001"))
                        {
                            EqualRisk = true;
                        }
                        else if (Pol_Source_Site_Obs_Issue_Risk == PolSourceIssueRiskEnum.LowRisk
                            && polSourceObservationIssue.ObservationInfo.Contains(",91001"))
                        {
                            EqualRisk = true;
                        }
                        else
                        {
                            // nothing
                        }
                    }
                    else
                    {
                        EqualRisk = true;
                    }

                    if (PolSourceObsInfoEqualList.Count > 0)
                    {
                        int countEqualFound = 0;
                        int countReverseEqualFound = 0;
                        foreach (string s in PolSourceObsInfoEqualList)
                        {
                            if (polSourceObservationIssue.ObservationInfo.Contains(s))
                            {
                                countEqualFound += 1;
                            }

                            if (!polSourceObservationIssue.ObservationInfo.Contains(s))
                            {
                                countReverseEqualFound += 1;
                            }
                        }

                        if (Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal != null && Pol_Source_Site_Obs_Issue_Filtering_Reverse_Equal == true)
                        {
                            if (countReverseEqualFound == PolSourceObsInfoEqualList.Count)
                            {
                                if (EqualRisk)
                                {
                                    if (string.IsNullOrWhiteSpace(reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Sentence))
                                    {
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Enum_ID_List = polSourceObservationIssue.ObservationInfo;
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Sentence = GetPolSourceObsIssueSentence(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, 0, 1000);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial = GetPolSourceObsIssueSelectionFirstInitial(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial = GetPolSourceObsIssueSelectionSecondInitial(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial = GetPolSourceObsIssueSelectionLastInitial(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Risk_Text = GetPolSourceObsIssueSelectionRisk(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial = GetPolSourceObsIssueSelectionRiskInitial(polSourceObservationIssue.ObservationInfo);
                                        if (Pol_Source_Site_Obs_Issue_Items_Text_Start_Level != null
                                            && Pol_Source_Site_Obs_Issue_Items_Text_End_Level != null)
                                        {
                                            reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, (int)Pol_Source_Site_Obs_Issue_Items_Text_Start_Level, (int)Pol_Source_Site_Obs_Issue_Items_Text_End_Level);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (countEqualFound == PolSourceObsInfoEqualList.Count)
                            {
                                if (EqualRisk)
                                {
                                    if (string.IsNullOrWhiteSpace(reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Sentence))
                                    {
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Enum_ID_List = polSourceObservationIssue.ObservationInfo;
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Sentence = GetPolSourceObsIssueSentence(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, 0, 1000);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial = GetPolSourceObsIssueSelectionFirstInitial(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial = GetPolSourceObsIssueSelectionSecondInitial(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial = GetPolSourceObsIssueSelectionLastInitial(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Risk_Text = GetPolSourceObsIssueSelectionRisk(polSourceObservationIssue.ObservationInfo);
                                        reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial = GetPolSourceObsIssueSelectionRiskInitial(polSourceObservationIssue.ObservationInfo);
                                        if (Pol_Source_Site_Obs_Issue_Items_Text_Start_Level != null
                                            && Pol_Source_Site_Obs_Issue_Items_Text_End_Level != null)
                                        {
                                            reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, (int)Pol_Source_Site_Obs_Issue_Items_Text_Start_Level, (int)Pol_Source_Site_Obs_Issue_Items_Text_End_Level);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (EqualRisk)
                        {
                            if (string.IsNullOrWhiteSpace(reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Sentence))
                            {
                                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Enum_ID_List = polSourceObservationIssue.ObservationInfo;
                                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Sentence = GetPolSourceObsIssueSentence(polSourceObservationIssue.ObservationInfo);
                                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, 0, 1000);
                                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_First_Initial = GetPolSourceObsIssueSelectionFirstInitial(polSourceObservationIssue.ObservationInfo);
                                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_Second_Initial = GetPolSourceObsIssueSelectionSecondInitial(polSourceObservationIssue.ObservationInfo);
                                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text_Last_Initial = GetPolSourceObsIssueSelectionLastInitial(polSourceObservationIssue.ObservationInfo);
                                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Risk_Text = GetPolSourceObsIssueSelectionRisk(polSourceObservationIssue.ObservationInfo);
                                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Risk_Text_Initial = GetPolSourceObsIssueSelectionRiskInitial(polSourceObservationIssue.ObservationInfo);
                                if (Pol_Source_Site_Obs_Issue_Items_Text_Start_Level != null
                                    && Pol_Source_Site_Obs_Issue_Items_Text_End_Level != null)
                                {
                                    reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Items_Text = GetPolSourceObsIssueSelection(polSourceObservationIssue.ObservationInfo, (int)Pol_Source_Site_Obs_Issue_Items_Text_Start_Level, (int)Pol_Source_Site_Obs_Issue_Items_Text_End_Level);
                                }
                            }
                        }
                    }
                }
            }

            reportPol_Source_Site_Obs_IssueModelList = reportPol_Source_Site_Obs_IssueModelList.Where(c => c.Pol_Source_Site_Obs_Issue_Sentence != "").ToList();

            foreach (ReportPol_Source_Site_Obs_IssueModel reportPol_Source_Site_Obs_IssueModel in reportPol_Source_Site_Obs_IssueModelList)
            {
                Counter += 1;
                reportPol_Source_Site_Obs_IssueModel.Pol_Source_Site_Obs_Issue_Counter = Counter;
            }

            return reportPol_Source_Site_Obs_IssueModelList;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}