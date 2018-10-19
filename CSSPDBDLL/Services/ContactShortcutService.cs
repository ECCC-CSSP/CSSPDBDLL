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
    public class ContactShortcutService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public ContactService _ContactService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ContactShortcutService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _ContactService = new ContactService(LanguageRequest, User);
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
        public string ContactShortcutModelOK(ContactShortcutModel contactShortcutModel)
        {
            string retStr = FieldCheckNotZeroInt(contactShortcutModel.ContactID, ServiceRes.ContactID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(contactShortcutModel.ShortCutText, ServiceRes.ShortCutText, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(contactShortcutModel.ShortCutAddress, ServiceRes.ShortCutAddress, 3, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillContactShortcut(ContactShortcut contactShortcut, ContactShortcutModel contactShortcutModel, ContactOK contactOK)
        {
            contactShortcut.ContactShortcutID = contactShortcutModel.ContactShortcutID;
            contactShortcut.ContactID = (int)contactShortcutModel.ContactID;
            contactShortcut.ShortCutText = contactShortcutModel.ShortCutText;
            contactShortcut.ShortCutAddress = contactShortcutModel.ShortCutAddress;
            contactShortcut.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                contactShortcut.LastUpdateContactTVItemID = 2;
            }
            else
            {
                contactShortcut.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetContactShortcutModelCountDB()
        {
            int contactShortcutModelCount = (from c in db.ContactShortcuts
                                             select c).Count();
            return contactShortcutModelCount;
        }
        public ContactShortcutModel GetContactShortcutModelExistDB(ContactShortcutModel contactShortcutModel)
        {
            ContactShortcutModel contactShortcutModelRet = (from c in db.ContactShortcuts
                                                            where c.ContactID == contactShortcutModel.ContactID
                                                            && c.ShortCutText == contactShortcutModel.ShortCutText
                                                            select new ContactShortcutModel
                                                            {
                                                                Error = "",
                                                                ContactShortcutID = c.ContactShortcutID,
                                                                ContactID = c.ContactID,
                                                                ShortCutText = c.ShortCutText,
                                                                ShortCutAddress = c.ShortCutAddress,
                                                                LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                            }).FirstOrDefault<ContactShortcutModel>();

            if (contactShortcutModelRet == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.ContactID, ServiceRes.ContactID + "," +
                    ServiceRes.ShortCutText,
                    contactShortcutModel.ContactID.ToString() + "," +
                    contactShortcutModel.ShortCutText));
            }

            return contactShortcutModelRet;
        }
        public ContactShortcutModel GetContactShortcutModelWithContactShortcutIDDB(int ContactShortcutID)
        {
            ContactShortcutModel contactShortcutModel = (from c in db.ContactShortcuts
                                                         where c.ContactShortcutID == ContactShortcutID
                                                         select new ContactShortcutModel
                                                         {
                                                             Error = "",
                                                             ContactShortcutID = c.ContactShortcutID,
                                                             ContactID = c.ContactID,
                                                             ShortCutText = c.ShortCutText,
                                                             ShortCutAddress = c.ShortCutAddress,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).FirstOrDefault<ContactShortcutModel>();

            if (contactShortcutModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ContactShortcut, ServiceRes.ContactShortcutID, ContactShortcutID));
            }

            return contactShortcutModel;
        }
        public List<ContactShortcutModel> GetContactShortcutModelListWithContactIDDB(int ContactID)
        {
            List<ContactShortcutModel> contactShortcutModelList = (from c in db.ContactShortcuts
                                                                   where c.ContactID == ContactID
                                                                   select new ContactShortcutModel
                                                                   {
                                                                       Error = "",
                                                                       ContactShortcutID = c.ContactShortcutID,
                                                                       ContactID = c.ContactID,
                                                                       ShortCutText = c.ShortCutText,
                                                                       ShortCutAddress = c.ShortCutAddress,
                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                   }).ToList<ContactShortcutModel>();

            return contactShortcutModelList;
        }
        public ContactShortcut GetContactShortcutWithContactShortcutIDDB(int ContactShortcutID)
        {
            ContactShortcut contactShortcut = (from c in db.ContactShortcuts
                                               where c.ContactShortcutID == ContactShortcutID
                                               select c).FirstOrDefault<ContactShortcut>();
            return contactShortcut;
        }

        // Helper
        public ContactShortcutModel ReturnError(string Error)
        {
            return new ContactShortcutModel() { Error = Error };
        }

        // Post
        public ContactShortcutModel PostAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ContactShortcutID = 0;
            int ContactID = 0;
            string ShortCutText = "";
            string ShortCutAddress = "";

            int.TryParse(fc["ContactShortcutID"], out ContactShortcutID);
            // if 0 then want to add new TVItem else want to modify

            int.TryParse(fc["ContactID"], out ContactID);
            if (ContactID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactID));

            ShortCutText = fc["ShortCutText"];
            if (string.IsNullOrWhiteSpace(ShortCutText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ShortCutText));

            ShortCutAddress = fc["ShortCutAddress"];
            if (string.IsNullOrWhiteSpace(ShortCutAddress))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ShortCutAddress));

            ContactShortcutModel contactShortcutModel = new ContactShortcutModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (ContactShortcutID == 0)
                {
                    ContactModel contactModel = _ContactService.GetContactModelWithContactIDDB(ContactID);
                    if (!string.IsNullOrWhiteSpace(contactModel.Error))
                        return ReturnError(contactModel.Error);

                    ContactShortcutModel contactShortcutModelNew = new ContactShortcutModel()
                    {
                        ContactID = ContactID,
                        ShortCutText = ShortCutText,
                        ShortCutAddress = ShortCutAddress,
                    };

                    contactShortcutModel = GetContactShortcutModelExistDB(contactShortcutModelNew);
                    if (!string.IsNullOrWhiteSpace(contactShortcutModel.Error))
                        return ReturnError(contactShortcutModel.Error);


                    contactShortcutModel = PostAddContactShortcutDB(contactShortcutModelNew);
                    if (!string.IsNullOrWhiteSpace(contactShortcutModel.Error))
                        return ReturnError(contactShortcutModel.Error);

                }
                else
                {

                    ContactShortcutModel contactShortcutModelNew = new ContactShortcutModel()
                    {
                        ContactID = ContactID,
                        ShortCutText = ShortCutText,
                        ShortCutAddress = ShortCutAddress,
                    };

                    ContactShortcutModel contactShortcutModelToChange = GetContactShortcutModelExistDB(contactShortcutModelNew);
                    if (!string.IsNullOrWhiteSpace(contactShortcutModelToChange.Error))
                        return ReturnError(contactShortcutModelToChange.Error);

                    contactShortcutModelToChange.ShortCutAddress = ShortCutAddress;

                    contactShortcutModel = PostUpdateContactShortcutDB(contactShortcutModelToChange);
                    if (!string.IsNullOrWhiteSpace(contactShortcutModel.Error))
                        return ReturnError(contactShortcutModel.Error);

                }

                ts.Complete();
            }

            return contactShortcutModel;
        }
        public ContactShortcutModel PostAddContactShortcutDB(ContactShortcutModel contactShortcutModel)
        {
            string retStr = ContactShortcutModelOK(contactShortcutModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ContactModel contactModel = _ContactService.GetContactModelWithContactIDDB(contactShortcutModel.ContactID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnError(contactModel.Error);

            ContactShortcut contactShortcutNew = new ContactShortcut();
            retStr = FillContactShortcut(contactShortcutNew, contactShortcutModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ContactShortcuts.Add(contactShortcutNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ContactShortcuts", contactShortcutNew.ContactShortcutID, LogCommandEnum.Add, contactShortcutNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetContactShortcutModelWithContactShortcutIDDB(contactShortcutNew.ContactShortcutID);
        }
        public ContactShortcutModel PostDeleteContactShortcutDB(int contactShortcutID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ContactShortcut contactShortcutToDelete = GetContactShortcutWithContactShortcutIDDB(contactShortcutID);
            if (contactShortcutToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ContactShortcut));

            using (TransactionScope ts = new TransactionScope())
            {
                db.ContactShortcuts.Remove(contactShortcutToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ContactShortcuts", contactShortcutToDelete.ContactShortcutID, LogCommandEnum.Delete, contactShortcutToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public ContactShortcutModel PostUpdateContactShortcutDB(ContactShortcutModel contactShortcutModel)
        {
            string retStr = ContactShortcutModelOK(contactShortcutModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            ContactShortcut contactShortcutToUpdate = GetContactShortcutWithContactShortcutIDDB(contactShortcutModel.ContactShortcutID);
            if (contactShortcutToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.ContactShortcut));

            retStr = FillContactShortcut(contactShortcutToUpdate, contactShortcutModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ContactShortcuts", contactShortcutToUpdate.ContactShortcutID, LogCommandEnum.Change, contactShortcutToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetContactShortcutModelWithContactShortcutIDDB(contactShortcutToUpdate.ContactShortcutID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}

