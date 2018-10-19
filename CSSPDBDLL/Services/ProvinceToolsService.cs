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
using System.IO;

namespace CSSPDBDLL.Services
{
    public class ProvinceToolsService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public TVFileService _TVFileService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public PolSourceSiteService _PolSourceSiteService { get; private set; }
        public PolSourceObservationService _PolSourceObservationService { get; private set; }
        public PolSourceObservationIssueService _PolSourceObservationIssueService { get; private set; }

        #endregion Properties

        #region Constructors
        public ProvinceToolsService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _PolSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
            _PolSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
            _PolSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        public TVItemModel ReturnError(string Error)
        {
            return new TVItemModel() { Error = Error };
        }

        #region Functions Precipitation 
        public AppTaskModel GetAllPrecipitationForYearDB(int ProvinceTVItemID, int Year)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, Year, AppTaskCommandEnum.GetAllPrecipitationForYear);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "Year", Value = Year.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = Year,
                AppTaskCommand = AppTaskCommandEnum.GetAllPrecipitationForYear,
                ErrorText = "",
                StatusText = ServiceRes.GetAllPrecipitationForYear,
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

            return appTaskModelRet;
        }
        public AppTaskModel FillRunPrecipByClimateSitePriorityForYearDB(int ProvinceTVItemID, int Year)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, Year, AppTaskCommandEnum.FillRunPrecipByClimateSitePriorityForYear);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "Year", Value = Year.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = Year,
                AppTaskCommand = AppTaskCommandEnum.FillRunPrecipByClimateSitePriorityForYear,
                ErrorText = "",
                StatusText = ServiceRes.FillRunPrecipByClimateSitePriorityForYear,
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

            return appTaskModelRet;

        }
        public AppTaskModel FindMissingPrecipForProvinceDB(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.FindMissingPrecipForProvince);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.FindMissingPrecipForProvince,
                ErrorText = "",
                StatusText = ServiceRes.FindMissingPrecipForProvince + " " + ServiceRes.CreatingFileMissingDateTimeDotCSV,
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

            return appTaskModelRet;
        }
        #endregion Functions Precipitation

        #region Functions Classification

        public string GetInit(int ProvinceTVItemID)
        {
            string Init = "XX";

            TVItemModel tvItemModelProv = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProv.Error))
            {
                return Init;
            }

            switch (tvItemModelProv.TVText)
            {
                case "British Columbia":
                case "Colombie-Britannique":
                    Init = "BC";
                    break;
                case "New Brunswick":
                case "Nouveau-Brunswick":
                    Init = "NB";
                    break;
                case "Newfoundland and Labrador":
                case "Terre-Neuve-et-Labrador":
                    Init = "NL";
                    break;
                case "Nova Scotia":
                case "Nouvelle-Écosse":
                    Init = "NS";
                    break;
                case "Prince Edward Island":
                case "Île-du-Prince-Édouard":
                    Init = "PE";
                    break;
                case "Québec":
                case "Quebec":
                    Init = "QC";
                    break;
                case "Maine":
                    Init = "ME";
                    break;
                default:
                    break;
            }

            return Init;
        }
        public TVFileModel GetTVFileModelClassificationPolygons(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelProv = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProv.Error))
            {
                return new TVFileModel() { Error = tvItemModelProv.Error };
            }

            if (tvItemModelProv.TVType != TVTypeEnum.Province)
            {
                return new TVFileModel() { Error = string.Format(ServiceRes.ShouldContainTVTypeOf_, TVTypeEnum.Province.ToString()) };
            }

            string Init = GetInit(ProvinceTVItemID);

            string ServerPath = _TVFileService.GetServerFilePath(ProvinceTVItemID);

            string FileName = $"ClassificationPolygons_{Init}.kml";

            TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithServerFilePathAndServerFileNameDB(ServerPath, FileName);
            if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
            {
                return new TVFileModel() { Error = tvFileModel.Error };
            }

            return tvFileModel;
        }
        public TVFileModel GetTVFileModelClassificationInputs(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelProv = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProv.Error))
            {
                return new TVFileModel() { Error = tvItemModelProv.Error };
            }

            if (tvItemModelProv.TVType != TVTypeEnum.Province)
            {
                return new TVFileModel() { Error = string.Format(ServiceRes.ShouldContainTVTypeOf_, TVTypeEnum.Province.ToString()) };
            }

            string Init = GetInit(ProvinceTVItemID);

            string ServerPath = _TVFileService.GetServerFilePath(ProvinceTVItemID);

            string FileName = $"ClassificationInputs_{Init}.kml";

            TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithServerFilePathAndServerFileNameDB(ServerPath, FileName);
            if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
            {
                return new TVFileModel() { Error = tvFileModel.Error };
            }

            return tvFileModel;
        }
        public TVFileModel GetTVFileModelGroupingInputs(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelProv = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProv.Error))
            {
                return new TVFileModel() { Error = tvItemModelProv.Error };
            }

            if (tvItemModelProv.TVType != TVTypeEnum.Province)
            {
                return new TVFileModel() { Error = string.Format(ServiceRes.ShouldContainTVTypeOf_, TVTypeEnum.Province.ToString()) };
            }

            string Init = GetInit(ProvinceTVItemID);

            string ServerPath = _TVFileService.GetServerFilePath(ProvinceTVItemID);

            string FileName = $"GroupingInputs_{Init}.kml";

            TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithServerFilePathAndServerFileNameDB(ServerPath, FileName);
            if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
            {
                return new TVFileModel() { Error = tvFileModel.Error };
            }

            return tvFileModel;
        }
        public TVFileModel GetTVFileModelMWQMSitesAndPolSourceSites(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelProv = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProv.Error))
            {
                return new TVFileModel() { Error = tvItemModelProv.Error };
            }

            if (tvItemModelProv.TVType != TVTypeEnum.Province)
            {
                return new TVFileModel() { Error = string.Format(ServiceRes.ShouldContainTVTypeOf_, TVTypeEnum.Province.ToString()) };
            }

            string Init = GetInit(ProvinceTVItemID);

            string ServerPath = _TVFileService.GetServerFilePath(ProvinceTVItemID);

            string FileName = $"MWQMSitesAndPolSourceSites_{Init}.kml";

            TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithServerFilePathAndServerFileNameDB(ServerPath, FileName);
            if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
            {
                return new TVFileModel() { Error = tvFileModel.Error };
            }

            return tvFileModel;
        }
        public AppTaskModel ProvinceToolsCreateClassificationInputsKMLDB(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.ProvinceToolsCreateClassificationInputsKML);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.ProvinceToolsCreateClassificationInputsKML,
                ErrorText = "",
                StatusText = ServiceRes.ProvinceToolsCreateClassificationInputsKML,
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

            return appTaskModelRet;
        }
        public AppTaskModel ProvinceToolsCreateGroupingInputsKMLDB(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.ProvinceToolsCreateGroupingInputsKML);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.ProvinceToolsCreateGroupingInputsKML,
                ErrorText = "",
                StatusText = ServiceRes.ProvinceToolsCreateGroupingInputsKML,
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

            return appTaskModelRet;
        }
        public AppTaskModel ProvinceToolsCreateMWQMSitesAndPolSourceSitesKMLDB(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML,
                ErrorText = "",
                StatusText = ServiceRes.ProvinceToolsCreateMWQMSitesAndPolSourceSitesKML,
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

            return appTaskModelRet;
        }
        public AppTaskModel GenerateClassificationForCSSPWebToolsVisualizationDB(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.GenerateClassificationForCSSPWebToolsVisualization);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.GenerateClassificationForCSSPWebToolsVisualization,
                ErrorText = "",
                StatusText = ServiceRes.GenerateClassificationForCSSPWebToolsVisualization,
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

            return appTaskModelRet;
        }
        public AppTaskModel GenerateKMLFileClassificationForCSSPWebToolsVisualizationDB(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.GenerateKMLFileClassificationForCSSPWebToolsVisualization);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.GenerateKMLFileClassificationForCSSPWebToolsVisualization,
                ErrorText = "",
                StatusText = ServiceRes.GenerateKMLFileClassificationForCSSPWebToolsVisualization,
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

            return appTaskModelRet;
        }
        public AppTaskModel GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualizationDB(int ProvinceTVItemID)
        {
            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return new AppTaskModel() { Error = tvItemModelSubsector.Error };


            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(ProvinceTVItemID, ProvinceTVItemID, AppTaskCommandEnum.GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return appTaskModelExist;

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemID", Value = ProvinceTVItemID.ToString() });

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
                TVItemID = ProvinceTVItemID,
                TVItemID2 = ProvinceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization,
                ErrorText = "",
                StatusText = ServiceRes.GenerateLinksBetweenMWQMSitesAndPolSourceSitesForCSSPWebToolsVisualization,
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

            return appTaskModelRet;
        }
        #endregion Functions Classification
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}