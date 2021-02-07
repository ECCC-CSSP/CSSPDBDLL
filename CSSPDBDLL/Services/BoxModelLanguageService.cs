using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;

namespace CSSPDBDLL.Services
{
    public class BoxModelLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _LogService = new LogService(LanguageRequest, User);
            _BaseEnumService = new BaseEnumService(LanguageRequest);
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
        public string BoxModelLanguageModelOK(BoxModelLanguageModel boxModelLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(boxModelLanguageModel.BoxModelID, ServiceRes.BoxModelID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(boxModelLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(boxModelLanguageModel.ScenarioName, ServiceRes.ScenarioName, 2, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(boxModelLanguageModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillBoxModelLanguageModel(BoxModelLanguage boxModelLanguage, BoxModelLanguageModel boxModelLanguageModel, ContactOK contactOK)
        {
            try
            {
                boxModelLanguage.DBCommand = (int)boxModelLanguageModel.DBCommand;
                boxModelLanguage.BoxModelID = boxModelLanguageModel.BoxModelID;
                boxModelLanguage.Language = (int)boxModelLanguageModel.Language;
                boxModelLanguage.ScenarioName = boxModelLanguageModel.ScenarioName;
                boxModelLanguage.TranslationStatus = (int)boxModelLanguageModel.TranslationStatus;
                boxModelLanguage.LastUpdateDate_UTC = DateTime.UtcNow;
                if (contactOK == null)
                {
                    boxModelLanguage.LastUpdateContactTVItemID = 2;
                }
                else
                {
                    boxModelLanguage.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }

        // Get
        public int GetBoxModelLanguageModelCountDB()
        {
            int BoxModelLanguageModelCount = (from c in db.BoxModelLanguages
                                              select c).Count();


            return BoxModelLanguageModelCount;
        }
        public BoxModelLanguageModel GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(int BoxModelID, LanguageEnum Language)
        {
            BoxModelLanguageModel boxModelLanguageModel = (from c in db.BoxModelLanguages
                                                           where c.BoxModelID == BoxModelID
                                                           && c.Language == (int)Language
                                                           select new BoxModelLanguageModel
                                                           {
                                                               Error = "",
                                                               BoxModelLanguageID = c.BoxModelLanguageID,
                                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                                               BoxModelID = c.BoxModelID,
                                                               Language = (LanguageEnum)c.Language,
                                                               ScenarioName = c.ScenarioName,
                                                               TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                           }).FirstOrDefault<BoxModelLanguageModel>();


            if (boxModelLanguageModel == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModelLanguage, ServiceRes.BoxModelID + "," + ServiceRes.Language, BoxModelID + "," + Language));

            return boxModelLanguageModel;
        }
        public BoxModelLanguage GetBoxModelLanguageWithBoxModelIDAndLanguageDB(int BoxModelID, LanguageEnum Language)
        {
            BoxModelLanguage boxModelLanguage = (from c in db.BoxModelLanguages
                                                 where c.BoxModelID == BoxModelID
                                                 && c.Language == (int)Language
                                                 select c).FirstOrDefault<BoxModelLanguage>();

            return boxModelLanguage;
        }

        // Helper
        public BoxModelLanguageModel ReturnError(string Error)
        {
            return new BoxModelLanguageModel() { Error = Error };
        }

        // Post
        public BoxModelLanguageModel PostAddBoxModelLanguageDB(BoxModelLanguageModel boxModelLanguageModel)
        {
            string retStr = BoxModelLanguageModelOK(boxModelLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error)) 
                return ReturnError(contactOK.Error);

            BoxModelLanguageModel boxModelLanguageModelExist = GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(boxModelLanguageModel.BoxModelID, boxModelLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(boxModelLanguageModelExist.Error)) 
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.BoxModelLanguage));

            BoxModelLanguage boxModelLanguageNew = new BoxModelLanguage();
            retStr = FillBoxModelLanguageModel(boxModelLanguageNew, boxModelLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.BoxModelLanguages.Add(boxModelLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModelLanguages", boxModelLanguageNew.BoxModelLanguageID, LogCommandEnum.Add, boxModelLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(boxModelLanguageNew.BoxModelID, (LanguageEnum)boxModelLanguageNew.Language);
        }
        public BoxModelLanguageModel PostDeleteBoxModelLanguageDB(int BoxModelID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error)) 
                return ReturnError(contactOK.Error);

            BoxModelLanguage boxModelLanguageToDelete = GetBoxModelLanguageWithBoxModelIDAndLanguageDB(BoxModelID, Language);
            if (boxModelLanguageToDelete == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.BoxModelLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.BoxModelLanguages.Remove(boxModelLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModelLanguages", boxModelLanguageToDelete.BoxModelLanguageID, LogCommandEnum.Delete, boxModelLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public BoxModelLanguageModel PostUpdateBoxModelLanguageDB(BoxModelLanguageModel boxModelLanguageModel)
        {
            string retStr = BoxModelLanguageModelOK(boxModelLanguageModel);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error)) 
                return ReturnError(contactOK.Error);

            BoxModelLanguage boxModelLanguageToUpdate = GetBoxModelLanguageWithBoxModelIDAndLanguageDB(boxModelLanguageModel.BoxModelID, boxModelLanguageModel.Language);
            if (boxModelLanguageToUpdate == null) 
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.BoxModelLanguage));

            retStr = FillBoxModelLanguageModel(boxModelLanguageToUpdate, boxModelLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr)) 
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr)) 
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModelLanguages", boxModelLanguageToUpdate.BoxModelLanguageID, LogCommandEnum.Change, boxModelLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetBoxModelLanguageModelWithBoxModelIDAndLanguageDB(boxModelLanguageToUpdate.BoxModelID, (LanguageEnum)boxModelLanguageToUpdate.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
