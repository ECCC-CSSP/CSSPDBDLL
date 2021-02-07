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
    public class ClassificationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ClassificationService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
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
        public string ClassificationModelOK(ClassificationModel classificationModel)
        {
            string retStr = FieldCheckNotZeroInt(classificationModel.ClassificationTVItemID, ServiceRes.ClassificationTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(classificationModel.ClassificationTVText, ServiceRes.ClassificationTVText, 3, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.ClassificationTypeOK(classificationModel.ClassificationType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(classificationModel.Ordinal, ServiceRes.Ordinal, 0, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(classificationModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillClassification(Classification Classification, ClassificationModel ClassificationModel, ContactOK contactOK)
        {
            Classification.DBCommand = (int)ClassificationModel.DBCommand;
            Classification.ClassificationTVItemID = ClassificationModel.ClassificationTVItemID;
            Classification.ClassificationType = (int)ClassificationModel.ClassificationType;
            Classification.Ordinal = ClassificationModel.Ordinal;
            Classification.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                Classification.LastUpdateContactTVItemID = 2;
            }
            else
            {
                Classification.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetClassificationModelCountDB()
        {
            int ClassificationModelCount = (from c in db.Classifications
                                            select c).Count();

            return ClassificationModelCount;
        }
        public List<ClassificationModel> GetClassificationModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<ClassificationModel> ClassificationModelList = (from c in db.TVItems
                                                                 from p in db.Classifications
                                                                 let classTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == p.ClassificationTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                 where c.ParentID == SubsectorTVItemID
                                                                 && c.TVItemID == p.ClassificationTVItemID
                                                                 select new ClassificationModel
                                                                 {
                                                                     Error = "",
                                                                     ClassificationID = p.ClassificationID,
                                                                     DBCommand = (DBCommandEnum)p.DBCommand,
                                                                     ClassificationTVItemID = p.ClassificationTVItemID,
                                                                     ClassificationTVText = classTVText,
                                                                     ClassificationType = (ClassificationTypeEnum)p.ClassificationType,
                                                                     Ordinal = p.Ordinal,
                                                                     LastUpdateDate_UTC = p.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = p.LastUpdateContactTVItemID,
                                                                 }).ToList<ClassificationModel>();

            return ClassificationModelList;
        }
        public ClassificationModel GetClassificationModelWithClassificationIDDB(int ClassificationID)
        {
            ClassificationModel ClassificationModel = (from c in db.Classifications
                                                       let classTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.ClassificationTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       where c.ClassificationID == ClassificationID
                                                       select new ClassificationModel
                                                       {
                                                           Error = "",
                                                           ClassificationID = c.ClassificationID,
                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                           ClassificationTVItemID = c.ClassificationTVItemID,
                                                           ClassificationTVText = classTVText,
                                                           ClassificationType = (ClassificationTypeEnum)c.ClassificationType,
                                                           Ordinal = c.Ordinal,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<ClassificationModel>();

            if (ClassificationModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Classification, ServiceRes.ClassificationID, ClassificationID));
            }

            return ClassificationModel;
        }
        public ClassificationModel GetClassificationModelWithClassificationTVItemIDDB(int ClassificationTVItemID)
        {
            ClassificationModel ClassificationModel = (from c in db.Classifications
                                                       let classTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.ClassificationTVItemID select cl.TVText).FirstOrDefault<string>()
                                                       where c.ClassificationTVItemID == ClassificationTVItemID
                                                       select new ClassificationModel
                                                       {
                                                           Error = "",
                                                           ClassificationID = c.ClassificationID,
                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                           ClassificationTVItemID = c.ClassificationTVItemID,
                                                           ClassificationTVText = classTVText,
                                                           ClassificationType = (ClassificationTypeEnum)c.ClassificationType,
                                                           Ordinal = c.Ordinal,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<ClassificationModel>();

            if (ClassificationModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Classification, ServiceRes.ClassificationTVItemID, ClassificationTVItemID));
            }

            return ClassificationModel;
        }
        public Classification GetClassificationWithClassificationWithClassificationTVItemIDDB(int ClassificationTVItemID)
        {
            Classification Classification = (from c in db.Classifications
                                             where c.ClassificationTVItemID == ClassificationTVItemID
                                             select c).FirstOrDefault<Classification>();

            return Classification;
        }
        public Classification GetClassificationWithClassificationIDDB(int ClassificationID)
        {
            Classification Classification = (from c in db.Classifications
                                             where c.ClassificationID == ClassificationID
                                             select c).FirstOrDefault<Classification>();

            return Classification;
        }
        public int GetNextAvailableOrdinalNumberWithParentTVItemIDDB(int ParentTVItemID)
        {
            int NextAvailableSiteNumber = 1;
            Classification Classification = (from c in db.TVItems
                                             from p in db.Classifications
                                             where c.TVItemID == p.ClassificationTVItemID
                                             && c.ParentID == ParentTVItemID
                                             orderby p.Ordinal descending
                                             select p).FirstOrDefault<Classification>();

            if (Classification != null)
            {
                NextAvailableSiteNumber = (int)Classification.Ordinal + 1;
            }

            return NextAvailableSiteNumber;
        }

        // Helper
        public string CreateTVText(ClassificationModel ClassificationModel)
        {
            return ClassificationModel.ClassificationTVText;
        }
        public bool GetIsItSameObject(ClassificationModel ClassificationModel, TVItemModel tvItemModelClassificationExit)
        {
            bool IsSame = false;
            if (ClassificationModel.ClassificationTVItemID == tvItemModelClassificationExit.TVItemID)
            {
                IsSame = true;
            }

            return IsSame;
        }
        public ClassificationModel ReturnError(string Error)
        {
            return new ClassificationModel() { Error = Error };
        }

        // Post
        //public ClassificationModel ClassificationAddOrModifyDB(FormCollection fc)
        //{
        //    int tempInt = 0;
        //    int ParentTVItemID = 0;
        //    int ClassificationTVItemID = 0;
        //    bool IsActive = false;
        //    bool IsPointSource = false;
        //    double Lat = 0.0D;
        //    double Lng = 0.0D;

        //    ContactOK contactOK = IsContactOK();
        //    if (!string.IsNullOrWhiteSpace(contactOK.Error))
        //        return ReturnError(contactOK.Error);

        //    if (string.IsNullOrWhiteSpace(fc["ParentTVItemID"]))
        //        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

        //    int.TryParse(fc["ParentTVItemID"], out ParentTVItemID);
        //    if (ParentTVItemID == 0)
        //        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

        //    if (string.IsNullOrWhiteSpace(fc["ClassificationTVItemID"]))
        //        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ClassificationTVItemID));

        //    int.TryParse(fc["ClassificationTVItemID"], out ClassificationTVItemID);

        //    // ClassificationTVItemID == 0 ==> Add 
        //    // ClassificationTVItemID > 0 ==> Modify

        //    TVItemModel tvItemModelPolSource = null;
        //    if (ClassificationTVItemID != 0)
        //    {
        //        tvItemModelPolSource = _TVItemService.GetTVItemModelWithTVItemIDDB(ClassificationTVItemID);
        //        if (!string.IsNullOrWhiteSpace(tvItemModelPolSource.Error))
        //            return ReturnError(tvItemModelPolSource.Error);
        //    }

        //    ClassificationModel ClassificationNewOrToChange = new ClassificationModel();

        //    if (ClassificationTVItemID != 0)
        //    {
        //        ClassificationNewOrToChange = GetClassificationModelWithClassificationTVItemIDDB(ClassificationTVItemID);
        //        if (!string.IsNullOrWhiteSpace(ClassificationNewOrToChange.Error))
        //            return ReturnError(ClassificationNewOrToChange.Error);
        //    }

        //    if (string.IsNullOrWhiteSpace(fc["IsActive"]))
        //        IsActive = false;
        //    else
        //        IsActive = true;

        //    if (!IsActive)
        //    {
        //        int.TryParse(fc["InactiveReason"], out tempInt);
        //        if (tempInt == 0)
        //            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InactiveReason));

        //        ClassificationNewOrToChange.InactiveReason = (PolSourceInactiveReasonEnum)tempInt;
        //    }
        //    else
        //    {
        //        ClassificationNewOrToChange.InactiveReason = null;
        //    }

        //    if (string.IsNullOrWhiteSpace(fc["IsPointSource"]))
        //        IsPointSource = false;
        //    else
        //        IsPointSource = true;

        //    ClassificationNewOrToChange.IsPointSource = IsPointSource;

        //    double.TryParse(fc["Lat"], out Lat);
        //    if (Lat == 0.0D)
        //        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lat));

        //    double.TryParse(fc["Lng"], out Lng);
        //    if (Lng == 0.0D)
        //        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lng));

        //    List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)Lat, Lng = (float)Lng, Ordinal = 0 } };

        //    using (TransactionScope ts = new TransactionScope())
        //    {
        //        string ObservationInfo = ((int)PolSourceObsInfoEnum.SourceStart).ToString() + ",";
        //        List<int> obsIntList = ObservationInfo.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
        //        string ObservationLanguageTVText = ServiceRes.Error;
        //        string TVText = _BaseEnumService.GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum.Error);
        //        int NextSiteNumber = 0;

        //        if (ClassificationTVItemID == 0)
        //        {
        //            NextSiteNumber = GetNextAvailableSiteNumberWithParentTVItemIDDB(ParentTVItemID);

        //            ClassificationNewOrToChange.Site = NextSiteNumber;

        //            TVText = TVText + " - " + "000000".Substring(0, "000000".Length - NextSiteNumber.ToString().Length) + NextSiteNumber.ToString();

        //            TVItemModel tvItemModelNewClassification = _TVItemService.PostAddChildTVItemDB(ParentTVItemID, TVText, TVTypeEnum.Classification);
        //            if (!string.IsNullOrWhiteSpace(tvItemModelNewClassification.Error))
        //                return ReturnError(tvItemModelNewClassification.Error);

        //            ClassificationNewOrToChange.ClassificationTVItemID = tvItemModelNewClassification.TVItemID;
        //            ClassificationNewOrToChange.ClassificationTVText = TVText;

        //            ClassificationNewOrToChange = PostAddClassificationDB(ClassificationNewOrToChange);
        //            if (!string.IsNullOrWhiteSpace(ClassificationNewOrToChange.Error))
        //                return ReturnError(ClassificationNewOrToChange.Error);

        //            // Automatically add one Pollution Source Observation for today
        //            PolSourceObservationModel polSourceObservationModelNew = new PolSourceObservationModel()
        //            {
        //                ClassificationID = ClassificationNewOrToChange.ClassificationID,
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
        //            foreach (LanguageEnum lang in LanguageListAllowable.Where(c => c != LanguageRequest))
        //            {
        //                TVItemService tvItemService = new TVItemService(lang, _TVItemService.User);
        //                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang + "-CA");
        //                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang + "-CA");

        //                ObservationInfo = ((int)PolSourceObsInfoEnum.SourceStart).ToString() + ",";
        //                ObservationLanguageTVText = ServiceRes.Error;
        //                TVText = _BaseEnumService.GetEnumText_PolSourceObsInfoTextEnum(PolSourceObsInfoEnum.Error);

        //                TVText = (string.IsNullOrWhiteSpace(TVText) ? ServiceRes.Error : TVText);

        //                if (ClassificationTVItemID == 0)
        //                {
        //                    TVText = TVText + " - " + "000000".Substring(0, "000000".Length - NextSiteNumber.ToString().Length) + NextSiteNumber.ToString();
        //                }
        //                else
        //                {
        //                    TVText = TVText + " - " + "000000".Substring(0, "000000".Length - ClassificationNewOrToChange.Site.ToString().Length) + ClassificationNewOrToChange.Site.ToString();
        //                }

        //                TVItemLanguageModel tvItemLanguageModel = new TVItemLanguageModel();
        //                tvItemLanguageModel.Language = lang;
        //                tvItemLanguageModel.TVText = TVText;
        //                tvItemLanguageModel.TVItemID = ClassificationNewOrToChange.ClassificationTVItemID;

        //                TVItemLanguageModel tvItemLanguageModelRet = tvItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
        //                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
        //                    return ReturnError(tvItemLanguageModelRet.Error);

        //                Thread.CurrentThread.CurrentCulture = new CultureInfo(LanguageRequest + "-CA");
        //                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageRequest + "-CA");
        //            }
        //        }
        //        else
        //        {
        //            ClassificationNewOrToChange = PostUpdateClassificationDB(ClassificationNewOrToChange);
        //            if (!string.IsNullOrWhiteSpace(ClassificationNewOrToChange.Error))
        //                return ReturnError(ClassificationNewOrToChange.Error);

        //        }

        //        // Adding map info
        //        List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(ClassificationNewOrToChange.ClassificationTVItemID, TVTypeEnum.Classification, MapInfoDrawTypeEnum.Point);
        //        if (mapInfoPointModelList.Count == 0)
        //        {
        //            MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Classification, ClassificationNewOrToChange.ClassificationTVItemID);
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

        //        TVItemModel tvItemModelClassification = _TVItemService.GetTVItemModelWithTVItemIDDB(ClassificationNewOrToChange.ClassificationTVItemID);
        //        if (!string.IsNullOrWhiteSpace(tvItemModelClassification.Error))
        //            return ReturnError(tvItemModelClassification.Error);

        //        tvItemModelClassification.IsActive = IsActive;

        //        TVItemModel tvItemModelRet = _TVItemService.PostUpdateTVItemDB(tvItemModelClassification);
        //        if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
        //            return ReturnError(tvItemModelRet.Error);

        //        ts.Complete();
        //    }
        //    return ClassificationNewOrToChange;
        //}
        public ClassificationModel PostAddClassificationDB(ClassificationModel ClassificationModel)
        {
            string retStr = ClassificationModelOK(ClassificationModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(ClassificationModel.ClassificationTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            Classification ClassificationNew = new Classification();
            retStr = FillClassification(ClassificationNew, ClassificationModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return new ClassificationModel() { Error = retStr };
            }

            using (TransactionScope ts = new TransactionScope())
            {
                db.Classifications.Add(ClassificationNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Classifications", ClassificationNew.ClassificationID, LogCommandEnum.Add, ClassificationNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetClassificationModelWithClassificationIDDB(ClassificationNew.ClassificationID);
        }
        public ClassificationModel PostDeleteClassificationDB(int ClassificationID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Classification ClassificationToDelete = GetClassificationWithClassificationIDDB(ClassificationID);
            if (ClassificationToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Classification));

            int TVItemIDToDelete = ClassificationToDelete.ClassificationTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.Classifications.Remove(ClassificationToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Classifications", ClassificationToDelete.ClassificationID, LogCommandEnum.Delete, ClassificationToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                try
                {
                    TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                }
                catch (Exception)
                {
                    // nothing
                }

                ts.Complete();
            }
            return ReturnError("");
        }
        public ClassificationModel PostDeleteClassificationWithClassificationTVItemIDDB(int ClassificationTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Classification ClassificationToDelete = GetClassificationWithClassificationWithClassificationTVItemIDDB(ClassificationTVItemID);
            if (ClassificationToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Classification));

            ClassificationModel ClassificationModelRet = PostDeleteClassificationDB(ClassificationToDelete.ClassificationID);
            if (!string.IsNullOrWhiteSpace(ClassificationModelRet.Error))
                return ReturnError(ClassificationModelRet.Error);

            return ReturnError("");
        }
        public ClassificationModel PostUpdateClassificationDB(ClassificationModel ClassificationModel)
        {
            string retStr = ClassificationModelOK(ClassificationModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Classification ClassificationToUpdate = GetClassificationWithClassificationIDDB(ClassificationModel.ClassificationID);
            if (ClassificationToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Classification));

            retStr = FillClassification(ClassificationToUpdate, ClassificationModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Classifications", ClassificationToUpdate.ClassificationID, LogCommandEnum.Change, ClassificationToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetClassificationModelWithClassificationIDDB(ClassificationToUpdate.ClassificationID);
        }
        public ClassificationModel ClassificationSetActiveDB(int TVItemID, bool SetActive)
        {
            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                return new ClassificationModel() { Error = tvItemModel.Error };
            }

            tvItemModel.IsActive = SetActive;
            TVItemModel tvItemModelRet = _TVItemService.PostUpdateTVItemDB(tvItemModel);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return new ClassificationModel() { Error = tvItemModelRet.Error };
            }

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}