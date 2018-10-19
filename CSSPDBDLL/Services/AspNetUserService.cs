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
    public class AspNetUserService : BaseService
    {
        #region Variables
        public UserManager<ApplicationUser2> _UserManager { get; private set; }
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public AspNetUserService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _UserManager = new UserManager<ApplicationUser2>(new UserStore<ApplicationUser2>(new IdentityDbContext("CSSPDBEntities")));
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
        public string AspNetUserModelOK(AspNetUserModel aspNetUserModel)
        {
            string retStr = EmailOK(aspNetUserModel.LoginEmail);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(aspNetUserModel.Password, ServiceRes.Password, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill 
        public string FillAspNetUser(AspNetUser aspNetUser, AspNetUserModel aspNetUserModel)
        {

            aspNetUser.Id = aspNetUserModel.Id;
            aspNetUser.Email = aspNetUserModel.LoginEmail;
            aspNetUser.EmailConfirmed = aspNetUserModel.EmailConfirmed;
            aspNetUser.PasswordHash = aspNetUserModel.PasswordHash;
            aspNetUser.SecurityStamp = aspNetUserModel.SecurityStamp;
            aspNetUser.PhoneNumber = aspNetUserModel.PhoneNumber;
            aspNetUser.PhoneNumberConfirmed = aspNetUserModel.PhoneNumberConfirmed;
            aspNetUser.TwoFactorEnabled = aspNetUserModel.TwoFactorEnabled;
            aspNetUser.LockoutEndDateUtc = aspNetUserModel.LockoutEndDateUtc;
            aspNetUser.LockoutEnabled = aspNetUserModel.LockoutEnabled;
            aspNetUser.AccessFailedCount = aspNetUserModel.AccessFailedCount;
            aspNetUser.UserName = aspNetUserModel.LoginEmail;

            return "";
        }

        // Get
        public int GetAspNetUserModelCountDB()
        {
            return (from c in db.AspNetUsers
                    select c).Count();
        }
        public List<AspNetUserModel> GetAspNetUserModelDB(int skip, int take)
        {
            take = Math.Min(take, TakeMax);

            List<AspNetUserModel> aspNetUserModelList = (from c in db.AspNetUsers
                                                         orderby c.Email
                                                         select new AspNetUserModel
                                                         {
                                                             Error = "",
                                                             Id = c.Id,
                                                             Email = c.Email,
                                                             EmailConfirmed = c.EmailConfirmed,
                                                             PasswordHash = c.PasswordHash,
                                                             SecurityStamp = c.SecurityStamp,
                                                             PhoneNumber = c.PhoneNumber,
                                                             PhoneNumberConfirmed = c.PhoneNumberConfirmed,
                                                             TwoFactorEnabled = c.TwoFactorEnabled,
                                                             LockoutEndDateUtc = c.LockoutEndDateUtc,
                                                             LockoutEnabled = c.LockoutEnabled,
                                                             AccessFailedCount = c.AccessFailedCount,
                                                             UserName = c.UserName,
                                                         }).Skip(skip).Take(take).ToList<AspNetUserModel>();

            return aspNetUserModelList;
        }
        public AspNetUserModel GetAspNetUserModelWithEmailDB(string Email)
        {
            AspNetUserModel aspNetUserModel = (from c in db.AspNetUsers
                                               where c.Email == Email
                                               select new AspNetUserModel
                                               {
                                                   Error = "",
                                                   Id = c.Id,
                                                   Email = c.Email,
                                                   EmailConfirmed = c.EmailConfirmed,
                                                   PasswordHash = c.PasswordHash,
                                                   SecurityStamp = c.SecurityStamp,
                                                   PhoneNumber = c.PhoneNumber,
                                                   PhoneNumberConfirmed = c.PhoneNumberConfirmed,
                                                   TwoFactorEnabled = c.TwoFactorEnabled,
                                                   LockoutEndDateUtc = c.LockoutEndDateUtc,
                                                   LockoutEnabled = c.LockoutEnabled,
                                                   AccessFailedCount = c.AccessFailedCount,
                                                   UserName = c.UserName,
                                                   LoginEmail = c.Email,
                                               }).FirstOrDefault<AspNetUserModel>();

            if (aspNetUserModel == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AspNetUser, ServiceRes.Email, Email));

            return aspNetUserModel;
        }
        public AspNetUserModel GetAspNetUserModelWithIdDB(string Id)
        {
            AspNetUserModel aspNetUserModel = (from c in db.AspNetUsers
                                               where c.Id == Id
                                               select new AspNetUserModel
                                               {
                                                   Error = "",
                                                   Id = c.Id,
                                                   Email = c.Email,
                                                   EmailConfirmed = c.EmailConfirmed,
                                                   PasswordHash = c.PasswordHash,
                                                   SecurityStamp = c.SecurityStamp,
                                                   PhoneNumber = c.PhoneNumber,
                                                   PhoneNumberConfirmed = c.PhoneNumberConfirmed,
                                                   TwoFactorEnabled = c.TwoFactorEnabled,
                                                   LockoutEndDateUtc = c.LockoutEndDateUtc,
                                                   LockoutEnabled = c.LockoutEnabled,
                                                   AccessFailedCount = c.AccessFailedCount,
                                                   UserName = c.UserName,
                                                   LoginEmail = c.Email,
                                               }).FirstOrDefault<AspNetUserModel>();

            if (aspNetUserModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AspNetUser, ServiceRes.Id, Id));

            return aspNetUserModel;
        }
        public AspNetUser GetAspNetUserWithEmailDB(string Email)
        {
            AspNetUser aspNetUser = (from c in db.AspNetUsers
                                     where c.Email == Email
                                     select c).FirstOrDefault<AspNetUser>();

            return aspNetUser;
        }
        public AspNetUser GetAspNetUserWithIdDB(string Id)
        {
            AspNetUser aspNetUser = (from c in db.AspNetUsers
                                     where c.Id == Id
                                     select c).FirstOrDefault<AspNetUser>();

            return aspNetUser;
        }

        // Helper
        public IdentityResult CreateUser(ApplicationUser2 applicationUser, string Password)
        {
            IdentityResult result = _UserManager.Create(applicationUser, Password);

            return result;
        }
        public AspNetUserModel ReturnError(string Error)
        {
            return new AspNetUserModel() { Error = Error };
        }

        // Post
        public AspNetUserModel PostAddFirstAspNetUserDB(AspNetUserModel aspNetUserModel)
        {
            int Count = GetAspNetUserModelCountDB();
            if (Count > 0) 
                return ReturnError(string.Format(ServiceRes.ToAddFirst_Requires_TableToBeEmpty, ServiceRes.AspNetUser));

            string retStr = AspNetUserModelOK(aspNetUserModel);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            AspNetUser aspNetUserExist = GetAspNetUserWithEmailDB(aspNetUserModel.LoginEmail);
            if (aspNetUserExist != null) 
                return ReturnError(string.Format(ServiceRes.UserWithLoginEmail_AlreadyExist, aspNetUserModel.LoginEmail));

            ApplicationUser2 applicationUser = new ApplicationUser2() { UserName = aspNetUserModel.LoginEmail };

            AspNetUser aspNetUserNew = new AspNetUser();

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    IdentityResult result = CreateUser(applicationUser, aspNetUserModel.Password);
                }
                catch (Exception)
                {
                    // nothing for now
                }

                aspNetUserModel.PasswordHash = applicationUser.PasswordHash;
                aspNetUserModel.SecurityStamp = applicationUser.SecurityStamp;
                aspNetUserModel.AccessFailedCount = applicationUser.AccessFailedCount;
                aspNetUserModel.Email = aspNetUserModel.LoginEmail;
                aspNetUserModel.UserName = aspNetUserModel.LoginEmail;
                aspNetUserModel.EmailConfirmed = applicationUser.EmailConfirmed;
                aspNetUserModel.Id = applicationUser.Id;
                aspNetUserModel.LockoutEnabled = applicationUser.LockoutEnabled;
                aspNetUserModel.LockoutEndDateUtc = applicationUser.LockoutEndDateUtc;
                aspNetUserModel.PhoneNumber = applicationUser.PhoneNumber;
                aspNetUserModel.PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed;
                aspNetUserModel.TwoFactorEnabled = applicationUser.TwoFactorEnabled;

                retStr = FillAspNetUser(aspNetUserNew, aspNetUserModel);
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                db.AspNetUsers.Add(aspNetUserNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("AppNetUsers", -1, LogCommandEnum.Add, aspNetUserNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetAspNetUserModelWithEmailDB(aspNetUserNew.Email);
        }
        public AspNetUserModel PostAddAspNetUserDB(AspNetUserModel aspNetUserModel, bool LoggedIn)
        {
            string retStr = AspNetUserModelOK(aspNetUserModel);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            AspNetUser aspNetUserExist = GetAspNetUserWithEmailDB(aspNetUserModel.LoginEmail);
            if (aspNetUserExist != null)
                return ReturnError(string.Format(ServiceRes.UserWithLoginEmail_AlreadyExist, aspNetUserModel.LoginEmail));

            if (LoggedIn)
            {
                ContactOK contactOK = IsContactOK();
                if (!string.IsNullOrEmpty(contactOK.Error)) 
                    return ReturnError(contactOK.Error);
            }

            string LoginEmail = aspNetUserModel.LoginEmail;
            ApplicationUser2 applicationUser = new ApplicationUser2() { UserName = LoginEmail };

            AspNetUser aspNetUserNew = new AspNetUser();

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    IdentityResult result = CreateUser(applicationUser, aspNetUserModel.Password);
                }
                catch (Exception)
                {
                    //return new AspNetUserModel() { Error = ex.Message };
                }

                aspNetUserModel.PasswordHash = applicationUser.PasswordHash;
                aspNetUserModel.SecurityStamp = applicationUser.SecurityStamp;
                aspNetUserModel.AccessFailedCount = applicationUser.AccessFailedCount;
                aspNetUserModel.Email = aspNetUserModel.LoginEmail;
                aspNetUserModel.UserName = aspNetUserModel.LoginEmail;
                aspNetUserModel.EmailConfirmed = applicationUser.EmailConfirmed;
                aspNetUserModel.Id = applicationUser.Id;
                aspNetUserModel.LockoutEnabled = applicationUser.LockoutEnabled;
                aspNetUserModel.LockoutEndDateUtc = applicationUser.LockoutEndDateUtc;
                aspNetUserModel.PhoneNumber = applicationUser.PhoneNumber;
                aspNetUserModel.PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed;
                aspNetUserModel.TwoFactorEnabled = applicationUser.TwoFactorEnabled;

                retStr = FillAspNetUser(aspNetUserNew, aspNetUserModel);
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                db.AspNetUsers.Add(aspNetUserNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                ts.Complete();
            }
            return GetAspNetUserModelWithEmailDB(aspNetUserNew.Email);
        }
        public AspNetUserModel PostDeleteAspNetUserWithIdDB(string Id)
        {
            //ContactOK contactOK = IsContactOK();
            //if (!string.IsNullOrEmpty(contactOK.Error))
            //    return ReturnError(contactOK.Error);

            AspNetUser aspNetUserToDelete = GetAspNetUserWithIdDB(Id);
            if (aspNetUserToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AspNetUser));

            using (TransactionScope ts = new TransactionScope())
            {
                db.AspNetUsers.Remove(aspNetUserToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("AppNetUsers", -1, LogCommandEnum.Delete, aspNetUserToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public AspNetUserModel PostUpdateAspNetUserDB(AspNetUserModel aspNetUserModel)
        {
            string retStr = AspNetUserModelOK(aspNetUserModel);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            //ContactOK contactOK = IsContactOK();
            //if (!string.IsNullOrEmpty(contactOK.Error)) 
            //    return ReturnError(contactOK.Error);

            AspNetUser aspNetUserToUpdate = GetAspNetUserWithIdDB(aspNetUserModel.Id);
            if (aspNetUserToUpdate == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.AspNetUser));

            retStr = FillAspNetUser(aspNetUserToUpdate, aspNetUserModel);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("AppNetUsers", -1, LogCommandEnum.Change, aspNetUserToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetAspNetUserModelWithEmailDB(aspNetUserToUpdate.Email);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
