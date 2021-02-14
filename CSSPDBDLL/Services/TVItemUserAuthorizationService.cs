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

namespace CSSPDBDLL.Services
{
    public class TVItemUserAuthorizationService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
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
        public string TVItemUserAuthorizationModelOK(TVItemUserAuthorizationModel tvItemUserAuthorizationModel)
        {
            string retStr = FieldCheckNotZeroInt(tvItemUserAuthorizationModel.ContactTVItemID, ServiceRes.ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(tvItemUserAuthorizationModel.TVItemID1, ServiceRes.TVItemID1);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(tvItemUserAuthorizationModel.TVItemID2, ServiceRes.TVItemID2);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(tvItemUserAuthorizationModel.TVItemID3, ServiceRes.TVItemID3);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(tvItemUserAuthorizationModel.TVItemID4, ServiceRes.TVItemID4);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVAuthOK(tvItemUserAuthorizationModel.TVAuth);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(tvItemUserAuthorizationModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTVItemUserAuthorization(TVItemUserAuthorization tvItemUserAuthorization, TVItemUserAuthorizationModel tvItemUserAuthorizationModel, ContactOK contactOK)
        {
            tvItemUserAuthorization.DBCommand = (int)tvItemUserAuthorizationModel.DBCommand;
            tvItemUserAuthorization.ContactTVItemID = tvItemUserAuthorizationModel.ContactTVItemID;
            tvItemUserAuthorization.TVItemID1 = tvItemUserAuthorizationModel.TVItemID1;
            tvItemUserAuthorization.TVItemID2 = tvItemUserAuthorizationModel.TVItemID2;
            tvItemUserAuthorization.TVItemID3 = tvItemUserAuthorizationModel.TVItemID3;
            tvItemUserAuthorization.TVItemID4 = tvItemUserAuthorizationModel.TVItemID4;
            tvItemUserAuthorization.TVAuth = (int)tvItemUserAuthorizationModel.TVAuth;
            tvItemUserAuthorization.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tvItemUserAuthorization.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tvItemUserAuthorization.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public List<TVItemTVAuth> GetTVItemTVAuthWithContactTVItemIDDB(int ContactTVItemID)
        {
            List<TVItemTVAuth> tvItemTVAuthList = (from c in db.TVItemUserAuthorizations
                                                   let tvItemID1TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID1 select cl.TVText).FirstOrDefault<string>()
                                                   let tvTypeText = (from cl in db.TVItems where cl.TVItemID == c.TVItemID1 select ((TVTypeEnum)cl.TVType).ToString()).FirstOrDefault<string>()
                                                   where c.ContactTVItemID == ContactTVItemID
                                                   orderby tvItemID1TVText
                                                   select new TVItemTVAuth
                                                   {
                                                       Error = "",
                                                       TVItemUserAuthID = c.TVItemUserAuthorizationID,
                                                       TVItemID1 = c.TVItemID1,
                                                       TVText = tvItemID1TVText,
                                                       TVTypeStr = tvTypeText,
                                                       TVAuth = (TVAuthEnum)c.TVAuth,
                                                   }).ToList<TVItemTVAuth>();

            return tvItemTVAuthList;
        }
        public int GetTVItemUserAuthorizationModelCountDB()
        {
            int TVItemUserAuthorizationModelCount = (from c in db.TVItemUserAuthorizations
                                                     select c).Count();

            return TVItemUserAuthorizationModelCount;
        }
        public List<TVItemUserAuthorization> GetTVItemUserAuthorizationWithContactTVItemIDListDB(int ContactTVItemID)
        {
            List<TVItemUserAuthorization> tvItemUserAuthorizationList = (from c in db.TVItemUserAuthorizations
                                                                         where c.ContactTVItemID == ContactTVItemID
                                                                         select c).ToList();

            return tvItemUserAuthorizationList;
        }
        public List<TVItemUserAuthorizationModel> GetTVItemUserAuthorizationModelListDB()
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = (from c in db.TVItemUserAuthorizations
                                                                                   let tvItemID1TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID1 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID2TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID3TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID3 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID4TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID4 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvPath1 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID1 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath2 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID2 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath3 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID3 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath4 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID4 select ct.TVPath).FirstOrDefault<string>()
                                                                                   select new TVItemUserAuthorizationModel
                                                                                   {
                                                                                       Error = "",
                                                                                       TVItemUserAuthorizationID = c.TVItemUserAuthorizationID,
                                                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                       ContactTVItemID = c.ContactTVItemID,
                                                                                       TVItemID1 = c.TVItemID1,
                                                                                       TVText1 = tvItemID1TVText,
                                                                                       TVPath1 = tvPath1,
                                                                                       TVItemID2 = c.TVItemID2,
                                                                                       TVText2 = tvItemID2TVText,
                                                                                       TVPath2 = tvPath2,
                                                                                       TVItemID3 = c.TVItemID3,
                                                                                       TVText3 = tvItemID3TVText,
                                                                                       TVPath3 = tvPath3,
                                                                                       TVItemID4 = c.TVItemID4,
                                                                                       TVText4 = tvItemID4TVText,
                                                                                       TVPath4 = tvPath4,
                                                                                       TVAuth = (TVAuthEnum)c.TVAuth,
                                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                   }).ToList<TVItemUserAuthorizationModel>();

            foreach (TVItemUserAuthorizationModel tvItemUserAuthorizationModel in tvItemUserAuthorizationModelList)
            {
                tvItemUserAuthorizationModel.TVLevel1 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath1);

                if (tvItemUserAuthorizationModel.TVPath2 != null)
                    tvItemUserAuthorizationModel.TVLevel2 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath2);

                if (tvItemUserAuthorizationModel.TVPath3 != null)
                    tvItemUserAuthorizationModel.TVLevel3 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath3);

                if (tvItemUserAuthorizationModel.TVPath4 != null)
                    tvItemUserAuthorizationModel.TVLevel4 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath4);
            }

            return tvItemUserAuthorizationModelList.OrderBy(c => c.TVLevel1).ThenBy(c => c.TVLevel2).ToList<TVItemUserAuthorizationModel>();
        }
        public List<TVItemUserAuthorizationModel> GetTVItemUserAuthorizationModelListWithContactTVItemIDDB(int ContactTVItemID)
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = (from c in db.TVItemUserAuthorizations
                                                                                   let tvItemID1TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID1 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID2TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID3TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID3 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID4TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID4 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvPath1 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID1 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath2 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID2 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath3 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID3 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath4 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID4 select ct.TVPath).FirstOrDefault<string>()
                                                                                   where c.ContactTVItemID == ContactTVItemID
                                                                                   select new TVItemUserAuthorizationModel
                                                                                   {
                                                                                       Error = "",
                                                                                       TVItemUserAuthorizationID = c.TVItemUserAuthorizationID,
                                                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                       ContactTVItemID = c.ContactTVItemID,
                                                                                       TVItemID1 = c.TVItemID1,
                                                                                       TVText1 = tvItemID1TVText,
                                                                                       TVPath1 = tvPath1,
                                                                                       TVItemID2 = c.TVItemID2,
                                                                                       TVText2 = tvItemID2TVText,
                                                                                       TVPath2 = tvPath2,
                                                                                       TVItemID3 = c.TVItemID3,
                                                                                       TVText3 = tvItemID3TVText,
                                                                                       TVPath3 = tvPath3,
                                                                                       TVItemID4 = c.TVItemID4,
                                                                                       TVText4 = tvItemID4TVText,
                                                                                       TVPath4 = tvPath4,
                                                                                       TVAuth = (TVAuthEnum)c.TVAuth,
                                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                   }).ToList<TVItemUserAuthorizationModel>();

            foreach (TVItemUserAuthorizationModel tvItemUserAuthorizationModel in tvItemUserAuthorizationModelList)
            {
                tvItemUserAuthorizationModel.TVLevel1 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath1);

                if (tvItemUserAuthorizationModel.TVPath2 != null)
                    tvItemUserAuthorizationModel.TVLevel2 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath2);

                if (tvItemUserAuthorizationModel.TVPath3 != null)
                    tvItemUserAuthorizationModel.TVLevel3 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath3);

                if (tvItemUserAuthorizationModel.TVPath4 != null)
                    tvItemUserAuthorizationModel.TVLevel4 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath4);
            }
            return tvItemUserAuthorizationModelList.OrderBy(c => c.TVLevel1).ThenBy(c => c.TVLevel2).ToList<TVItemUserAuthorizationModel>();
        }
        public List<TVItemUserAuthorizationModel> GetTVItemUserAuthorizationModelListWithTVItemID1DB(int TVItemID1)
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            List<TVItemUserAuthorizationModel> tvItemUserAuthorizationModelList = (from c in db.TVItemUserAuthorizations
                                                                                   let tvItemID1TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID1 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID2TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID3TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID3 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvItemID4TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID4 select cl.TVText).FirstOrDefault<string>()
                                                                                   let tvPath1 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID1 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath2 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID2 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath3 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID3 select ct.TVPath).FirstOrDefault<string>()
                                                                                   let tvPath4 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID4 select ct.TVPath).FirstOrDefault<string>()
                                                                                   where c.TVItemID1 == TVItemID1
                                                                                   select new TVItemUserAuthorizationModel
                                                                                   {
                                                                                       Error = "",
                                                                                       TVItemUserAuthorizationID = c.TVItemUserAuthorizationID,
                                                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                                                       ContactTVItemID = c.ContactTVItemID,
                                                                                       TVItemID1 = c.TVItemID1,
                                                                                       TVText1 = tvItemID1TVText,
                                                                                       TVPath1 = tvPath1,
                                                                                       TVItemID2 = c.TVItemID2,
                                                                                       TVText2 = tvItemID2TVText,
                                                                                       TVPath2 = tvPath2,
                                                                                       TVItemID3 = c.TVItemID3,
                                                                                       TVText3 = tvItemID3TVText,
                                                                                       TVPath3 = tvPath3,
                                                                                       TVItemID4 = c.TVItemID4,
                                                                                       TVText4 = tvItemID4TVText,
                                                                                       TVPath4 = tvPath4,
                                                                                       TVAuth = (TVAuthEnum)c.TVAuth,
                                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                   }).ToList<TVItemUserAuthorizationModel>();

            foreach (TVItemUserAuthorizationModel tvItemUserAuthorizationModel in tvItemUserAuthorizationModelList)
            {
                tvItemUserAuthorizationModel.TVLevel1 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath1);

                if (tvItemUserAuthorizationModel.TVPath2 != null)
                    tvItemUserAuthorizationModel.TVLevel2 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath2);

                if (tvItemUserAuthorizationModel.TVPath3 != null)
                    tvItemUserAuthorizationModel.TVLevel3 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath3);

                if (tvItemUserAuthorizationModel.TVPath4 != null)
                    tvItemUserAuthorizationModel.TVLevel4 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath4);
            }
            return tvItemUserAuthorizationModelList.OrderBy(c => c.TVLevel1).ThenBy(c => c.TVLevel2).ToList<TVItemUserAuthorizationModel>();
        }
        public TVItemUserAuthorizationModel GetTVItemUserAuthorizationModelWithTVItemUserAuthorizationIDDB(int TVItemUserAuthorizationID)
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            TVItemUserAuthorizationModel tvItemUserAuthorizationModel = (from c in db.TVItemUserAuthorizations
                                                                         let tvItemID1TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID1 select cl.TVText).FirstOrDefault<string>()
                                                                         let tvItemID2TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                                                         let tvItemID3TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID3 select cl.TVText).FirstOrDefault<string>()
                                                                         let tvItemID4TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID4 select cl.TVText).FirstOrDefault<string>()
                                                                         let tvPath1 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID1 select ct.TVPath).FirstOrDefault<string>()
                                                                         let tvPath2 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID2 select ct.TVPath).FirstOrDefault<string>()
                                                                         let tvPath3 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID3 select ct.TVPath).FirstOrDefault<string>()
                                                                         let tvPath4 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID4 select ct.TVPath).FirstOrDefault<string>()
                                                                         where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                                                         select new TVItemUserAuthorizationModel
                                                                         {
                                                                             Error = "",
                                                                             TVItemUserAuthorizationID = c.TVItemUserAuthorizationID,
                                                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                                                             ContactTVItemID = c.ContactTVItemID,
                                                                             TVItemID1 = c.TVItemID1,
                                                                             TVText1 = tvItemID1TVText,
                                                                             TVPath1 = tvPath1,
                                                                             TVItemID2 = c.TVItemID2,
                                                                             TVText2 = tvItemID2TVText,
                                                                             TVPath2 = tvPath2,
                                                                             TVItemID3 = c.TVItemID3,
                                                                             TVText3 = tvItemID3TVText,
                                                                             TVPath3 = tvPath3,
                                                                             TVItemID4 = c.TVItemID4,
                                                                             TVText4 = tvItemID4TVText,
                                                                             TVPath4 = tvPath4,
                                                                             TVAuth = (TVAuthEnum)c.TVAuth,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<TVItemUserAuthorizationModel>();


            if (tvItemUserAuthorizationModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemUserAuthorization, ServiceRes.TVItemUserAuthorizationID, TVItemUserAuthorizationID));


            tvItemUserAuthorizationModel.TVLevel1 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath1);

            if (tvItemUserAuthorizationModel.TVPath2 != null)
                tvItemUserAuthorizationModel.TVLevel2 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath2);

            if (tvItemUserAuthorizationModel.TVPath3 != null)
                tvItemUserAuthorizationModel.TVLevel3 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath3);

            if (tvItemUserAuthorizationModel.TVPath4 != null)
                tvItemUserAuthorizationModel.TVLevel4 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath4);

            return tvItemUserAuthorizationModel;
        }
        public TVItemUserAuthorizationModel GetTVItemUserAuthorizationModelWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB(int ContactTVItemID, int TVItemID1, int? TVItemID2, int? TVItemID3, int? TVItemID4)
        {
            TVItemService tvItemService = new TVItemService(this.LanguageRequest, this.User);

            TVItemUserAuthorizationModel tvItemUserAuthorizationModel = (from c in db.TVItemUserAuthorizations
                                                                         let tvItemID1TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID1 select cl.TVText).FirstOrDefault<string>()
                                                                         let tvItemID2TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID2 select cl.TVText).FirstOrDefault<string>()
                                                                         let tvItemID3TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID3 select cl.TVText).FirstOrDefault<string>()
                                                                         let tvItemID4TVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVItemID4 select cl.TVText).FirstOrDefault<string>()
                                                                         let tvPath1 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID1 select ct.TVPath).FirstOrDefault<string>()
                                                                         let tvPath2 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID2 select ct.TVPath).FirstOrDefault<string>()
                                                                         let tvPath3 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID3 select ct.TVPath).FirstOrDefault<string>()
                                                                         let tvPath4 = (from ct in db.TVItems where ct.TVItemID == c.TVItemID4 select ct.TVPath).FirstOrDefault<string>()
                                                                         where c.ContactTVItemID == ContactTVItemID
                                                                         && c.TVItemID1 == TVItemID1
                                                                         && c.TVItemID2 == TVItemID2
                                                                         && c.TVItemID3 == TVItemID3
                                                                         && c.TVItemID4 == TVItemID4
                                                                         select new TVItemUserAuthorizationModel
                                                                         {
                                                                             Error = "",
                                                                             TVItemUserAuthorizationID = c.TVItemUserAuthorizationID,
                                                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                                                             ContactTVItemID = c.ContactTVItemID,
                                                                             TVItemID1 = c.TVItemID1,
                                                                             TVText1 = tvItemID1TVText,
                                                                             TVPath1 = tvPath1,
                                                                             TVItemID2 = c.TVItemID2,
                                                                             TVText2 = tvItemID2TVText,
                                                                             TVPath2 = tvPath2,
                                                                             TVItemID3 = c.TVItemID3,
                                                                             TVText3 = tvItemID3TVText,
                                                                             TVPath3 = tvPath3,
                                                                             TVItemID4 = c.TVItemID4,
                                                                             TVText4 = tvItemID4TVText,
                                                                             TVPath4 = tvPath4,
                                                                             TVAuth = (TVAuthEnum)c.TVAuth,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<TVItemUserAuthorizationModel>();

            if (tvItemUserAuthorizationModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemUserAuthorization, ServiceRes.ContactTVItemID
                    + "," + ServiceRes.TVItemID1 + ","
                    + ServiceRes.TVItemID2 ?? "" + ","
                    + ServiceRes.TVItemID3 ?? "" + ","
                    + ServiceRes.TVItemID4 ?? "",
                    ContactTVItemID.ToString() + ","
                    + TVItemID1.ToString() + ","
                    + TVItemID2 ?? "" + ","
                    + TVItemID3 ?? "" + ","
                    + TVItemID4 ?? ""
                    ));

            tvItemUserAuthorizationModel.TVLevel1 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath1);

            if (tvItemUserAuthorizationModel.TVPath2 != null)
                tvItemUserAuthorizationModel.TVLevel2 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath2);

            if (tvItemUserAuthorizationModel.TVPath3 != null)
                tvItemUserAuthorizationModel.TVLevel3 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath3);

            if (tvItemUserAuthorizationModel.TVPath4 != null)
                tvItemUserAuthorizationModel.TVLevel4 = tvItemService.GetTVLevel(tvItemUserAuthorizationModel.TVPath4);

            return tvItemUserAuthorizationModel;
        }
        public TVItemUserAuthorization GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDB(int TVItemUserAuthorizationID)
        {
            TVItemUserAuthorization TVItemUserAuthorization = (from c in db.TVItemUserAuthorizations
                                                               where c.TVItemUserAuthorizationID == TVItemUserAuthorizationID
                                                               select c).FirstOrDefault<TVItemUserAuthorization>();
            return TVItemUserAuthorization;
        }
        public TVItemUserAuthorization GetTVItemUserAuthorizationWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB(int ContactTVItemID, int TVItemID1, int? TVItemID2, int? TVItemID3, int? TVItemID4)
        {
            TVItemUserAuthorization TVItemUserAuthorization = (from c in db.TVItemUserAuthorizations
                                                               where c.ContactTVItemID == ContactTVItemID
                                                               && c.TVItemID1 == TVItemID1
                                                               && c.TVItemID2 == TVItemID2
                                                               && c.TVItemID3 == TVItemID3
                                                               && c.TVItemID4 == TVItemID4
                                                               select c).FirstOrDefault<TVItemUserAuthorization>();
            return TVItemUserAuthorization;
        }
        // Helper
        public TVItemUserAuthorizationModel ReturnError(string Error)
        {
            return new TVItemUserAuthorizationModel() { Error = Error };
        }

        // Post
        public TVItemUserAuthorizationModel PostAddTVItemUserAuthorizationDB(TVItemUserAuthorizationModel tvItemUserAuthorizationModel)
        {
            string retStr = TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            bool IsAdmin = IsAdministratorDB(User.Identity.Name);
            if (!IsAdmin)
                return ReturnError(ServiceRes.OnlyAdministratorsCanManageUsers);

            if (contactOK.ContactTVItemID == tvItemUserAuthorizationModel.ContactTVItemID)
                return ReturnError(ServiceRes.CantSetOwnAuthorization);

            TVItemUserAuthorization tvItemUserAuthorizationExist = GetTVItemUserAuthorizationWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB(tvItemUserAuthorizationModel.ContactTVItemID, tvItemUserAuthorizationModel.TVItemID1, tvItemUserAuthorizationModel.TVItemID2, tvItemUserAuthorizationModel.TVItemID3, tvItemUserAuthorizationModel.TVItemID4);
            if (tvItemUserAuthorizationExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemUserAuthorization));

            TVItemUserAuthorization tvItemUserAuthorizationNew = new TVItemUserAuthorization();
            retStr = FillTVItemUserAuthorization(tvItemUserAuthorizationNew, tvItemUserAuthorizationModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemUserAuthorizations.Add(tvItemUserAuthorizationNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemUserAuthorizations", tvItemUserAuthorizationNew.TVItemUserAuthorizationID, LogCommandEnum.Add, tvItemUserAuthorizationNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTVItemUserAuthorizationModelWithTVItemUserAuthorizationIDDB(tvItemUserAuthorizationNew.TVItemUserAuthorizationID);
        }
        public TVItemUserAuthorizationModel PostDeleteTVItemUserAuthorizationDB(int TVItemUserAuthorizationID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);
            bool IsAdmin = IsAdministratorDB(User.Identity.Name);
            if (!IsAdmin)
                return ReturnError(ServiceRes.OnlyAdministratorsCanManageUsers);

            TVItemUserAuthorization tvItemUserAuthorizationToDelete = GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDB(TVItemUserAuthorizationID);
            if (tvItemUserAuthorizationToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemUserAuthorization));

            if (contactOK.ContactTVItemID == tvItemUserAuthorizationToDelete.ContactTVItemID)
                return ReturnError(ServiceRes.CantSetOwnAuthorization);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemUserAuthorizations.Remove(tvItemUserAuthorizationToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemUserAuthorizations", tvItemUserAuthorizationToDelete.TVItemUserAuthorizationID, LogCommandEnum.Delete, tvItemUserAuthorizationToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVItemUserAuthorizationModel PostSetTVItemUserAuthorizationDB(TVItemUserAuthorizationModel tvItemUserAuthorizationModel)
        {
            TVItemUserAuthorization tvItemUserAuthorizationToUpdate = GetTVItemUserAuthorizationWithContactTVItemIDTVItemID1TVItemID2TVItemID3TVItemID4DB(tvItemUserAuthorizationModel.ContactTVItemID, tvItemUserAuthorizationModel.TVItemID1, null, null, null);
            if (tvItemUserAuthorizationToUpdate == null)
            {
                tvItemUserAuthorizationModel.DBCommand = DBCommandEnum.Original;

                return PostAddTVItemUserAuthorizationDB(tvItemUserAuthorizationModel);
            }
            else
            {
                return PostUpdateTVItemUserAuthorizationDB(tvItemUserAuthorizationModel);
            }
        }
        public TVItemUserAuthorizationModel PostUpdateTVItemUserAuthorizationDB(TVItemUserAuthorizationModel tvItemUserAuthorizationModel)
        {
            string retStr = TVItemUserAuthorizationModelOK(tvItemUserAuthorizationModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            bool IsAdmin = IsAdministratorDB(User.Identity.Name);
            if (!IsAdmin)
                return ReturnError(ServiceRes.OnlyAdministratorsCanManageUsers);

            TVItemUserAuthorization tvItemUserAuthorizationToUpdate = GetTVItemUserAuthorizationWithTVItemUserAuthorizationIDDB(tvItemUserAuthorizationModel.TVItemUserAuthorizationID);
            if (tvItemUserAuthorizationToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItemUserAuthorization));

            if (contactOK.ContactTVItemID == tvItemUserAuthorizationToUpdate.ContactTVItemID)
                return ReturnError(ServiceRes.CantSetOwnAuthorization);

            retStr = FillTVItemUserAuthorization(tvItemUserAuthorizationToUpdate, tvItemUserAuthorizationModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemUserAuthorizations", tvItemUserAuthorizationToUpdate.TVItemUserAuthorizationID, LogCommandEnum.Change, tvItemUserAuthorizationToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTVItemUserAuthorizationModelWithTVItemUserAuthorizationIDDB(tvItemUserAuthorizationToUpdate.TVItemUserAuthorizationID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
