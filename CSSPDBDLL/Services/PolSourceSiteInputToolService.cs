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
using System.IO;

namespace CSSPDBDLL.Services
{
    public class PolSourceSiteInputToolService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteInputToolService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Helper
        public TVItemModel ReturnError(string Error)
        {
            return new TVItemModel() { Error = Error };
        }
        #endregion Helper

        #region Functions public
        public TVItemModel SaveAddressContactDB(int ContactTVItemID, int ProvinceTVItemID, int TVItemID, string StreetNumber,
            string StreetName, int StreetType, string Municipality, string PostalCode, bool CreateMunicipality, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            AddressService addressService = new AddressService(LanguageRequest, user);
            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, user);

            if (ContactTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.ContactTVItemID)}");
            }

            TVItemModel tvItemModelContact = tvItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
            {
                return ReturnError($"ERROR: {tvItemModelContact.Error}");
            }

            if (tvItemModelContact.TVType != TVTypeEnum.Contact)
            {
                return ReturnError($"ERROR: ContactTVItemID [{ContactTVItemID}] is not of type Contact");
            }

            // doing Province
            if (ProvinceTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.ProvinceTVItemID)}");
            }

            TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProvince.Error))
            {
                return ReturnError($"ERROR: {tvItemModelProvince.Error}");
            }

            if (tvItemModelProvince.TVType != TVTypeEnum.Province)
            {
                return ReturnError($"ERROR: ProvinceTVItemID [{ProvinceTVItemID}] is not of type Province");
            }

            if (TVItemID == 0)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID));
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000"));
            }

            if (string.IsNullOrWhiteSpace(Municipality))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Municipality));
            }

            TVItemModel tvItemModelMunicipality = new TVItemModel();
            if (CreateMunicipality)
            {
                tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                {
                    tvItemModelMunicipality = tvItemService.PostAddChildTVItemDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                    if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                    {
                        return ReturnError($"ERROR: {string.Format(ServiceRes.CouldNotCreateMunicipality_, Municipality)}");
                    }
                }
            }
            else
            {
                tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                {
                    return ReturnError($"ERROR: {string.Format(ServiceRes.CouldNotFindMunicipality_, Municipality)}");
                }
            }

            List<TVItemModel> tvItemModelParents = tvItemService.GetParentsTVItemModelList(tvItemModelMunicipality.TVPath);

            AddressModel addressModelNew = new AddressModel();
            addressModelNew.AddressType = AddressTypeEnum.Civic;
            addressModelNew.StreetNumber = StreetNumber;
            addressModelNew.StreetName = StreetName;
            addressModelNew.StreetType = (StreetTypeEnum)StreetType;
            addressModelNew.MunicipalityTVItemID = tvItemModelMunicipality.TVItemID;
            addressModelNew.ProvinceTVItemID = tvItemModelProvince.TVItemID;
            addressModelNew.CountryTVItemID = tvItemModelProvince.ParentID;
            addressModelNew.PostalCode = PostalCode;

            string TVTextAddress = addressService.CreateTVText(addressModelNew);

            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
            {
                return ReturnError($"ERROR: {tvItemModelRoot.Error}");
            }

            AddressModel addressModelRet = addressService.GetAddressModelExistDB(addressModelNew);
            if (!string.IsNullOrWhiteSpace(addressModelRet.Error))
            {
                TVItemModel tvItemModelAddress = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVTextAddress, TVTypeEnum.Address);
                if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelAddress.Error}");
                }

                addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

                addressModelRet = addressService.PostAddAddressDB(addressModelNew);
                if (!string.IsNullOrWhiteSpace(addressModelRet.Error))
                {
                    return ReturnError($"ERROR: {addressModelRet.Error}");
                }
            }

            List<TVItemLinkModel> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(ContactTVItemID);
            bool TVItemLinkModelExist = false;
            foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList)
            {
                if (tvItemLinkModel.ToTVItemID == addressModelRet.AddressTVItemID)
                {
                    if (tvItemLinkModel.FromTVType == TVTypeEnum.Contact && tvItemLinkModel.ToTVType == TVTypeEnum.Address)
                    {
                        TVItemLinkModelExist = true;
                    }
                }
            }

            if (!TVItemLinkModelExist)
            {
                TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                {
                    FromTVItemID = tvItemModelContact.TVItemID,
                    ToTVItemID = addressModelRet.AddressTVItemID,
                    FromTVType = TVTypeEnum.Contact,
                    ToTVType = TVTypeEnum.Address,
                    StartDateTime_Local = DateTime.Now,
                    EndDateTime_Local = null,
                    Ordinal = 0,
                    TVLevel = 0,
                    TVPath = "p" + tvItemModelContact + "p" + addressModelRet.AddressTVItemID,
                    ParentTVItemLinkID = null,
                };

                TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                {
                    return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                }
            }

            return ReturnError($"{addressModelRet.AddressTVItemID}");
        }
        public TVItemModel CreateOrModifyEmailDB(int ContactTVItemID, int EmailTVItemID, int? EmailType, string EmailAddress, bool ShouldDelete, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModelAdmin = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModelAdmin.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, user);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, user);
            EmailService emailService = new EmailService(LanguageRequest, user);

            if (ContactTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            ContactModel contactModel = contactService.GetContactModelWithContactTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {contactModel.Error}");
            }

            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.EmailAddress)}");
            }

            if (EmailType == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.EmailType)}");
            }

            if (ShouldDelete)
            {
                EmailModel emailModelRet = emailService.GetEmailModelWithEmailTVItemIDDB(EmailTVItemID);
                if (!string.IsNullOrWhiteSpace(emailModelRet.Error))
                {
                    return ReturnError($"ERROR: {emailModelRet.Error}");
                }

                List<TVItemLinkModel> tvItemLinkModelList2 = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(ContactTVItemID);
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList2)
                {
                    if (tvItemLinkModel.ToTVItemID == EmailTVItemID)
                    {
                        if (tvItemLinkModel.FromTVType == TVTypeEnum.Contact && tvItemLinkModel.ToTVType == TVTypeEnum.Email)
                        {
                            TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkModel.TVItemLinkID);
                            if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                            {
                                return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                            }
                        }
                    }
                }

                return ReturnError($"{EmailTVItemID}");
            }

            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
            {
                return ReturnError($"ERROR: {tvItemModelRoot.Error}");
            }

            string TVText = EmailAddress;

            TVItemModel tvItemModel = tvItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Email);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                // does not exist so create
                tvItemModel = tvItemService.PostCreateTVItem(tvItemModelRoot.TVItemID, TVText, TVText, TVTypeEnum.Email);
                if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                {
                    return ReturnError($"ERROR: {tvItemModel.Error}");
                }
            }

            EmailModel emailModelNew = new EmailModel()
            {
                EmailType = (EmailTypeEnum)EmailType,
                EmailAddress = EmailAddress,
                EmailTVItemID = tvItemModel.TVItemID,
            };

            EmailModel emailModel = emailService.GetEmailModelExistDB(emailModelNew);
            if (!string.IsNullOrWhiteSpace(emailModel.Error))
            {
                emailModel = emailService.PostAddEmailDB(emailModelNew);
                if (!string.IsNullOrWhiteSpace(emailModel.Error))
                {
                    return ReturnError($"ERROR: {emailModel.Error}");
                }
            }

            TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
            {
                FromTVItemID = contactModel.ContactTVItemID,
                ToTVItemID = emailModel.EmailTVItemID,
                FromTVType = TVTypeEnum.Contact,
                ToTVType = TVTypeEnum.Email,
                StartDateTime_Local = DateTime.Now,
                EndDateTime_Local = null,
                Ordinal = 0,
                TVLevel = 0,
                TVPath = "p" + contactModel.ContactTVItemID + "p" + emailModel.EmailTVItemID,
                ParentTVItemLinkID = null,
            };


            bool TVItemLinkExist = false;
            List<TVItemLinkModel> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(contactModel.ContactTVItemID);
            if (tvItemLinkModelList.Count > 0)
            {
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList)
                {
                    if (tvItemLinkModel.ToTVItemID == emailModel.EmailTVItemID)
                    {
                        TVItemLinkExist = true;
                        break;
                    }
                }
            }

            if (!TVItemLinkExist)
            {
                TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                {
                    return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                }
            }

            return ReturnError($"{emailModel.EmailTVItemID}");
        }
        public TVItemModel CreateOrModifyTelephoneDB(int ContactTVItemID, int TelTVItemID, int? TelType, string TelNumber, bool ShouldDelete, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModelAdmin = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModelAdmin.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, user);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, user);
            TelService telService = new TelService(LanguageRequest, user);

            if (ContactTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            ContactModel contactModel = contactService.GetContactModelWithContactTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {contactModel.Error}");
            }

            if (string.IsNullOrWhiteSpace(TelNumber))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.TelNumber)}");
            }

            if (TelType == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.TelType)}");
            }

            if (ShouldDelete)
            {
                TelModel telModelRet = telService.GetTelModelWithTelTVItemIDDB(TelTVItemID);
                if (!string.IsNullOrWhiteSpace(telModelRet.Error))
                {
                    return ReturnError($"ERROR: {telModelRet.Error}");
                }

                List<TVItemLinkModel> tvItemLinkModelList2 = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(ContactTVItemID);
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList2)
                {
                    if (tvItemLinkModel.ToTVItemID == TelTVItemID)
                    {
                        if (tvItemLinkModel.FromTVType == TVTypeEnum.Contact && tvItemLinkModel.ToTVType == TVTypeEnum.Tel)
                        {
                            TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkModel.TVItemLinkID);
                            if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                            {
                                return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                            }
                        }
                    }
                }

                return ReturnError($"{TelTVItemID}");
            }

            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
            {
                return ReturnError($"ERROR: {tvItemModelRoot.Error}");
            }

            string TVText = TelNumber;

            TVItemModel tvItemModel = tvItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Tel);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                // does not exist so create
                tvItemModel = tvItemService.PostCreateTVItem(tvItemModelRoot.TVItemID, TVText, TVText, TVTypeEnum.Tel);
                if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                {
                    return ReturnError($"ERROR: {tvItemModel.Error}");
                }
            }

            TelModel telModelNew = new TelModel()
            {
                TelType = (TelTypeEnum)TelType,
                TelNumber = TelNumber,
                TelTVItemID = tvItemModel.TVItemID,
            };

            TelModel telModel = telService.GetTelModelExistDB(telModelNew);
            if (!string.IsNullOrWhiteSpace(telModel.Error))
            {
                telModel = telService.PostAddTelDB(telModelNew);
                if (!string.IsNullOrWhiteSpace(telModel.Error))
                {
                    return ReturnError($"ERROR: {telModel.Error}");
                }
            }

            TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
            {
                FromTVItemID = contactModel.ContactTVItemID,
                ToTVItemID = telModel.TelTVItemID,
                FromTVType = TVTypeEnum.Contact,
                ToTVType = TVTypeEnum.Tel,
                StartDateTime_Local = DateTime.Now,
                EndDateTime_Local = null,
                Ordinal = 0,
                TVLevel = 0,
                TVPath = "p" + contactModel.ContactTVItemID + "p" + telModel.TelTVItemID,
                ParentTVItemLinkID = null,
            };

            bool TVItemLinkExist = false;
            List<TVItemLinkModel> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(contactModel.ContactTVItemID);
            if (tvItemLinkModelList.Count > 0)
            {
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList)
                {
                    if (tvItemLinkModel.ToTVItemID == telModel.TelTVItemID)
                    {
                        TVItemLinkExist = true;
                        break;
                    }
                }
            }

            if (!TVItemLinkExist)
            {
                TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                {
                    return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                }
            }

            return ReturnError($"{telModel.TelTVItemID}");
        }
        public TVItemModel CreateOrModifyContactDB(int MunicipalityTVItemID, int ContactTVItemID, string FirstName,
            string Initial, string LastName, string Email, int? Title, bool IsActive, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, user);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, user);
            AspNetUserService aspNetUserService = new AspNetUserService(LanguageRequest, user);

            if (MunicipalityTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.MunicipalityTVItemID)}");
            }

            TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
            {
                return ReturnError($"ERROR: {tvItemModelMunicipality.Error}");
            }

            if (ContactTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            if (string.IsNullOrWhiteSpace(FirstName))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.FirstName)}");
            }

            if (string.IsNullOrWhiteSpace(LastName))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.LastName)}");
            }

            if (string.IsNullOrWhiteSpace(Email))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.LoginEmail)}");
            }

            if (!IsActive)
            {
                List<TVItemLinkModel> tvItemLinkModelListToRemove = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(MunicipalityTVItemID);
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelListToRemove)
                {
                    if (tvItemLinkModel.ToTVItemID == ContactTVItemID)
                    {
                        if (tvItemLinkModel.FromTVType == TVTypeEnum.Municipality && tvItemLinkModel.ToTVType == TVTypeEnum.Contact)
                        {
                            TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkModel.TVItemLinkID);
                            if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                            {
                                return ReturnError($"ERROR: Could not remove the contact { FirstName } {LastName} from the municipality contact");
                            }
                        }
                    }
                }
                return ReturnError($"{ContactTVItemID}");
            }

            ContactModel contactModelRet = contactService.GetContactModelWithContactTVItemIDDB(ContactTVItemID);
            if (ContactTVItemID >= 20000000 || !string.IsNullOrWhiteSpace(contactModelRet.Error))
            {
                NewContactModel newContactModelNew = new NewContactModel()
                {
                    FirstName = FirstName,
                    Initial = Initial,
                    LastName = LastName,
                    LoginEmail = Email,
                    ContactTitle = (ContactTitleEnum)Title,
                };

                AspNetUserModel aspNetUserModel2 = aspNetUserService.GetAspNetUserModelWithEmailDB(Email);
                if (string.IsNullOrWhiteSpace(aspNetUserModel2.Error)) // already exist
                {
                    contactModelRet = contactService.GetContactModelWithLoginEmailDB(Email);
                    if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
                    {
                        return ReturnError($"ERROR: could not find Contact with Login Email { Email }");
                    }
                }
                else
                {
                    // create Contact, TVItem and TVLanguage items
                    contactModelRet = contactService.PostLoggedInUserCreateNewUserDB(newContactModelNew);
                    if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
                    {
                        // this is not really an error, we just try to create a new contact 
                        // but one already exist so it just return it with an error attached to it
                        contactModelRet = contactService.GetContactModelWithFirstNameInitialAndLastNameDB(FirstName, Initial, LastName);
                        if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
                        {
                            return ReturnError($"ERROR: {FirstName} {Initial}, {LastName} exist but could not find it");
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
            {
                return ReturnError($"ERROR: {contactModelRet.Error}");
            }

            if (!contactModelRet.IsNew)
            {
                return ReturnError($"ERROR: Not allowed to change the Name or Email of an individual that is already using the account");
            }

            if (FirstName != contactModelRet.FirstName)
            {
                contactModelRet.FirstName = FirstName;
            }

            if (Initial != contactModelRet.Initial)
            {
                contactModelRet.Initial = Initial;
            }

            if (LastName != contactModelRet.LastName)
            {
                contactModelRet.LastName = LastName;
            }

            if (Email != contactModelRet.LoginEmail)
            {
                contactModelRet.LoginEmail = Email;
            }

            if (Title == null)
            {
                contactModelRet.ContactTitle = ContactTitleEnum.Error;
            }
            else
            {
                contactModelRet.ContactTitle = (ContactTitleEnum)Title;
            }

            contactModelRet = contactService.PostUpdateContactDB(contactModelRet);
            if (!string.IsNullOrWhiteSpace(contactModelRet.Error))
            {
                return ReturnError($"ERROR: {contactModelRet.Error}");
            }

            AspNetUserModel aspNetUserModel = aspNetUserService.GetAspNetUserModelWithIdDB(contactModelRet.Id);
            if (!string.IsNullOrWhiteSpace(aspNetUserModel.Error))
            {
                return ReturnError($"ERROR: {aspNetUserModel.Error}");
            }

            using (CSSPDBEntities db2 = new CSSPDBEntities())
            {
                AspNetUser aspNetUser = (from c in db2.AspNetUsers
                                         where c.Id == contactModelRet.Id
                                         select c).FirstOrDefault();

                if (aspNetUser != null)
                {
                    aspNetUser.Email = Email;
                    aspNetUser.UserName = Email;
                }

                try
                {
                    db2.SaveChanges();
                }
                catch (Exception ex)
                {
                    return ReturnError($"ERROR: {ex.Message}");
                }
            }

            List<TVItemLinkModel> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(MunicipalityTVItemID);
            bool TVItemLinkModelExist = false;
            foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList)
            {
                if (tvItemLinkModel.ToTVItemID == contactModelRet.ContactTVItemID)
                {
                    if (tvItemLinkModel.FromTVType == TVTypeEnum.Municipality && tvItemLinkModel.ToTVType == TVTypeEnum.Contact)
                    {
                        TVItemLinkModelExist = true;
                        break;
                    }
                }
            }

            if (!TVItemLinkModelExist)
            {
                TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                {
                    FromTVItemID = tvItemModelMunicipality.TVItemID,
                    ToTVItemID = contactModelRet.ContactTVItemID,
                    FromTVType = TVTypeEnum.Municipality,
                    ToTVType = TVTypeEnum.Contact,
                    StartDateTime_Local = DateTime.Now,
                    EndDateTime_Local = null,
                    Ordinal = 0,
                    TVLevel = 0,
                    TVPath = "p" + tvItemModelMunicipality.TVItemID + "p" + contactModelRet.ContactTVItemID,
                    ParentTVItemLinkID = null,
                };

                TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                {
                    return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                }
            }

            return ReturnError($"{contactModelRet.ContactTVItemID}");
        }
        public TVItemModel CreateOrModifyInfrastructureDB(int MunicipalityTVItemID, int TVItemID, string TVText, bool IsActive,
            float? Lat, float? Lng, float? LatOutfall, float? LngOutfall, string CommentEN, string CommentFR, InfrastructureTypeEnum? InfrastructureType,
            FacilityTypeEnum? FacilityType, bool? IsMechanicallyAerated, int? NumberOfCells, int? NumberOfAeratedCells, AerationTypeEnum? AerationType,
            PreliminaryTreatmentTypeEnum? PreliminaryTreatmentType, PrimaryTreatmentTypeEnum? PrimaryTreatmentType,
            SecondaryTreatmentTypeEnum? SecondaryTreatmentType, TertiaryTreatmentTypeEnum? TertiaryTreatmentType,
            DisinfectionTypeEnum? DisinfectionType, CollectionSystemTypeEnum? CollectionSystemType, AlarmSystemTypeEnum? AlarmSystemType,
            float? DesignFlow_m3_day, float? AverageFlow_m3_day, float? PeakFlow_m3_day, int? PopServed,
            CanOverflowTypeEnum? CanOverflow, ValveTypeEnum? ValveType, bool? HasBackupPower,
            float? PercFlowOfTotal, float? AverageDepth_m, int? NumberOfPorts,
            float? PortDiameter_m, float? PortSpacing_m, float? PortElevation_m, float? VerticalAngle_deg, float? HorizontalAngle_deg,
            float? DecayRate_per_day, float? NearFieldVelocity_m_s, float? FarFieldVelocity_m_s, float? ReceivingWaterSalinity_PSU,
            float? ReceivingWaterTemperature_C, int? ReceivingWater_MPN_per_100ml, float? DistanceFromShore_m,
            int? SeeOtherMunicipalityTVItemID, string SeeOtherMunicipalityText, int? PumpsToTVItemID, string LinePathInf, string LinePathInfOutfall, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            if (InfrastructureType == null)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureType)}");
            }

            TVTypeEnum tvTypeInfrastructure = TVTypeEnum.Error;

            switch (InfrastructureType)
            {
                case InfrastructureTypeEnum.LiftStation:
                    {
                        tvTypeInfrastructure = TVTypeEnum.LiftStation;
                    }
                    break;
                case InfrastructureTypeEnum.LineOverflow:
                    {
                        tvTypeInfrastructure = TVTypeEnum.LineOverflow;
                    }
                    break;
                case InfrastructureTypeEnum.Other:
                    {
                        tvTypeInfrastructure = TVTypeEnum.OtherInfrastructure;
                    }
                    break;
                case InfrastructureTypeEnum.SeeOtherMunicipality:
                    {
                        tvTypeInfrastructure = TVTypeEnum.SeeOtherMunicipality;
                    }
                    break;
                case InfrastructureTypeEnum.WWTP:
                    {
                        tvTypeInfrastructure = TVTypeEnum.WasteWaterTreatmentPlant;
                    }
                    break;
                default:
                    break;
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, user);
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, user);
            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, user);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, user);

            if (MunicipalityTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.MunicipalityTVItemID)}");
            }

            TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
            {
                return ReturnError($"ERROR: {tvItemModelMunicipality.Error}");
            }

            if (TVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            if (string.IsNullOrWhiteSpace(TVText))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.TVText)}");
            }

            InfrastructureModel infrastructureModelRet = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
            if (TVItemID >= 10000000 || !string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
            {
                TVItemModel tvItemModelInfrastructure = tvItemService.PostAddChildTVItemDB(MunicipalityTVItemID, TVText, TVTypeEnum.Infrastructure);
                if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelInfrastructure.Error}");
                }

                InfrastructureModel infrastructureModelNew = new InfrastructureModel();
                infrastructureModelNew.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
                infrastructureModelNew.InfrastructureTVText = TVText;

                infrastructureModelRet = infrastructureService.PostAddInfrastructureDB(infrastructureModelNew);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModelRet.Error}");
                }

                // changing comment (EN)
                InfrastructureLanguageModel infrastructureLanguageModelEN = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet.InfrastructureID, LanguageEnum.en);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelEN.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelEN.Error}");
                }

                infrastructureLanguageModelEN.Comment = CommentEN;

                InfrastructureLanguageModel infrastructureLanguageModelENRet = infrastructureService._InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelEN);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelENRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelENRet.Error}");
                }

                // changing comment (FR)
                InfrastructureLanguageModel infrastructureLanguageModelFR = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet.InfrastructureID, LanguageEnum.fr);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFR.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelFR.Error}");
                }

                infrastructureLanguageModelEN.Comment = CommentFR;

                InfrastructureLanguageModel infrastructureLanguageModelFRRet = infrastructureService._InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelFR);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFRRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelFRRet.Error}");
                }

                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat == null ? 0.0f : (float)Lat, Lng = Lng == null ? 0.0f : (float)Lng, Ordinal = 0 },
                };

                List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                foreach (MapInfoModel mapInfoModel in mapInfoModelList)
                {
                    MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet2.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoModelRet2.Error}");
                    }
                }

                MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, tvTypeInfrastructure, tvItemModelInfrastructure.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                {
                    return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                }

                List<Coord> coordListOutfall = new List<Coord>()
                {
                    new Coord() { Lat = LatOutfall == null ? 0.0f : (float)LatOutfall, Lng = LngOutfall == null ? 0.0f : (float)LngOutfall, Ordinal = 0 },
                };

                MapInfoModel mapInfoModelRetOutfall = mapInfoService.CreateMapInfoObjectDB(coordListOutfall, MapInfoDrawTypeEnum.Point, TVTypeEnum.Outfall, tvItemModelInfrastructure.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRetOutfall.Error))
                {
                    return ReturnError($"ERROR: {mapInfoModelRetOutfall.Error}");
                }

                // doing LinePathInf
                List<string> coordArrText = LinePathInf.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                List<Coord> coordLinePathInf = new List<Coord>();

                int ordinal = 1;
                foreach (string coordText in coordArrText)
                {
                    List<string> valStr = coordText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (valStr.Count != 3)
                    {
                        return ReturnError($"ERROR: LinePathInf not well formed. valStr != 3");
                    }

                    Coord coord = new Coord() { Lat = float.Parse(valStr[0]), Lng = float.Parse(valStr[1]), Ordinal = ordinal };
                    ordinal++;

                    coordLinePathInf.Add(coord);
                }

                MapInfoModel mapInfoModelLinePathRet = mapInfoService.CreateMapInfoObjectDB(coordLinePathInf, MapInfoDrawTypeEnum.Polyline, tvTypeInfrastructure, tvItemModelInfrastructure.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelLinePathRet.Error))
                {
                    return ReturnError($"ERROR: {mapInfoModelLinePathRet.Error}");
                }

                // doing LinePathInfOutfall
                List<string> coordArrTextOutfall = LinePathInfOutfall.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                List<Coord> coordLinePathInfOutfall = new List<Coord>();

                int ordinalOutfall = 1;
                foreach (string coordText in coordArrTextOutfall)
                {
                    List<string> valStr = coordText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                    if (valStr.Count != 3)
                    {
                        return ReturnError($"ERROR: LinePathInfOutfall not well formed. valStr != 3");
                    }

                    Coord coord = new Coord() { Lat = float.Parse(valStr[0]), Lng = float.Parse(valStr[1]), Ordinal = ordinalOutfall };
                    ordinalOutfall++;

                    coordLinePathInf.Add(coord);
                }

                MapInfoModel mapInfoModelLinePathOutfallRet = mapInfoService.CreateMapInfoObjectDB(coordLinePathInf, MapInfoDrawTypeEnum.Polyline, TVTypeEnum.Outfall, tvItemModelInfrastructure.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelLinePathOutfallRet.Error))
                {
                    return ReturnError($"ERROR: {mapInfoModelLinePathOutfallRet.Error}");
                }
            }

            if (string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
            {
                // changing TVText if required
                TVItemModel tvItemModelInfrastructure = tvItemService.GetTVItemModelWithTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelInfrastructure.Error}");
                }

                tvItemModelInfrastructure.TVText = TVText;
                tvItemModelInfrastructure.IsActive = IsActive;

                TVItemModel tvItemModelInfrastructureRet = tvItemService.PostUpdateTVItemDB(tvItemModelInfrastructure);
                if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructureRet.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelInfrastructureRet.Error}");
                }

                // changing TVText
                TVItemLanguageModel tvItemLanguageModelEN = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(infrastructureModelRet.InfrastructureTVItemID, LanguageEnum.en);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelEN.Error))
                {
                    return ReturnError($"ERROR: {tvItemLanguageModelEN.Error}");
                }
                tvItemLanguageModelEN.TVText = TVText;
                TVItemLanguageModel tvItemLanguageModelENRet = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelEN);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelENRet.Error))
                {
                    return ReturnError($"ERROR: {tvItemLanguageModelENRet.Error}");
                }

                // changing TVText
                TVItemLanguageModel tvItemLanguageModelFR = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(infrastructureModelRet.InfrastructureTVItemID, LanguageEnum.fr);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelFR.Error))
                {
                    return ReturnError($"ERROR: {tvItemLanguageModelFR.Error}");
                }
                tvItemLanguageModelFR.TVText = TVText;
                TVItemLanguageModel tvItemLanguageModelFRRet = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelFR);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelFRRet.Error))
                {
                    return ReturnError($"ERROR: {tvItemLanguageModelFRRet.Error}");
                }

                List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                foreach (MapInfoModel mapInfoModel in mapInfoModelList)
                {
                    if (!(mapInfoModel.TVType == tvTypeInfrastructure || mapInfoModel.TVType == TVTypeEnum.Outfall))
                    {
                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModelRet2.Error))
                        {
                            return ReturnError($"ERROR: {mapInfoModelRet2.Error}");
                        }
                    }
                }

                // changing Lat, Lng if required
                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat == null ? 0.0f : (float)Lat, Lng = Lng == null ? 0.0f : (float)Lng, Ordinal = 0 },
                };

                List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeInfrastructure, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count == 0)
                {
                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, tvTypeInfrastructure, infrastructureModelRet.InfrastructureTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                    }

                    mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeInfrastructure, MapInfoDrawTypeEnum.Point);
                }

                if (mapInfoPointModelList[0].Lat != coordList[0].Lat || mapInfoPointModelList[0].Lng != coordList[0].Lng)
                {
                    mapInfoPointModelList[0].Lat = coordList[0].Lat;
                    mapInfoPointModelList[0].Lng = coordList[0].Lng;
                    MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoPointModelRet.Error}");
                    }
                }

                // changing LatOutfall, LngOutfall if required
                List<Coord> coordListOutfall = new List<Coord>()
                {
                    new Coord() { Lat = LatOutfall == null ? 0.0f : (float)LatOutfall, Lng = LngOutfall == null ? 0.0f : (float)LngOutfall, Ordinal = 0 },
                };
                List<MapInfoPointModel> mapInfoPointModelOufallList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count == 0)
                {
                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordListOutfall, MapInfoDrawTypeEnum.Point, TVTypeEnum.Outfall, infrastructureModelRet.InfrastructureTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                    }
                    mapInfoPointModelOufallList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
                }

                if (mapInfoPointModelOufallList[0].Lat != coordListOutfall[0].Lat || mapInfoPointModelOufallList[0].Lng != coordListOutfall[0].Lng)
                {
                    mapInfoPointModelOufallList[0].Lat = coordListOutfall[0].Lat;
                    mapInfoPointModelOufallList[0].Lng = coordListOutfall[0].Lng;

                    MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelOufallList[0]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoPointModelRet.Error}");
                    }
                }

                // doing LinePathInf
                List<string> coordArrText = LinePathInf.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!string.IsNullOrEmpty(LinePathInf))
                {
                    List<Coord> coordLinePathInf = new List<Coord>();

                    int ordinal = 1;
                    foreach (string coordText in coordArrText)
                    {
                        List<string> valStr = coordText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                        if (valStr.Count != 3)
                        {
                            return ReturnError($"ERROR: LinePathInf not well formed. valStr != 3");
                        }

                        Coord coord = new Coord() { Lat = float.Parse(valStr[0]), Lng = float.Parse(valStr[1]), Ordinal = ordinal };
                        ordinal++;

                        coordLinePathInf.Add(coord);
                    }

                    List<MapInfoPointModel> mapInfoPointModelLinePathList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeInfrastructure, MapInfoDrawTypeEnum.Polyline);
                    if (mapInfoPointModelLinePathList.Count == 0)
                    {
                        MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordLinePathInf, MapInfoDrawTypeEnum.Polyline, tvTypeInfrastructure, infrastructureModelRet.InfrastructureTVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        {
                            return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                        }
                        mapInfoPointModelLinePathList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeInfrastructure, MapInfoDrawTypeEnum.Polyline);
                        if (mapInfoPointModelLinePathList.Count == 0)
                        {
                            return ReturnError($"ERROR: Could not find MapInfoModel created with TVType [{tvTypeInfrastructure.ToString()}] as Polyline for InfrastructureTVItemID = [{infrastructureModelRet.InfrastructureTVItemID}]");
                        }
                    }
                    else
                    {
                        bool FoundDifferent = false;
                        if (coordLinePathInf.Count != mapInfoPointModelLinePathList.Count)
                        {
                            FoundDifferent = true;
                        }
                        else
                        {
                            int count = coordLinePathInf.Count;
                            for (int i = 0; i < count; i++)
                            {
                                if (coordLinePathInf[i].Lat.ToString("F5") != mapInfoPointModelLinePathList[i].Lat.ToString("F5") || coordLinePathInf[i].Lng.ToString("F5") != mapInfoPointModelLinePathList[i].Lng.ToString("F5"))
                                {
                                    FoundDifferent = true;
                                    break;
                                }
                            }
                        }

                        if (FoundDifferent)
                        {
                            MapInfoModel mapInfoModel = mapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelLinePathList[0].MapInfoID);
                            if (!string.IsNullOrEmpty(mapInfoModel.Error))
                            {
                                MapInfoModel mapInfoModelRet = mapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                                {
                                    return ReturnError($"ERROR: Could not delete MapInfoModel with MapInfoID = [{mapInfoModel.MapInfoID}]");
                                }
                            }

                            MapInfoModel mapInfoModelRet2 = mapInfoService.CreateMapInfoObjectDB(coordLinePathInf, MapInfoDrawTypeEnum.Polyline, tvTypeInfrastructure, infrastructureModelRet.InfrastructureTVItemID);
                            if (!string.IsNullOrWhiteSpace(mapInfoModelRet2.Error))
                            {
                                return ReturnError($"ERROR: {mapInfoModelRet2.Error}");
                            }
                            mapInfoPointModelLinePathList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeInfrastructure, MapInfoDrawTypeEnum.Polyline);
                            if (mapInfoPointModelLinePathList.Count == 0)
                            {
                                return ReturnError($"ERROR: Could not find MapInfoModel created with TVType [{tvTypeInfrastructure.ToString()}] as Polyline for InfrastructureTVItemID = [{infrastructureModelRet.InfrastructureTVItemID}]");
                            }

                        }
                    }
                }
                else
                {
                    List<MapInfoPointModel> mapInfoPointModelLinePathListToDelete = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeInfrastructure, MapInfoDrawTypeEnum.Polyline);

                    if (mapInfoPointModelLinePathListToDelete.Count > 0)
                    {
                        MapInfoModel mapInfoModel = mapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelLinePathListToDelete[0].MapInfoID);
                        if (!string.IsNullOrEmpty(mapInfoModel.Error))
                        {
                            MapInfoModel mapInfoModelRet = mapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                            {
                                return ReturnError($"ERROR: Could not delete MapInfoModel with MapInfoID = [{mapInfoModel.MapInfoID}]");
                            }
                        }
                    }

                }

                // doing LinePathInfOutfall
                List<string> coordArrTextOutfall = LinePathInfOutfall.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!string.IsNullOrEmpty(LinePathInfOutfall))
                {
                    List<Coord> coordLinePathInfOutfall = new List<Coord>();

                    int ordinal = 1;
                    foreach (string coordText in coordArrText)
                    {
                        List<string> valStr = coordText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                        if (valStr.Count != 3)
                        {
                            return ReturnError($"ERROR: LinePathInf not well formed. valStr != 3");
                        }

                        Coord coord = new Coord() { Lat = float.Parse(valStr[0]), Lng = float.Parse(valStr[1]), Ordinal = ordinal };
                        ordinal++;

                        coordLinePathInfOutfall.Add(coord);
                    }

                    List<MapInfoPointModel> mapInfoPointModelLinePathOutfallList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Polyline);
                    if (mapInfoPointModelLinePathOutfallList.Count == 0)
                    {
                        MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordLinePathInfOutfall, MapInfoDrawTypeEnum.Polyline, TVTypeEnum.Outfall, infrastructureModelRet.InfrastructureTVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        {
                            return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                        }
                        mapInfoPointModelLinePathOutfallList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Polyline);
                        if (mapInfoPointModelLinePathOutfallList.Count == 0)
                        {
                            return ReturnError($"ERROR: Could not find MapInfoModel created with TVType [{tvTypeInfrastructure.ToString()}] as Polyline for InfrastructureTVItemID = [{infrastructureModelRet.InfrastructureTVItemID}]");
                        }
                    }
                    else
                    {
                        bool FoundDifferent = false;
                        if (coordLinePathInfOutfall.Count != mapInfoPointModelLinePathOutfallList.Count)
                        {
                            FoundDifferent = true;
                        }
                        else
                        {
                            int count = coordLinePathInfOutfall.Count;
                            for (int i = 0; i < count; i++)
                            {
                                if (coordLinePathInfOutfall[i].Lat.ToString("F5") != mapInfoPointModelLinePathOutfallList[i].Lat.ToString("F5") || coordLinePathInfOutfall[i].Lng.ToString("F5") != mapInfoPointModelLinePathOutfallList[i].Lng.ToString("F5"))
                                {
                                    FoundDifferent = true;
                                    break;
                                }
                            }
                        }

                        if (FoundDifferent)
                        {
                            MapInfoModel mapInfoModel = mapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelLinePathOutfallList[0].MapInfoID);
                            if (!string.IsNullOrEmpty(mapInfoModel.Error))
                            {
                                MapInfoModel mapInfoModelRet = mapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                                {
                                    return ReturnError($"ERROR: Could not delete MapInfoModel with MapInfoID = [{mapInfoModel.MapInfoID}]");
                                }
                            }

                            MapInfoModel mapInfoModelRet2 = mapInfoService.CreateMapInfoObjectDB(coordLinePathInfOutfall, MapInfoDrawTypeEnum.Polyline, TVTypeEnum.Outfall, infrastructureModelRet.InfrastructureTVItemID);
                            if (!string.IsNullOrWhiteSpace(mapInfoModelRet2.Error))
                            {
                                return ReturnError($"ERROR: {mapInfoModelRet2.Error}");
                            }
                            mapInfoPointModelLinePathOutfallList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Polyline);
                            if (mapInfoPointModelLinePathOutfallList.Count == 0)
                            {
                                return ReturnError($"ERROR: Could not find MapInfoModel created with TVType [{tvTypeInfrastructure.ToString()}] as Polyline for InfrastructureTVItemID = [{infrastructureModelRet.InfrastructureTVItemID}]");
                            }

                        }
                    }
                }
                else
                {
                    List<MapInfoPointModel> mapInfoPointModelLinePathListToDelete = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Polyline);

                    if (mapInfoPointModelLinePathListToDelete.Count > 0)
                    {
                        MapInfoModel mapInfoModel = mapInfoService.GetMapInfoModelWithMapInfoIDDB(mapInfoPointModelLinePathListToDelete[0].MapInfoID);
                        if (!string.IsNullOrEmpty(mapInfoModel.Error))
                        {
                            MapInfoModel mapInfoModelRet = mapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                            {
                                return ReturnError($"ERROR: Could not delete MapInfoModel with MapInfoID = [{mapInfoModel.MapInfoID}]");
                            }
                        }
                    }

                }


                // changing Infrastructure
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModelRet.Error}");
                }

                infrastructureModelRet.InfrastructureType = InfrastructureType;

                if (InfrastructureType == InfrastructureTypeEnum.WWTP)
                {
                    infrastructureModelRet.FacilityType = FacilityType;
                    infrastructureModelRet.PreliminaryTreatmentType = PreliminaryTreatmentType;
                    infrastructureModelRet.PrimaryTreatmentType = PrimaryTreatmentType;
                    infrastructureModelRet.SecondaryTreatmentType = SecondaryTreatmentType;
                    infrastructureModelRet.TertiaryTreatmentType = TertiaryTreatmentType;
                    infrastructureModelRet.DisinfectionType = DisinfectionType;
                    infrastructureModelRet.CollectionSystemType = CollectionSystemType;
                    infrastructureModelRet.AlarmSystemType = AlarmSystemType;
                    infrastructureModelRet.NumberOfCells = NumberOfCells;
                    infrastructureModelRet.NumberOfAeratedCells = NumberOfAeratedCells;
                    infrastructureModelRet.IsMechanicallyAerated = IsMechanicallyAerated;
                    infrastructureModelRet.AerationType = AerationType;
                    infrastructureModelRet.DesignFlow_m3_day = DesignFlow_m3_day;
                    infrastructureModelRet.AverageFlow_m3_day = AverageFlow_m3_day;
                    infrastructureModelRet.PeakFlow_m3_day = PeakFlow_m3_day;
                    infrastructureModelRet.PopServed = PopServed;
                    infrastructureModelRet.CanOverflow = null;
                    if (CanOverflow != null)
                    {
                        if (CanOverflow == CanOverflowTypeEnum.Yes)
                        {
                            infrastructureModelRet.CanOverflow = true;
                        }
                        else if (CanOverflow == CanOverflowTypeEnum.No)
                        {
                            infrastructureModelRet.CanOverflow = false;
                        }
                    }
                    infrastructureModelRet.ValveType = ValveType;
                    infrastructureModelRet.HasBackupPower = HasBackupPower;
                    infrastructureModelRet.PercFlowOfTotal = PercFlowOfTotal;
                    infrastructureModelRet.AverageDepth_m = AverageDepth_m;
                    infrastructureModelRet.NumberOfPorts = NumberOfPorts;
                    infrastructureModelRet.PortDiameter_m = PortDiameter_m;
                    infrastructureModelRet.PortSpacing_m = PortSpacing_m;
                    infrastructureModelRet.PortElevation_m = PortElevation_m;
                    infrastructureModelRet.VerticalAngle_deg = VerticalAngle_deg;
                    infrastructureModelRet.HorizontalAngle_deg = HorizontalAngle_deg;
                    infrastructureModelRet.DecayRate_per_day = DecayRate_per_day;
                    infrastructureModelRet.NearFieldVelocity_m_s = NearFieldVelocity_m_s;
                    infrastructureModelRet.FarFieldVelocity_m_s = FarFieldVelocity_m_s;
                    infrastructureModelRet.ReceivingWaterSalinity_PSU = ReceivingWaterSalinity_PSU;
                    infrastructureModelRet.ReceivingWaterTemperature_C = ReceivingWaterTemperature_C;
                    infrastructureModelRet.ReceivingWater_MPN_per_100ml = ReceivingWater_MPN_per_100ml;
                    infrastructureModelRet.DistanceFromShore_m = DistanceFromShore_m;
                }
                else if (InfrastructureType == InfrastructureTypeEnum.LiftStation || InfrastructureType == InfrastructureTypeEnum.LineOverflow)
                {
                    infrastructureModelRet.FacilityType = null;
                    infrastructureModelRet.PreliminaryTreatmentType = null;
                    infrastructureModelRet.PrimaryTreatmentType = null;
                    infrastructureModelRet.SecondaryTreatmentType = null;
                    infrastructureModelRet.TertiaryTreatmentType = null;
                    infrastructureModelRet.DisinfectionType = null;
                    infrastructureModelRet.CollectionSystemType = null;
                    infrastructureModelRet.NumberOfAeratedCells = null;
                    infrastructureModelRet.IsMechanicallyAerated = null;
                    infrastructureModelRet.AerationType = null;
                    infrastructureModelRet.DesignFlow_m3_day = null;
                    infrastructureModelRet.AverageFlow_m3_day = null;
                    infrastructureModelRet.PeakFlow_m3_day = null;
                    infrastructureModelRet.PopServed = null;
                    infrastructureModelRet.AverageDepth_m = AverageDepth_m;
                    infrastructureModelRet.NumberOfPorts = NumberOfPorts;
                    infrastructureModelRet.PortDiameter_m = PortDiameter_m;
                    infrastructureModelRet.PortSpacing_m = PortSpacing_m;
                    infrastructureModelRet.PortElevation_m = PortElevation_m;
                    infrastructureModelRet.VerticalAngle_deg = VerticalAngle_deg;
                    infrastructureModelRet.HorizontalAngle_deg = HorizontalAngle_deg;
                    infrastructureModelRet.DecayRate_per_day = DecayRate_per_day;
                    infrastructureModelRet.NearFieldVelocity_m_s = NearFieldVelocity_m_s;
                    infrastructureModelRet.FarFieldVelocity_m_s = FarFieldVelocity_m_s;
                    infrastructureModelRet.ReceivingWaterSalinity_PSU = ReceivingWaterSalinity_PSU;
                    infrastructureModelRet.ReceivingWaterTemperature_C = ReceivingWaterTemperature_C;
                    infrastructureModelRet.ReceivingWater_MPN_per_100ml = ReceivingWater_MPN_per_100ml;
                    infrastructureModelRet.DistanceFromShore_m = DistanceFromShore_m;
                }
                else
                {
                    infrastructureModelRet.FacilityType = null;
                    infrastructureModelRet.PreliminaryTreatmentType = null;
                    infrastructureModelRet.PrimaryTreatmentType = null;
                    infrastructureModelRet.SecondaryTreatmentType = null;
                    infrastructureModelRet.TertiaryTreatmentType = null;
                    infrastructureModelRet.DisinfectionType = null;
                    infrastructureModelRet.CollectionSystemType = null;
                    infrastructureModelRet.NumberOfAeratedCells = null;
                    infrastructureModelRet.IsMechanicallyAerated = null;
                    infrastructureModelRet.AerationType = null;
                    infrastructureModelRet.DesignFlow_m3_day = null;
                    infrastructureModelRet.AverageFlow_m3_day = null;
                    infrastructureModelRet.PeakFlow_m3_day = null;
                    infrastructureModelRet.PopServed = null;
                    infrastructureModelRet.AverageDepth_m = null;
                    infrastructureModelRet.NumberOfPorts = null;
                    infrastructureModelRet.PortDiameter_m = null;
                    infrastructureModelRet.PortSpacing_m = null;
                    infrastructureModelRet.PortElevation_m = null;
                    infrastructureModelRet.VerticalAngle_deg = null;
                    infrastructureModelRet.HorizontalAngle_deg = null;
                    infrastructureModelRet.DecayRate_per_day = null;
                    infrastructureModelRet.NearFieldVelocity_m_s = null;
                    infrastructureModelRet.FarFieldVelocity_m_s = null;
                    infrastructureModelRet.ReceivingWaterSalinity_PSU = null;
                    infrastructureModelRet.ReceivingWaterTemperature_C = null;
                    infrastructureModelRet.ReceivingWater_MPN_per_100ml = null;
                    infrastructureModelRet.DistanceFromShore_m = null;
                }

                if (InfrastructureType == InfrastructureTypeEnum.LiftStation || InfrastructureType == InfrastructureTypeEnum.LineOverflow)
                {
                    infrastructureModelRet.AlarmSystemType = AlarmSystemType;
                    if (CanOverflow != null)
                    {
                        if (CanOverflow == CanOverflowTypeEnum.Yes)
                        {
                            infrastructureModelRet.CanOverflow = true;
                        }
                        else if (CanOverflow == CanOverflowTypeEnum.No)
                        {
                            infrastructureModelRet.CanOverflow = false;
                        }
                    }
                    infrastructureModelRet.ValveType = ValveType;
                    infrastructureModelRet.HasBackupPower = HasBackupPower;
                    infrastructureModelRet.PercFlowOfTotal = PercFlowOfTotal;
                }

                if (InfrastructureType == InfrastructureTypeEnum.SeeOtherMunicipality)
                {
                    if (SeeOtherMunicipalityTVItemID != null && SeeOtherMunicipalityTVItemID != 0)
                    {
                        infrastructureModelRet.SeeOtherMunicipalityTVItemID = SeeOtherMunicipalityTVItemID;
                    }
                }
                else
                {
                    infrastructureModelRet.SeeOtherMunicipalityTVItemID = null;
                }

                infrastructureModelRet.InfrastructureTVText = TVText;

                InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet2.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModelRet2.Error}");
                }

                // changing comment (EN) if required
                InfrastructureLanguageModel infrastructureLanguageModelEN = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet2.InfrastructureID, LanguageEnum.en);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelEN.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelEN.Error}");
                }

                if (infrastructureLanguageModelEN.Comment != CommentEN)
                {
                    infrastructureLanguageModelEN.Comment = CommentEN;

                    InfrastructureLanguageModel infrastructureLanguageModelENRet = infrastructureService._InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelEN);
                    if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelENRet.Error))
                    {
                        return ReturnError($"ERROR: {infrastructureLanguageModelENRet.Error}");
                    }
                }

                // changing comment (FR)
                InfrastructureLanguageModel infrastructureLanguageModelFR = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet2.InfrastructureID, LanguageEnum.fr);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFR.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelFR.Error}");
                }

                if (infrastructureLanguageModelFR.Comment != CommentFR)
                {
                    infrastructureLanguageModelFR.Comment = CommentFR;

                    InfrastructureLanguageModel infrastructureLanguageModelFRRet = infrastructureService._InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelFR);
                    if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFRRet.Error))
                    {
                        return ReturnError($"ERROR: {infrastructureLanguageModelFRRet.Error}");
                    }
                }

                if (PumpsToTVItemID != null && PumpsToTVItemID > 0)
                {
                    List<int> TVItemLinkIDListToDelete = new List<int>();

                    List<TVItemLinkModel> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(infrastructureModelRet2.InfrastructureTVItemID);
                    foreach (TVItemLinkModel tvItemLinkModel2 in tvItemLinkModelList)
                    {
                        if (tvItemLinkModel2.FromTVType == TVTypeEnum.Infrastructure && tvItemLinkModel2.ToTVType == TVTypeEnum.Infrastructure)
                        {
                            if (tvItemLinkModel2.ToTVItemID != PumpsToTVItemID)
                            {
                                TVItemLinkIDListToDelete.Add(tvItemLinkModel2.TVItemLinkID);
                            }
                        }
                    }

                    foreach (int tvItemLinkIDToDelete in TVItemLinkIDListToDelete)
                    {
                        TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkIDToDelete);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                        {
                            return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                        }
                    }

                    TVItemLinkModel tvItemLinkModel = tvItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(infrastructureModelRet2.InfrastructureTVItemID, (int)PumpsToTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    {
                        TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                        {
                            FromTVItemID = infrastructureModelRet2.InfrastructureTVItemID,
                            ToTVItemID = (int)PumpsToTVItemID,
                            FromTVType = TVTypeEnum.Infrastructure,
                            ToTVType = TVTypeEnum.Infrastructure,
                            StartDateTime_Local = DateTime.UtcNow.AddDays(-1),
                            EndDateTime_Local = DateTime.UtcNow,
                            Ordinal = 0,
                            TVLevel = 0,
                            TVPath = "p" + infrastructureModelRet2.InfrastructureTVItemID + "p" + PumpsToTVItemID,
                        };

                        TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                        {
                            return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                        }
                    }
                    else
                    {
                        tvItemLinkModel.FromTVItemID = infrastructureModelRet2.InfrastructureTVItemID;
                        tvItemLinkModel.ToTVItemID = (int)PumpsToTVItemID;
                        tvItemLinkModel.FromTVType = TVTypeEnum.Infrastructure;
                        tvItemLinkModel.ToTVType = TVTypeEnum.Infrastructure;
                        tvItemLinkModel.StartDateTime_Local = DateTime.UtcNow.AddDays(-1);
                        tvItemLinkModel.EndDateTime_Local = DateTime.UtcNow;
                        tvItemLinkModel.Ordinal = 0;
                        tvItemLinkModel.TVLevel = 0;
                        tvItemLinkModel.TVPath = "p" + infrastructureModelRet2.InfrastructureTVItemID + "p" + PumpsToTVItemID;

                        TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                        {
                            return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                        }
                    }
                }

            }

            return ReturnError($"{infrastructureModelRet.InfrastructureTVItemID}");
        }
        public TVItemModel CreateNewPollutionSourceSiteDB(int SubsectorTVItemID, int TVItemID, string TVText, int SiteNumber, float Lat, float Lng, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);
            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, user);

            if (SubsectorTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.SubsectorTVItemID)}");
            }

            TVItemModel tvItemModelSS = tvItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSS.Error))
            {
                return ReturnError($"ERROR: {tvItemModelSS.Error}");
            }

            if (TVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            if (string.IsNullOrWhiteSpace(TVText))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.TVText)}");
            }



            PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
            if (TVItemID >= 10000000 || !string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
            {
                int Site = polSourceSiteService.GetNextAvailableSiteNumberWithParentTVItemIDDB(SubsectorTVItemID);

                TVText = TVText.Replace("000000".Substring(0, SiteNumber.ToString().Length) + SiteNumber.ToString(), "000000".Substring(0, Site.ToString().Length) + Site.ToString());
                TVItemModel tvItemModelPSS = tvItemService.PostAddChildTVItemDB(SubsectorTVItemID, TVText, TVTypeEnum.PolSourceSite);
                if (!string.IsNullOrWhiteSpace(tvItemModelPSS.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelPSS.Error}");
                }

                PolSourceSiteModel polSourceSiteModelNew = new PolSourceSiteModel();
                polSourceSiteModelNew.PolSourceSiteTVItemID = tvItemModelPSS.TVItemID;
                polSourceSiteModelNew.PolSourceSiteTVText = TVText;
                polSourceSiteModelNew.IsPointSource = false;
                polSourceSiteModelNew.Site = Site;

                polSourceSiteModelRet = polSourceSiteService.PostAddPolSourceSiteDB(polSourceSiteModelNew);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                {
                    return ReturnError($"ERROR: {polSourceSiteModelRet.Error}");
                }

                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                };

                MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.PolSourceSite, tvItemModelPSS.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                {
                    return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                }
            }
            else
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._NeedToBeMoreThan_, ServiceRes.TVItemID, "10000000")}");
            }

            return ReturnError($"{polSourceSiteModelRet.PolSourceSiteTVItemID}");
        }
        public TVItemModel CreateNewObsDateDB(int PSSTVItemID, DateTime NewObsDate, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);
            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, user);

            if (PSSTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(PSSTVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
            {
                return ReturnError($"ERROR: {polSourceSiteModel.Error}");
            }

            if (NewObsDate.Year < 1980 || NewObsDate > DateTime.Now)
            {
                return ReturnError($"ERROR: {ServiceRes.DateOfObservationShouldBeBetween1980AndToday}");
            }

            PolSourceObservationModel polSourceObservationModelNew = new PolSourceObservationModel();
            polSourceObservationModelNew.PolSourceSiteTVItemID = PSSTVItemID;
            polSourceObservationModelNew.PolSourceSiteID = polSourceSiteModel.PolSourceSiteID;
            polSourceObservationModelNew.ContactTVItemID = contactModel.ContactTVItemID;
            polSourceObservationModelNew.DesktopReviewed = false;
            polSourceObservationModelNew.ObservationDate_Local = NewObsDate;
            polSourceObservationModelNew.Observation_ToBeDeleted = "-";

            PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PostAddPolSourceObservationDB(polSourceObservationModelNew);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModelRet.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationModelRet.Error}");
            }

            return ReturnError($"{polSourceObservationModelRet.PolSourceObservationID}");
        }
        public TVItemModel RemoveIssueDB(int ObsID, int IssueID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, user);
            PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, user);

            if (ObsID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }
            if (ObsID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "ObsID", "10000000")}");
            }

            PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(ObsID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationModel.Error}");
            }

            if (IssueID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }

            List<PolSourceObservationIssueModel> polSourceObservationIssueModelList = polSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(ObsID);

            bool DidDelete = false;
            foreach (PolSourceObservationIssueModel polSourceObservationIssueModel in polSourceObservationIssueModelList)
            {
                if (polSourceObservationIssueModel.PolSourceObservationIssueID == IssueID)
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = polSourceObservationIssueService.GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(IssueID);
                    if (string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                    {
                        PolSourceObservationIssueModel polSourceObservationIssueModelRetDel = polSourceObservationIssueService.PostDeletePolSourceObservationIssueDB(IssueID);
                        if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRetDel.Error))
                        {
                            return ReturnError(polSourceObservationIssueModelRetDel.Error);
                        }

                    }


                    DidDelete = true;
                }
            }

            if (!DidDelete)
            {
                return ReturnError("ERROR: Issue already deleted");
            }

            return ReturnError("");

        }
        public TVItemModel SavePSSorInfrastructureAddressDB(int ProvinceTVItemID, int TVItemID, string StreetNumber, string StreetName, int StreetType, string Municipality, string PostalCode, bool CreateMunicipality, bool IsPSS, bool IsInfrastructure, bool IsContact, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            AddressService addressService = new AddressService(LanguageRequest, user);
            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, user);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, user);

            // doing Province
            if (ProvinceTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.ProvinceTVItemID)}");
            }

            TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProvince.Error))
            {
                return ReturnError($"ERROR: {tvItemModelProvince.Error}");
            }

            if (TVItemID == 0)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID));
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000"));
            }

            if (string.IsNullOrWhiteSpace(Municipality))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Municipality));
            }

            if (IsPSS)
            {
                PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                {
                    return ReturnError($"ERROR: {polSourceSiteModel.Error}");
                }
            }

            if (IsInfrastructure)
            {
                InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModel.Error}");
                }
            }

            if (IsContact)
            {
                ContactModel contactModel2 = contactService.GetContactModelWithContactTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(contactModel2.Error))
                {
                    return ReturnError($"ERROR: {contactModel2.Error}");
                }
            }

            TVItemModel tvItemModelMunicipality = new TVItemModel();
            if (CreateMunicipality)
            {
                tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                {
                    tvItemModelMunicipality = tvItemService.PostAddChildTVItemDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                    if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                    {
                        return ReturnError($"ERROR: {string.Format(ServiceRes.CouldNotCreateMunicipality_, Municipality)}");
                    }
                }
            }
            else
            {
                tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                {
                    return ReturnError($"ERROR: {string.Format(ServiceRes.CouldNotFindMunicipality_, Municipality)}");
                }
            }

            List<TVItemModel> tvItemModelParents = tvItemService.GetParentsTVItemModelList(tvItemModelMunicipality.TVPath);

            AddressModel addressModelNew = new AddressModel();
            addressModelNew.AddressType = AddressTypeEnum.Civic;
            addressModelNew.StreetNumber = StreetNumber;
            addressModelNew.StreetName = StreetName;
            addressModelNew.StreetType = (StreetTypeEnum)StreetType;
            addressModelNew.MunicipalityTVItemID = tvItemModelMunicipality.TVItemID;
            addressModelNew.ProvinceTVItemID = tvItemModelProvince.TVItemID;
            addressModelNew.CountryTVItemID = tvItemModelProvince.ParentID;
            addressModelNew.PostalCode = PostalCode;

            string TVTextAddress = addressService.CreateTVText(addressModelNew);

            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
            {
                return ReturnError($"ERROR: {tvItemModelRoot.Error}");
            }

            AddressModel addressModelRet = addressService.GetAddressModelExistDB(addressModelNew);
            if (!string.IsNullOrWhiteSpace(addressModelRet.Error))
            {
                TVItemModel tvItemModelAddress = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVTextAddress, TVTypeEnum.Address);
                if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelAddress.Error}");
                }

                addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

                addressModelRet = addressService.PostAddAddressDB(addressModelNew);
                if (!string.IsNullOrWhiteSpace(addressModelRet.Error))
                {
                    return ReturnError($"ERROR: {addressModelRet.Error}");
                }
            }

            if (IsPSS)
            {
                PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                {
                    return ReturnError($"ERROR: {polSourceSiteModel.Error}");
                }

                polSourceSiteModel.CivicAddressTVItemID = addressModelRet.AddressTVItemID;
                PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                {
                    return ReturnError($"ERROR: {polSourceSiteModelRet.Error}");
                }
            }

            if (IsInfrastructure)
            {
                InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModel.Error}");
                }

                infrastructureModel.CivicAddressTVItemID = addressModelRet.AddressTVItemID;
                InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModelRet.Error}");
                }
            }

            if (IsContact)
            {
                ContactModel contactModel3 = contactService.GetContactModelWithContactTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(contactModel3.Error))
                {
                    return ReturnError($"ERROR: {contactModel3.Error}");
                }

                TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                {
                    FromTVItemID = contactModel3.ContactTVItemID,
                    ToTVItemID = addressModelRet.AddressTVItemID,
                    FromTVType = TVTypeEnum.Contact,
                    ToTVType = TVTypeEnum.Address,
                    StartDateTime_Local = DateTime.Now,
                    Ordinal = 0,
                    TVLevel = 0,
                    TVPath = "p" + contactModel3.ContactTVItemID + "p" + addressModelRet.AddressTVItemID,
                };

                TVItemLinkModel tvItemLinkModel = tvItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(contactModel3.ContactTVItemID, addressModelRet.AddressTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                {
                    tvItemLinkModel = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    {
                        return ReturnError($"ERROR: {tvItemLinkModel.Error}");
                    }
                }
            }

            return ReturnError($"{addressModelRet.AddressTVItemID}");
        }
        public TVItemModel SaveLatLngWithTVTypeDB(int TVItemID, float Lat, float Lng, TVTypeEnum TVType, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, user);

            if (TVItemID == 0)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID));
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000"));
            }

            List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(TVItemID);

            foreach (MapInfoModel mapInfoModel in mapInfoModelList)
            {
                if (mapInfoModel.TVType == TVType)
                {
                    if (mapInfoModel.MapInfoDrawType == MapInfoDrawTypeEnum.Point)
                    {
                        List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemID, TVType, MapInfoDrawTypeEnum.Point);

                        if (mapInfoPointModelList.Count > 0)
                        {
                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                            {
                                if (mapInfoPointModel.Lat != Lat || mapInfoPointModel.Lng != Lng)
                                {
                                    mapInfoPointModel.Lat = Lat;
                                    mapInfoPointModel.Lng = Lng;

                                    MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModel);
                                    if (!string.IsNullOrWhiteSpace(mapInfoPointModel.Error))
                                    {
                                        return ReturnError(mapInfoPointModel.Error);
                                    }
                                }

                                break; // just do first
                            }

                        }
                        break;
                    }
                }
            }

            return ReturnError("");
        }
        public TVItemModel SavePictureInfoDB(int TVItemID, int PictureTVItemID, string FileName, string Description, string Extension, bool FromWater, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVFileService tvFileService = new TVFileService(LanguageRequest, user);

            if (TVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000")}");
            }

            TVItemModel tvItemModelPSS = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelPSS.Error))
            {
                return ReturnError($"ERROR: {tvItemModelPSS.Error}");
            }

            if (PictureTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "PictureTVItemID")}");
            }

            if (PictureTVItemID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "PictureTVItemID", "10000000")}");
            }

            TVFileModel tvFileModelPicture = tvFileService.GetTVFileModelWithTVFileTVItemIDDB(PictureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelPicture.Error))
            {
                return ReturnError($"ERROR: {tvFileModelPicture.Error}");
            }

            FileInfo fi = new FileInfo(tvFileModelPicture.ServerFilePath + tvFileModelPicture.ServerFileName);

            if (!fi.Exists)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.File_DoesNotExist, fi.FullName)}");
            }

            tvFileModelPicture.ServerFileName = FileName + Extension;
            tvFileModelPicture.FileDescription = Description;
            tvFileModelPicture.FromWater = FromWater;

            TVFileModel tvFileModelPictureRet = tvFileService.PostUpdateTVFileDB(tvFileModelPicture);
            if (!string.IsNullOrWhiteSpace(tvFileModelPictureRet.Error))
            {
                return ReturnError($"ERROR: {tvFileModelPictureRet.Error}");
            }

            return ReturnError($"{tvFileModelPictureRet.TVFileTVItemID}");

        }
        public TVItemModel RemovePictureDB(int TVItemID, int PictureTVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVFileService tvFileService = new TVFileService(LanguageRequest, user);

            if (TVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000")}");
            }

            TVItemModel tvItemModelPSS = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelPSS.Error))
            {
                return ReturnError($"ERROR: {tvItemModelPSS.Error}");
            }

            if (PictureTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "PictureTVItemID")}");
            }

            if (PictureTVItemID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "PictureTVItemID", "10000000")}");
            }

            TVFileModel tvFileModelPicture = tvFileService.GetTVFileModelWithTVFileTVItemIDDB(PictureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelPicture.Error))
            {
                return ReturnError($"ERROR: {tvFileModelPicture.Error}");
            }

            TVFileModel tvFileModelRet = tvFileService.PostDeleteTVFileWithTVItemIDDB(PictureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
            {
                return ReturnError($"ERROR: {tvFileModelRet.Error}");
            }

            return ReturnError($"");

        }
        public TVItemModel SavePSSObsIssueDB(int ObsID, int IssueID, int Ordinal, string ObservationInfo, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, user);
            PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, user);

            if (ObsID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }
            if (ObsID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "ObsID", "10000000")}");
            }

            PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(ObsID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationModel.Error}");
            }

            if (IssueID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }

            List<PolSourceObservationIssueModel> polSourceObservationIssueModelList = polSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(ObsID);

            PolSourceObservationIssueModel polSourceObservationIssueModelExist = null;
            foreach (PolSourceObservationIssueModel polSourceObservationIssueModel in polSourceObservationIssueModelList)
            {
                if (polSourceObservationIssueModel.PolSourceObservationIssueID == IssueID)
                {
                    polSourceObservationIssueModelExist = polSourceObservationIssueModel;
                    break;
                }
            }

            PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = new PolSourceObservationIssueModel();
            if (polSourceObservationIssueModelExist != null)
            {
                polSourceObservationIssueModelExist.Ordinal = Ordinal;
                polSourceObservationIssueModelExist.ObservationInfo = ObservationInfo;
                polSourceObservationIssueModelExist.PolSourceObsInfoList = ObservationInfo.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => (PolSourceObsInfoEnum)int.Parse(c)).ToList();

                polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelExist);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet2.Error))
                {
                    return ReturnError($"ERROR: {polSourceObservationIssueModelRet2.Error}");
                }
            }
            else
            {
                PolSourceObservationIssueModel polSourceObservationIssueModelNew = new PolSourceObservationIssueModel();
                polSourceObservationIssueModelNew.PolSourceObservationID = ObsID;
                polSourceObservationIssueModelNew.Ordinal = Ordinal;
                polSourceObservationIssueModelNew.ObservationInfo = ObservationInfo;
                polSourceObservationIssueModelNew.PolSourceObsInfoList = ObservationInfo.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => (PolSourceObsInfoEnum)int.Parse(c)).ToList();

                polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelNew);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet2.Error))
                {
                    return ReturnError($"ERROR: {polSourceObservationIssueModelRet2.Error}");
                }
            }

            return ReturnError($"{polSourceObservationIssueModelRet2.PolSourceObservationIssueID}");

        }
        public TVItemModel SavePSSObsIssueExtraCommentDB(int ObsID, int IssueID, string ExtraComment, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, user);
            PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, user);

            if (ObsID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }
            if (ObsID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "ObsID", "10000000")}");
            }

            PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(ObsID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationModel.Error}");
            }

            if (IssueID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }
            if (IssueID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "IssueID", "10000000")}");
            }

            PolSourceObservationIssueModel polSourceObservationIssueModel = polSourceObservationIssueService.GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(IssueID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModel.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationIssueModel.Error}");
            }

            polSourceObservationIssueModel.ExtraComment = ExtraComment;

            PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModel);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet2.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationIssueModelRet2.Error}");
            }

            return ReturnError($"");

        }
        public TVItemModel SavePSSTVTextAndIsActiveDB(int TVItemID, string TVText, bool IsActive, bool IsPointSource, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, user);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);

            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemModel tvItemModel = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                return ReturnError(tvItemModel.Error);
            }

            tvItemModel.IsActive = IsActive;

            TVItemModel tvItemModelRet = tvItemService.PostUpdateTVItemDB(tvItemModel);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return ReturnError(tvItemModelRet.Error);
            }

            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
            polSourceSiteModel.IsPointSource = IsPointSource;

            PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
            {
                return ReturnError(polSourceSiteModelRet.Error);
            }

            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, user);

            if (TVItemID == 0)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID));
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000"));
            }

            foreach (LanguageEnum lang in LanguageListAllowable)
            {
                TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(TVItemID, lang);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                {
                    return ReturnError(tvItemLanguageModel.Error);
                }

                tvItemLanguageModel.TVText = TVText;

                TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                {
                    return ReturnError(tvItemLanguageModelRet.Error);
                }


            }

            return ReturnError("");
        }
        public TVItemModel UserExistDB(string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            return ReturnError("");
        }
        public TVItemModel EmailExistDB(int TVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            EmailService emailService = new EmailService(LanguageRequest, user);
            EmailModel emailModel = emailService.GetEmailModelWithEmailTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(emailModel.Error))
            {
                return ReturnError("ERROR: " + string.Format(ServiceRes._DoesNotExist, ServiceRes.Email));
            }

            return ReturnError("");
        }
        public TVItemModel TelExistDB(int TVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TelService telService = new TelService(LanguageRequest, user);
            TelModel telModel = telService.GetTelModelWithTelTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(telModel.Error))
            {
                return ReturnError("ERROR: " + string.Format(ServiceRes._DoesNotExist, ServiceRes.Tel));
            }

            return ReturnError("");
        }
        public TVItemModel ContactExistDB(int TVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            ContactModel contactModel2 = contactService.GetContactModelWithContactTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(contactModel2.Error))
            {
                return ReturnError("ERROR: " + string.Format(ServiceRes._DoesNotExist, ServiceRes.Contact));
            }

            return ReturnError("");
        }
        public TVItemModel InfrastructureExistDB(int TVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, user);
            InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
            {
                return ReturnError("ERROR: " + string.Format(ServiceRes._DoesNotExist, ServiceRes.Infrastructure));
            }

            return ReturnError("");
        }
        public TVItemModel PSSExistDB(int TVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);
            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
            {
                return ReturnError("ERROR: " + string.Format(ServiceRes._DoesNotExist, ServiceRes.PolSourceSite));
            }

            return ReturnError("");
        }
        public TVItemModel MunicipalityExistDB(int ProvinceTVItemID, string Municipality, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProvince.Error))
            {
                return ReturnError("ERROR: " + tvItemModelProvince.Error);
            }

            TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
            {
                return ReturnError("ERROR: " + tvItemModelMunicipality.Error);
            }

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}