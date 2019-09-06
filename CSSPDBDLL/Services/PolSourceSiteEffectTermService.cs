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
    public class PolSourceSiteEffectTermService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string PolSourceSiteEffectTermModelOK(PolSourceSiteEffectTermModel polSourceSiteEffectTermModel)
        {
            string retStr = FieldCheckNotNullBool(polSourceSiteEffectTermModel.IsGroup, ServiceRes.IsGroup);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(polSourceSiteEffectTermModel.UnderGroupID, ServiceRes.UnderGroupID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (GetPolSourceSiteEffectTermWithEffectTermENDB(polSourceSiteEffectTermModel.EffectTermEN))
            {
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.EffectTermEN);
            }

            retStr = FieldCheckIfNotNullMaxLengthString(polSourceSiteEffectTermModel.EffectTermEN, ServiceRes.EffectTermEN, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (GetPolSourceSiteEffectTermWithEffectTermFRDB(polSourceSiteEffectTermModel.EffectTermFR))
            {
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.EffectTermFR);
            }

            retStr = FieldCheckIfNotNullMaxLengthString(polSourceSiteEffectTermModel.EffectTermFR, ServiceRes.EffectTermFR, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillPolSourceSiteEffectTerm(PolSourceSiteEffectTerm polSourceSiteEffectTerm, PolSourceSiteEffectTermModel polSourceSiteEffectTermModel, ContactOK contactOK)
        {
            polSourceSiteEffectTerm.IsGroup = polSourceSiteEffectTermModel.IsGroup;
            polSourceSiteEffectTerm.UnderGroupID = polSourceSiteEffectTermModel.UnderGroupID;
            polSourceSiteEffectTerm.EffectTermEN = polSourceSiteEffectTermModel.EffectTermEN;
            polSourceSiteEffectTerm.EffectTermFR = polSourceSiteEffectTermModel.EffectTermFR;
            polSourceSiteEffectTerm.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                polSourceSiteEffectTerm.LastUpdateContactTVItemID = 2;
            }
            else
            {
                polSourceSiteEffectTerm.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetPolSourceSiteEffectTermModelCountDB()
        {
            int PolSourceSiteEffectTermModelCount = (from c in db.PolSourceSiteEffectTerms
                                                     select c).Count();

            return PolSourceSiteEffectTermModelCount;
        }
        public List<PolSourceSiteEffectTermModel> GetAllPolSourceSiteEffectTerm()
        {
            List<PolSourceSiteEffectTermModel> polSourceSiteEffectTermModelList = (from c in db.PolSourceSiteEffectTerms
                                                                                   select new PolSourceSiteEffectTermModel
                                                                                   {
                                                                                       Error = "",
                                                                                       PolSourceSiteEffectTermID = c.PolSourceSiteEffectTermID,
                                                                                       IsGroup = c.IsGroup,
                                                                                       UnderGroupID = c.UnderGroupID,
                                                                                       EffectTermEN = c.EffectTermEN,
                                                                                       EffectTermFR = c.EffectTermFR,
                                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                                   }).ToList<PolSourceSiteEffectTermModel>();

            return polSourceSiteEffectTermModelList;
        }
        public PolSourceSiteEffectTermModel GetPolSourceSiteEffectTermModelWithPolSourceSiteEffectTermIDDB(int PolSourceSiteEffectTermID)
        {
            PolSourceSiteEffectTermModel polSourceSiteEffectTermModel = (from c in db.PolSourceSiteEffectTerms
                                                                         where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                                                                         select new PolSourceSiteEffectTermModel
                                                                         {
                                                                             Error = "",
                                                                             PolSourceSiteEffectTermID = c.PolSourceSiteEffectTermID,
                                                                             IsGroup = c.IsGroup,
                                                                             UnderGroupID = c.UnderGroupID,
                                                                             EffectTermEN = c.EffectTermEN,
                                                                             EffectTermFR = c.EffectTermFR,
                                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                         }).FirstOrDefault<PolSourceSiteEffectTermModel>();

            if (polSourceSiteEffectTermModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.PolSourceSiteEffectTerm, ServiceRes.PolSourceSiteEffectTermID, PolSourceSiteEffectTermID));
            }

            return polSourceSiteEffectTermModel;
        }
        public PolSourceSiteEffectTerm GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermIDDB(int PolSourceSiteEffectTermID)
        {
            PolSourceSiteEffectTerm polSourceSiteEffectTerm = (from c in db.PolSourceSiteEffectTerms
                                                               where c.PolSourceSiteEffectTermID == PolSourceSiteEffectTermID
                                                               select c).FirstOrDefault<PolSourceSiteEffectTerm>();

            return polSourceSiteEffectTerm;
        }

        public bool GetPolSourceSiteEffectTermWithEffectTermENDB(string EffectTermEN)
        {
            return (from c in db.PolSourceSiteEffectTerms
                    where c.EffectTermEN == EffectTermEN
                    select c).Any();
        }
        public bool GetPolSourceSiteEffectTermWithEffectTermFRDB(string EffectTermFR)
        {
            return (from c in db.PolSourceSiteEffectTerms
                    where c.EffectTermFR == EffectTermFR
                    select c).Any();
        }

        // Helper
        public PolSourceSiteEffectTermModel ReturnError(string Error)
        {
            return new PolSourceSiteEffectTermModel() { Error = Error };
        }

        // Post
        public PolSourceSiteEffectTermModel PolSourceSiteEffectTermAddOrModifyDB(FormCollection fc)
        {
            int tempInt = 0;
            int PolSourceSiteEffectTermID = 0;
            bool IsGroup = false;
            int? UnderGroupID = 0;
            string EffectTermEN = "";
            string EffectTermFR = "";

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);


            if (string.IsNullOrWhiteSpace(fc["PolSourceSiteEffectTermID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteEffectTermID));

            int.TryParse(fc["PolSourceSiteEffectTermID"], out PolSourceSiteEffectTermID);

            // PolSourceSiteEffectTermID == 0 ==> Add 
            // PolSourceSiteEffectTermID > 0 ==> Modify

            PolSourceSiteEffectTermModel polSourceSiteEffectTermNewOrToChange = new PolSourceSiteEffectTermModel();

            if (PolSourceSiteEffectTermID != 0)
            {
                polSourceSiteEffectTermNewOrToChange = GetPolSourceSiteEffectTermModelWithPolSourceSiteEffectTermIDDB(PolSourceSiteEffectTermID);
                if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTermNewOrToChange.Error))
                    return ReturnError(polSourceSiteEffectTermNewOrToChange.Error);
            }

            if (string.IsNullOrWhiteSpace(fc["IsGroup"]))
            {
                IsGroup = false;
            }
            else
            {
                IsGroup = true;
            }

            if (!int.TryParse(fc["UnderGroupID"], out tempInt))
            {
                UnderGroupID = null;
            }
            else
            {
                UnderGroupID = tempInt;
            }

            if (IsGroup)
            {
                UnderGroupID = null;
            }

            if (string.IsNullOrWhiteSpace(fc["EffectTermEN"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EffectTermEN));

            EffectTermEN = fc["EffectTermEN"];

            if (GetPolSourceSiteEffectTermWithEffectTermENDB(EffectTermEN))
            {
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.EffectTermEN));
            }

            if (string.IsNullOrWhiteSpace(fc["EffectTermFR"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EffectTermFR));

            EffectTermFR = fc["EffectTermFR"];

            if (GetPolSourceSiteEffectTermWithEffectTermFRDB(EffectTermFR))
            {
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.EffectTermFR));
            }

            using (TransactionScope ts = new TransactionScope())
            {
                if (PolSourceSiteEffectTermID == 0)
                {
                    PolSourceSiteEffectTermModel polSourceSiteEffectTermModelNew = new PolSourceSiteEffectTermModel()
                    {
                        IsGroup = IsGroup,
                        UnderGroupID = UnderGroupID,
                        EffectTermEN = EffectTermEN,
                        EffectTermFR = EffectTermFR,
                    };

                    PolSourceSiteEffectTermModel polSourceSiteEffectTermModelRet = PostAddPolSourceSiteEffectTermDB(polSourceSiteEffectTermModelNew);
                    if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTermModelRet.Error))
                        return ReturnError(polSourceSiteEffectTermModelRet.Error);
                }
                else
                {
                    polSourceSiteEffectTermNewOrToChange.IsGroup = IsGroup;
                    polSourceSiteEffectTermNewOrToChange.UnderGroupID = UnderGroupID;
                    polSourceSiteEffectTermNewOrToChange.EffectTermEN = EffectTermEN;
                    polSourceSiteEffectTermNewOrToChange.EffectTermFR = EffectTermFR;

                    polSourceSiteEffectTermNewOrToChange = PostUpdatePolSourceSiteEffectTermDB(polSourceSiteEffectTermNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTermNewOrToChange.Error))
                        return ReturnError(polSourceSiteEffectTermNewOrToChange.Error);

                }

                ts.Complete();
            }
            return polSourceSiteEffectTermNewOrToChange;
        }
        public PolSourceSiteEffectTermModel PolSourceSiteEffectTermSetIsGroupDB(int PolSourceSiteEffectTermID, bool IsGroup)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteEffectTermModel polSourceSiteEffectTermToChange = GetPolSourceSiteEffectTermModelWithPolSourceSiteEffectTermIDDB(PolSourceSiteEffectTermID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTermToChange.Error))
                return ReturnError(polSourceSiteEffectTermToChange.Error);

            if (IsGroup == false)
            {
                List<PolSourceSiteEffectTermModel> polSourceSiteEffectTermModelList = GetAllPolSourceSiteEffectTerm();

                foreach (PolSourceSiteEffectTermModel polSourceSiteEffectTermModel in polSourceSiteEffectTermModelList)
                {
                    if (polSourceSiteEffectTermModel.UnderGroupID == PolSourceSiteEffectTermID)
                    {
                        polSourceSiteEffectTermModel.UnderGroupID = null;

                        PolSourceSiteEffectTermModel polSourceSiteEffectTermModelRet = PostUpdatePolSourceSiteEffectTermDB(polSourceSiteEffectTermModel);
                        if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTermModelRet.Error))
                            return ReturnError(polSourceSiteEffectTermModelRet.Error);
                    }
                }
            }
            else
            {
                polSourceSiteEffectTermToChange.UnderGroupID = null;
                polSourceSiteEffectTermToChange.IsGroup = IsGroup;
            }

            PolSourceSiteEffectTermModel polSourceSiteEffectTermToChangeRet = PostUpdatePolSourceSiteEffectTermDB(polSourceSiteEffectTermToChange);

            return polSourceSiteEffectTermToChangeRet;
        }
        public PolSourceSiteEffectTermModel PolSourceSiteEffectTermSendToGroupDB(int PolSourceSiteEffectTermID, int PolSourceSiteEffectTermIDGroup)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteEffectTermModel polSourceSiteEffectTermToChange = GetPolSourceSiteEffectTermModelWithPolSourceSiteEffectTermIDDB(PolSourceSiteEffectTermID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTermToChange.Error))
                return ReturnError(polSourceSiteEffectTermToChange.Error);

            PolSourceSiteEffectTermModel polSourceSiteEffectTermGroup = GetPolSourceSiteEffectTermModelWithPolSourceSiteEffectTermIDDB(PolSourceSiteEffectTermIDGroup);
            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectTermGroup.Error))
                return ReturnError(polSourceSiteEffectTermGroup.Error);


            if (polSourceSiteEffectTermGroup.IsGroup == false)
            {
                return ReturnError(ServiceRes.EffectTermToSendToGroupIsNotAGroup);
            }

            if (polSourceSiteEffectTermToChange.IsGroup == true)
            {
                return ReturnError(ServiceRes.EffectTermIsAlreadyAGroup);
            }

            polSourceSiteEffectTermToChange.IsGroup = false;
            polSourceSiteEffectTermToChange.UnderGroupID = polSourceSiteEffectTermGroup.UnderGroupID;
            PolSourceSiteEffectTermModel polSourceSiteEffectTermGroupRet = PostUpdatePolSourceSiteEffectTermDB(polSourceSiteEffectTermToChange);

            return polSourceSiteEffectTermGroupRet;
        }
        public PolSourceSiteEffectTermModel PostAddPolSourceSiteEffectTermDB(PolSourceSiteEffectTermModel polSourceSiteEffectTermModel)
        {
            string retStr = PolSourceSiteEffectTermModelOK(polSourceSiteEffectTermModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteEffectTerm polSourceSiteEffectTermNew = new PolSourceSiteEffectTerm();
            retStr = FillPolSourceSiteEffectTerm(polSourceSiteEffectTermNew, polSourceSiteEffectTermModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return new PolSourceSiteEffectTermModel() { Error = retStr };
            }

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceSiteEffectTerms.Add(polSourceSiteEffectTermNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSiteEffectTerms", polSourceSiteEffectTermNew.PolSourceSiteEffectTermID, LogCommandEnum.Add, polSourceSiteEffectTermNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetPolSourceSiteEffectTermModelWithPolSourceSiteEffectTermIDDB(polSourceSiteEffectTermNew.PolSourceSiteEffectTermID);
        }
        public PolSourceSiteEffectTermModel PostDeletePolSourceSiteEffectTermDB(int PolSourceSiteEffectTermID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteEffectTerm polSourceSiteEffectTermToDelete = GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermIDDB(PolSourceSiteEffectTermID);
            if (polSourceSiteEffectTermToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.PolSourceSiteEffectTerm));

            using (TransactionScope ts = new TransactionScope())
            {
                db.PolSourceSiteEffectTerms.Remove(polSourceSiteEffectTermToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSiteEffectTerms", polSourceSiteEffectTermToDelete.PolSourceSiteEffectTermID, LogCommandEnum.Delete, polSourceSiteEffectTermToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public PolSourceSiteEffectTermModel PostUpdatePolSourceSiteEffectTermDB(PolSourceSiteEffectTermModel polSourceSiteEffectTermModel)
        {
            string retStr = PolSourceSiteEffectTermModelOK(polSourceSiteEffectTermModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            PolSourceSiteEffectTerm polSourceSiteEffectTermToUpdate = GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermIDDB(polSourceSiteEffectTermModel.PolSourceSiteEffectTermID);
            if (polSourceSiteEffectTermToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.PolSourceSiteEffectTerm));

            retStr = FillPolSourceSiteEffectTerm(polSourceSiteEffectTermToUpdate, polSourceSiteEffectTermModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("PolSourceSiteEffectTerms", polSourceSiteEffectTermToUpdate.PolSourceSiteEffectTermID, LogCommandEnum.Change, polSourceSiteEffectTermToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetPolSourceSiteEffectTermModelWithPolSourceSiteEffectTermIDDB(polSourceSiteEffectTermToUpdate.PolSourceSiteEffectTermID);
        }
        public PolSourceSiteEffectTermModel PolSourceSiteEffectTermSetActiveDB(int TVItemID, bool SetActive)
        {
            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                return new PolSourceSiteEffectTermModel() { Error = tvItemModel.Error };
            }

            tvItemModel.IsActive = SetActive;
            TVItemModel tvItemModelRet = _TVItemService.PostUpdateTVItemDB(tvItemModel);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return new PolSourceSiteEffectTermModel() { Error = tvItemModelRet.Error };
            }

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}