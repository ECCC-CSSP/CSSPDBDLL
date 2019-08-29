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
    public class TideSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public AppTaskService _AppTaskService { get; private set; }
        public MikeBoundaryConditionService _MikeBoundaryConditionService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TideSiteService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _MikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, User);
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
        public string TideSiteModelOK(TideSiteModel tideSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(tideSiteModel.TideSiteTVItemID, ServiceRes.TideSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(tideSiteModel.TideSiteName, ServiceRes.TideSiteName, 3, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(tideSiteModel.Province, ServiceRes.Province, 2, 2);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(tideSiteModel.sid, ServiceRes.sid, 0, 1000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(tideSiteModel.Zone, ServiceRes.Zone, 0, 1000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }


            return "";
        }

        // Fill
        public string FillTideSite(TideSite tideSiteNew, TideSiteModel tideSiteModel, ContactOK contactOK)
        {
            tideSiteNew.TideSiteTVItemID = tideSiteModel.TideSiteTVItemID;
            tideSiteNew.TideSiteName = tideSiteModel.TideSiteName;
            tideSiteNew.Province = tideSiteModel.Province;
            tideSiteNew.sid = tideSiteModel.sid;
            tideSiteNew.Zone = tideSiteModel.Zone;
            tideSiteNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tideSiteNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tideSiteNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetTideSiteModelCountDB()
        {
            int TideSiteModelCount = (from c in db.TideSites
                                      select c).Count();

            return TideSiteModelCount;
        }
        public TideSiteModel GetTideSiteModelWithTideSiteIDDB(int TideSiteID)
        {
            TideSiteModel tideSiteModel = (from c in db.TideSites
                                           let tideSiteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TideSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                           where c.TideSiteID == TideSiteID
                                           select new TideSiteModel
                                           {
                                               Error = "",
                                               TideSiteID = c.TideSiteID,
                                               TideSiteTVItemID = c.TideSiteTVItemID,
                                               TideSiteName = tideSiteName,
                                               Province = c.Province,
                                               sid = c.sid,
                                               Zone = c.Zone,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<TideSiteModel>();

            if (tideSiteModel == null)
                return ReturnTideSiteError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideSite, ServiceRes.TideSiteID, TideSiteID));

            return tideSiteModel;
        }
        public TideSiteModel GetTideSiteModelExistDB(TideSiteModel tideSiteModel)
        {
            TideSiteModel tideSiteModelExist = (from c in db.TideSites
                                           let tideSiteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TideSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                           where c.Province == tideSiteModel.Province
                                           && c.sid == tideSiteModel.sid
                                           && c.Zone == tideSiteModel.Zone
                                           && c.TideSiteName == tideSiteModel.TideSiteName
                                           select new TideSiteModel
                                           {
                                               Error = "",
                                               TideSiteID = c.TideSiteID,
                                               TideSiteTVItemID = c.TideSiteTVItemID,
                                               TideSiteName = tideSiteName,
                                               Province = c.Province,
                                               sid = c.sid,
                                               Zone = c.Zone,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<TideSiteModel>();

            if (tideSiteModelExist == null)
                return ReturnTideSiteError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideSite, 
                    ServiceRes.Province + "," +
                    ServiceRes.sid + "," +
                    ServiceRes.Zone + "," +
                    ServiceRes.TideSiteName,
                    tideSiteModel.Province + "," +
                    tideSiteModel.sid + "," +
                    tideSiteModel.Zone + "," +
                    tideSiteModel.TideSiteName));

            return tideSiteModelExist;
        }
        public TideSiteModel GetTideSiteModelWithTideSiteTVItemIDDB(int TideSiteTVItemID)
        {
            TideSiteModel tideSiteModel = (from c in db.TideSites
                                           let tideSiteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TideSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                           where c.TideSiteTVItemID == TideSiteTVItemID
                                           orderby c.TideSiteID descending
                                           select new TideSiteModel
                                           {
                                               Error = "",

                                               TideSiteID = c.TideSiteID,
                                               TideSiteTVItemID = c.TideSiteTVItemID,
                                               TideSiteName = tideSiteName,
                                               Province = c.Province,
                                               sid = c.sid,
                                               Zone = c.Zone,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<TideSiteModel>();

            if (tideSiteModel == null)
                return ReturnTideSiteError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TideSite, ServiceRes.TideSiteTVItemID, TideSiteTVItemID));

            return tideSiteModel;
        }
        public TideSite GetTideSiteWithTideSiteIDDB(int TideSiteID)
        {
            TideSite TideSite = (from c in db.TideSites
                                 where c.TideSiteID == TideSiteID
                                 select c).FirstOrDefault<TideSite>();

            return TideSite;
        }
        public List<DataPathOfTide> GetTideDataPathsDB()
        {
            List<DataPathOfTide> dataPathOfTideList = new List<DataPathOfTide>();

            //Arctic
            DataPathOfTide dataPathOfTide9 = new DataPathOfTide();
            dataPathOfTide9.Text = ServiceRes.Arctic;
            dataPathOfTide9.WebTideDataSet = WebTideDataSetEnum.arctic9;
            dataPathOfTideList.Add(dataPathOfTide9);

            // Brador
            DataPathOfTide dataPathOfTide2 = new DataPathOfTide();
            dataPathOfTide2.Text = ServiceRes.BrasdOrLake;
            dataPathOfTide2.WebTideDataSet = WebTideDataSetEnum.brador;
            dataPathOfTideList.Add(dataPathOfTide2);

            // Global (LEGOS France)
            DataPathOfTide dataPathOfTide10 = new DataPathOfTide();
            dataPathOfTide10.Text = ServiceRes.GlobalLEGOS;
            dataPathOfTide10.WebTideDataSet = WebTideDataSetEnum.HRglobal;
            dataPathOfTideList.Add(dataPathOfTide10);

            // Halifax Harbour
            DataPathOfTide dataPathOfTide3 = new DataPathOfTide();
            dataPathOfTide3.Text = ServiceRes.HalifaxHarbour;
            dataPathOfTide3.WebTideDataSet = WebTideDataSetEnum.h3o;
            dataPathOfTideList.Add(dataPathOfTide3);

            //Hudson Bay (IML) 
            DataPathOfTide dataPathOfTide6 = new DataPathOfTide();
            dataPathOfTide6.Text = ServiceRes.HudsonBayIML;
            dataPathOfTide6.WebTideDataSet = WebTideDataSetEnum.hudson;
            dataPathOfTideList.Add(dataPathOfTide6);

            //North East Pacific (IOS)
            DataPathOfTide dataPathOfTide8 = new DataPathOfTide();
            dataPathOfTide8.Text = ServiceRes.NorthEastPacificIOS;
            dataPathOfTide8.WebTideDataSet = WebTideDataSetEnum.ne_pac4;
            dataPathOfTideList.Add(dataPathOfTide8);

            // North West Atlantic 
            DataPathOfTide dataPathOfTide5 = new DataPathOfTide();
            dataPathOfTide5.Text = ServiceRes.NorthWestAtlantic;
            dataPathOfTide5.WebTideDataSet = WebTideDataSetEnum.nwatl;
            dataPathOfTideList.Add(dataPathOfTide5);

            //Quatsino Sound
            DataPathOfTide dataPathOfTide7 = new DataPathOfTide();
            dataPathOfTide7.Text = ServiceRes.QuatsinoSound;
            dataPathOfTide7.WebTideDataSet = WebTideDataSetEnum.QuatsinoModel14;
            dataPathOfTideList.Add(dataPathOfTide7);

            // Scotian Fundy Maine
            DataPathOfTide dataPathOfTide4 = new DataPathOfTide();
            dataPathOfTide4.Text = ServiceRes.ScotianFundyMaine;
            dataPathOfTide4.WebTideDataSet = WebTideDataSetEnum.sshelf;
            dataPathOfTideList.Add(dataPathOfTide4);

            // Upper Bay of Fundy
            DataPathOfTide dataPathOfTide1 = new DataPathOfTide();
            dataPathOfTide1.Text = ServiceRes.UpperBayFundy;
            dataPathOfTide1.WebTideDataSet = WebTideDataSetEnum.flood;
            dataPathOfTideList.Add(dataPathOfTide1);

            // Vancouver Island (Mike Foreman)
            DataPathOfTide dataPathOfTide11 = new DataPathOfTide();
            dataPathOfTide11.Text = ServiceRes.VancouverIslandMF;
            dataPathOfTide11.WebTideDataSet = WebTideDataSetEnum.vigf8;
            dataPathOfTideList.Add(dataPathOfTide11);

            return dataPathOfTideList;
        }

        // Helper
        public string CreateTVText(TideSiteModel tideSiteModel)
        {
            return tideSiteModel.TideSiteName;
        }
        public TideSiteModel ReturnTideSiteError(string Error)
        {
            return new TideSiteModel() { Error = Error };
        }
        public AppTaskModel ReturnAppTaskError(string Error)
        {
            return new AppTaskModel() { Error = Error };
        }

        // Post
        public AppTaskModel GenerateWebTideDB(int MikeScenarioTVItemID, int BCMeshTVItemID, int WebTideNodeNumb)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnAppTaskError(contactOK.Error);

            if (MikeScenarioTVItemID < 1)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            if (BCMeshTVItemID < 1)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.BCMeshTVItemID));
            
            if (WebTideNodeNumb < 1)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.WTNodeNumb));

            TVItemModel tvItemModelMikeBoundaryCondition = _TVItemService.GetTVItemModelWithTVItemIDDB(BCMeshTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeBoundaryCondition.Error))
                return ReturnAppTaskError(tvItemModelMikeBoundaryCondition.Error);

            TVItemModel tvItemModelMikeScenario = _TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenario.Error))
                return ReturnAppTaskError(tvItemModelMikeScenario.Error); 
            
            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "MikeScenarioTVItemID", Value = MikeScenarioTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "BCMeshTVItemID", Value = BCMeshTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "WebTideNodeNumb", Value = WebTideNodeNumb.ToString() });

            StringBuilder sbParameters = new StringBuilder();
            int count = 0;
            foreach (AppTaskParameter atp in appTaskParameterList)
            {
                if (count == 0)
                {
                    sbParameters.Append("|||");
                }
                sbParameters.Append(atp.Name + "," + atp.Value + "|||");
                count += 1;
            }

            AppTaskModel appTaskModelNew = new AppTaskModel()
            {
                TVItemID = MikeScenarioTVItemID,
                TVItemID2 = MikeScenarioTVItemID,
                AppTaskCommand = AppTaskCommandEnum.GenerateWebTide,
                ErrorText = "",
                StatusText = ServiceRes.GeneratingWebTideNodes,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = sbParameters.ToString(),
                Language = LanguageRequest,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
            };

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(appTaskModelNew.TVItemID, appTaskModelNew.TVItemID, appTaskModelNew.AppTaskCommand);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return ReturnAppTaskError(string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask));

            AppTaskModel appTaskModelRet = _AppTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                return ReturnAppTaskError(appTaskModelRet.Error);

            return appTaskModelRet;
        }
        public string ResetWebTideDB(int MikeScenarioTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return contactOK.Error;

            if (MikeScenarioTVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID);

            using (TransactionScope ts = new TransactionScope())
            {
                List<MikeBoundaryConditionModel> mikeBoundaryConditionModelListMeshToDelete = _MikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);

                foreach (MikeBoundaryConditionModel mikeBoundaryConditionModel in mikeBoundaryConditionModelListMeshToDelete)
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = _MikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModel.MikeBoundaryConditionID);
                    if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionModelRet.Error))
                        return mikeBoundaryConditionModelRet.Error;
                }

                List<MikeBoundaryConditionModel> mikeBoundaryConditionModelListWebTideToDelete = _MikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionWebTide);
                foreach (MikeBoundaryConditionModel mikeBoundaryConditionModel in mikeBoundaryConditionModelListWebTideToDelete)
                {
                    MikeBoundaryConditionModel mikeBoundaryConditionModelRet = _MikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModel.MikeBoundaryConditionID);
                    if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionModelRet.Error))
                        return mikeBoundaryConditionModelRet.Error;
                }

                ts.Complete();
            }

            return "";

        }
        public AppTaskModel SetupWebTideDB(int MikeScenarioTVItemID, int WebTideDataSet)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnAppTaskError(contactOK.Error);

            if (MikeScenarioTVItemID == 0)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            if (WebTideDataSet == 0)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.WebTideDataSet));

            WebTideDataSetEnum webTideDataSet = (WebTideDataSetEnum)WebTideDataSet;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(MikeScenarioTVItemID, MikeScenarioTVItemID, AppTaskCommandEnum.SetupWebTide);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return ReturnAppTaskError(string.Format(ServiceRes.TaskOf_AlreadyRunning, AppTaskCommandEnum.SetupWebTide.ToString()));

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "MikeScenarioTVItemID", Value = MikeScenarioTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "WebTideDataSet", Value = ((int)(WebTideDataSetEnum)WebTideDataSet).ToString() });

            StringBuilder sbParameters = new StringBuilder();
            int count = 0;
            foreach (AppTaskParameter atp in appTaskParameterList)
            {
                if (count == 0)
                {
                    sbParameters.Append("|||");
                }
                sbParameters.Append(atp.Name + "," + atp.Value + "|||");
                count += 1;
            }

            AppTaskModel appTaskModelNew = new AppTaskModel()
            {
                TVItemID = MikeScenarioTVItemID,
                TVItemID2 = MikeScenarioTVItemID,
                AppTaskCommand = AppTaskCommandEnum.SetupWebTide,
                ErrorText = "",
                StatusText = ServiceRes.SettingBoundaryConditions,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = sbParameters.ToString(),
                Language = LanguageRequest,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
            };

            AppTaskModel appTaskModelRet = _AppTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                return ReturnAppTaskError(appTaskModelRet.Error);

            return appTaskModelRet;
        }

        public TideSiteModel PostAddTideSiteDB(TideSiteModel tideSiteModel)
        {
            string retStr = TideSiteModelOK(tideSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnTideSiteError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnTideSiteError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(tideSiteModel.TideSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnTideSiteError(tvItemModelExist.Error);

            TideSite tideSiteNew = new TideSite();
            retStr = FillTideSite(tideSiteNew, tideSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnTideSiteError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TideSites.Add(tideSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnTideSiteError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TideSites", tideSiteNew.TideSiteID, LogCommandEnum.Add, tideSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnTideSiteError(logModel.Error);

                ts.Complete();
            }
            return GetTideSiteModelWithTideSiteIDDB(tideSiteNew.TideSiteID);
        }
        public TideSiteModel PostDeleteTideSiteDB(int TideSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnTideSiteError(contactOK.Error);

            TideSite tideSiteToDelete = GetTideSiteWithTideSiteIDDB(TideSiteID);
            if (tideSiteToDelete == null)
                return ReturnTideSiteError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TideSite));

            int TVItemIDToDelete = tideSiteToDelete.TideSiteTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.TideSites.Remove(tideSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnTideSiteError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TideSites", tideSiteToDelete.TideSiteID, LogCommandEnum.Delete, tideSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnTideSiteError(logModel.Error);

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnTideSiteError(tvItemModelRet.Error);

                ts.Complete();
            }

            return ReturnTideSiteError("");
        }
        public TideSiteModel PostUpdateTideSiteDB(TideSiteModel tideSiteModel)
        {
            string retStr = TideSiteModelOK(tideSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnTideSiteError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnTideSiteError(contactOK.Error);

            TideSite tideSiteToUpdate = GetTideSiteWithTideSiteIDDB(tideSiteModel.TideSiteID);
            if (tideSiteToUpdate == null)
                return ReturnTideSiteError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TideSite));

            retStr = FillTideSite(tideSiteToUpdate, tideSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnTideSiteError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnTideSiteError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TideSites", tideSiteToUpdate.TideSiteID, LogCommandEnum.Change, tideSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnTideSiteError(logModel.Error);

                ts.Complete();
            }
            return GetTideSiteModelWithTideSiteIDDB(tideSiteToUpdate.TideSiteID);
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
