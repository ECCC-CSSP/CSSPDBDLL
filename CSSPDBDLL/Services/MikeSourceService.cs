using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class MikeSourceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public MapInfoService _MapInfoService { get; private set; }
        public MikeSourceStartEndService _MikeSourceStartEndService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public TVFileService _TVFileService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MikeSourceService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _MikeSourceStartEndService = new MikeSourceStartEndService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
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
        public string MikeSourceModelOK(MikeSourceModel mikeSourceModel)
        {
            string retStr = FieldCheckNotZeroInt(mikeSourceModel.MikeSourceTVItemID, ServiceRes.MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mikeSourceModel.MikeSourceTVText, ServiceRes.MikeSourceTVText, 3, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(mikeSourceModel.IsContinuous, ServiceRes.IsContinuous);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(mikeSourceModel.Include, ServiceRes.Include);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(mikeSourceModel.IsRiver, ServiceRes.IsRiver);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(mikeSourceModel.UseHydrometric, ServiceRes.UseHydrometric);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(mikeSourceModel.HydrometricTVItemID, ServiceRes.HydrometricTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mikeSourceModel.DrainageArea_km2, ServiceRes.DrainageArea_km2, 0.0f, 100000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mikeSourceModel.Factor, ServiceRes.Factor, 0.0f, 1000.0f);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mikeSourceModel.SourceNumberString, ServiceRes.SourceNumberString, 3, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }
        public string CheckIfSourceNameIsUniqueDB(int MikeScenarioTVItemID, string SourceName)
        {
            TVItemModel tvItemModelMikeScenario = _TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenario.Error))
                return tvItemModelMikeScenario.Error;

            MikeSourceModel mikeSourceModel = new MikeSourceModel();
            mikeSourceModel.MikeSourceTVText = SourceName;
            string TVText = CreateTVText(mikeSourceModel);
            if (string.IsNullOrWhiteSpace(TVText))
                return string.Format(ServiceRes._IsRequired, ServiceRes.TVText);

            TVItemModel tvItemModelExist = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelMikeScenario.TVItemID, TVText, TVTypeEnum.MikeSource);
            if (string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return string.Format(ServiceRes._HasToBeUnique, ServiceRes.SourceName);
            else
                return "true";
        }

        // Fill
        public string FillMikeSource(MikeSource mikeSource, MikeSourceModel mikeSourceModel, ContactOK contactOK)
        {
            mikeSource.MikeSourceTVItemID = mikeSourceModel.MikeSourceTVItemID;
            mikeSource.Include = mikeSourceModel.Include;
            mikeSource.IsContinuous = mikeSourceModel.IsContinuous;
            mikeSource.IsRiver = mikeSourceModel.IsRiver;
            mikeSource.UseHydrometric = mikeSourceModel.UseHydrometric;
            mikeSource.HydrometricTVItemID = mikeSourceModel.HydrometricTVItemID;
            mikeSource.DrainageArea_km2 = mikeSourceModel.DrainageArea_km2;
            mikeSource.Factor = mikeSourceModel.Factor;
            mikeSource.SourceNumberString = mikeSourceModel.SourceNumberString;
            mikeSource.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mikeSource.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mikeSource.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMikeSourceModelCountDB()
        {
            return (from c in db.MikeSources
                    select c).Count();
        }
        public List<MikeSourceModel> GetMikeSourceModelAndMikeSourceStartEndModelListWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            List<MikeSourceModel> mikeSourceModelList = (from c in db.TVItems
                                                         from m in db.MikeSources
                                                         let sourceName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == m.MikeSourceTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let sourceStartEndModelList = (from mse in db.MikeSourceStartEnds
                                                                                        where m.MikeSourceID == mse.MikeSourceID
                                                                                        orderby mse.StartDateAndTime_Local
                                                                                        select new MikeSourceStartEndModel
                                                                                        {
                                                                                            Error = "",
                                                                                            MikeSourceStartEndID = mse.MikeSourceStartEndID,
                                                                                            MikeSourceID = mse.MikeSourceID,
                                                                                            StartDateAndTime_Local = mse.StartDateAndTime_Local,
                                                                                            EndDateAndTime_Local = mse.EndDateAndTime_Local,
                                                                                            SourceFlowStart_m3_day = mse.SourceFlowStart_m3_day,
                                                                                            SourceFlowEnd_m3_day = mse.SourceFlowEnd_m3_day,
                                                                                            SourcePollutionStart_MPN_100ml = mse.SourcePollutionStart_MPN_100ml,
                                                                                            SourcePollutionEnd_MPN_100ml = mse.SourcePollutionEnd_MPN_100ml,
                                                                                            SourceSalinityStart_PSU = mse.SourceSalinityStart_PSU,
                                                                                            SourceSalinityEnd_PSU = mse.SourceSalinityEnd_PSU,
                                                                                            SourceTemperatureStart_C = mse.SourceTemperatureStart_C,
                                                                                            SourceTemperatureEnd_C = mse.SourceTemperatureEnd_C,
                                                                                            LastUpdateDate_UTC = mse.LastUpdateDate_UTC,
                                                                                            LastUpdateContactTVItemID = mse.LastUpdateContactTVItemID
                                                                                        }).ToList()
                                                         where c.TVItemID == m.MikeSourceTVItemID
                                                         && c.ParentID == MikeScenarioTVItemID
                                                         orderby sourceName
                                                         select new MikeSourceModel
                                                         {
                                                             Error = "",
                                                             MikeSourceID = m.MikeSourceID,
                                                             MikeSourceTVText = sourceName,
                                                             Include = m.Include,
                                                             IsContinuous = m.IsContinuous,
                                                             IsRiver = m.IsRiver,
                                                             UseHydrometric = m.UseHydrometric,
                                                             HydrometricTVItemID = m.HydrometricTVItemID,
                                                             DrainageArea_km2 = m.DrainageArea_km2,
                                                             Factor = m.Factor,
                                                             SourceNumberString = m.SourceNumberString,
                                                             MikeSourceTVItemID = m.MikeSourceTVItemID,
                                                             MikeSourceStartEndModelList = sourceStartEndModelList,
                                                             LastUpdateDate_UTC = m.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = m.LastUpdateContactTVItemID
                                                         }).ToList<MikeSourceModel>();

            foreach (MikeSourceModel mikeSourceModel in mikeSourceModelList)
            {
                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mikeSourceModel.MikeSourceTVItemID, TVTypeEnum.MikeSource, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count > 0)
                {
                    mikeSourceModel.Lat = (float)mapInfoPointModelList[0].Lat;
                    mikeSourceModel.Lng = (float)mapInfoPointModelList[0].Lng;
                }
            }

            return mikeSourceModelList;
        }
        public List<MikeSourceModel> GetMikeSourceModelListWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            List<MikeSourceModel> mikeSourceModelList = (from c in db.TVItems
                                                         from m in db.MikeSources
                                                         let sourceName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == m.MikeSourceTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         where c.TVItemID == m.MikeSourceTVItemID
                                                         && c.ParentID == MikeScenarioTVItemID
                                                         orderby sourceName
                                                         select new MikeSourceModel
                                                         {
                                                             Error = "",
                                                             MikeSourceID = m.MikeSourceID,
                                                             MikeSourceTVText = sourceName,
                                                             Include = m.Include,
                                                             IsContinuous = m.IsContinuous,
                                                             IsRiver = m.IsRiver,
                                                             UseHydrometric = m.UseHydrometric,
                                                             HydrometricTVItemID = m.HydrometricTVItemID,
                                                             DrainageArea_km2 = m.DrainageArea_km2,
                                                             Factor = m.Factor,
                                                             SourceNumberString = m.SourceNumberString,
                                                             MikeSourceTVItemID = m.MikeSourceTVItemID,
                                                             LastUpdateDate_UTC = m.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = m.LastUpdateContactTVItemID
                                                         }).ToList<MikeSourceModel>();

            foreach (MikeSourceModel mikeSourceModel in mikeSourceModelList)
            {
                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mikeSourceModel.MikeSourceTVItemID, TVTypeEnum.MikeSource, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count > 0)
                {
                    mikeSourceModel.Lat = (float)mapInfoPointModelList[0].Lat;
                    mikeSourceModel.Lng = (float)mapInfoPointModelList[0].Lng;
                }
            }

            return mikeSourceModelList;
        }
        public MikeSourceModel GetMikeSourceModelWithMikeSourceIDDB(int MikeSourceID)
        {
            MikeSourceModel mikeSourceModel = (from c in db.MikeSources
                                               let sourceName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MikeSourceTVItemID select cl.TVText).FirstOrDefault<string>()
                                               where c.MikeSourceID == MikeSourceID
                                               select new MikeSourceModel
                                               {
                                                   Error = "",
                                                   MikeSourceID = c.MikeSourceID,
                                                   MikeSourceTVText = sourceName,
                                                   Include = c.Include,
                                                   IsContinuous = c.IsContinuous,
                                                   IsRiver = c.IsRiver,
                                                   UseHydrometric = c.UseHydrometric,
                                                   HydrometricTVItemID = c.HydrometricTVItemID,
                                                   DrainageArea_km2 = c.DrainageArea_km2,
                                                   Factor = c.Factor,
                                                   SourceNumberString = c.SourceNumberString,
                                                   MikeSourceTVItemID = c.MikeSourceTVItemID,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                               }).FirstOrDefault<MikeSourceModel>();

            if (mikeSourceModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeSource, ServiceRes.MikeSourceID, MikeSourceID));
            }
            else
            {
                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mikeSourceModel.MikeSourceTVItemID, TVTypeEnum.MikeSource, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count > 0)
                {
                    mikeSourceModel.Lat = (float)mapInfoPointModelList[0].Lat;
                    mikeSourceModel.Lng = (float)mapInfoPointModelList[0].Lng;
                }
            }
            return mikeSourceModel;
        }
        public MikeSourceModel GetMikeSourceModelWithMikeSourceTVItemIDDB(int MikeSourceTVItemID)
        {
            MikeSourceModel mikeSourceModel = (from c in db.MikeSources
                                               let sourceName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MikeSourceTVItemID select cl.TVText).FirstOrDefault<string>()
                                               where c.MikeSourceTVItemID == MikeSourceTVItemID
                                               select new MikeSourceModel
                                               {
                                                   Error = "",
                                                   MikeSourceID = c.MikeSourceID,
                                                   MikeSourceTVText = sourceName,
                                                   Include = c.Include,
                                                   IsContinuous = c.IsContinuous,
                                                   IsRiver = c.IsRiver,
                                                   UseHydrometric = c.UseHydrometric,
                                                   HydrometricTVItemID = c.HydrometricTVItemID,
                                                   DrainageArea_km2 = c.DrainageArea_km2,
                                                   Factor = c.Factor,
                                                   SourceNumberString = c.SourceNumberString,
                                                   MikeSourceTVItemID = c.MikeSourceTVItemID,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                               }).FirstOrDefault<MikeSourceModel>();

            if (mikeSourceModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeSource, ServiceRes.MikeSourceTVItemID, MikeSourceTVItemID));
            }
            else
            {
                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mikeSourceModel.MikeSourceTVItemID, TVTypeEnum.MikeSource, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count > 0)
                {
                    mikeSourceModel.Lat = (float)mapInfoPointModelList[0].Lat;
                    mikeSourceModel.Lng = (float)mapInfoPointModelList[0].Lng;
                }
            }

            return mikeSourceModel;
        }
        public MikeSource GetMikeSourceWithMikeSourceIDDB(int MikeSourceID)
        {
            MikeSource mikeSource = (from c in db.MikeSources
                                     where c.MikeSourceID == MikeSourceID
                                     select c).FirstOrDefault<MikeSource>();

            return mikeSource;
        }

        // Helper
        public string CreateTVText(MikeSourceModel mikeSourceModel)
        {
            return mikeSourceModel.MikeSourceTVText;
        }
        public bool GetIsItSameObject(MikeSourceModel mikeSourceModel, TVItemModel tvItemModelMikeSourceExit)
        {
            bool IsSame = false;
            if (mikeSourceModel.MikeSourceTVItemID == tvItemModelMikeSourceExit.TVItemID)
            {
                IsSame = true;
            }

            return IsSame;
        }
        public MikeSourceModel ReturnError(string Error)
        {
            return new MikeSourceModel() { Error = Error };
        }

        // Post
        public MikeSourceModel PostAddMikeSourceDB(MikeSourceModel mikeSourceModel)
        {
            string retStr = MikeSourceModelOK(mikeSourceModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExit = _TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExit.Error))
                return ReturnError(tvItemModelExit.Error);

            MikeSource mikeSourceNew = new MikeSource();
            retStr = FillMikeSource(mikeSourceNew, mikeSourceModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MikeSources.Add(mikeSourceNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeSources", mikeSourceNew.MikeSourceID, LogCommandEnum.Add, mikeSourceNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMikeSourceModelWithMikeSourceIDDB(mikeSourceNew.MikeSourceID);
        }
        public MikeSourceModel PostDeleteMikeSourceDB(int MikeSourceID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MikeSource mikeSourceToDelete = GetMikeSourceWithMikeSourceIDDB(MikeSourceID);
            if (mikeSourceToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeSource));

            int TVItemIDToDelete = mikeSourceToDelete.MikeSourceTVItemID;

            int SourceNumber = int.Parse(mikeSourceToDelete.SourceNumberString.Substring("SOURCE_".Length));

            TVItemModel tvItemModelMikeSource = _TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceToDelete.MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeSource.Error))
                return ReturnError(tvItemModelMikeSource.Error);

            int MikeScenarioTVItemID = tvItemModelMikeSource.ParentID;

            TVItemModel tvItemModelMikeScenario = _TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenario.Error))
                return ReturnError(tvItemModelMikeScenario.Error);

            string ServerPath = _TVFileService.GetServerFilePath(MikeScenarioTVItemID);

            string ServerFileNameConc = $"{ tvItemModelMikeSource.TVText}_PollutionConcentration.dfs0";

            TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithServerFilePathAndServerFileNameDB(ServerPath, ServerFileNameConc);
            if (string.IsNullOrWhiteSpace(tvFileModel.Error))
            {
                TVFileModel tvFileModelRet = _TVFileService.PostDeleteTVFileDB(tvFileModel.TVFileID);
                if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
                    return ReturnError(tvFileModelRet.Error);
            }

            string ServerFileNameDischarge = $"{ tvItemModelMikeSource.TVText}_Discharge.dfs0";

            TVFileModel tvFileModelDischarge = _TVFileService.GetTVFileModelWithServerFilePathAndServerFileNameDB(ServerPath, ServerFileNameDischarge);
            if (string.IsNullOrWhiteSpace(tvFileModelDischarge.Error))
            {
                TVFileModel tvFileModelRet = _TVFileService.PostDeleteTVFileDB(tvFileModelDischarge.TVFileID);
                if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
                    return ReturnError(tvFileModelRet.Error);
            }

            List<MikeSourceModel> mikeSourceModelList = GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);

            using (TransactionScope ts = new TransactionScope())
            {
                MapInfoModel mapInfoModelRet = _MapInfoService.PostDeleteMapInfoWithTVItemIDDB(mikeSourceToDelete.MikeSourceTVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                    return ReturnError(mapInfoModelRet.Error);

                db.MikeSources.Remove(mikeSourceToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeSources", mikeSourceToDelete.MikeSourceID, LogCommandEnum.Delete, mikeSourceToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                bool ok = false;
                while (!ok)
                {
                    SourceNumber += 1;

                    MikeSourceModel mikeSourceModel = mikeSourceModelList.Where(c => c.SourceNumberString == "SOURCE_" + SourceNumber.ToString()).FirstOrDefault();
                    if (mikeSourceModel != null)
                    {
                        mikeSourceModel.SourceNumberString = "SOURCE_" + (SourceNumber - 1).ToString();

                        MikeSourceModel mikeSourceModelRet = PostUpdateMikeSourceDB(mikeSourceModel);
                        if (!string.IsNullOrWhiteSpace(mikeSourceModelRet.Error))
                            return ReturnError(mikeSourceModelRet.Error);
                    }
                    else
                    {
                        ok = true;
                    }
                }

                ts.Complete();
            }
            return ReturnError("");
        }
        public MikeSourceModel PostDeleteMikeSourceWithTVItemIDDB(int MikeSourceTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MikeSourceModel mikeSourceModelToDelete = GetMikeSourceModelWithMikeSourceTVItemIDDB(MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeSourceModelToDelete.Error))
                return ReturnError(mikeSourceModelToDelete.Error);           

            MikeSourceModel mikeSourceModelRet = PostDeleteMikeSourceDB(mikeSourceModelToDelete.MikeSourceID);
            if (!string.IsNullOrWhiteSpace(mikeSourceModelRet.Error))
                return ReturnError(mikeSourceModelRet.Error);


            return ReturnError("");
        }
        public MikeSourceModel PostUpdateMikeSourceDB(MikeSourceModel mikeSourceModel)
        {
            string retStr = MikeSourceModelOK(mikeSourceModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MikeSource mikeSourceToUpdate = GetMikeSourceWithMikeSourceIDDB(mikeSourceModel.MikeSourceID);
            if (mikeSourceToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeSource));

            retStr = FillMikeSource(mikeSourceToUpdate, mikeSourceModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeSources", mikeSourceToUpdate.MikeSourceID, LogCommandEnum.Change, mikeSourceToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(mikeSourceToUpdate.MikeSourceTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnError(tvItemLanguageModelToUpdate.Error);

                        string TVText = CreateTVText(mikeSourceModel);
                        if (string.IsNullOrWhiteSpace(TVText))
                            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemModel tvItemModelMikeSourceExit = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(mikeSourceModel.MikeSourceTVItemID, TVText, TVTypeEnum.MikeSource);
                        if (string.IsNullOrWhiteSpace(tvItemModelMikeSourceExit.Error))
                        {
                            bool IsSameTVItemModel = GetIsItSameObject(mikeSourceModel, tvItemModelMikeSourceExit);
                            if (!IsSameTVItemModel)
                                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MikeSource));
                        }

                        tvItemLanguageModelToUpdate.TVText = TVText;

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }
            return GetMikeSourceModelWithMikeSourceIDDB(mikeSourceToUpdate.MikeSourceID);
        }
        #endregion Function public

        #region Function private
        #endregion Functions private
    }
}
