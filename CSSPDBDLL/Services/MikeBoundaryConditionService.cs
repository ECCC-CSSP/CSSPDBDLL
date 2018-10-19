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
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class MikeBoundaryConditionService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public MapInfoService _MapInfoService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
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
        public string MikeBoundaryConditionModelOK(MikeBoundaryConditionModel mikeBoundaryConditionModel)
        {
            string retStr = FieldCheckNotZeroInt(mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID, ServiceRes.MikeBoundaryConditionTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mikeBoundaryConditionModel.MikeBoundaryConditionTVText, ServiceRes.MikeBoundaryConditionTVText, 1, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mikeBoundaryConditionModel.MikeBoundaryConditionCode, ServiceRes.MikeBoundaryConditionCode, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mikeBoundaryConditionModel.MikeBoundaryConditionName, ServiceRes.MikeBoundaryConditionName, 1, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mikeBoundaryConditionModel.MikeBoundaryConditionLength_m, ServiceRes.MikeBoundaryConditionLength_m, 0, 500000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mikeBoundaryConditionModel.MikeBoundaryConditionFormat, ServiceRes.MikeBoundaryConditionFormat, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.MikeBoundaryConditionLevelOrVelocityOK(mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.WebTideDataSetOK(mikeBoundaryConditionModel.WebTideDataSet);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mikeBoundaryConditionModel.NumberOfWebTideNodes, ServiceRes.NumberOfWebTideNodes, 0, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (!(mikeBoundaryConditionModel.TVType == TVTypeEnum.MikeBoundaryConditionWebTide || mikeBoundaryConditionModel.TVType == TVTypeEnum.MikeBoundaryConditionMesh))
            {
                return string.Format(ServiceRes.TVTypeForBoundaryConditionShouldBeOneOf_Or_, ServiceRes.MikeBoundaryConditionWebTide, ServiceRes.MikeBoundaryConditionMesh);
            }

            return "";
        }

        // Fill
        public string FillMikeBoundaryCondition(MikeBoundaryCondition mikeBoundaryCondition, MikeBoundaryConditionModel mikeBoundaryConditionModel, ContactOK contactOK)
        {
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID;
            mikeBoundaryCondition.MikeBoundaryConditionCode = mikeBoundaryConditionModel.MikeBoundaryConditionCode;
            mikeBoundaryCondition.MikeBoundaryConditionFormat = mikeBoundaryConditionModel.MikeBoundaryConditionFormat;
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = mikeBoundaryConditionModel.MikeBoundaryConditionLength_m;
            mikeBoundaryCondition.MikeBoundaryConditionName = mikeBoundaryConditionModel.MikeBoundaryConditionName;
            mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (int)mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity;
            mikeBoundaryCondition.NumberOfWebTideNodes = mikeBoundaryConditionModel.NumberOfWebTideNodes;
            mikeBoundaryCondition.WebTideDataFromStartToEndDate = mikeBoundaryConditionModel.WebTideDataFromStartToEndDate;
            mikeBoundaryCondition.TVType = (int)mikeBoundaryConditionModel.TVType;
            mikeBoundaryCondition.WebTideDataSet = (int)mikeBoundaryConditionModel.WebTideDataSet;
            mikeBoundaryCondition.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mikeBoundaryCondition.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mikeBoundaryCondition.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMikeBoundaryConditionCountDB()
        {
            return (from c in db.MikeBoundaryConditions
                    select c).Count();
        }
        public List<MikeBoundaryConditionModel> GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(int MikeScenarioTVItemID, TVTypeEnum TVType)
        {
            List<MikeBoundaryConditionModel> mikeBoundaryConditionModelList = (from c in db.TVItems
                                                                               from m in db.MikeBoundaryConditions
                                                                               let bcName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == m.MikeBoundaryConditionTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                               where c.ParentID == MikeScenarioTVItemID
                                                                               && c.TVItemID == m.MikeBoundaryConditionTVItemID
                                                                               && c.TVType == (int)TVType
                                                                               select new MikeBoundaryConditionModel
                                                                               {
                                                                                   Error = "",
                                                                                   MikeBoundaryConditionID = m.MikeBoundaryConditionID,
                                                                                   MikeBoundaryConditionTVItemID = m.MikeBoundaryConditionTVItemID,
                                                                                   MikeBoundaryConditionTVText = bcName,
                                                                                   MikeBoundaryConditionCode = m.MikeBoundaryConditionCode,
                                                                                   MikeBoundaryConditionFormat = m.MikeBoundaryConditionFormat,
                                                                                   MikeBoundaryConditionLength_m = m.MikeBoundaryConditionLength_m,
                                                                                   MikeBoundaryConditionName = m.MikeBoundaryConditionName,
                                                                                   MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)m.MikeBoundaryConditionLevelOrVelocity,
                                                                                   NumberOfWebTideNodes = m.NumberOfWebTideNodes,
                                                                                   WebTideDataSet = (WebTideDataSetEnum)m.WebTideDataSet,
                                                                                   WebTideDataFromStartToEndDate = m.WebTideDataFromStartToEndDate,
                                                                                   TVType = (TVTypeEnum)m.TVType,
                                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                                               }).ToList<MikeBoundaryConditionModel>();

            return mikeBoundaryConditionModelList;
        }
        public MikeBoundaryConditionModel GetMikeBoundaryConditionModelWithMikeBoundaryConditionIDDB(int MikeBoundaryConditionID)
        {
            MikeBoundaryConditionModel mikeBoundaryConditionModel = (from c in db.MikeBoundaryConditions
                                                                     let bcName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MikeBoundaryConditionTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                     where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                                                                     select new MikeBoundaryConditionModel
                                                                     {
                                                                         Error = "",
                                                                         MikeBoundaryConditionID = c.MikeBoundaryConditionID,
                                                                         MikeBoundaryConditionTVItemID = c.MikeBoundaryConditionTVItemID,
                                                                         MikeBoundaryConditionTVText = bcName,
                                                                         MikeBoundaryConditionCode = c.MikeBoundaryConditionCode,
                                                                         MikeBoundaryConditionFormat = c.MikeBoundaryConditionFormat,
                                                                         MikeBoundaryConditionLength_m = c.MikeBoundaryConditionLength_m,
                                                                         MikeBoundaryConditionName = c.MikeBoundaryConditionName,
                                                                         MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)c.MikeBoundaryConditionLevelOrVelocity,
                                                                         NumberOfWebTideNodes = c.NumberOfWebTideNodes,
                                                                         WebTideDataSet = (WebTideDataSetEnum)c.WebTideDataSet,
                                                                         WebTideDataFromStartToEndDate = c.WebTideDataFromStartToEndDate,
                                                                         TVType = (TVTypeEnum)c.TVType,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                                     }).FirstOrDefault<MikeBoundaryConditionModel>();

            if (mikeBoundaryConditionModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeBoundaryCondition, ServiceRes.MikeBoundaryConditionID, MikeBoundaryConditionID));

            return mikeBoundaryConditionModel;
        }
        public MikeBoundaryConditionModel GetMikeBoundaryConditionModelWithMikeBoundaryConditionTVItemIDDB(int MikeBoundaryConditionTVItemID)
        {
            MikeBoundaryConditionModel mikeBoundaryConditionModel = (from c in db.MikeBoundaryConditions
                                                                     let bcName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MikeBoundaryConditionTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                     where c.MikeBoundaryConditionTVItemID == MikeBoundaryConditionTVItemID
                                                                     select new MikeBoundaryConditionModel
                                                                     {
                                                                         Error = "",
                                                                         MikeBoundaryConditionID = c.MikeBoundaryConditionID,
                                                                         MikeBoundaryConditionTVItemID = c.MikeBoundaryConditionTVItemID,
                                                                         MikeBoundaryConditionTVText = bcName,
                                                                         MikeBoundaryConditionCode = c.MikeBoundaryConditionCode,
                                                                         MikeBoundaryConditionFormat = c.MikeBoundaryConditionFormat,
                                                                         MikeBoundaryConditionLength_m = c.MikeBoundaryConditionLength_m,
                                                                         MikeBoundaryConditionName = c.MikeBoundaryConditionName,
                                                                         MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)c.MikeBoundaryConditionLevelOrVelocity,
                                                                         NumberOfWebTideNodes = c.NumberOfWebTideNodes,
                                                                         WebTideDataSet = (WebTideDataSetEnum)c.WebTideDataSet,
                                                                         WebTideDataFromStartToEndDate = c.WebTideDataFromStartToEndDate,
                                                                         TVType = (TVTypeEnum)c.TVType,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                                     }).FirstOrDefault<MikeBoundaryConditionModel>();

            if (mikeBoundaryConditionModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeBoundaryCondition, ServiceRes.MikeBoundaryConditionTVItemID, MikeBoundaryConditionTVItemID));

            return mikeBoundaryConditionModel;
        }
        public MikeBoundaryConditionModel GetMikeBoundaryConditionModelExistDB(MikeBoundaryConditionModel mikeBoundaryConditionModel)
        {
            MikeBoundaryConditionModel mikeBoundaryConditionModelRet = (from m in db.MikeBoundaryConditions
                                                                        let bcName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == m.MikeBoundaryConditionTVItemID select cl.TVText).FirstOrDefault<string>()
                                                                        where m.MikeBoundaryConditionTVItemID == mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID
                                                                        && m.MikeBoundaryConditionCode == mikeBoundaryConditionModel.MikeBoundaryConditionCode
                                                                        && m.MikeBoundaryConditionFormat == mikeBoundaryConditionModel.MikeBoundaryConditionFormat
                                                                        && m.MikeBoundaryConditionName == mikeBoundaryConditionModel.MikeBoundaryConditionName
                                                                        && m.MikeBoundaryConditionLevelOrVelocity == (int)mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity
                                                                        select new MikeBoundaryConditionModel
                                                                        {
                                                                            Error = "",
                                                                            MikeBoundaryConditionID = m.MikeBoundaryConditionID,
                                                                            MikeBoundaryConditionTVItemID = m.MikeBoundaryConditionTVItemID,
                                                                            MikeBoundaryConditionTVText = bcName,
                                                                            MikeBoundaryConditionCode = m.MikeBoundaryConditionCode,
                                                                            MikeBoundaryConditionFormat = m.MikeBoundaryConditionFormat,
                                                                            MikeBoundaryConditionLength_m = m.MikeBoundaryConditionLength_m,
                                                                            MikeBoundaryConditionName = m.MikeBoundaryConditionName,
                                                                            MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)m.MikeBoundaryConditionLevelOrVelocity,
                                                                            NumberOfWebTideNodes = m.NumberOfWebTideNodes,
                                                                            WebTideDataSet = (WebTideDataSetEnum)m.WebTideDataSet,
                                                                            WebTideDataFromStartToEndDate = m.WebTideDataFromStartToEndDate,
                                                                            TVType = (TVTypeEnum)m.TVType,
                                                                            LastUpdateDate_UTC = m.LastUpdateDate_UTC,
                                                                            LastUpdateContactTVItemID = m.LastUpdateContactTVItemID
                                                                        }).FirstOrDefault<MikeBoundaryConditionModel>();

            if (mikeBoundaryConditionModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeBoundaryCondition,
                    ServiceRes.MikeBoundaryConditionTVItemID + "," +
                    ServiceRes.MikeBoundaryConditionCode + "," +
            ServiceRes.MikeBoundaryConditionFormat + "," +
            ServiceRes.MikeBoundaryConditionName + "," +
            ServiceRes.MikeBoundaryConditionLevelOrVelocity,
            mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID + "," +
            mikeBoundaryConditionModel.MikeBoundaryConditionCode + "," +
            mikeBoundaryConditionModel.MikeBoundaryConditionFormat + "," +
            mikeBoundaryConditionModel.MikeBoundaryConditionName + "," +
            mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity));

            return mikeBoundaryConditionModelRet;
        }
        public MikeBoundaryCondition GetMikeBoundaryConditionWithMikeBoundaryConditionIDDB(int MikeBoundaryConditionID)
        {
            MikeBoundaryCondition mikeBoundaryCondition = (from c in db.MikeBoundaryConditions
                                                           let bcName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MikeBoundaryConditionTVItemID select cl.TVText).FirstOrDefault<string>()
                                                           where c.MikeBoundaryConditionID == MikeBoundaryConditionID
                                                           select c).FirstOrDefault<MikeBoundaryCondition>();

            return mikeBoundaryCondition;
        }

        // Helper
        public string CreateTVText(MikeBoundaryConditionModel mikeBoundaryConditionModel)
        {
            return mikeBoundaryConditionModel.MikeBoundaryConditionTVText;
        }
        public bool GetIsItSameObject(MikeBoundaryConditionModel mikeBoundaryConditionModel, TVItemModel tvItemModelMikeBoundaryConditionExit)
        {
            bool IsSame = false;
            if (mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID == tvItemModelMikeBoundaryConditionExit.TVItemID)
            {
                IsSame = true;
            }

            return IsSame;
        }
        public MikeBoundaryConditionModel ReturnError(string Error)
        {
            return new MikeBoundaryConditionModel() { Error = Error };
        }

        // Post
        public MikeBoundaryConditionModel PostAddMikeBoundaryConditionDB(MikeBoundaryConditionModel mikeBoundaryConditionModel)
        {
            string retStr = MikeBoundaryConditionModelOK(mikeBoundaryConditionModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExit = _TVItemService.GetTVItemModelWithTVItemIDDB(mikeBoundaryConditionModel.MikeBoundaryConditionTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExit.Error))
                return ReturnError(tvItemModelExit.Error);

            MikeBoundaryCondition mikeBoundaryConditionNew = new MikeBoundaryCondition();

            retStr = FillMikeBoundaryCondition(mikeBoundaryConditionNew, mikeBoundaryConditionModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MikeBoundaryConditions.Add(mikeBoundaryConditionNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeBoundaryConditions", mikeBoundaryConditionNew.MikeBoundaryConditionID, LogCommandEnum.Add, mikeBoundaryConditionNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMikeBoundaryConditionModelWithMikeBoundaryConditionIDDB(mikeBoundaryConditionNew.MikeBoundaryConditionID);
        }
        public MikeBoundaryConditionModel PostDeleteMikeBoundaryConditionDB(int MikeBoundaryConditionID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MikeBoundaryCondition mikeBoundaryConditionToDelete = GetMikeBoundaryConditionWithMikeBoundaryConditionIDDB(MikeBoundaryConditionID);
            if (mikeBoundaryConditionToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeBoundaryCondition));

            int TVItemIDToDelete = mikeBoundaryConditionToDelete.MikeBoundaryConditionTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.MikeBoundaryConditions.Remove(mikeBoundaryConditionToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeBoundaryConditions", mikeBoundaryConditionToDelete.MikeBoundaryConditionID, LogCommandEnum.Delete, mikeBoundaryConditionToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                MapInfoModel mapInfoModelRet = _MapInfoService.PostDeleteMapInfoWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                    return ReturnError(mapInfoModelRet.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MikeBoundaryConditionModel PostUpdateMikeBoundaryConditionDB(MikeBoundaryConditionModel mikeBoundaryConditionModel)
        {
            string retStr = MikeBoundaryConditionModelOK(mikeBoundaryConditionModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MikeBoundaryCondition mikeBoundaryConditionToUpdate = GetMikeBoundaryConditionWithMikeBoundaryConditionIDDB(mikeBoundaryConditionModel.MikeBoundaryConditionID);
            if (mikeBoundaryConditionToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeBoundaryCondition));

            retStr = FillMikeBoundaryCondition(mikeBoundaryConditionToUpdate, mikeBoundaryConditionModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeBoundaryConditions", mikeBoundaryConditionToUpdate.MikeBoundaryConditionID, LogCommandEnum.Change, mikeBoundaryConditionToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMikeBoundaryConditionModelWithMikeBoundaryConditionIDDB(mikeBoundaryConditionToUpdate.MikeBoundaryConditionID);
        }
        #endregion Function public

        #region Function private
        #endregion Functions private
    }
}
