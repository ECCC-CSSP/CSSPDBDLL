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
    public class HelpDocService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public HelpDocService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string HelpDocModelOK(HelpDocModel helpDocModel)
        {
            string retStr = FieldCheckNotNullAndMinMaxLengthString(helpDocModel.DocKey, ServiceRes.DocKey, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(helpDocModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(helpDocModel.DocHTMLText, ServiceRes.DocHTMLText, 50000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillHelpDoc(HelpDoc helpDocNew, HelpDocModel helpDocModel, ContactOK contactOK)
        {
            helpDocNew.DocKey = helpDocModel.DocKey;
            helpDocNew.Language = (int)helpDocModel.Language;
            helpDocNew.DocHTMLText = helpDocModel.DocHTMLText;
            helpDocNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                helpDocNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                helpDocNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetHelpDocModelCountDB()
        {
            int HelpDocModelCount = (from c in db.HelpDocs
                                     select c).Count();

            return HelpDocModelCount;
        }
        public HelpDocModel GetHelpDocModelWithDocKeyAndLanguageDB(string DocKey, LanguageEnum Language)
        {
            HelpDocModel helpDocModel = (from c in db.HelpDocs
                                         where c.DocKey == DocKey
                                         && c.Language == (int)Language
                                         select new HelpDocModel
                                         {
                                             Error = "",
                                             HelpDocID = c.HelpDocID,
                                             DocKey = c.DocKey,
                                             Language = (LanguageEnum)c.Language,
                                             DocHTMLText = c.DocHTMLText,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<HelpDocModel>();
            if (helpDocModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.HelpDoc, ServiceRes.DocKey + "," + ServiceRes.Language,
                    DocKey + "," + Language));

            return helpDocModel;
        }
        public HelpDocModel GetHelpDocModelWithHelpDocIDDB(int HelpDocID)
        {
            HelpDocModel helpDocModel = (from c in db.HelpDocs
                                         where c.HelpDocID == HelpDocID
                                         select new HelpDocModel
                                         {
                                             Error = "",
                                             HelpDocID = c.HelpDocID,
                                             DocKey = c.DocKey,
                                             Language = (LanguageEnum)c.Language,
                                             DocHTMLText = c.DocHTMLText,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<HelpDocModel>();
            if (helpDocModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.HelpDoc, ServiceRes.HelpDocID, HelpDocID));

            return helpDocModel;
        }
        public HelpDoc GetHelpDocWithHelpDocIDDB(int HelpDocID)
        {
            HelpDoc HelpDoc = (from c in db.HelpDocs
                               where c.HelpDocID == HelpDocID
                               select c).FirstOrDefault<HelpDoc>();

            return HelpDoc;
        }

        // Helper
        public HelpDocModel ReturnError(string Error)
        {
            return new HelpDocModel() { Error = Error };
        }

        // Post
        public HelpDocModel PostAddOrModifyHelpDocDB(string DocKey, string LanguageText, string DocHTMLText)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LanguageEnum Language = LanguageEnum.en;

            if (LanguageText == "fr")
            {
                Language = LanguageEnum.fr;
            }

            HelpDocModel helpDocModelRet = new HelpDocModel();
            HelpDocModel helpDocModelExist = GetHelpDocModelWithDocKeyAndLanguageDB(DocKey, Language);
            if (!string.IsNullOrWhiteSpace(helpDocModelExist.Error))
            {
                HelpDocModel helpDocModelNew = new HelpDocModel()
                {
                    DocKey = DocKey,
                    DocHTMLText = DocHTMLText,
                    Language = Language,
                };

                helpDocModelRet = PostAddHelpDocDB(helpDocModelNew);
                if (!string.IsNullOrWhiteSpace(helpDocModelRet.Error))
                {
                    return ReturnError(helpDocModelRet.Error);
                }
            }
            else
            {
                helpDocModelExist.DocHTMLText = DocHTMLText;

                helpDocModelRet = PostUpdateHelpDocDB(helpDocModelExist);
                if (!string.IsNullOrWhiteSpace(helpDocModelRet.Error))
                {
                    return ReturnError(helpDocModelRet.Error);
                }

            }


            return GetHelpDocModelWithHelpDocIDDB(helpDocModelRet.HelpDocID);
        }
        public HelpDocModel PostAddHelpDocDB(HelpDocModel helpDocModel)
        {
            string retStr = HelpDocModelOK(helpDocModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HelpDocModel helpDocModelExist = GetHelpDocModelWithDocKeyAndLanguageDB(helpDocModel.DocKey, helpDocModel.Language);
            if (string.IsNullOrWhiteSpace(helpDocModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.HelpDoc));

            HelpDoc helpDocNew = new HelpDoc();
            retStr = FillHelpDoc(helpDocNew, helpDocModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.HelpDocs.Add(helpDocNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HelpDocs", helpDocNew.HelpDocID, LogCommandEnum.Add, helpDocNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetHelpDocModelWithHelpDocIDDB(helpDocNew.HelpDocID);
        }
        public HelpDocModel PostDeleteHelpDocDB(int HelpDocID, LanguageEnum Language)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HelpDoc helpDocToDelete = GetHelpDocWithHelpDocIDDB(HelpDocID);
            if (helpDocToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.HelpDoc));

            using (TransactionScope ts = new TransactionScope())
            {
                db.HelpDocs.Remove(helpDocToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HelpDocs", helpDocToDelete.HelpDocID, LogCommandEnum.Delete, helpDocToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public HelpDocModel PostUpdateHelpDocDB(HelpDocModel helpDocModel)
        {
            string retStr = HelpDocModelOK(helpDocModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            HelpDoc helpDocToUpdate = GetHelpDocWithHelpDocIDDB(helpDocModel.HelpDocID);
            if (helpDocToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.HelpDoc));

            retStr = FillHelpDoc(helpDocToUpdate, helpDocModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("HelpDocs", helpDocToUpdate.HelpDocID, LogCommandEnum.Change, helpDocToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetHelpDocModelWithHelpDocIDDB(helpDocToUpdate.HelpDocID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
