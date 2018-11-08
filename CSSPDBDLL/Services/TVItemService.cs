using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class TVItemService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemLanguageService _TVItemLanguageService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TVItemService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemLanguageService = new TVItemLanguageService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
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

        // Check
        public string TVItemModelOK(TVItemModel tvItemModel)
        {
            string retStr = FieldCheckIfNotNullWithinRangeInt(tvItemModel.TVLevel, ServiceRes.TVLevel, 0, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(tvItemModel.TVPath, ServiceRes.TVPath, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(tvItemModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(tvItemModel.ParentID, ServiceRes.ParentID, 0, 1000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTVItem(TVItem tvItem, TVItemModel tvItemModel, ContactOK contactOK)
        {
            tvItem.TVLevel = tvItemModel.TVLevel;
            tvItem.TVPath = tvItemModel.TVPath;
            tvItem.TVType = (int)tvItemModel.TVType;
            tvItem.ParentID = tvItemModel.ParentID;
            tvItem.IsActive = tvItemModel.IsActive;
            tvItem.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tvItem.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tvItem.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public List<TVItemModel> GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(int TVItemID, TVTypeEnum TVType)
        {
            TVItemModel currentTVItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(currentTVItemModel.Error))
                return new List<TVItemModel>() { new TVItemModel() { Error = currentTVItemModel.Error } };

            List<TVItemModel> tvItemModelList = (from c in db.TVItems
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                 where c.TVPath.StartsWith(currentTVItemModel.TVPath + "p")
                                                 && c.TVType == (int)TVType
                                                 orderby tvText
                                                 select new TVItemModel
                                                 {
                                                     Error = "",
                                                     TVItemID = c.TVItemID,
                                                     IsActive = c.IsActive,
                                                     ParentID = c.ParentID,
                                                     TVLevel = c.TVLevel,
                                                     TVPath = c.TVPath,
                                                     TVType = (TVTypeEnum)c.TVType,
                                                     TVText = tvText,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                 }).ToList<TVItemModel>();


            return tvItemModelList;
        }
        public List<TVItemModelAndChildCount> GetChildrenTVItemModelAndChildCountListWithTVItemIDAndTVTypeDB(int TVItemID, TVTypeEnum TVType)
        {
            TVItemModel currentTVItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(currentTVItemModel.Error))
                return new List<TVItemModelAndChildCount>() { new TVItemModelAndChildCount() { Error = currentTVItemModel.Error } };

            List<TVItemModelAndChildCount> tvItemModelAndChildCountList = (from c in db.TVItems
                                                                           let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                                           let childCount = (from cc in db.TVItemStats where cc.TVItemID == c.TVItemID select cc.ChildCount).DefaultIfEmpty().Sum()
                                                                           where c.TVPath.StartsWith(currentTVItemModel.TVPath + "p")
                                                                           && c.TVType == (int)TVType
                                                                           orderby tvText
                                                                           select new TVItemModelAndChildCount
                                                                           {
                                                                               Error = "",
                                                                               TVItemID = c.TVItemID,
                                                                               IsActive = c.IsActive,
                                                                               ParentID = c.ParentID,
                                                                               TVLevel = c.TVLevel,
                                                                               TVPath = c.TVPath,
                                                                               TVType = (TVTypeEnum)c.TVType,
                                                                               TVText = tvText,
                                                                               ChildCount = ((TVType == TVTypeEnum.MWQMSite || TVType == TVTypeEnum.MWQMRun) ? childCount / 2 : childCount),
                                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                                           }).ToList<TVItemModelAndChildCount>();

            if (tvItemModelAndChildCountList.Count > 0)
            {
                ContactModel contactModel = GetContactLoggedInDB();

                TVItemService tvItemService = new TVItemService(LanguageRequest, User);
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, User);
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, User);

                List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModelList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelListWithContactTVItemIDDB(contactModel.ContactTVItemID);

                List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelListWithContactTVItemIDDB(contactModel.ContactTVItemID);

                foreach (TVItemModelAndChildCount tvItemModelAndChildCount in tvItemModelAndChildCountList)
                {
                    TVAuthEnum tvAuth = TVAuthEnum.Error;

                    int TVLevelCurrent = tvItemModelAndChildCount.TVLevel;
                    string TVPathType = tvItemService.tvTypeNamesAndPathList.Where(c => c.Index == (int)tvItemModelAndChildCount.TVType).FirstOrDefault().TVPath;

                    foreach (TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel in tvTypeUserAuthorizationModelList)
                    {
                        if (TVPathType.Length >= tvTypeUserAuthorizationModel.TVPath.Length)
                        {
                            if (TVPathType.StartsWith(tvTypeUserAuthorizationModel.TVPath))
                            {
                                tvAuth = tvTypeUserAuthorizationModel.TVAuth;
                            }
                        }
                    }

                    foreach (TVItemUserAuthorizationModel tvItemUserAuthorizationModel in tvItemUserAuthorizationModelList)
                    {
                        if (tvItemModelAndChildCount.TVPath.Length >= tvItemUserAuthorizationModel.TVPath1.Length)
                        {
                            if (tvItemModelAndChildCount.TVPath.StartsWith(tvItemUserAuthorizationModel.TVPath1))
                            {
                                tvAuth = tvItemUserAuthorizationModel.TVAuth;
                            }
                        }
                    }
                    tvItemModelAndChildCount.TVAuth = tvAuth;
                }
            }

            return tvItemModelAndChildCountList;
        }
        public List<TVItemModelAndChildCount> GetChildrenTVItemModelAndChildCountListWithTVItemIDAndTVTypeOnlyOneLevelDownDB(int TVItemID, TVTypeEnum TVType)
        {
            TVItemModel currentTVItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(currentTVItemModel.Error))
                return new List<TVItemModelAndChildCount>() { new TVItemModelAndChildCount() { Error = currentTVItemModel.Error } };

            List<TVItemModelAndChildCount> tvItemModelAndChildCountList = (from c in db.TVItems
                                                                           let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                                           let childCount = (from cc in db.TVItemStats where cc.TVItemID == c.TVItemID select cc.ChildCount).DefaultIfEmpty().Sum()
                                                                           where c.TVPath.StartsWith(currentTVItemModel.TVPath + "p")
                                                                           && c.TVType == (int)TVType
                                                                           && c.TVLevel == currentTVItemModel.TVLevel + 1
                                                                           orderby tvText
                                                                           select new TVItemModelAndChildCount
                                                                           {
                                                                               Error = "",
                                                                               TVItemID = c.TVItemID,
                                                                               IsActive = c.IsActive,
                                                                               ParentID = c.ParentID,
                                                                               TVLevel = c.TVLevel,
                                                                               TVPath = c.TVPath,
                                                                               TVType = (TVTypeEnum)c.TVType,
                                                                               TVText = tvText,
                                                                               ChildCount = ((TVType == TVTypeEnum.MWQMSite || TVType == TVTypeEnum.MWQMRun) ? childCount / 2 : childCount),
                                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                                           }).ToList<TVItemModelAndChildCount>();

            if (tvItemModelAndChildCountList.Count > 0)
            {
                ContactModel contactModel = GetContactLoggedInDB();

                TVItemService tvItemService = new TVItemService(LanguageRequest, User);
                TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, User);
                TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, User);

                List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModelList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelListWithContactTVItemIDDB(contactModel.ContactTVItemID);

                List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelListWithContactTVItemIDDB(contactModel.ContactTVItemID);

                foreach (TVItemModelAndChildCount tvItemModelAndChildCount in tvItemModelAndChildCountList)
                {
                    TVAuthEnum tvAuth = TVAuthEnum.Error;

                    int TVLevelCurrent = tvItemModelAndChildCount.TVLevel;
                    string TVPathType = tvItemService.tvTypeNamesAndPathList.Where(c => c.Index == (int)tvItemModelAndChildCount.TVType).FirstOrDefault().TVPath;

                    foreach (TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel in tvTypeUserAuthorizationModelList)
                    {
                        if (TVPathType.Length >= tvTypeUserAuthorizationModel.TVPath.Length)
                        {
                            if (TVPathType.StartsWith(tvTypeUserAuthorizationModel.TVPath))
                            {
                                tvAuth = tvTypeUserAuthorizationModel.TVAuth;
                            }
                        }
                    }

                    foreach (TVItemUserAuthorizationModel tvItemUserAuthorizationModel in tvItemUserAuthorizationModelList)
                    {
                        if (tvItemModelAndChildCount.TVPath.Length >= tvItemUserAuthorizationModel.TVPath1.Length)
                        {
                            if (tvItemModelAndChildCount.TVPath.StartsWith(tvItemUserAuthorizationModel.TVPath1))
                            {
                                tvAuth = tvItemUserAuthorizationModel.TVAuth;
                            }
                        }
                    }
                    tvItemModelAndChildCount.TVAuth = tvAuth;
                }
            }

            return tvItemModelAndChildCountList;
        }
        public TVItemModel GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(int ParentID, string TVText, TVTypeEnum TVType)
        {
            TVItemModel tvItemModel = (from c in db.TVItems
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                       where c.ParentID == ParentID
                                       && tvText == TVText
                                       && c.TVType == (int)TVType
                                       select new TVItemModel
                                       {
                                           Error = "",
                                           TVItemID = c.TVItemID,
                                           IsActive = c.IsActive,
                                           ParentID = c.ParentID,
                                           TVLevel = c.TVLevel,
                                           TVPath = c.TVPath,
                                           TVType = (TVTypeEnum)c.TVType,
                                           TVText = tvText,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                       }).FirstOrDefault<TVItemModel>();

            if (tvItemModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.ParentID + "," + ServiceRes.TVText + "," + ServiceRes.TVType, ParentID + "," + TVText + "," + TVType));

            return tvItemModel;
        }
        public TVItemModel GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(int TVItemID, string TVText, TVTypeEnum TVType)
        {
            TVItemModel currentTVItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(currentTVItemModel.Error))
                return new TVItemModel() { Error = currentTVItemModel.Error };

            TVItemModel tvItemModel = (from c in db.TVItems
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                       where c.TVPath.StartsWith(currentTVItemModel.TVPath + "p")
                                       && tvText.StartsWith(TVText)
                                       && c.TVType == (int)TVType
                                       select new TVItemModel
                                       {
                                           Error = "",
                                           TVItemID = c.TVItemID,
                                           IsActive = c.IsActive,
                                           ParentID = c.ParentID,
                                           TVLevel = c.TVLevel,
                                           TVPath = c.TVPath,
                                           TVType = (TVTypeEnum)c.TVType,
                                           TVText = tvText,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                       }).FirstOrDefault<TVItemModel>();

            if (tvItemModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID + "," + ServiceRes.TVText + "," + ServiceRes.TVType, TVItemID.ToString() + "," + TVText + "," + TVType.ToString()));

            return tvItemModel;
        }
        private List<FilePurposeEnum> GetFilePurposeFromSearchTag(SearchTagEnum searchTag)
        {
            switch (searchTag)
            {
                case SearchTagEnum.fi:
                    return new List<FilePurposeEnum>() { FilePurposeEnum.Image };
                case SearchTagEnum.fp:
                    return new List<FilePurposeEnum>() { FilePurposeEnum.Picture };
                case SearchTagEnum.frg:
                    return new List<FilePurposeEnum>() { FilePurposeEnum.ReportGenerated };
                case SearchTagEnum.ftg:
                    return new List<FilePurposeEnum>() { FilePurposeEnum.TemplateGenerated };
                case SearchTagEnum.fmike:
                    return new List<FilePurposeEnum>() { FilePurposeEnum.MikeInput, FilePurposeEnum.MikeInputMDF, FilePurposeEnum.MikeResultDFSU, FilePurposeEnum.MikeResultKMZ };
                default:
                    return new List<FilePurposeEnum>();
            }
        }
        private List<FileTypeEnum> GetFileTypeFromSearchTag(SearchTagEnum searchTag)
        {
            switch (searchTag)
            {
                case SearchTagEnum.fpdf:
                    return new List<FileTypeEnum>() { FileTypeEnum.PDF };
                case SearchTagEnum.fdocx:
                    return new List<FileTypeEnum>() { FileTypeEnum.DOCX };
                case SearchTagEnum.fxlsx:
                    return new List<FileTypeEnum>() { FileTypeEnum.XLSX };
                case SearchTagEnum.fkmz:
                    return new List<FileTypeEnum>() { FileTypeEnum.KMZ };
                case SearchTagEnum.fxyz:
                    return new List<FileTypeEnum>() { FileTypeEnum.XYZ };
                case SearchTagEnum.fdfs:
                    return new List<FileTypeEnum>() { FileTypeEnum.DFS0, FileTypeEnum.DFS1, FileTypeEnum.DFSU };
                case SearchTagEnum.fmdf:
                    return new List<FileTypeEnum>() { FileTypeEnum.MDF };
                case SearchTagEnum.fm21fm:
                    return new List<FileTypeEnum>() { FileTypeEnum.M21FM };
                case SearchTagEnum.fm3fm:
                    return new List<FileTypeEnum>() { FileTypeEnum.M3FM };
                case SearchTagEnum.fmesh:
                    return new List<FileTypeEnum>() { FileTypeEnum.MESH };
                case SearchTagEnum.flog:
                    return new List<FileTypeEnum>() { FileTypeEnum.LOG };
                case SearchTagEnum.ftxt:
                    return new List<FileTypeEnum>() { FileTypeEnum.TXT };
                case SearchTagEnum.fcsv:
                    return new List<FileTypeEnum>() { FileTypeEnum.CSV };
                default:
                    return new List<FileTypeEnum>();
            }
        }
        public List<TVItemModel> GetParentTVItemModelListWithTVItemIDForActivityDB(int TVItemID)
        {
            TVItemModel currentTVItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(currentTVItemModel.Error))
                return new List<TVItemModel>() { new TVItemModel() { Error = currentTVItemModel.Error } };

            List<int> ParentTVItemIDList = GetParentsTVItemIDList(GetParentTVPath(currentTVItemModel.TVPath));
            if (ParentTVItemIDList.Count == 0)
                return new List<TVItemModel>();

            List<TVItemModel> tvItemModelList = (from c in db.TVItems
                                                 from p in ParentTVItemIDList
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                 where c.TVItemID == p
                                                 orderby c.TVLevel
                                                 select new TVItemModel
                                                 {
                                                     Error = "",
                                                     TVItemID = c.TVItemID,
                                                     IsActive = c.IsActive,
                                                     ParentID = c.ParentID,
                                                     TVLevel = c.TVLevel,
                                                     TVPath = c.TVPath,
                                                     TVType = (TVTypeEnum)c.TVType,
                                                     TVText = tvText,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                 }).ToList<TVItemModel>();

            if (tvItemModelList.Count > 0)
            {
                tvItemModelList[0].TVText = ServiceRes.AllActivities;
            }

            return tvItemModelList;
        }
        public List<TVItemModel> GetParentTVItemModelListWithTVItemIDForLocationDB(int TVItemID)
        {
            TVItemModel currentTVItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);

            if (!string.IsNullOrWhiteSpace(currentTVItemModel.Error))
                return new List<TVItemModel>() { new TVItemModel() { Error = currentTVItemModel.Error } };

            List<int> ParentTVItemIDList = GetParentsTVItemIDList(GetParentTVPath(currentTVItemModel.TVPath));

            if (ParentTVItemIDList.Count == 0)
                return new List<TVItemModel>();

            List<TVItemModel> tvItemModelList = (from c in db.TVItems
                                                 from p in ParentTVItemIDList
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                 where c.TVItemID == p
                                                 orderby c.TVLevel
                                                 select new TVItemModel
                                                 {
                                                     Error = "",
                                                     TVItemID = c.TVItemID,
                                                     IsActive = c.IsActive,
                                                     ParentID = c.ParentID,
                                                     TVLevel = c.TVLevel,
                                                     TVPath = c.TVPath,
                                                     TVType = (TVTypeEnum)c.TVType,
                                                     TVText = tvText,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                 }).ToList<TVItemModel>();

            if (tvItemModelList.Count > 0)
            {
                tvItemModelList[0].TVText = ServiceRes.AllLocations;
            }

            return tvItemModelList;
        }
        public TVItemModel GetParentTVItemModelWithTVItemIDForActivityDB(int TVItemID)
        {
            if (TVItemID == 1)
                return ReturnError(ServiceRes.RootTVItemDoesNotHaveParentTVItem);

            TVItemModel tvItemModel = (from c in db.TVItems
                                       from cp in db.TVItems
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == cp.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                       where c.ParentID == cp.TVItemID
                                       && c.TVItemID == TVItemID
                                       select new TVItemModel
                                       {
                                           Error = "",
                                           TVItemID = cp.TVItemID,
                                           IsActive = cp.IsActive,
                                           ParentID = cp.ParentID,
                                           TVLevel = cp.TVLevel,
                                           TVPath = cp.TVPath,
                                           TVType = (TVTypeEnum)cp.TVType,
                                           TVText = tvText,
                                           LastUpdateDate_UTC = cp.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = cp.LastUpdateContactTVItemID
                                       }).FirstOrDefault<TVItemModel>();

            if (tvItemModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFindParent_WithChild_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, TVItemID));

            if (tvItemModel.TVItemID == 1) // root
                tvItemModel.TVText = ServiceRes.AllActivities;

            return tvItemModel;
        }
        public TVItemModel GetParentTVItemModelWithTVItemIDForLocationDB(int TVItemID)
        {
            if (TVItemID == 1)
                return ReturnError(ServiceRes.RootTVItemDoesNotHaveParentTVItem);

            TVItemModel tvItemModel = (from c in db.TVItems
                                       from cp in db.TVItems
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == cp.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                       where c.ParentID == cp.TVItemID
                                       && c.TVItemID == TVItemID
                                       select new TVItemModel
                                       {
                                           Error = "",
                                           TVItemID = cp.TVItemID,
                                           IsActive = cp.IsActive,
                                           ParentID = cp.ParentID,
                                           TVLevel = cp.TVLevel,
                                           TVPath = cp.TVPath,
                                           TVType = (TVTypeEnum)cp.TVType,
                                           TVText = tvText,
                                           LastUpdateDate_UTC = cp.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = cp.LastUpdateContactTVItemID
                                       }).FirstOrDefault<TVItemModel>();

            if (tvItemModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFindParent_WithChild_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, TVItemID));

            if (tvItemModel.TVItemID == 1) // root
                tvItemModel.TVText = ServiceRes.AllLocations;

            return tvItemModel;
        }
        public TVItemModel GetRootTVItemModelDB()
        {
            TVItemModel tvItemModel = (from c in db.TVItems
                                       let tvText = (from cl in db.TVItemLanguages
                                                     where cl.TVItemID == c.TVItemID
                                                     && cl.Language == (int)LanguageRequest
                                                     select cl.TVText).FirstOrDefault<string>()
                                       where c.TVLevel == 0
                                       select new TVItemModel
                                       {
                                           Error = "",
                                           TVItemID = c.TVItemID,
                                           IsActive = c.IsActive,
                                           ParentID = c.ParentID,
                                           TVLevel = c.TVLevel,
                                           TVPath = c.TVPath,
                                           TVType = (TVTypeEnum)c.TVType,
                                           TVText = tvText,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                       }).FirstOrDefault<TVItemModel>();

            if (tvItemModel == null)
                return ReturnError(ServiceRes.CouldNotFindRoot);

            if (tvItemModel.TVItemID == 1)
                tvItemModel.TVText = ServiceRes.AllLocations;

            return tvItemModel;
        }
        public SearchTagEnum GetSearchTag(string TagText)
        {
            switch (TagText)
            {
                case "c":
                    return SearchTagEnum.c;
                case "e":
                    return SearchTagEnum.e;
                case "t":
                    return SearchTagEnum.t;
                case "fi":
                    return SearchTagEnum.fi;
                case "fp":
                    return SearchTagEnum.fp;
                case "fr":
                    return SearchTagEnum.frg;
                case "fg":
                    return SearchTagEnum.ftg;
                case "fpdf":
                    return SearchTagEnum.fpdf;
                case "fdocx":
                    return SearchTagEnum.fdocx;
                case "fxlsx":
                    return SearchTagEnum.fxlsx;
                case "fkmz":
                    return SearchTagEnum.fkmz;
                case "fxyz":
                    return SearchTagEnum.fxyz;
                case "fdfs":
                    return SearchTagEnum.fdfs;
                case "fmike":
                    return SearchTagEnum.fmike;
                case "fmdf":
                    return SearchTagEnum.fmdf;
                case "fm21fm":
                    return SearchTagEnum.fm21fm;
                case "fm3fm":
                    return SearchTagEnum.fm3fm;
                case "fmesh":
                    return SearchTagEnum.fmesh;
                case "flog":
                    return SearchTagEnum.flog;
                case "ftxt":
                    return SearchTagEnum.ftxt;
                case "fcsv":
                    return SearchTagEnum.fcsv;
                case "m":
                    return SearchTagEnum.m;
                case "p":
                    return SearchTagEnum.p;
                case "ms":
                    return SearchTagEnum.ms;
                case "cs":
                    return SearchTagEnum.cs;
                case "hs":
                    return SearchTagEnum.hs;
                case "ts":
                    return SearchTagEnum.ts;
                case "ww":
                    return SearchTagEnum.ww;
                case "ls":
                    return SearchTagEnum.ls;
                case "st":
                    return SearchTagEnum.st;
                case "ps":
                    return SearchTagEnum.ps;
                case "a":
                    return SearchTagEnum.a;
                case "s":
                    return SearchTagEnum.s;
                case "ss":
                    return SearchTagEnum.ss;
                case "u":
                    return SearchTagEnum.u;
                default:
                    return SearchTagEnum.notag;
            }
        }
        public List<SearchTagAndTerms> GetSearchTagAndTermsList(string searchTerm)
        {
            List<SearchTagAndTerms> SearchTagAndTermsList = new List<SearchTagAndTerms>();

            string CurrentTerm = "";
            List<string> TermsList = new List<string>();
            SearchTagEnum SearchTag = SearchTagEnum.notag;

            for (int i = 0, count = searchTerm.Count(); i < count; i++)
            {
                if (searchTerm[i] == ":".ToCharArray()[0])
                {
                    if (!(SearchTag == SearchTagEnum.notag && TermsList.Count == 0))
                    {
                        SearchTagAndTermsList.Add(new SearchTagAndTerms() { SearchTag = SearchTag, SearchTermList = TermsList });
                    }
                    SearchTag = GetSearchTag(CurrentTerm);
                    if (i == count - 1)
                    {
                        if (SearchTag != SearchTagEnum.notag || CurrentTerm.Length > 0)
                        {
                            SearchTagAndTermsList.Add(new SearchTagAndTerms() { SearchTag = SearchTag, SearchTermList = TermsList });
                        }
                    }
                    CurrentTerm = "";
                    TermsList = new List<string>();
                }
                else if (searchTerm[i] == " ".ToCharArray()[0])
                {
                    if (CurrentTerm.Length > 0)
                    {
                        TermsList.Add(CurrentTerm);
                        if (i == count - 1)
                        {
                            SearchTagAndTermsList.Add(new SearchTagAndTerms() { SearchTag = SearchTag, SearchTermList = TermsList });
                        }
                        CurrentTerm = "";
                    }
                    if (i == count - 1)
                    {
                        if (SearchTag != SearchTagEnum.notag || CurrentTerm.Length > 0)
                        {
                            SearchTagAndTermsList.Add(new SearchTagAndTerms() { SearchTag = SearchTag, SearchTermList = TermsList });
                        }
                        else
                        {
                            if (TermsList.Count > 0)
                            {
                                SearchTagAndTermsList.Add(new SearchTagAndTerms() { SearchTag = SearchTag, SearchTermList = TermsList });
                            }
                        }
                    }
                }
                else
                {
                    CurrentTerm = CurrentTerm + searchTerm[i];
                    if (i == count - 1)
                    {
                        if (CurrentTerm.Length > 0)
                        {
                            TermsList.Add(CurrentTerm);
                            CurrentTerm = "";
                        }
                        SearchTagAndTermsList.Add(new SearchTagAndTerms() { SearchTag = SearchTag, SearchTermList = TermsList });
                    }
                }

            }

            return SearchTagAndTermsList;
        }
        public List<TVItemModel> GetSubTVItemModelWithFromTVItemIDAndToTVItemIDOfTVTypeDB(int FromTVItemID, int ToTVItemID, TVTypeEnum TVType)
        {
            IEnumerable<TVItemLink> tvItemLinkList = (from c in db.TVItemLinks
                                                      where c.FromTVItemID == FromTVItemID
                                                      && c.ToTVItemID == ToTVItemID
                                                      select c);

            IEnumerable<TVItemLink> tvItemLinkList2 = (from c in db.TVItemLinks
                                                       from t in tvItemLinkList
                                                       where c.ParentTVItemLinkID == t.TVItemLinkID
                                                       && c.FromTVItemID == ToTVItemID
                                                       && c.ToTVType == (int)TVType
                                                       select c);

            List<TVItemModel> tvItemModelList = (from c in db.TVItems
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                 from t in tvItemLinkList2
                                                 where c.TVItemID == t.ToTVItemID
                                                 select new TVItemModel
                                                 {
                                                     Error = "",
                                                     TVItemID = c.TVItemID,
                                                     IsActive = c.IsActive,
                                                     ParentID = c.ParentID,
                                                     TVLevel = c.TVLevel,
                                                     TVPath = c.TVPath,
                                                     TVType = (TVTypeEnum)c.TVType,
                                                     TVText = tvText,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                 }).ToList<TVItemModel>();

            return tvItemModelList;

        }
        public int GetTVItemModelCountDB()
        {
            return (from c in db.TVItems
                    select c).Count();
        }
        public int GetTVItemModelCountWithTVTypeDB(TVTypeEnum TVType)
        {
            return (from c in db.TVItems
                    where c.TVType == (int)TVType
                    select c).Count();
        }
        public List<TVItemModel> GetTVItemModelListWithTVItemIDListDB(List<int> TVItemIDList)
        {
            List<TVItemModel> tvItemModelList = (from c in db.TVItems
                                                 from l in TVItemIDList
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                 where c.TVItemID == l
                                                 orderby tvText
                                                 select new TVItemModel
                                                 {
                                                     Error = "",
                                                     TVItemID = c.TVItemID,
                                                     IsActive = c.IsActive,
                                                     ParentID = c.ParentID,
                                                     TVLevel = c.TVLevel,
                                                     TVPath = c.TVPath,
                                                     TVType = (TVTypeEnum)c.TVType,
                                                     TVText = tvText,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                 }).ToList<TVItemModel>();

            foreach (TVItemModel tvim in tvItemModelList)
            {
                if (tvim.TVItemID == 1)
                {
                    tvim.TVText = ServiceRes.AllLocations;
                }
            }

            return tvItemModelList;
        }
        public List<TVItemModel> GetTVItemModelListWithTVTypeDB(TVTypeEnum TVType)
        {
            List<TVItemModel> tvItemModelList = (from c in db.TVItems
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                 where c.TVType == (int)TVType
                                                 orderby tvText
                                                 select new TVItemModel
                                                 {
                                                     Error = "",
                                                     TVItemID = c.TVItemID,
                                                     IsActive = c.IsActive,
                                                     ParentID = c.ParentID,
                                                     TVLevel = c.TVLevel,
                                                     TVPath = c.TVPath,
                                                     TVType = (TVTypeEnum)c.TVType,
                                                     TVText = tvText,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                 }).ToList<TVItemModel>();

            foreach (TVItemModel tvim in tvItemModelList)
            {
                if (tvim.TVItemID == 1)
                {
                    tvim.TVText = ServiceRes.AllLocations;
                }
            }

            return tvItemModelList;
        }
        public List<TVItemModel> GetTVItemModelListContainingTVTextDB(int TVItemID, string SearchTerm)
        {
            SearchTerm = SearchTerm.Trim();

            if (SearchTerm == "")
                return new List<TVItemModel>();

            IEnumerable<TVItemModel> tvItemModelEnum = null;

            List<SearchTagAndTerms> SearchTagAndTermsList = GetSearchTagAndTermsList(SearchTerm);

            var tvItemEnum = (from c in db.TVItems select c);

            foreach (SearchTagAndTerms searchTagAndTerms in SearchTagAndTermsList)
            {
                TVTypeEnum? tvTypeEnum = GetTVTypeFromSearchTag(searchTagAndTerms.SearchTag);

                List<FileTypeEnum> fileTypeList = GetFileTypeFromSearchTag(searchTagAndTerms.SearchTag);

                List<FilePurposeEnum> filePurposeList = GetFilePurposeFromSearchTag(searchTagAndTerms.SearchTag);

                if (searchTagAndTerms.SearchTag == SearchTagEnum.u)
                {
                    if (searchTagAndTerms.SearchTermList.Count == 0)
                    {
                        if (SearchTagAndTermsList.Count == 1)
                        {
                            tvItemEnum = (from c in tvItemEnum
                                          from cl in db.TVItemLanguages
                                          where c.TVItemID == cl.TVItemID
                                          && cl.TVText.Contains("ShouldNotFindThisText")
                                          && cl.Language == (int)LanguageRequest
                                          select c);
                        }
                    }
                    else
                    {
                        tvItemEnum = (from c in tvItemEnum
                                      from cl in db.TVItemLanguages
                                      from st in searchTagAndTerms.SearchTermList
                                      where c.TVItemID == cl.TVItemID
                                      && cl.TVText.Contains(st)
                                      && cl.Language == (int)LanguageRequest
                                      select c);

                    }
                }
                else
                {
                    foreach (string s in searchTagAndTerms.SearchTermList)
                    {
                        tvItemEnum = (from c in tvItemEnum
                                      from cl in db.TVItemLanguages
                                      where c.TVItemID == cl.TVItemID
                                      && cl.TVText.Contains(s)
                                      && cl.Language == (int)LanguageRequest
                                      select c);
                    }

                    if (tvTypeEnum != null)
                    {
                        if (tvTypeEnum == TVTypeEnum.File)
                        {
                            tvItemEnum = (from c in tvItemEnum
                                          from f in db.TVFiles
                                          where c.TVItemID == f.TVFileTVItemID
                                          select c);

                            if (fileTypeList.Count > 0)
                            {
                                tvItemEnum = (from c in tvItemEnum
                                              from f in db.TVFiles
                                              where c.TVItemID == f.TVFileTVItemID
                                              && fileTypeList.Contains((FileTypeEnum)f.FileType)
                                              select c);
                            }

                            if (filePurposeList.Count > 0)
                            {
                                tvItemEnum = (from c in tvItemEnum
                                              from f in db.TVFiles
                                              where c.TVItemID == f.TVFileTVItemID
                                              && filePurposeList.Contains((FilePurposeEnum)f.FilePurpose)
                                              select c);
                            }
                        }
                        else
                        {
                            tvItemEnum = (from c in tvItemEnum
                                          where c.TVType == (int)tvTypeEnum
                                          select c);

                        }
                    }


                }
            }

            //List<SearchTagEnum> SearchTagWhereShouldGetParentList = new List<SearchTagEnum>()
            //{
            //    SearchTagEnum.fi, SearchTagEnum.fp, SearchTagEnum.fr, SearchTagEnum.fg, SearchTagEnum.fmike,
            //    SearchTagEnum.fpdf, SearchTagEnum.fdocx, SearchTagEnum.fxlsx, SearchTagEnum.fkmz,
            //    SearchTagEnum.fxyz,SearchTagEnum.fdfs, SearchTagEnum.fmdf, SearchTagEnum.fm21fm,
            //    SearchTagEnum.fm3fm, SearchTagEnum.fmesh, SearchTagEnum.flog, SearchTagEnum.ftxt
            //};
            //SearchTagAndTerms searchTagAndTermsFile = SearchTagAndTermsList.Where(c => SearchTagWhereShouldGetParentList.Contains(c.SearchTag)).FirstOrDefault();
            //if (searchTagAndTermsFile != null)
            //{
            //    IEnumerable<int> TVItemIDParentList = (from c in tvItemEnum
            //                                           select c.ParentID).Distinct();

            //    tvItemEnum = (from c in db.TVItems
            //                  from p in TVItemIDParentList
            //                  where c.TVItemID == p
            //                  select c);

            //}

            SearchTagAndTerms searchTagAndTermsUnder = SearchTagAndTermsList.Where(c => c.SearchTag == SearchTagEnum.u).FirstOrDefault();

            if (searchTagAndTermsUnder != null)
            {
                string TVPath = (from c in db.TVItems
                                 where c.TVItemID == TVItemID
                                 select c.TVPath).FirstOrDefault();

                if (string.IsNullOrWhiteSpace(TVPath))
                    TVPath = "p1";

                tvItemModelEnum = (from c in tvItemEnum
                                   from cl in db.TVItemLanguages
                                   where c.TVItemID == cl.TVItemID
                                   && c.TVPath.StartsWith(TVPath + "p")
                                   && cl.Language == (int)LanguageRequest
                                   select new TVItemModel
                                   {
                                       Error = "",
                                       TVItemID = c.TVItemID,
                                       IsActive = c.IsActive,
                                       ParentID = c.ParentID,
                                       TVLevel = c.TVLevel,
                                       TVPath = c.TVPath,
                                       TVType = (TVTypeEnum)c.TVType,
                                       TVText = cl.TVText,
                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                   });
            }
            else
            {
                tvItemModelEnum = (from c in tvItemEnum
                                   from cl in db.TVItemLanguages
                                   where c.TVItemID == cl.TVItemID
                                   && cl.Language == (int)LanguageRequest
                                   select new TVItemModel
                                   {
                                       Error = "",
                                       TVItemID = c.TVItemID,
                                       IsActive = c.IsActive,
                                       ParentID = c.ParentID,
                                       TVLevel = c.TVLevel,
                                       TVPath = c.TVPath,
                                       TVType = (TVTypeEnum)c.TVType,
                                       TVText = cl.TVText,
                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                   });
            }

            if (tvItemModelEnum == null)
                return new List<TVItemModel>();

            return tvItemModelEnum.Take(10).ToList();
        }
        public TVItemModel GetTVItemModelWithTVItemIDDB(int TVItemID)
        {
            TVItemModel tvItemModel = (from c in db.TVItems
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                       where c.TVItemID == TVItemID
                                       orderby tvText
                                       select new TVItemModel
                                       {
                                           Error = "",
                                           TVItemID = c.TVItemID,
                                           IsActive = c.IsActive,
                                           ParentID = c.ParentID,
                                           TVLevel = c.TVLevel,
                                           TVPath = c.TVPath,
                                           TVType = (TVTypeEnum)c.TVType,
                                           TVText = tvText,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                       }).FirstOrDefault<TVItemModel>();

            if (tvItemModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, TVItemID));

            if (TVItemID == 1)
                tvItemModel.TVText = ServiceRes.AllLocations;

            return tvItemModel;
        }
        public TVItem GetTVItemWithTVItemIDDB(int TVItemID)
        {
            TVItem tvItem = (from c in db.TVItems
                             where c.TVItemID == TVItemID
                             select c).FirstOrDefault<TVItem>();
            return tvItem;
        }
        private TVTypeEnum? GetTVTypeFromSearchTag(SearchTagEnum searchTag)
        {
            switch (searchTag)
            {
                case SearchTagEnum.c:
                    return TVTypeEnum.Contact;
                case SearchTagEnum.e:
                    return TVTypeEnum.Email;
                case SearchTagEnum.t:
                    return TVTypeEnum.Tel;
                case SearchTagEnum.fi:
                case SearchTagEnum.fp:
                case SearchTagEnum.frg:
                case SearchTagEnum.ftg:
                case SearchTagEnum.fpdf:
                case SearchTagEnum.fdocx:
                case SearchTagEnum.fxlsx:
                case SearchTagEnum.fkmz:
                case SearchTagEnum.fxyz:
                case SearchTagEnum.fdfs:
                case SearchTagEnum.fmike:
                case SearchTagEnum.fmdf:
                case SearchTagEnum.fm21fm:
                case SearchTagEnum.fm3fm:
                case SearchTagEnum.fmesh:
                case SearchTagEnum.flog:
                case SearchTagEnum.ftxt:
                    return TVTypeEnum.File;
                case SearchTagEnum.m:
                    return TVTypeEnum.Municipality;
                case SearchTagEnum.p:
                    return TVTypeEnum.Province;
                case SearchTagEnum.ms:
                    return TVTypeEnum.MikeScenario;
                case SearchTagEnum.cs:
                    return TVTypeEnum.ClimateSite;
                case SearchTagEnum.hs:
                    return TVTypeEnum.HydrometricSite;
                case SearchTagEnum.ts:
                    return TVTypeEnum.TideSite;
                case SearchTagEnum.ww:
                    return TVTypeEnum.Infrastructure;
                case SearchTagEnum.ls:
                    return TVTypeEnum.Infrastructure;
                case SearchTagEnum.st:
                    return TVTypeEnum.MWQMSite;
                case SearchTagEnum.ps:
                    return TVTypeEnum.PolSourceSite;
                case SearchTagEnum.a:
                    return TVTypeEnum.Area;
                case SearchTagEnum.s:
                    return TVTypeEnum.Sector;
                case SearchTagEnum.ss:
                    return TVTypeEnum.Subsector;
                case SearchTagEnum.u:
                case SearchTagEnum.notag:
                    return null;
                default:
                    return null;
            }
        }
        public List<TVTypeNamesAndPath> GetTVTypeNamesAndPathParentsWithTVType(string TVPath)
        {
            List<TVTypeNamesAndPath> tvTypeNameAndPathParentsList = new List<TVTypeNamesAndPath>();

            if (!TVPath.Contains("p1"))
                return new List<TVTypeNamesAndPath>();

            while (!string.IsNullOrWhiteSpace(TVPath))
            {
                foreach (TVTypeNamesAndPath tvTypeNamesAndPath in tvTypeNamesAndPathList)
                {
                    if (TVPath == tvTypeNamesAndPath.TVPath)
                    {
                        tvTypeNameAndPathParentsList.Insert(0, tvTypeNamesAndPath);
                        TVPath = GetParentTVPath(tvTypeNamesAndPath.TVPath);
                        break;
                    }
                }
            }

            return tvTypeNameAndPathParentsList;
        }

        // Helper
        public string CleanText(string txtToClean)
        {
            // got to make sure there are not \t, \r, \n, in the text
            txtToClean = txtToClean.Replace("/", "-").Replace("\t", " ").Replace("\r", " ").Replace("\n", " ").Replace("&", "AND").Replace("#", " ");

            // removing all double space
            for (int i = 0; i < 20; i++)
            {
                txtToClean = txtToClean.Replace("  ", " ");
            }

            return txtToClean.Trim();
        }
        public MapInfoModel CreateMapInfoObjectDB(List<Coord> coordList, MapInfoDrawTypeEnum mapInfoDrawType, TVTypeEnum TVType, int TVItemID)
        {
            MapInfoService mapInfoService = new MapInfoService(this.LanguageRequest, this.User);

            MapInfoModel mapInfoModel = mapInfoService.CreateMapInfoObjectDB(coordList, mapInfoDrawType, TVType, TVItemID);

            return mapInfoModel;
        }
        public List<Coord> GetCoordFromText(string MapInfoPointText)
        {
            List<Coord> coordList = new List<Coord>();

            List<string> stringList = MapInfoPointText.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            int count = 0;
            foreach (string s in stringList)
            {
                List<string> stringListVal = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();

                float Lat = 0.0f;
                float Lng = 0.0f;
                float.TryParse(stringListVal[0], out Lat);
                float.TryParse(stringListVal[1], out Lng);

                coordList.Add(new Coord() { Lat = Lat, Lng = Lng, Ordinal = count });

                count += 1;
            }

            return coordList;
        }
        public bool GetIsItSameObject(TVItemModel tvItemModel, TVItemModel tvItemModelExist)
        {
            bool IsSame = false;
            if (tvItemModel.TVItemID == tvItemModelExist.TVItemID)
            {
                IsSame = true;
            }

            return IsSame;
        }
        public int GetTVItemID(string TVPath)
        {
            int RetVal = -1; // will return -1 if an error occured or if there are no parent i.e. tvItem is root
            if (!string.IsNullOrWhiteSpace(TVPath))
            {
                string LastPart = TVPath.Substring(TVPath.LastIndexOf(@"p") + 1);
                if (!string.IsNullOrWhiteSpace(LastPart))
                {
                    RetVal = int.Parse(LastPart);
                }
            }

            return RetVal;
        }
        public int GetTVLevel(string TVPath)
        {
            int RetVal = -1; // will return -1 if an error occured or if there are no parent i.e. tvItem is root
            if (!string.IsNullOrWhiteSpace(TVPath))
            {
                string LastPart = TVPath.Substring(TVPath.LastIndexOf(@"p") + 1);
                if (!string.IsNullOrWhiteSpace(LastPart))
                {
                    RetVal = (from c in TVPath
                              where c == @"p".ToCharArray()[0]
                              select c).Count() - 1;
                }
            }

            return RetVal;
        }
        public int GetParentTVLevel(string TVPath)
        {
            int RetVal = -1; // will return -1 if an error occured or if there are no parent i.e. tvItem is root
            if (!string.IsNullOrWhiteSpace(TVPath))
            {
                if (TVPath.Contains(@"p"))
                {
                    string LastPart = TVPath.Substring(TVPath.LastIndexOf(@"p") + 1);
                    if (!string.IsNullOrWhiteSpace(LastPart))
                    {
                        RetVal = (from c in TVPath
                                  where c == @"p".ToCharArray()[0]
                                  select c).Count() - 2;
                    }
                }
            }

            return RetVal;
        }
        public int GetParentTVItemID(string TVPath)
        {
            int RetVal = -1; // will return -1 if an error occured or if there are no parent i.e. tvItem is root
            if (!string.IsNullOrWhiteSpace(TVPath))
            {
                string LastPart = TVPath.Substring(TVPath.LastIndexOf(@"p") + 1);
                if (!string.IsNullOrWhiteSpace(LastPart))
                {
                    string ChildPath = TVPath.Substring(0, TVPath.LastIndexOf(@"p"));
                    if (ChildPath.Contains(@"p"))
                    {
                        string LastPart2 = ChildPath.Substring(ChildPath.LastIndexOf(@"p") + 1);
                        if (!string.IsNullOrWhiteSpace(LastPart2))
                        {
                            RetVal = int.Parse(LastPart2);
                        }
                    }
                }
            }

            return RetVal;
        }
        public string GetParentTVPath(string TVPath)
        {
            string RetVal = ""; // will return "" if an error occured or if there are no parent i.e. tvItem is root
            if (!string.IsNullOrWhiteSpace(TVPath))
            {
                string LastPart = TVPath.Substring(TVPath.LastIndexOf(@"p") + 1);
                if (!string.IsNullOrWhiteSpace(LastPart))
                {
                    RetVal = TVPath.Substring(0, TVPath.LastIndexOf(@"p"));
                }
            }

            return RetVal;
        }
        public List<int> GetParentsTVItemIDList(string TVPath)
        {
            string[] TVItemIDArrStr = TVPath.Split("p".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<int> parentsTVItemIDList = new List<int>();
            foreach (string s in TVItemIDArrStr)
            {
                parentsTVItemIDList.Add(int.Parse(s));
            }

            if (parentsTVItemIDList.Count != GetTVLevel(TVPath) + 1)
            {
                return new List<int>();
            }

            return parentsTVItemIDList;
        }
        public List<TVItemModel> GetParentsTVItemModelList(string TVPath)
        {
            List<TVItemModel> tvItemModelList = new List<TVItemModel>();

            string[] TVItemIDArrStr = TVPath.Split("p".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<int> parentsTVItemIDList = new List<int>();
            foreach (string s in TVItemIDArrStr)
            {
                parentsTVItemIDList.Add(int.Parse(s));
            }

            if (parentsTVItemIDList.Count != GetTVLevel(TVPath) + 1)
            {
                return tvItemModelList.ToList();
            }

            foreach (int TVItemID in parentsTVItemIDList)
            {
                tvItemModelList.Add(GetTVItemModelWithTVItemIDDB(TVItemID));
            }

            return tvItemModelList.ToList();
        }
        public string IsMapInfoPointTextProperFormat(string MapInfoPointText)
        {
            List<string> stringList = MapInfoPointText.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            if (stringList.Count != 1)
                return ServiceRes.MapInfoPointNotWellFormedShouldHave1Point;

            foreach (string s in stringList)
            {
                string retStr = IsPointTextProperFormat(s);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return retStr;
            }

            return "";
        }
        public string IsMapInfoPolylineTextProperFormat(string MapInfoPolylineText)
        {
            List<string> stringList = MapInfoPolylineText.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            if (stringList.Count < 2)
                return ServiceRes.MapInfoPointNotWellFormedShouldHaveMoreThan1Point;

            foreach (string s in stringList)
            {
                string retStr = IsPointTextProperFormat(s);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return retStr;
            }
            return "";
        }
        public string IsMapInfoPolygonTextProperFormat(string MapInfoPolygonText)
        {
            List<string> stringList = MapInfoPolygonText.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            if (stringList.Count < 3)
                return ServiceRes.MapInfoPointNotWellFormedShouldHaveMoreThan2Points;

            foreach (string s in stringList)
            {
                string retStr = IsPointTextProperFormat(s);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return retStr;
            }
            return "";
        }
        public string IsPointTextProperFormat(string pointText)
        {
            List<string> stringListVal = pointText.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            if (stringListVal.Count != 2)
                return ServiceRes.MapInfoPointNotWellFormedShouldHave2Values;

            foreach (string sv in stringListVal)
            {
                float value = 0.0f;
                float.TryParse(sv, out value);
                if (value == 0.0f)
                    return ServiceRes.MapInfoPointNotADecimalValue;
            }

            return "";
        }
        public TVItemModel ReturnError(string Error)
        {
            return new TVItemModel() { Error = Error };
        }

        // More Info
        public TVItemMoreInfoFileModel GetTVItemMoreInfoFileDB(int TVItemID)
        {
            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoFileModel() { Error = tvItemModel.Error };

            TVItemMoreInfoFileModel tvItemMoreInfoFileModel = (from c in db.TVFiles
                                                               from cl in db.TVFileLanguages
                                                               where c.TVFileTVItemID == TVItemID
                                                               && c.TVFileID == cl.TVFileID
                                                               && cl.Language == (int)LanguageRequest
                                                               select new TVItemMoreInfoFileModel
                                                               {
                                                                   Error = "",
                                                                   FullDesc = cl.FileDescription,
                                                                   Parameters = c.Parameters,
                                                                   Language = (LanguageEnum)cl.Language
                                                               }).FirstOrDefault<TVItemMoreInfoFileModel>();

            if (tvItemMoreInfoFileModel != null)
            {
                if (!string.IsNullOrWhiteSpace(tvItemMoreInfoFileModel.Parameters))
                {
                    string NewParam = "";
                    string Parameters = tvItemMoreInfoFileModel.Parameters;
                    List<string> ParamValueList = Parameters.Split("|||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                    foreach (string ParamValue in ParamValueList)
                    {
                        List<string> PandV = ParamValue.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                        if (PandV.Count == 2)
                        {
                            if (!(PandV[0] == "ReportTypeID" || PandV[0] == "TVItemID"))
                            {
                                NewParam = NewParam + PandV[0] + " [" + PandV[1] + "], ";
                            }

                        }
                    }
                    tvItemMoreInfoFileModel.Parameters = NewParam;
                }
            }

            return tvItemMoreInfoFileModel;
        }
        public TVItemMoreInfoInfrastructureModel GetTVItemMoreInfoInfrastructureDB(int TVItemID)
        {
            TVItemMoreInfoInfrastructureModel tvItemMoreInfoInfrastructureModel = new TVItemMoreInfoInfrastructureModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoInfrastructureModel() { Error = tvItemModel.Error };

            tvItemMoreInfoInfrastructureModel.Error = "";

            // BoxModel count
            tvItemMoreInfoInfrastructureModel.BoxModelCount = (from c in db.TVItems
                                                               from b in db.BoxModels
                                                               where c.TVItemID == b.InfrastructureTVItemID
                                                               && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                               select b).Count();

            // VPScenario count
            tvItemMoreInfoInfrastructureModel.VPScenarioCount = (from c in db.TVItems
                                                                 from v in db.VPScenarios
                                                                 where c.TVItemID == v.InfrastructureTVItemID
                                                                 && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                                 select v).Count();

            tvItemMoreInfoInfrastructureModel.PercOfTotalFlow = 0;

            // Getting the FlowPeak

            TVItem tvItem = (from c in db.TVItems
                             where c.TVPath == tvItemModel.TVPath
                             select c).FirstOrDefault<TVItem>();

            if (tvItem != null)
            {
                Infrastructure inf = (from c in db.Infrastructures
                                      where c.InfrastructureTVItemID == tvItem.TVItemID
                                      select c).FirstOrDefault<Infrastructure>();

                if (inf != null)
                {
                    if (inf.PercFlowOfTotal != null)
                    {
                        tvItemMoreInfoInfrastructureModel.PercOfTotalFlow = (float)inf.PercFlowOfTotal;
                    }

                    if (inf.PeakFlow_m3_day != null)
                    {
                        if (inf.PeakFlow_m3_day > 0)
                        {
                            tvItemMoreInfoInfrastructureModel.PeakFlow_m3_day = (float)inf.PeakFlow_m3_day;
                        }
                    }
                    if (tvItemMoreInfoInfrastructureModel.PeakFlow_m3_day == null)
                    {
                        bool Done = false;
                        int CurrentTVItemID = tvItem.TVItemID;
                        while (!Done)
                        {
                            TVItemLink currentLink = (from c in db.TVItemLinks
                                                      where c.ToTVItemID == CurrentTVItemID
                                                      select c).FirstOrDefault<TVItemLink>();

                            if (currentLink == null)
                            {
                                Done = true;
                            }
                            else
                            {
                                CurrentTVItemID = currentLink.FromTVItemID;

                                Infrastructure inf2 = (from c in db.Infrastructures
                                                       where c.InfrastructureTVItemID == CurrentTVItemID
                                                       select c).FirstOrDefault<Infrastructure>();

                                if (inf2 != null)
                                {
                                    if (inf2.PeakFlow_m3_day != null)
                                    {
                                        if (inf2.PeakFlow_m3_day > 0)
                                        {
                                            tvItemMoreInfoInfrastructureModel.PeakFlow_m3_day = (float)(inf2.PeakFlow_m3_day * tvItemMoreInfoInfrastructureModel.PercOfTotalFlow / 100);
                                            Done = true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (inf.AverageFlow_m3_day != null)
                    {
                        if (inf.AverageFlow_m3_day > 0)
                        {
                            tvItemMoreInfoInfrastructureModel.AverageFlow_m3_day = (float)inf.AverageFlow_m3_day;
                        }
                    }
                    if (tvItemMoreInfoInfrastructureModel.AverageFlow_m3_day == null)
                    {
                        bool Done = false;
                        int CurrentTVItemID = tvItem.TVItemID;
                        while (!Done)
                        {
                            TVItemLink currentLink = (from c in db.TVItemLinks
                                                      where c.ToTVItemID == CurrentTVItemID
                                                      select c).FirstOrDefault<TVItemLink>();

                            if (currentLink == null)
                            {
                                Done = true;
                            }
                            else
                            {
                                CurrentTVItemID = currentLink.FromTVItemID;

                                Infrastructure inf2 = (from c in db.Infrastructures
                                                       where c.InfrastructureTVItemID == CurrentTVItemID
                                                       select c).FirstOrDefault<Infrastructure>();

                                if (inf2 != null)
                                {
                                    if (inf2.AverageFlow_m3_day != null)
                                    {
                                        if (inf2.AverageFlow_m3_day > 0)
                                        {
                                            tvItemMoreInfoInfrastructureModel.AverageFlow_m3_day = (float)(inf2.AverageFlow_m3_day * tvItemMoreInfoInfrastructureModel.PercOfTotalFlow / 100);
                                            Done = true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            return tvItemMoreInfoInfrastructureModel;
        }
        public TVItemMoreInfoMikeScenarioModel GetTVItemMoreInfoMikeScenarioDB(int TVItemID)
        {
            MikeScenarioService mikeScenarioService = new MikeScenarioService(_TVItemLinkService.LanguageRequest, _TVItemLinkService.User);
            MikeSourceService mikeSourceService = new MikeSourceService(_TVItemLinkService.LanguageRequest, _TVItemLinkService.User);
            MikeSourceStartEndService mikeSourceStartEndService = new MikeSourceStartEndService(_TVItemLinkService.LanguageRequest, _TVItemLinkService.User);

            TVItemMoreInfoMikeScenarioModel tvItemMoreInfoMikeScenarioModel = new TVItemMoreInfoMikeScenarioModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoMikeScenarioModel() { Error = tvItemModel.Error };

            tvItemMoreInfoMikeScenarioModel.Error = "";


            MikeScenarioModel mikeScenarioModel = mikeScenarioService.GetMikeScenarioModelWithMikeScenarioTVItemIDDB(TVItemID);

            if (mikeScenarioModel != null)
            {
                tvItemMoreInfoMikeScenarioModel.ScenarioStatus = (ScenarioStatusEnum)mikeScenarioModel.ScenarioStatus;
                tvItemMoreInfoMikeScenarioModel.MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local;
                tvItemMoreInfoMikeScenarioModel.MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local;
                tvItemMoreInfoMikeScenarioModel.WindSpeed_km_h = (float)mikeScenarioModel.WindSpeed_km_h;
                tvItemMoreInfoMikeScenarioModel.WindDirection_deg = (float)mikeScenarioModel.WindDirection_deg;
                tvItemMoreInfoMikeScenarioModel.DecayFactor_per_day = (float)mikeScenarioModel.DecayFactor_per_day;
                tvItemMoreInfoMikeScenarioModel.DecayIsConstant = (bool)mikeScenarioModel.DecayIsConstant;
                tvItemMoreInfoMikeScenarioModel.DecayFactorAmplitude = (float)mikeScenarioModel.DecayFactorAmplitude;
                tvItemMoreInfoMikeScenarioModel.ResultFrequency_min = (int)mikeScenarioModel.ResultFrequency_min;
                tvItemMoreInfoMikeScenarioModel.AmbientTemperature_C = (float)mikeScenarioModel.AmbientTemperature_C;
                tvItemMoreInfoMikeScenarioModel.AmbientSalinity_PSU = (float)mikeScenarioModel.AmbientSalinity_PSU;
                tvItemMoreInfoMikeScenarioModel.ManningNumber = (float)mikeScenarioModel.ManningNumber;
                tvItemMoreInfoMikeScenarioModel.HydroFileSize = (int)(mikeScenarioModel.EstimatedHydroFileSize ?? 0);
                tvItemMoreInfoMikeScenarioModel.TransFileSize = (int)(mikeScenarioModel.EstimatedTransFileSize ?? 0);

                List<MikeSourceModel> mikeSourceModelList = mikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(TVItemID);

                foreach (MikeSourceModel mikeSourceModel in mikeSourceModelList)
                {
                    if (mikeSourceModel.Include && !mikeSourceModel.IsRiver)
                    {
                        List<MikeSourceStartEndModel> mikeSourceStartEndModelList = null;
                        mikeSourceStartEndModelList = mikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);

                        TVItemMikeSourceModel tvItemMikeSourceModel = new TVItemMikeSourceModel()
                        {
                            MikeSourceTVText = mikeSourceModel.MikeSourceTVText,
                            IsContinuous = mikeSourceModel.IsContinuous,
                        };
                        if (mikeSourceStartEndModelList != null)
                        {
                            tvItemMikeSourceModel.TVItemMikeSourceStartEndModelList = mikeSourceStartEndModelList;
                        }

                        tvItemMoreInfoMikeScenarioModel.TVItemMikeSourceModelList.Add(tvItemMikeSourceModel);
                    }
                }


            }

            return tvItemMoreInfoMikeScenarioModel;
        }
        public TVItemMoreInfoMunicipalityModel GetTVItemMoreInfoMunicipalityDB(int TVItemID)
        {
            TVItemMoreInfoMunicipalityModel tvItemMoreInfoMunicipalityModel = new TVItemMoreInfoMunicipalityModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoMunicipalityModel() { Error = tvItemModel.Error };

            tvItemMoreInfoMunicipalityModel.Error = "";

            // WWTP count
            tvItemMoreInfoMunicipalityModel.WWTPCount = (from c in db.TVItems
                                                         from b in db.Infrastructures
                                                         where c.TVItemID == b.InfrastructureTVItemID
                                                         && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                         && b.InfrastructureType == (int)InfrastructureTypeEnum.WWTP
                                                         && c.TVType == (int)TVTypeEnum.Infrastructure
                                                         select b).Count();

            // LS count
            tvItemMoreInfoMunicipalityModel.LSCount = (from c in db.TVItems
                                                       from b in db.Infrastructures
                                                       where c.TVItemID == b.InfrastructureTVItemID
                                                       && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                       && b.InfrastructureType == (int)InfrastructureTypeEnum.LiftStation
                                                       && c.TVType == (int)TVTypeEnum.Infrastructure
                                                       select b).Count();

            // Mikescenario count
            tvItemMoreInfoMunicipalityModel.MikeScenarioCount = (from c in db.TVItems
                                                                 where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                                 && c.TVType == (int)TVTypeEnum.MikeScenario
                                                                 select c).Count();

            // BoxModel count
            tvItemMoreInfoMunicipalityModel.BoxModelCount = (from c in db.TVItems
                                                             from b in db.BoxModels
                                                             where c.TVItemID == b.InfrastructureTVItemID
                                                             && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                             && c.TVType == (int)TVTypeEnum.Infrastructure
                                                             select c).Count();

            // VPScenario count
            tvItemMoreInfoMunicipalityModel.VPScenarioCount = (from c in db.TVItems
                                                               from v in db.VPScenarios
                                                               where c.TVItemID == v.InfrastructureTVItemID
                                                               && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                               && c.TVType == (int)TVTypeEnum.Infrastructure
                                                               select v).Count();



            return tvItemMoreInfoMunicipalityModel;
        }
        public TVItemMoreInfoPolSourceSiteModel GetTVItemMoreInfoPolSourceSiteDB(int TVItemID)
        {
            TVItemMoreInfoPolSourceSiteModel tvItemMoreInfoPolSourceSiteModel = new TVItemMoreInfoPolSourceSiteModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoPolSourceSiteModel() { Error = tvItemModel.Error };

            tvItemMoreInfoPolSourceSiteModel.Error = "";

            PolSourceObservation polSourceObservation = (from c in db.PolSourceSites
                                                         from o in db.PolSourceObservations
                                                         where c.PolSourceSiteTVItemID == TVItemID
                                                         && c.PolSourceSiteID == o.PolSourceSiteID
                                                         orderby o.ObservationDate_Local descending
                                                         select o).FirstOrDefault<PolSourceObservation>();
            tvItemMoreInfoPolSourceSiteModel.FullDesc = "";
            tvItemMoreInfoPolSourceSiteModel.IssuesTVTextList = new List<string>();
            tvItemMoreInfoPolSourceSiteModel.ObsDateTime_Local = new DateTime(1000, 1, 1);

            if (polSourceObservation != null)
            {
                tvItemMoreInfoPolSourceSiteModel.FullDesc = (string.IsNullOrWhiteSpace(polSourceObservation.Observation_ToBeDeleted) ? "" : polSourceObservation.Observation_ToBeDeleted).Replace(@"\n", "<br />");

                List<PolSourceObservationIssue> polSourceObservationIssueList = (from c in db.PolSourceObservationIssues
                                                                                 from o in db.PolSourceObservations
                                                                                 where c.PolSourceObservationID == o.PolSourceObservationID
                                                                                 && c.PolSourceObservationID == polSourceObservation.PolSourceObservationID
                                                                                 orderby c.Ordinal
                                                                                 select c).ToList<PolSourceObservationIssue>();

                if (polSourceObservationIssueList.Count > 0)
                {
                    foreach (PolSourceObservationIssue polSourceObservationIssue in polSourceObservationIssueList)
                    {
                        List<string> ObservationInfoList = (string.IsNullOrWhiteSpace(polSourceObservationIssue.ObservationInfo) ? new List<string>() : polSourceObservationIssue.ObservationInfo.Trim().Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());

                        string TVText = "";
                        for (int i = 0, count = ObservationInfoList.Count; i < count; i++)
                        {
                            string Temp = _BaseEnumService.GetEnumText_PolSourceObsInfoReportEnum((PolSourceObsInfoEnum)int.Parse(ObservationInfoList[i]));
                            switch (ObservationInfoList[i].Substring(0, 3))
                            {
                                case "101":
                                    {
                                        Temp = Temp.Replace("Source", "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Source</strong>");
                                    }
                                    break;
                                //case "153":
                                //    {
                                //        Temp = Temp.Replace("Dilution Analyses", "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Dilution Analyses</strong>");
                                //    }
                                //    break;
                                case "250":
                                    {
                                        Temp = Temp.Replace("Pathway", "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Pathway</strong>");
                                    }
                                    break;
                                case "900":
                                    {
                                        Temp = Temp.Replace("Status", "<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Status</strong>");
                                    }
                                    break;
                                case "910":
                                    {
                                        Temp = Temp.Replace("Risk", "<strong>Risk</strong>");
                                    }
                                    break;
                                case "110":
                                case "120":
                                case "122":
                                case "151":
                                case "152":
                                case "153":
                                case "155":
                                case "156":
                                case "157":
                                case "163":
                                case "166":
                                case "167":
                                case "170":
                                case "171":
                                case "172":
                                case "173":
                                case "176":
                                case "178":
                                case "181":
                                case "182":
                                case "183":
                                case "185":
                                case "186":
                                case "187":
                                case "190":
                                case "191":
                                case "192":
                                case "193":
                                case "194":
                                case "196":
                                case "198":
                                case "199":
                                case "220":
                                case "930":
                                    {
                                        Temp = @"<span class=""hidden"">" + Temp + "</span>";
                                    }
                                    break;
                                default:
                                    break;
                            }
                            TVText = TVText + Temp;
                        }
                        tvItemMoreInfoPolSourceSiteModel.IssuesTVTextList.Add(string.IsNullOrWhiteSpace(TVText) ? ServiceRes.Error : TVText);
                    }
                }

                tvItemMoreInfoPolSourceSiteModel.ObsDateTime_Local = polSourceObservation.ObservationDate_Local;
            }

            return tvItemMoreInfoPolSourceSiteModel;
        }
        public TVItemMoreInfoProvinceModel GetTVItemMoreInfoProvinceDB(int TVItemID)
        {
            TVItemMoreInfoProvinceModel tvItemMoreInfoProvinceModel = new TVItemMoreInfoProvinceModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoProvinceModel() { Error = tvItemModel.Error };

            tvItemMoreInfoProvinceModel.Error = "";

            // Municipality count
            tvItemMoreInfoProvinceModel.MunicipalityCount = (from c in db.TVItems
                                                             where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                             && c.TVType == (int)TVTypeEnum.Municipality
                                                             select c).Count();

            // WWTP count
            tvItemMoreInfoProvinceModel.WWTPCount = (from c in db.TVItems
                                                     from b in db.Infrastructures
                                                     where c.TVItemID == b.InfrastructureTVItemID
                                                     && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                     && b.InfrastructureType == (int)InfrastructureTypeEnum.WWTP
                                                     && c.TVType == (int)TVTypeEnum.Infrastructure
                                                     select b).Count();

            // LS count
            tvItemMoreInfoProvinceModel.LSCount = (from c in db.TVItems
                                                   from b in db.Infrastructures
                                                   where c.TVItemID == b.InfrastructureTVItemID
                                                   && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                   && b.InfrastructureType == (int)InfrastructureTypeEnum.LiftStation
                                                   && c.TVType == (int)TVTypeEnum.Infrastructure
                                                   select b).Count();

            // Area count
            tvItemMoreInfoProvinceModel.AreaCount = (from c in db.TVItems
                                                     where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                     && c.TVType == (int)TVTypeEnum.Area
                                                     select c).Count();

            // Sector count
            tvItemMoreInfoProvinceModel.SectorCount = (from c in db.TVItems
                                                       where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                       && c.TVType == (int)TVTypeEnum.Sector
                                                       select c).Count();

            // Subsector count
            tvItemMoreInfoProvinceModel.SubSectorCount = (from c in db.TVItems
                                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                          && c.TVType == (int)TVTypeEnum.Subsector
                                                          select c).Count();

            // Sample count
            tvItemMoreInfoProvinceModel.MWQMSampleCount = (from c in db.TVItems
                                                           from s in db.MWQMSamples
                                                           where c.TVItemID == s.MWQMSiteTVItemID
                                                           && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                           && c.TVType == (int)TVTypeEnum.MWQMSite
                                                           select s).Count();

            // Site count
            tvItemMoreInfoProvinceModel.MWQMSiteCount = (from c in db.TVItems
                                                         where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                         && c.TVType == (int)TVTypeEnum.MWQMSite
                                                         select c).Count();

            // Pollution Source Site count
            tvItemMoreInfoProvinceModel.PolSourceSiteCount = (from c in db.TVItems
                                                              where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                              && c.TVType == (int)TVTypeEnum.PolSourceSite
                                                              select c).Count();

            // Mikescenario count
            tvItemMoreInfoProvinceModel.MikeScenarioCount = (from c in db.TVItems
                                                             where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                             && c.TVType == (int)TVTypeEnum.MikeScenario
                                                             select c).Count();

            // BoxModel count
            tvItemMoreInfoProvinceModel.BoxModelCount = (from c in db.TVItems
                                                         from b in db.BoxModels
                                                         where c.TVItemID == b.InfrastructureTVItemID
                                                         && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                         select b).Count();

            // VPScenario count
            tvItemMoreInfoProvinceModel.VPScenarioCount = (from c in db.TVItems
                                                           from v in db.VPScenarios
                                                           where c.TVItemID == v.InfrastructureTVItemID
                                                           && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                           select v).Count();

            return tvItemMoreInfoProvinceModel;
        }
        public TVItemMoreInfoSectorModel GetTVItemMoreInfoSectorDB(int TVItemID)
        {
            TVItemMoreInfoSectorModel tvItemMoreInfoSectorModel = new TVItemMoreInfoSectorModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoSectorModel() { Error = tvItemModel.Error };

            tvItemMoreInfoSectorModel.Error = "";

            // Municipality count
            tvItemMoreInfoSectorModel.MunicipalityCount = (from c in db.TVItems
                                                           where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                           && c.TVType == (int)TVTypeEnum.Municipality
                                                           select c).Count();

            // WWTP count
            tvItemMoreInfoSectorModel.WWTPCount = (from c in db.TVItems
                                                   from b in db.Infrastructures
                                                   where c.TVItemID == b.InfrastructureTVItemID
                                                   && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                   && b.InfrastructureType == (int)InfrastructureTypeEnum.WWTP
                                                   && c.TVType == (int)TVTypeEnum.Infrastructure
                                                   select b).Count();

            // LS count
            tvItemMoreInfoSectorModel.LSCount = (from c in db.TVItems
                                                 from b in db.Infrastructures
                                                 where c.TVItemID == b.InfrastructureTVItemID
                                                 && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                 && b.InfrastructureType == (int)InfrastructureTypeEnum.LiftStation
                                                 && c.TVType == (int)TVTypeEnum.Infrastructure
                                                 select b).Count();

            // Subsector count
            tvItemMoreInfoSectorModel.SubSectorCount = (from c in db.TVItems
                                                        where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                        && c.TVType == (int)TVTypeEnum.Subsector
                                                        select c).Count();

            // Sample count
            tvItemMoreInfoSectorModel.MWQMSampleCount = (from c in db.TVItems
                                                         from s in db.MWQMSamples
                                                         where c.TVItemID == s.MWQMSiteTVItemID
                                                         && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                         && c.TVType == (int)TVTypeEnum.MWQMSite
                                                         select s).Count();

            // Site count
            tvItemMoreInfoSectorModel.MWQMSiteCount = (from c in db.TVItems
                                                       where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                       && c.TVType == (int)TVTypeEnum.MWQMSite
                                                       select c).Count();

            // Pollution Source Site count
            tvItemMoreInfoSectorModel.PolSourceSiteCount = (from c in db.TVItems
                                                            where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                            && c.TVType == (int)TVTypeEnum.PolSourceSite
                                                            select c).Count();

            // Mikescenario count
            tvItemMoreInfoSectorModel.MikeScenarioCount = (from c in db.TVItems
                                                           where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                           && c.TVType == (int)TVTypeEnum.MikeScenario
                                                           select c).Count();

            // BoxModel count
            tvItemMoreInfoSectorModel.BoxModelCount = (from c in db.TVItems
                                                       from b in db.BoxModels
                                                       where c.TVItemID == b.InfrastructureTVItemID
                                                       && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                       select b).Count();

            // VPScenario count
            tvItemMoreInfoSectorModel.VPScenarioCount = (from c in db.TVItems
                                                         from v in db.VPScenarios
                                                         where c.TVItemID == v.InfrastructureTVItemID
                                                         && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                         select v).Count();


            return tvItemMoreInfoSectorModel;
        }
        public TVItemMoreInfoSubsectorModel GetTVItemMoreInfoSubsectorDB(int TVItemID)
        {
            TVItemMoreInfoSubsectorModel tvItemMoreInfoSubsectorModel = new TVItemMoreInfoSubsectorModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoSubsectorModel() { Error = tvItemModel.Error };

            tvItemMoreInfoSubsectorModel.Error = "";


            // Municipality count
            tvItemMoreInfoSubsectorModel.MunicipalityCount = (from c in db.TVItems
                                                              where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                              && c.TVType == (int)TVTypeEnum.Municipality
                                                              select c).Count();

            // WWTP count
            tvItemMoreInfoSubsectorModel.WWTPCount = (from c in db.TVItems
                                                      from b in db.Infrastructures
                                                      where c.TVItemID == b.InfrastructureTVItemID
                                                      && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                      && b.InfrastructureType == (int)InfrastructureTypeEnum.WWTP
                                                      && c.TVType == (int)TVTypeEnum.Infrastructure
                                                      select b).Count();

            // LS count
            tvItemMoreInfoSubsectorModel.LSCount = (from c in db.TVItems
                                                    from b in db.Infrastructures
                                                    where c.TVItemID == b.InfrastructureTVItemID
                                                    && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                    && b.InfrastructureType == (int)InfrastructureTypeEnum.LiftStation
                                                    && c.TVType == (int)TVTypeEnum.Infrastructure
                                                    select b).Count();

            // Sample count
            tvItemMoreInfoSubsectorModel.MWQMSampleCount = (from c in db.TVItems
                                                            from s in db.MWQMSamples
                                                            where c.TVItemID == s.MWQMSiteTVItemID
                                                            && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                            && c.TVType == (int)TVTypeEnum.MWQMSite
                                                            select s).Count();

            // Site count
            tvItemMoreInfoSubsectorModel.MWQMSiteCount = (from c in db.TVItems
                                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                          && c.TVType == (int)TVTypeEnum.MWQMSite
                                                          select c).Count();

            // Pollution Source Site count
            tvItemMoreInfoSubsectorModel.PolSourceSiteCount = (from c in db.TVItems
                                                               where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                               && c.TVType == (int)TVTypeEnum.PolSourceSite
                                                               select c).Count();

            // Mikescenario count
            tvItemMoreInfoSubsectorModel.MikeScenarioCount = (from c in db.TVItems
                                                              where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                              && c.TVType == (int)TVTypeEnum.MikeScenario
                                                              select c).Count();

            // BoxModel count
            tvItemMoreInfoSubsectorModel.BoxModelCount = (from c in db.TVItems
                                                          from b in db.BoxModels
                                                          where c.TVItemID == b.InfrastructureTVItemID
                                                          && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                          select b).Count();

            // VPScenario count
            tvItemMoreInfoSubsectorModel.VPScenarioCount = (from c in db.TVItems
                                                            from v in db.VPScenarios
                                                            where c.TVItemID == v.InfrastructureTVItemID
                                                            && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                                            select v).Count();

            return tvItemMoreInfoSubsectorModel;
        }
        public TVItemMoreInfoMWQMRunModel GetTVItemMoreInfoMWQMRunTVItemIDDB(int MWQMRunTVItemID)
        {
            TVItemMoreInfoMWQMRunModel tvItemMoreInfoMWQMRunModel = new TVItemMoreInfoMWQMRunModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(MWQMRunTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoMWQMRunModel() { Error = tvItemModel.Error };

            MWQMSampleService mwqmSampleService = new MWQMSampleService(LanguageRequest, User);
            MWQMRunService mwqmRunService = new MWQMRunService(LanguageRequest, User);

            tvItemMoreInfoMWQMRunModel.Error = "";
            tvItemMoreInfoMWQMRunModel.MWQMSampleModelList = mwqmSampleService.GetMWQMSampleModelListWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
            tvItemMoreInfoMWQMRunModel.MWQMRunModel = mwqmRunService.GetMWQMRunModelWithMWQMRunTVItemIDDB(MWQMRunTVItemID);

            return tvItemMoreInfoMWQMRunModel;
        }
        public TVItemMoreInfoMWQMSiteModel GetTVItemMoreInfoMWQMSiteTVItemIDDB(int MWQMSiteTVItemID, int NumberOfSample)
        {
            TVItemMoreInfoMWQMSiteModel tvItemMoreInfoMWQMSiteModel = new TVItemMoreInfoMWQMSiteModel();

            TVItemModel tvItemModel = GetTVItemModelWithTVItemIDDB(MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new TVItemMoreInfoMWQMSiteModel() { Error = tvItemModel.Error };

            tvItemMoreInfoMWQMSiteModel.Error = "";

            MWQMSite mwqmSite = (from c in db.MWQMSites
                                 where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                 select c).FirstOrDefault();

            tvItemMoreInfoMWQMSiteModel.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)mwqmSite.MWQMSiteLatestClassification;

            string SampleTypeText = ((int)SampleTypeEnum.Routine).ToString() + ",";
            List<MWQMSample> mwqmSampleAll = (from c in db.MWQMSites
                                              from sa in db.MWQMSamples
                                              where c.MWQMSiteTVItemID == sa.MWQMSiteTVItemID
                                              && c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                              && sa.SampleTypesText.Contains(SampleTypeText)
                                              orderby sa.SampleDateTime_Local descending
                                              select sa).ToList<MWQMSample>();

            tvItemMoreInfoMWQMSiteModel.MWQMSampleCount = mwqmSampleAll.Count;

            List<MWQMSample> mwqmSampleList = (from c in mwqmSampleAll
                                               orderby c.SampleDateTime_Local descending
                                               select c).Take(NumberOfSample).ToList<MWQMSample>();

            if (mwqmSampleList.Count == 0)
            {
                tvItemMoreInfoMWQMSiteModel.Coloring = "noData";
                tvItemMoreInfoMWQMSiteModel.Letter = "0";

                return tvItemMoreInfoMWQMSiteModel;
            }

            int MinYear = (from c in mwqmSampleList
                           orderby c.SampleDateTime_Local descending
                           select c.SampleDateTime_Local.Year).Min();

            int MaxYear = (from c in mwqmSampleList
                           orderby c.SampleDateTime_Local descending
                           select c.SampleDateTime_Local.Year).Max();

            mwqmSampleList = (from c in mwqmSampleAll
                              where c.SampleDateTime_Local.Year >= MinYear
                              && c.SampleDateTime_Local.Year <= MaxYear
                              orderby c.SampleDateTime_Local descending
                              select c).ToList<MWQMSample>();

            tvItemMoreInfoMWQMSiteModel.SampCount = mwqmSampleList.Count();
            if (mwqmSampleAll.Count() > 0)
            {

                MWQMSample mwqmSample = (from c in mwqmSampleList
                                         orderby c.SampleDateTime_Local descending
                                         select c).FirstOrDefault();

                if (mwqmSample != null)
                {
                    tvItemMoreInfoMWQMSiteModel.LastSampleDate = mwqmSample.SampleDateTime_Local;
                }

                tvItemMoreInfoMWQMSiteModel.SampMinYear = mwqmSampleAll.Select(c => c.SampleDateTime_Local).Min().Year;
                tvItemMoreInfoMWQMSiteModel.SampMaxYear = mwqmSampleAll.Select(c => c.SampleDateTime_Local).Max().Year;
            }

            if (tvItemMoreInfoMWQMSiteModel.SampCount > 0)
            {
                tvItemMoreInfoMWQMSiteModel.MinFC = (float)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                tvItemMoreInfoMWQMSiteModel.MaxFC = (float)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);
            }

            if (mwqmSampleList.Count >= 4)
            {
                List<double> GeoMeanList = (from c in mwqmSampleList
                                            select (c.FecCol_MPN_100ml == 1 ? 1.9D : (double)c.FecCol_MPN_100ml)).ToList<double>();

                tvItemMoreInfoMWQMSiteModel.P90 = (float)GetP90(GeoMeanList);
                tvItemMoreInfoMWQMSiteModel.GeoMean = (float)GeometricMean(GeoMeanList);
                tvItemMoreInfoMWQMSiteModel.Median = (float)GetMedian(GeoMeanList);
                tvItemMoreInfoMWQMSiteModel.PercOver43 = (float)((((double)GeoMeanList.Where(c => c > 43).Count()) / (double)GeoMeanList.Count()) * 100.0D);
                tvItemMoreInfoMWQMSiteModel.PercOver260 = (float)((((double)GeoMeanList.Where(c => c > 260).Count()) / (double)GeoMeanList.Count()) * 100.0D);
                tvItemMoreInfoMWQMSiteModel.StatMinYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Min().Year;
                tvItemMoreInfoMWQMSiteModel.StatMaxYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Max().Year;

                int P90Int = (int)Math.Round((double)tvItemMoreInfoMWQMSiteModel.P90, 0);
                int GeoMeanInt = (int)Math.Round((double)tvItemMoreInfoMWQMSiteModel.GeoMean, 0);
                int MedianInt = (int)Math.Round((double)tvItemMoreInfoMWQMSiteModel.Median, 0);
                int PercOver43Int = (int)Math.Round((double)tvItemMoreInfoMWQMSiteModel.PercOver43, 0);
                int PercOver260Int = (int)Math.Round((double)tvItemMoreInfoMWQMSiteModel.PercOver260, 0);

                if ((GeoMeanInt > 88) || (MedianInt > 88) || (P90Int > 260) || (PercOver260Int > 10))
                {
                    tvItemMoreInfoMWQMSiteModel.Coloring = "noDepuration";
                    if ((GeoMeanInt > 181) || (MedianInt > 181) || (P90Int > 460) || (PercOver260Int > 18))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "F";
                    }
                    else if ((GeoMeanInt > 163) || (MedianInt > 163) || (P90Int > 420) || (PercOver260Int > 17))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "E";
                    }
                    else if ((GeoMeanInt > 144) || (MedianInt > 144) || (P90Int > 380) || (PercOver260Int > 15))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "D";
                    }
                    else if ((GeoMeanInt > 125) || (MedianInt > 125) || (P90Int > 340) || (PercOver260Int > 13))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "C";
                    }
                    else if ((GeoMeanInt > 107) || (MedianInt > 107) || (P90Int > 300) || (PercOver260Int > 12))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "B";
                    }
                    else
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "A";
                    }
                }
                else if ((GeoMeanInt > 14) || (MedianInt > 14) || (P90Int > 43) || (PercOver43Int > 10))
                {
                    tvItemMoreInfoMWQMSiteModel.Coloring = "failed";
                    if ((GeoMeanInt > 76) || (MedianInt > 76) || (P90Int > 224) || (PercOver43Int > 27))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "F";
                    }
                    else if ((GeoMeanInt > 63) || (MedianInt > 63) || (P90Int > 188) || (PercOver43Int > 23))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "E";
                    }
                    else if ((GeoMeanInt > 51) || (MedianInt > 51) || (P90Int > 152) || (PercOver43Int > 20))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "D";
                    }
                    else if ((GeoMeanInt > 39) || (MedianInt > 39) || (P90Int > 115) || (PercOver43Int > 17))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "C";
                    }
                    else if ((GeoMeanInt > 26) || (MedianInt > 26) || (P90Int > 79) || (PercOver43Int > 13))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "B";
                    }
                    else
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "A";
                    }
                }
                else
                {
                    tvItemMoreInfoMWQMSiteModel.Coloring = "passed";
                    if ((GeoMeanInt > 12) || (MedianInt > 12) || (P90Int > 36) || (PercOver43Int > 8))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "F";
                    }
                    else if ((GeoMeanInt > 9) || (MedianInt > 9) || (P90Int > 29) || (PercOver43Int > 7))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "E";
                    }
                    else if ((GeoMeanInt > 7) || (MedianInt > 7) || (P90Int > 22) || (PercOver43Int > 5))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "D";
                    }
                    else if ((GeoMeanInt > 5) || (MedianInt > 5) || (P90Int > 14) || (PercOver43Int > 3))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "C";
                    }
                    else if ((GeoMeanInt > 2) || (MedianInt > 2) || (P90Int > 7) || (PercOver43Int > 2))
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "B";
                    }
                    else
                    {
                        tvItemMoreInfoMWQMSiteModel.Letter = "A";
                    }
                }
            }
            else if (tvItemMoreInfoMWQMSiteModel.SampCount == 0)
            {
                tvItemMoreInfoMWQMSiteModel.Coloring = "noData";
                tvItemMoreInfoMWQMSiteModel.Letter = mwqmSampleList.Count.ToString();
            }
            else
            {
                tvItemMoreInfoMWQMSiteModel.Coloring = "notEnoughData";
                tvItemMoreInfoMWQMSiteModel.Letter = mwqmSampleList.Count.ToString();
            }

            return tvItemMoreInfoMWQMSiteModel;
        }

        public List<TVTypeEnum> GetChildrenTVTypeListWithTVItemIDDB(int TVItemID)
        {
            List<TVTypeEnum> tvTypeEnumList = (from c in db.TVItems
                                               where c.ParentID == TVItemID
                                               && c.TVLevel != 0
                                               select (TVTypeEnum)c.TVType).Distinct().ToList();

            return tvTypeEnumList;
        }

        // Stat
        public double GeometricMean(List<double> data)
        {
            double GMean, prod;

            prod = 1.0;

            foreach (double d in data)
            {
                prod *= d;
            }

            GMean = Math.Pow(prod, (1.0 / data.Count()));
            return GMean;
        }
        public double GetMedian(List<double> data)
        {
            //Framework 2.0 version of this method. there is an easier way in F4        
            if (data == null || data.Count() == 0)
                return 0D;

            //make sure the list is sorted, but use a new array
            List<double> sortedData = data.OrderBy(c => c).ToList();

            //get the median
            int size = sortedData.Count();
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)sortedData[mid] : ((double)sortedData[mid] + (double)sortedData[mid - 1]) / 2;
            return median;
        }
        public double GetP90(List<double> data)
        {
            double P90;

            List<double> fcLogList = new List<double>();
            foreach (double d in data)
            {
                fcLogList.Add(Math.Log10(d)); //Math.log(d.val) / Math.LN10
            }

            // calculating P90
            double Mean = (double)fcLogList.Average();
            double SD = GetStandardDeviation(fcLogList);
            double P90Log = (SD * 1.28) + Mean;
            P90 = Math.Pow(10, P90Log);
            return P90;

        }
        public double GetStandardDeviation(List<double> fcList)
        {
            double ret = 0;
            if (fcList.Count() > 0)
            {
                double avg = fcList.Average();
                double sum = fcList.Sum(d => Math.Pow(d - avg, 2));
                ret = Math.Sqrt((sum) / (fcList.Count() - 1));
            }
            return ret;
        }

        // Post
        public TVItemModel TVItemDeleteDB(int TVItemID)
        {
            TVItemModel tvItemModelRet = new TVItemModel() { Error = "Error" };
            using (TransactionScope ts = new TransactionScope())
            {
                MapInfoModel mapInfoModel = PostDeleteMapInfoWithTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                    return ReturnError(mapInfoModel.Error);

                TVItemModel tvItemModelExist = GetTVItemModelWithTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                    return ReturnError(tvItemModelExist.Error);

                switch (tvItemModelExist.TVType)
                {
                    case TVTypeEnum.Root:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Address:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Area:
                        {
                            tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                                return ReturnError(tvItemModelRet.Error);
                        }
                        break;
                    case TVTypeEnum.ClimateSite:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Contact:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Country:
                        {
                            tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                                return ReturnError(tvItemModelRet.Error);
                        }
                        break;
                    case TVTypeEnum.Email:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.File:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.HydrometricSite:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Infrastructure:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionWebTide:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.MikeBoundaryConditionMesh:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.MikeScenario:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.MikeSource:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Municipality:
                        {
                            tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                                return ReturnError(tvItemModelRet.Error);
                        }
                        break;
                    case TVTypeEnum.MWQMRun:
                        {
                            MWQMRunService mwqmRunService = new MWQMRunService(LanguageRequest, User);

                            MWQMRunModel mwqmRunModel = mwqmRunService.PostDeleteMWQMRunTVItemIDDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
                                return ReturnError(mwqmRunModel.Error);

                            tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                                return ReturnError(tvItemModelRet.Error);

                        }
                        break;
                    case TVTypeEnum.MWQMSite:
                        {
                            MWQMSiteService mwqmSiteService = new MWQMSiteService(LanguageRequest, User);

                            MWQMSiteModel mwqmSiteModel = mwqmSiteService.PostDeleteMWQMSiteTVItemDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(mwqmSiteModel.Error))
                                return ReturnError(mwqmSiteModel.Error);

                            tvItemModelRet.Error = mwqmSiteModel.Error;

                            //tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            //if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                            //    return ReturnError(tvItemModelRet.Error);

                        }
                        break;
                    case TVTypeEnum.PolSourceSite:
                        {
                            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
                            AddressService addressService = new AddressService(LanguageRequest, User);
                            TVItemService tvItemService = new TVItemService(LanguageRequest, User);
                            TVFileService tvFileService = new TVFileService(LanguageRequest, User);

                            tvItemModelRet.Error = "";

                            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
                            if (string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                            {
                                if (polSourceSiteModel.CivicAddressTVItemID != null)
                                {
                                    try
                                    {
                                        AddressModel addressModel = addressService.GetAddressModelWithAddressTVItemIDDB((int)polSourceSiteModel.CivicAddressTVItemID);
                                        if (!string.IsNullOrWhiteSpace(addressModel.Error))
                                            return ReturnError(addressModel.Error);

                                        AddressModel addressModelRet = addressService.PostDeleteAddressWithAddressTVItemIDDB(addressModel.AddressTVItemID);
                                    }
                                    catch (Exception)
                                    {
                                        // Nothing
                                    }
                                }

                                PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PostDeletePolSourceSiteWithPolSourceSiteTVItemIDDB(TVItemID);
                                if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                                    return ReturnError(polSourceSiteModelRet.Error);

                                tvItemModelRet.Error = polSourceSiteModelRet.Error;
                            }

                            if (string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                            {
                                List<TVFileModel> tvFileModelList = tvFileService.GetTVFileModelListWithParentTVItemIDDB(TVItemID);
                                foreach (TVFileModel tvFileModel in tvFileModelList)
                                {
                                    try
                                    {
                                        TVFileModel tvFileModelRet = tvFileService.PostDeleteTVFileDB(tvFileModel.TVFileID);
                                        TVItemModel tvItemModelRet2 = tvItemService.PostDeleteTVItemWithTVItemIDDB(tvFileModel.TVFileTVItemID);
                                    }
                                    catch (Exception)
                                    {
                                        // nothing
                                    }
                                }

                                try
                                {
                                    TVItemModel tvItemModelRet2 = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                                }
                                catch (Exception)
                                {
                                    // nothing
                                }
                            }

                            //tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            //if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                            //    return ReturnError(tvItemModelRet.Error);

                        }
                        break;
                    case TVTypeEnum.Province:
                        {
                            tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                                return ReturnError(tvItemModelRet.Error);
                        }
                        break;
                    case TVTypeEnum.Sector:
                        {
                            tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                                return ReturnError(tvItemModelRet.Error);
                        }
                        break;
                    case TVTypeEnum.Subsector:
                        {
                            tvItemModelRet = PostDeleteTVItemWithTVItemIDDB(TVItemID);
                            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                                return ReturnError(tvItemModelRet.Error);
                        }
                        break;
                    case TVTypeEnum.Tel:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.TideSite:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.MWQMSiteSample:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.WasteWaterTreatmentPlant:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.LiftStation:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Spill:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.BoxModel:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.VisualPlumesScenario:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Outfall:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.OtherInfrastructure:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.NoDepuration:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Failed:
                        {
                            tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.Passed:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.NoData:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.LessThan10:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.MeshNode:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.WebTideNode:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.SamplingPlan:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    case TVTypeEnum.SeeOther:
                        {
                            //tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                    default:
                        {
                            tvItemModelRet.Error = string.Format(ServiceRes.DeleteTVType_IsNotImplemented, tvItemModelRet.TVType.ToString());
                        }
                        break;
                }


                ts.Complete();
            }

            return tvItemModelRet;
        }
        public TVItemModel PostAddOrModifyTVItemDB(FormCollection fc)
        {

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ParentTVItemID = 0;
            int TVItemID = 0;
            int TVTypeInt = (int)TVAuthEnum.Error;
            TVTypeEnum TVType = TVTypeEnum.Error;
            string TVText = "";
            string MapInfoPointText = "";
            string MapInfoPolylineText = "";
            string MapInfoPolygonText = "";
            bool IsActive = false;

            int.TryParse(fc["ParentTVItemID"], out ParentTVItemID);
            if (ParentTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

            int.TryParse(fc["TVItemID"], out TVItemID);
            // if 0 then want to add new TVItem else want to modify

            int.TryParse(fc["TVType"], out TVTypeInt);
            if (TVTypeInt == (int)TVTypeEnum.Error)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVType));

            TVType = (TVTypeEnum)TVTypeInt;

            TVText = fc["TVText"];
            if (string.IsNullOrWhiteSpace(TVText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

            if (TVText.Contains("#"))
                return ReturnError(string.Format(ServiceRes.NameOfItemShouldNotContainThe_Character, "#"));

            if (!string.IsNullOrWhiteSpace(fc["IsActive"]))
                IsActive = true;

            MapInfoPointText = fc["MapInfoPoint"].Trim();
            if (string.IsNullOrWhiteSpace(MapInfoPointText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoPoint));

            string retStr = IsMapInfoPointTextProperFormat(MapInfoPointText);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            List<Coord> coordListMapInfoPoint = GetCoordFromText(MapInfoPointText);
            if (coordListMapInfoPoint.Count == 0)
                return ReturnError(ServiceRes.MapInfoPointNotWellFormedShouldHave1Point);

            MapInfoPolylineText = fc["MapInfoPolyline"].Trim();

            List<Coord> coordListMapInfoPolyline = new List<Coord>();
            if (!string.IsNullOrWhiteSpace(MapInfoPolylineText))
            {
                retStr = IsMapInfoPolylineTextProperFormat(MapInfoPolylineText);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                coordListMapInfoPolyline = GetCoordFromText(MapInfoPolylineText);
                if (coordListMapInfoPolyline.Count < 2)
                    return ReturnError(ServiceRes.MapInfoPointNotWellFormedShouldHaveMoreThan1Point);

            }

            MapInfoPolygonText = fc["MapInfoPolygon"].Trim();
            List<Coord> coordListMapInfoPolygon = new List<Coord>();
            if (!string.IsNullOrWhiteSpace(MapInfoPolygonText))
            {
                retStr = IsMapInfoPolygonTextProperFormat(MapInfoPolygonText);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                coordListMapInfoPolygon = GetCoordFromText(MapInfoPolygonText);
                if (coordListMapInfoPolygon.Count < 3)
                    return ReturnError(ServiceRes.MapInfoPointNotWellFormedShouldHaveMoreThan2Points);
            }

            TVItemModel tvItemModel = new TVItemModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (TVItemID == 0)
                {
                    tvItemModel = PostAddChildTVItemDB(ParentTVItemID, TVText, TVType);
                    if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                        return ReturnError(tvItemModel.Error);
                }
                else
                {
                    TVItemModel tvItemModelToChange = GetTVItemModelWithTVItemIDDB(TVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelToChange.Error))
                        return ReturnError(tvItemModelToChange.Error);

                    tvItemModelToChange.TVText = TVText;
                    tvItemModelToChange.IsActive = IsActive;

                    tvItemModel = PostUpdateTVItemDB(tvItemModelToChange);
                    if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                        return ReturnError(tvItemModel.Error);

                    MapInfoModel mapInfoModelRet = PostDeleteMapInfoWithTVItemIDDB(tvItemModel.TVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnError(mapInfoModelRet.Error);
                }

                MapInfoModel mapInfoModel = CreateMapInfoObjectDB(coordListMapInfoPoint, MapInfoDrawTypeEnum.Point, TVType, tvItemModel.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                    return ReturnError(mapInfoModel.Error);

                if (coordListMapInfoPolyline.Count > 1)
                {
                    mapInfoModel = CreateMapInfoObjectDB(coordListMapInfoPolyline, MapInfoDrawTypeEnum.Polyline, TVType, tvItemModel.TVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                        return ReturnError(mapInfoModel.Error);
                }

                if (coordListMapInfoPolygon.Count > 1)
                {
                    mapInfoModel = CreateMapInfoObjectDB(coordListMapInfoPolygon, MapInfoDrawTypeEnum.Polygon, TVType, tvItemModel.TVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                        return ReturnError(mapInfoModel.Error);
                }

                ts.Complete();
            }
            return tvItemModel;
        }
        public TVItemModel PostAddRootTVItemDB()
        {
            int TVItemCount = GetTVItemModelCountDB();
            if (TVItemCount > 0)
                return ReturnError(ServiceRes.TVItemRootShouldBeTheFirstOneAdded);

            TVItemModel tvItemModel = new TVItemModel();
            tvItemModel.TVLevel = 0;
            tvItemModel.TVPath = "p1";
            tvItemModel.TVType = TVTypeEnum.Root;
            tvItemModel.ParentID = 1;
            tvItemModel.IsActive = true;

            string TVText = "Root";

            TVItemModel tvItemModelRootExist = GetRootTVItemModelDB();
            if (string.IsNullOrWhiteSpace(tvItemModelRootExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.Root));

            TVItem tvItemNew = new TVItem();
            string retStr = FillTVItem(tvItemNew, tvItemModel, null);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItems.Add(tvItemNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItems", tvItemNew.TVItemID, LogCommandEnum.Add, tvItemNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel()
                    {
                        Language = Lang,
                        TVText = TVText,
                        TVItemID = tvItemNew.TVItemID,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    TVItemLanguageModel tvItemLanguageModelRet = _TVItemLanguageService.PostAddRootTVItemLanguageDB(tvItemLanguageModel);
                    if (!string.IsNullOrEmpty(tvItemLanguageModelRet.Error))
                        return ReturnError(string.Format(ServiceRes.CouldNotAddError_, tvItemLanguageModelRet.Error));
                }

                ts.Complete();
            }

            return GetTVItemModelWithTVItemIDDB(tvItemNew.TVItemID);
        }
        public TVItemModel PostAddChildTVItemDB(int ParentTVItemID, string TVText, TVTypeEnum TVType)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelParent = GetTVItemModelWithTVItemIDDB(ParentTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                return ReturnError(tvItemModelParent.Error);

            TVItemModel tvItemModelExist = GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(ParentTVItemID, TVText, TVType);
            if (string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVText));

            TVItemModel tvItemModel = new TVItemModel();
            tvItemModel.TVLevel = tvItemModelParent.TVLevel + 1;
            tvItemModel.TVPath = tvItemModelParent.TVPath + "p0"; // will change
            tvItemModel.TVType = (TVTypeEnum)TVType;
            tvItemModel.ParentID = ParentTVItemID;
            tvItemModel.IsActive = true;

            TVItem tvItemNew = new TVItem();

            string retStr = FillTVItem(tvItemNew, tvItemModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItems.Add(tvItemNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItems", tvItemNew.TVItemID, LogCommandEnum.Add, tvItemNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                tvItemNew.TVPath = tvItemModelParent.TVPath + "p" + tvItemNew.TVItemID;

                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                logModel = _LogService.PostAddLogForObj("TVItems", tvItemNew.TVItemID, LogCommandEnum.Change, tvItemNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);


                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel()
                    {
                        Language = Lang,
                        TVText = TVText,
                        TVItemID = tvItemNew.TVItemID,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    TVItemLanguageModel tvItemLanguageModelRet = _TVItemLanguageService.PostAddTVItemLanguageDB(tvItemLanguageModel);
                    if (!string.IsNullOrEmpty(tvItemLanguageModelRet.Error))
                        return ReturnError(string.Format(ServiceRes.CouldNotAddError_, tvItemLanguageModelRet.Error));
                }

                ts.Complete();
            }

            return GetTVItemModelWithTVItemIDDB(tvItemNew.TVItemID);
        }
        public TVItemModel PostAddChildContactTVItemDB(int ParentTVItemID, string TVText, TVTypeEnum TVType)
        {
            ContactOK contactOK = null;

            TVItemModel tvItemModelParent = GetTVItemModelWithTVItemIDDB(ParentTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                return ReturnError(tvItemModelParent.Error);

            TVItemModel tvItemModelExist = GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(ParentTVItemID, TVText, TVType);
            if (string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVText));

            TVItemModel tvItemModel = new TVItemModel();
            tvItemModel.TVLevel = tvItemModelParent.TVLevel + 1;
            tvItemModel.TVPath = tvItemModelParent.TVPath + "p0"; // will change
            tvItemModel.TVType = (TVTypeEnum)TVType;
            tvItemModel.ParentID = ParentTVItemID;
            tvItemModel.IsActive = true;

            TVItem tvItemNew = new TVItem();

            string retStr = FillTVItem(tvItemNew, tvItemModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItems.Add(tvItemNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItems", tvItemNew.TVItemID, LogCommandEnum.Add, tvItemNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                tvItemNew.TVPath = tvItemModelParent.TVPath + "p" + tvItemNew.TVItemID;

                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                logModel = _LogService.PostAddLogForObj("TVItems", tvItemNew.TVItemID, LogCommandEnum.Change, tvItemNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel()
                    {
                        Language = Lang,
                        TVText = TVText,
                        TVItemID = tvItemNew.TVItemID,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    TVItemLanguageModel tvItemLanguageModelRet = _TVItemLanguageService.PostAddTVItemContactLanguageDB(tvItemLanguageModel);
                    if (!string.IsNullOrEmpty(tvItemLanguageModelRet.Error))
                        return ReturnError(string.Format(ServiceRes.CouldNotAddError_, tvItemLanguageModelRet.Error));
                }

                ts.Complete();
            }

            return GetTVItemModelWithTVItemIDDB(tvItemNew.TVItemID);
        }
        public TVItemModel PostCreateTVItem(int TVItemID, string TVTextEN, string TVTextFR, TVTypeEnum tvType)
        {
            TVTextEN = CleanText(TVTextEN);
            TVTextFR = CleanText(TVTextFR);

            if (TVTextEN.Length > 200)
            {
                TVTextEN = TVTextEN.Substring(0, 180);
            }

            if (TVTextFR.Length > 200)
            {
                TVTextFR = TVTextFR.Substring(0, 180);
            }

            TVItemModel tvItemModel = GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(TVItemID, TVTextEN, tvType);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                tvItemModel = PostAddChildTVItemDB(TVItemID, TVTextEN, tvType);
                if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                    return ReturnError(tvItemModel.Error);

                TVItemLanguageModel tvItemLanguageModel = _TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModel.TVItemID, LanguageEnum.fr);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                    return ReturnError(tvItemLanguageModel.Error);

                tvItemLanguageModel.TVText = TVTextFR;
                tvItemLanguageModel = _TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                    return ReturnError(tvItemLanguageModel.Error);
            }
            return tvItemModel;
        }
        public MapInfoModel PostDeleteMapInfoWithTVItemIDDB(int TVItemID)
        {
            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, User);

            MapInfoModel mapInfoModel = mapInfoService.PostDeleteMapInfoWithTVItemIDDB(TVItemID);

            return mapInfoModel;
        }
        public TVItemModel PostDeleteTVItemWithTVItemIDDB(int TVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItem tvItemToDelete = GetTVItemWithTVItemIDDB(TVItemID);
            if (tvItemToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItem));

            db.TVItems.Remove(tvItemToDelete);
            string retStr = DoDeleteChanges();
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            LogModel logModel = _LogService.PostAddLogForObj("TVItems", tvItemToDelete.TVItemID, LogCommandEnum.Delete, tvItemToDelete);
            if (!string.IsNullOrWhiteSpace(logModel.Error))
                return ReturnError(logModel.Error);

            return ReturnError("");
        }
        public TVItemModel PostMoveTVItemUnderAnotherTVItemDB(int TVItemIDToMove, int TVItemIDUnder)
        {
            if (TVItemIDToMove == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemIDToMove));

            if (TVItemIDUnder == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemIDUnder));

            TVItemModel tvItemModelToMove = GetTVItemModelWithTVItemIDDB(TVItemIDToMove);
            if (!string.IsNullOrWhiteSpace(tvItemModelToMove.Error))
                return ReturnError(tvItemModelToMove.Error);

            string OldTVPath = tvItemModelToMove.TVPath;

            TVItemModel tvItemModelToMoveParent = GetTVItemModelWithTVItemIDDB(tvItemModelToMove.ParentID);
            if (!string.IsNullOrWhiteSpace(tvItemModelToMoveParent.Error))
                return ReturnError(tvItemModelToMoveParent.Error);

            TVItemModel tvItemModelUnder = GetTVItemModelWithTVItemIDDB(TVItemIDUnder);
            if (!string.IsNullOrWhiteSpace(tvItemModelUnder.Error))
                return ReturnError(tvItemModelUnder.Error);

            if (tvItemModelToMoveParent.TVType != tvItemModelUnder.TVType)
                return ReturnError(string.Format(ServiceRes.CanOnlyMoveUnderSameTypeOfParent));

            int ParentTVItemID = tvItemModelToMove.ParentID;
            using (TransactionScope ts = new TransactionScope())
            {
                // change Item itself
                tvItemModelToMove.TVPath = tvItemModelUnder.TVPath + "p" + tvItemModelToMove.TVItemID;
                tvItemModelToMove.ParentID = tvItemModelUnder.TVItemID;

                TVItemModel tvItemModelRet = PostUpdateTVItemDB(tvItemModelToMove);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                string NewBaseTVPath = tvItemModelRet.TVPath;

                // change all child
                List<TVItem> tvItemToChangeList = (from c in db.TVItems
                                                   where c.TVPath.StartsWith(OldTVPath + "p")
                                                   select c).ToList();

                foreach (TVItem tvItem in tvItemToChangeList)
                {
                    tvItem.TVPath = tvItem.TVPath.Replace(OldTVPath, NewBaseTVPath);

                    LogModel logModel = _LogService.PostAddLogForObj("TVItems", tvItem.TVItemID, LogCommandEnum.Change, tvItem);
                    if (!string.IsNullOrWhiteSpace(logModel.Error))
                        return ReturnError(logModel.Error);
                }

                if (tvItemModelToMove.TVType == TVTypeEnum.Infrastructure)
                {
                    TVItemLinkModel tvItemLinkModel = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDDB(tvItemModelToMove.TVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                        return ReturnError(tvItemLinkModel.Error);

                    tvItemLinkModel = _TVItemLinkService.PostDeleteTVItemLinkWithToTVItemIDDB(tvItemModelToMove.TVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                        return ReturnError(tvItemLinkModel.Error);
                }

                string retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(string.Format(ServiceRes.CouldNotMove_Under_, tvItemModelToMove.TVText, tvItemModelUnder.TVText));

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVItemModel PostUpdateTVItemDB(TVItemModel tvItemModel)
        {
            string retStr = TVItemModelOK(tvItemModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItem tvItemToUpdate = GetTVItemWithTVItemIDDB(tvItemModel.TVItemID);
            if (tvItemToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItem));

            TVItemModel tvItemModelExist = GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemToUpdate.ParentID, tvItemModel.TVText, (TVTypeEnum)tvItemModel.TVType);
            if (string.IsNullOrWhiteSpace(tvItemModelExist.Error))
            {
                bool IsSameTVItemModel = GetIsItSameObject(tvItemModel, tvItemModelExist);
                if (!IsSameTVItemModel)
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItem));
            }

            retStr = FillTVItem(tvItemToUpdate, tvItemModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItems", tvItemToUpdate.TVItemID, LogCommandEnum.Change, tvItemToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel()
                        {
                            Language = Lang,
                            TVText = tvItemModel.TVText,
                            TVItemID = tvItemToUpdate.TVItemID,
                            TranslationStatus = TranslationStatusEnum.Translated,
                        };
                        TVItemLanguageModel tvItemLanguageModelRet = _TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrEmpty(tvItemLanguageModelRet.Error))
                            return ReturnError(string.Format(ServiceRes.CouldNotAddError_, tvItemLanguageModelRet.Error));
                    }
                }

                ts.Complete();
            }
            return GetTVItemModelWithTVItemIDDB(tvItemToUpdate.TVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
