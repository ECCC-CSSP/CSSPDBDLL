using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using System.Collections.Generic;
using System;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using System.Web.Mvc;
using System.IO;
using System.Threading;
using System.Globalization;

namespace CSSPDBDLL.Services
{
    public class DocTemplateService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        public TVFileService _TVFileService { get; private set; }
        #endregion Properties

        #region Constructors
        public DocTemplateService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
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

        // Check
        public string DocTemplateModelOK(DocTemplateModel docTemplateModel)
        {
            string retStr = _BaseEnumService.LanguageOK(docTemplateModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(docTemplateModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(docTemplateModel.TVFileTVItemID, ServiceRes.TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(docTemplateModel.FileName, ServiceRes.FileName, 150);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(docTemplateModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillDocTemplate(DocTemplate docTemplate, DocTemplateModel docTemplateModel, ContactOK contactOK)
        {
            docTemplate.DBCommand = (int)docTemplateModel.DBCommand;
            docTemplate.Language = (int)docTemplateModel.Language;
            docTemplate.TVType = (int)docTemplateModel.TVType;
            docTemplate.TVFileTVItemID = docTemplateModel.TVFileTVItemID;
            docTemplate.FileName = docTemplateModel.FileName;
            docTemplate.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                docTemplate.LastUpdateContactTVItemID = 2;
            }
            else
            {
                docTemplate.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetDocTemplateModelCountDB()
        {
            int DocTemplateModelCount = (from c in db.DocTemplates
                                         select c).Count();

            return DocTemplateModelCount;
        }
        public DocTemplateModel GetDocTemplateModelWithTVFileTVItemIDDB(int TVFileTVItemID)
        {
            DocTemplateModel docTemplateModel = (from c in db.DocTemplates
                                                 where c.TVFileTVItemID == TVFileTVItemID
                                                 orderby c.TVType, c.FileName
                                                 select new DocTemplateModel
                                                 {
                                                     Error = "",
                                                     DocTemplateID = c.DocTemplateID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
                                                     Language = (LanguageEnum)c.Language,
                                                     TVType = (TVTypeEnum)c.TVType,
                                                     TVFileTVItemID = c.TVFileTVItemID,
                                                     FileName = c.FileName,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).FirstOrDefault<DocTemplateModel>();

            if (docTemplateModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DocTemplate, ServiceRes.TVFileTVItemID, TVFileTVItemID.ToString()));
            }

            return docTemplateModel;
        }
        public List<DocTemplateModel> GetDocTemplateModelListWithTVTypeDB(TVTypeEnum TVType)
        {
            List<DocTemplateModel> DocTemplateModelList = (from c in db.DocTemplates
                                                           where c.TVType == (int)TVType
                                                           orderby c.TVType, c.FileName
                                                           select new DocTemplateModel
                                                           {
                                                               Error = "",
                                                               DocTemplateID = c.DocTemplateID,
                                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                                               Language = (LanguageEnum)c.Language,
                                                               TVType = (TVTypeEnum)c.TVType,
                                                               TVFileTVItemID = c.TVFileTVItemID,
                                                               FileName = c.FileName,
                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                           }).ToList<DocTemplateModel>();

            return DocTemplateModelList;
        }
        public DocTemplateModel GetDocTemplateModelWithDocTemplateIDDB(int DocTemplateID)
        {
            DocTemplateModel docTemplateModel = (from c in db.DocTemplates
                                                 where c.DocTemplateID == DocTemplateID
                                                 orderby c.TVType, c.FileName
                                                 select new DocTemplateModel
                                                 {
                                                     Error = "",
                                                     DocTemplateID = c.DocTemplateID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
                                                     Language = (LanguageEnum)c.Language,
                                                     TVType = (TVTypeEnum)c.TVType,
                                                     TVFileTVItemID = c.TVFileTVItemID,
                                                     FileName = c.FileName,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).FirstOrDefault<DocTemplateModel>();

            if (docTemplateModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DocTemplate, ServiceRes.DocTemplateID, DocTemplateID.ToString()));
            }

            return docTemplateModel;
        }
        public DocTemplate GetDocTemplateWithDocTemplateIDDB(int DocTemplateID)
        {
            DocTemplate docTemplate = (from c in db.DocTemplates
                                       where c.DocTemplateID == DocTemplateID
                                       select c).FirstOrDefault<DocTemplate>();

            return docTemplate;
        }
        public DocTemplateModel GetDocTemplateModelExistDB(DocTemplateModel docTemplateModel)
        {
            DocTemplateModel docTemplateModelRet = (from c in db.DocTemplates
                                                    where c.TVType == (int)docTemplateModel.TVType
                                                    && c.FileName == docTemplateModel.FileName
                                                    select new DocTemplateModel
                                                    {
                                                        Error = "",
                                                        DocTemplateID = c.DocTemplateID,
                                                        DBCommand = (DBCommandEnum)c.DBCommand,
                                                        Language = (LanguageEnum)c.Language,
                                                        TVType = (TVTypeEnum)c.TVType,
                                                        TVFileTVItemID = c.TVFileTVItemID,
                                                        FileName = c.FileName,
                                                        LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                        LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                    }).FirstOrDefault<DocTemplateModel>();

            if (docTemplateModelRet == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DocTemplate, ServiceRes.TVType + "," + ServiceRes.FileName, docTemplateModel.TVType.ToString() + "," + docTemplateModel.FileName));
            }

            return docTemplateModelRet;
        }

        // Helper
        public DocTemplateModel ReturnError(string Error)
        {
            return new DocTemplateModel() { Error = Error };
        }
        public string GenerateFileNameForDocTemplate(int DocTemplateID, int ParentTVItemID, string LanguageRequest)
        {
            List<string> ReplaceTextListWithUnderscore = new List<string>() { "#", "%", "&", "{", "}", "\\", "<", ">", "*", "?", "/", " ", "$", "!", "'", "\"", ":", "@", "+", "`", "|", "=" };

            if (LanguageRequest == "fr")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");
            }

            DocTemplateModel docTemplateModel = GetDocTemplateModelWithDocTemplateIDDB(DocTemplateID);
            if (!string.IsNullOrWhiteSpace(docTemplateModel.Error))
                return "ERROR_" + docTemplateModel.Error.Replace(" ", "_");

            TVItemModel tvItemModelTemplateFile = _TVItemService.GetTVItemModelWithTVItemIDDB(docTemplateModel.TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelTemplateFile.Error))
                return "ERROR_" + tvItemModelTemplateFile.Error.Replace(" ", "_");

            TVItemModel tvItemModelParent = _TVItemService.GetTVItemModelWithTVItemIDDB(ParentTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                return "ERROR_" + tvItemModelParent.Error.Replace(" ", "_");

            TVFileModel tvFileModelTemplate = _TVFileService.GetTVFileModelWithTVFileTVItemIDDB(docTemplateModel.TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelTemplate.Error))
                return "ERROR_" + tvFileModelTemplate.Error.Replace(" ", "_");

            FileInfo fiTemplate = new FileInfo(_TVFileService.ChoseEDriveOrCDrive(_TVFileService.GetServerFilePath(tvItemModelTemplateFile.ParentID)) + tvFileModelTemplate.ServerFileName);

            if (!fiTemplate.Exists)
                return "ERROR_" + string.Format(ServiceRes.CouldNotFind_, fiTemplate.FullName).Replace(" ", "_");

            DateTime DateUtc = DateTime.UtcNow;
            string FileName = tvFileModelTemplate.ServerFileName.Replace(fiTemplate.Extension.ToLower(), "") + "_" + DateUtc.Year.ToString() + "_" +
                (DateUtc.Month < 10 ? "0" + DateUtc.Month.ToString() : DateUtc.Month.ToString()) + "_" +
                (DateUtc.Day < 10 ? "0" + DateUtc.Day.ToString() : DateUtc.Day.ToString()) + "_" +
                (DateUtc.Hour < 10 ? "0" + DateUtc.Hour.ToString() : DateUtc.Hour.ToString()) + "_" +
                (DateUtc.Minute < 10 ? "0" + DateUtc.Minute.ToString() : DateUtc.Minute.ToString()) + "_" +
                LanguageRequest + fiTemplate.Extension.ToLower();

            return FileName;
        }

        // Post
        //public DocTemplateModel DocTemplateAddOrModifyDB(FormCollection fc)
        //{
        //    int tempInt = 0;
        //    int DocTemplateID = 0;
        //    TVTypeEnum TVType = TVTypeEnum.Error;
        //    string FileName = "";

        //    ContactOK contactOK = IsContactOK();
        //    if (!string.IsNullOrWhiteSpace(contactOK.Error))
        //        return ReturnError(contactOK.Error);

        //    int.TryParse(fc["DocTemplateID"], out DocTemplateID);
        //    // can be 0 if adding a new DocTemplate

        //    int.TryParse(fc["TVType"], out tempInt);
        //    if (tempInt == 0)
        //        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVType));

        //    TVType = (TVTypeEnum)tempInt;

        //    FileName = fc["FileName"];
        //    if (string.IsNullOrWhiteSpace(FileName))
        //        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.FileName));

        //    TVItemModel TVItemRoot = _TVItemService.GetRootTVItemModelDB();
        //    if (!string.IsNullOrWhiteSpace(TVItemRoot.Error))
        //        return ReturnError(TVItemRoot.Error);

        //    DocTemplateModel docTemplateModel = new DocTemplateModel();
        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        string ObservationInfo = ((int)PolSourceObsInfoEnum.LandBased).ToString() + ",";
        //        List<int> obsIntList = ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        //        string ObservationLanguageTVText = ServiceRes.Error;
        //        string TVText = _BaseEnumService.GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum.Error);
        //        int NextSiteNumber = 0;

        //        if (DocTemplateID == 0)
        //        {

        //            DocTemplateModel docTemplateModelNew = new DocTemplateModel()
        //            {
        //                TVType = (int)TVType,
        //                FileName = FileName,
        //            };
        //            // Automatically add one Pollution Source Observation for today
        //            PolSourceObservationModel polSourceObservationModelNew = new PolSourceObservationModel()
        //            {
        //                PolSourceSiteTVItemID = polSourceSiteNewOrToChange.PolSourceSiteTVItemID,
        //                ObservationDate_Local = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
        //                ContactTVItemID = contactOK.ContactTVItemID,
        //                Observation_ToBeDeleted = "",
        //            };

        //            PolSourceObservationModel polSourceObservationModelRet = _PolSourceObservationService.PostAddPolSourceObservationDB(polSourceObservationModelNew);
        //            if (!string.IsNullOrWhiteSpace(polSourceObservationModelRet.Error))
        //                return ReturnError(polSourceObservationModelRet.Error);

        //            // Automatically add one Pollution Source Observation Issue
        //            PolSourceObservationIssueModel polSourceObservationIssueModelNew = new PolSourceObservationIssueModel();
        //            polSourceObservationIssueModelNew.PolSourceObservationID = polSourceObservationModelRet.PolSourceObservationID;
        //            polSourceObservationIssueModelNew.ObservationInfo = ObservationInfo;
        //            polSourceObservationIssueModelNew.Ordinal = 0;

        //            PolSourceObservationIssueModel polSourceObservationIssueModelRet = _PolSourceObservationService._PolSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelNew);
        //            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
        //                return ReturnError(polSourceObservationIssueModelRet.Error);

        //            // doing the other language
        //            foreach (string lang in LanguageListAllowable.Where(c => c != LanguageRequest))
        //            {
        //                TVItemService tvItemService = new TVItemService(lang, _TVItemService.User);
        //                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
        //                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

        //                ObservationInfo = ((int)PolSourceObsInfoEnum.LandBased).ToString() + ",";
        //                ObservationLanguageTVText = ServiceRes.Error;
        //                TVText = _BaseEnumService.GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum.Error);

        //                TVText = (string.IsNullOrWhiteSpace(TVText) ? ServiceRes.Error : TVText);

        //                if (PolSourceSiteTVItemID == 0)
        //                {
        //                    TVText = TVText + " - " + "000000".Substring(0, "000000".Length - NextSiteNumber.ToString().Length) + NextSiteNumber.ToString();
        //                }
        //                else
        //                {
        //                    TVText = TVText + " - " + "000000".Substring(0, "000000".Length - polSourceSiteNewOrToChange.Site.ToString().Length) + polSourceSiteNewOrToChange.Site.ToString();
        //                }

        //                TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
        //                tvItemLanguageModel.Language = lang;
        //                tvItemLanguageModel.TVText = TVText;
        //                tvItemLanguageModel.TVItemID = polSourceSiteNewOrToChange.PolSourceSiteTVItemID;

        //                TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
        //                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
        //                    return ReturnError(tvItemLanguageModelRet.Error);

        //                Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
        //                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
        //            }
        //        }
        //        else
        //        {
        //            polSourceSiteNewOrToChange = PostUpdatePolSourceSiteDB(polSourceSiteNewOrToChange);
        //            if (!string.IsNullOrWhiteSpace(polSourceSiteNewOrToChange.Error))
        //                return ReturnError(polSourceSiteNewOrToChange.Error);

        //        }

        //        // Adding map info
        //        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(polSourceSiteNewOrToChange.PolSourceSiteTVItemID, TVTypeEnum.PolSourceSite, MapInfoDrawTypeEnum.Point);
        //        if (mapInfoPointModelList.Count == 0)
        //        {
        //            MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.PolSourceSite, polSourceSiteNewOrToChange.PolSourceSiteTVItemID);
        //            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
        //                return ReturnError(mapInfoModelRet.Error);
        //        }
        //        else
        //        {
        //            mapInfoPointModelList[0].Lat = coordList[0].Lat;
        //            mapInfoPointModelList[0].Lng = coordList[0].Lng;

        //            MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
        //            if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
        //                return ReturnError(mapInfoPointModelRet.Error);
        //        }

        //        TVItemModel tvItemModelPolSourceSite = _TVItemService.GetTVItemModelWithTVItemIDDB(polSourceSiteNewOrToChange.PolSourceSiteTVItemID);
        //        if (!string.IsNullOrWhiteSpace(tvItemModelPolSourceSite.Error))
        //            return ReturnError(tvItemModelPolSourceSite.Error);

        //        tvItemModelPolSourceSite.IsActive = IsActive;

        //        TVItemModel tvItemModelRet = _TVItemService.PostUpdateTVItemDB(tvItemModelPolSourceSite);
        //        if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
        //            return ReturnError(tvItemModelRet.Error);

        //        ts.Complete();
        //    }
        //    return polSourceSiteNewOrToChange;
        //}

        public DocTemplateModel PostAddDocTemplateDB(DocTemplateModel docTemplateModel)
        {
            string retStr = DocTemplateModelOK(docTemplateModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithTVFileTVItemIDDB(docTemplateModel.TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
                return ReturnError(tvFileModel.Error);

            DocTemplateModel docTemplateModelExist = GetDocTemplateModelExistDB(docTemplateModel);
            if (string.IsNullOrWhiteSpace(docTemplateModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.DocTemplate));

            DocTemplate docTemplateNew = new DocTemplate();
            retStr = FillDocTemplate(docTemplateNew, docTemplateModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.DocTemplates.Add(docTemplateNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DocTemplates", docTemplateNew.DocTemplateID, LogCommandEnum.Add, docTemplateNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDocTemplateModelWithDocTemplateIDDB(docTemplateNew.DocTemplateID);
        }
        public DocTemplateModel PostDeleteDocTemplateWithDocTemplateIDDB(int DocTemplateID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DocTemplate docTemplateToDelete = GetDocTemplateWithDocTemplateIDDB(DocTemplateID);
            if (docTemplateToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.DocTemplate));

            int TVFileTVItemID = docTemplateToDelete.TVFileTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.DocTemplates.Remove(docTemplateToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DocTemplates", docTemplateToDelete.DocTemplateID, LogCommandEnum.Delete, docTemplateToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public DocTemplateModel PostDeleteDocTemplateWithTVFileTVItemIDDB(int TVFileTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DocTemplateModel docTemplateModelToDelete = GetDocTemplateModelWithTVFileTVItemIDDB(TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(docTemplateModelToDelete.Error))
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.DocTemplate));

            return PostDeleteDocTemplateWithDocTemplateIDDB(docTemplateModelToDelete.DocTemplateID);
        }
        public DocTemplateModel PostUpdateDocTemplateDB(DocTemplateModel docTemplateModel)
        {
            string retStr = DocTemplateModelOK(docTemplateModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithTVFileTVItemIDDB(docTemplateModel.TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
                return ReturnError(tvFileModel.Error);

            DocTemplate docTemplateToUpdate = GetDocTemplateWithDocTemplateIDDB(docTemplateModel.DocTemplateID);
            if (docTemplateToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.DocTemplate));

            retStr = FillDocTemplate(docTemplateToUpdate, docTemplateModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                if (tvFileModel.ServerFileName != docTemplateModel.FileName)
                {
                    tvFileModel.ServerFileName = docTemplateModel.FileName;

                    TVFileModel tvFileModelRet = _TVFileService.PostUpdateTVFileDB(tvFileModel);
                    if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
                        return ReturnError(tvFileModelRet.Error);
                }

                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DocTemplates", docTemplateToUpdate.DocTemplateID, LogCommandEnum.Change, docTemplateToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDocTemplateModelWithDocTemplateIDDB(docTemplateToUpdate.DocTemplateID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
