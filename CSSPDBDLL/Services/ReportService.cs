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
    public partial class ReportService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public ReportBaseService _ReportBaseService { get; set; }
        #endregion Properties

        #region Constructors
        public ReportService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _ReportBaseService = new ReportBaseService(LanguageRequest, new System.Windows.Forms.TreeView());
        }
        #endregion Constructors

        #region Functions Helper      
        public string CheckFromAndToValues(ReportTreeNode reportTreeNode, int? From, int? To, string VarText, string Condition)
        {
            if (From != null && To == null)
            {
                reportTreeNode.Error = string.Format(ServiceRes._IsRequiredWhenUsing_For_Condition, "TO_" + VarText, "FROM_" + VarText, Condition);
                return reportTreeNode.Error;
            }
            if (From == null && To != null)
            {
                reportTreeNode.Error = string.Format(ServiceRes._IsRequiredWhenUsing_For_Condition, "FROM_" + VarText, "TO_" + VarText, Condition);
                return reportTreeNode.Error;
            }

            return "";
        }
        public string GetPolSourceObsIssueSentence(string IDsText)
        {
            string Sentence = "";
            if (string.IsNullOrWhiteSpace(IDsText))
            {
                Sentence = ServiceRes.Empty;
            }
            else
            {
                List<string> IdsList = IDsText.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string s in IdsList)
                {
                    Sentence += _BaseEnumService.GetEnumText_PolSourceObsInfoReportEnum((PolSourceObsInfoEnum)int.Parse(s));
                }
            }

            return Sentence;
        }
        public string GetPolSourceObsIssueSelection(string IDsText, int StartLevel, int EndLevel)
        {
            string Selection = "";
            if (string.IsNullOrWhiteSpace(IDsText))
            {
                Selection = ServiceRes.Empty;
            }
            else
            {
                List<string> IdsList = IDsText.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                int count = 0;
                foreach (string s in IdsList)
                {
                    if (count >= StartLevel && count <= EndLevel)
                    {
                        string tempText = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(s));
                        if (tempText.IndexOf("|") > 0)
                        {
                            tempText = tempText.Substring(0, tempText.IndexOf("|")).Trim();
                        }
                        if (!string.IsNullOrWhiteSpace(tempText))
                        {
                            if (tempText.Last() == ",".ToCharArray()[0])
                            {
                                tempText = tempText.Substring(0, tempText.Length - 1) + ", ";
                            }
                            else
                            {
                                tempText = tempText + ", ";
                            }
                        }

                        Selection += tempText;
                    }
                    count += 1;
                }
            }

            Selection = Selection.Trim();
            if (!string.IsNullOrWhiteSpace(Selection))
            {
                if (Selection.Last() == ",".ToCharArray()[0])
                {
                    Selection = Selection.Substring(0, Selection.Length - 1);
                }
            }

            return Selection;
        }
        public string GetPolSourceObsIssueSelectionFirstInitial(string IDsText/*, int StartLevel, int EndLevel*/)
        {
            List<string> IdsList = IDsText.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string s in IdsList)
            {
                if (!s.StartsWith("9"))
                {
                    string tempTextInitial = _BaseEnumService.GetEnumText_PolSourceObsInfoInitEnum((PolSourceObsInfoEnum)int.Parse(s)).Trim();
                    if (!string.IsNullOrWhiteSpace(tempTextInitial))
                    {
                        return tempTextInitial;
                    }
                }
            }

            return "";
        }
        public string GetPolSourceObsIssueSelectionSecondInitial(string IDsText/*, int StartLevel, int EndLevel*/)
        {
            bool SkippedFirst = false;
            List<string> IdsList = IDsText.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string s in IdsList)
            {
                if (!s.StartsWith("9"))
                {
                    string tempTextInitial = _BaseEnumService.GetEnumText_PolSourceObsInfoInitEnum((PolSourceObsInfoEnum)int.Parse(s)).Trim();
                    if (!string.IsNullOrWhiteSpace(tempTextInitial))
                    {
                        if (SkippedFirst)
                        {
                            return tempTextInitial;
                        }
                        else
                        {
                            SkippedFirst = true;
                        }
                    }
                }
            }

            return "";
        }
        public string GetPolSourceObsIssueSelectionLastInitial(string IDsText/*, int StartLevel, int EndLevel*/)
        {
            string TextLastInitial = "";
            List<string> IdsList = IDsText.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string s in IdsList)
            {
                if (!s.StartsWith("9"))
                {
                    string tempTextInitial = _BaseEnumService.GetEnumText_PolSourceObsInfoInitEnum((PolSourceObsInfoEnum)int.Parse(s)).Trim();
                    if (!string.IsNullOrWhiteSpace(tempTextInitial))
                    {
                        TextLastInitial = tempTextInitial;
                    }
                }
            }

            return TextLastInitial;
        }
        public string GetPolSourceObsIssueSelectionRisk(string IDsText)
        {
            string Selection = "";
            if (string.IsNullOrWhiteSpace(IDsText))
            {
                Selection = ServiceRes.Empty;
            }
            else
            {
                List<string> IdsList = IDsText.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                if (IdsList.Count == 0)
                {
                    return Selection;
                }
                string tempTextRisk = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(IdsList.Last()));
                if (tempTextRisk.IndexOf("|") > 0)
                {
                    tempTextRisk = tempTextRisk.Substring(0, tempTextRisk.IndexOf("|")).Trim();
                }
                if (!string.IsNullOrWhiteSpace(tempTextRisk))
                {
                    if (tempTextRisk.Last() == ",".ToCharArray()[0])
                    {
                        tempTextRisk = tempTextRisk.Substring(0, tempTextRisk.Length - 1);
                    }
                    else
                    {
                        tempTextRisk = tempTextRisk.Substring(0, tempTextRisk.Length);
                    }
                }

                Selection = tempTextRisk;
            }

            return Selection;
        }
        public string GetPolSourceObsIssueSelectionRiskInitial(string IDsText)
        {
            string Selection = "";
            if (string.IsNullOrWhiteSpace(IDsText))
            {
                Selection = ServiceRes.Empty;
            }
            else
            {
                List<string> IdsList = IDsText.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                if (IdsList.Count == 0)
                {
                    return Selection;
                }

                string tempTextRisk = _BaseEnumService.GetEnumText_PolSourceObsInfoInitEnum((PolSourceObsInfoEnum)int.Parse(IdsList.Last())).Trim();
                if (!string.IsNullOrWhiteSpace(tempTextRisk))
                {
                    if (tempTextRisk.Last() == ",".ToCharArray()[0])
                    {
                        tempTextRisk = tempTextRisk.Substring(0, tempTextRisk.Length - 1) + ", ";
                    }
                    else
                    {
                        tempTextRisk = tempTextRisk + ", ";
                    }
                }

                Selection = tempTextRisk;
            }

            return Selection;
        }
        #endregion Functions Helper

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}