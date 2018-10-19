using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using System.Collections.Generic;
using CSSPDBDLL.Services.Resources;
using System;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class ResetPasswordService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public ResetPasswordService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string ResetPasswordModelOK(ResetPasswordModel resetPassword)
        {

            if (string.IsNullOrWhiteSpace(resetPassword.Code))
            {
                return string.Format(ServiceRes._IsRequired, ServiceRes.Code);
            }

            if (resetPassword.Code.Length > 8)
            {
                return string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Code, 8);
            }

            if (resetPassword.Code.Length < 8)
            {
                return string.Format(ServiceRes._MinLengthIs_, ServiceRes.Code, 8);
            }

            string retStrEmail = EmailOK(resetPassword.Email);
            if (!string.IsNullOrWhiteSpace(retStrEmail))
            {
                return retStrEmail;
            }

            if (string.IsNullOrWhiteSpace(resetPassword.Password))
            {
                return string.Format(ServiceRes._IsRequired, ServiceRes.Password);
            }

            if (resetPassword.Password.Length > 100)
            {
                return string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Password, 100);
            }

            if (resetPassword.Password.Length < 6)
            {
                return string.Format(ServiceRes._MinLengthIs_, ServiceRes.Password, 6);
            }

            if (string.IsNullOrWhiteSpace(resetPassword.ConfirmPassword))
            {
                return string.Format(ServiceRes._IsRequired, ServiceRes.ConfirmPassword);
            }

            if (resetPassword.Password != resetPassword.ConfirmPassword)
            {
                return ServiceRes.PasswordAndConfirmPasswordNotIdentical;
            }

            // checking if Email exist
            Contact contact = (from c in db.Contacts
                               from a in db.AspNetUsers
                               where c.Id == a.Id
                               && a.UserName == resetPassword.Email
                               select c).FirstOrDefault<Contact>();

            if (contact == null)
            {
                return string.Format(ServiceRes.CouldNotFind_, ServiceRes.EmailIN);
            }

            string RetStr = CleanResetPasswordWithEmail(resetPassword.Email);
            if (!string.IsNullOrEmpty(RetStr))
            {
                return RetStr;
            }

            return "";
        }

        // Fill
        public string FillResetPassword(ResetPassword resetPassword, ResetPasswordModel resetPasswordModel, ContactOK contactOK)
        {
            try
            {
                resetPassword.Code = resetPasswordModel.Code;
                resetPassword.Email = resetPasswordModel.Email;
                resetPassword.ExpireDate_Local = resetPasswordModel.ExpireDate_Local;
                resetPassword.LastUpdateDate_UTC = DateTime.UtcNow;
                if (contactOK == null)
                {
                    resetPassword.LastUpdateContactTVItemID = 2;
                }
                else
                {
                    resetPassword.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

        // Get
        public int GetResetPasswordModelCountDB()
        {
            return (from c in db.ResetPasswords
                    select c).Count();
        }
        public List<ResetPasswordModel> GetResetPasswordModelListDB(int skip, int take)
        {
            List<ResetPasswordModel> resetPasswordModelList = (from c in db.ResetPasswords
                                                               orderby c.ResetPasswordID
                                                               select new ResetPasswordModel
                                                               {
                                                                   Error = "",
                                                                   ResetPasswordID = c.ResetPasswordID,
                                                                   Code = c.Code,
                                                                   Email = c.Email,
                                                                   ExpireDate_Local = c.ExpireDate_Local,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                               }).Skip(skip).Take(take).ToList<ResetPasswordModel>();

            return resetPasswordModelList;
        }
        public List<ResetPasswordModel> GetResetPasswordModelListWithEmailDB(string Email)
        {
            List<ResetPasswordModel> resetPasswordModelList = (from c in db.ResetPasswords
                                                               where c.Email == Email
                                                               orderby c.ResetPasswordID
                                                               select new ResetPasswordModel
                                                               {
                                                                   Error = "",
                                                                   ResetPasswordID = c.ResetPasswordID,
                                                                   Code = c.Code,
                                                                   Email = c.Email,
                                                                   ExpireDate_Local = c.ExpireDate_Local,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                               }).ToList<ResetPasswordModel>();

            return resetPasswordModelList;
        }
        public List<ResetPasswordModel> GetResetPasswordModelListWithCodeDB(string Code)
        {
            List<ResetPasswordModel> resetPasswordModelList = (from c in db.ResetPasswords
                                                               where c.Code == Code
                                                               orderby c.ResetPasswordID
                                                               select new ResetPasswordModel
                                                               {
                                                                   Error = "",
                                                                   ResetPasswordID = c.ResetPasswordID,
                                                                   Code = c.Code,
                                                                   Email = c.Email,
                                                                   ExpireDate_Local = c.ExpireDate_Local,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                               }).ToList<ResetPasswordModel>();

            return resetPasswordModelList;
        }
        public ResetPasswordModel GetResetPasswordModelWithCodeAndEmailDB(string Code, string Email)
        {
            ResetPasswordModel resetPasswordModel = (from c in db.ResetPasswords
                                                     where c.Code == Code
                                                     && c.Email == Email
                                                     orderby c.ResetPasswordID
                                                     select new ResetPasswordModel
                                                     {
                                                         Error = "",
                                                         ResetPasswordID = c.ResetPasswordID,
                                                         Code = c.Code,
                                                         Email = c.Email,
                                                         ExpireDate_Local = c.ExpireDate_Local,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                     }).FirstOrDefault<ResetPasswordModel>();
            if (resetPasswordModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ResetPassword, ServiceRes.Code + "," + ServiceRes.Email, Code + "," + Email));

            return resetPasswordModel;
        }
        public ResetPasswordModel GetResetPasswordModelWithResetPasswordIDDB(int ResetPasswordID)
        {
            ResetPasswordModel resetPasswordModel = (from c in db.ResetPasswords
                                                     where c.ResetPasswordID == ResetPasswordID
                                                     orderby c.ResetPasswordID
                                                     select new ResetPasswordModel
                                                     {
                                                         Error = "",
                                                         ResetPasswordID = c.ResetPasswordID,
                                                         Code = c.Code,
                                                         Email = c.Email,
                                                         ExpireDate_Local = c.ExpireDate_Local,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                     }).FirstOrDefault<ResetPasswordModel>();

            if (resetPasswordModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ResetPassword, ServiceRes.ResetPasswordID, ResetPasswordID));

            return resetPasswordModel;
        }
        public ResetPassword GetResetPasswordWithResetPasswordIDDB(int ResetPasswordID)
        {
            ResetPassword resetPassword = (from c in db.ResetPasswords
                                           where c.ResetPasswordID == ResetPasswordID
                                           orderby c.ResetPasswordID
                                           select c).FirstOrDefault<ResetPassword>();

            return resetPassword;
        }

        // Helper
        public string CleanResetPasswordWithEmail(string Email)
        {
            // remove the ResetPassword item that was used from the DB === UniqueCode
            List<ResetPassword> ResetPasswordList = (from r in db.ResetPasswords
                                                     where r.Email == Email
                                                     && r.ExpireDate_Local < DateTime.Today
                                                     select r).ToList<ResetPassword>();

            foreach (ResetPassword rpToDelete in ResetPasswordList)
            {
                LogModel logModel = _LogService.PostAddLogForObj("ResetPasswords", rpToDelete.ResetPasswordID, LogCommandEnum.Delete, rpToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return logModel.Error;

                db.ResetPasswords.Remove(rpToDelete);
            }

            using (TransactionScope ts = new TransactionScope())
            {
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return retStr;

                ts.Complete();
            }
            return "";
        }
        public ResetPasswordModel ReturnError(string Error)
        {
            return new ResetPasswordModel() { Error = Error };
        }

        // Post
        public ResetPasswordModel PostAddResetPasswordDB(ResetPasswordModel resetPasswordModel)
        {
            ResetPassword resetPasswordNew = new ResetPassword();

            string retStr = ResetPasswordModelOK(resetPasswordModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = null;

            retStr = FillResetPassword(resetPasswordNew, resetPasswordModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.ResetPasswords.Add(resetPasswordNew);
                retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ResetPasswords", resetPasswordNew.ResetPasswordID, LogCommandEnum.Add, resetPasswordNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetResetPasswordModelWithResetPasswordIDDB(resetPasswordNew.ResetPasswordID);
        }
        public ResetPasswordModel PostDeleteResetPasswordDB(int ResetPasswordID)
        {
            ResetPassword resetPasswordDelete = GetResetPasswordWithResetPasswordIDDB(ResetPasswordID);
            if (resetPasswordDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ResetPassword));

            using (TransactionScope ts = new TransactionScope())
            {
                db.ResetPasswords.Remove(resetPasswordDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("ResetPasswords", resetPasswordDelete.ResetPasswordID, LogCommandEnum.Delete, resetPasswordDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        #endregion Function public

        #region Function private
        #endregion Functions private
    }
}

