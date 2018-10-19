using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class TVItemLinkService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string TVItemLinkModelOK(TVItemLinkModel tvItemLinkModel)
        {
            string retStr = FieldCheckNotZeroInt(tvItemLinkModel.FromTVItemID, ServiceRes.FromTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(tvItemLinkModel.ToTVItemID, ServiceRes.ToTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(tvItemLinkModel.FromTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(tvItemLinkModel.ToTVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(tvItemLinkModel.Ordinal, ServiceRes.Ordinal, 0, 1000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(tvItemLinkModel.TVLevel, ServiceRes.TVLevel, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(tvItemLinkModel.TVPath, ServiceRes.TVPath, 2, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTVItemLink(TVItemLink tvItemLinkNew, TVItemLinkModel tvItemLinkModel, ContactOK contactOK)
        {
            tvItemLinkNew.FromTVItemID = tvItemLinkModel.FromTVItemID;
            tvItemLinkNew.ToTVItemID = tvItemLinkModel.ToTVItemID;
            tvItemLinkNew.FromTVType = (int)tvItemLinkModel.FromTVType;
            tvItemLinkNew.ToTVType = (int)tvItemLinkModel.ToTVType;
            tvItemLinkNew.Ordinal = tvItemLinkModel.Ordinal;
            tvItemLinkNew.StartDateTime_Local = tvItemLinkModel.StartDateTime_Local;
            tvItemLinkNew.EndDateTime_Local = tvItemLinkModel.EndDateTime_Local;
            tvItemLinkNew.ParentTVItemLinkID = tvItemLinkModel.ParentTVItemLinkID;
            tvItemLinkNew.TVLevel = tvItemLinkModel.TVLevel;
            tvItemLinkNew.TVPath = tvItemLinkModel.TVPath;
            tvItemLinkNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tvItemLinkNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tvItemLinkNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetTVItemLinkModelCountWithFromTVItemIDDB(int FromTVItemID)
        {
            return (from c in db.TVItemLinks
                    where c.FromTVItemID == FromTVItemID
                    select c).Count();
        }
        public int GetTVItemLinkModelCountWithToTVItemIDDB(int ToTVItemID)
        {
            return (from c in db.TVItemLinks
                    where c.ToTVItemID == ToTVItemID
                    select c).Count();
        }
        public List<TVItemLinkModel> GetTVItemLinkModelListWithFromTVItemIDDB(int FromTVItemID)
        {
            List<TVItemLinkModel> tvItemLinkModelList = (from c in db.TVItemLinks
                                                         let fromName = (from cl in db.TVItemLanguages where cl.TVItemID == c.FromTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                         let toName = (from cl in db.TVItemLanguages where cl.TVItemID == c.ToTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                         where c.FromTVItemID == FromTVItemID
                                                         orderby fromName, toName
                                                         select new TVItemLinkModel
                                                         {
                                                             Error = "",
                                                             TVItemLinkID = c.TVItemLinkID,
                                                             FromTVItemID = c.FromTVItemID,
                                                             FromTVText = fromName,
                                                             ToTVItemID = c.ToTVItemID,
                                                             ToTVText = toName,
                                                             FromTVType = (TVTypeEnum)c.FromTVType,
                                                             ToTVType = (TVTypeEnum)c.ToTVType,
                                                             StartDateTime_Local = c.StartDateTime_Local,
                                                             EndDateTime_Local = c.EndDateTime_Local,
                                                             Ordinal = c.Ordinal,
                                                             TVLevel = c.TVLevel,
                                                             TVPath = c.TVPath,
                                                             ParentTVItemLinkID = c.ParentTVItemLinkID,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                         }).ToList<TVItemLinkModel>();

            return tvItemLinkModelList;
        }
        public List<TVItemLinkModel> GetTVItemLinkModelListWithToTVItemIDDB(int ToTVItemID)
        {
            List<TVItemLinkModel> tvItemLinkModelList = (from c in db.TVItemLinks
                                                         let fromName = (from cl in db.TVItemLanguages where cl.TVItemID == c.FromTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                         let toName = (from cl in db.TVItemLanguages where cl.TVItemID == c.ToTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                                         where c.ToTVItemID == ToTVItemID
                                                         orderby fromName, toName
                                                         select new TVItemLinkModel
                                                         {
                                                             Error = "",
                                                             TVItemLinkID = c.TVItemLinkID,
                                                             FromTVItemID = c.FromTVItemID,
                                                             FromTVText = fromName,
                                                             ToTVItemID = c.ToTVItemID,
                                                             ToTVText = toName,
                                                             FromTVType = (TVTypeEnum)c.FromTVType,
                                                             ToTVType = (TVTypeEnum)c.ToTVType,
                                                             StartDateTime_Local = c.StartDateTime_Local,
                                                             EndDateTime_Local = c.EndDateTime_Local,
                                                             Ordinal = c.Ordinal,
                                                             TVLevel = c.TVLevel,
                                                             TVPath = c.TVPath,
                                                             ParentTVItemLinkID = c.ParentTVItemLinkID,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                         }).ToList<TVItemLinkModel>();

            return tvItemLinkModelList;
        }
        public TVItemLinkModel GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(int FromTVItemID, int ToTVItemID)
        {
            TVItemLinkModel tvItemLinkModel = (from c in db.TVItemLinks
                                               let fromName = (from cl in db.TVItemLanguages where cl.TVItemID == c.FromTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                               let toName = (from cl in db.TVItemLanguages where cl.TVItemID == c.ToTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                               where c.FromTVItemID == FromTVItemID
                                               && c.ToTVItemID == ToTVItemID
                                               orderby fromName, toName
                                               select new TVItemLinkModel
                                               {
                                                   Error = "",
                                                   TVItemLinkID = c.TVItemLinkID,
                                                   FromTVItemID = c.FromTVItemID,
                                                   FromTVText = fromName,
                                                   ToTVItemID = c.ToTVItemID,
                                                   ToTVText = toName,
                                                   FromTVType = (TVTypeEnum)c.FromTVType,
                                                   ToTVType = (TVTypeEnum)c.ToTVType,
                                                   StartDateTime_Local = c.StartDateTime_Local,
                                                   EndDateTime_Local = c.EndDateTime_Local,
                                                   Ordinal = c.Ordinal,
                                                   TVLevel = c.TVLevel,
                                                   TVPath = c.TVPath,
                                                   ParentTVItemLinkID = c.ParentTVItemLinkID,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                               }).FirstOrDefault<TVItemLinkModel>();

            if (tvItemLinkModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLink, ServiceRes.FromTVItemID + "," + ServiceRes.ToTVItemID, FromTVItemID + "," + ToTVItemID));

            return tvItemLinkModel;
        }
        public TVItemLink GetTVItemLinkWithFromTVItemIDAndToTVItemIDDB(int FromTVItemID, int ToTVItemID)
        {
            TVItemLink tvItemLink = (from c in db.TVItemLinks
                                     where c.FromTVItemID == FromTVItemID
                                     && c.ToTVItemID == ToTVItemID
                                     select c).FirstOrDefault<TVItemLink>();
            return tvItemLink;
        }
        public List<TVItemLink> GetTVItemLinkListWithFromTVItemIDDB(int FromTVItemID)
        {
            List<TVItemLink> tvItemLinkList = (from c in db.TVItemLinks
                                               where c.FromTVItemID == FromTVItemID
                                               select c).ToList<TVItemLink>();
            return tvItemLinkList;
        }
        public List<TVItemLink> GetTVItemLinkListWithToTVItemIDDB(int ToTVItemID)
        {
            List<TVItemLink> tvItemLinkList = (from c in db.TVItemLinks
                                               where c.ToTVItemID == ToTVItemID
                                               select c).ToList<TVItemLink>();
            return tvItemLinkList;
        }
        public TVItemLinkModel GetTVItemLinkModelWithTVItemLinkIDDB(int TVItemLinkID)
        {
            TVItemLinkModel tvItemLinkModel = (from c in db.TVItemLinks
                                               let fromName = (from cl in db.TVItemLanguages where cl.TVItemID == c.FromTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                               let toName = (from cl in db.TVItemLanguages where cl.TVItemID == c.ToTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                               where c.TVItemLinkID == TVItemLinkID
                                               orderby fromName, toName
                                               select new TVItemLinkModel
                                               {
                                                   Error = "",
                                                   TVItemLinkID = c.TVItemLinkID,
                                                   FromTVItemID = c.FromTVItemID,
                                                   FromTVText = fromName,
                                                   ToTVItemID = c.ToTVItemID,
                                                   ToTVText = toName,
                                                   FromTVType = (TVTypeEnum)c.FromTVType,
                                                   ToTVType = (TVTypeEnum)c.ToTVType,
                                                   StartDateTime_Local = c.StartDateTime_Local,
                                                   EndDateTime_Local = c.EndDateTime_Local,
                                                   Ordinal = c.Ordinal,
                                                   TVLevel = c.TVLevel,
                                                   TVPath = c.TVPath,
                                                   ParentTVItemLinkID = c.ParentTVItemLinkID,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                               }).FirstOrDefault<TVItemLinkModel>();


            if (tvItemLinkModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItemLanguage, ServiceRes.TVItemLinkID, TVItemLinkID));

            return tvItemLinkModel;
        }
        public TVItemLink GetTVItemLinkWithTVItemLinkIDDB(int TVItemLinkID)
        {
            TVItemLink tvItemLink = (from c in db.TVItemLinks
                                     where c.TVItemLinkID == TVItemLinkID
                                     select c).FirstOrDefault<TVItemLink>();
            return tvItemLink;
        }
        public TVItemLink GetTVItemLinkWithFromTVItemIDAndFromTVTypeAndToTVTypeDB(int FromTVItemID, TVTypeEnum FromTVType, TVTypeEnum ToTVType)
        {
            TVItemLink tvItemLink = (from c in db.TVItemLinks
                                     where c.FromTVItemID == FromTVItemID
                                     && c.FromTVType == (int)FromTVType
                                     && c.ToTVType == (int)ToTVType
                                     select c).FirstOrDefault<TVItemLink>();
            return tvItemLink;
        }
        // Helper
        public TVItemLinkModel ReturnError(string Error)
        {
            return new TVItemLinkModel() { Error = Error };
        }

        // Post
        public TVItemLinkModel PostAddTVItemLinkDB(TVItemLinkModel tvItemLinkModel)
         {
            string retStr = TVItemLinkModelOK(tvItemLinkModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemLinkModel tvItemLinkModelRet = GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(tvItemLinkModel.FromTVItemID, tvItemLinkModel.ToTVItemID);
            if (string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemLink));

            TVItemLink tvItemLinkNew = new TVItemLink();
            retStr = FillTVItemLink(tvItemLinkNew, tvItemLinkModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemLinks.Add(tvItemLinkNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLinks", tvItemLinkNew.TVItemLinkID, LogCommandEnum.Add, tvItemLinkNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetTVItemLinkModelWithTVItemLinkIDDB(tvItemLinkNew.TVItemLinkID);
        }
        public TVItemLinkModel PostDeleteTVItemLinkWithTVItemLinkIDDB(int TVItemLinkID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemLink tvItemLinkToDelete = GetTVItemLinkWithTVItemLinkIDDB(TVItemLinkID);
            if (tvItemLinkToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemLink));

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemLinks.Remove(tvItemLinkToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLinks", tvItemLinkToDelete.TVItemLinkID, LogCommandEnum.Delete, tvItemLinkToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public TVItemLinkModel PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(int FromTVItemID, int ToTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemLink tvItemLinkToDelete = GetTVItemLinkWithFromTVItemIDAndToTVItemIDDB(FromTVItemID, ToTVItemID);
            if (tvItemLinkToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemLink));

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemLinks.Remove(tvItemLinkToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLinks", tvItemLinkToDelete.TVItemLinkID, LogCommandEnum.Delete, tvItemLinkToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVItemLinkModel PostDeleteTVItemLinkWithFromTVItemIDAndFromTVTypeAndToTVTypeDB(int FromTVItemID, TVTypeEnum FromTVType, TVTypeEnum ToTVType)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemLink tvItemLinkToDelete = GetTVItemLinkWithFromTVItemIDAndFromTVTypeAndToTVTypeDB(FromTVItemID, FromTVType, ToTVType);
            if (tvItemLinkToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVItemLink));

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemLinks.Remove(tvItemLinkToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLinks", tvItemLinkToDelete.TVItemLinkID, LogCommandEnum.Delete, tvItemLinkToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVItemLinkModel PostDeleteTVItemLinkWithFromTVItemIDDB(int FromTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            List<TVItemLink> tvItemLinkListToDelete = GetTVItemLinkListWithFromTVItemIDDB(FromTVItemID);

            foreach (TVItemLink tvil in tvItemLinkListToDelete)
            {
                LogModel logModel = _LogService.PostAddLogForObj("TVItemLinks", tvil.TVItemLinkID, LogCommandEnum.Delete, tvil);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                db.TVItemLinks.Remove(tvil);
            }

            using (TransactionScope ts = new TransactionScope())
            {

                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVItemLinkModel PostDeleteTVItemLinkWithToTVItemIDDB(int ToTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);


            List<TVItemLink> tvItemLinkListToDelete = GetTVItemLinkListWithToTVItemIDDB(ToTVItemID);

            foreach (TVItemLink tvil in tvItemLinkListToDelete)
            {
                LogModel logModel = _LogService.PostAddLogForObj("TVItemLinks", tvil.TVItemLinkID, LogCommandEnum.Delete, tvil);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                db.TVItemLinks.Remove(tvil);
            }

            using (TransactionScope ts = new TransactionScope())
            {

                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVItemLinkModel PostUpdateTVItemLinkDB(TVItemLinkModel tvItemLinkModel)
        {
            string retStr = TVItemLinkModelOK(tvItemLinkModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemLink tvItemLinkToUpdate = GetTVItemLinkWithTVItemLinkIDDB(tvItemLinkModel.TVItemLinkID);
            if (tvItemLinkToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItemLink));

            List<TVItemLinkModel> tvItemLinkModelList = GetTVItemLinkModelListWithFromTVItemIDDB(tvItemLinkModel.FromTVItemID);
            foreach (TVItemLinkModel tvItemLinkModelInDB in tvItemLinkModelList)
            {
                if (tvItemLinkModelInDB.ToTVItemID == tvItemLinkModel.ToTVItemID && tvItemLinkModelInDB.TVItemLinkID != tvItemLinkModel.TVItemLinkID)
                    return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItemLink));
            }

            retStr = FillTVItemLink(tvItemLinkToUpdate, tvItemLinkModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemLinks", tvItemLinkToUpdate.TVItemLinkID, LogCommandEnum.Change, tvItemLinkToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetTVItemLinkModelWithTVItemLinkIDDB(tvItemLinkToUpdate.TVItemLinkID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
