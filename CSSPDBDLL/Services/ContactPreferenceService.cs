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


namespace CSSPDBDLL.Services
{
    public class ContactPreferenceService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public ContactService _ContactService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ContactPreferenceService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _ContactService = new ContactService(LanguageRequest, User);
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
        public string ContactPreferenceModelOK(ContactPreferenceModel contactPreferenceModel)
        {
            string retStr = FieldCheckNotZeroInt(contactPreferenceModel.ContactID, ServiceRes.ContactID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(contactPreferenceModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(contactPreferenceModel.MarkerSize, ServiceRes.MarkerSize, 1, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(contactPreferenceModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillContactPreference(ContactPreference contactPreference, ContactPreferenceModel contactPreferenceModel, ContactOK contactOK)
        {
            contactPreference.DBCommand = (int)contactPreferenceModel.DBCommand;
            contactPreference.ContactPreferenceID = contactPreferenceModel.ContactPreferenceID;
            contactPreference.ContactID = (int)contactPreferenceModel.ContactID;
            contactPreference.TVType = (int)contactPreferenceModel.TVType;
            contactPreference.MarkerSize = contactPreferenceModel.MarkerSize;
            contactPreference.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                contactPreference.LastUpdateContactTVItemID = 2;
            }
            else
            {
                contactPreference.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetContactPreferenceModelCountDB()
        {
            int contactPreferenceModelCount = (from c in db.ContactPreferences
                                               select c).Count();
            return contactPreferenceModelCount;
        }
        public ContactPreferenceModel GetContactPreferenceModelExistDB(ContactPreferenceModel contactPreferenceModel)
        {
            ContactPreferenceModel contactPreferenceModelRet = (from c in db.ContactPreferences
                                                                where c.ContactID == contactPreferenceModel.ContactID
                                                                && c.TVType == (int)contactPreferenceModel.TVType
                                                                select new ContactPreferenceModel
                                                                {
                                                                    Error = "",
                                                                    ContactPreferenceID = c.ContactPreferenceID,
                                                                    DBCommand = (DBCommandEnum)c.DBCommand,
                                                                    ContactID = c.ContactID,
                                                                    TVType = (TVTypeEnum)c.TVType,
                                                                    MarkerSize = c.MarkerSize,
                                                                    LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                    LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                }).FirstOrDefault<ContactPreferenceModel>();

            if (contactPreferenceModelRet == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ContactID, 
                    ServiceRes.ContactID + "," + 
                    ServiceRes.TVType, 
                    contactPreferenceModel.ContactID.ToString() + "," + 
                    contactPreferenceModel.TVType.ToString()));
            }

            return contactPreferenceModelRet;
        }
        public ContactPreferenceModel GetContactPreferenceModelWithContactPreferenceIDDB(int ContactPreferenceID)
        {
            ContactPreferenceModel contactPreferenceModel = (from c in db.ContactPreferences
                                                             where c.ContactPreferenceID == ContactPreferenceID
                                                             select new ContactPreferenceModel
                                                             {
                                                                 Error = "",
                                                                 ContactPreferenceID = c.ContactPreferenceID,
                                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                                 ContactID = c.ContactID,
                                                                 TVType = (TVTypeEnum)c.TVType,
                                                                 MarkerSize = c.MarkerSize,
                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                             }).FirstOrDefault<ContactPreferenceModel>();

            if (contactPreferenceModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ContactPreference, ServiceRes.ContactPreferenceID, ContactPreferenceID));
            }

            return contactPreferenceModel;
        }
        public List<ContactPreferenceModel> GetContactPreferenceModelListWithContactIDDB(int ContactID)
        {
            List<ContactPreferenceModel> contactPreferenceModelList = (from c in db.ContactPreferences
                                                                       where c.ContactID == ContactID
                                                                       select new ContactPreferenceModel
                                                                       {
                                                                           Error = "",
                                                                           ContactPreferenceID = c.ContactPreferenceID,
                                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                                           ContactID = c.ContactID,
                                                                           TVType = (TVTypeEnum)c.TVType,
                                                                           MarkerSize = c.MarkerSize,
                                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                       }).ToList<ContactPreferenceModel>();

            return contactPreferenceModelList;
        }
        public ContactPreference GetContactPreferenceWithContactPreferenceIDDB(int ContactPreferenceID)
        {
            ContactPreference contactPreference = (from c in db.ContactPreferences
                                                   where c.ContactPreferenceID == ContactPreferenceID
                                                   select c).FirstOrDefault<ContactPreference>();
            return contactPreference;
        }

        // Helper
        public ContactPreferenceModel ReturnError(string Error)
        {
            return new ContactPreferenceModel() { Error = Error };
        }

        // Post
        public ContactPreferenceModel PostAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ContactPreferenceID = 0;
            int ContactID = 0;
            int TVTypeInt = 0;
            TVTypeEnum TVType = TVTypeEnum.Error;
            int MarkerSize = 0;

            int.TryParse(fc["ContactPreferenceID"], out ContactPreferenceID);
            // if 0 then want to add new TVItem else want to modify

            int.TryParse(fc["ContactID"], out ContactID);
            if (ContactID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactID));

            int.TryParse(fc["TVType"], out TVTypeInt);
            if (TVTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVType));

            TVType = (TVTypeEnum)TVTypeInt;

            int.TryParse(fc["MarkerSize"], out MarkerSize);
            if (MarkerSize == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MarkerSize));

            ContactPreferenceModel contactPreferenceModel = new ContactPreferenceModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (ContactPreferenceID == 0)
                {
                    ContactModel contactModel = _ContactService.GetContactModelWithContactIDDB(ContactID);
                    if (!string.IsNullOrWhiteSpace(contactModel.Error))
                        return ReturnError(contactModel.Error);

                    ContactPreferenceModel contactPreferenceModelNew = new ContactPreferenceModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        ContactID = ContactID,
                        TVType = TVType,
                        MarkerSize = MarkerSize,
                    };

                    contactPreferenceModel = GetContactPreferenceModelExistDB(contactPreferenceModelNew);
                    if (!string.IsNullOrWhiteSpace(contactPreferenceModel.Error))
                        return ReturnError(contactPreferenceModel.Error);

                    ContactPreferenceModel contactPreferenceModelRet = PostAddContactPreferenceDB(contactPreferenceModelNew);
                    if (!string.IsNullOrWhiteSpace(contactPreferenceModelRet.Error))
                        return ReturnError(contactPreferenceModelRet.Error);

                }
                else
                {

                    ContactPreferenceModel contactPreferenceModelNew = new ContactPreferenceModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        ContactID = ContactID,
                        TVType = TVType,
                        MarkerSize = MarkerSize,
                    };

                    ContactPreferenceModel contactPreferenceModelToChange = GetContactPreferenceModelExistDB(contactPreferenceModelNew);
                    if (!string.IsNullOrWhiteSpace(contactPreferenceModelToChange.Error))
                        return ReturnError(contactPreferenceModelToChange.Error);

                    contactPreferenceModelToChange.MarkerSize = MarkerSize;

                    contactPreferenceModel = PostUpdateContactPreferenceDB(contactPreferenceModelToChange);
                    if (!string.IsNullOrWhiteSpace(contactPreferenceModel.Error))
                        return ReturnError(contactPreferenceModel.Error);
                  
                }

                ts.Complete();
            }

            return contactPreferenceModel;
        }
        public ContactPreferenceModel PostAddContactPreferenceDB(ContactPreferenceModel contactPreferenceModel)
        {
            string retStr = ContactPreferenceModelOK(contactPreferenceModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ContactModel contactModel = _ContactService.GetContactModelWithContactIDDB(contactPreferenceModel.ContactID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnError(contactModel.Error);

            ContactPreference contactPreferenceNew = new ContactPreference();
            retStr = FillContactPreference(contactPreferenceNew, contactPreferenceModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ContactPreferences.Add(contactPreferenceNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ContactPreferences", contactPreferenceNew.ContactPreferenceID, LogCommandEnum.Add, contactPreferenceNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetContactPreferenceModelWithContactPreferenceIDDB(contactPreferenceNew.ContactPreferenceID);
        }
        public ContactPreferenceModel PostDeleteContactPreferenceDB(int contactPreferenceID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ContactPreference contactPreferenceToDelete = GetContactPreferenceWithContactPreferenceIDDB(contactPreferenceID);
            if (contactPreferenceToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ContactPreference));

            using (TransactionScope ts = new TransactionScope())
            {
                db.ContactPreferences.Remove(contactPreferenceToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ContactPreferences", contactPreferenceToDelete.ContactPreferenceID, LogCommandEnum.Delete, contactPreferenceToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public ContactPreferenceModel PostUpdateContactPreferenceDB(ContactPreferenceModel contactPreferenceModel)
        {
            string retStr = ContactPreferenceModelOK(contactPreferenceModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ContactPreference contactPreferenceToUpdate = GetContactPreferenceWithContactPreferenceIDDB(contactPreferenceModel.ContactPreferenceID);
            if (contactPreferenceToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ContactPreference));

            retStr = FillContactPreference(contactPreferenceToUpdate, contactPreferenceModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ContactPreferences", contactPreferenceToUpdate.ContactPreferenceID, LogCommandEnum.Change, contactPreferenceToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetContactPreferenceModelWithContactPreferenceIDDB(contactPreferenceToUpdate.ContactPreferenceID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

