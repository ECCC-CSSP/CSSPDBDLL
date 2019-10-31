using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using CSSPDBDLL.Services.Resources;
using System.Text.RegularExpressions;
using System.Net.Mail;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPModelsDLL.Services;
using CSSPDBDLL;

namespace CSSPDBDLL.Services
{

    public class BaseService : IDisposable
    {
        #region Variables public
        public List<LanguageEnum> LanguageListAllowable = new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr };
        public CSSPDBEntities db;
        public CoCoRaHSEntities CoCoRaHSdb;
        public LanguageEnum LanguageRequest;
        public IPrincipal User;
        public int TakeMax = 1000000;
        public string BasePath = @"E:\inetpub\wwwroot\csspwebtools\App_Data\";
        public double R = 6378137.0;
        public double d2r = Math.PI / 180;
        public double r2d = 180 / Math.PI;
        public string DBName = "CSSPDB";
        public Random random = new Random((int)(DateTime.Now.Ticks));
        public List<TVTypeNamesAndPath> tvTypeNamesAndPathList = new List<TVTypeNamesAndPath>();
        public List<PolSourceObsInfoChild> polSourceObsInfoChildList = new List<PolSourceObsInfoChild>();
        public bool CanSendEmail = true;
        public string FromEmail = "ec.pccsm-cssp.ec@canada.ca";
        public int TileSize = 256;
        public double OriginX, OriginY;
        public double PixelsPerLonDegree;
        public double PixelsPerLonRadian;

        #endregion Variables public

        #region Properties
        public BaseEnumService _BaseEnumService { get; set; } 
        public BaseModelService _BaseModelService { get; set; }
        #endregion Properties

        #region Constructors
        public BaseService(LanguageEnum LanguageRequest, IPrincipal User)
        {
            if (!(LanguageRequest == LanguageEnum.en || LanguageRequest == LanguageEnum.fr))
            {
                this.LanguageRequest = LanguageEnum.en;
            }
            else
            {
                if (LanguageListAllowable.Contains(LanguageRequest))
                {
                    this.LanguageRequest = LanguageRequest;
                }
                else
                {
                    this.LanguageRequest = LanguageEnum.en;
                }
            }
            _BaseEnumService = new BaseEnumService(LanguageRequest);
            _BaseModelService = new BaseModelService(LanguageRequest);

            this.User = User;
            db = new CSSPDBEntities();
            CoCoRaHSdb = new CoCoRaHSEntities();
            FillTVTypeNamesAndPathList();
            _BaseModelService.FillPolSourceObsInfoChild(polSourceObsInfoChildList);

            OriginX = TileSize / 2;
            OriginY = TileSize / 2;
            PixelsPerLonDegree = TileSize / 360.0;
            PixelsPerLonRadian = TileSize / (2 * Math.PI);

        }
        #endregion Constructors

        #region Functions public
        #region Functions Checks
        public virtual string CoCoRaHSDoAddChanges()
        {
            try
            {
                CoCoRaHSdb.SaveChanges();
            }
            catch (Exception ex)
            {
                return string.Format(ServiceRes.CouldNotAddError_, ex.Message);
            }
            return "";
        }
        public virtual string CoCoRaHSDoDeleteChanges()
        {
            try
            {
                CoCoRaHSdb.SaveChanges();
            }
            catch (Exception ex)
            {
                return string.Format(ServiceRes.CouldNotDeleteError_, ex.Message);
            }
            return "";
        }
        public virtual string CoCoRaHSDoUpdateChanges()
        {
            try
            {
                CoCoRaHSdb.SaveChanges();
            }
            catch (Exception ex)
            {
                return string.Format(ServiceRes.CouldNotUpdateError_, ex.Message);
            }
            return "";
        }
        public virtual string DoAddChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return string.Format(ServiceRes.CouldNotAddError_, ex.Message);
            }
            return "";
        }
        public virtual string DoDeleteChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return string.Format(ServiceRes.CouldNotDeleteError_, ex.Message);
            }
            return "";
        }
        public virtual string DoUpdateChanges()
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return string.Format(ServiceRes.CouldNotUpdateError_, ex.Message);
            }
            return "";
        }
        public virtual string EmailOK(string Email)
        {
            if (string.IsNullOrWhiteSpace(Email))
            {
                return string.Format(ServiceRes._IsRequired, ServiceRes.Email);
            }

            if (Email.Length > 255)
            {
                return string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, 255);
            }

            Regex regex = new Regex(@"^([\w\!\#$\%\&\'*\+\-\/\=\?\^`{\|\}\~]+\.)*[\w\!\#$\%\&\'‌​*\+\-\/\=\?\^`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[‌​a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$");
            if (!regex.IsMatch(Email))
            {
                return string.Format(ServiceRes._EmailNotWellFormed, Email);
            }

            return "";
        }
        public void FillTVTypeNamesAndPathList()
        {
            tvTypeNamesAndPathList.Clear();
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Root",
                Index = (int)TVTypeEnum.Root,
                TVPath = "p" + ((int)TVTypeEnum.Root).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Contact",
                Index = (int)TVTypeEnum.Contact,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Root").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Contact).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Country",
                Index = (int)TVTypeEnum.Country,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Root").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Country).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Province",
                Index = (int)TVTypeEnum.Province,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Country").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Province).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Address",
                Index = (int)TVTypeEnum.Address,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Root").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Address).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Email",
                Index = (int)TVTypeEnum.Email,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Root").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Email).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Tel",
                Index = (int)TVTypeEnum.Tel,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Root").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Tel).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Area",
                Index = (int)TVTypeEnum.Area,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Province").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Area).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Sector",
                Index = (int)TVTypeEnum.Sector,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Area").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Sector).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Subsector",
                Index = (int)TVTypeEnum.Subsector,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Sector").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Subsector).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Municipality",
                Index = (int)TVTypeEnum.Municipality,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Subsector").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Municipality).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "ClimateSite",
                Index = (int)TVTypeEnum.ClimateSite,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Province").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.ClimateSite).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "HydrometricSite",
                Index = (int)TVTypeEnum.HydrometricSite,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Province").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.HydrometricSite).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "TideSite",
                Index = (int)TVTypeEnum.TideSite,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Subsector").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.TideSite).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "MWQMSite",
                Index = (int)TVTypeEnum.MWQMSite,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Subsector").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.MWQMSite).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "PolSourceSite",
                Index = (int)TVTypeEnum.PolSourceSite,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Subsector").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.PolSourceSite).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "MikeScenario",
                Index = (int)TVTypeEnum.MikeScenario,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Municipality").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.MikeScenario).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "MikeSource",
                Index = (int)TVTypeEnum.MikeSource,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "MikeScenario").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.MikeSource).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "MikeBoundaryConditionMesh",
                Index = (int)TVTypeEnum.MikeBoundaryConditionMesh,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "MikeScenario").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.MikeBoundaryConditionMesh).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "MikeBoundaryConditionWebTide",
                Index = (int)TVTypeEnum.MikeBoundaryConditionWebTide,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "MikeScenario").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.MikeBoundaryConditionWebTide).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "Infrastructure",
                Index = (int)TVTypeEnum.Infrastructure,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Municipality").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.Infrastructure).ToString()
            });
            tvTypeNamesAndPathList.Add(new TVTypeNamesAndPath()
            {
                TVTypeName = "MWQMRun",
                Index = (int)TVTypeEnum.MWQMRun,
                TVPath = tvTypeNamesAndPathList.Where(c => c.TVTypeName == "Subsector").FirstOrDefault().TVPath + "p" + ((int)TVTypeEnum.MWQMRun).ToString()
            });
        }
        public virtual ContactModel GetContactLoggedInDB()
        {
            ContactModel contactModel = new ContactModel();

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
            {
                return new ContactModel() { Error = contactOK.Error };
            }

            contactModel = (from c in db.Contacts
                            from a in db.AspNetUsers
                            where c.Id == a.Id
                            && a.UserName == User.Identity.Name
                            select new ContactModel
                            {
                                Error = "",
                                ContactID = c.ContactID,
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
                return ReturnContactBaseError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.Email, User.Identity.Name));

            return contactModel;
        }
        public virtual ContactModel GetContactModelWithContactIDDB(int ContactID)
        {
            ContactModel contactModel = (from c in db.Contacts
                                         from a in db.AspNetUsers
                                         where c.Id == a.Id
                                         && c.ContactID == ContactID
                                         select new ContactModel
                                         {
                                             Error = "",
                                             ContactID = c.ContactID,
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

            if (contactModel == null) return ReturnContactBaseError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.ContactID, ContactID));

            return contactModel;
        }
        public virtual ContactModel GetContactModelWithContactTVItemIDDB(int ContactTVItemID)
        {
            ContactModel contactModel = (from c in db.Contacts
                                         from a in db.AspNetUsers
                                         from t in db.TVItems
                                         where c.Id == a.Id
                                         && c.ContactTVItemID == t.TVItemID
                                         && t.TVItemID == ContactTVItemID
                                         select new ContactModel
                                         {
                                             Error = "",
                                             ContactID = c.ContactID,
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
                return ReturnContactBaseError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Contact, ServiceRes.ContactTVItemID, ContactTVItemID));

            return contactModel;
        }
        public LastUpdateAndTVText GetLastUpdateAndDateDB(string Table, int ID, int Offset_min)
        {
            string Tables = "";
            if (Table == "Address")
            {
                Tables = Table + "es";
            }
            else
            {
                Tables = Table + "s";
            }
            string sql = "";
            if (Table == "TVItemLanguage")
            {
                sql = "SELECT TVItemLanguages_1.LastUpdateDate_UTC, TVItemLanguages.TVText"
                    + " FROM TVItems INNER JOIN"
                    + " TVItemLanguages ON TVItems.TVItemID = TVItemLanguages.TVItemID INNER JOIN"
                    + " TVItemLanguages AS TVItemLanguages_1 ON TVItems.TVItemID = TVItemLanguages_1.LastUpdateContactTVItemID"
                    + " WHERE     (TVItemLanguages.Language = " + ((int)LanguageRequest).ToString() + ")"
                    + " AND (TVItemLanguages_1.Language = " + ((int)LanguageRequest).ToString() + ")"
                    + " AND (TVItemLanguages_1.TVItemID = " + ID.ToString() + ")";
            }
            else
            {
                sql = "SELECT " + Tables + ".LastUpdateDate_UTC, TVItemLanguages.TVText"
                    + " FROM " + Tables + " INNER JOIN"
                    + " TVItems ON " + Tables + ".LastUpdateContactTVItemID = TVItems.TVItemID INNER JOIN"
                    + " TVItemLanguages ON TVItems.TVItemID = TVItemLanguages.TVItemID"
                    + " WHERE (" + Tables + "." + Table + "ID = " + ID.ToString()
                    + ") AND (TVItemLanguages.Language = " + ((int)LanguageRequest).ToString() + ")";
            }

            LastUpdateAndTVText lastUpdateAndTVText = db.Database.SqlQuery<LastUpdateAndTVText>(sql).FirstOrDefault<LastUpdateAndTVText>();

            lastUpdateAndTVText.LastUpdateDate_Local = lastUpdateAndTVText.LastUpdateDate_UTC.AddMinutes(Offset_min * (-1));

            return lastUpdateAndTVText;
        }
        public virtual TVAuthEnum GetTVAuthWithTVItemIDAndContactID(int ContactTVItemID, int TVItemID1, int? TVItemID2, int? TVItemID3, int? TVItemID4)
        {
            if (TVItemID1 == 0)
                return TVAuthEnum.Error;

            if (ContactTVItemID == 0)
                return TVAuthEnum.Error;

            TVItemService tvItemService = new TVItemService(LanguageRequest, User);
            TVTypeUserAuthorizationService tvTypeUserAuthorizationService = new TVTypeUserAuthorizationService(LanguageRequest, User);
            TVItemUserAuthorizationService tvItemUserAuthorizationService = new TVItemUserAuthorizationService(LanguageRequest, User);

            TVItemModel tvItemModel = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID1);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return TVAuthEnum.Error;

            List<TVTypeUserAuthorizationModel> tvTypeUserAuthorizationModelList = tvTypeUserAuthorizationService.GetTVTypeUserAuthorizationModelListWithContactTVItemIDDB(ContactTVItemID);
            if (tvTypeUserAuthorizationModelList.Count == 0)
                return TVAuthEnum.Error;

            if (tvTypeUserAuthorizationModelList[0].TVType != TVTypeEnum.Root)
                return TVAuthEnum.Error;

            List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = tvItemUserAuthorizationService.GetTVItemUserAuthorizationModelListWithContactTVItemIDDB(ContactTVItemID);

            if (tvItemModel.TVType == TVTypeEnum.File)
            {
                tvItemModel = tvItemService.GetTVItemModelWithTVItemIDDB(tvItemModel.ParentID);
            }

            int TVLevelCurrent = tvItemModel.TVLevel;
            string TVPathType = tvItemService.tvTypeNamesAndPathList.Where(c => c.Index == (int)tvItemModel.TVType).FirstOrDefault().TVPath;

            TVAuthEnum tvAuth = TVAuthEnum.Error;

            foreach (TVTypeUserAuthorizationModel tvTypeUserAuthorizationModel in tvTypeUserAuthorizationModelList)
            {
                if (TVPathType.Length >= tvTypeUserAuthorizationModel.TVPath.Length)
                {
                    if (TVPathType.StartsWith(tvTypeUserAuthorizationModel.TVPath))
                    {
                        tvAuth = tvTypeUserAuthorizationModel.TVAuth;
                    }
                }
            }

            foreach (TVItemUserAuthorizationModel tvItemUserAuthorizationModel in tvItemUserAuthorizationModelList)
            {
                if (tvItemModel.TVPath.Length >= tvItemUserAuthorizationModel.TVPath1.Length)
                {
                    if (tvItemModel.TVPath.StartsWith(tvItemUserAuthorizationModel.TVPath1))
                    {
                        tvAuth = tvItemUserAuthorizationModel.TVAuth;
                    }
                }
            }
            return tvAuth;
        }
        public virtual TVAuthEnum GetTVAuthWithTVItemIDAndLoggedInUser(int TVItemID1, int? TVItemID2, int? TVItemID3, int? TVItemID4)
        {
            if (TVItemID1 == 0)
                return TVAuthEnum.Error;

            ContactModel contactModel = GetContactLoggedInDB();

            TVAuthEnum tvAuth = GetTVAuthWithTVItemIDAndContactID(contactModel.ContactTVItemID, TVItemID1, TVItemID2, TVItemID3, TVItemID4);

            return tvAuth;
        }
        public virtual bool IsAdministratorDB(string LoginEmail)
        {
            string retStr = EmailOK(LoginEmail);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return false;
            }

            bool retBool = (from ua in db.TVTypeUserAuthorizations
                            from u in db.Contacts
                            from a in db.AspNetUsers
                            where a.Id == u.Id
                            && ua.TVType == (int)TVTypeEnum.Root
                            && ua.ContactTVItemID == u.ContactTVItemID
                            && a.Email == LoginEmail
                            && ua.TVAuth == (int)TVAuthEnum.Admin
                            select ua).Any();

            return retBool;
        }
        public virtual ContactOK IsContactOK()
        {
            if (User == null || User.Identity.IsAuthenticated == false)
                return new ContactOK() { ContactID = 0, ContactTVItemID = 0, Error = ServiceRes.NeedToBeLoggedIn };

            Contact contact = (from c in db.Contacts
                               from a in db.AspNetUsers
                               where c.Id == a.Id
                               && a.Email == User.Identity.Name
                               select c).FirstOrDefault<Contact>();

            if (contact == null)
                return new ContactOK() { ContactID = 0, ContactTVItemID = 0, Error = ServiceRes.NeedToBeLoggedIn };

            if (!contact.EmailValidated)
                return new ContactOK() { ContactID = 0, ContactTVItemID = 0, Error = ServiceRes.EmailRequiresValidation };

            return new ContactOK() { ContactID = contact.ContactID, ContactTVItemID = contact.ContactTVItemID, Error = "" };
        }
        public virtual bool IsSamplingPlannerDB(string LoginEmail)
        {
            string retStr = EmailOK(LoginEmail);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return false;
            }

            Contact contact = (from u in db.Contacts
                               from a in db.AspNetUsers
                               where a.Id == u.Id
                               && a.Email == LoginEmail
                               select u).FirstOrDefault();

            if (contact == null)
            {
                return false;
            }
            if (contact.SamplingPlanner_ProvincesTVItemID == null)
            {
                return false;
            }
            if (contact.SamplingPlanner_ProvincesTVItemID.Length == 0)
            {
                return false;
            }

            return true;
        }
        public virtual bool IsStartDateBiggerThanEndDate(DateTime StartDate, DateTime? EndDate)
        {
            if (StartDate > EndDate)
            {
                return true;
            }
            return false;
        }
        public ContactModel ReturnContactBaseError(string Error)
        {
            return new ContactModel() { Error = Error };
        }
        public virtual string SendEmail(MailMessage mail)
        {
            SmtpClient myClient = new SmtpClient();

            myClient.Host = "smtp.email-courriel.canada.ca";
            myClient.Port = 587;
            myClient.Credentials = new System.Net.NetworkCredential("ec.pccsm-cssp.ec@canada.ca", "H^9h6g@Gy$N57k=Dr@J7=F2y6p6b!T");
            myClient.EnableSsl = true;

            try
            {
                if (CanSendEmail)
                    myClient.Send(mail);
            }
            catch (Exception ex)
            {
                return string.Format(ServiceRes.EmailWasNotSent_, (ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : ""));
            }

            return "";
        }
        #endregion Functions Checks

        #region Functions field check
        public virtual string FieldCheckIfNotNullNotZeroInt(int? Value, string Res)
        {
            if (Value != null)
            {
                if (Value == 0)
                {
                    return string.Format(ServiceRes._IsRequired, Res);
                }
            }

            return "";
        }
        public virtual string FieldCheckIfNotNullWithinRangeDouble(double? Value, string Res, double Min, double Max)
        {
            if (Value != null)
            {
                if (Value < Min || Value > Max)
                {
                    return string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max);
                }
            }

            return "";
        }
        public virtual string FieldCheckIfNotNullWithinRangeInt(int? Value, string Res, int Min, int Max)
        {
            if (Value != null)
            {
                if (Value < Min || Value > Max)
                {
                    return string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max);
                }
            }

            return "";
        }
        public virtual string FieldCheckIfNotNullMaxLengthString(string Value, string Res, int Max)
        {
            if (Value != null)
            {
                if (Value.Length > Max)
                {
                    return string.Format(ServiceRes._MaxLengthIs_, Res, Max);
                }
            }


            return "";
        }
        public virtual string FieldCheckNotEmptyAndMaxLengthString(string Value, string Res, int Max)
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                return string.Format(ServiceRes._IsRequired, Res);
            }

            if (Value.Length > Max)
            {
                return string.Format(ServiceRes._MaxLengthIs_, Res, Max);
            }
            return "";
        }
        public virtual string FieldCheckNotNullBool(bool? Value, string Res)
        {
            if (Value == null)
            {
                return string.Format(ServiceRes._IsRequired, Res);
            }

            return "";
        }
        public virtual string FieldCheckNotNullDateTime(DateTime? Value, string Res)
        {
            if (Value == null)
            {
                return string.Format(ServiceRes._IsRequired, Res);
            }

            return "";
        }
        public virtual string FieldCheckNotNullAndWithinRangeDouble(double? Value, string Res, double Min, double Max)
        {
            if (Value == null)
            {
                return string.Format(ServiceRes._IsRequired, Res);
            }

            if (Value < Min || Value > Max)
            {
                return string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max);
            }

            return "";
        }
        public virtual string FieldCheckNotNullAndWithinRangeInt(int? Value, string Res, int Min, int Max)
        {
            if (Value == null)
            {
                return string.Format(ServiceRes._IsRequired, Res);
            }

            if (Value < Min || Value > Max)
            {
                return string.Format(ServiceRes._RangeIsBetween_And_, Res, Min, Max);
            }

            return "";
        }
        public virtual string FieldCheckNotNullAndMinMaxLengthString(string Value, string Res, int Min, int Max)
        {
            if (Value == null)
            {
                return string.Format(ServiceRes._IsRequired, Res);
            }

            if (Value.Length < Min)
            {
                return string.Format(ServiceRes._MinLengthIs_, Res, Min);
            }

            if (Value.Length > Max)
            {
                return string.Format(ServiceRes._MaxLengthIs_, Res, Max);
            }

            return "";
        }
        public virtual string FieldCheckNotZeroDouble(Double Value, string Res)
        {
            if (Value == 0D)
            {
                return string.Format(ServiceRes._IsRequired, Res);
            }

            return "";
        }
        public virtual string FieldCheckNotZeroInt(int? Value, string Res)
        {
            if (Value == 0)
            {
                return string.Format(ServiceRes._IsRequired, Res);
            }

            return "";
        }
        #endregion Functions field check
          #endregion Functions public

        #region Functions private
        #endregion Functions private

        public void Dispose()
    {
        db.Dispose();
    }
}
}
