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

namespace CSSPDBDLL.Services
{
    public class PolSourceSiteEffectService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public PolSourceSiteEffectTermService _PolSourceSiteEffectTermService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _PolSourceSiteEffectTermService = new PolSourceSiteEffectTermService(LanguageRequest, User);
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
        public string PolSourceSiteEffectModelOK(PolSourceSiteEffectModel polSourceSiteEffectModel)
        {
            string retStr = FieldCheckNotZeroInt(polSourceSiteEffectModel.PolSourceSiteOrInfrastructureTVItemID, ServiceRes.PolSourceSiteOrInfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(polSourceSiteEffectModel.MWQMSiteTVItemID, ServiceRes.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(polSourceSiteEffectModel.AnalysisDocumentTVItemID, ServiceRes.AnalysisDocumentTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillPolSourceSiteEffect(PolSourceSiteEffect polSourceSiteEffect, PolSourceSiteEffectModel polSourceSiteEffectModel, ContactOK contactOK)
        {
            polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = polSourceSiteEffectModel.PolSourceSiteOrInfrastructureTVItemID;
            polSourceSiteEffect.MWQMSiteTVItemID = polSourceSiteEffectModel.MWQMSiteTVItemID;
            polSourceSiteEffect.PolSourceSiteEffectTermIDs = polSourceSiteEffectModel.PolSourceSiteEffectTermIDs;
            polSourceSiteEffect.Comments = polSourceSiteEffectModel.Comments;
            polSourceSiteEffect.AnalysisDocumentTVItemID = polSourceSiteEffectModel.AnalysisDocumentTVItemID;
            polSourceSiteEffect.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                polSourceSiteEffect.LastUpdateContactTVItemID = 2;
            }
            else
            {
                polSourceSiteEffect.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetPolSourceSiteEffectModelCountDB()
        {
            int PolSourceSiteEffectModelCount = (from c in db.PolSourceSiteEffects
                                                 select c).Count();

            return PolSourceSiteEffectModelCount;
        }
        public PolSourceSiteEffectModel GetPolSourceSiteEffectModelWithPolSourceSiteEffectIDDB(int PolSourceSiteEffectID)
        {
            PolSourceSiteEffectModel polSourceSiteEffectModel = (from c in db.PolSourceSiteEffects
                                                                 where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                                                                 select new PolSourceSiteEffectModel
                                                                 {
                                                                     Error = "",
                                                                     PolSourceSiteEffectID = c.PolSourceSiteEffectID,
                                                                     PolSourceSiteOrInfrastructureTVItemID = c.PolSourceSiteOrInfrastructureTVItemID,
                                                                     MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                     PolSourceSiteEffectTermIDs = c.PolSourceSiteEffectTermIDs,
                                                                     Comments = c.Comments,
                                                                     AnalysisDocumentTVItemID = c.AnalysisDocumentTVItemID,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).FirstOrDefault<PolSourceSiteEffectModel>();

            if (polSourceSiteEffectModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceSiteEffectModel, ServiceRes.PolSourceSiteEffectID, PolSourceSiteEffectID));
            }
            else
            {
                List<PolSourceSiteEffectTermModel> polSourceSiteEffectTermModelList = _PolSourceSiteEffectTermService.GetAllPolSourceSiteEffectTerm();

                polSourceSiteEffectModel.PolSourceSiteEffectTermModelList = FillPolSourceSiteEffectTermModelList(polSourceSiteEffectModel, polSourceSiteEffectTermModelList);
            }

            return polSourceSiteEffectModel;
        }
        public PolSourceSiteEffect GetPolSourceSiteEffectWithPolSourceSiteEffectIDDB(int PolSourceSiteEffectID)
        {
            PolSourceSiteEffect polSourceSiteEffect = (from c in db.PolSourceSiteEffects
                                                       where c.PolSourceSiteEffectID == PolSourceSiteEffectID
                                                       select c).FirstOrDefault<PolSourceSiteEffect>();

            return polSourceSiteEffect;
        }
        public PolSourceSiteEffectModel GetPolSourceSiteEffectModelWithPolSourceSiteOrInfrastructureTVItemIDAndMWQMSiteTVItemIDDB(int PolSourceSiteOrInfrastructureTVItemID, int MWQMSiteTVItemID)
        {
            PolSourceSiteEffectModel polSourceSiteEffectModel = (from c in db.PolSourceSiteEffects
                                                                 where c.PolSourceSiteOrInfrastructureTVItemID == PolSourceSiteOrInfrastructureTVItemID
                                                                 && c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                                                 select new PolSourceSiteEffectModel
                                                                 {
                                                                     Error = "",
                                                                     PolSourceSiteEffectID = c.PolSourceSiteEffectID,
                                                                     PolSourceSiteOrInfrastructureTVItemID = c.PolSourceSiteOrInfrastructureTVItemID,
                                                                     MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                     PolSourceSiteEffectTermIDs = c.PolSourceSiteEffectTermIDs,
                                                                     Comments = c.Comments,
                                                                     AnalysisDocumentTVItemID = c.AnalysisDocumentTVItemID,
                                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                 }).FirstOrDefault<PolSourceSiteEffectModel>();

            if (polSourceSiteEffectModel == null)
            {
               return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceSiteEffectModel, ServiceRes.PolSourceSiteOrInfrastructureTVItemID + "," + ServiceRes.MWQMSiteTVItemID, PolSourceSiteOrInfrastructureTVItemID.ToString() + "," + MWQMSiteTVItemID.ToString()));
            }
            else
            {
                List<PolSourceSiteEffectTermModel> polSourceSiteEffectTermModelList = _PolSourceSiteEffectTermService.GetAllPolSourceSiteEffectTerm();

                polSourceSiteEffectModel.PolSourceSiteEffectTermModelList = FillPolSourceSiteEffectTermModelList(polSourceSiteEffectModel, polSourceSiteEffectTermModelList);
            }

            return polSourceSiteEffectModel;
        }
        public List<PolSourceSiteEffectModel> GetPolSourceSiteEffectModelListWithPolSourceSiteOrInfrastructureTVItemIDDB(int PolSourceSiteOrInfrastructureTVItemID)
        {
            List<PolSourceSiteEffectModel> polSourceSiteEffectModelList = (from c in db.PolSourceSiteEffects
                                                                           where c.PolSourceSiteOrInfrastructureTVItemID == PolSourceSiteOrInfrastructureTVItemID
                                                                           select new PolSourceSiteEffectModel
                                                                           {
                                                                               Error = "",
                                                                               PolSourceSiteEffectID = c.PolSourceSiteEffectID,
                                                                               PolSourceSiteOrInfrastructureTVItemID = c.PolSourceSiteOrInfrastructureTVItemID,
                                                                               MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                               PolSourceSiteEffectTermIDs = c.PolSourceSiteEffectTermIDs,
                                                                               Comments = c.Comments,
                                                                               AnalysisDocumentTVItemID = c.AnalysisDocumentTVItemID,
                                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                           }).ToList<PolSourceSiteEffectModel>();

            if (polSourceSiteEffectModelList.Count > 0)
            {
                List<PolSourceSiteEffectTermModel> polSourceSiteEffectTermModelList = _PolSourceSiteEffectTermService.GetAllPolSourceSiteEffectTerm();

                foreach (PolSourceSiteEffectModel polSourceSiteEffectModel in polSourceSiteEffectModelList)
                {

                    polSourceSiteEffectModel.PolSourceSiteEffectTermModelList = FillPolSourceSiteEffectTermModelList(polSourceSiteEffectModel, polSourceSiteEffectTermModelList);
                }
            }

            return polSourceSiteEffectModelList;
        }
        public List<PolSourceSiteEffectModel> GetPolSourceSiteEffectModelListWithMWQMSiteTVItemIDDB(int MWQMSiteTVItemID)
        {
            List<PolSourceSiteEffectModel> polSourceSiteEffectModelList = (from c in db.PolSourceSiteEffects
                                                                           where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                                                           select new PolSourceSiteEffectModel
                                                                           {
                                                                               Error = "",
                                                                               PolSourceSiteEffectID = c.PolSourceSiteEffectID,
                                                                               PolSourceSiteOrInfrastructureTVItemID = c.PolSourceSiteOrInfrastructureTVItemID,
                                                                               MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                               PolSourceSiteEffectTermIDs = c.PolSourceSiteEffectTermIDs,
                                                                               Comments = c.Comments,
                                                                               AnalysisDocumentTVItemID = c.AnalysisDocumentTVItemID,
                                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                           }).ToList<PolSourceSiteEffectModel>();

            if (polSourceSiteEffectModelList.Count > 0)
            {
                List<PolSourceSiteEffectTermModel> polSourceSiteEffectTermModelList = _PolSourceSiteEffectTermService.GetAllPolSourceSiteEffectTerm();

                foreach (PolSourceSiteEffectModel polSourceSiteEffectModel in polSourceSiteEffectModelList)
                {

                    polSourceSiteEffectModel.PolSourceSiteEffectTermModelList = FillPolSourceSiteEffectTermModelList(polSourceSiteEffectModel, polSourceSiteEffectTermModelList);
                }
            }

            return polSourceSiteEffectModelList;
        }

        // Helper
        public PolSourceSiteEffectModel ReturnError(string Error)
        {
            return new PolSourceSiteEffectModel() { Error = Error };
        }

        // Post
        public PolSourceSiteEffectModel PolSourceSiteEffectTermsSaveAllDB(int PolSourceSiteEffectID, string PolSourceSiteEffectTermIDs)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteEffectModel polSourceSiteEffectToChange = GetPolSourceSiteEffectModelWithPolSourceSiteEffectIDDB(PolSourceSiteEffectID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectToChange.Error))
                return ReturnError(polSourceSiteEffectToChange.Error);

            polSourceSiteEffectToChange.PolSourceSiteEffectTermIDs = PolSourceSiteEffectTermIDs;

            PolSourceSiteEffectModel polSourceSiteEffectToChangeRet = PostUpdatePolSourceSiteEffectDB(polSourceSiteEffectToChange);

            return polSourceSiteEffectToChangeRet;
        }
        public PolSourceSiteEffectModel PolSourceSiteEffectAddOrModifyDB(FormCollection fc)
        {
            int tempInt = 0;
            int PolSourceSiteEffectID = 0;
            int PolSourceSiteOrInfrastructureTVItemID = 0;
            int MWQMSiteTVItemID = 0;
            string PolSourceSiteEffectTermIDs = "";
            string Comments = "";
            int? AnalysisDocumentTVItemID = null;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            if (string.IsNullOrWhiteSpace(fc["PolSourceSiteEffectID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteEffectID));

            if (!int.TryParse(fc["PolSourceSiteEffectID"], out PolSourceSiteEffectID))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteEffectID));
            }

            PolSourceSiteEffectModel polSourceSiteEffectNewOrToChange = new PolSourceSiteEffectModel();

            if (PolSourceSiteEffectID != 0)
            {
                polSourceSiteEffectNewOrToChange = GetPolSourceSiteEffectModelWithPolSourceSiteEffectIDDB(PolSourceSiteEffectID);
                if (!string.IsNullOrWhiteSpace(polSourceSiteEffectNewOrToChange.Error))
                    return ReturnError(polSourceSiteEffectNewOrToChange.Error);
            }

            // PolSourceSiteEffectID == 0 ==> Add 
            // PolSourceSiteEffectID > 0 ==> Modify

            if (string.IsNullOrWhiteSpace(fc["PolSourceSiteOrInfrastructureTVItemID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteOrInfrastructureTVItemID));

            if (!int.TryParse(fc["PolSourceSiteOrInfrastructureTVItemID"], out PolSourceSiteOrInfrastructureTVItemID))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteOrInfrastructureTVItemID));
            }

            TVItemModel tvItemModelPolSourceSiteOrInfrastructure = null;
            if (PolSourceSiteOrInfrastructureTVItemID != 0)
            {
                tvItemModelPolSourceSiteOrInfrastructure = _TVItemService.GetTVItemModelWithTVItemIDDB(PolSourceSiteOrInfrastructureTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelPolSourceSiteOrInfrastructure.Error))
                    return ReturnError(tvItemModelPolSourceSiteOrInfrastructure.Error);
            }

            if (string.IsNullOrWhiteSpace(fc["MWQMSiteTVItemID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID));

            if (!int.TryParse(fc["MWQMSiteTVItemID"], out MWQMSiteTVItemID))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID));
            }

            TVItemModel tvItemModelMWQMSite = null;
            if (MWQMSiteTVItemID != 0)
            {
                tvItemModelMWQMSite = _TVItemService.GetTVItemModelWithTVItemIDDB(MWQMSiteTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelMWQMSite.Error))
                    return ReturnError(tvItemModelMWQMSite.Error);
            }

            PolSourceSiteEffectTermIDs = fc["PolSourceSiteEffectTermIDs"];

            Comments = fc["Comments"];

            if (string.IsNullOrWhiteSpace(fc["AnalysisDocumentTVItemID"]))
            {
                AnalysisDocumentTVItemID = null;
            }
            else
            {
                if (!int.TryParse(fc["AnalysisDocumentTVItemID"], out tempInt))
                {
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AnalysisDocumentTVItemID));
                }
                else
                {
                    AnalysisDocumentTVItemID = tempInt;
                }
            }

            using (TransactionScope ts = new TransactionScope())
            {
                if (PolSourceSiteEffectID == 0)
                {
                    PolSourceSiteEffectModel polSourceSiteEffectModelNew = new PolSourceSiteEffectModel()
                    {
                        PolSourceSiteOrInfrastructureTVItemID = PolSourceSiteOrInfrastructureTVItemID,
                        MWQMSiteTVItemID = MWQMSiteTVItemID,
                        PolSourceSiteEffectTermIDs = PolSourceSiteEffectTermIDs,
                        Comments = Comments,
                        AnalysisDocumentTVItemID = AnalysisDocumentTVItemID,
                    };

                    PolSourceSiteEffectModel polSourceSiteEffectModelRet = PostAddPolSourceSiteEffectDB(polSourceSiteEffectModelNew);
                    if (!string.IsNullOrWhiteSpace(polSourceSiteEffectModelRet.Error))
                        return ReturnError(polSourceSiteEffectModelRet.Error);
                }
                else
                {
                    polSourceSiteEffectNewOrToChange.PolSourceSiteOrInfrastructureTVItemID = PolSourceSiteOrInfrastructureTVItemID;
                    polSourceSiteEffectNewOrToChange.MWQMSiteTVItemID = MWQMSiteTVItemID;
                    polSourceSiteEffectNewOrToChange.PolSourceSiteEffectTermIDs = PolSourceSiteEffectTermIDs;
                    polSourceSiteEffectNewOrToChange.Comments = Comments;
                    polSourceSiteEffectNewOrToChange.AnalysisDocumentTVItemID = AnalysisDocumentTVItemID;

                    polSourceSiteEffectNewOrToChange = PostUpdatePolSourceSiteEffectDB(polSourceSiteEffectNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(polSourceSiteEffectNewOrToChange.Error))
                        return ReturnError(polSourceSiteEffectNewOrToChange.Error);

                }

                ts.Complete();
            }
            return polSourceSiteEffectNewOrToChange;
        }
        public PolSourceSiteEffectModel PostAddPolSourceSiteEffectDB(PolSourceSiteEffectModel polSourceSiteEffectModel)
        {
            string retStr = PolSourceSiteEffectModelOK(polSourceSiteEffectModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(polSourceSiteEffectModel.PolSourceSiteOrInfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            TVItemModel tvItemModelExist2 = _TVItemService.GetTVItemModelWithTVItemIDDB(polSourceSiteEffectModel.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist2.Error))
                return ReturnError(tvItemModelExist2.Error);

            if (polSourceSiteEffectModel.AnalysisDocumentTVItemID != null)
            {
                TVItemModel tvItemModelExist3 = _TVItemService.GetTVItemModelWithTVItemIDDB((int)polSourceSiteEffectModel.AnalysisDocumentTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelExist3.Error))
                    return ReturnError(tvItemModelExist3.Error);
            }

            PolSourceSiteEffect polSourceSiteEffectNew = new PolSourceSiteEffect();
            retStr = FillPolSourceSiteEffect(polSourceSiteEffectNew, polSourceSiteEffectModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return new PolSourceSiteEffectModel() { Error = retStr };
            }

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceSiteEffects.Add(polSourceSiteEffectNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSiteEffects", polSourceSiteEffectNew.PolSourceSiteEffectID, LogCommandEnum.Add, polSourceSiteEffectNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetPolSourceSiteEffectModelWithPolSourceSiteEffectIDDB(polSourceSiteEffectNew.PolSourceSiteEffectID);
        }
        public PolSourceSiteEffectModel PostDeletePolSourceSiteEffectDB(int PolSourceSiteEffectID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteEffect polSourceSiteEffectToDelete = GetPolSourceSiteEffectWithPolSourceSiteEffectIDDB(PolSourceSiteEffectID);
            if (polSourceSiteEffectToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceSiteEffect));

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceSiteEffects.Remove(polSourceSiteEffectToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSiteEffects", polSourceSiteEffectToDelete.PolSourceSiteEffectID, LogCommandEnum.Delete, polSourceSiteEffectToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public PolSourceSiteEffectModel PostUpdatePolSourceSiteEffectDB(PolSourceSiteEffectModel polSourceSiteEffectModel)
        {
            string retStr = PolSourceSiteEffectModelOK(polSourceSiteEffectModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteEffect polSourceSiteEffectToUpdate = GetPolSourceSiteEffectWithPolSourceSiteEffectIDDB(polSourceSiteEffectModel.PolSourceSiteEffectID);
            if (polSourceSiteEffectToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.PolSourceSiteEffect));

            retStr = FillPolSourceSiteEffect(polSourceSiteEffectToUpdate, polSourceSiteEffectModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSiteEffects", polSourceSiteEffectToUpdate.PolSourceSiteEffectID, LogCommandEnum.Change, polSourceSiteEffectToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetPolSourceSiteEffectModelWithPolSourceSiteEffectIDDB(polSourceSiteEffectToUpdate.PolSourceSiteEffectID);
        }
        public PolSourceSiteEffectModel PolSourceSiteEffectSetActiveDB(int TVItemID, bool SetActive)
        {
            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                return new PolSourceSiteEffectModel() { Error = tvItemModel.Error };
            }

            tvItemModel.IsActive = SetActive;
            TVItemModel tvItemModelRet = _TVItemService.PostUpdateTVItemDB(tvItemModel);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return new PolSourceSiteEffectModel() { Error = tvItemModelRet.Error };
            }

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        private List<PolSourceSiteEffectTermModel> FillPolSourceSiteEffectTermModelList(PolSourceSiteEffectModel polSourceSiteEffectModel, List<PolSourceSiteEffectTermModel> polSourceSiteEffectTermModelAllList)
        {
            List<PolSourceSiteEffectTermModel> polSourceSiteEffectTermModelList = new List<PolSourceSiteEffectTermModel>();
            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectModel.PolSourceSiteEffectTermIDs))
            {
                List<string> strList = polSourceSiteEffectModel.PolSourceSiteEffectTermIDs.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                polSourceSiteEffectModel.PolSourceSiteEffectTermModelList = new List<PolSourceSiteEffectTermModel>();

                foreach (string s in strList)
                {
                    if (int.TryParse(s, out int PolSourceSiteEffectTermID))
                    {
                        PolSourceSiteEffectTermModel polSourceSiteEffectTermModel = polSourceSiteEffectTermModelAllList.Where(c => c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID).FirstOrDefault();
                        if (polSourceSiteEffectTermModel != null)
                        {
                            polSourceSiteEffectTermModelList.Add(polSourceSiteEffectTermModel);
                        }
                    }
                }
            }

            return polSourceSiteEffectTermModelList;
        }

        #endregion Functions private
    }
}