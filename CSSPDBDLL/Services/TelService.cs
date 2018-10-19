using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class TelService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public TVItemLinkService _TVItemLinkService {get; private set;}
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TelService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
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
        public string TelModelOK(TelModel telModel)
        {
            string retStr = FieldCheckNotNullAndMinMaxLengthString(telModel.TelNumber, ServiceRes.TelNumber, 7, 20);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TelTypeOK(telModel.TelType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(telModel.TelTVItemID, ServiceRes.TelTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTel(Tel tel, TelModel telModel, ContactOK contactOK)
        {
            tel.TelTVItemID = telModel.TelTVItemID;
            tel.TelNumber = telModel.TelNumber;
            tel.TelType = (int)telModel.TelType;
            tel.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tel.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tel.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetTelModelCountDB()
        {
            int telModelCount = (from c in db.Tels
                                 select c).Count();
            return telModelCount;
        }
        public TelModel GetTelModelWithTelIDDB(int TelID)
        {
            TelModel telModel = (from c in db.Tels
                                 where c.TelID == TelID
                                 select new TelModel
                                 {
                                     Error = "",
                                     TelID = c.TelID,
                                     TelTVItemID = c.TelTVItemID,
                                     TelNumber = c.TelNumber,
                                     TelType = (TelTypeEnum)c.TelType,
                                     TelTypeText = "",
                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                 }).FirstOrDefault<TelModel>();

            if (telModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Tel, ServiceRes.TelID, TelID));
            }
            else
            {
                telModel.TelTypeText = _BaseEnumService.GetEnumText_TelTypeEnum((TelTypeEnum)telModel.TelType);
            }
            return telModel;
        }
        public TelModel GetTelModelWithTelTVItemIDDB(int TelTVItemID)
        {
            TelModel telModel = (from c in db.Tels
                                 where c.TelTVItemID == TelTVItemID
                                 select new TelModel
                                 {
                                     Error = "",
                                     TelID = c.TelID,
                                     TelTVItemID = c.TelTVItemID,
                                     TelNumber = c.TelNumber,
                                     TelType = (TelTypeEnum)c.TelType,
                                     TelTypeText = "",
                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                 }).FirstOrDefault<TelModel>();

            if (telModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Tel, ServiceRes.TelTVItemID, TelTVItemID));
            }
            else
            {
                telModel.TelTypeText = _BaseEnumService.GetEnumText_TelTypeEnum((TelTypeEnum)telModel.TelType);
            }
            return telModel;
        }
        public Tel GetTelWithTelIDDB(int TelID)
        {
            Tel tel = (from c in db.Tels
                       where c.TelID == TelID
                       select c).FirstOrDefault<Tel>();
            return tel;
        }

        // Helper
        public string CreateTVText(TelModel telModel)
        {
            return telModel.TelNumber;
        }
        public TelModel ReturnError(string Error)
        {
            return new TelModel() { Error = Error };
        }

        // Post
        public TelModel PostAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ContactTVItemID = 0;
            int TelTVItemID = 0;
            string TelNumber = "";
            int TelTypeInt = 0;
            TelTypeEnum TelType = TelTypeEnum.Error;

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            if (ContactTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            int.TryParse(fc["TelTVItemID"], out TelTVItemID);
            // if 0 then want to add new TVItem else want to modify

            TelNumber = fc["TelNumber"];
            if (string.IsNullOrWhiteSpace(TelNumber))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TelNumber));

            int.TryParse(fc["TelType"], out TelTypeInt);
            if (TelTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TelType));

            TelType = (TelTypeEnum)TelTypeInt;

            TelModel telModel = new TelModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (TelTVItemID == 0)
                {
                    TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
                    if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                        return ReturnError(tvItemModelRoot.Error);

                    TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                        return ReturnError(tvItemModelContact.Error);

                    TelModel telModelNew = new TelModel()
                    {
                        TelNumber = TelNumber,
                        TelType = TelType,
                    };

                    string TVText = CreateTVText(telModelNew);
                    if (string.IsNullOrWhiteSpace(TVText))
                        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                    TVItemModel tvItemModelTel = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Tel);
                    if (!string.IsNullOrWhiteSpace(tvItemModelTel.Error))
                    {
                        // Should add
                        tvItemModelTel = _TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Tel);
                        if (!string.IsNullOrWhiteSpace(tvItemModelTel.Error))
                            return ReturnError(tvItemModelTel.Error);

                        telModelNew.TelTVItemID = tvItemModelTel.TVItemID;

                        telModel = PostAddTelDB(telModelNew);
                        if (!string.IsNullOrWhiteSpace(telModel.Error))
                            return ReturnError(telModel.Error);
                    }

                    telModel = GetTelModelWithTelTVItemIDDB(tvItemModelTel.TVItemID);
                    if (!string.IsNullOrWhiteSpace(telModel.Error))
                        return ReturnError(telModel.Error);

                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        FromTVItemID = tvItemModelContact.TVItemID,
                        ToTVItemID = tvItemModelTel.TVItemID,
                        FromTVType = tvItemModelContact.TVType,
                        ToTVType = TVTypeEnum.Tel,
                        StartDateTime_Local = DateTime.Now,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p" + tvItemModelContact.TVItemID + "p" + tvItemModelTel.TVItemID,
                    };

                    TVItemLinkModel tvItemLinkModel = _TVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(tvItemModelContact.TVItemID, tvItemModelTel.TVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    {
                        tvItemLinkModel = _TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                            return ReturnError(tvItemLinkModel.Error);
                    }
                }
                else
                {
                    TelModel telModelToChange = GetTelModelWithTelTVItemIDDB(TelTVItemID);
                    if (!string.IsNullOrWhiteSpace(telModelToChange.Error))
                        return ReturnError(telModelToChange.Error);

                    telModelToChange.TelNumber = TelNumber;
                    telModelToChange.TelType = TelType;

                    telModel = PostUpdateTelDB(telModelToChange);
                    if (!string.IsNullOrWhiteSpace(telModel.Error))
                        return ReturnError(telModel.Error);

                    foreach (LanguageEnum Lang in LanguageListAllowable)
                    {
                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(telModelToChange.TelTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);

                        tvItemLanguageModel.TVText = CreateTVText(telModelToChange);

                        tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }

            return telModel;
        }
        public TelModel PostAddTelDB(TelModel telModel)
        {
            string retStr = TelModelOK(telModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelTel = _TVItemService.GetTVItemModelWithTVItemIDDB(telModel.TelTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelTel.Error))
                return ReturnError(tvItemModelTel.Error);

            Tel telNew = new Tel();
            retStr = FillTel(telNew, telModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.Tels.Add(telNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Tels", telNew.TelID, LogCommandEnum.Add, telNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTelModelWithTelIDDB(telNew.TelID);
        }
        public TelModel PostDeleteTelDB(int telID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Tel telToDelete = GetTelWithTelIDDB(telID);
            if (telToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Tel));

            int TVItemIDToDelete = telToDelete.TelTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.Tels.Remove(telToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Tels", telToDelete.TelID, LogCommandEnum.Delete, telToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public TelModel PostDeleteTelUnderContactTVItemIDDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ContactTVItemID = 0;
            int TelTVItemID = 0;

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            if (ContactTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            int.TryParse(fc["TelTVItemID"], out TelTVItemID);
            if (TelTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TelTVItemID));

            TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                return ReturnError(tvItemModelContact.Error);

            TVItemModel tvItemModelTel = _TVItemService.GetTVItemModelWithTVItemIDDB(TelTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelTel.Error))
                return ReturnError(tvItemModelTel.Error);

            TelModel telModel = GetTelModelWithTelTVItemIDDB(TelTVItemID);
            if (!string.IsNullOrWhiteSpace(telModel.Error))
                return ReturnError(telModel.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                TVItemLinkModel tvItemLinkModel = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemModelContact.TVItemID, tvItemModelTel.TVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    return ReturnError(tvItemLinkModel.Error);

                TelModel telModelDel = PostDeleteTelDB(telModel.TelID);
                //if (!string.IsNullOrWhiteSpace(telModelDel.Error))
                //    return ReturnError(telModelDel.Error);

                ts.Complete();
            }

            return new TelModel() { Error = "" }; // no error
        }
        public TelModel PostDeleteTelWithTelTVItemIDDB(int TelTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TelModel telModelToDelete = GetTelModelWithTelTVItemIDDB(TelTVItemID);
            if (!string.IsNullOrWhiteSpace(telModelToDelete.Error))
                return ReturnError(telModelToDelete.Error);

            telModelToDelete = PostDeleteTelDB(telModelToDelete.TelID);
            if (!string.IsNullOrWhiteSpace(telModelToDelete.Error))
                return ReturnError(telModelToDelete.Error);

            return ReturnError("");
        }
        public TelModel PostUpdateTelDB(TelModel telModel)
        {
            string retStr = TelModelOK(telModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Tel telToUpdate = GetTelWithTelIDDB(telModel.TelID);
            if (telToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Tel));

            retStr = FillTel(telToUpdate, telModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Tels", telToUpdate.TelID, LogCommandEnum.Change, telToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(telToUpdate.TelTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnError(tvItemLanguageModelToUpdate.Error);

                        tvItemLanguageModelToUpdate.TVText = CreateTVText(telModel);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.TVText))
                            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }
                }
                ts.Complete();
            }
            return GetTelModelWithTelIDDB(telToUpdate.TelID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

