using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Principal;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class ContactService : BaseService
    {
        #region Variables
        int UniqueCodeSize = 8; // maximum is 12 in the DB
        int SearchMaxReturn = 10;
        #endregion Variables

        #region Properties
        public AspNetUserService _AspNetUserService { get; private set; }
        public TVTypeUserAuthorizationService _TVTypeUserAuthorizationService { get; private set; }
        public TVItemUserAuthorizationService _TVItemUserAuthorizationService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public ResetPasswordService _ResetPasswordService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public MWQMRunService _MWQMRunService { get; private set; }
        public PolSourceObservationService _PolSourceObservationService { get; private set; }
        public TelService _TelService { get; private set; }
        public EmailService _EmailService { get; private set; }
        public AddressService _AddressService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ContactService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            Init(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
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
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        public override bool IsAdministratorDB(string LoginEmail = "")
        {
            return base.IsAdministratorDB(LoginEmail);
        }
        public override bool IsSamplingPlannerDB(string LoginEmail = "")
        {
            return base.IsSamplingPlannerDB(LoginEmail);
        }
        public override string EmailOK(string Email)
        {
            return base.EmailOK(Email);
        }
        public override ContactModel GetContactLoggedInDB()
        {
            return base.GetContactLoggedInDB();
        }
        public override ContactModel GetContactModelWithContactIDDB(int ContactID)
        {
            return base.GetContactModelWithContactIDDB(ContactID);
        }
        public override string SendEmail(MailMessage mail)
        {
            return base.SendEmail(mail);
        }
        public override ContactModel GetContactModelWithContactTVItemIDDB(int ContactTVItemID)
        {
            return base.GetContactModelWithContactTVItemIDDB(ContactTVItemID);
        }

        // Check
        public string CheckCodeEmailExistDB(string CodeEmail)
        {
            CodeEmail = CodeEmail.Trim();

            string[] strArr = CodeEmail.Split(",".ToCharArray()[0]);
            if (strArr.Length != 2)
            {
                return string.Format(ServiceRes._IsNotComposedOf_Parts, ServiceRes.CodeEmail, 2);
            }

            string Code = strArr[0].Trim();
            string Email = strArr[1].Trim();

            string retStr = FieldCheckNotNullAndMinMaxLengthString(Code, ServiceRes.Code, 8, 8);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = EmailOK(Email);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            ResetPassword resetPassword = (from a in db.ResetPasswords
                                           where a.Email == Email
                                           && a.Code == Code
                                           orderby a.ResetPasswordID descending
                                           select a).FirstOrDefault<ResetPassword>();

            if (resetPassword != null)
                return "true";
            else
                return string.Format(ServiceRes.Code_ForEmail_DoesNotExist, Code, Email);

        }
        public string CheckEmailExistDB(string Email)
        {

            string retStr = EmailOK(Email);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            Contact contact = (from c in db.Contacts
                               from a in db.AspNetUsers
                               where c.Id == a.Id
                               && a.UserName == Email
                               select c).FirstOrDefault<Contact>();

            if (contact != null)
                return "true";
            else
                return string.Format(ServiceRes._DoesNotExist, Email);

        }
        public string CheckEmailUniquenessDB(string Email)
        {
            Contact contact = new Contact();

            ContactOK contactOK = IsContactOK();
            if (string.IsNullOrWhiteSpace(contactOK.Error))
            {
                contact = (from c in db.Contacts
                           from a in db.AspNetUsers
                           where c.Id == a.Id
                           && a.Email == Email
                           && a.Email != User.Identity.Name
                           select c).FirstOrDefault<Contact>();
            }
            else
            {
                contact = (from c in db.Contacts
                           from a in db.AspNetUsers
                           where c.Id == a.Id
                           && a.Email == Email
                           select c).FirstOrDefault<Contact>();
            }

            if (contact == null)
                return "true";
            else
                return string.Format(ServiceRes._IsAlreadyTaken, Email);

        }
        public string CheckFullNameUniquenessDB(string FullName)
        {
            string[] strArr = FullName.Split(",".ToCharArray()[0]);

            if (strArr.Length != 3)
            {
                return string.Format(ServiceRes._IsNotComposedOf_Parts, ServiceRes.FullName, 3);
            }
            string FirstName = strArr[0].Trim();
            string Initial = strArr[1].Trim();
            string LastName = strArr[2].Trim();

            if (!string.IsNullOrWhiteSpace(Initial))
            {
                if (Initial != "")
                {
                    if (Initial.Last().ToString() == ".")
                    {
                        Initial = Initial.Substring(0, Initial.Length - 1);
                    }
                }
            }
            else
            {
                Initial = "";
            }
            Contact contact;
            ContactOK contactOK = IsContactOK();
            if (string.IsNullOrWhiteSpace(contactOK.Error))
            {
                contact = (from c in db.Contacts
                           from a in db.AspNetUsers
                           where c.Id == a.Id
                           && c.FirstName == FirstName
                           && c.LastName == LastName
                           && c.Initial == Initial
                           && a.Email != User.Identity.Name
                           select c).FirstOrDefault<Contact>();
            }
            else
            {
                contact = (from c in db.Contacts
                           from a in db.AspNetUsers
                           where c.Id == a.Id
                           && c.FirstName == FirstName
                           && c.LastName == LastName
                           && c.Initial == Initial
                           select c).FirstOrDefault<Contact>();
            }

            if (contact == null)
                return "true";
            else
                return string.Format(ServiceRes._IsAlreadyTaken, strArr[0] + (string.IsNullOrEmpty(strArr[1]) ? " " : " " + strArr[1] + ", ") + strArr[2]);

        }
        public string CheckWebNameUniquenessDB(string WebName)
        {
            Contact contact = new Contact();
            ContactOK contactOK = IsContactOK();
            if (string.IsNullOrWhiteSpace(contactOK.Error))
            {
                contact = (from c in db.Contacts
                           from a in db.AspNetUsers
                           where c.Id == a.Id
                           && c.WebName == WebName
                           && a.Email != User.Identity.Name
                           select c).FirstOrDefault<Contact>();
            }
            else
            {
                contact = (from c in db.Contacts
                           from a in db.AspNetUsers
                           where c.Id == a.Id
                           && c.WebName == WebName
                           select c).FirstOrDefault<Contact>();
            }

            if (contact == null)
                return "true";
            else
                return string.Format(ServiceRes._IsAlreadyTaken, WebName);

        }
        public string ContactModelOK(ContactModel contactModel)
        {
            bool LoginIsAdmin = GetContactLoggedInDB().IsAdmin;
            string retStr = FieldCheckNotZeroInt(contactModel.ContactTVItemID, ServiceRes.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(contactModel.WebName, ServiceRes.WebName, 3, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(contactModel.FirstName, ServiceRes.FirstName, 1, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(contactModel.Initial, ServiceRes.Initial, 0, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(contactModel.LastName, ServiceRes.LastName, 1, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.ContactTitleOK(contactModel.ContactTitle);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            string retStrEmail = EmailOK(contactModel.LoginEmail);
            if (!string.IsNullOrWhiteSpace(retStrEmail))
            {
                return retStrEmail;
            }

            Contact contactExist = null;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
            {
                // Probably trying to register
                contactExist = (from c in db.Contacts
                                where c.WebName == contactModel.WebName.Trim()
                                select c).FirstOrDefault<Contact>();

            }
            else
            {
                if (User.Identity.Name != contactModel.LoginEmail)
                {
                    // Can only change contact info if contact
                    if (!contactModel.IsNew && !LoginIsAdmin)
                    {
                        return ServiceRes.NotAllowedToChangeContactInformation;
                    }

                    if (contactModel.ContactID > 0)
                    {
                        contactExist = (from c in db.Contacts
                                        where c.ContactID != contactModel.ContactID
                                        && c.WebName == contactModel.WebName.Trim()
                                        select c).FirstOrDefault<Contact>();
                    }
                }
                else
                {
                    // Probably trying to change some info from profile (FirstName, LastName, WebName etc...)
                    contactExist = (from c in db.Contacts
                                    from a in db.AspNetUsers
                                    where c.Id == a.Id
                                    && c.WebName == contactModel.WebName.Trim()
                                    && a.Email != User.Identity.Name
                                    select c).FirstOrDefault<Contact>();
                }
            }

            if (contactExist != null)
            {
                return string.Format(ServiceRes._HasToBeUnique, ServiceRes.WebName);
            }

            // checking that the combination of FirstName, LastName and Initial is unique
            contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
            {
                // Probably trying to register
                if (string.IsNullOrWhiteSpace(contactModel.Initial))
                {
                    contactModel.Initial = "";
                }

                contactExist = (from c in db.Contacts
                                where c.FirstName == contactModel.FirstName.Trim()
                                && c.LastName == contactModel.LastName.Trim()
                                && c.Initial == contactModel.Initial.Trim()
                                select c).FirstOrDefault<Contact>();

            }
            else
            {
                // Probably trying to change some info from profile (FirstName, LastName, WebName etc...)
                if (string.IsNullOrWhiteSpace(contactModel.Initial))
                {
                    contactModel.Initial = "";
                }

                if (User.Identity.Name != contactModel.LoginEmail)
                {
                    // Can only change contact info if contact
                    if (!contactModel.IsNew && !LoginIsAdmin)
                    {
                        return ServiceRes.NotAllowedToChangeContactInformation;
                    }

                    if (contactModel.ContactID > 0)
                    {
                        contactExist = (from c in db.Contacts
                                        where c.ContactID != contactModel.ContactID
                                        && c.FirstName == contactModel.FirstName
                                        && c.LastName == contactModel.LastName
                                        && c.Initial.Trim() == contactModel.Initial.Trim()
                                        select c).FirstOrDefault<Contact>();
                    }
                }
                else
                {
                    contactExist = (from c in db.Contacts
                                    from a in db.AspNetUsers
                                    where c.Id == a.Id
                                    && c.FirstName == contactModel.FirstName
                                    && c.LastName == contactModel.LastName
                                    && c.Initial.Trim() == contactModel.Initial.Trim()
                                    && a.Email != User.Identity.Name
                                    select c).FirstOrDefault<Contact>();

                }
            }

            if (contactExist != null)
            {
                return string.Format(ServiceRes._HasToBeUnique, ServiceRes.FullName);
            }

            // checking that Email is unique which is also the UserName of the Users
            contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
            {
                contactExist = (from c in db.Contacts
                                from a in db.AspNetUsers
                                where c.Id == a.Id
                                && a.Email == contactModel.LoginEmail.Trim()
                                select c).FirstOrDefault<Contact>();

            }
            else
            {
                if (User.Identity.Name != contactModel.LoginEmail)
                {
                    // Can only change contact info if contact
                    if (!contactModel.IsNew && !LoginIsAdmin)
                    {
                        return ServiceRes.NotAllowedToChangeContactInformation;
                    }

                    if (contactModel.ContactID > 0)
                    {
                        contactExist = (from c in db.Contacts
                                        where c.ContactID != contactModel.ContactID
                                        && c.LoginEmail == contactModel.LoginEmail.Trim()
                                        select c).FirstOrDefault<Contact>();
                    }
                }
                else
                {
                    contactExist = (from c in db.Contacts
                                    from a in db.AspNetUsers
                                    where c.Id == a.Id
                                    && a.Email == contactModel.LoginEmail.Trim()
                                    && a.Email != User.Identity.Name
                                    select c).FirstOrDefault<Contact>();
                }
            }

            if (contactExist != null)
            {
                return string.Format(ServiceRes._HasToBeUnique, ServiceRes.Email);
            }

            retStr = _BaseEnumService.DBCommandOK(contactModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }
        public string LoginModelOK(LoginModel loginModel)
        {
            string retStr = EmailOK(loginModel.Email);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (string.IsNullOrWhiteSpace(loginModel.Password))
            {
                return string.Format(ServiceRes._IsRequired, ServiceRes.Password);
            }

            if (loginModel.Password.Length > 100)
            {
                return string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Password, "100");
            }

            return "";
        }
        public string NewContactModelOK(NewContactModel newContactModel)
        {
            string retStr = FieldCheckNotEmptyAndMaxLengthString(newContactModel.FirstName, ServiceRes.FirstName, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(newContactModel.LastName, ServiceRes.LastName, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(newContactModel.Initial, ServiceRes.Initial, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            string retStrEmail = EmailOK(newContactModel.LoginEmail);
            if (!string.IsNullOrWhiteSpace(retStrEmail))
            {
                return retStrEmail;
            }

            return "";
        }
        public string RegisterModelOK(RegisterModel registerModel)
        {
            string retStr = FieldCheckNotEmptyAndMaxLengthString(registerModel.WebName, ServiceRes.WebName, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(registerModel.FirstName, ServiceRes.FirstName, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(registerModel.Initial, ServiceRes.Initial, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(registerModel.LastName, ServiceRes.LastName, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            string retStrEmail = EmailOK(registerModel.LoginEmail);
            if (!string.IsNullOrWhiteSpace(retStrEmail))
            {
                return retStrEmail;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(registerModel.Password, ServiceRes.Password, 6, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                return ServiceRes.PasswordAndConfirmPasswordNotIdentical;
            }

            Contact contactExist = new Contact();

            contactExist = (from c in db.Contacts
                            where c.WebName == registerModel.WebName.Trim()
                            select c).FirstOrDefault<Contact>();


            if (contactExist != null)
            {
                return string.Format(ServiceRes._HasToBeUnique, ServiceRes.WebName);
            }

            if (string.IsNullOrWhiteSpace(registerModel.Initial))
            {
                registerModel.Initial = "";
            }

            contactExist = (from c in db.Contacts
                            where c.FirstName == registerModel.FirstName.Trim()
                            && c.LastName == registerModel.LastName.Trim()
                            && c.Initial == registerModel.Initial.Trim()
                            select c).FirstOrDefault<Contact>();


            if (contactExist != null)
            {
                return string.Format(ServiceRes._HasToBeUnique, ServiceRes.FullName);
            }

            contactExist = (from c in db.Contacts
                            from a in db.AspNetUsers
                            where c.Id == a.Id
                            && a.Email == registerModel.LoginEmail.Trim()
                            select c).FirstOrDefault<Contact>();

            if (contactExist != null)
            {
                return string.Format(ServiceRes._HasToBeUnique, ServiceRes.Email);
            }


            return ""; // everything is ok you can register the new user
        }

        // Fill
        public string FillContact(Contact contact, ContactModel contactModel, ContactOK contactOK)
        {
            contact.DBCommand = (int)contactModel.DBCommand;
            contact.Id = contactModel.Id;
            contact.ContactTVItemID = contactModel.ContactTVItemID;
            contact.LoginEmail = contactModel.LoginEmail;
            contact.FirstName = contactModel.FirstName;
            contact.LastName = contactModel.LastName;
            if (contactModel.ContactTitle == null)
            {
                contact.ContactTitle = null;
            }
            else
            {
                contact.ContactTitle = (int)contactModel.ContactTitle;
            }
            contact.Initial = contactModel.Initial;
            contact.WebName = contactModel.WebName;
            contact.IsAdmin = contactModel.IsAdmin;
            contact.IsNew = contactModel.IsNew;
            contact.SamplingPlanner_ProvincesTVItemID = contactModel.SamplingPlanner_ProvincesTVItemID;
            contact.EmailValidated = contactModel.EmailValidated;
            contact.Disabled = contactModel.Disabled;
            contact.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                contact.LastUpdateContactTVItemID = 2;
            }
            else
            {
                contact.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public List<ContactModel> GetAdminContactModelListDB()
        {
            List<ContactModel> contactModelList = (from c in db.Contacts
                                                   from a in db.AspNetUsers
                                                   from t in db.TVTypeUserAuthorizations
                                                   where c.Id == a.Id
                                                   && c.ContactTVItemID == t.ContactTVItemID
                                                   && t.TVType == (int)TVTypeEnum.Root
                                                   && t.TVAuth == (int)TVAuthEnum.Admin
                                                   select new ContactModel
                                                   {
                                                       Error = "",
                                                       ContactID = c.ContactID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       Id = c.Id,
                                                       ContactTVItemID = c.ContactTVItemID,
                                                       Disabled = c.Disabled,
                                                       EmailValidated = c.EmailValidated,
                                                       FirstName = c.FirstName,
                                                       Initial = c.Initial,
                                                       IsAdmin = c.IsAdmin,
                                                       IsNew = c.IsNew,
                                                       SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                                                       LastName = c.LastName,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LoginEmail = a.Email,
                                                       WebName = c.WebName,
                                                       ContactTitle = (ContactTitleEnum)c.ContactTitle,
                                                   }).ToList<ContactModel>();

            return contactModelList;
        }
        public int GetContactModelCountDB()
        {
            int contactModelCount = (from c in db.Contacts
                                     select c).Count();

            return contactModelCount;
        }
        public ContactModel GetContactModelAndTelEmailAddressListWithContactTVItemIDDB(int ContactTVItemID)
        {
            ContactModel contactModel = (from c in db.Contacts
                                         where c.ContactTVItemID == ContactTVItemID
                                         select new ContactModel
                                         {
                                             Error = "",
                                             ContactID = c.ContactID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             Id = c.Id,
                                             ContactTVItemID = c.ContactTVItemID,
                                             Disabled = c.Disabled,
                                             EmailValidated = c.EmailValidated,
                                             FirstName = c.FirstName,
                                             Initial = c.Initial,
                                             IsAdmin = c.IsAdmin,
                                             IsNew = c.IsNew,
                                             SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                                             LastName = c.LastName,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LoginEmail = c.LoginEmail,
                                             WebName = c.WebName,
                                             ContactTitle = (ContactTitleEnum)c.ContactTitle,
                                         }).FirstOrDefault<ContactModel>();

            if (contactModel == null)
                return ReturnContactError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.ContactTVItemID, ContactTVItemID));

            List<TVItemLinkModel> tvItemLinkModelList = _TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(ContactTVItemID);

            List<TelModel> telModelList = new List<TelModel>();
            List<EmailModel> emailModelList = new List<EmailModel>();
            List<AddressModel> addressModelList = new List<AddressModel>();
            foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList)
            {
                if (tvItemLinkModel.ToTVType == TVTypeEnum.Tel)
                {
                    telModelList.Add(_TelService.GetTelModelWithTelTVItemIDDB(tvItemLinkModel.ToTVItemID));
                }
                if (tvItemLinkModel.ToTVType == TVTypeEnum.Email)
                {
                    emailModelList.Add(_EmailService.GetEmailModelWithEmailTVItemIDDB(tvItemLinkModel.ToTVItemID));
                }
                if (tvItemLinkModel.ToTVType == TVTypeEnum.Address)
                {
                    addressModelList.Add(_AddressService.GetAddressModelWithAddressTVItemIDDB(tvItemLinkModel.ToTVItemID));
                }
            }

            contactModel.TelList = telModelList;
            contactModel.EmailList = emailModelList;
            contactModel.AddressList = addressModelList;

            return contactModel;
        }
        public List<ContactModel> GetContactModelListDB(int skip, int take)
        {
            take = Math.Min(take, TakeMax);

            List<ContactModel> contactModelList = (from c in db.Contacts
                                                   from a in db.AspNetUsers
                                                   where c.Id == a.Id
                                                   orderby c.LastName, c.Initial, c.FirstName
                                                   select new ContactModel
                                                   {
                                                       Error = "",
                                                       ContactID = c.ContactID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       Id = c.Id,
                                                       ContactTVItemID = c.ContactTVItemID,
                                                       Disabled = c.Disabled,
                                                       EmailValidated = c.EmailValidated,
                                                       FirstName = c.FirstName,
                                                       Initial = c.Initial,
                                                       IsAdmin = c.IsAdmin,
                                                       IsNew = c.IsNew,
                                                       SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                                                       LastName = c.LastName,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LoginEmail = a.Email,
                                                       WebName = c.WebName,
                                                       ContactTitle = (ContactTitleEnum)c.ContactTitle,
                                                   }).Skip(skip).Take(take).ToList<ContactModel>();

            return contactModelList;
        }
        public ContactModel GetContactModelWithLoginEmailDB(string LoginEmail)
        {
            ContactModel contactModel = (from c in db.Contacts
                                         from a in db.AspNetUsers
                                         where c.Id == a.Id
                                         && a.Email == LoginEmail
                                         select new ContactModel
                                         {
                                             Error = "",
                                             ContactID = c.ContactID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             Id = c.Id,
                                             ContactTVItemID = c.ContactTVItemID,
                                             Disabled = c.Disabled,
                                             EmailValidated = c.EmailValidated,
                                             FirstName = c.FirstName,
                                             Initial = c.Initial,
                                             IsAdmin = c.IsAdmin,
                                             IsNew = c.IsNew,
                                             SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                                             LastName = c.LastName,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LoginEmail = a.Email,
                                             WebName = c.WebName,
                                             ContactTitle = (ContactTitleEnum)c.ContactTitle,
                                         }).FirstOrDefault<ContactModel>();

            if (contactModel == null)
                return ReturnContactError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.LoginEmail, LoginEmail));

            return contactModel;
        }
        public ContactModel GetContactModelWithFirstNameInitialAndLastNameDB(string FirstName, string Initial, string LastName)
        {
            ContactModel contactModel = (from c in db.Contacts
                                         from a in db.AspNetUsers
                                         where c.Id == a.Id
                                         && c.FirstName == FirstName
                                         && c.Initial == Initial
                                         && c.LastName == LastName
                                         select new ContactModel
                                         {
                                             Error = "",
                                             ContactID = c.ContactID,
                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                             Id = c.Id,
                                             ContactTVItemID = c.ContactTVItemID,
                                             Disabled = c.Disabled,
                                             EmailValidated = c.EmailValidated,
                                             FirstName = c.FirstName,
                                             Initial = c.Initial,
                                             IsAdmin = c.IsAdmin,
                                             IsNew = c.IsNew,
                                             SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                                             LastName = c.LastName,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LoginEmail = a.Email,
                                             WebName = c.WebName,
                                             ContactTitle = (ContactTitleEnum)c.ContactTitle,
                                         }).FirstOrDefault<ContactModel>();

            if (contactModel == null)
                return ReturnContactError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.Name, MakeFullName(FirstName, Initial, LastName)));

            return contactModel;
        }
        public List<ContactModel> GetContactModelWithFirstLetterDB(string FirstLetter)
        {
            if (string.IsNullOrWhiteSpace(FirstLetter))
            {
                return new List<ContactModel>() { new ContactModel() { Error = string.Format(ServiceRes._IsRequired, ServiceRes.FirstLetter) } };
            }

            if (FirstLetter.Length != 1)
            {
                return new List<ContactModel>() { new ContactModel() { Error = string.Format(ServiceRes._MaxLengthIs_, ServiceRes.FirstLetter, 1) } };
            }

            List<ContactModel> contactModelList = (from c in db.Contacts
                                                   from a in db.AspNetUsers
                                                   where c.Id == a.Id
                                                   && c.LastName.StartsWith(FirstLetter)
                                                   orderby c.LastName, c.FirstName, c.Initial
                                                   select new ContactModel
                                                   {
                                                       Error = "",
                                                       ContactID = c.ContactID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       Id = c.Id,
                                                       ContactTVItemID = c.ContactTVItemID,
                                                       Disabled = c.Disabled,
                                                       EmailValidated = c.EmailValidated,
                                                       FirstName = c.FirstName,
                                                       Initial = c.Initial,
                                                       IsAdmin = c.IsAdmin,
                                                       IsNew = c.IsNew,
                                                       SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                                                       LastName = c.LastName,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LoginEmail = a.Email,
                                                       WebName = c.WebName,
                                                       ContactTitle = (ContactTitleEnum)c.ContactTitle,
                                                   }).ToList<ContactModel>();

            return contactModelList;
        }
        public List<ContactModel> GetContactModelWithSamplingPlanner_ProvincesTVItemIDDB(int ProvinceTVItemID)
        {
            List<ContactModel> contactModelList = (from c in db.Contacts
                                                   from a in db.AspNetUsers
                                                   where c.Id == a.Id
                                                   && c.SamplingPlanner_ProvincesTVItemID.Contains(ProvinceTVItemID.ToString())
                                                   select new ContactModel
                                                   {
                                                       Error = "",
                                                       ContactID = c.ContactID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       Id = c.Id,
                                                       ContactTVItemID = c.ContactTVItemID,
                                                       Disabled = c.Disabled,
                                                       EmailValidated = c.EmailValidated,
                                                       FirstName = c.FirstName,
                                                       Initial = c.Initial,
                                                       IsAdmin = c.IsAdmin,
                                                       IsNew = c.IsNew,
                                                       SamplingPlanner_ProvincesTVItemID = c.SamplingPlanner_ProvincesTVItemID,
                                                       LastName = c.LastName,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LoginEmail = a.Email,
                                                       WebName = c.WebName,
                                                       ContactTitle = (ContactTitleEnum)c.ContactTitle,
                                                   }).ToList<ContactModel>();


            return contactModelList;
        }
        public Contact GetContactWithContactIDDB(int ContactID)
        {
            Contact contact = (from c in db.Contacts
                               from a in db.AspNetUsers
                               where c.Id == a.Id
                               && c.ContactID == ContactID
                               select c).FirstOrDefault<Contact>();

            return contact;
        }
        public Contact GetContactWithContactTVItemIDDB(int ContactTVItemID)
        {
            Contact contact = (from c in db.Contacts
                               from a in db.AspNetUsers
                               where c.Id == a.Id
                               && c.ContactTVItemID == ContactTVItemID
                               select c).FirstOrDefault<Contact>();

            return contact;
        }
        public Contact GetContactWithEmailDB(string LoginEmail)
        {
            Contact contact = (from c in db.Contacts
                               from a in db.AspNetUsers
                               where c.Id == a.Id
                               && a.Email == LoginEmail
                               select c).FirstOrDefault<Contact>();

            return contact;
        }
        public List<string> GetFirstLetterOfLastNameDB()
        {
            List<string> lastNameFirstLetterList = (from c in db.Contacts
                                                    let first = c.LastName.Substring(0, 1)
                                                    orderby first
                                                    select first.ToUpper()).Distinct().ToList<string>();

            return lastNameFirstLetterList;
        }
        public List<ResetPassword> GetResetPasswordWithExpireDate_LocalSmallerThanToday()
        {
            List<ResetPassword> resetPasswordList = (from r in db.ResetPasswords
                                                     where r.ExpireDate_Local < DateTime.Today
                                                     select r).ToList<ResetPassword>();

            return resetPasswordList;
        }
        public List<ResetPassword> GetResetPasswordWithEmail(string LoginEmail)
        {
            List<ResetPassword> resetPasswordList = (from r in db.ResetPasswords
                                                     where r.Email == LoginEmail
                                                     select r).ToList<ResetPassword>();

            return resetPasswordList;
        }

        // Helper
        public string AddTVTypeUserAuthorization(TVTypeUserAuthorization tvTypeUserAuthorizationNew)
        {
            db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorizationNew);
            string retStr = DoAddChanges();
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            LogModel logModel = _LogService.PostAddLogForObj("TVTypeUserAuthorizations", tvTypeUserAuthorizationNew.TVTypeUserAuthorizationID, LogCommandEnum.Add, tvTypeUserAuthorizationNew);
            if (!string.IsNullOrWhiteSpace(logModel.Error))
                return logModel.Error;

            return "";
        }
        public bool ContactTVItemIDIsBeingUsed(int ContactTVItemID)
        {
            // Check everywhere ContactTVItemID could exist
            // MWQMRuns SamplingContactTVItemID, LabSampleApprovalContactTVItemID
            // PolSourceObservations ContactTVItemID
            // TVItemLinks FromTVItemID, ToTVItemID

            List<MWQMRunModel> mwqmRunModelList = _MWQMRunService.GetMWQMRunModelListWithLabSampleApprovalContactTVItemIDDB(ContactTVItemID);
            if (mwqmRunModelList.Count > 0)
                return true;

            PolSourceObservationModel polSourceObservationModel = _PolSourceObservationService.GetPolSourceObservationModelFirstWithContactTVItemIDDB(ContactTVItemID);
            if (string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
                return true;

            List<TVItemLink> tvItemLinkList = _TVItemLinkService.GetTVItemLinkListWithFromTVItemIDDB(ContactTVItemID);
            if (tvItemLinkList.Count > 0)
                return true;

            tvItemLinkList = _TVItemLinkService.GetTVItemLinkListWithToTVItemIDDB(ContactTVItemID);
            if (tvItemLinkList.Count > 0)
                return true;

            return false;
        }
        public string CreateTVText(ContactModel contactModel)
        {
            return MakeFullName(contactModel.FirstName, contactModel.Initial, contactModel.LastName);
        }
        public string CreateUniquePassword()
        {
            string uniquePassword = "";
            for (int i = 0; i < 12; i++)
            {
                uniquePassword += random.Next(0, 9).ToString().First();
            }

            return uniquePassword;
        }
        public string CreateUniqueWebName(string FirstName, string LastName)
        {
            string UniqueWebName = FirstName + "_" + LastName;
            for (int i = 1; i < 100; i++)
            {
                string retStr = CheckWebNameUniquenessDB(UniqueWebName);
                if (retStr == "true")
                {
                    break;
                }
                UniqueWebName = FirstName + "_" + LastName + "_" + i;
            }

            return UniqueWebName;
        }
        public void Init(LanguageEnum LanguageRequest, IPrincipal User)
        {
            _AspNetUserService = new AspNetUserService(LanguageRequest, User);
            _TVTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, User);
            _TVItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
            _ResetPasswordService = new ResetPasswordService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MWQMRunService = new MWQMRunService(LanguageRequest, User);
            _PolSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
            _TelService = new TelService(LanguageRequest, User);
            _EmailService = new EmailService(LanguageRequest, User);
            _AddressService = new AddressService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
        }
        public string GenerateUniqueCodeForResetPasswordDB()
        {
            string UniqueCode = "";

            Random r = new Random((int)DateTime.Now.Ticks);

            while (UniqueCode.Length < UniqueCodeSize)
            {
                UniqueCode += (r.Next(0, 9)).ToString();
            }

            return UniqueCode;
        }
        public string GetBodyForSendEmailWithCode(string Email, string Code)
        {
            return ServiceRes.PlsUseFollowingUniqueCodeEtc
                + @"<br />"
                + @"<br />"
                + ServiceRes.YourEmailIs + " " + Email + @"<br />"
                + @"<br />"
                + ServiceRes.CodeIs + " " + Code + @"<br />"
                + @"<br />"
                + ServiceRes.AutoEmailFromServer + @"<br />";
        }
        public string GetBodyOfCreateNewContactAndEmail(string FullNameLoggedIn, string FullNameAdded, string CreatorEmail)
        {
            if (CreatorEmail == "")
            {
                return string.Format(ServiceRes._RegisteredAndAddedInWebSite, @"<b>" + FullNameAdded + @"</b>  @<br />");
            }
            else
            {
                return string.Format(ServiceRes._AddedInWebSiteBy_, @"<b>" + FullNameAdded + "</b>", FullNameLoggedIn + @"<br />");
            }
        }
        public int GetContactIDFromLoggedInUserDB()
        {
            int ContactID = 0;
            ContactID = (from c in db.Contacts
                         from a in db.AspNetUsers
                         where c.Id == a.Id
                         && a.Email == User.Identity.Name
                         select c.ContactID).FirstOrDefault<int>();

            return ContactID;
        }
        public string GetSubjectOfCreateNewContactAndEmail(string FullNameLoggedIn, string FullNameAdded, string CreatorEmail)
        {
            if (CreatorEmail == "")
            {
                return string.Format(ServiceRes._RegisteredAndAddedInWebSite, FullNameAdded);
            }
            else
            {
                return string.Format(ServiceRes.YouBeenAddedInWebSiteBy_, FullNameLoggedIn);
            }
        }
        public string MakeFullName(string FirstName, string Initial, string LastName)
        {
            return LastName + ", " + FirstName + (string.IsNullOrWhiteSpace(Initial) ? "" : " " + Initial + ".");
        }
        public ContactModel ReturnContactError(string Error)
        {
            return new ContactModel() { Error = Error };
        }
        public RegisterModel ReturnRegisterError(string Error)
        {
            return new RegisterModel() { Error = Error };
        }
        public ResetPasswordModel ReturnResetPasswordError(string Error)
        {
            return new ResetPasswordModel() { Error = Error };
        }
        public RegisterModel SetRegisterModel(RegisterModel registerModel)
        {
            registerModel.Password = CreateUniquePassword();
            registerModel.ConfirmPassword = registerModel.Password;
            registerModel.Initial = "";

            string retStr = EmailOK(registerModel.LoginEmail);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnRegisterError(retStr);

            if (string.IsNullOrWhiteSpace(registerModel.FirstName))
                return ReturnRegisterError(string.Format(ServiceRes._IsRequired, ServiceRes.FirstName));

            if (string.IsNullOrWhiteSpace(registerModel.LastName))
                return ReturnRegisterError(string.Format(ServiceRes._IsRequired, ServiceRes.LastName));

            registerModel.WebName = CreateUniqueWebName(registerModel.FirstName, registerModel.LastName);

            retStr = RegisterModelOK(registerModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnRegisterError(retStr);

            return registerModel;
        }

        // Post
        public ContactModel PostAddOrModifyContactUnderParentTVItemIDDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            int ParentTVItemID = 0;
            int ContactTVItemID = 0;
            string FirstName = "";
            string Initial = "";
            string LastName = "";
            string LoginEmail = "";
            int TempInt = 0;
            ContactTitleEnum? ContactTitle = ContactTitleEnum.Error;

            int.TryParse(fc["ParentTVItemID"], out ParentTVItemID);
            if (ParentTVItemID == 0)
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            // if 0 then want to add new TVItem else want to modify

            FirstName = fc["FirstName"];
            if (string.IsNullOrWhiteSpace(FirstName))
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.FirstName));

            Initial = fc["Initial"];

            LastName = fc["LastName"];
            if (string.IsNullOrWhiteSpace(LastName))
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.LastName));

            LoginEmail = fc["LoginEmail"];
            if (string.IsNullOrWhiteSpace(LoginEmail))
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.LoginEmail));

            int.TryParse(fc["ContactTitle"], out TempInt);
            if (TempInt == 0)
            {
                ContactTitle = null;
            }
            else
            {
                ContactTitle = (ContactTitleEnum)TempInt;
            }

            ContactModel contactModel = new ContactModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (ContactTVItemID == 0)
                {
                    NewContactModel newContactModelNew = new NewContactModel()
                    {
                        FirstName = FirstName,
                        Initial = Initial,
                        LastName = LastName,
                        LoginEmail = LoginEmail,
                        ContactTitle = ContactTitle,
                    };
                    contactModel = PostLoggedInUserCreateNewUserDB(newContactModelNew);
                    if (!string.IsNullOrWhiteSpace(contactModel.Error))
                        return ReturnContactError(contactModel.Error);

                    TVItemModel tvItemModelParent = _TVItemService.GetTVItemModelWithTVItemIDDB(ParentTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                        return ReturnContactError(tvItemModelParent.Error);

                    TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(contactModel.ContactTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                        return ReturnContactError(tvItemModelContact.Error);

                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        FromTVItemID = tvItemModelParent.TVItemID,
                        ToTVItemID = contactModel.ContactTVItemID,
                        FromTVType = tvItemModelParent.TVType,
                        ToTVType = TVTypeEnum.Contact,
                        StartDateTime_Local = DateTime.Now,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p" + tvItemModelParent.TVItemID + "p" + contactModel.ContactTVItemID,
                    };

                    TVItemLinkModel tvItemLinkModel = _TVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(tvItemModelParent.TVItemID, contactModel.ContactTVItemID);
                    if (string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                        return ReturnContactError(string.Format(ServiceRes._AlreadyExists, tvItemModelContact.TVText));

                    tvItemLinkModel = _TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                        return ReturnContactError(tvItemLinkModel.Error);
                }
                else
                {
                    ContactModel contactModelToChange = GetContactModelWithContactTVItemIDDB(ContactTVItemID);
                    if (!string.IsNullOrWhiteSpace(contactModelToChange.Error))
                        return ReturnContactError(contactModelToChange.Error);

                    if (contactModelToChange.LoginEmail != LoginEmail)
                    {
                        contactModel = PostDeleteContactUnderParentTVItemIDDB(fc);
                        if (!string.IsNullOrWhiteSpace(contactModel.Error))
                            return ReturnContactError(contactModel.Error);

                        fc["ContactTVItemID"] = "0";

                        contactModel = PostAddOrModifyContactUnderParentTVItemIDDB(fc);
                        if (!string.IsNullOrWhiteSpace(contactModel.Error))
                            return ReturnContactError(contactModel.Error);
                    }
                    else
                    {
                        contactModelToChange.DBCommand = DBCommandEnum.Original;
                        contactModelToChange.FirstName = FirstName;
                        contactModelToChange.Initial = Initial;
                        contactModelToChange.LastName = LastName;
                        contactModelToChange.ContactTitle = ContactTitle;

                        contactModel = PostUpdateContactDB(contactModelToChange);
                        if (!string.IsNullOrWhiteSpace(contactModel.Error))
                            return ReturnContactError(contactModel.Error);

                        foreach (LanguageEnum Lang in LanguageListAllowable)
                        {
                            TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(contactModelToChange.ContactTVItemID, Lang);
                            if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                                return ReturnContactError(tvItemLanguageModel.Error);

                            tvItemLanguageModel.TVText = CreateTVText(contactModelToChange);

                            tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                            if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                                return ReturnContactError(tvItemLanguageModel.Error);
                        }
                    }
                }

                ts.Complete();
            }
            return contactModel;
        }
        public ContactModel PostAddContactDB(ContactModel contactModel)
        {
            string retStr = ContactModelOK(contactModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnContactError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(contactModel.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnContactError(tvItemModelExist.Error);

            Contact contactNew = new Contact();
            retStr = FillContact(contactNew, contactModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnContactError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.Contacts.Add(contactNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Contacts", contactNew.ContactID, LogCommandEnum.Add, contactNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
                tvTypeUserAuthorizationNew.ContactTVItemID = contactModel.ContactTVItemID;
                tvTypeUserAuthorizationNew.TVType = (int)TVTypeEnum.Root;
                tvTypeUserAuthorizationNew.TVAuth = (int)TVAuthEnum.NoAccess;
                tvTypeUserAuthorizationNew.LastUpdateDate_UTC = DateTime.UtcNow;
                tvTypeUserAuthorizationNew.LastUpdateContactTVItemID = contactNew.ContactID;

                retStr = AddTVTypeUserAuthorization(tvTypeUserAuthorizationNew);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                ts.Complete();
            }
            return GetContactModelWithContactIDDB(contactNew.ContactID);
        }
        public ContactModel PostAddFirstContactDB(ContactModel contactModel)
        {
            int Count = GetContactModelCountDB();

            if (Count > 0)
                return ReturnContactError(string.Format(ServiceRes.ToAddFirst_Requires_TableToBeEmpty, ServiceRes.Contacts));

            string retStr = ContactModelOK(contactModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnContactError(retStr);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(contactModel.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnContactError(tvItemModelExist.Error);

            Contact contactNew = new Contact();
            retStr = FillContact(contactNew, contactModel, null);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnContactError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.Contacts.Add(contactNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Contacts", contactNew.ContactID, LogCommandEnum.Add, contactNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
                tvTypeUserAuthorizationNew.ContactTVItemID = contactModel.ContactTVItemID;
                tvTypeUserAuthorizationNew.TVType = (int)TVTypeEnum.Root;
                tvTypeUserAuthorizationNew.TVAuth = (int)TVAuthEnum.Admin;
                tvTypeUserAuthorizationNew.LastUpdateDate_UTC = DateTime.UtcNow;
                tvTypeUserAuthorizationNew.LastUpdateContactTVItemID = contactNew.ContactID;

                db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorizationNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                logModel = _LogService.PostAddLogForObj("TVTypeUserAuthorizations", tvTypeUserAuthorizationNew.TVTypeUserAuthorizationID, LogCommandEnum.Add, tvTypeUserAuthorizationNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                ts.Complete();
            }
            return GetContactModelWithContactIDDB(contactNew.ContactID);
        }
        public ContactModel PostDeleteContactDB(int contactID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            Contact contactToDelete = GetContactWithContactIDDB(contactID);
            if (contactToDelete == null)
                return ReturnContactError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Contact));

            int ContactTVItemID = contactToDelete.ContactTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.Contacts.Remove(contactToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Contacts", contactToDelete.ContactID, LogCommandEnum.Delete, contactToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(ContactTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnContactError(tvItemModelRet.Error);

                ts.Complete();
            }
            return ReturnContactError("");
        }
        public ContactModel PostDeleteContactUnderParentTVItemIDDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            int ParentTVItemID = 0;
            int ContactTVItemID = 0;

            int.TryParse(fc["ParentTVItemID"], out ParentTVItemID);
            if (ParentTVItemID == 0)
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            if (ContactTVItemID == 0)
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            TVItemModel tvItemModelParent = _TVItemService.GetTVItemModelWithTVItemIDDB(ParentTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                return ReturnContactError(tvItemModelParent.Error);

            TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                return ReturnContactError(tvItemModelContact.Error);

            ContactModel contactModel = GetContactModelWithContactTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnContactError(contactModel.Error);


            List<TVItemLinkModel> tvItemLinkModelList = _TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(contactModel.ContactTVItemID);

            List<TVItemLinkModel> tvItemLinkModelToDelete = new List<TVItemLinkModel>();
            foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList)
            {
                tvItemLinkModelToDelete.Add(tvItemLinkModel);
            }

            using (TransactionScope ts = new TransactionScope())
            {
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelToDelete)
                {
                    if (contactModel.IsNew == true)
                    {

                        if (tvItemLinkModel.ToTVType == TVTypeEnum.Tel || tvItemLinkModel.ToTVType == TVTypeEnum.Email || tvItemLinkModel.ToTVType == TVTypeEnum.Address)
                        {
                            TVItemLinkModel tvItemLinkModelRet4 = new TVItemLinkModel();
                            if (contactModel.IsNew == true)
                            {
                                tvItemLinkModelRet4 = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDDB(contactModel.ContactTVItemID);
                                //if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                                //    return ReturnContactError(tvItemLinkModelRet.Error);
                            }
                        }
                    }
                }

                ts.Complete();
            }

            using (TransactionScope ts = new TransactionScope())
            {
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelToDelete)
                {
                    if (contactModel.IsNew == true)
                    {
                        if (tvItemLinkModel.ToTVType == TVTypeEnum.Tel)
                        {
                            TelModel telModel = _TelService.PostDeleteTelWithTelTVItemIDDB(tvItemLinkModel.ToTVItemID);
                            // Could be use by someone else
                            //if (!string.IsNullOrWhiteSpace(telModel.Error))
                            //    return ReturnContactError(telModel.Error);
                        }

                        if (tvItemLinkModel.ToTVType == TVTypeEnum.Email)
                        {
                            EmailModel EmailModel = _EmailService.PostDeleteEmailWithEmailTVItemIDDB(tvItemLinkModel.ToTVItemID);
                            // Could be use by someone else
                            //if (!string.IsNullOrWhiteSpace(telModel.Error))
                            //    return ReturnContactError(telModel.Error);
                        }

                        if (tvItemLinkModel.ToTVType == TVTypeEnum.Address)
                        {
                            AddressModel addressModel = _AddressService.PostDeleteAddressWithAddressTVItemIDDB(tvItemLinkModel.ToTVItemID);
                            // Could be use by someone else
                            //if (!string.IsNullOrWhiteSpace(telModel.Error))
                            //    return ReturnContactError(telModel.Error);
                        }
                    }
                }

                ts.Complete();
            }

            TVItemLinkModel tvItemLinkModelRet = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemModelParent.TVItemID, tvItemModelContact.TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
            {
                return ReturnContactError(tvItemLinkModelRet.Error);
            }

            if (contactModel.IsNew)
            {
                if (!ContactTVItemIDIsBeingUsed(ContactTVItemID))
                {
                    AspNetUserModel aspNetModelRet = _AspNetUserService.PostDeleteAspNetUserWithIdDB(contactModel.Id);
                    if (!string.IsNullOrWhiteSpace(aspNetModelRet.Error))
                        return ReturnContactError(aspNetModelRet.Error);

                    tvItemModelContact = _TVItemService.PostDeleteTVItemWithTVItemIDDB(ContactTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                        return ReturnContactError(tvItemModelContact.Error);

                    ContactModel contactModelRet = PostDeleteContactWithContactTVItemIDDB(ContactTVItemID);
                    //if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
                    //    return ReturnContactError(contactModelRet.Error);
                }
                else
                {
                    return ReturnContactError(string.Format(ServiceRes.Contact_IsBeingUsed, tvItemModelContact.TVText));
                }
            }

            return new ContactModel() { Error = "" }; // no error
        }
        public ContactModel PostDeleteContactWithContactTVItemIDDB(int ContactTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            Contact contactToDelete = GetContactWithContactTVItemIDDB(ContactTVItemID);
            if (contactToDelete == null)
                return ReturnContactError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Contact));

            using (TransactionScope ts = new TransactionScope())
            {
                ContactModel contactModel = PostDeleteContactDB(contactToDelete.ContactID);
                if (!string.IsNullOrWhiteSpace(contactModel.Error))
                    return ReturnContactError(contactModel.Error);

                ts.Complete();
            }
            return ReturnContactError("");
        }
        public ContactModel PostLinkParentTVItemIDAndContactTVItemIDDB(int ParentTVItemID, int ContactTVItemID)
        {
            if (ParentTVItemID == 0)
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.ParentTVItemID));

            if (ContactTVItemID == 0)
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            TVItemModel tvItemModelParent = _TVItemService.GetTVItemModelWithTVItemIDDB(ParentTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                return ReturnContactError(tvItemModelParent.Error);

            TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                return ReturnContactError(tvItemModelContact.Error);

            TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
            {
                DBCommand = DBCommandEnum.Original,
                FromTVItemID = ParentTVItemID,
                ToTVItemID = ContactTVItemID,
                FromTVType = tvItemModelParent.TVType,
                ToTVType = TVTypeEnum.Contact,
                Ordinal = 0,
                TVLevel = 0,
                TVPath = "p" + tvItemModelParent.TVItemID + "p" + ContactTVItemID,
            };

            TVItemLinkModel tvItemLinkModel = _TVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(ParentTVItemID, ContactTVItemID);
            if (string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                return ReturnContactError(string.Format(ServiceRes._AlreadyExists, tvItemModelContact.TVText));

            tvItemLinkModel = _TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
            if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                return ReturnContactError(tvItemLinkModel.Error);

            return ReturnContactError("");
        }
        public ContactModel PostLoggedInUserCreateNewUserDB(NewContactModel newContactModel)
        {
            string retStr = NewContactModelOK(newContactModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnContactError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                return ReturnContactError(tvItemModelRoot.Error);

            AspNetUserModel aspNetUserModelNew = new AspNetUserModel();
            aspNetUserModelNew.LoginEmail = newContactModel.LoginEmail;
            aspNetUserModelNew.Password = CreateUniquePassword();

            ContactModel contactModelRet = new ContactModel();

            using (TransactionScope ts = new TransactionScope())
            {
                AspNetUserModel aspNetUserModelRet = _AspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
                if (!string.IsNullOrWhiteSpace(aspNetUserModelRet.Error))
                    return ReturnContactError(aspNetUserModelRet.Error);

                ContactModel contactModelNew = new ContactModel();
                contactModelNew.DBCommand = DBCommandEnum.Original;
                contactModelNew.Id = aspNetUserModelRet.Id;
                contactModelNew.ContactTVItemID = 1; // will change
                contactModelNew.LoginEmail = newContactModel.LoginEmail;
                contactModelNew.FirstName = newContactModel.FirstName;
                contactModelNew.LastName = newContactModel.LastName;
                contactModelNew.Initial = newContactModel.Initial;
                if (newContactModel.ContactTitle == null)
                {
                    contactModelNew.ContactTitle = null;
                }
                else
                {
                    contactModelNew.ContactTitle = newContactModel.ContactTitle;
                }
                contactModelNew.WebName = CreateUniqueWebName(newContactModel.FirstName, newContactModel.LastName);
                contactModelNew.IsAdmin = false;
                contactModelNew.IsNew = true;
                contactModelNew.SamplingPlanner_ProvincesTVItemID = "";
                contactModelNew.EmailValidated = false;
                contactModelNew.Disabled = false;

                string TVText = CreateTVText(contactModelNew);
                if (string.IsNullOrWhiteSpace(TVText))
                    return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                TVItemModel tvItemModelContact = _TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                    return ReturnContactError(tvItemModelContact.Error);

                contactModelNew.ContactTVItemID = tvItemModelContact.TVItemID;
                contactModelRet = PostAddContactDB(contactModelNew);
                if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
                    return ReturnContactError(contactModelRet.Error);

                TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
                tvTypeUserAuthorizationNew.DBCommand = (int)tvItemModelContact.DBCommand;
                tvTypeUserAuthorizationNew.ContactTVItemID = tvItemModelContact.TVItemID;
                tvTypeUserAuthorizationNew.TVType = (int)TVTypeEnum.Root;
                tvTypeUserAuthorizationNew.TVAuth = (int)TVAuthEnum.NoAccess;
                tvTypeUserAuthorizationNew.LastUpdateDate_UTC = DateTime.UtcNow;
                tvTypeUserAuthorizationNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;

                db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorizationNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVTypeUserAuthorizations", tvTypeUserAuthorizationNew.TVTypeUserAuthorizationID, LogCommandEnum.Add, tvTypeUserAuthorizationNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                ts.Complete();
            }
            return contactModelRet;
        }
        public ContactModel PostRegisterNewContactDB(RegisterModel registerModel)
        {
            string retStr = RegisterModelOK(registerModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnContactError(retStr);

            Contact contactNew = new Contact();
            using (TransactionScope ts = new TransactionScope())
            {
                AspNetUserModel aspNetUserModel = new AspNetUserModel()
                {
                    LoginEmail = registerModel.LoginEmail,
                    Password = registerModel.Password
                };

                AspNetUserModel aspNetUserModelRet = _AspNetUserService.PostAddAspNetUserDB(aspNetUserModel, false);
                if (!string.IsNullOrWhiteSpace(aspNetUserModelRet.Error))
                    return ReturnContactError(aspNetUserModelRet.Error);

                TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
                if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                    return ReturnContactError(tvItemModelRoot.Error);

                ContactModel contactModel = new ContactModel()
                {
                    DBCommand = DBCommandEnum.Original,
                    LoginEmail = registerModel.LoginEmail,
                    FirstName = registerModel.FirstName,
                    Initial = registerModel.Initial,
                    LastName = registerModel.LastName,
                    EmailValidated = true, // temporary will be changed to false after TVItem is added
                    IsAdmin = registerModel.IsAdmin,
                    Disabled = registerModel.Disabled,
                    WebName = registerModel.WebName,
                    Id = aspNetUserModelRet.Id,
                    IsNew = false,
                    SamplingPlanner_ProvincesTVItemID = "",

                };

                string TVText = CreateTVText(contactModel);
                if (string.IsNullOrWhiteSpace(TVText))
                    return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                retStr = FillContact(contactNew, contactModel, null);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                TVItemModel tvItemModelContact = _TVItemService.PostAddChildContactTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Contact);
                if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                    return ReturnContactError(tvItemModelContact.Error);

                contactNew.ContactTVItemID = tvItemModelContact.TVItemID;

                db.Contacts.Add(contactNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Contacts", contactNew.ContactID, LogCommandEnum.Add, contactNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                base.User = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);

                Init(LanguageRequest, base.User);

                ContactModel contactModelRet = GetContactModelWithContactIDDB(contactNew.ContactID);
                if (contactModelRet == null)
                    return ReturnContactError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Contact));

                contactNew.ContactTVItemID = tvItemModelContact.TVItemID;
                contactNew.EmailValidated = false;

                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                logModel = _LogService.PostAddLogForObj("Contacts", contactNew.ContactID, LogCommandEnum.Change, contactNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                TVTypeUserAuthorization tvTypeUserAuthorizationNew = new TVTypeUserAuthorization();
                tvTypeUserAuthorizationNew.DBCommand = (int)DBCommandEnum.Original;
                tvTypeUserAuthorizationNew.ContactTVItemID = contactModelRet.ContactTVItemID;
                tvTypeUserAuthorizationNew.TVType = (int)TVTypeEnum.Root;
                tvTypeUserAuthorizationNew.TVAuth = (int)TVAuthEnum.NoAccess;
                tvTypeUserAuthorizationNew.LastUpdateDate_UTC = DateTime.UtcNow;
                tvTypeUserAuthorizationNew.LastUpdateContactTVItemID = contactNew.ContactID;

                db.TVTypeUserAuthorizations.Add(tvTypeUserAuthorizationNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                logModel = _LogService.PostAddLogForObj("TVTypeUserAuthorizations", tvTypeUserAuthorizationNew.TVTypeUserAuthorizationID, LogCommandEnum.Add, tvTypeUserAuthorizationNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                ts.Complete();
            }
            return GetContactModelWithContactIDDB(contactNew.ContactID);
        }
        public ContactModel PostRemoveUserDB(string LoginEmail)
        {
            // To remove a user you need to have admin at this time
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            if (!IsAdministratorDB(User.Identity.Name))
                return ReturnContactError(ServiceRes.OnlyAdministratorsCanManageUsers);

            ContactModel contactModelLoggedIn = GetContactLoggedInDB();
            if (!string.IsNullOrWhiteSpace(contactModelLoggedIn.Error))
                return ReturnContactError(contactModelLoggedIn.Error);

            if (LoginEmail.ToLower() == contactModelLoggedIn.LoginEmail.ToLower())
                return ReturnContactError(ServiceRes.CantDeleteOneSelf);

            ContactModel contactModelToDelete = GetContactModelWithLoginEmailDB(LoginEmail);
            if (!string.IsNullOrWhiteSpace(contactModelToDelete.Error))
                return ReturnContactError(contactModelToDelete.Error);

            string Id = contactModelToDelete.Id;

            AspNetUserModel aspNetUserModelRet = _AspNetUserService.GetAspNetUserModelWithEmailDB(LoginEmail);
            if (!string.IsNullOrWhiteSpace(aspNetUserModelRet.Error))
                return ReturnContactError(aspNetUserModelRet.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                foreach (LanguageEnum lang in LanguageListAllowable)
                {
                    TVItemLanguageModel tvItemLanguageModelToChange = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(contactModelToDelete.ContactTVItemID, lang);
                    if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToChange.Error))
                        return ReturnContactError(tvItemLanguageModelToChange.Error);

                    tvItemLanguageModelToChange.TVText += " " + ServiceRes.RemovedWithParenthesis;

                    TVItemLanguageModel tvItemLanguageModelRet = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToChange);
                    if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                        return ReturnContactError(tvItemLanguageModelRet.Error);
                }

                AspNetUserModel aspNetUserModel = _AspNetUserService.PostDeleteAspNetUserWithIdDB(Id);
                if (!string.IsNullOrWhiteSpace(aspNetUserModel.Error))
                    return ReturnContactError(aspNetUserModel.Error);

                ts.Complete();
            }
            return new ContactModel() { LoginEmail = LoginEmail, Error = "" };
        }
        public ContactModel PostResetPasswordDB(ResetPasswordModel resetPasswordModel)
        {
            AspNetUserModel aspNetUserModelRet = new AspNetUserModel();
            using (TransactionScope ts = new TransactionScope())
            {
                string retStr = _ResetPasswordService.ResetPasswordModelOK(resetPasswordModel);
                if (!string.IsNullOrEmpty(retStr))
                    return ReturnContactError(retStr);

                ResetPasswordModel resetPasswordModelRet = _ResetPasswordService.GetResetPasswordModelWithCodeAndEmailDB(resetPasswordModel.Code, resetPasswordModel.Email);
                if (!string.IsNullOrWhiteSpace(resetPasswordModelRet.Error))
                    return ReturnContactError(resetPasswordModelRet.Error);

                AspNetUserModel aspNetUserModel = new AspNetUserModel()
                {
                    LoginEmail = "unique" + resetPasswordModel.Email,
                    Password = resetPasswordModel.Password
                };

                aspNetUserModelRet = _AspNetUserService.PostAddAspNetUserDB(aspNetUserModel, false);
                if (!string.IsNullOrWhiteSpace(aspNetUserModelRet.Error))
                    return ReturnContactError(aspNetUserModelRet.Error);

                AspNetUserModel aspNetUserModelRet4 = _AspNetUserService.PostDeleteAspNetUserWithIdDB(aspNetUserModelRet.Id);
                if (!string.IsNullOrWhiteSpace(aspNetUserModelRet4.Error))
                    return ReturnContactError(aspNetUserModelRet4.Error);

                AspNetUserModel aspNetUserModelRet2 = _AspNetUserService.GetAspNetUserModelWithEmailDB(resetPasswordModel.Email);
                if (!string.IsNullOrWhiteSpace(aspNetUserModelRet2.Error))
                    return ReturnContactError(aspNetUserModelRet2.Error);

                aspNetUserModelRet2.Password = resetPasswordModel.Password;
                aspNetUserModelRet2.PasswordHash = aspNetUserModelRet.PasswordHash;
                aspNetUserModelRet2.SecurityStamp = aspNetUserModelRet.SecurityStamp;

                AspNetUserModel aspNetUserModelRet3 = _AspNetUserService.PostUpdateAspNetUserDB(aspNetUserModelRet2);
                if (!string.IsNullOrWhiteSpace(aspNetUserModelRet3.Error))
                    return ReturnContactError(aspNetUserModelRet3.Error);

                ResetPasswordModel resetPasswordModelRet2 = _ResetPasswordService.PostDeleteResetPasswordDB(resetPasswordModelRet.ResetPasswordID);
                if (!string.IsNullOrWhiteSpace(resetPasswordModelRet2.Error))
                    return ReturnContactError(resetPasswordModelRet2.Error);

                ts.Complete();
            }
            return GetContactModelWithLoginEmailDB(resetPasswordModel.Email);
        }
        public ContactModel PostSetContactDisabledOrEnableForContactTVItemIDDB(int ContactTVItemID)
        {
            ContactModel contactModel = new ContactModel();
            if (ContactTVItemID == 0)
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            bool IsAdmin = IsAdministratorDB(User.Identity.Name);
            if (!IsAdmin)
                return ReturnContactError(ServiceRes.OnlyAdministratorsCanManageUsers);

            ContactModel contactModelLoggedIn = GetContactModelWithLoginEmailDB(User.Identity.Name);
            if (!string.IsNullOrWhiteSpace(contactModelLoggedIn.Error))
                return ReturnContactError(contactModelLoggedIn.Error);

            Contact contact = GetContactWithContactTVItemIDDB(ContactTVItemID);
            if (contact == null)
                return ReturnContactError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.UserAccountIN, ServiceRes.UserInfoID, ContactTVItemID));

            if (contact.ContactID == contactModelLoggedIn.ContactID)
                return ReturnContactError(ServiceRes.CantDisableOrEnableOneSelf);

            contact.Disabled = !(contact.Disabled);
            contact.LastUpdateDate_UTC = DateTime.UtcNow;
            contact.LastUpdateContactTVItemID = contactOK.ContactTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                string retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Contacts", contact.ContactID, LogCommandEnum.Change, contact);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                ts.Complete();
            }
            contactModel = GetContactModelWithContactTVItemIDDB(ContactTVItemID);

            return contactModel;
        }
        public ContactModel PostSetRemoveProvinceDB(int ContactTVItemID, int ProvinceTVItemID)
        {
            ContactModel contactModel = GetContactModelWithContactTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnContactError(contactModel.Error);

            contactModel.SamplingPlanner_ProvincesTVItemID = contactModel.SamplingPlanner_ProvincesTVItemID.Replace(ProvinceTVItemID.ToString() + ",", "");
            ContactModel contactModelRet = PostUpdateContactDB(contactModel);
            if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
                return ReturnContactError(contactModelRet.Error);

            return contactModelRet;
        }
        public ContactModel PostSetAddProvinceDB(int ContactTVItemID, int ProvinceTVItemID)
        {
            ContactModel contactModel = GetContactModelWithContactTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnContactError(contactModel.Error);

            contactModel.SamplingPlanner_ProvincesTVItemID = contactModel.SamplingPlanner_ProvincesTVItemID + ProvinceTVItemID.ToString() + ",";
            ContactModel contactModelRet = PostUpdateContactDB(contactModel);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
                return ReturnContactError(contactModel.Error);

            return contactModelRet;
        }
        public ResetPasswordModel PostTryToSendEmailDB(string LoginEmail)
        {
            ResetPasswordModel resetPasswordModelRet = new ResetPasswordModel();
            using (TransactionScope ts = new TransactionScope())
            {
                string retStr = EmailOK(LoginEmail);
                if (!string.IsNullOrEmpty(retStr))
                    return ReturnResetPasswordError(retStr);

                Contact contact = GetContactWithEmailDB(LoginEmail);
                if (contact == null)
                    return ReturnResetPasswordError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.Email, LoginEmail));

                // remove all old ResetPassword in the DB
                List<ResetPassword> ResetPasswordList = GetResetPasswordWithExpireDate_LocalSmallerThanToday();
                foreach (ResetPassword rpToDelete in ResetPasswordList)
                {
                    ResetPasswordModel resetPasswordModelRet2 = _ResetPasswordService.PostDeleteResetPasswordDB(rpToDelete.ResetPasswordID);
                    if (!string.IsNullOrWhiteSpace(resetPasswordModelRet2.Error))
                        return ReturnResetPasswordError(resetPasswordModelRet2.Error);
                }

                // remove all ResetPassword with LoginEmail
                ResetPasswordList = GetResetPasswordWithEmail(LoginEmail);
                foreach (ResetPassword rpToDelete in ResetPasswordList)
                {
                    ResetPasswordModel resetPasswordModelRet2 = _ResetPasswordService.PostDeleteResetPasswordDB(rpToDelete.ResetPasswordID);
                    if (!string.IsNullOrWhiteSpace(resetPasswordModelRet2.Error))
                        return ReturnResetPasswordError(resetPasswordModelRet2.Error);
                }

                ResetPasswordModel resetPasswordModel = new ResetPasswordModel()
                {
                    DBCommand = DBCommandEnum.Original,
                    Code = GenerateUniqueCodeForResetPasswordDB(),
                    Password = "sleifjlisjf@24@",
                    ConfirmPassword = "sleifjlisjf@24@",
                    ExpireDate_Local = DateTime.Today.AddDays(1),
                    Email = LoginEmail,
                };

                resetPasswordModelRet = _ResetPasswordService.PostAddResetPasswordDB(resetPasswordModel);
                if (!string.IsNullOrWhiteSpace(resetPasswordModelRet.Error))
                    return ReturnResetPasswordError(resetPasswordModelRet.Error);

                ts.Complete();
            }

            MailMessage mail = new MailMessage();
            mail.To.Clear();
            mail.To.Add(resetPasswordModelRet.Email);
            mail.From = new MailAddress(FromEmail);
            mail.Subject = ServiceRes.CSSPWebToolRequiredInformationToChangeYourPassword;
            mail.Body = ServiceRes.PlsUseFollowingUniqueCodeEtc
                + @"<br />"
                + @"<br />"
                + ServiceRes.YourEmailIs + " " + resetPasswordModelRet.Email + @"<br />"
                + @"<br />"
                + ServiceRes.CodeIs + " " + resetPasswordModelRet.Code + @"<br />"
                + @"<br />"
                + ServiceRes.AutoEmailFromServer + @"<br />";
            mail.IsBodyHtml = true;

            string retStr2 = SendEmail(mail);
            if (!string.IsNullOrWhiteSpace(resetPasswordModelRet.Error))
                return ReturnResetPasswordError(retStr2);

            return resetPasswordModelRet;
        }
        public ContactModel PostUpdateContactDB(ContactModel contactModel)
        {
            string retStr = ContactModelOK(contactModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnContactError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            Contact contactToUpdate = GetContactWithContactIDDB(contactModel.ContactID);
            if (contactToUpdate == null)
                return ReturnContactError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Contact));

            retStr = FillContact(contactToUpdate, contactModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnContactError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnContactError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Contacts", contactToUpdate.ContactID, LogCommandEnum.Change, contactToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnContactError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(contactToUpdate.ContactTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnContactError(tvItemLanguageModelToUpdate.Error);

                        tvItemLanguageModelToUpdate.TVText = CreateTVText(contactModel);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.TVText))
                            return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnContactError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }
            return GetContactModelWithContactIDDB(contactToUpdate.ContactID);
        }
        public ContactModel ProfileSaveDB(FormCollection fc)
        {
            int ContactTVItemID = 0;
            string FirstName = "";
            string Initial = "";
            string LastName = "";
            //string LoginEmail = "";

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnContactError(contactOK.Error);

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            if (ContactTVItemID == 0)
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            ContactModel contactModelToChange = GetContactModelWithContactTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModelToChange.Error))
                return ReturnContactError(contactModelToChange.Error);

            FirstName = fc["FirstName"];
            if (string.IsNullOrWhiteSpace(FirstName))
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.FirstName));

            contactModelToChange.FirstName = FirstName;

            Initial = fc["Initial"];
            contactModelToChange.Initial = Initial;

            LastName = fc["LastName"];
            if (string.IsNullOrWhiteSpace(LastName))
                return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.LastName));

            contactModelToChange.LastName = LastName;

            //LoginEmail = fc["LoginEmail"];
            //if (string.IsNullOrWhiteSpace(LoginEmail))
            //    return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.LoginEmail));

            //contactModelToChange.LoginEmail = LoginEmail;

            using (TransactionScope ts = new TransactionScope())
            {
                ContactModel contactModelRet = PostUpdateContactDB(contactModelToChange);
                if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
                    return ReturnContactError(contactModelRet.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(contactModelRet.ContactTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnContactError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLanguage, ServiceRes.TVItemID + "," + ServiceRes.Language, contactModelRet.ContactTVItemID.ToString() + "," + Lang));

                        tvItemLanguageModelToUpdate.TVText = CreateTVText(contactModelRet);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.TVText))
                            return ReturnContactError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnContactError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }
            return GetContactModelWithContactTVItemIDDB(ContactTVItemID);
        }

        // Search
        public List<ContactSearchModel> ContactSearchDB(string SearchTerm = "")
        {
            IEnumerable<ContactSearchModel> tvItemEnum = null;

            SearchTerm = SearchTerm.Trim();
            if (SearchTerm == "")
            {
                return new List<ContactSearchModel>();
            }

            List<string> termList = SearchTerm.Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList().Select(c => c.Trim()).ToList();

            if (termList.Count == 0)
            {
                return new List<ContactSearchModel>();
            }
            else
            {
                tvItemEnum = (from c in db.TVItems
                              from cl in db.TVItemLanguages
                              from st in termList
                              from ct in db.Contacts
                              let fullName = ct.LastName + ", " + ct.FirstName + (ct.Initial == null ? "" : " " + ct.Initial)
                              where c.TVItemID == cl.TVItemID
                              && c.TVItemID == ct.ContactTVItemID
                              && cl.TVText.Contains(st)
                              && cl.Language == (int)LanguageRequest
                              orderby fullName
                              select new ContactSearchModel
                              {
                                  ContactID = ct.ContactID,
                                  ContactTVItemID = ct.ContactTVItemID,
                                  FullName = fullName,
                              }).Take(SearchMaxReturn).ToList<ContactSearchModel>();
            }

            return tvItemEnum.ToList();
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
