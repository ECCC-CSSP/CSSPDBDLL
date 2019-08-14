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
using System.Web.Mvc;

namespace CSSPDBDLL.Services
{
    public class RainExceedanceClimateSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string RainExceedanceClimateSiteModelOK(RainExceedanceClimateSiteModel rainExceedanceClimateSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(rainExceedanceClimateSiteModel.RainExceedanceID, ServiceRes.RainExceedanceID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(rainExceedanceClimateSiteModel.ClimateSiteID, ServiceRes.ClimateSiteID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillRainExceedanceClimateSite(RainExceedanceClimateSite rainExceedanceClimateSiteNew, RainExceedanceClimateSiteModel rainExceedanceClimateSiteModel, ContactOK contactOK)
        {
            rainExceedanceClimateSiteNew.RainExceedanceID = rainExceedanceClimateSiteModel.RainExceedanceID;
            rainExceedanceClimateSiteNew.ClimateSiteID = rainExceedanceClimateSiteModel.ClimateSiteID;
            rainExceedanceClimateSiteNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                rainExceedanceClimateSiteNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                rainExceedanceClimateSiteNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetRainExceedanceClimateSiteModelCountDB()
        {
            int RainExceedanceClimateSiteModelCount = (from c in db.RainExceedanceClimateSites
                                                       select c).Count();

            return RainExceedanceClimateSiteModelCount;
        }
        public List<RainExceedanceClimateSiteModel> GetRainExceedanceClimateSiteModelListWithRainExceedanceIDDB(int RainExceedanceID)
        {
            List<RainExceedanceClimateSiteModel> RainExceedanceClimateSiteModelList = (from c in db.RainExceedanceClimateSites
                                                                                       select new RainExceedanceClimateSiteModel
                                                                                       {
                                                                                           Error = "",
                                                                                           RainExceedanceClimateSiteID = c.RainExceedanceClimateSiteID,
                                                                                           RainExceedanceID = c.RainExceedanceID,
                                                                                           ClimateSiteID = c.ClimateSiteID,
                                                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                       }).ToList<RainExceedanceClimateSiteModel>();

            return RainExceedanceClimateSiteModelList;
        }
        public RainExceedanceClimateSiteModel GetRainExceedanceClimateSiteModelWithRainExceedanceClimateSiteIDDB(int RainExceedanceClimateSiteID)
        {
            RainExceedanceClimateSiteModel rainExceedanceClimateSiteModel = (from c in db.RainExceedanceClimateSites
                                                                             where c.RainExceedanceClimateSiteID == RainExceedanceClimateSiteID
                                                                             select new RainExceedanceClimateSiteModel
                                                                             {
                                                                                 Error = "",
                                                                                 RainExceedanceClimateSiteID = c.RainExceedanceClimateSiteID,
                                                                                 RainExceedanceID = c.RainExceedanceID,
                                                                                 ClimateSiteID = c.ClimateSiteID,
                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                             }).FirstOrDefault<RainExceedanceClimateSiteModel>();

            if (rainExceedanceClimateSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.RainExceedanceClimateSite, ServiceRes.RainExceedanceClimateSiteID, RainExceedanceClimateSiteID));

            return rainExceedanceClimateSiteModel;
        }
        public RainExceedanceClimateSite GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteIDDB(int RainExceedanceClimateSiteID)
        {
            RainExceedanceClimateSite RainExceedanceClimateSite = (from c in db.RainExceedanceClimateSites
                                                                   where c.RainExceedanceClimateSiteID == RainExceedanceClimateSiteID
                                                                   select c).FirstOrDefault<RainExceedanceClimateSite>();

            return RainExceedanceClimateSite;
        }
        public RainExceedanceClimateSite GetRainExceedanceClimateSiteExistDB(RainExceedanceClimateSiteModel rainExceedanceClimateSiteModel)
        {
            RainExceedanceClimateSite rainExceedanceClimateSite = (from c in db.RainExceedanceClimateSites
                                                                   where c.RainExceedanceID == rainExceedanceClimateSiteModel.RainExceedanceID
                                                                   && c.ClimateSiteID == rainExceedanceClimateSiteModel.ClimateSiteID
                                                                   select c).FirstOrDefault<RainExceedanceClimateSite>();

            return rainExceedanceClimateSite;
        }

        // Helper
        public RainExceedanceClimateSiteModel ReturnError(string Error)
        {
            return new RainExceedanceClimateSiteModel() { Error = Error };
        }

        // Post
        public RainExceedanceClimateSiteModel PostRainExceedanceClimateSiteSaveDB(int RainExceedanceID, int ClimateSiteID, bool Use)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
            {
                return ReturnError(contactOK.Error);
            }

            RainExceedanceClimateSiteModel RainExceedanceClimateSiteModelRet = new RainExceedanceClimateSiteModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (Use)
                {
                    RainExceedanceClimateSiteModel rainExceedanceClimateSiteModelNew = new RainExceedanceClimateSiteModel()
                    {
                        RainExceedanceID = RainExceedanceID,
                        ClimateSiteID = ClimateSiteID,
                    };

                    RainExceedanceClimateSite rainExceedanceClimateSite = GetRainExceedanceClimateSiteExistDB(rainExceedanceClimateSiteModelNew);
                    if (rainExceedanceClimateSite == null)
                    {
                        RainExceedanceClimateSiteModelRet = PostAddRainExceedanceClimateSiteDB(rainExceedanceClimateSiteModelNew);
                        if (!string.IsNullOrWhiteSpace(RainExceedanceClimateSiteModelRet.Error))
                        {
                            return ReturnError(RainExceedanceClimateSiteModelRet.Error);
                        }

                    }
                }
                else
                {
                    RainExceedanceClimateSiteModel rainExceedanceClimateSiteModelNew = new RainExceedanceClimateSiteModel()
                    {
                        RainExceedanceID = RainExceedanceID,
                        ClimateSiteID = ClimateSiteID,
                    };

                    RainExceedanceClimateSite rainExceedanceClimateSite = GetRainExceedanceClimateSiteExistDB(rainExceedanceClimateSiteModelNew);
                    if (rainExceedanceClimateSite == null)
                    {
                        return ReturnError(ServiceRes.CouldNotFindClimateSiteToRemoveFromRainExceedance);
                    }
                    else
                    {
                        RainExceedanceClimateSiteModelRet = PostDeleteRainExceedanceClimateSiteDB(rainExceedanceClimateSite.RainExceedanceClimateSiteID);
                        if (!string.IsNullOrWhiteSpace(RainExceedanceClimateSiteModelRet.Error))
                        {
                            return ReturnError(RainExceedanceClimateSiteModelRet.Error);
                        }
                    }
                }

                ts.Complete();
            }

            return RainExceedanceClimateSiteModelRet;
        }
        public RainExceedanceClimateSiteModel PostAddRainExceedanceClimateSiteDB(RainExceedanceClimateSiteModel rainExceedanceClimateSiteModel)
        {
            string retStr = RainExceedanceClimateSiteModelOK(rainExceedanceClimateSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RainExceedanceClimateSite rainExceedanceClimateSiteExist = GetRainExceedanceClimateSiteExistDB(rainExceedanceClimateSiteModel);
            if (rainExceedanceClimateSiteExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.RainExceedanceClimateSite));

            RainExceedanceClimateSite rainExceedanceClimateSiteNew = new RainExceedanceClimateSite();
            retStr = FillRainExceedanceClimateSite(rainExceedanceClimateSiteNew, rainExceedanceClimateSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.RainExceedanceClimateSites.Add(rainExceedanceClimateSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RainExceedanceClimateSites", rainExceedanceClimateSiteNew.RainExceedanceClimateSiteID, LogCommandEnum.Add, rainExceedanceClimateSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetRainExceedanceClimateSiteModelWithRainExceedanceClimateSiteIDDB(rainExceedanceClimateSiteNew.RainExceedanceClimateSiteID);
        }
        public RainExceedanceClimateSiteModel PostDeleteRainExceedanceClimateSiteDB(int RainExceedanceClimateSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RainExceedanceClimateSite rainExceedanceClimateSiteToDelete = GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteIDDB(RainExceedanceClimateSiteID);
            if (rainExceedanceClimateSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.RainExceedanceClimateSite));

            using (TransactionScope ts = new TransactionScope())
            {
                db.RainExceedanceClimateSites.Remove(rainExceedanceClimateSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RainExceedanceClimateSites", rainExceedanceClimateSiteToDelete.RainExceedanceClimateSiteID, LogCommandEnum.Delete, rainExceedanceClimateSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public RainExceedanceClimateSiteModel PostUpdateRainExceedanceClimateSiteDB(RainExceedanceClimateSiteModel rainExceedanceClimateSiteModel)
        {
            string retStr = RainExceedanceClimateSiteModelOK(rainExceedanceClimateSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            RainExceedanceClimateSite rainExceedanceClimateSiteToUpdate = GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteIDDB(rainExceedanceClimateSiteModel.RainExceedanceClimateSiteID);
            if (rainExceedanceClimateSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.RainExceedanceClimateSite));

            retStr = FillRainExceedanceClimateSite(rainExceedanceClimateSiteToUpdate, rainExceedanceClimateSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("RainExceedanceClimateSites", rainExceedanceClimateSiteToUpdate.RainExceedanceClimateSiteID, LogCommandEnum.Change, rainExceedanceClimateSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetRainExceedanceClimateSiteModelWithRainExceedanceClimateSiteIDDB(rainExceedanceClimateSiteToUpdate.RainExceedanceClimateSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
