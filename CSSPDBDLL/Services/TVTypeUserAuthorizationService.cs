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
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class TVTypeUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public override bool IsAdministratorDB(string LoginEmail = "")
        {
            return base.IsAdministratorDB(LoginEmail);
        }
        public override ContactModel GetContactLoggedInDB()
        {
            return base.GetContactLoggedInDB();
        }
        public override ContactModel GetContactModelWithContactTVItemIDDB(int ContactTVItemID)
        {
            return base.GetContactModelWithContactTVItemIDDB(ContactTVItemID);
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
        public string TVTypeUserAuthorizationModelOK(TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel)
        {
            string retStr = FieldCheckNotZeroInt(tvTypeUserAuthorizationModel.ContactTVItemID, ServiceRes.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(tvTypeUserAuthorizationModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVAuthOK(tvTypeUserAuthorizationModel.TVAuth);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTVTypeUserAuthorization(TVTypeUserAuthorization tvTypeUserAuthorization, TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel, ContactOK contactOK)
        {
            tvTypeUserAuthorization.ContactTVItemID = tvTypeUserAuthorizationModel.ContactTVItemID;
            tvTypeUserAuthorization.TVType = (int)tvTypeUserAuthorizationModel.TVType;
            tvTypeUserAuthorization.TVAuth = (int)tvTypeUserAuthorizationModel.TVAuth;
            tvTypeUserAuthorization.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tvTypeUserAuthorization.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetTVTypeUserAuthorizationModelCountDB()
        {
            int TVTypeUserAuthorizationModelCount = (from c in db.TVTypeUserAuthorizations
                                                     select c).Count();

            return TVTypeUserAuthorizationModelCount;
        }
        public List<TVTypeUserAuthorizationModel> GetTVTypeUserAuthorizationModelListDB()
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModelList = (from c in db.TVTypeUserAuthorizations
                                                                                   orderby c.TVTypeUserAuthorizationID descending
                                                                                   select new TVTypeUserAuthorizationModel
                                                                                   {
                                                                                       Error = "",
                                                                                       TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                                                                                       ContactTVItemID = c.ContactTVItemID,
                                                                                       TVType = (TVTypeEnum)c.TVType,
                                                                                       TVPath = "",
                                                                                       TVLevel = -1,
                                                                                       TVAuth = (TVAuthEnum)c.TVAuth,
                                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                   }).ToList<TVTypeUserAuthorizationModel>();

            foreach (TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel in tvTypeUserAuthorizationModelList)
            {
                tvTypeUserAuthorizationModel.TVPath = tvTypeNamesAndPathList.Where(c => c.Index == (int)tvTypeUserAuthorizationModel.TVType).FirstOrDefault().TVPath;
                tvTypeUserAuthorizationModel.TVLevel = tvItemService.GetTVLevel(tvTypeUserAuthorizationModel.TVPath);
            }

            return tvTypeUserAuthorizationModelList.OrderBy(c => c.TVLevel).ToList<TVTypeUserAuthorizationModel>();
        }
        public List<TVTypeUserAuthorizationModel> GetTVTypeUserAuthorizationModelListWithContactTVItemIDDB(int ContactTVItemID)
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModelList = (from c in db.TVTypeUserAuthorizations
                                                                                   where c.ContactTVItemID == ContactTVItemID
                                                                                   select new TVTypeUserAuthorizationModel
                                                                                   {
                                                                                       Error = "",
                                                                                       TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                                                                                       ContactTVItemID = c.ContactTVItemID,
                                                                                       TVType = (TVTypeEnum)c.TVType,
                                                                                       TVPath = "",
                                                                                       TVLevel = -1,
                                                                                       TVAuth = (TVAuthEnum)c.TVAuth,
                                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                   }).ToList<TVTypeUserAuthorizationModel>();

            foreach (TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel in tvTypeUserAuthorizationModelList)
            {
                tvTypeUserAuthorizationModel.TVPath = tvTypeNamesAndPathList.Where(c => c.Index == (int)tvTypeUserAuthorizationModel.TVType).FirstOrDefault().TVPath;
                tvTypeUserAuthorizationModel.TVLevel = tvItemService.GetTVLevel(tvTypeUserAuthorizationModel.TVPath);
            }

            return tvTypeUserAuthorizationModelList.OrderBy(c => c.TVLevel).ToList<TVTypeUserAuthorizationModel>();
        }
        public TVTypeUserAuthorizationModel GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(int ContactTVItemID, TVTypeEnum TVType)
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel = (from c in db.TVTypeUserAuthorizations
                                                                         where c.ContactTVItemID == ContactTVItemID
                                                                         && c.TVType == (int)TVType
                                                                         orderby c.TVTypeUserAuthorizationID descending
                                                                         select new TVTypeUserAuthorizationModel
                                                                         {
                                                                             Error = "",
                                                                             TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                                                                             ContactTVItemID = c.ContactTVItemID,
                                                                             TVType = (TVTypeEnum)c.TVType,
                                                                             TVPath = "",
                                                                             TVLevel = -1,
                                                                             TVAuth = (TVAuthEnum)c.TVAuth,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<TVTypeUserAuthorizationModel>();

            if (tvTypeUserAuthorizationModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, BaseEnumServiceRes.TVTypeUserAuthorization, ServiceRes.ContactID + "," + ServiceRes.TVType, ContactTVItemID.ToString() + "," + TVType.ToString()));

            tvTypeUserAuthorizationModel.TVPath = tvTypeNamesAndPathList.Where(c => c.Index == (int)tvTypeUserAuthorizationModel.TVType).FirstOrDefault().TVPath;
            tvTypeUserAuthorizationModel.TVLevel = tvItemService.GetTVLevel(tvTypeUserAuthorizationModel.TVPath);
       
            return tvTypeUserAuthorizationModel;
        }
        public TVTypeUserAuthorizationModel GetTVTypeUserAuthorizationModelWithTVTypeUserAuthorizationIDDB(int TVTypeUserAuthorizationID)
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel = (from c in db.TVTypeUserAuthorizations
                                                                         where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                                                         select new TVTypeUserAuthorizationModel
                                                                         {
                                                                             Error = "",
                                                                             TVTypeUserAuthorizationID = c.TVTypeUserAuthorizationID,
                                                                             ContactTVItemID = c.ContactTVItemID,
                                                                             TVType = (TVTypeEnum)c.TVType,
                                                                             TVPath = "",
                                                                             TVLevel = -1,
                                                                             TVAuth = (TVAuthEnum)c.TVAuth,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<TVTypeUserAuthorizationModel>();

            if (tvTypeUserAuthorizationModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, BaseEnumServiceRes.TVTypeUserAuthorization, BaseEnumServiceRes.TVTypeUserAuthorizationID, TVTypeUserAuthorizationID));

            tvTypeUserAuthorizationModel.TVPath = tvTypeNamesAndPathList.Where(c => c.Index == (int)tvTypeUserAuthorizationModel.TVType).FirstOrDefault().TVPath;
            tvTypeUserAuthorizationModel.TVLevel = tvItemService.GetTVLevel(tvTypeUserAuthorizationModel.TVPath);
       
            return tvTypeUserAuthorizationModel;
        }
        public TVTypeUserAuthorization GetTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(int ContactTVItemID, TVTypeEnum TVType)
        {
            TVTypeUserAuthorization TVTypeUserAuthorization = (from c in db.TVTypeUserAuthorizations
                                                               where c.ContactTVItemID == ContactTVItemID
                                                               && c.TVType == (int)TVType
                                                               select c).FirstOrDefault<TVTypeUserAuthorization>();
            return TVTypeUserAuthorization;
        }
        public TVTypeUserAuthorization GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDB(int TVTypeUserAuthorizationID)
        {
            TVTypeUserAuthorization TVTypeUserAuthorization = (from c in db.TVTypeUserAuthorizations
                                                               where c.TVTypeUserAuthorizationID == TVTypeUserAuthorizationID
                                                               select c).FirstOrDefault<TVTypeUserAuthorization>();
            return TVTypeUserAuthorization;
        }

        // Helper
        public TVTypeUserAuthorizationModel ReturnError(string Error)
        {
            return new TVTypeUserAuthorizationModel() { Error = Error };
        }

        // Post
        public TVTypeUserAuthorizationModel PostAddTVTypeUserAuthorizationDB(TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel)
        {
            string retStr = TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            bool IsAdmin = IsAdministratorDB(User.Identity.Name);
            if (!IsAdmin)
                return ReturnError(ServiceRes.OnlyAdministratorsCanManageUsers);

            ContactModel contactModel = GetContactModelWithContactTVItemIDDB(tvTypeUserAuthorizationModel.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnError(contactModel.Error);

            ContactModel contactModelLoggedIn = GetContactLoggedInDB();
            if (!string.IsNullOrWhiteSpace(contactModelLoggedIn.Error))
                return ReturnError(contactModelLoggedIn.Error);

            if (contactOK.ContactTVItemID == tvTypeUserAuthorizationModel.ContactTVItemID)
                return ReturnError(ServiceRes.CantSetOwnAuthorization);

            TVTypeUserAuthorization tvTypeUserAuthorizationExist = GetTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModel.ContactTVItemID, tvTypeUserAuthorizationModel.TVType);
            if (tvTypeUserAuthorizationExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, BaseEnumServiceRes.TVTypeUserAuthorization));

            TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
            retStr = FillTVTypeUserAuthorization(tvTypeUserAuthorizationNew, tvTypeUserAuthorizationModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorizationNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVTypeUserAuthorizations", tvTypeUserAuthorizationNew.TVTypeUserAuthorizationID, LogCommandEnum.Add, tvTypeUserAuthorizationNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTVTypeUserAuthorizationModelWithTVTypeUserAuthorizationIDDB(tvTypeUserAuthorizationNew.TVTypeUserAuthorizationID);
        }
        public TVTypeUserAuthorizationModel PostDeleteTVTypeUserAuthorizationDB(int TVTypeUserAuthorizationID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            bool IsAdmin = IsAdministratorDB(User.Identity.Name);
            if (!IsAdmin)
                return ReturnError(ServiceRes.OnlyAdministratorsCanManageUsers);

            TVTypeUserAuthorization tvTypeUserAuthorizationToDelete = GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDB(TVTypeUserAuthorizationID);
            if (tvTypeUserAuthorizationToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, BaseEnumServiceRes.TVTypeUserAuthorization));

            if (tvTypeUserAuthorizationToDelete.TVType == (int)TVTypeEnum.Root)
                return ReturnError(ServiceRes.CantRemoveRootAutorization);

            ContactModel contactModel = GetContactModelWithContactTVItemIDDB(tvTypeUserAuthorizationToDelete.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnError(contactModel.Error);

            ContactModel contactModelLoggedIn = GetContactLoggedInDB();
            if (!string.IsNullOrWhiteSpace(contactModelLoggedIn.Error))
                return ReturnError(contactModelLoggedIn.Error);

            if (contactOK.ContactTVItemID == tvTypeUserAuthorizationToDelete.ContactTVItemID)
                return ReturnError(ServiceRes.CantSetOwnAuthorization);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVTypeUserAuthorizations.Remove(tvTypeUserAuthorizationToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVTypeUserAuthorizations", tvTypeUserAuthorizationToDelete.TVTypeUserAuthorizationID, LogCommandEnum.Delete, tvTypeUserAuthorizationToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVTypeUserAuthorizationModel PostDeleteTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(int ContactTVItemID, TVTypeEnum TVType)
        {
            TVTypeUserAuthorizationModel TVTypeUserAuthorizationModel = GetTVTypeUserAuthorizationModelWithContactTVItemIDAndTVTypeDB(ContactTVItemID, TVType);
            if (!string.IsNullOrWhiteSpace(TVTypeUserAuthorizationModel.Error))
                return ReturnError(TVTypeUserAuthorizationModel.Error);

            return PostDeleteTVTypeUserAuthorizationDB(TVTypeUserAuthorizationModel.TVTypeUserAuthorizationID);
        }
        public TVTypeUserAuthorizationModel PostSetTVTypeUserAuthorizationDB(TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel)
        {
            TVTypeUserAuthorization tvTypeUserAuthorizationToUpdate = GetTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModel.ContactTVItemID, tvTypeUserAuthorizationModel.TVType);
            if (tvTypeUserAuthorizationToUpdate == null)
            {
                return PostAddTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModel);
            }
            else
            {
                return PostUpdateTVTypeUserAuthorizationDB(tvTypeUserAuthorizationModel);
            }
        }
        public TVTypeUserAuthorizationModel PostUpdateTVTypeUserAuthorizationDB(TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel)
        {
            string retStr = TVTypeUserAuthorizationModelOK(tvTypeUserAuthorizationModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            bool IsAdmin = IsAdministratorDB(User.Identity.Name);
            if (!IsAdmin)
                return ReturnError(ServiceRes.OnlyAdministratorsCanManageUsers);

            ContactModel contactModel = GetContactModelWithContactTVItemIDDB(tvTypeUserAuthorizationModel.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnError(contactModel.Error);

            ContactModel contactModelLoggedIn = GetContactLoggedInDB();
            if (!string.IsNullOrWhiteSpace(contactModelLoggedIn.Error))
                return ReturnError(contactModelLoggedIn.Error);

            if (contactOK.ContactTVItemID == tvTypeUserAuthorizationModel.ContactTVItemID)
                return ReturnError(ServiceRes.CantSetOwnAuthorization);

            TVTypeUserAuthorization tvTypeUserAuthorizationToUpdate = new TVTypeUserAuthorization();
            if (tvTypeUserAuthorizationModel.TVTypeUserAuthorizationID != 0)
            {
                tvTypeUserAuthorizationToUpdate = GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationIDDB(tvTypeUserAuthorizationModel.TVTypeUserAuthorizationID);
                if (tvTypeUserAuthorizationToUpdate == null)
                    return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, BaseEnumServiceRes.TVTypeUserAuthorization));
            }
            else
            {
                tvTypeUserAuthorizationToUpdate = GetTVTypeUserAuthorizationWithContactTVItemIDAndTVTypeDB(tvTypeUserAuthorizationModel.ContactTVItemID, tvTypeUserAuthorizationModel.TVType);
                if (tvTypeUserAuthorizationToUpdate == null)
                    return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, BaseEnumServiceRes.TVTypeUserAuthorization));
            }

            retStr = FillTVTypeUserAuthorization(tvTypeUserAuthorizationToUpdate, tvTypeUserAuthorizationModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVTypeUserAuthorizations", tvTypeUserAuthorizationToUpdate.TVTypeUserAuthorizationID, LogCommandEnum.Change, tvTypeUserAuthorizationToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            if (tvTypeUserAuthorizationModel.TVType == TVTypeEnum.Root)
            {
                if (tvTypeUserAuthorizationModel.TVAuth == TVAuthEnum.Admin)
                {
                    contactModel.IsAdmin = true;
                }
                else
                {
                    contactModel.IsAdmin = false;
                }

                ContactService contactService = new ContactService(LanguageRequest, User);
                ContactModel contactModelRet = contactService.PostUpdateContactDB(contactModel);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

            }

            return GetTVTypeUserAuthorizationModelWithTVTypeUserAuthorizationIDDB(tvTypeUserAuthorizationToUpdate.TVTypeUserAuthorizationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
