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
    public class SpillService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public SpillLanguageService _SpillLanguageService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public SpillService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _SpillLanguageService = new SpillLanguageService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        public override string FieldCheckNotNullDateTime(DateTime? Value, string Res)
        {
            return base.FieldCheckNotNullDateTime(Value, Res);
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
        public string SpillModelOK(SpillModel spillModel)
        {
            string retStr = FieldCheckNotZeroInt(spillModel.MunicipalityTVItemID, ServiceRes.MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(spillModel.InfrastructureTVItemID, ServiceRes.InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(spillModel.SpillComment, ServiceRes.SpillComment, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(spillModel.StartDateTime_Local, ServiceRes.StartDateTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (spillModel.EndDateTime_Local != null)
            {
                if (spillModel.StartDateTime_Local > spillModel.EndDateTime_Local)
                {
                    return string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDateTime_Local, ServiceRes.EndDateTime_Local);
                }
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(spillModel.AverageFlow_m3_day, ServiceRes.AverageFlow_m3_day, 1, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(spillModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillSpill(Spill spill, SpillModel spillModel, ContactOK contactOK)
        {
            spill.DBCommand = (int)spillModel.DBCommand;
            spill.MunicipalityTVItemID = spillModel.MunicipalityTVItemID;
            spill.InfrastructureTVItemID = spillModel.InfrastructureTVItemID;
            spill.StartDateTime_Local = spillModel.StartDateTime_Local;
            spill.EndDateTime_Local = spillModel.EndDateTime_Local;
            spill.AverageFlow_m3_day = spillModel.AverageFlow_m3_day;
            spill.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                spill.LastUpdateContactTVItemID = 2;
            }
            else
            {
                spill.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetSpillModelCountDB()
        {
            int SpillModelCount = (from c in db.Spills
                                   select c).Count();

            return SpillModelCount;
        }
        public List<SpillModel> GetSpillModelListWithInfrastructureTVItemIDDB(int InfrastructureTVItemID)
        {
            List<SpillModel> SpillModelList = (from c in db.Spills
                                               let muniName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MunicipalityTVItemID select cl.TVText).FirstOrDefault<string>()
                                               let infrastructureName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.InfrastructureTVItemID select cl.TVText).FirstOrDefault<string>()
                                               let spillComment = (from cl in db.SpillLanguages where cl.Language == (int)LanguageRequest && cl.SpillID == c.SpillID select cl.SpillComment).FirstOrDefault<string>()
                                               where c.InfrastructureTVItemID == InfrastructureTVItemID
                                               orderby c.SpillID
                                               select new SpillModel
                                               {
                                                   Error = "",
                                                   SpillID = c.SpillID,
                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                   SpillComment = spillComment,
                                                   MunicipalityTVItemID = c.MunicipalityTVItemID,
                                                   MunicipalityTVText = muniName,
                                                   InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                   InfrastructureTVText = infrastructureName,
                                                   AverageFlow_m3_day = c.AverageFlow_m3_day,
                                                   EndDateTime_Local = c.EndDateTime_Local,
                                                   StartDateTime_Local = c.StartDateTime_Local,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                               }).ToList<SpillModel>();

            return SpillModelList;
        }
        public List<SpillModel> GetSpillModelListWithMunicipalityTVItemIDDB(int MunicipalityTVItemID)
        {
            List<SpillModel> SpillModelList = (from c in db.Spills
                                               let muniName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MunicipalityTVItemID select cl.TVText).FirstOrDefault<string>()
                                               let infrastructureName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.InfrastructureTVItemID select cl.TVText).FirstOrDefault<string>()
                                               let spillComment = (from cl in db.SpillLanguages where cl.Language == (int)LanguageRequest && cl.SpillID == c.SpillID select cl.SpillComment).FirstOrDefault<string>()
                                               where c.MunicipalityTVItemID == MunicipalityTVItemID
                                               orderby c.SpillID
                                               select new SpillModel
                                               {
                                                   Error = "",
                                                   SpillID = c.SpillID,
                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                   SpillComment = spillComment,
                                                   MunicipalityTVItemID = c.MunicipalityTVItemID,
                                                   MunicipalityTVText = muniName,
                                                   InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                   InfrastructureTVText = infrastructureName,
                                                   AverageFlow_m3_day = c.AverageFlow_m3_day,
                                                   EndDateTime_Local = c.EndDateTime_Local,
                                                   StartDateTime_Local = c.StartDateTime_Local,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                               }).ToList<SpillModel>();

            return SpillModelList;
        }
        public SpillModel GetSpillModelWithSpillIDDB(int SpillID)
        {
            SpillModel spillModel = (from c in db.Spills
                                     let muniName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MunicipalityTVItemID select cl.TVText).FirstOrDefault<string>()
                                     let infrastructureName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.InfrastructureTVItemID select cl.TVText).FirstOrDefault<string>()
                                     let spillComment = (from cl in db.SpillLanguages where cl.Language == (int)LanguageRequest && cl.SpillID == c.SpillID select cl.SpillComment).FirstOrDefault<string>()
                                     where c.SpillID == SpillID
                                     select new SpillModel
                                     {
                                         Error = "",
                                         SpillID = c.SpillID,
                                         DBCommand = (DBCommandEnum)c.DBCommand,
                                         SpillComment = spillComment,
                                         MunicipalityTVItemID = c.MunicipalityTVItemID,
                                         MunicipalityTVText = muniName,
                                         InfrastructureTVItemID = c.InfrastructureTVItemID,
                                         InfrastructureTVText = infrastructureName,
                                         AverageFlow_m3_day = c.AverageFlow_m3_day,
                                         EndDateTime_Local = c.EndDateTime_Local,
                                         StartDateTime_Local = c.StartDateTime_Local,
                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                     }).FirstOrDefault<SpillModel>();

            if (spillModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Spill, ServiceRes.SpillID, SpillID));

            return spillModel;
        }
        public Spill GetSpillWithSpillIDDB(int SpillID)
        {
            Spill spill = (from c in db.Spills
                           where c.SpillID == SpillID
                           select c).FirstOrDefault<Spill>();

            return spill;
        }
        public Spill GetSpillExistDB(SpillModel spillModel)
        {
            Spill spill = (from c in db.Spills
                           where c.MunicipalityTVItemID == spillModel.MunicipalityTVItemID
                           && c.InfrastructureTVItemID == spillModel.InfrastructureTVItemID
                           && c.StartDateTime_Local == spillModel.StartDateTime_Local
                           select c).FirstOrDefault<Spill>();

            return spill;
        }

        // Helper
        public SpillModel ReturnError(string Error)
        {
            return new SpillModel() { Error = Error };
        }

        // Post
        public SpillModel PostAddSpillDB(SpillModel spillModel)
        {
            string retStr = SpillModelOK(spillModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelMunicipality = _TVItemService.GetTVItemModelWithTVItemIDDB(spillModel.MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                return ReturnError(tvItemModelMunicipality.Error);

            if (spillModel.InfrastructureTVItemID != null)
            {
                TVItemModel tvItemModelInfrastructure = _TVItemService.GetTVItemModelWithTVItemIDDB((int)spillModel.InfrastructureTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
                    return ReturnError(tvItemModelInfrastructure.Error);
            }

            Spill spillExist = GetSpillExistDB(spillModel);
            if (spillExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.Spill));

            Spill spillNew = new Spill();
            retStr = FillSpill(spillNew, spillModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.Spills.Add(spillNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Spills", spillNew.SpillID, LogCommandEnum.Add, spillNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    SpillLanguageModel spillLanguageModel = new SpillLanguageModel()
                    {
                        SpillID = spillNew.SpillID,
                        Language = Lang,
                        SpillComment = spillModel.SpillComment,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    SpillLanguageModel spillLanguageModelRet = _SpillLanguageService.PostAddSpillLanguageDB(spillLanguageModel);
                    if (!string.IsNullOrEmpty(spillLanguageModelRet.Error))
                        return ReturnError(spillLanguageModelRet.Error);
                }

                ts.Complete();
            }
            return GetSpillModelWithSpillIDDB(spillNew.SpillID);
        }
        public SpillModel PostDeleteSpillDB(int SpillID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);


            Spill spillToDelete = GetSpillWithSpillIDDB(SpillID);
            if (spillToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Spill));

            using (TransactionScope ts = new TransactionScope())
            {
                db.Spills.Remove(spillToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Spills", spillToDelete.SpillID, LogCommandEnum.Delete, spillToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public SpillModel PostUpdateSpillDB(SpillModel spillModel)
        {
            string retStr = SpillModelOK(spillModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelMunicipality = _TVItemService.GetTVItemModelWithTVItemIDDB(spillModel.MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                return ReturnError(tvItemModelMunicipality.Error);

            if (spillModel.InfrastructureTVItemID != null)
            {
                TVItemModel tvItemModelInfrastructure = _TVItemService.GetTVItemModelWithTVItemIDDB((int)spillModel.InfrastructureTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
                    return ReturnError(tvItemModelInfrastructure.Error);
            }

            Spill spillToUpdate = GetSpillWithSpillIDDB(spillModel.SpillID);
            if (spillToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Spill));

            retStr = FillSpill(spillToUpdate, spillModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Spills", spillToUpdate.SpillID, LogCommandEnum.Change, spillToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        SpillLanguageModel spillLanguageModel = new SpillLanguageModel()
                        {
                            SpillID = spillModel.SpillID,
                            Language = Lang,
                            SpillComment = spillModel.SpillComment,
                            TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                        };

                        SpillLanguageModel spillLanguageModelRet = _SpillLanguageService.PostUpdateSpillLanguageDB(spillLanguageModel);
                        if (!string.IsNullOrEmpty(spillLanguageModelRet.Error))
                            return ReturnError(spillLanguageModelRet.Error);
                    }
                }

                ts.Complete();
            }
            return GetSpillModelWithSpillIDDB(spillToUpdate.SpillID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
