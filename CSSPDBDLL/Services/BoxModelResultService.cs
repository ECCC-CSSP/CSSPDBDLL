using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class BoxModelResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public BoxModelResultService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
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
        public string BoxModelResultModelOK(BoxModelResultModel boxModelResultModel)
        {
            string retStr = FieldCheckNotZeroInt(boxModelResultModel.BoxModelID, ServiceRes.BoxModelID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.BoxModelResultTypeOK(boxModelResultModel.BoxModelResultType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroDouble(boxModelResultModel.Radius_m, ServiceRes.Radius_m);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroDouble(boxModelResultModel.RectLength_m, ServiceRes.RectLength_m);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroDouble(boxModelResultModel.RectWidth_m, ServiceRes.RectWidth_m);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroDouble(boxModelResultModel.Surface_m2, ServiceRes.Surface_m2);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroDouble(boxModelResultModel.Volume_m3, ServiceRes.Volume_m3);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillBoxModelResultModel(BoxModelResult boxModelResult, BoxModelResultModel boxModelResultModel, ContactOK contactOK)
        {
            boxModelResult.BoxModelID = boxModelResultModel.BoxModelID;
            boxModelResult.CircleCenterLatitude = boxModelResultModel.CircleCenterLatitude;
            boxModelResult.CircleCenterLongitude = boxModelResultModel.CircleCenterLongitude;
            boxModelResult.FixLength = boxModelResultModel.FixLength;
            boxModelResult.FixWidth = boxModelResultModel.FixWidth;
            boxModelResult.LeftSideDiameterLineAngle_deg = boxModelResultModel.LeftSideDiameterLineAngle_deg;
            boxModelResult.LeftSideLineAngle_deg = boxModelResultModel.LeftSideLineAngle_deg;
            boxModelResult.LeftSideLineStartLatitude = boxModelResultModel.LeftSideLineStartLatitude;
            boxModelResult.LeftSideLineStartLongitude = boxModelResultModel.LeftSideLineStartLongitude;
            boxModelResult.Radius_m = boxModelResultModel.Radius_m;
            boxModelResult.RectLength_m = boxModelResultModel.RectLength_m;
            boxModelResult.RectWidth_m = boxModelResultModel.RectWidth_m;
            boxModelResult.BoxModelResultType = (int)boxModelResultModel.BoxModelResultType;
            boxModelResult.Surface_m2 = boxModelResultModel.Surface_m2;
            boxModelResult.Volume_m3 = boxModelResultModel.Volume_m3;
            boxModelResult.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                boxModelResult.LastUpdateContactTVItemID = 2;
            }
            else
            {
                boxModelResult.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetBoxModelResultModelCountDB()
        {
            int BoxModelResultModelCount = (from c in db.BoxModelResults
                                            select c).Count();

            return BoxModelResultModelCount;
        }
        public List<BoxModelResultModel> GetBoxModelResultModelListWithBoxModelIDOrderByResultTypeDB(int BoxModelID)
        {
            List<BoxModelResultModel> boxModelResultModelList = (from c in db.BoxModelResults
                                                                 where c.BoxModelID == BoxModelID
                                                                 orderby c.BoxModelResultType
                                                                 select new BoxModelResultModel
                                                                 {
                                                                     Error = "",
                                                                     BoxModelResultID = c.BoxModelResultID,
                                                                     BoxModelID = c.BoxModelID,
                                                                     CircleCenterLatitude = c.CircleCenterLatitude,
                                                                     CircleCenterLongitude = c.CircleCenterLongitude,
                                                                     FixLength = c.FixLength,
                                                                     FixWidth = c.FixWidth,
                                                                     LeftSideDiameterLineAngle_deg = c.LeftSideDiameterLineAngle_deg,
                                                                     LeftSideLineAngle_deg = c.LeftSideLineAngle_deg,
                                                                     LeftSideLineStartLatitude = c.LeftSideLineStartLatitude,
                                                                     LeftSideLineStartLongitude = c.LeftSideLineStartLongitude,
                                                                     Radius_m = c.Radius_m,
                                                                     RectLength_m = c.RectLength_m,
                                                                     RectWidth_m = c.RectWidth_m,
                                                                     BoxModelResultType = (BoxModelResultTypeEnum)c.BoxModelResultType,
                                                                     Surface_m2 = c.Surface_m2,
                                                                     Volume_m3 = c.Volume_m3,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).ToList<BoxModelResultModel>();

            return boxModelResultModelList;
        }
        public BoxModelResultModel GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(int BoxModelID, BoxModelResultTypeEnum ResultType)
        {
            BoxModelResultModel boxModelResultModel = (from c in db.BoxModelResults
                                                       where c.BoxModelID == BoxModelID
                                                       && c.BoxModelResultType == (int)ResultType
                                                       select new BoxModelResultModel
                                                       {
                                                           Error = "",
                                                           BoxModelResultID = c.BoxModelResultID,
                                                           BoxModelID = c.BoxModelID,
                                                           CircleCenterLatitude = c.CircleCenterLatitude,
                                                           CircleCenterLongitude = c.CircleCenterLongitude,
                                                           FixLength = c.FixLength,
                                                           FixWidth = c.FixWidth,
                                                           LeftSideDiameterLineAngle_deg = c.LeftSideDiameterLineAngle_deg,
                                                           LeftSideLineAngle_deg = c.LeftSideLineAngle_deg,
                                                           LeftSideLineStartLatitude = c.LeftSideLineStartLatitude,
                                                           LeftSideLineStartLongitude = c.LeftSideLineStartLongitude,
                                                           Radius_m = c.Radius_m,
                                                           RectLength_m = c.RectLength_m,
                                                           RectWidth_m = c.RectWidth_m,
                                                           BoxModelResultType = (BoxModelResultTypeEnum)c.BoxModelResultType,
                                                           Surface_m2 = c.Surface_m2,
                                                           Volume_m3 = c.Volume_m3,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<BoxModelResultModel>();

            if (boxModelResultModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModelResultModel, ServiceRes.BoxModelID + "," + ServiceRes.BoxModelResultType, BoxModelID + "," + ResultType));

            return boxModelResultModel;
        }
        public BoxModelResultModel GetBoxModelResultModelWithBoxModelResultIDDB(int BoxModelResultID)
        {
            BoxModelResultModel boxModelResultModel = (from c in db.BoxModelResults
                                                       where c.BoxModelResultID == BoxModelResultID
                                                       select new BoxModelResultModel
                                                       {
                                                           Error = "",
                                                           BoxModelResultID = c.BoxModelResultID,
                                                           BoxModelID = c.BoxModelID,
                                                           CircleCenterLatitude = c.CircleCenterLatitude,
                                                           CircleCenterLongitude = c.CircleCenterLongitude,
                                                           FixLength = c.FixLength,
                                                           FixWidth = c.FixWidth,
                                                           LeftSideDiameterLineAngle_deg = c.LeftSideDiameterLineAngle_deg,
                                                           LeftSideLineAngle_deg = c.LeftSideLineAngle_deg,
                                                           LeftSideLineStartLatitude = c.LeftSideLineStartLatitude,
                                                           LeftSideLineStartLongitude = c.LeftSideLineStartLongitude,
                                                           Radius_m = c.Radius_m,
                                                           RectLength_m = c.RectLength_m,
                                                           RectWidth_m = c.RectWidth_m,
                                                           BoxModelResultType = (BoxModelResultTypeEnum)c.BoxModelResultType,
                                                           Surface_m2 = c.Surface_m2,
                                                           Volume_m3 = c.Volume_m3,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).FirstOrDefault<BoxModelResultModel>();

            if (boxModelResultModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModelResultModel, ServiceRes.BoxModelResultID, BoxModelResultID));

            return boxModelResultModel;
        }
        public BoxModelResult GetBoxModelResultWithBoxModelResultIDDB(int BoxModelResultID)
        {
            BoxModelResult boxModelResult = (from c in db.BoxModelResults
                                             where c.BoxModelResultID == BoxModelResultID
                                             select c).FirstOrDefault<BoxModelResult>();

            return boxModelResult;
        }

        // Helper
        public BoxModelResultModel ReturnError(string Error)
        {
            return new BoxModelResultModel() { Error = Error };
        }

        // Post
        public BoxModelResultModel PostAddBoxModelResultDB(BoxModelResultModel boxModelResultModel)
        {
            string retStr = BoxModelResultModelOK(boxModelResultModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            BoxModelResult boxModelResultNew = new BoxModelResult();
            retStr = FillBoxModelResultModel(boxModelResultNew, boxModelResultModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.BoxModelResults.Add(boxModelResultNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModelResults", boxModelResultNew.BoxModelID, LogCommandEnum.Add, boxModelResultNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetBoxModelResultModelWithBoxModelResultIDDB(boxModelResultNew.BoxModelResultID);
        }
        public BoxModelResultModel PostDeleteBoxModelResultDB(int BoxModelResultID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            BoxModelResult boxModelResultToDelete = GetBoxModelResultWithBoxModelResultIDDB(BoxModelResultID);
            if (boxModelResultToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.BoxModelResult));

            using (TransactionScope ts = new TransactionScope())
            {
                db.BoxModelResults.Remove(boxModelResultToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModelResults", boxModelResultToDelete.BoxModelID, LogCommandEnum.Delete, boxModelResultToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public BoxModelResultModel PostUpdateBoxModelResultDB(BoxModelResultModel boxModelResultModel)
        {
            string retStr = BoxModelResultModelOK(boxModelResultModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            BoxModelResult boxModelResultToUpdate = GetBoxModelResultWithBoxModelResultIDDB(boxModelResultModel.BoxModelResultID);
            if (boxModelResultToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.BoxModelResult));

            retStr = FillBoxModelResultModel(boxModelResultToUpdate, boxModelResultModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModelResults", boxModelResultToUpdate.BoxModelID, LogCommandEnum.Change, boxModelResultToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelResultToUpdate.BoxModelID, (BoxModelResultTypeEnum)boxModelResultToUpdate.BoxModelResultType);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
