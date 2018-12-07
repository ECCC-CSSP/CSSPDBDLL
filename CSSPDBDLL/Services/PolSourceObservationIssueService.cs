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
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class PolSourceObservationIssueService : BaseService
    {
        #region Variables
        private List<string> startWithList = new List<string>() { "101", "143", "910" };
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        public override string FieldCheckNotNullDateTime(DateTime? Value, string Res)
        {
            return base.FieldCheckNotNullDateTime(Value, Res);
        }
        public override string DoAddChanges()
        {
            return base.DoAddChanges();
        }
        public override string DoDeleteChanges()
        {
            return base.DoDeleteChanges();
        }
        public override string DoUpdateChanges()
        {
            return base.DoUpdateChanges();
        }
        public PolSourceObservationModel GetPolSourceObservationModelWithPolSourceObservationIDDB(int PolSourceObservationID)
        {
            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
            return polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(PolSourceObservationID);
        }
        public PolSourceSiteModel GetPolSourceSiteModelWithPolSourceSiteIDDB(int PolSourceSiteID)
        {
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
            return polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteIDDB(PolSourceSiteID);
        }
        public List<PolSourceObservationModel> GetPolSourceObservationModelListWithPolSourceSiteIDDB(int PolSourceSiteID)
        {
            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
            return polSourceObservationService.GetPolSourceObservationModelListWithPolSourceSiteIDDB(PolSourceSiteID);
        }
        public PolSourceSiteModel PostUpdatePolSourceSiteDB(PolSourceSiteModel polSourceSiteModel)
        {
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
            return polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
        }

        // Check
        public string PolSourceObservationIssueModelOK(PolSourceObservationIssueModel polSourceObservationIssueModel)
        {
            string retStr = FieldCheckNotZeroInt(polSourceObservationIssueModel.PolSourceObservationID, ServiceRes.PolSourceObservationID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(polSourceObservationIssueModel.ObservationInfo, ServiceRes.ObservationInfo, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(polSourceObservationIssueModel.Ordinal, ServiceRes.Ordinal, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.PolSourceObsInfoListOK(polSourceObservationIssueModel.PolSourceObsInfoList);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillPolSourceObservationIssue(PolSourceObservationIssue polSourceObservationIssue, PolSourceObservationIssueModel polSourceObservationIssueModel, ContactOK contactOK)
        {
            polSourceObservationIssue.PolSourceObservationID = polSourceObservationIssueModel.PolSourceObservationID;
            string ObservationInfo = "";
            if (polSourceObservationIssueModel.PolSourceObsInfoList != null)
            {
                foreach (PolSourceObsInfoEnum polSourceObsInfo in polSourceObservationIssueModel.PolSourceObsInfoList)
                {
                    ObservationInfo += (int)polSourceObsInfo + ",";
                }
            }
            polSourceObservationIssue.ObservationInfo = ObservationInfo;
            polSourceObservationIssue.Ordinal = polSourceObservationIssueModel.Ordinal;
            polSourceObservationIssue.ExtraComment = polSourceObservationIssueModel.ExtraComment;
            polSourceObservationIssue.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                polSourceObservationIssue.LastUpdateContactTVItemID = 2;
            }
            else
            {
                polSourceObservationIssue.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetPolSourceObservationIssueModelCountDB()
        {
            int PolSourceObservationIssueModelCount = (from c in db.PolSourceObservationIssues
                                                       select c).Count();

            return PolSourceObservationIssueModelCount;
        }
        public List<PolSourceObservationIssueModel> GetPolSourceObservationIssueModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<PolSourceObservationIssueModel> PolSourceObservationIssueModelList = (from pss in db.PolSourceSites
                                                                                       from pso in db.PolSourceObservations
                                                                                       from psoi in db.PolSourceObservationIssues
                                                                                       from t in db.TVItems
                                                                                       where pss.PolSourceSiteID == pso.PolSourceSiteID
                                                                                       && pso.PolSourceObservationID == psoi.PolSourceObservationID
                                                                                       && pss.PolSourceSiteTVItemID == t.TVItemID
                                                                                       && t.ParentID == SubsectorTVItemID
                                                                                       orderby psoi.Ordinal
                                                                                       select new PolSourceObservationIssueModel
                                                                                       {
                                                                                           Error = "",
                                                                                           PolSourceObservationIssueID = psoi.PolSourceObservationIssueID,
                                                                                           PolSourceObservationID = psoi.PolSourceObservationID,
                                                                                           ObservationInfo = psoi.ObservationInfo,
                                                                                           Ordinal = psoi.Ordinal,
                                                                                           ExtraComment = psoi.ExtraComment,
                                                                                           LastUpdateDate_UTC = psoi.LastUpdateDate_UTC,
                                                                                           LastUpdateContactTVItemID = psoi.LastUpdateContactTVItemID,
                                                                                       }).ToList<PolSourceObservationIssueModel>();

            foreach (PolSourceObservationIssueModel polSourceObservationIssueModel in PolSourceObservationIssueModelList)
            {
                if (polSourceObservationIssueModel.ObservationInfo != null && polSourceObservationIssueModel.ObservationInfo.Length > 0)
                {
                    List<string> PolSourceObsStrArr = polSourceObservationIssueModel.ObservationInfo.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<PolSourceObsInfoEnum> polSourceInfoList = new List<PolSourceObsInfoEnum>();
                    foreach (string s in PolSourceObsStrArr)
                    {
                        polSourceInfoList.Add((PolSourceObsInfoEnum)int.Parse(s));
                    }

                    polSourceObservationIssueModel.PolSourceObsInfoList = polSourceInfoList;
                }
            }

            return PolSourceObservationIssueModelList;
        }
        public List<PolSourceObservationIssueModel> GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(int PolSourceObservationID)
        {
            List<PolSourceObservationIssueModel> PolSourceObservationIssueModelList = (from c in db.PolSourceObservationIssues
                                                                                       where c.PolSourceObservationID == PolSourceObservationID
                                                                                       orderby c.Ordinal
                                                                                       select new PolSourceObservationIssueModel
                                                                                       {
                                                                                           Error = "",
                                                                                           PolSourceObservationIssueID = c.PolSourceObservationIssueID,
                                                                                           PolSourceObservationID = c.PolSourceObservationID,
                                                                                           ObservationInfo = c.ObservationInfo,
                                                                                           Ordinal = c.Ordinal,
                                                                                           ExtraComment = c.ExtraComment,
                                                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                       }).ToList<PolSourceObservationIssueModel>();

            foreach (PolSourceObservationIssueModel polSourceObservationIssueModel in PolSourceObservationIssueModelList)
            {
                if (polSourceObservationIssueModel.ObservationInfo != null && polSourceObservationIssueModel.ObservationInfo.Length > 0)
                {
                    List<string> PolSourceObsStrArr = polSourceObservationIssueModel.ObservationInfo.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                    List<PolSourceObsInfoEnum> polSourceInfoList = new List<PolSourceObsInfoEnum>();
                    foreach (string s in PolSourceObsStrArr)
                    {
                        polSourceInfoList.Add((PolSourceObsInfoEnum)int.Parse(s));
                    }

                    polSourceObservationIssueModel.PolSourceObsInfoList = polSourceInfoList;
                }
            }

            return PolSourceObservationIssueModelList;
        }
        public PolSourceObservationIssueModel GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(int PolSourceObservationIssueID)
        {
            PolSourceObservationIssueModel polSourceObservationIssueModel = (from c in db.PolSourceObservationIssues
                                                                             where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                                                                             select new PolSourceObservationIssueModel
                                                                             {
                                                                                 Error = "",
                                                                                 PolSourceObservationIssueID = c.PolSourceObservationIssueID,
                                                                                 PolSourceObservationID = c.PolSourceObservationID,
                                                                                 ObservationInfo = c.ObservationInfo,
                                                                                 Ordinal = c.Ordinal,
                                                                                 ExtraComment = c.ExtraComment,
                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                             }).FirstOrDefault<PolSourceObservationIssueModel>();

            if (polSourceObservationIssueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservationIssue,
                    ServiceRes.PolSourceObservationIssueID, PolSourceObservationIssueID));

            if (polSourceObservationIssueModel.ObservationInfo != null && polSourceObservationIssueModel.ObservationInfo.Length > 0)
            {
                List<string> PolSourceObsStrArr = polSourceObservationIssueModel.ObservationInfo.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                List<PolSourceObsInfoEnum> polSourceInfoList = new List<PolSourceObsInfoEnum>();
                foreach (string s in PolSourceObsStrArr)
                {
                    polSourceInfoList.Add((PolSourceObsInfoEnum)int.Parse(s));
                }

                polSourceObservationIssueModel.PolSourceObsInfoList = polSourceInfoList;
            }

            return polSourceObservationIssueModel;
        }
        public PolSourceObservationIssue GetPolSourceObservationIssueWithPolSourceObservationIssueIDDB(int PolSourceObservationIssueID)
        {
            PolSourceObservationIssue PolSourceObservationIssue = (from c in db.PolSourceObservationIssues
                                                                   where c.PolSourceObservationIssueID == PolSourceObservationIssueID
                                                                   select c).FirstOrDefault<PolSourceObservationIssue>();

            return PolSourceObservationIssue;
        }
        public PolSourceObservationIssueModel GetPolSourceObservationIssueModelExistDB(PolSourceObservationIssueModel polSourceObservationIssueModel)
        {
            PolSourceObservationIssueModel polSourceObservationIssueModelRet = (from c in db.PolSourceObservationIssues
                                                                                where c.PolSourceObservationID == polSourceObservationIssueModel.PolSourceObservationID
                                                                                && c.Ordinal == polSourceObservationIssueModel.Ordinal
                                                                                select new PolSourceObservationIssueModel
                                                                                {
                                                                                    Error = "",
                                                                                    PolSourceObservationIssueID = c.PolSourceObservationIssueID,
                                                                                    PolSourceObservationID = c.PolSourceObservationID,
                                                                                    ObservationInfo = c.ObservationInfo,
                                                                                    Ordinal = c.Ordinal,
                                                                                    ExtraComment = c.ExtraComment,
                                                                                    LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                    LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                }).FirstOrDefault<PolSourceObservationIssueModel>();

            if (polSourceObservationIssueModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceObservationIssue, ServiceRes.PolSourceObservationID + "," + ServiceRes.Ordinal, polSourceObservationIssueModel.PolSourceObservationID + "," + polSourceObservationIssueModel.Ordinal));

            if (polSourceObservationIssueModel.ObservationInfo != null && polSourceObservationIssueModel.ObservationInfo.Length > 0)
            {
                List<string> PolSourceObsStrArr = polSourceObservationIssueModel.ObservationInfo.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                List<PolSourceObsInfoEnum> polSourceInfoList = new List<PolSourceObsInfoEnum>();
                foreach (string s in PolSourceObsStrArr)
                {
                    polSourceInfoList.Add((PolSourceObsInfoEnum)int.Parse(s));
                }

                polSourceObservationIssueModel.PolSourceObsInfoList = polSourceInfoList;
            }

            return polSourceObservationIssueModelRet;
        }
        public PolSourceObservationIssue GetPolSourceObservationIssueExistDB(PolSourceObservationIssueModel polSourceObservationIssueModel)
        {
            PolSourceObservationIssue polSourceObservationIssue = (from c in db.PolSourceObservationIssues
                                                                   where c.PolSourceObservationID == polSourceObservationIssueModel.PolSourceObservationID
                                                                   && c.Ordinal == polSourceObservationIssueModel.Ordinal
                                                                   select c).FirstOrDefault<PolSourceObservationIssue>();

            return polSourceObservationIssue;
        }

        // Helper
        public PolSourceObservationIssueModel ReturnError(string Error)
        {
            return new PolSourceObservationIssueModel() { Error = Error };
        }

        // Post
        public PolSourceObservationIssueModel PostAddEmptyPolSourceObservationIssueDB(FormCollection fc)
        {
            int PolSourceObservationID = 0;
            int NextIssueOrdinal = -1;

            int.TryParse(fc["PolSourceObservationID"], out PolSourceObservationID);
            if (PolSourceObservationID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceObservationID));

            PolSourceObservationModel polSourceObservationModel = GetPolSourceObservationModelWithPolSourceObservationIDDB(PolSourceObservationID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
                return ReturnError(polSourceObservationModel.Error);

            int.TryParse(fc["NextIssueOrdinal"], out NextIssueOrdinal); // will default to 0

            PolSourceObservationIssueModel polSourceObservationIssueModelNew = new PolSourceObservationIssueModel();
            polSourceObservationIssueModelNew.PolSourceObservationID = polSourceObservationModel.PolSourceObservationID;
            polSourceObservationIssueModelNew.ObservationInfo = ((int)PolSourceObsInfoEnum.SourceStart).ToString() + ",";
            polSourceObservationIssueModelNew.PolSourceObsInfoList = polSourceObservationIssueModelNew.ObservationInfo.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((PolSourceObsInfoEnum)int.Parse(c))).ToList();
            polSourceObservationIssueModelNew.Ordinal = NextIssueOrdinal;
            polSourceObservationIssueModelNew.ExtraComment = "";

            PolSourceObservationIssueModel polSourceObservationIssueModelExist = GetPolSourceObservationIssueModelExistDB(polSourceObservationIssueModelNew);
            if (string.IsNullOrWhiteSpace(polSourceObservationIssueModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.PolSourceObservationIssue));

            PolSourceObservationIssueModel polSourceObservationIssueModelRet = PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelNew);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                return ReturnError(polSourceObservationIssueModelRet.Error);

            return polSourceObservationIssueModelRet;
        }
        public PolSourceObservationIssueModel PostModifyPolSourceObservationIssueDB(FormCollection fc)
        {
            int PolSourceObservationIssueID = 0;
            string ObservationInfo = "";
            string TVText = "";
            string ExtraComment = "";

            int.TryParse(fc["PolSourceObservationIssueID"], out PolSourceObservationIssueID);
            if (PolSourceObservationIssueID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceObservationIssueID));

            PolSourceObservationIssueModel polSourceObservationIssueModel = GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(PolSourceObservationIssueID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModel.Error))
                return ReturnError(polSourceObservationIssueModel.Error);

            PolSourceObservationIssueModel polSourceObservationIssueModelFirstOrdinal = GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(polSourceObservationIssueModel.PolSourceObservationID).OrderBy(c => c.Ordinal).FirstOrDefault();
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelFirstOrdinal.Error))
                return ReturnError(polSourceObservationIssueModelFirstOrdinal.Error);


            ObservationInfo = "";
            for (int i = 0, count = fc.Count; i < count; i++)
            {
                if (fc.Keys[i].StartsWith("c"))
                {
                    string StartTxt = fc[i].Substring(0, 3);

                    ObservationInfo = ObservationInfo + fc[i] + ",";
                    if (startWithList.Where(c => c.StartsWith(StartTxt)).Any())
                    {
                        TVText = TVText.Trim();
                        string TempText = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(fc[i]));
                        if (TempText.IndexOf("|") > 0)
                        {
                            TempText = TempText.Substring(0, TempText.IndexOf("|")).Trim();
                        }
                        TVText = TVText + (TVText.Length == 0 ? "" : ", ") + TempText;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(fc["ExtraComment"]))
            {
                ExtraComment = fc["ExtraComment"];
            }

            PolSourceObservationIssueModel polSourceObservationIssueModelRet = new PolSourceObservationIssueModel();

            string NC = "";
            if (!string.IsNullOrWhiteSpace(ObservationInfo))
            {
                List<int> polSourceObsInfoIntList = ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                polSourceObservationIssueModel.ObservationInfo = ObservationInfo;
                polSourceObservationIssueModel.PolSourceObsInfoList = polSourceObservationIssueModel.ObservationInfo.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((PolSourceObsInfoEnum)int.Parse(c))).ToList();
                polSourceObservationIssueModel.ExtraComment = ExtraComment;

                polSourceObservationIssueModelRet = PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModel);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                    return ReturnError(polSourceObservationIssueModelRet.Error);

                bool WellFormed = IssueWellFormed(polSourceObsInfoIntList, polSourceObsInfoChildList);
                bool Completed = IssueCompleted(polSourceObsInfoIntList, polSourceObsInfoChildList);

                NC = (WellFormed == false || Completed == false ? " (NC) - " : "");
                if (LanguageRequest == LanguageEnum.fr)
                {
                    NC = NC.Replace("NC", "PC");
                }
            }

            if (polSourceObservationIssueModel.Ordinal == polSourceObservationIssueModelFirstOrdinal.Ordinal)
            {
                PolSourceObservationModel polSourceObservationModel = GetPolSourceObservationModelWithPolSourceObservationIDDB(polSourceObservationIssueModel.PolSourceObservationID);
                if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
                    return ReturnError(polSourceObservationIssueModel.Error);

                PolSourceSiteModel polSourceSiteModel = GetPolSourceSiteModelWithPolSourceSiteIDDB(polSourceObservationModel.PolSourceSiteID);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                    return ReturnError(polSourceSiteModel.Error);

                TVText = "P00000".Substring(0, "P00000".Length - polSourceSiteModel.Site.ToString().Length) + polSourceSiteModel.Site.ToString() + " - " + NC + TVText;

                TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
                tvItemLanguageModel.Language = LanguageRequest;

                bool Found = true;
                while (Found)
                {
                    if (TVText.Contains("  "))
                    {
                        TVText = TVText.Replace("  ", " ");
                    }
                    else
                    {
                        Found = false;
                    }
                }

                tvItemLanguageModel.TVText = TVText;
                tvItemLanguageModel.TVItemID = polSourceSiteModel.PolSourceSiteTVItemID;

                TVItemLanguageModel tvItemLanguageModelRet = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                    return ReturnError(tvItemLanguageModelRet.Error);


                // doing the other language
                foreach (LanguageEnum lang in LanguageListAllowable.Where(c => c != LanguageRequest))
                {
                    TVItemService tvItemService = new TVItemService(lang, User);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

                    ObservationInfo = "";
                    TVText = "";
                    for (int i = 0, count = fc.Count; i < count; i++)
                    {
                        if (fc.Keys[i].StartsWith("c"))
                        {
                            string StartTxt = fc[i].Substring(0, 3);

                            ObservationInfo = ObservationInfo + fc[i] + ",";
                            if (startWithList.Where(c => c.StartsWith(StartTxt)).Any())
                            {
                                TVText = TVText.Trim();
                                string TempText = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(fc[i]));
                                if (TempText.IndexOf("|") > 0)
                                {
                                    TempText = TempText.Substring(0, TempText.IndexOf("|")).Trim();
                                }
                                TVText = TVText + (TVText.Length == 0 ? "" : ", ") + TempText;
                            }
                        }
                    }

                    TVText = "P00000".Substring(0, "P00000".Length - polSourceSiteModel.Site.ToString().Length) + polSourceSiteModel.Site.ToString() + " - " + NC + TVText;

                    tvItemLanguageModel = new TVItemLanguageModel();
                    tvItemLanguageModel.Language = lang;

                    Found = true;
                    while (Found)
                    {
                        if (TVText.Contains("  "))
                        {
                            TVText = TVText.Replace("  ", " ");
                        }
                        else
                        {
                            Found = false;
                        }
                    }

                    tvItemLanguageModel.TVText = TVText;
                    tvItemLanguageModel.TVItemID = polSourceSiteModel.PolSourceSiteTVItemID;

                    tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                    if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                        return ReturnError(tvItemLanguageModelRet.Error);

                    Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
                }
            }

            return polSourceObservationIssueModelRet;
        }
        public PolSourceObservationIssueModel PostAddPolSourceObservationIssueDB(PolSourceObservationIssueModel polSourceObservationIssueModel)
        {
            string retStr = PolSourceObservationIssueModelOK(polSourceObservationIssueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceObservationIssueModel polSourceObservationIssueModelExist = GetPolSourceObservationIssueModelExistDB(polSourceObservationIssueModel);
            if (string.IsNullOrWhiteSpace(polSourceObservationIssueModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.PolSourceObservationIssue));

            PolSourceObservationIssue polSourceObservationIssueNew = new PolSourceObservationIssue();
            retStr = FillPolSourceObservationIssue(polSourceObservationIssueNew, polSourceObservationIssueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceObservationIssues.Add(polSourceObservationIssueNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceObservationIssues", polSourceObservationIssueNew.PolSourceObservationIssueID, LogCommandEnum.Add, polSourceObservationIssueNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            if (polSourceObservationIssueNew.Ordinal == 0)
            {
                PolSourceObservationIssue polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues
                                                                            where c.PolSourceObservationID == polSourceObservationIssueNew.PolSourceObservationID
                                                                            orderby c.Ordinal
                                                                            select c).FirstOrDefault();

                PolSourceSite polSourceSite = (from pso in db.PolSourceObservations
                                               from pss in db.PolSourceSites
                                               where pso.PolSourceSiteID == pss.PolSourceSiteID
                                               && pso.PolSourceObservationID == polSourceObservationIssueFirst.PolSourceObservationID
                                               select pss).FirstOrDefault();

                if (polSourceSite == null)
                    return ReturnError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.PolSourceSite));

                List<string> polSourceObsInfoList = polSourceObservationIssueFirst.ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                List<int> polSourceObsInfoIntList = polSourceObsInfoList.Select(c => int.Parse(c)).ToList();

                // doing the other language
                foreach (LanguageEnum lang in LanguageListAllowable)
                {
                    TVItemService tvItemService = new TVItemService(lang, User);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

                    string TVText = "";
                    for (int i = 0, count = polSourceObsInfoList.Count; i < count; i++)
                    {
                        string StartTxt = polSourceObsInfoList[i].Substring(0, 3);

                        if (startWithList.Where(c => c.StartsWith(StartTxt)).Any())
                        {
                            TVText = TVText.Trim();
                            string TempText = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(polSourceObsInfoList[i]));
                            if (TempText.IndexOf("|") > 0)
                            {
                                TempText = TempText.Substring(0, TempText.IndexOf("|")).Trim();
                            }
                            TVText = TVText + (TVText.Length == 0 ? "" : ", ") + TempText;
                        }
                    }

                    bool WellFormed = IssueWellFormed(polSourceObsInfoIntList, polSourceObsInfoChildList);
                    bool Completed = IssueCompleted(polSourceObsInfoIntList, polSourceObsInfoChildList);

                    string NC = (WellFormed == false || Completed == false ? " (NC) - " : "");
                    if (lang == LanguageEnum.fr)
                    {
                        NC = NC.Replace("NC", "PC");
                    }

                    TVText = "P00000".Substring(0, "P00000".Length - polSourceSite.Site.ToString().Length) + polSourceSite.Site.ToString() + " - " + NC + TVText;

                    TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
                    tvItemLanguageModel.Language = lang;

                    bool Found = true;
                    while (Found)
                    {
                        if (TVText.Contains("  "))
                        {
                            TVText = TVText.Replace("  ", " ");
                        }
                        else
                        {
                            Found = false;
                        }
                    }

                    tvItemLanguageModel.TVText = TVText;
                    tvItemLanguageModel.TVItemID = polSourceSite.PolSourceSiteTVItemID;

                    TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                    if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                        return ReturnError(tvItemLanguageModelRet.Error);

                    Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
                }
            }

            return GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(polSourceObservationIssueNew.PolSourceObservationIssueID);
        }
        public PolSourceObservationIssueModel PostDeletePolSourceObservationIssueDB(int PolSourceObservationIssueID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceObservationIssue polSourceObservationIssueToDelete = GetPolSourceObservationIssueWithPolSourceObservationIssueIDDB(PolSourceObservationIssueID);
            if (polSourceObservationIssueToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceObservationIssue));

            List<PolSourceObservationIssueModel> PolSourceObservationIssueModelList = GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(polSourceObservationIssueToDelete.PolSourceObservationID);
            if (PolSourceObservationIssueModelList.Count == 1)
                return ReturnError(ServiceRes.ShouldNotDeleteTheLastIssue);

            int PolSourceObservationID = polSourceObservationIssueToDelete.PolSourceObservationID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceObservationIssues.Remove(polSourceObservationIssueToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceObservationIssues", polSourceObservationIssueToDelete.PolSourceObservationIssueID, LogCommandEnum.Delete, polSourceObservationIssueToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            PolSourceObservationIssue polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues
                                                                        where c.PolSourceObservationID == PolSourceObservationID
                                                                        orderby c.Ordinal
                                                                        select c).FirstOrDefault();

            if (polSourceObservationIssueFirst != null)
            {
                PolSourceSite polSourceSite = (from pso in db.PolSourceObservations
                                               from pss in db.PolSourceSites
                                               where pso.PolSourceSiteID == pss.PolSourceSiteID
                                               && pso.PolSourceObservationID == polSourceObservationIssueFirst.PolSourceObservationID
                                               select pss).FirstOrDefault();

                if (polSourceSite == null)
                    return ReturnError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.PolSourceSite));

                List<string> polSourceObsInfoList = polSourceObservationIssueFirst.ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                List<int> polSourceObsInfoIntList = polSourceObsInfoList.Select(c => int.Parse(c)).ToList();

                // doing the other language
                foreach (LanguageEnum lang in LanguageListAllowable)
                {
                    TVItemService tvItemService = new TVItemService(lang, User);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

                    string TVText = "";
                    for (int i = 0, count = polSourceObsInfoList.Count; i < count; i++)
                    {
                        string StartTxt = polSourceObsInfoList[i].Substring(0, 3);

                        if (startWithList.Where(c => c.StartsWith(StartTxt)).Any())
                        {
                            TVText = TVText.Trim();
                            string TempText = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(polSourceObsInfoList[i]));
                            if (TempText.IndexOf("|") > 0)
                            {
                                TempText = TempText.Substring(0, TempText.IndexOf("|")).Trim();
                            }
                            TVText = TVText + (TVText.Length == 0 ? "" : ", ") + TempText;
                        }
                    }

                    bool WellFormed = IssueWellFormed(polSourceObsInfoIntList, polSourceObsInfoChildList);
                    bool Completed = IssueCompleted(polSourceObsInfoIntList, polSourceObsInfoChildList);

                    string NC = (WellFormed == false || Completed == false ? " (NC) - " : "");
                    if (lang == LanguageEnum.fr)
                    {
                        NC = NC.Replace("NC", "PC");
                    }

                    TVText = "P00000".Substring(0, "P00000".Length - polSourceSite.Site.ToString().Length) + polSourceSite.Site.ToString() + " - " + NC + TVText;

                    TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
                    tvItemLanguageModel.Language = lang;

                    bool Found = true;
                    while (Found)
                    {
                        if (TVText.Contains("  "))
                        {
                            TVText = TVText.Replace("  ", " ");
                        }
                        else
                        {
                            Found = false;
                        }
                    }

                    tvItemLanguageModel.TVText = TVText;
                    tvItemLanguageModel.TVItemID = polSourceSite.PolSourceSiteTVItemID;

                    TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                    if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                        return ReturnError(tvItemLanguageModelRet.Error);

                    Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
                }
            }

            return ReturnError("");
        }
        public PolSourceObservationIssueModel PostPolSourceObservationIssueMoveDownDB(int PolSourceObservationIssueID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceObservationIssueModel polSourceObservationIssueModelToMoveDown = GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(PolSourceObservationIssueID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelToMoveDown.Error))
                return ReturnError(polSourceObservationIssueModelToMoveDown.Error);

            PolSourceObservationIssueModel polSourceObservationIssueModelToMoveUp = GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(polSourceObservationIssueModelToMoveDown.PolSourceObservationID).Where(c => c.Ordinal > polSourceObservationIssueModelToMoveDown.Ordinal).OrderBy(c => c.Ordinal).FirstOrDefault();
            if (polSourceObservationIssueModelToMoveUp == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.PolSourceObservationIssue));

            int tempOrdinal = polSourceObservationIssueModelToMoveDown.Ordinal;
            polSourceObservationIssueModelToMoveDown.Ordinal = polSourceObservationIssueModelToMoveUp.Ordinal;
            polSourceObservationIssueModelToMoveUp.Ordinal = tempOrdinal;


            using (TransactionScope ts = new TransactionScope())
            {
                PolSourceObservationIssueModel polSourceObservationIssueModelRet = PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelToMoveDown);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                    return ReturnError(polSourceObservationIssueModelRet.Error);

                polSourceObservationIssueModelRet = PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelToMoveUp);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                    return ReturnError(polSourceObservationIssueModelRet.Error);

                ts.Complete();
            }

            PolSourceObservationIssue polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues
                                                                        where c.PolSourceObservationID == polSourceObservationIssueModelToMoveDown.PolSourceObservationID
                                                                        orderby c.Ordinal
                                                                        select c).FirstOrDefault();

            PolSourceSite polSourceSite = (from pso in db.PolSourceObservations
                                           from pss in db.PolSourceSites
                                           where pso.PolSourceSiteID == pss.PolSourceSiteID
                                           && pso.PolSourceObservationID == polSourceObservationIssueFirst.PolSourceObservationID
                                           select pss).FirstOrDefault();

            if (polSourceSite == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.PolSourceSite));

            List<string> polSourceObsInfoList = polSourceObservationIssueFirst.ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> polSourceObsInfoIntList = polSourceObsInfoList.Select(c => int.Parse(c)).ToList();

            // doing the other language
            foreach (LanguageEnum lang in LanguageListAllowable)
            {
                TVItemService tvItemService = new TVItemService(lang, User);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

                string TVText = "";
                for (int i = 0, count = polSourceObsInfoList.Count; i < count; i++)
                {
                    string StartTxt = polSourceObsInfoList[i].Substring(0, 3);

                    if (startWithList.Where(c => c.StartsWith(StartTxt)).Any())
                    {
                        TVText = TVText.Trim();
                        string TempText = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(polSourceObsInfoList[i]));
                        if (TempText.IndexOf("|") > 0)
                        {
                            TempText = TempText.Substring(0, TempText.IndexOf("|")).Trim();
                        }
                        TVText = TVText + (TVText.Length == 0 ? "" : ", ") + TempText;
                    }
                }

                bool WellFormed = IssueWellFormed(polSourceObsInfoIntList, polSourceObsInfoChildList);
                bool Completed = IssueCompleted(polSourceObsInfoIntList, polSourceObsInfoChildList);

                string NC = (WellFormed == false || Completed == false ? " (NC) - " : "");
                if (lang == LanguageEnum.fr)
                {
                    NC = NC.Replace("NC", "PC");
                }

                TVText = "P00000".Substring(0, "P00000".Length - polSourceSite.Site.ToString().Length) + polSourceSite.Site.ToString() + " - " + NC + TVText;

                TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
                tvItemLanguageModel.Language = lang;

                bool Found = true;
                while (Found)
                {
                    if (TVText.Contains("  "))
                    {
                        TVText = TVText.Replace("  ", " ");
                    }
                    else
                    {
                        Found = false;
                    }
                }

                tvItemLanguageModel.TVText = TVText;
                tvItemLanguageModel.TVItemID = polSourceSite.PolSourceSiteTVItemID;

                TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                    return ReturnError(tvItemLanguageModelRet.Error);

                Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
            }


            return ReturnError("");
        }
        public PolSourceObservationIssueModel PostPolSourceObservationIssueMoveUpDB(int PolSourceObservationIssueID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceObservationIssueModel polSourceObservationIssueModelToMoveUp = GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(PolSourceObservationIssueID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelToMoveUp.Error))
                return ReturnError(polSourceObservationIssueModelToMoveUp.Error);

            PolSourceObservationIssueModel polSourceObservationIssueModelToMoveDown = GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(polSourceObservationIssueModelToMoveUp.PolSourceObservationID).Where(c => c.Ordinal < polSourceObservationIssueModelToMoveUp.Ordinal).OrderByDescending(c => c.Ordinal).FirstOrDefault();
            if (polSourceObservationIssueModelToMoveDown == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.PolSourceObservationIssue));

            int tempOrdinal = polSourceObservationIssueModelToMoveUp.Ordinal;
            polSourceObservationIssueModelToMoveUp.Ordinal = polSourceObservationIssueModelToMoveDown.Ordinal;
            polSourceObservationIssueModelToMoveDown.Ordinal = tempOrdinal;

            using (TransactionScope ts = new TransactionScope())
            {
                PolSourceObservationIssueModel polSourceObservationIssueModelRet = PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelToMoveUp);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                    return ReturnError(polSourceObservationIssueModelRet.Error);

                polSourceObservationIssueModelRet = PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelToMoveDown);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                    return ReturnError(polSourceObservationIssueModelRet.Error);

                ts.Complete();
            }

            PolSourceObservationIssue polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues
                                                                        where c.PolSourceObservationID == polSourceObservationIssueModelToMoveDown.PolSourceObservationID
                                                                        orderby c.Ordinal
                                                                        select c).FirstOrDefault();

            PolSourceSite polSourceSite = (from pso in db.PolSourceObservations
                                           from pss in db.PolSourceSites
                                           where pso.PolSourceSiteID == pss.PolSourceSiteID
                                           && pso.PolSourceObservationID == polSourceObservationIssueFirst.PolSourceObservationID
                                           select pss).FirstOrDefault();

            if (polSourceSite == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.PolSourceSite));

            List<string> polSourceObsInfoList = polSourceObservationIssueFirst.ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> polSourceObsInfoIntList = polSourceObsInfoList.Select(c => int.Parse(c)).ToList();

            // doing the other language
            foreach (LanguageEnum lang in LanguageListAllowable)
            {
                TVItemService tvItemService = new TVItemService(lang, User);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

                string TVText = "";
                for (int i = 0, count = polSourceObsInfoList.Count; i < count; i++)
                {
                    string StartTxt = polSourceObsInfoList[i].Substring(0, 3);

                    if (startWithList.Where(c => c.StartsWith(StartTxt)).Any())
                    {
                        TVText = TVText.Trim();
                        string TempText = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(polSourceObsInfoList[i]));
                        if (TempText.IndexOf("|") > 0)
                        {
                            TempText = TempText.Substring(0, TempText.IndexOf("|")).Trim();
                        }
                        TVText = TVText + (TVText.Length == 0 ? "" : ", ") + TempText;
                    }
                }

                bool WellFormed = IssueWellFormed(polSourceObsInfoIntList, polSourceObsInfoChildList);
                bool Completed = IssueCompleted(polSourceObsInfoIntList, polSourceObsInfoChildList);

                string NC = (WellFormed == false || Completed == false ? " (NC) - " : "");
                if (lang == LanguageEnum.fr)
                {
                    NC = NC.Replace("NC", "PC");
                }

                TVText = "P00000".Substring(0, "P00000".Length - polSourceSite.Site.ToString().Length) + polSourceSite.Site.ToString() + " - " + NC + TVText;

                TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
                tvItemLanguageModel.Language = lang;

                bool Found = true;
                while (Found)
                {
                    if (TVText.Contains("  "))
                    {
                        TVText = TVText.Replace("  ", " ");
                    }
                    else
                    {
                        Found = false;
                    }
                }

                tvItemLanguageModel.TVText = TVText;
                tvItemLanguageModel.TVItemID = polSourceSite.PolSourceSiteTVItemID;

                TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                    return ReturnError(tvItemLanguageModelRet.Error);

                Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
            }

            return ReturnError("");
        }
        public PolSourceObservationIssueModel PostUpdatePolSourceObservationIssueDB(PolSourceObservationIssueModel polSourceObservationIssueModel)
        {
            string retStr = PolSourceObservationIssueModelOK(polSourceObservationIssueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceObservationIssue polSourceObservationIssueToUpdate = GetPolSourceObservationIssueWithPolSourceObservationIssueIDDB(polSourceObservationIssueModel.PolSourceObservationIssueID);
            if (polSourceObservationIssueToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.PolSourceObservationIssue));

            retStr = FillPolSourceObservationIssue(polSourceObservationIssueToUpdate, polSourceObservationIssueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceObservationIssues", polSourceObservationIssueToUpdate.PolSourceObservationIssueID, LogCommandEnum.Change, polSourceObservationIssueToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            if (polSourceObservationIssueToUpdate.Ordinal == 0)
            {
                PolSourceObservationIssue polSourceObservationIssueFirst = (from c in db.PolSourceObservationIssues
                                                                            where c.PolSourceObservationID == polSourceObservationIssueToUpdate.PolSourceObservationID
                                                                            orderby c.Ordinal
                                                                            select c).FirstOrDefault();

                PolSourceSite polSourceSite = (from pso in db.PolSourceObservations
                                               from pss in db.PolSourceSites
                                               where pso.PolSourceSiteID == pss.PolSourceSiteID
                                               && pso.PolSourceObservationID == polSourceObservationIssueFirst.PolSourceObservationID
                                               select pss).FirstOrDefault();

                if (polSourceSite == null)
                    return ReturnError(string.Format(ServiceRes.CouldNotFind_, ServiceRes.PolSourceSite));

                List<string> polSourceObsInfoList = polSourceObservationIssueFirst.ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                List<int> polSourceObsInfoIntList = polSourceObsInfoList.Select(c => int.Parse(c)).ToList();

                // doing the other language
                foreach (LanguageEnum lang in LanguageListAllowable)
                {
                    TVItemService tvItemService = new TVItemService(lang, User);
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

                    string TVText = "";
                    for (int i = 0, count = polSourceObsInfoList.Count; i < count; i++)
                    {
                        string StartTxt = polSourceObsInfoList[i].Substring(0, 3);

                        if (startWithList.Where(c => c.StartsWith(StartTxt)).Any())
                        {
                            TVText = TVText.Trim();
                            string TempText = _BaseEnumService.GetEnumText_PolSourceObsInfoEnum((PolSourceObsInfoEnum)int.Parse(polSourceObsInfoList[i]));
                            if (TempText.IndexOf("|") > 0)
                            {
                                TempText = TempText.Substring(0, TempText.IndexOf("|")).Trim();
                            }
                            TVText = TVText + (TVText.Length == 0 ? "" : ", ") + TempText;
                        }
                    }

                    bool WellFormed = IssueWellFormed(polSourceObsInfoIntList, polSourceObsInfoChildList);
                    bool Completed = IssueCompleted(polSourceObsInfoIntList, polSourceObsInfoChildList);

                    string NC = (WellFormed == false || Completed == false ? " (NC) - " : "");
                    if (lang == LanguageEnum.fr)
                    {
                        NC = NC.Replace("NC", "PC");
                    }

                    TVText = "P00000".Substring(0, "P00000".Length - polSourceSite.Site.ToString().Length) + polSourceSite.Site.ToString() + " - " + NC + TVText;

                    TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
                    tvItemLanguageModel.Language = lang;

                    bool Found = true;
                    while (Found)
                    {
                        if (TVText.Contains("  "))
                        {
                            TVText = TVText.Replace("  ", " ");
                        }
                        else
                        {
                            Found = false;
                        }
                    }

                    tvItemLanguageModel.TVText = TVText;
                    tvItemLanguageModel.TVItemID = polSourceSite.PolSourceSiteTVItemID;

                    TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                    if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                        return ReturnError(tvItemLanguageModelRet.Error);

                    Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
                }
            }

            return GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(polSourceObservationIssueToUpdate.PolSourceObservationIssueID);
        }
        #endregion Functions public

        #region Functions private
        public bool IssueWellFormed(List<int> polSourceObsInfoIntList, List<PolSourceObsInfoChild> polSourceObsInfoChildList)
        {
            int ChildStart = 0;
            for (int i = 0, count = polSourceObsInfoIntList.Count - 2; i < count; i++)
            {
                if (ChildStart != 0)
                {
                    string obsEnum3Char = polSourceObsInfoIntList[i].ToString().Substring(0, 3);
                    string ChildStart3Char = ChildStart.ToString().Substring(0, 3);
                    if (obsEnum3Char != ChildStart3Char)
                    {
                        return false;
                    }
                }

                PolSourceObsInfoChild polSourceObsInfoChild = polSourceObsInfoChildList.Where(c => c.PolSourceObsInfo == ((PolSourceObsInfoEnum)polSourceObsInfoIntList[i])).FirstOrDefault<PolSourceObsInfoChild>();
                if (polSourceObsInfoChild != null)
                {
                    ChildStart = ((int)polSourceObsInfoChild.PolSourceObsInfoChildStart);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool IssueCompleted(List<int> polSourceObsInfoIntList, List<PolSourceObsInfoChild> polSourceObsInfoChildList)
        {

            if (polSourceObsInfoIntList.Count > 0)
            {
                int obsEnumIntLast = polSourceObsInfoIntList[polSourceObsInfoIntList.Count - 1];

                PolSourceObsInfoChild polSourceObsInfoChild = polSourceObsInfoChildList.Where(c => c.PolSourceObsInfo == ((PolSourceObsInfoEnum)obsEnumIntLast)).FirstOrDefault<PolSourceObsInfoChild>();
                if (polSourceObsInfoChild == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion Functions private
    }
}