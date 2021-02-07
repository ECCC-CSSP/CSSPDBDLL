using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web;
using System.IO;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPDHI;
using Newtonsoft.Json;

namespace CSSPDBDLL.Services
{
    public class MikeScenarioResultService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public AppTaskService _AppTaskService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public MikeSourceService _MikeSourceService { get; private set; }
        public MikeBoundaryConditionService _MikeBoundaryConditionService { get; private set; }
        public TideSiteService _TideSiteService { get; private set; }
        public TVFileService _TVFileService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        public MWQMRunService _MWQMRunService { get; private set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _MikeSourceService = new MikeSourceService(LanguageRequest, User);
            _MikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, User);
            _TideSiteService = new TideSiteService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _MWQMRunService = new MWQMRunService(LanguageRequest, User);
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
        public string MikeScenarioResultModelOK(MikeScenarioResultModel mikeScenarioResultModel)
        {
            string retStr = FieldCheckNotZeroInt(mikeScenarioResultModel.MikeScenarioTVItemID, ServiceRes.MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(mikeScenarioResultModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMikeScenarioResult(MikeScenarioResult mikeScenarioResult, MikeScenarioResultModel mikeScenarioResultModel, ContactOK contactOK)
        {
            mikeScenarioResult.DBCommand = (int)mikeScenarioResultModel.DBCommand;
            mikeScenarioResult.MikeScenarioTVItemID = mikeScenarioResultModel.MikeScenarioTVItemID;
            mikeScenarioResult.MikeResultsJSON = mikeScenarioResultModel.MikeResultsJSON;
            mikeScenarioResult.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mikeScenarioResult.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mikeScenarioResult.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMikeScenarioResultModelCountDB()
        {
            int MikeScenarioResultModelCount = (from c in db.MikeScenarioResults
                                                select c).Count();

            return MikeScenarioResultModelCount;
        }
        public MikeScenarioResultModel GetMikeScenarioResultModelWithMikeScenarioResultIDDB(int MikeScenarioResultID)
        {
            MikeScenarioResultModel mikeScenarioResultModel = (from c in db.MikeScenarioResults
                                                               let tvText = (from bl in db.TVItemLanguages where bl.Language == (int)LanguageRequest && bl.TVItemID == c.MikeScenarioTVItemID select bl.TVText).FirstOrDefault<string>()
                                                               where c.MikeScenarioResultID == MikeScenarioResultID
                                                               select new MikeScenarioResultModel
                                                               {
                                                                   Error = "",
                                                                   MikeScenarioResultID = c.MikeScenarioResultID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   MikeScenarioTVItemID = c.MikeScenarioTVItemID,
                                                                   MikeScenarioTVText = tvText,
                                                                   MikeResultsJSON = c.MikeResultsJSON,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).FirstOrDefault<MikeScenarioResultModel>();

            if (mikeScenarioResultModel == null)
                return ReturnMikeScenarioResultError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeScenarioResult, ServiceRes.MikeScenarioResultID, MikeScenarioResultID));

            return mikeScenarioResultModel;
        }
        public MikeScenarioResultModel GetMikeScenarioResultModelWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            MikeScenarioResultModel mikeScenarioResultModel = (from c in db.MikeScenarioResults
                                                               let tvText = (from bl in db.TVItemLanguages where bl.Language == (int)LanguageRequest && bl.TVItemID == c.MikeScenarioTVItemID select bl.TVText).FirstOrDefault<string>()
                                                               where c.MikeScenarioTVItemID == MikeScenarioTVItemID
                                                               select new MikeScenarioResultModel
                                                               {
                                                                   Error = "",
                                                                   MikeScenarioResultID = c.MikeScenarioResultID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   MikeScenarioTVItemID = c.MikeScenarioTVItemID,
                                                                   MikeScenarioTVText = tvText,
                                                                   MikeResultsJSON = c.MikeResultsJSON,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).FirstOrDefault<MikeScenarioResultModel>();

            if (mikeScenarioResultModel == null)
                return ReturnMikeScenarioResultError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeScenarioResult, ServiceRes.MikeScenarioTVItemID, MikeScenarioTVItemID));

            return mikeScenarioResultModel;
        }
        public MikeScenarioResult GetMikeScenarioResultWithMikeScenarioResultIDDB(int MikeScenarioResultID)
        {
            MikeScenarioResult mikeScenarioResult = (from c in db.MikeScenarioResults
                                                     where c.MikeScenarioResultID == MikeScenarioResultID
                                                     select c).FirstOrDefault<MikeScenarioResult>();

            return mikeScenarioResult;
        }
        public MikeScenarioResult GetMikeScenarioResultWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            MikeScenarioResult mikeScenarioResult = (from c in db.MikeScenarioResults
                                                     where c.MikeScenarioTVItemID == MikeScenarioTVItemID
                                                     select c).FirstOrDefault<MikeScenarioResult>();

            return mikeScenarioResult;
        }
        public MIKEResult GetMikeScenarioMIKEResultJSONWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            string MIKEResultStr = (from c in db.MikeScenarioResults
                                    where c.MikeScenarioTVItemID == MikeScenarioTVItemID
                                    select c.MikeResultsJSON).FirstOrDefault();

            MIKEResult mikeResult = JsonConvert.DeserializeObject<MIKEResult>(MIKEResultStr);

            return mikeResult;
        }

        public AppTaskModel ReturnAppTaskError(string Error)
        {
            return new AppTaskModel() { Error = Error };
        }
        public MapInfoPointModel ReturnMapInfoPointError(string Error)
        {
            return new MapInfoPointModel() { Error = Error };
        }
        public MikeScenarioResultModel ReturnMikeScenarioResultError(string Error)
        {
            return new MikeScenarioResultModel() { Error = Error };
        }
        public MikeSourceModel ReturnMikeSourceError(string Error)
        {
            return new MikeSourceModel() { Error = Error };
        }
        public MikeSourceStartEndModel ReturnMikeSourceStartEndError(string Error)
        {
            return new MikeSourceStartEndModel() { Error = Error };
        }
        public TVFileModel ReturnTVFileError(string Error)
        {
            return new TVFileModel() { Error = Error };
        }
        public TVItemModel ReturnTVItemError(string Error)
        {
            return new TVItemModel() { Error = Error };
        }

        // Post AppTask

        // Post Normal
        public MikeScenarioResultModel PostAddMikeScenarioResultDB(MikeScenarioResultModel mikeScenarioResultModel)
        {
            string retStr = MikeScenarioResultModelOK(mikeScenarioResultModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMikeScenarioResultError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnMikeScenarioResultError(contactOK.Error);

            TVItemModel tvItemModelMikeScenarioResult = _TVItemService.GetTVItemModelWithTVItemIDDB(mikeScenarioResultModel.MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenarioResult.Error))
                return ReturnMikeScenarioResultError(tvItemModelMikeScenarioResult.Error);

            MikeScenarioResult mikeScenarioResultNew = new MikeScenarioResult();

            retStr = FillMikeScenarioResult(mikeScenarioResultNew, mikeScenarioResultModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMikeScenarioResultError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MikeScenarioResults.Add(mikeScenarioResultNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnMikeScenarioResultError(retStr);

                ts.Complete();
            }

            return GetMikeScenarioResultModelWithMikeScenarioResultIDDB(mikeScenarioResultNew.MikeScenarioResultID);

        }
        public MikeScenarioResultModel PostDeleteMikeScenarioResultWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnMikeScenarioResultError(contactOK.Error);

            MikeScenarioResult mikeScenarioResultToDelete = GetMikeScenarioResultWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (mikeScenarioResultToDelete == null)
                return ReturnMikeScenarioResultError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeScenarioResult));

            db.MikeScenarioResults.Remove(mikeScenarioResultToDelete);
            string retStr = DoDeleteChanges();
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMikeScenarioResultError(retStr);

            return ReturnMikeScenarioResultError("");
        }
        public MikeScenarioResultModel PostUpdateMikeScenarioResultDB(MikeScenarioResultModel mikeScenarioResultModel)
        {
            string retStr = MikeScenarioResultModelOK(mikeScenarioResultModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnMikeScenarioResultError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnMikeScenarioResultError(contactOK.Error);

            MikeScenarioResult mikeScenarioResultToUpdate = GetMikeScenarioResultWithMikeScenarioResultIDDB(mikeScenarioResultModel.MikeScenarioResultID);
            if (mikeScenarioResultToUpdate == null)
                return ReturnMikeScenarioResultError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeScenarioResult));

            TVItemModel tvItemModelMikeScenarioResult = _TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(mikeScenarioResultModel.MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenarioResult.Error))
                return ReturnMikeScenarioResultError(tvItemModelMikeScenarioResult.Error);

            retStr = FillMikeScenarioResult(mikeScenarioResultToUpdate, mikeScenarioResultModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMikeScenarioResultError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnMikeScenarioResultError(retStr);

                ts.Complete();
            }

            return GetMikeScenarioResultModelWithMikeScenarioResultIDDB(mikeScenarioResultToUpdate.MikeScenarioResultID);
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
