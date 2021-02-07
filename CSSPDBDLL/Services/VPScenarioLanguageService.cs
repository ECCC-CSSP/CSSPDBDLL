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
    public class VPScenarioLanguageService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public VPScenarioLanguageService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string VPScenarioLanguageModelOK(VPScenarioLanguageModel vpScenarioLanguageModel)
        {
            string retStr = FieldCheckNotZeroInt(vpScenarioLanguageModel.VPScenarioID, ServiceRes.VPScenarioID);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = _BaseEnumService.LanguageOK(vpScenarioLanguageModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = FieldCheckNotNullAndMinMaxLengthString(vpScenarioLanguageModel.VPScenarioName, ServiceRes.VPScenarioName, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
                return retStr;

            retStr = _BaseEnumService.DBCommandOK(vpScenarioLanguageModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillVPScenarioLanguage(VPScenarioLanguage vpScenarioLanguageNew, VPScenarioLanguageModel vpScenarioLanguageModel, ContactOK contactOK)
        {
            vpScenarioLanguageNew.DBCommand = (int)vpScenarioLanguageModel.DBCommand;
            vpScenarioLanguageNew.VPScenarioID = vpScenarioLanguageModel.VPScenarioID;
            vpScenarioLanguageNew.Language = (int)vpScenarioLanguageModel.Language;
            vpScenarioLanguageNew.TranslationStatus = (int)vpScenarioLanguageModel.TranslationStatus;
            vpScenarioLanguageNew.VPScenarioName = vpScenarioLanguageModel.VPScenarioName;
            vpScenarioLanguageNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                vpScenarioLanguageNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                vpScenarioLanguageNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetVPScenarioLanguageModelCountDB()
        {
            int VPScenarioLanguageModelCount = (from c in db.VPScenarioLanguages
                                                select c).Count();

            return VPScenarioLanguageModelCount;
        }
        public VPScenarioLanguageModel GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB(int VPScenarioID, LanguageEnum Language)
        {
            VPScenarioLanguageModel vpScenarioLanguageModel = (from c in db.VPScenarioLanguages
                                                               where c.VPScenarioID == VPScenarioID
                                                               && c.Language == (int)Language
                                                               select new VPScenarioLanguageModel
                                                               {
                                                                   Error = "",
                                                                   VPScenarioID = c.VPScenarioID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   Language = (LanguageEnum)c.Language,
                                                                   TranslationStatus = (TranslationStatusEnum)c.TranslationStatus,
                                                                   VPScenarioName = c.VPScenarioName,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).FirstOrDefault<VPScenarioLanguageModel>();

            if (vpScenarioLanguageModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.VPScenarioLanguage, ServiceRes.VPScenarioID + "," + ServiceRes.Language, VPScenarioID.ToString() + "," + Language));

            return vpScenarioLanguageModel;
        }
        public VPScenarioLanguage GetVPScenarioLanguageWithVPScenarioIDAndLanguageDB(int VPScenarioID, LanguageEnum Language)
        {
            VPScenarioLanguage vpScenarioLanguage = (from c in db.VPScenarioLanguages
                                                     where c.VPScenarioID == VPScenarioID
                                                     && c.Language == (int)Language
                                                     select c).FirstOrDefault<VPScenarioLanguage>();

            return vpScenarioLanguage;
        }

        // Helper
        public VPScenarioLanguageModel ReturnError(string Error)
        {
            return new VPScenarioLanguageModel() { Error = Error };
        }

        // Post
        public VPScenarioLanguageModel PostAddVPScenarioLanguageDB(VPScenarioLanguageModel vpScenarioLanguageModel)
        {
            string retStr = VPScenarioLanguageModelOK(vpScenarioLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPScenarioLanguageModel vpScenarioLanguageModelExist = GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB(vpScenarioLanguageModel.VPScenarioID, vpScenarioLanguageModel.Language);
            if (string.IsNullOrWhiteSpace(vpScenarioLanguageModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.VPScenarioLanguage));

            VPScenarioLanguage vpScenarioLanguageNew = new VPScenarioLanguage();
            retStr = FillVPScenarioLanguage(vpScenarioLanguageNew, vpScenarioLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.VPScenarioLanguages.Add(vpScenarioLanguageNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPScenarioLanguages", vpScenarioLanguageNew.VPScenarioLanguageID, LogCommandEnum.Add, vpScenarioLanguageNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB(vpScenarioLanguageNew.VPScenarioID, vpScenarioLanguageModel.Language);
        }
        public VPScenarioLanguageModel PostDeleteVPScenarioLanguageDB(int VPScenarioID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPScenarioLanguage vpScenarioLanguageToDelete = GetVPScenarioLanguageWithVPScenarioIDAndLanguageDB(VPScenarioID, Language);
            if (vpScenarioLanguageToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.VPScenarioLanguage));

            using (TransactionScope ts = new TransactionScope())
            {
                db.VPScenarioLanguages.Remove(vpScenarioLanguageToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPScenarioLanguages", vpScenarioLanguageToDelete.VPScenarioLanguageID, LogCommandEnum.Delete, vpScenarioLanguageToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public VPScenarioLanguageModel PostUpdateVPScenarioLanguageDB(VPScenarioLanguageModel vpScenarioLanguageModel)
        {
            string retStr = VPScenarioLanguageModelOK(vpScenarioLanguageModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            VPScenarioLanguage vpScenarioLanguageToUpdate = GetVPScenarioLanguageWithVPScenarioIDAndLanguageDB(vpScenarioLanguageModel.VPScenarioID, vpScenarioLanguageModel.Language);
            if (vpScenarioLanguageToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.VPScenarioLanguage));

            retStr = FillVPScenarioLanguage(vpScenarioLanguageToUpdate, vpScenarioLanguageModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("VPScenarioLanguages", vpScenarioLanguageToUpdate.VPScenarioLanguageID, LogCommandEnum.Change, vpScenarioLanguageToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetVPScenarioLanguageModelWithVPScenarioIDAndLanguageDB(vpScenarioLanguageToUpdate.VPScenarioID, vpScenarioLanguageModel.Language);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
