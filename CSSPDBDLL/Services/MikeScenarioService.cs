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

namespace CSSPDBDLL.Services
{
    public class MikeScenarioService : BaseService
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
        public MikeScenarioService(LanguageEnum LanguageRequest, IPrincipal User)
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
        public string CheckIfMikeScenarioNameIsUniqueDB(int TVItemID, string MikeScenarioName)
        {
            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            MikeScenarioModel mikeScenarioModel = new MikeScenarioModel();
            mikeScenarioModel.MikeScenarioTVText = MikeScenarioName;

            string TVText = CreateTVText(mikeScenarioModel);
            if (string.IsNullOrWhiteSpace(TVText))
                return string.Format(ServiceRes._IsRequired, ServiceRes.TVText);

            TVItemModel tvItemModelExist = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModel.TVItemID, TVText, TVTypeEnum.MikeScenario);
            if (string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return string.Format(ServiceRes._HasToBeUnique, ServiceRes.MikeScenarioName);
            else
                return "true";
        }
        public string MikeScenarioModelOK(MikeScenarioModel mikeScenarioModel)
        {
            string retStr = FieldCheckNotZeroInt(mikeScenarioModel.MikeScenarioTVItemID, ServiceRes.MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(mikeScenarioModel.MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                return string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, mikeScenarioModel.MikeScenarioTVItemID.ToString());
            }

            List<TVItemModel> tvItemModelParents = _TVItemService.GetParentsTVItemModelList(tvItemModel.TVPath);
            if (tvItemModelParents.Count == 0)
            {
                return string.Format(ServiceRes._ShouldNotBeNullOrEmpty, "tvItemModelParents");
            }

            if (tvItemModelParents[tvItemModelParents.Count - 2].TVType == TVTypeEnum.Sector)
            {
                retStr = FieldCheckIfNotNullNotZeroInt(mikeScenarioModel.ForSimulatingMWQMRunTVItemID, ServiceRes.ForSimulatingMWQMRunTVItemID);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mikeScenarioModel.MikeScenarioTVText, ServiceRes.MikeScenarioTVText, 3, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullNotZeroInt(mikeScenarioModel.ParentMikeScenarioID, ServiceRes.ParentMikeScenarioID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.ScenarioStatusOK(mikeScenarioModel.ScenarioStatus);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(mikeScenarioModel.MikeScenarioEndDateTime_Local, ServiceRes.MikeScenarioEndDateAndTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(mikeScenarioModel.MikeScenarioStartDateTime_Local, ServiceRes.MikeScenarioStartDateAndTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (mikeScenarioModel.MikeScenarioEndDateTime_Local < mikeScenarioModel.MikeScenarioStartDateTime_Local)
            {
                return string.Format(ServiceRes._IsLaterThan_, ServiceRes.MikeScenarioStartDateTime_Local, ServiceRes.MikeScenarioEndDateTime_Local);
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mikeScenarioModel.WindSpeed_km_h,
                ServiceRes.WindSpeed_km_h, (double)0D, (double)100D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mikeScenarioModel.WindDirection_deg,
                ServiceRes.WindDirection_deg, (double)0D, (double)360D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mikeScenarioModel.DecayFactor_per_day,
                ServiceRes.DecayFactor_per_day, (double)0D, (double)100D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullBool(mikeScenarioModel.DecayIsConstant, ServiceRes.DecayIsConstant);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mikeScenarioModel.DecayFactorAmplitude,
                ServiceRes.DecayFactorAmplitude, (double)0D, (double)100D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (mikeScenarioModel.DecayIsConstant == true)
            {
                if (mikeScenarioModel.DecayFactorAmplitude > mikeScenarioModel.DecayFactor_per_day)
                {
                    return string.Format(ServiceRes._IsBiggerOrEqualTo_, ServiceRes.DecayFactorAmplitude, ServiceRes.DecayFactor_per_day);
                }
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(mikeScenarioModel.ResultFrequency_min,
                ServiceRes.ResultFrequency_min, 5, 60);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mikeScenarioModel.AmbientTemperature_C,
                ServiceRes.AmbientTemperature_C, (double)0D, (double)35D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mikeScenarioModel.AmbientSalinity_PSU,
                ServiceRes.AmbientSalinity_PSU, (double)0D, (double)35D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mikeScenarioModel.ManningNumber,
                ServiceRes.ManningNumber, (double)20D, (double)40D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMikeScenario(MikeScenario mikeScenario, MikeScenarioModel mikeScenarioModel, ContactOK contactOK)
        {
            mikeScenario.AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU;
            mikeScenario.AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C;
            mikeScenario.DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day;
            mikeScenario.DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude;
            mikeScenario.DecayIsConstant = mikeScenarioModel.DecayIsConstant;
            mikeScenario.ErrorInfo = mikeScenarioModel.ErrorInfo;
            mikeScenario.EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize;
            mikeScenario.EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize;
            mikeScenario.ForSimulatingMWQMRunTVItemID = mikeScenarioModel.ForSimulatingMWQMRunTVItemID;
            mikeScenario.GenerateDecouplingFiles = mikeScenarioModel.GenerateDecouplingFiles;
            mikeScenario.ManningNumber = mikeScenarioModel.ManningNumber;
            mikeScenario.MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local;
            mikeScenario.MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local;
            mikeScenario.MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min;
            mikeScenario.MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local;
            mikeScenario.MikeScenarioTVItemID = mikeScenarioModel.MikeScenarioTVItemID;
            mikeScenario.NumberOfElements = mikeScenarioModel.NumberOfElements;
            mikeScenario.NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters;
            mikeScenario.NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers;
            mikeScenario.NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps;
            mikeScenario.NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters;
            mikeScenario.NumberOfZLayers = mikeScenarioModel.NumberOfZLayers;
            mikeScenario.ResultFrequency_min = mikeScenarioModel.ResultFrequency_min;
            mikeScenario.ParentMikeScenarioID = mikeScenarioModel.ParentMikeScenarioID;
            mikeScenario.ScenarioStatus = (int)mikeScenarioModel.ScenarioStatus;
            mikeScenario.WindDirection_deg = mikeScenarioModel.WindDirection_deg;
            mikeScenario.WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h;
            mikeScenario.UseDecouplingFiles = mikeScenarioModel.UseDecouplingFiles;
            mikeScenario.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = mikeScenarioModel.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID;
            mikeScenario.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mikeScenario.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mikeScenario.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMikeScenarioCountWithMikeScenarioStatusDB(ScenarioStatusEnum scenarioStatus)
        {
            int mikeScenarioStatusCount = (from c in db.MikeScenarios
                                           where c.ScenarioStatus == (int)scenarioStatus
                                           select c).Count();

            return mikeScenarioStatusCount;
        }
        public InputSummary GetMikeScenarioInputSummaryDB(int MikeScenarioTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return new InputSummary() { Error = contactOK.Error };

            int NumbOfCharToPush = 34;
            StringBuilder sb = new StringBuilder();

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return new InputSummary() { Error = mikeScenarioModel.Error };

            // Scenario General
            sb.AppendLine(string.Format(ReturnStrLimit(ServiceRes.ScenarioName + @":", NumbOfCharToPush) + "\t{0}", mikeScenarioModel.MikeScenarioTVText != null ? mikeScenarioModel.MikeScenarioTVText : ServiceRes.EmptyLowerCase));
            if (mikeScenarioModel.MikeScenarioStartDateTime_Local != null)
            {
                sb.AppendLine(string.Format(ReturnStrLimit(ServiceRes.ScenarioStartDateTime + @":", NumbOfCharToPush) + "\t{0:yyyy/MM/dd HH:mm:ss tt} (UTC)", mikeScenarioModel.MikeScenarioStartDateTime_Local));
            }
            else
            {
                sb.AppendLine(string.Format(ReturnStrLimit(ServiceRes.ScenarioStartDateTime + @":", NumbOfCharToPush) + "\t" + ServiceRes.NotSet));
            }
            if (mikeScenarioModel.MikeScenarioEndDateTime_Local != null && mikeScenarioModel.MikeScenarioStartDateTime_Local != null)
            {
                TimeSpan ts = new TimeSpan(mikeScenarioModel.MikeScenarioEndDateTime_Local.Ticks - mikeScenarioModel.MikeScenarioStartDateTime_Local.Ticks);

                sb.AppendLine(string.Format(ReturnStrLimit(ServiceRes.ScenarioLength + @":", NumbOfCharToPush) + "\t{0:F0} " + ServiceRes.DaysLowerCase + @" {1:F0} " + ServiceRes.HoursLowerCase + @" {2:F0} " + ServiceRes.MinutesLowerCase, ts.Days, ts.Hours, ts.Minutes));
            }
            else
            {
                sb.AppendLine(string.Format(ReturnStrLimit(ServiceRes.ScenarioLength + @":", NumbOfCharToPush) + "\t{0:F0} " + ServiceRes.DaysLowerCase + " {1:F0} " + ServiceRes.HoursLowerCase + @" {2:F0} " + ServiceRes.MinutesLowerCase, 0, 0, 0));
            }

            sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.ScenarioDecayFactor + @":", NumbOfCharToPush) + "\t{0:F5} (/" + ServiceRes.DayLowerCase + @")" + "\t{1:F8}" + @" (/" + ServiceRes.SecondLowerCase + @")", mikeScenarioModel.DecayFactor_per_day, (mikeScenarioModel.DecayFactor_per_day / 24 / 3600)).Replace(",", "."));
            sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.DecayIsConstant + @":", NumbOfCharToPush) + "\t{0}", mikeScenarioModel.DecayIsConstant.ToString()));
            if (!mikeScenarioModel.DecayIsConstant)
            {
                sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.ScenarioDecayFactorAmplitude + ":", NumbOfCharToPush) + "\t{0:F5}", mikeScenarioModel.DecayFactorAmplitude).Replace(",", "."));
            }
            sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.ResultFrequency + @":", NumbOfCharToPush) + "\t{0:F0} " + ServiceRes.MinutesLowerCase, mikeScenarioModel.ResultFrequency_min));
            sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.ScenarioAmbientTemperature + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.Celcius + @")", mikeScenarioModel.AmbientTemperature_C).Replace(",", "."));
            sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.ScenarioAmbientSalinity + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.PSU + @")", mikeScenarioModel.AmbientSalinity_PSU).Replace(",", "."));
            sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.ScenarioManningNumber + @":", NumbOfCharToPush) + "\t{0:F2} (m^(1/3)/s)", mikeScenarioModel.ManningNumber).Replace(",", "."));
            sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.ScenarioWindSpeed + @":", NumbOfCharToPush) + "\t{0:F2} (km/h)\t{1:F2} (m/s)", mikeScenarioModel.WindSpeed_km_h, mikeScenarioModel.WindSpeed_km_h / 3.6).Replace(",", "."));
            sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.ScenarioWindDirection + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.Degrees + @")", mikeScenarioModel.WindDirection_deg).Replace(",", "."));

            // Sources

            List<MikeSourceModel> mikeSourceModelList = _MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);

            int CountSource = 0;
            foreach (MikeSourceModel msm in mikeSourceModelList)
            {
                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(msm.MikeSourceTVItemID, TVTypeEnum.MikeSource, MapInfoDrawTypeEnum.Point);

                CountSource += 1;
                sb.AppendLine("");
                sb.AppendLine("");
                sb.AppendLine(string.Format(ReturnStrLimit(ServiceRes.Sources + "", 15) + " ({0})", CountSource));
                sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.Name + @":", NumbOfCharToPush) + "\t{0}", msm.MikeSourceTVText));
                sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.IsIncluded + @":", NumbOfCharToPush) + "\t{0}", msm.Include.ToString()));
                sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.Latitude + @":", NumbOfCharToPush) + "\t{0:F8}", mapInfoPointModelList[0].Lat).Replace(",", "."));
                sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.Longitude + @":", NumbOfCharToPush) + "\t{0:F8}", mapInfoPointModelList[0].Lng).Replace(",", "."));

                sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.IsContinuous + @":", NumbOfCharToPush) + "\t{0}", msm.IsContinuous.ToString()));

                List<MikeSourceStartEndModel> mikeSourceStartEndModelList = _MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(msm.MikeSourceTVItemID);
                foreach (MikeSourceStartEndModel mssem in mikeSourceStartEndModelList)
                {
                    sb.AppendLine("");
                    if (!(bool)msm.IsContinuous)
                    {
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.SpillStartDate + @":", NumbOfCharToPush) + "\t{0:yyyy/MM/dd HH:mm:ss tt} (UTC)", mssem.StartDateAndTime_Local));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.SpillEndDate + @":", NumbOfCharToPush) + "\t{0:yyyy/MM/dd HH:mm:ss tt} (UTC)", mssem.EndDateAndTime_Local));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.FlowStart + @":", NumbOfCharToPush) + "\t{0:F2} (m3/d)      {1:F8} (m3/s)", mssem.SourceFlowStart_m3_day, mssem.SourceFlowStart_m3_day / 24 / 3600).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.FlowEnd + @":", NumbOfCharToPush) + "\t{0:F2} (m3/d)      {1:F8} (m3/s)", mssem.SourceFlowEnd_m3_day, mssem.SourceFlowEnd_m3_day / 24 / 3600).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.PollutionStart + @":", NumbOfCharToPush) + "\t{0:F0} (" + ServiceRes.FCMPNPer100ml + @")", mssem.SourcePollutionStart_MPN_100ml).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.PollutionEnd + @":", NumbOfCharToPush) + "\t{0:F0} (" + ServiceRes.FCMPNPer100ml + @")", mssem.SourcePollutionEnd_MPN_100ml).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.TemperatureStart + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.Celcius + @")", mssem.SourceTemperatureStart_C).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.TemperatureEnd + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.Celcius + @")", mssem.SourceTemperatureEnd_C).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.SalinityStart + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.PSU + @")", mssem.SourceSalinityStart_PSU).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.SalinityEnd + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.PSU + @")", mssem.SourceSalinityEnd_PSU).Replace(",", "."));
                    }
                    else
                    {
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.FlowStart + @":", NumbOfCharToPush) + "\t{0:F2} (m3/d)      {1:F8} (m3/s)", mssem.SourceFlowStart_m3_day, mssem.SourceFlowStart_m3_day / 24 / 3600).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.PollutionStart + @":", NumbOfCharToPush) + "\t{0:F0} (" + ServiceRes.FCMPNPer100ml + @"l)", mssem.SourcePollutionStart_MPN_100ml).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.TemperatureStart + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.Celcius + @")", mssem.SourceTemperatureStart_C).Replace(",", "."));
                        sb.AppendLine(string.Format(ReturnStrLimit("" + ServiceRes.SalinityStart + @":", NumbOfCharToPush) + "\t{0:F2} (" + ServiceRes.PSU + @")", mssem.SourceSalinityStart_PSU).Replace(",", "."));
                    }
                }

            }

            return new InputSummary() { Error = "", Summary = sb.ToString() };
        }
        public List<TVFileModel> GetMikeScenarioImportOtherFileToUploadDB(int MikeScenarioTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return new List<TVFileModel>() { new TVFileModel() { Error = contactOK.Error } };

            if (MikeScenarioTVItemID == 0)
                return new List<TVFileModel>() { new TVFileModel() { Error = string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID) } };

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return new List<TVFileModel>() { new TVFileModel() { Error = mikeScenarioModel.Error } };

            List<TVFileModel> tvFileModelList = _TVFileService.GetTVFileModelListWithParentTVItemIDDB(MikeScenarioTVItemID).Where(c => c.FileType != FileTypeEnum.M21FM || c.FileType != FileTypeEnum.M3FM).Where(c => c.FileSize_kb == 0).ToList();

            return tvFileModelList;
        }
        public int GetMikeScenarioModelCountDB()
        {
            int MikeScenarioModelCount = (from c in db.MikeScenarios
                                          select c).Count();

            return MikeScenarioModelCount;
        }
        public MikeScenarioModel GetMikeScenarioModelWithMikeScenarioIDDB(int MikeScenarioID)
        {
            MikeScenarioModel mikeScenarioModel = (from c in db.MikeScenarios
                                                   let scenarioName = (from bl in db.TVItemLanguages where bl.Language == (int)LanguageRequest && bl.TVItemID == c.MikeScenarioTVItemID select bl.TVText).FirstOrDefault<string>()
                                                   where c.MikeScenarioID == MikeScenarioID
                                                   select new MikeScenarioModel
                                                   {
                                                       Error = "",
                                                       MikeScenarioID = c.MikeScenarioID,
                                                       AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                                                       AmbientTemperature_C = c.AmbientTemperature_C,
                                                       DecayFactor_per_day = c.DecayFactor_per_day,
                                                       DecayFactorAmplitude = c.DecayFactorAmplitude,
                                                       DecayIsConstant = c.DecayIsConstant,
                                                       ErrorInfo = c.ErrorInfo,
                                                       EstimatedHydroFileSize = c.EstimatedHydroFileSize,
                                                       EstimatedTransFileSize = c.EstimatedTransFileSize,
                                                       ForSimulatingMWQMRunTVItemID = c.ForSimulatingMWQMRunTVItemID,
                                                       GenerateDecouplingFiles = c.GenerateDecouplingFiles,
                                                       ManningNumber = c.ManningNumber,
                                                       MikeScenarioEndDateTime_Local = c.MikeScenarioEndDateTime_Local,
                                                       MikeScenarioExecutionTime_min = c.MikeScenarioExecutionTime_min,
                                                       MikeScenarioStartDateTime_Local = c.MikeScenarioStartDateTime_Local,
                                                       MikeScenarioStartExecutionDateTime_Local = c.MikeScenarioStartExecutionDateTime_Local,
                                                       MikeScenarioTVItemID = c.MikeScenarioTVItemID,
                                                       MikeScenarioTVText = scenarioName,
                                                       NumberOfElements = c.NumberOfElements,
                                                       NumberOfHydroOutputParameters = c.NumberOfHydroOutputParameters,
                                                       NumberOfSigmaLayers = c.NumberOfSigmaLayers,
                                                       NumberOfTimeSteps = c.NumberOfTimeSteps,
                                                       NumberOfTransOutputParameters = c.NumberOfTransOutputParameters,
                                                       NumberOfZLayers = c.NumberOfZLayers,
                                                       ResultFrequency_min = c.ResultFrequency_min,
                                                       ParentMikeScenarioID = c.ParentMikeScenarioID,
                                                       ScenarioStatus = (ScenarioStatusEnum)c.ScenarioStatus,
                                                       UseDecouplingFiles = c.UseDecouplingFiles,
                                                       UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = c.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,
                                                       WindDirection_deg = c.WindDirection_deg,
                                                       WindSpeed_km_h = c.WindSpeed_km_h,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).FirstOrDefault<MikeScenarioModel>();

            if (mikeScenarioModel == null)
                return ReturnMikeScenarioError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeScenario, ServiceRes.MikeScenarioID, MikeScenarioID));

            return mikeScenarioModel;
        }
        public MikeScenarioModel GetMikeScenarioModelWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            MikeScenarioModel mikeScenarioModel = (from c in db.MikeScenarios
                                                   let scenarioName = (from bl in db.TVItemLanguages where bl.Language == (int)LanguageRequest && bl.TVItemID == c.MikeScenarioTVItemID select bl.TVText).FirstOrDefault<string>()
                                                   where c.MikeScenarioTVItemID == MikeScenarioTVItemID
                                                   select new MikeScenarioModel
                                                   {
                                                       Error = "",
                                                       MikeScenarioID = c.MikeScenarioID,
                                                       AmbientSalinity_PSU = c.AmbientSalinity_PSU,
                                                       AmbientTemperature_C = c.AmbientTemperature_C,
                                                       DecayFactor_per_day = c.DecayFactor_per_day,
                                                       DecayFactorAmplitude = c.DecayFactorAmplitude,
                                                       DecayIsConstant = c.DecayIsConstant,
                                                       ErrorInfo = c.ErrorInfo,
                                                       EstimatedHydroFileSize = c.EstimatedHydroFileSize,
                                                       EstimatedTransFileSize = c.EstimatedTransFileSize,
                                                       ForSimulatingMWQMRunTVItemID = c.ForSimulatingMWQMRunTVItemID,
                                                       GenerateDecouplingFiles = c.GenerateDecouplingFiles,
                                                       ManningNumber = c.ManningNumber,
                                                       MikeScenarioEndDateTime_Local = c.MikeScenarioEndDateTime_Local,
                                                       MikeScenarioExecutionTime_min = c.MikeScenarioExecutionTime_min,
                                                       MikeScenarioStartDateTime_Local = c.MikeScenarioStartDateTime_Local,
                                                       MikeScenarioStartExecutionDateTime_Local = c.MikeScenarioStartExecutionDateTime_Local,
                                                       MikeScenarioTVItemID = c.MikeScenarioTVItemID,
                                                       MikeScenarioTVText = scenarioName,
                                                       NumberOfElements = c.NumberOfElements,
                                                       NumberOfHydroOutputParameters = c.NumberOfHydroOutputParameters,
                                                       NumberOfSigmaLayers = c.NumberOfSigmaLayers,
                                                       NumberOfTimeSteps = c.NumberOfTimeSteps,
                                                       NumberOfTransOutputParameters = c.NumberOfTransOutputParameters,
                                                       NumberOfZLayers = c.NumberOfZLayers,
                                                       ResultFrequency_min = c.ResultFrequency_min,
                                                       ParentMikeScenarioID = c.ParentMikeScenarioID,
                                                       ScenarioStatus = (ScenarioStatusEnum)c.ScenarioStatus,
                                                       UseDecouplingFiles = c.UseDecouplingFiles,
                                                       UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = c.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,
                                                       WindDirection_deg = c.WindDirection_deg,
                                                       WindSpeed_km_h = c.WindSpeed_km_h,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).FirstOrDefault<MikeScenarioModel>();

            if (mikeScenarioModel == null)
                return ReturnMikeScenarioError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeScenario, ServiceRes.MikeScenarioTVItemID, MikeScenarioTVItemID));

            return mikeScenarioModel;
        }
        public MikeScenario GetMikeScenarioWithMikeScenarioIDDB(int MikeScenarioID)
        {
            MikeScenario mikeScenario = (from c in db.MikeScenarios
                                         where c.MikeScenarioID == MikeScenarioID
                                         select c).FirstOrDefault<MikeScenario>();

            return mikeScenario;
        }
        public MikeScenario GetMikeScenarioWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            MikeScenario mikeScenario = (from c in db.MikeScenarios
                                         where c.MikeScenarioTVItemID == MikeScenarioTVItemID
                                         select c).FirstOrDefault<MikeScenario>();

            return mikeScenario;
        }

        public List<ContourPolygon> GetStudyAreaContourPolygonListWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            List<ContourPolygon> contourPolygonList = new List<ContourPolygon>();

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
            {
                contourPolygonList.Add(new ContourPolygon() { Error = mikeScenarioModel.Error });
                return contourPolygonList;
            }

            TVFileModel tvFileModelM21fmOrM3fm = _TVFileService.GetTVFileModelWithTVItemIDAndTVFileTypeM21FMOrM3FMDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelM21fmOrM3fm.Error))
            {
                contourPolygonList.Add(new ContourPolygon() { Error = tvFileModelM21fmOrM3fm.Error });
                return contourPolygonList;
            }

            FileInfo fiM21fmOrM3fm = new FileInfo(_TVFileService.ChoseEDriveOrCDrive(tvFileModelM21fmOrM3fm.ServerFilePath) + tvFileModelM21fmOrM3fm.ServerFileName);

            if (!fiM21fmOrM3fm.Exists)
            {
                contourPolygonList.Add(new ContourPolygon() { Error = string.Format(ServiceRes.File_DoesNotExist, fiM21fmOrM3fm.FullName) });
                return contourPolygonList;
            }

            FileInfo fiHydroResult = null;
            using (PFS pfs = new PFS(fiM21fmOrM3fm))
            {
                string Path = "FemEngineHD/HYDRODYNAMIC_MODULE/OUTPUTS/OUTPUT_1";
                string Keyword = "file_name";
                fiHydroResult = pfs.GetVariableFileInfo(Path, Keyword, 1);

                if (fiHydroResult == null)
                {
                    contourPolygonList.Add(new ContourPolygon() { Error = string.Format(ServiceRes.CouldNotFindOrReadKeyword_OfPath_InFile_, Keyword, Path, fiHydroResult.FullName) });
                    return contourPolygonList;
                }

                if (fiHydroResult == null && !fiHydroResult.Exists)
                {
                    contourPolygonList.Add(new ContourPolygon() { Error = string.Format(ServiceRes.File_DoesNotExist, fiHydroResult.FullName) });
                    return contourPolygonList;
                }
            }

            using (DFSU dfsu = new DFSU(fiHydroResult))
            {
                dfsu.GetStudyAreaContourPolygonList(contourPolygonList);
            }

            return contourPolygonList;
        }
        // Helper
        public TVItemModel CopyMikeScenarioBoundaryCondition(int MikeScenarioTVItemID, TVItemModel tvItemModelBoundaryCondition, TVTypeEnum TVType)
        {
            TVItemModel tvItemModelRet = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(MikeScenarioTVItemID, tvItemModelBoundaryCondition.TVText, TVType);
            if (string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                return ReturnTVItemError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MikeBoundaryCondition));

            tvItemModelRet = _TVItemService.PostAddChildTVItemDB(MikeScenarioTVItemID, tvItemModelBoundaryCondition.TVText, TVType);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                return ReturnTVItemError(tvItemModelRet.Error);

            MikeBoundaryConditionModel mikeBoundaryConditionModel = _MikeBoundaryConditionService.GetMikeBoundaryConditionModelWithMikeBoundaryConditionTVItemIDDB(tvItemModelBoundaryCondition.TVItemID);
            if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionModel.Error))
                return ReturnTVItemError(mikeBoundaryConditionModel.Error);

            MikeBoundaryConditionModel mikeBoundaryConditionModelNew = new MikeBoundaryConditionModel()
            {
                MikeBoundaryConditionCode = mikeBoundaryConditionModel.MikeBoundaryConditionCode,
                MikeBoundaryConditionFormat = mikeBoundaryConditionModel.MikeBoundaryConditionFormat,
                MikeBoundaryConditionLength_m = mikeBoundaryConditionModel.MikeBoundaryConditionLength_m,
                MikeBoundaryConditionName = mikeBoundaryConditionModel.MikeBoundaryConditionName,
                MikeBoundaryConditionLevelOrVelocity = mikeBoundaryConditionModel.MikeBoundaryConditionLevelOrVelocity,
                NumberOfWebTideNodes = mikeBoundaryConditionModel.NumberOfWebTideNodes,
                WebTideDataFromStartToEndDate = mikeBoundaryConditionModel.WebTideDataFromStartToEndDate,
                MikeBoundaryConditionTVItemID = tvItemModelRet.TVItemID,
                WebTideDataSet = mikeBoundaryConditionModel.WebTideDataSet,
                MikeBoundaryConditionTVText = mikeBoundaryConditionModel.MikeBoundaryConditionTVText,
                TVType = mikeBoundaryConditionModel.TVType,
            };

            MikeBoundaryConditionModel mikeBoundaryConditionModelRet = _MikeBoundaryConditionService.PostAddMikeBoundaryConditionDB(mikeBoundaryConditionModelNew);
            if (!string.IsNullOrEmpty(mikeBoundaryConditionModelRet.Error))
                return ReturnTVItemError(mikeBoundaryConditionModelRet.Error);

            List<MapInfoPointModel> mapInfoPointModelList = new List<MapInfoPointModel>();

            mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(tvItemModelBoundaryCondition.TVItemID, TVType, MapInfoDrawTypeEnum.Polyline);

            if (mapInfoPointModelList.Count == 0)
                return ReturnTVItemError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint));

            List<Coord> coordList = new List<Coord>();

            foreach (MapInfoPointModel mippm in mapInfoPointModelList)
            {
                coordList.Add(new Coord() { Lat = (float)mippm.Lat, Lng = (float)mippm.Lng, Ordinal = mippm.Ordinal });
            }

            MapInfoModel mapInfoModelRet2 = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Polyline, TVType, tvItemModelRet.TVItemID);
            if (!string.IsNullOrEmpty(mapInfoModelRet2.Error))
                return ReturnTVItemError(mapInfoModelRet2.Error);

            return tvItemModelRet;
        }
        public TVItemModel CopyMikeScenarioSource(int MikeScenarioTVItemID, MikeSourceModel msm)
        {
            TVItemModel tvItemMikeSource = _TVItemService.PostAddChildTVItemDB(MikeScenarioTVItemID, msm.MikeSourceTVText, TVTypeEnum.MikeSource);
            if (!string.IsNullOrEmpty(tvItemMikeSource.Error))
                return ReturnTVItemError(tvItemMikeSource.Error);

            MikeSourceModel mikeSourceModelNew = new MikeSourceModel()
            {
                IsContinuous = msm.IsContinuous,
                Include = msm.Include,
                IsRiver = msm.IsRiver,
                UseHydrometric = msm.UseHydrometric,
                HydrometricTVItemID = msm.HydrometricTVItemID,
                DrainageArea_km2 = msm.DrainageArea_km2,
                Factor = msm.Factor,
                LastUpdateDate_UTC = DateTime.UtcNow,
                SourceNumberString = msm.SourceNumberString,
                MikeSourceTVItemID = tvItemMikeSource.TVItemID,
                MikeSourceTVText = tvItemMikeSource.TVText,
            };

            MikeSourceModel mikeSourceModelRet = _MikeSourceService.PostAddMikeSourceDB(mikeSourceModelNew);
            if (!string.IsNullOrEmpty(mikeSourceModelRet.Error))
                return ReturnTVItemError(mikeSourceModelRet.Error);

            List<MikeSourceStartEndModel> mikeSourceStartEndModelOldList = _MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(msm.MikeSourceTVItemID);

            if (mikeSourceStartEndModelOldList.Count == 0)
                return ReturnTVItemError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MikeSourceStartEnd));

            foreach (MikeSourceStartEndModel mssem in mikeSourceStartEndModelOldList)
            {
                MikeSourceStartEndModel mikeSourceStartEndModelNew = new MikeSourceStartEndModel()
                {
                    EndDateAndTime_Local = mssem.EndDateAndTime_Local,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    MikeSourceID = mikeSourceModelRet.MikeSourceID,
                    SourceFlowEnd_m3_day = mssem.SourceFlowEnd_m3_day,
                    SourceFlowStart_m3_day = mssem.SourceFlowStart_m3_day,
                    SourcePollutionEnd_MPN_100ml = mssem.SourcePollutionEnd_MPN_100ml,
                    SourcePollutionStart_MPN_100ml = mssem.SourcePollutionStart_MPN_100ml,
                    SourceSalinityEnd_PSU = mssem.SourceSalinityEnd_PSU,
                    SourceSalinityStart_PSU = mssem.SourceSalinityStart_PSU,
                    SourceTemperatureEnd_C = mssem.SourceTemperatureEnd_C,
                    SourceTemperatureStart_C = mssem.SourceTemperatureStart_C,
                    StartDateAndTime_Local = mssem.StartDateAndTime_Local,

                };

                MikeSourceStartEndModel mikeSourceStartEndModelRet = _MikeSourceService._MikeSourceStartEndService.PostAddMikeSourceStartEndDB(mikeSourceStartEndModelNew);
                if (!string.IsNullOrEmpty(mikeSourceStartEndModelRet.Error))
                    return ReturnTVItemError(mikeSourceStartEndModelRet.Error);
            }

            List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(msm.MikeSourceTVItemID, TVTypeEnum.MikeSource, MapInfoDrawTypeEnum.Point);

            if (mapInfoPointModelList.Count == 0)
                return ReturnTVItemError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint));

            List<Coord> coordListSource = new List<Coord>() { new Coord() { Lat = (float)mapInfoPointModelList[0].Lat, Lng = (float)mapInfoPointModelList[0].Lng } };

            MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordListSource, MapInfoDrawTypeEnum.Point, TVTypeEnum.MikeSource, mikeSourceModelRet.MikeSourceTVItemID);
            if (!string.IsNullOrEmpty(mapInfoModelRet.Error))
                return ReturnTVItemError(mapInfoModelRet.Error);


            return tvItemMikeSource;
        }
        public TVItemModel CopyMikeScenarioTVFile(MikeScenarioModel mikeScenarioModel, MikeScenarioModel mikeScenarioModelRet, TVFileModel tvFileModel, string TVText)
        {
            string m21_3FileNameNoExt = "";

            TVItemModel tvItemModelTVFile = _TVItemService.PostAddChildTVItemDB(mikeScenarioModelRet.MikeScenarioTVItemID, tvFileModel.TVFileTVText, TVTypeEnum.File);
            if (!string.IsNullOrWhiteSpace(tvItemModelTVFile.Error))
                return ReturnTVItemError(tvItemModelTVFile.Error);


            TVFileModel tvFileModelNew = new TVFileModel();
            tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
            tvFileModelNew.FileCreatedDate_UTC = tvFileModel.FileCreatedDate_UTC;
            tvFileModelNew.FileDescription = tvFileModel.FileDescription;
            tvFileModelNew.FilePurpose = tvFileModel.FilePurpose;
            tvFileModelNew.FileSize_kb = tvFileModel.FileSize_kb;
            tvFileModelNew.FileType = tvFileModel.FileType;
            tvFileModelNew.FileInfo = "MIKE Scenario File";
            tvFileModelNew.Language = LanguageRequest;
            tvFileModelNew.Year = DateTime.Now.Year;
            if (tvFileModel.FileType == FileTypeEnum.M21FM || tvFileModel.FileType == FileTypeEnum.M3FM)
            {
                m21_3FileNameNoExt = tvFileModel.ServerFileName.Substring(0, tvFileModel.ServerFileName.LastIndexOf("."));
                tvFileModelNew.ServerFileName = tvFileModel.ServerFileName.Replace(m21_3FileNameNoExt, TVText);
            }
            else
            {
                tvFileModelNew.ServerFileName = tvFileModel.ServerFileName;
            }
            tvFileModelNew.ServerFilePath = tvFileModel.ServerFilePath.Replace(@"\" + mikeScenarioModel.MikeScenarioTVItemID + @"\", @"\" + mikeScenarioModelRet.MikeScenarioTVItemID + @"\");
            //tvFileModelNew.ServerFilePath = tvFileNew.ServerFilePath.Replace(m21_3FileNameNoExt, TVTextEN);

            string NewDirectory = tvFileModelNew.ServerFilePath.Replace(@"\" + mikeScenarioModel.MikeScenarioTVItemID + @"\", @"\" + mikeScenarioModelRet.MikeScenarioTVItemID + @"\");
            string OldDirectory = tvFileModel.ServerFilePath;

            NewDirectory = _TVFileService.ChoseEDriveOrCDrive(NewDirectory);
            OldDirectory = _TVFileService.ChoseEDriveOrCDrive(OldDirectory);

            DirectoryInfo di = new DirectoryInfo(NewDirectory);

            if (!di.Exists)
            {
                di.Create();
            }

            if (string.IsNullOrWhiteSpace(tvFileModelNew.FileDescription))
                tvFileModelNew.FileDescription = tvFileModelNew.ServerFileName + " description";

            TVFileModel tvFileModelRet = _TVFileService.PostAddTVFileDB(tvFileModelNew);
            if (!string.IsNullOrEmpty(tvFileModelRet.Error))
                return ReturnTVItemError(tvFileModelRet.Error);

            if (tvFileModel.FileSize_kb > 0)
            {
                if (tvFileModel.FileType == FileTypeEnum.M21FM || tvFileModel.FileType == FileTypeEnum.M3FM)
                {
                    try
                    {
                        File.Copy(OldDirectory + tvFileModel.ServerFileName, NewDirectory + TVText + "." + tvFileModel.FileType.ToString().ToLower());
                    }
                    catch (Exception ex)
                    {
                        return ReturnTVItemError(string.Format(ServiceRes.CouldNotCreateCopyOf__, NewDirectory + TVText + tvFileModel.FileType.ToString().ToLower(), ex.Message));
                    }
                }
                else
                {
                    try
                    {
                        File.Copy(OldDirectory + tvFileModel.ServerFileName, NewDirectory + tvFileModel.ServerFileName);
                    }
                    catch (Exception ex)
                    {
                        return ReturnTVItemError(string.Format(ServiceRes.CouldNotCreateCopyOf__, NewDirectory + tvFileModel.ServerFileName, ex.Message));
                    }
                }
            }

            return tvItemModelTVFile;
        }
        public string CreateTVText(MikeScenarioModel mikeScenarioModel)
        {
            return mikeScenarioModel.MikeScenarioTVText;
        }
        public bool GetIsItSameObject(MikeScenarioModel mikeScenarioModel, TVItemModel tvItemModelMikeScenarioExit)
        {
            bool IsSame = false;
            if (mikeScenarioModel.MikeScenarioTVItemID == tvItemModelMikeScenarioExit.TVItemID)
            {
                IsSame = true;
            }

            return IsSame;
        }
        public AppTaskModel ReturnAppTaskError(string Error)
        {
            return new AppTaskModel() { Error = Error };
        }
        public MapInfoPointModel ReturnMapInfoPointError(string Error)
        {
            return new MapInfoPointModel() { Error = Error };
        }
        public MikeScenarioModel ReturnMikeScenarioError(string Error)
        {
            return new MikeScenarioModel() { Error = Error };
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
        public string ReturnStrLimit(string TempStr, int NumbOfChar)
        {
            StringBuilder RetString = new StringBuilder();
            if (TempStr != null)
            {
                if (TempStr.Length < NumbOfChar)
                {
                    for (int i = 0; i < (NumbOfChar - TempStr.Length); i++)
                    {
                        RetString.Append(" ");
                    }
                    RetString.Append(TempStr);
                }
                else
                {
                    RetString.Append(TempStr);
                }
            }
            return RetString.ToString();
        }

        // Post AppTask
        public AppTaskModel PostMikeScenarioCreateWebTideDataWLFromStartToEndDateDB(int MikeScenarioTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnAppTaskError(contactOK.Error);

            if (MikeScenarioTVItemID == 0)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return ReturnAppTaskError(mikeScenarioModel.Error);

            //mikeScenarioModel.MikeScenarioStatus = ScenarioStatusEnum.Changed;

            //MikeScenarioModel mikeScenarioModelRet = PostUpdateMikeScenarioDB(mikeScenarioModel);
            //if (!string.IsNullOrWhiteSpace(mikeScenarioModelRet.Error))
            //    return ReturnAppTaskError(mikeScenarioModelRet.Error);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "MikeScenarioTVItemID", Value = MikeScenarioTVItemID.ToString() });

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
                AppTaskCommand = AppTaskCommandEnum.CreateWebTideDataWLAtFirstNode,
                ErrorText = "",
                StatusText = ServiceRes.CreateWebTideDataWLAtFirstNode,
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
        public AppTaskModel PostMikeScenarioAskToRunDB(int MikeScenarioTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnAppTaskError(contactOK.Error);

            if (MikeScenarioTVItemID == 0)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return ReturnAppTaskError(mikeScenarioModel.Error);

            mikeScenarioModel.ScenarioStatus = ScenarioStatusEnum.AskToRun;

            MikeScenarioModel mikeScenarioModelRet = PostUpdateMikeScenarioDB(mikeScenarioModel);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModelRet.Error))
                return ReturnAppTaskError(mikeScenarioModelRet.Error);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "MikeScenarioTVItemID", Value = MikeScenarioTVItemID.ToString() });

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
                AppTaskCommand = AppTaskCommandEnum.MikeScenarioAskToRun,
                ErrorText = "",
                StatusText = ServiceRes.AskingToRunMIKEScenario,
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
        public AppTaskModel LoadHydrometricDataValueDB(int MikeScenarioTVItemID, int MikeSourceTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnAppTaskError(contactOK.Error);

            if (MikeSourceTVItemID == 0)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID));

            MikeSourceModel mikeSourceModel = _MikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeSourceModel.Error))
                return ReturnAppTaskError(mikeSourceModel.Error);

            if (MikeScenarioTVItemID == 0)
                return ReturnAppTaskError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return ReturnAppTaskError(mikeScenarioModel.Error);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "MikeSourceTVItemID", Value = MikeSourceTVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "MikeScenarioTVItemID", Value = MikeScenarioTVItemID.ToString() });

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
                TVItemID = MikeSourceTVItemID,
                TVItemID2 = MikeSourceTVItemID,
                AppTaskCommand = AppTaskCommandEnum.LoadHydrometricDataValue,
                ErrorText = "",
                StatusText = ServiceRes.LoadHydrometricDataValue,
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

        // Post Normal
        public MikeScenarioModel PostAddMikeScenarioDB(MikeScenarioModel mikeScenarioModel)
        {
            string retStr = MikeScenarioModelOK(mikeScenarioModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMikeScenarioError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnMikeScenarioError(contactOK.Error);

            TVItemModel tvItemModelMikeScenario = _TVItemService.GetTVItemModelWithTVItemIDDB(mikeScenarioModel.MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenario.Error))
                return ReturnMikeScenarioError(tvItemModelMikeScenario.Error);

            MikeScenario mikeScenarioNew = new MikeScenario();

            retStr = FillMikeScenario(mikeScenarioNew, mikeScenarioModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMikeScenarioError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MikeScenarios.Add(mikeScenarioNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnMikeScenarioError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeScenarios", mikeScenarioNew.MikeScenarioID, LogCommandEnum.Add, mikeScenarioNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnMikeScenarioError(logModel.Error);

                ts.Complete();
            }

            return GetMikeScenarioModelWithMikeScenarioIDDB(mikeScenarioNew.MikeScenarioID);

        }
        public MikeScenarioModel PostDeleteMikeScenarioAndAllAssociationsWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnMikeScenarioError(contactOK.Error);

            MikeScenarioModel mikeScenarioModelToDelete = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModelToDelete.Error))
                return ReturnMikeScenarioError(mikeScenarioModelToDelete.Error);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(mikeScenarioModelToDelete.MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnMikeScenarioError(tvItemModel.Error);

            List<TVFileModel> tvFileModelList = _TVFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModel.TVItemID);
            List<MikeSourceModel> mikeScourceModelListToDelete = _MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(tvItemModel.TVItemID);
            List<MikeBoundaryConditionModel> mikeBoundaryConditionListMeshToDelete = _MikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(tvItemModel.TVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
            List<MikeBoundaryConditionModel> mikeBoundaryConditionListWebTideToDelete = _MikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(tvItemModel.TVItemID, TVTypeEnum.MikeBoundaryConditionWebTide);
            //using (TransactionScope ts = new TransactionScope())
            //{
            MapInfoModel mapInfoModelRet = _MapInfoService.PostDeleteMapInfoWithTVPathStartWithDB(tvItemModel.TVPath);
            if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                return ReturnMikeScenarioError(mapInfoModelRet.Error);

            // deleting TVFile
            foreach (TVFileModel tvFileModel in tvFileModelList.Where(c => c.FilePurpose != FilePurposeEnum.Template))
            {
                int TVFileTVItemID = tvFileModel.TVFileTVItemID;
                FileInfo fi = new FileInfo(_TVFileService.ChoseEDriveOrCDrive(tvFileModel.ServerFilePath + tvFileModel.ServerFileName));

                // Also deletes the TVItems
                TVFileModel tvFileModelToDelete = _TVFileService.PostDeleteTVFileWithTVItemIDDB(TVFileTVItemID);
                if (!string.IsNullOrWhiteSpace(tvFileModelToDelete.Error))
                    return ReturnMikeScenarioError(tvFileModelToDelete.Error);

                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    return ReturnMikeScenarioError(string.Format(ServiceRes.CouldNotDeleteError_, ex.Message));
                }
            }

            // deleting MikeSource
            foreach (MikeSourceModel mikeSourceModel in mikeScourceModelListToDelete)
            {
                // Also Deletes the TVItems
                MikeSourceModel mikeSourceModelRet = _MikeSourceService.PostDeleteMikeSourceWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                if (!string.IsNullOrWhiteSpace(mikeSourceModelRet.Error))
                    return ReturnMikeScenarioError(mikeSourceModelRet.Error);

            }

            // deleting MikeBoundaryConditions Mesh and Web Tide
            foreach (MikeBoundaryConditionModel mikeBoundaryConditionModel in mikeBoundaryConditionListWebTideToDelete.Concat(mikeBoundaryConditionListMeshToDelete))
            {
                // Also deletes the TVItems
                MikeBoundaryConditionModel mikeBoundaryConditionRet = _MikeBoundaryConditionService.PostDeleteMikeBoundaryConditionDB(mikeBoundaryConditionModel.MikeBoundaryConditionID);
                if (!string.IsNullOrWhiteSpace(mikeBoundaryConditionRet.Error))
                    return ReturnMikeScenarioError(mikeBoundaryConditionRet.Error);

            }

            MikeScenarioModel mikeScenarioModelRet = PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModelRet.Error))
                return ReturnMikeScenarioError(mikeScenarioModelRet.Error);

            string PathToDelete = _TVFileService.GetServerFilePath(MikeScenarioTVItemID);
            if (string.IsNullOrWhiteSpace(PathToDelete))
                return ReturnMikeScenarioError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.PathToDelete));

            DirectoryInfo di = new DirectoryInfo(PathToDelete);

            // now we should delete the Physical files or MIKE Scenario Path of Files
            if (di.Exists)
                di.Delete(true);

            TVItemModel TVItemModelRet = null;

            // deleting Boundary Condition TVItems
            List<TVItemModel> tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
            foreach (TVItemModel tvItemModelToDelete in tvItemModelList)
            {
                TVItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelToDelete.TVItemID);
                if (!string.IsNullOrWhiteSpace(TVItemModelRet.Error))
                    return ReturnMikeScenarioError(TVItemModelRet.Error);
            }

            // deleting Boundary Condition TVItems
            tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionWebTide);
            foreach (TVItemModel tvItemModelToDelete in tvItemModelList)
            {
                TVItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelToDelete.TVItemID);
                if (!string.IsNullOrWhiteSpace(TVItemModelRet.Error))
                    return ReturnMikeScenarioError(TVItemModelRet.Error);
            }

            // deleting Source TVItems
            tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeSource);
            foreach (TVItemModel tvItemModelToDelete in tvItemModelList)
            {
                TVItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelToDelete.TVItemID);
                if (!string.IsNullOrWhiteSpace(TVItemModelRet.Error))
                    return ReturnMikeScenarioError(TVItemModelRet.Error);
            }

            // deleting TVFile TVItems
            tvItemModelList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.File);
            foreach (TVItemModel tvItemModelToDelete in tvItemModelList)
            {
                TVItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(tvItemModelToDelete.TVItemID);
                if (!string.IsNullOrWhiteSpace(TVItemModelRet.Error))
                    return ReturnMikeScenarioError(TVItemModelRet.Error);
            }

            TVItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(TVItemModelRet.Error))
                return ReturnMikeScenarioError(TVItemModelRet.Error);

            // ts.Complete();
            // }

            return ReturnMikeScenarioError("");
        }
        public MikeScenarioModel PostDeleteMikeScenarioWithMikeScenarioTVItemIDDB(int MikeScenarioTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnMikeScenarioError(contactOK.Error);

            MikeScenario mikeScenarioToDelete = GetMikeScenarioWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (mikeScenarioToDelete == null)
                return ReturnMikeScenarioError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MikeScenario));

            db.MikeScenarios.Remove(mikeScenarioToDelete);
            string retStr = DoDeleteChanges();
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMikeScenarioError(retStr);

            LogModel logModel = _LogService.PostAddLogForObj("MikeScenarios", mikeScenarioToDelete.MikeScenarioID, LogCommandEnum.Delete, mikeScenarioToDelete);
            if (!string.IsNullOrWhiteSpace(logModel.Error))
                return ReturnMikeScenarioError(logModel.Error);

            return ReturnMikeScenarioError("");
        }
        public MikeScenarioModel PostUpdateMikeScenarioDB(MikeScenarioModel mikeScenarioModel)
        {
            string retStr = MikeScenarioModelOK(mikeScenarioModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnMikeScenarioError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnMikeScenarioError(contactOK.Error);

            MikeScenario mikeScenarioToUpdate = GetMikeScenarioWithMikeScenarioIDDB(mikeScenarioModel.MikeScenarioID);
            if (mikeScenarioToUpdate == null)
                return ReturnMikeScenarioError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MikeScenario));

            TVItemModel tvItemModelMikeScenario = _TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(mikeScenarioModel.MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenario.Error))
                return ReturnMikeScenarioError(tvItemModelMikeScenario.Error);

            retStr = FillMikeScenario(mikeScenarioToUpdate, mikeScenarioModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnMikeScenarioError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnMikeScenarioError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MikeScenarios", mikeScenarioToUpdate.MikeScenarioID, LogCommandEnum.Change, mikeScenarioToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnMikeScenarioError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(mikeScenarioToUpdate.MikeScenarioTVItemID, Lang);
                    if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                        return ReturnMikeScenarioError(tvItemLanguageModelToUpdate.Error);

                    string TVText = CreateTVText(mikeScenarioModel);
                    if (string.IsNullOrWhiteSpace(TVText))
                        return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                    TVItemModel tvItemModelMikeScenarioExit = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    if (string.IsNullOrWhiteSpace(tvItemModelMikeScenarioExit.Error))
                    {
                        bool IsSameTVItemModel = GetIsItSameObject(mikeScenarioModel, tvItemModelMikeScenarioExit);
                        if (!IsSameTVItemModel)
                            return ReturnMikeScenarioError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MikeScenario));
                    }

                    tvItemLanguageModelToUpdate.TVText = TVText;

                    TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                    if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                        return ReturnMikeScenarioError(tvItemLanguageModel.Error);
                }

                ts.Complete();
            }

            return GetMikeScenarioModelWithMikeScenarioIDDB(mikeScenarioToUpdate.MikeScenarioID);
        }

        // Post command
        public MikeScenarioModel PostAcceptWebTideDB(int MikeScenarioTVItemID)
        {
            if (MikeScenarioTVItemID == 0)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return ReturnMikeScenarioError(mikeScenarioModel.Error);

            mikeScenarioModel.ScenarioStatus = ScenarioStatusEnum.Completed;

            MikeScenarioModel mikeScenarioModelRet = PostUpdateMikeScenarioDB(mikeScenarioModel);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModelRet.Error))
                return ReturnMikeScenarioError(mikeScenarioModelRet.Error);

            return mikeScenarioModelRet;
        }
        public MapInfoPointModel PostDeleteMeshNodeDB(int MapInfoPointID)
        {
            if (MapInfoPointID == 0)
                return ReturnMapInfoPointError(string.Format(ServiceRes._IsRequired, ServiceRes.MapInfoPointID));

            MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostDeleteMapInfoPointDB(MapInfoPointID);

            return mapInfoPointModelRet;
        }
        public TVItemModel PostMikeScenarioCancelAndResetDB(int MikeScenarioTVItemID)
        {
            if (MikeScenarioTVItemID == 0)
                return ReturnTVItemError(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID));

            using (TransactionScope ts = new TransactionScope())
            {
                MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
                if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                    return ReturnTVItemError(mikeScenarioModel.Error);

                mikeScenarioModel.ScenarioStatus = (int)ScenarioStatusEnum.Error;

                MikeScenarioModel mikeScenarioModelRet = PostUpdateMikeScenarioDB(mikeScenarioModel);
                if (!string.IsNullOrWhiteSpace(mikeScenarioModelRet.Error))
                    return ReturnTVItemError(mikeScenarioModelRet.Error);

                AppTaskModel appTaskModelToCancel = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(MikeScenarioTVItemID, MikeScenarioTVItemID, AppTaskCommandEnum.MikeScenarioRunning);
                if (!string.IsNullOrWhiteSpace(appTaskModelToCancel.Error))
                    return ReturnTVItemError(appTaskModelToCancel.Error);

                appTaskModelToCancel.AppTaskCommand = AppTaskCommandEnum.MikeScenarioToCancel;

                AppTaskModel appTaskModelRet = _AppTaskService.PostUpdateAppTask(appTaskModelToCancel);
                if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                    return ReturnTVItemError(appTaskModelRet.Error);

                ts.Complete();
            }

            TVItemModel tvItemModelRet = _TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                return ReturnTVItemError(tvItemModelRet.Error);

            return tvItemModelRet;
        }
        public TVItemModel PostMikeScenarioCopyDB(int MikeScenarioTVItemID)
        {
            if (MikeScenarioTVItemID == 0)
                return ReturnTVItemError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            TVItemModel tvItemModelMikeScenario = _TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenario.Error))
                return ReturnTVItemError(tvItemModelMikeScenario.Error);

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return ReturnTVItemError(mikeScenarioModel.Error);

            TVItemModel tvItemModelMikeScenarioRet = new TVItemModel();

            using (TransactionScope ts = new TransactionScope())
            {
                // getting next available MikeScenarioName
                int CopyCount = 0;
                bool Found = false;
                string TVText = "";
                while (!Found)
                {
                    CopyCount += 1;
                    TVText = "_" + CopyCount.ToString() + ServiceRes.CopyOf + " " + mikeScenarioModel.MikeScenarioTVText;

                    TVItemModel tvItemModelExist = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                    if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                    {
                        Found = true;
                    }
                }

                tvItemModelMikeScenarioRet = _TVItemService.PostAddChildTVItemDB((int)tvItemModelMikeScenario.ParentID, TVText, TVTypeEnum.MikeScenario);
                if (!string.IsNullOrEmpty(tvItemModelMikeScenarioRet.Error))
                    return ReturnTVItemError(tvItemModelMikeScenarioRet.Error);

                MikeScenarioModel mikeScenarioModelNew = new MikeScenarioModel()
                {
                    AmbientSalinity_PSU = mikeScenarioModel.AmbientSalinity_PSU,
                    AmbientTemperature_C = mikeScenarioModel.AmbientTemperature_C,
                    DecayFactor_per_day = mikeScenarioModel.DecayFactor_per_day,
                    DecayFactorAmplitude = mikeScenarioModel.DecayFactorAmplitude,
                    DecayIsConstant = mikeScenarioModel.DecayIsConstant,
                    EstimatedHydroFileSize = mikeScenarioModel.EstimatedHydroFileSize,
                    EstimatedTransFileSize = mikeScenarioModel.EstimatedTransFileSize,
                    ForSimulatingMWQMRunTVItemID = mikeScenarioModel.ForSimulatingMWQMRunTVItemID,
                    GenerateDecouplingFiles = mikeScenarioModel.GenerateDecouplingFiles,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    ManningNumber = mikeScenarioModel.ManningNumber,
                    MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                    MikeScenarioExecutionTime_min = mikeScenarioModel.MikeScenarioExecutionTime_min,
                    MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                    MikeScenarioStartExecutionDateTime_Local = mikeScenarioModel.MikeScenarioStartExecutionDateTime_Local,
                    NumberOfElements = mikeScenarioModel.NumberOfElements,
                    NumberOfHydroOutputParameters = mikeScenarioModel.NumberOfHydroOutputParameters,
                    NumberOfSigmaLayers = mikeScenarioModel.NumberOfSigmaLayers,
                    NumberOfTimeSteps = mikeScenarioModel.NumberOfTimeSteps,
                    NumberOfTransOutputParameters = mikeScenarioModel.NumberOfTransOutputParameters,
                    NumberOfZLayers = mikeScenarioModel.NumberOfZLayers,
                    ResultFrequency_min = mikeScenarioModel.ResultFrequency_min,
                    ParentMikeScenarioID = mikeScenarioModel.ParentMikeScenarioID,
                    ScenarioStatus = ScenarioStatusEnum.Changed,
                    MikeScenarioTVItemID = tvItemModelMikeScenarioRet.TVItemID,
                    UseDecouplingFiles = mikeScenarioModel.UseDecouplingFiles,
                    UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = mikeScenarioModel.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID,
                    WindDirection_deg = mikeScenarioModel.WindDirection_deg,
                    WindSpeed_km_h = mikeScenarioModel.WindSpeed_km_h,
                    MikeScenarioTVText = tvItemModelMikeScenarioRet.TVText,
                    ErrorInfo = "",
                };

                // Adding Copied Mike Scenario
                MikeScenarioModel mikeScenarioModelRet = PostAddMikeScenarioDB(mikeScenarioModelNew);
                if (!string.IsNullOrEmpty(mikeScenarioModelRet.Error))
                    return ReturnTVItemError(mikeScenarioModelRet.Error);

                // Adding Copied Mike Sources
                List<MikeSourceModel> mikeSourceModelOldList = _MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);

                foreach (MikeSourceModel msm in mikeSourceModelOldList)
                {
                    TVItemModel tvItemModelSource = CopyMikeScenarioSource(tvItemModelMikeScenarioRet.TVItemID, msm);
                    if (!string.IsNullOrWhiteSpace(tvItemModelSource.Error))
                        return ReturnTVItemError(tvItemModelSource.Error);
                }

                // Adding Copied Mike Boundary Conditions Mesh

                List<TVItemModel> tvItemModelBoundaryConditionList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionMesh);
                if (tvItemModelBoundaryConditionList.Count == 0)
                    return ReturnTVItemError(string.Format(ServiceRes.CouldNotFindAny_, ServiceRes.MikeBoundaryCondition));

                foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList)
                {
                    TVItemModel tvItemModelBC = CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionMesh);
                    if (!string.IsNullOrWhiteSpace(tvItemModelBC.Error))
                        return ReturnTVItemError(tvItemModelBC.Error);
                }

                // Adding Copied Mike Boundary Conditions WebTide

                List<TVItemModel> tvItemModelBoundaryConditionList2 = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionWebTide);
                if (tvItemModelBoundaryConditionList2.Count == 0)
                    return ReturnTVItemError(string.Format(ServiceRes.CouldNotFindAny_, ServiceRes.MikeBoundaryCondition));

                foreach (TVItemModel tvItemModelBoundaryCondition in tvItemModelBoundaryConditionList2)
                {
                    TVItemModel tvItemModelBC = CopyMikeScenarioBoundaryCondition(tvItemModelMikeScenarioRet.TVItemID, tvItemModelBoundaryCondition, TVTypeEnum.MikeBoundaryConditionWebTide);
                    if (!string.IsNullOrWhiteSpace(tvItemModelBC.Error))
                        return ReturnTVItemError(tvItemModelBC.Error);
                }

                // Doing TVFiles

                List<TVFileModel> tvFileModelOldList = _TVFileService.GetTVFileModelListWithParentTVItemIDDB(MikeScenarioTVItemID).Where(c => c.FilePurpose == FilePurposeEnum.MikeInput || c.FilePurpose == FilePurposeEnum.MikeInputMDF || c.FilePurpose == FilePurposeEnum.MikeResultDFSU).ToList();
                foreach (TVFileModel tvFileModel in tvFileModelOldList)
                {
                    if (!(tvFileModel.FilePurpose == FilePurposeEnum.MikeResultDFSU && tvFileModel.ServerFileName.ToLower().EndsWith(".log")))
                    {
                        TVItemModel tvItemModelTVFile = CopyMikeScenarioTVFile(mikeScenarioModel, mikeScenarioModelRet, tvFileModel, TVText);
                        if (!string.IsNullOrWhiteSpace(tvItemModelTVFile.Error))
                            return ReturnTVItemError(tvItemModelTVFile.Error);
                    }
                }

                ts.Complete();
            }

            return tvItemModelMikeScenarioRet;
        }
        public MikeScenarioModel PostMikeScenarioGeneralParametersSaveDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnMikeScenarioError(contactOK.Error);

            bool DateChanged = false;
            int MikeScenarioTVItemID = 0;
            int StartYear = 0;
            int StartMonth = 0;
            int StartDay = 0;
            int HourStart = -1;
            int MinuteStart = -1;
            int EndYear = 0;
            int EndMonth = 0;
            int EndDay = 0;
            int HourEnd = -1;
            int MinuteEnd = -1;
            float DecayFactor_per_day = -1.0f;
            float DecayFactorAmplitude = -1.0f;
            float AmbientTemperature_C = -10.0f;
            float AmbientSalinity_PSU = -1.0f;
            int ResultFrequency_min = -1;
            float ManningNumber = -1.0f;
            float WindSpeed_km_h = -1.0f;
            float WindDirection_deg = -1.0f;
            bool? GenerateDecouplingFiles = false;
            bool? UseDecouplingFiles = false;
            int? UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = null;
            int? ForSimulatingMWQMRunTVItemID = null;

            int.TryParse(fc["MikeScenarioTVItemID"], out MikeScenarioTVItemID);
            if (MikeScenarioTVItemID == 0)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return ReturnMikeScenarioError(mikeScenarioModel.Error);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnMikeScenarioError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID, MikeScenarioTVItemID.ToString()));

            List<TVItemModel> tvItemModelParents = _TVItemService.GetParentsTVItemModelList(tvItemModel.TVPath);

            if (tvItemModelParents.Count == 0)
                return ReturnMikeScenarioError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, "tvItemModelParents"));

            if (tvItemModelParents[tvItemModelParents.Count - 2].TVType == TVTypeEnum.Sector)
            {
                if (fc["GenerateDecouplingFiles"] != null)
                {
                    GenerateDecouplingFiles = true;
                }

                if (fc["UseDecouplingFiles"] != null)
                {
                    UseDecouplingFiles = true;
                }

                if (int.TryParse(fc["UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID"], out int TempIntUseSalAndTemp))
                {
                    if (TempIntUseSalAndTemp != 0)
                    {
                        UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = TempIntUseSalAndTemp;
                    }
                }

                if (int.TryParse(fc["ForSimulatingMWQMRunTVItemID"], out int TempIntForSimul))
                {
                    if (TempIntForSimul != 0)
                    {
                        ForSimulatingMWQMRunTVItemID = TempIntForSimul;
                    }
                    else
                    {
                        return ReturnMikeScenarioError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, "ForSimulatingMWQMRunTVItemID"));
                    }
                }
            }

            string MikeScenarioName = fc["MikeScenarioName"];
            if (string.IsNullOrWhiteSpace(MikeScenarioName))
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioName));

            mikeScenarioModel.MikeScenarioTVText = MikeScenarioName.Trim();

            if (ForSimulatingMWQMRunTVItemID == null)
            {
                int.TryParse(fc["MikeScenarioStartYear"], out StartYear);
                if (StartYear == 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartYear));

                int.TryParse(fc["MikeScenarioStartMonth"], out StartMonth);
                if (StartMonth == 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartMonth));

                int.TryParse(fc["MikeScenarioStartDay"], out StartDay);
                if (StartDay == 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartDay));

                DateTime StartDate = new DateTime(StartYear, StartMonth, StartDay);

                string StartTime = fc["MikeScenarioStartTime"];
                if (string.IsNullOrEmpty(StartTime))
                    return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioStartTime));

                if (StartTime.Length != 5)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                if (StartTime[2].ToString() != ":")
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                int.TryParse(StartTime.Substring(0, 2), out HourStart);
                if (HourStart < 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                if (HourStart > 24)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                int.TryParse(StartTime.Substring(3, 2), out MinuteStart);
                if (MinuteStart < 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                if (MinuteStart > 60)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                StartDate = StartDate.AddHours(HourStart);
                StartDate = StartDate.AddMinutes(MinuteStart);

                if (mikeScenarioModel.MikeScenarioStartDateTime_Local != StartDate)
                {
                    mikeScenarioModel.MikeScenarioStartDateTime_Local = StartDate;
                    DateChanged = true;
                }

                int.TryParse(fc["MikeScenarioEndYear"], out EndYear);
                if (EndYear == 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndYear));

                int.TryParse(fc["MikeScenarioEndMonth"], out EndMonth);
                if (EndMonth == 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndMonth));

                int.TryParse(fc["MikeScenarioEndDay"], out EndDay);
                if (EndDay == 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndDay));

                DateTime EndDate = new DateTime(EndYear, EndMonth, EndDay);

                string EndTime = fc["MikeScenarioEndTime"];
                if (string.IsNullOrEmpty(EndTime))
                    return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioEndTime));

                if (EndTime.Length != 5)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                if (EndTime[2].ToString() != ":")
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                int.TryParse(EndTime.Substring(0, 2), out HourEnd);
                if (HourEnd < 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                if (HourEnd > 24)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                int.TryParse(EndTime.Substring(3, 2), out MinuteEnd);
                if (MinuteEnd < 0)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                if (MinuteEnd > 60)
                    return ReturnMikeScenarioError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                EndDate = EndDate.AddHours(HourEnd);
                EndDate = EndDate.AddMinutes(MinuteEnd);

                if (mikeScenarioModel.MikeScenarioEndDateTime_Local != EndDate)
                {
                    mikeScenarioModel.MikeScenarioEndDateTime_Local = EndDate;
                    DateChanged = true;
                }
            }
            else
            {
                MWQMRunModel mwqmRunModel = _MWQMRunService.GetMWQMRunModelWithMWQMRunTVItemIDDB((int)ForSimulatingMWQMRunTVItemID);
                if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
                {
                    return ReturnMikeScenarioError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMRun, ServiceRes.MWQMRunTVItemID, ((int)ForSimulatingMWQMRunTVItemID).ToString()));
                }

                mikeScenarioModel.MikeScenarioStartDateTime_Local = new DateTime(mwqmRunModel.DateTime_Local.Year, mwqmRunModel.DateTime_Local.Month, mwqmRunModel.DateTime_Local.Day);
                mikeScenarioModel.MikeScenarioEndDateTime_Local = new DateTime(mwqmRunModel.DateTime_Local.Year, mwqmRunModel.DateTime_Local.Month, mwqmRunModel.DateTime_Local.Day);

                mikeScenarioModel.MikeScenarioStartDateTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local.AddDays(-7);
                mikeScenarioModel.MikeScenarioEndDateTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local.AddDays(2);
            }

            float.TryParse(fc["DecayFactor_per_day"], out DecayFactor_per_day);
            if (DecayFactor_per_day < 0.0f)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.DecayFactor_per_day));

            mikeScenarioModel.DecayFactor_per_day = DecayFactor_per_day;

            if (fc["DecayIsConstant"] != null)
            {
                mikeScenarioModel.DecayIsConstant = true;
            }
            else
            {
                mikeScenarioModel.DecayIsConstant = false;
            }

            float.TryParse(fc["DecayFactorAmplitude"], out DecayFactorAmplitude);
            if (DecayFactorAmplitude < 0.0f)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.DecayFactorAmplitude));

            float.TryParse(fc["AmbientTemperature_C"], out AmbientTemperature_C);
            if (AmbientTemperature_C < -10.0f)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.AmbientTemperature_C));

            float.TryParse(fc["AmbientSalinity_PSU"], out AmbientSalinity_PSU);
            if (AmbientSalinity_PSU < 0.0f)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.AmbientSalinity_PSU));

            int.TryParse(fc["ResultFrequency_min"], out ResultFrequency_min);
            if (ResultFrequency_min < 0.0f)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.ResultFrequency_min));

            float.TryParse(fc["ManningNumber"], out ManningNumber);
            if (ManningNumber < 0.0f)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.ManningNumber));

            float.TryParse(fc["WindSpeed_km_h"], out WindSpeed_km_h);
            if (WindSpeed_km_h < 0.0f)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.WindSpeed_km_h));

            float.TryParse(fc["WindDirection_deg"], out WindDirection_deg);
            if (WindDirection_deg < 0.0f)
                return ReturnMikeScenarioError(string.Format(ServiceRes._IsRequired, ServiceRes.WindDirection_deg));

            mikeScenarioModel.DecayFactorAmplitude = DecayFactorAmplitude;
            mikeScenarioModel.AmbientTemperature_C = AmbientTemperature_C;
            mikeScenarioModel.AmbientSalinity_PSU = AmbientSalinity_PSU;
            mikeScenarioModel.GenerateDecouplingFiles = GenerateDecouplingFiles;
            mikeScenarioModel.UseDecouplingFiles = UseDecouplingFiles;
            mikeScenarioModel.UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID = UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID;
            mikeScenarioModel.ForSimulatingMWQMRunTVItemID = ForSimulatingMWQMRunTVItemID;
            mikeScenarioModel.ResultFrequency_min = ResultFrequency_min;
            mikeScenarioModel.ManningNumber = ManningNumber;
            mikeScenarioModel.WindSpeed_km_h = WindSpeed_km_h;
            mikeScenarioModel.WindDirection_deg = WindDirection_deg;

            MikeScenarioModel mikeScenarioModelRet = new MikeScenarioModel();
            using (TransactionScope ts = new TransactionScope())
            {
                mikeScenarioModelRet = PostUpdateMikeScenarioDB(mikeScenarioModel);
                if (!string.IsNullOrWhiteSpace(mikeScenarioModelRet.Error))
                    return ReturnMikeScenarioError(mikeScenarioModelRet.Error);

                MikeBoundaryConditionService mikeBoundaryConditionService = new MikeBoundaryConditionService(LanguageRequest, User);
                List<MikeBoundaryConditionModel> mbcModelList = mikeBoundaryConditionService.GetMikeBoundaryConditionModelListWithMikeScenarioTVItemIDAndTVTypeDB(mikeScenarioModel.MikeScenarioTVItemID, TVTypeEnum.MikeBoundaryConditionWebTide);
                if (mbcModelList.Count == 0)
                {
                    return ReturnMikeScenarioError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MikeBoundaryCondition, ServiceRes.MikeScenarioTVItemID + "," + ServiceRes.MikeBoundaryConditionWebTide, MikeScenarioTVItemID.ToString() + "," + TVTypeEnum.MikeBoundaryConditionWebTide.ToString()));
                }

                foreach (MikeBoundaryConditionModel mbcm in mbcModelList)
                {
                    mbcm.WebTideDataFromStartToEndDate = "";
                    MikeBoundaryConditionModel mbcmRet = mikeBoundaryConditionService.PostUpdateMikeBoundaryConditionDB(mbcm);
                    if (!string.IsNullOrWhiteSpace(mbcmRet.Error))
                    {
                        return ReturnMikeScenarioError(mbcmRet.Error);
                    }
                }

                ts.Complete();
            }

            return mikeScenarioModelRet;
        }
        public TVFileModel PostMikeScenarioOtherFileNotImportDB(int TVFileTVItemID)
        {
            if (TVFileTVItemID == 0)
                return ReturnTVFileError(string.Format(ServiceRes._IsRequired, ServiceRes.TVFileTVItemID));

            TVFileModel tvFileModelRet = new TVFileModel();
            using (TransactionScope ts = new TransactionScope())
            {
                TVFileModel tvFileModel = _TVFileService.GetTVFileModelWithTVFileTVItemIDDB(TVFileTVItemID);
                if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
                    return ReturnTVFileError(tvFileModel.Error);

                tvFileModel.FileSize_kb = -1;

                tvFileModelRet = _TVFileService.PostUpdateTVFileDB(tvFileModel);
                if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
                    return ReturnTVFileError(tvFileModelRet.Error);

                ts.Complete();
            }

            return tvFileModelRet;
        }
        public MikeSourceModel PostMikeSourceAddOrModifyDB(FormCollection fc)
        {
            int MikeScenarioTVItemID = 0;
            int MikeSourceTVItemID = 0;
            string MikeSourceName = "";
            bool Include = false;
            bool IsRiver = false;
            bool IsContinuous = false;
            bool UseHydrometric = false;
            int? HydrometricTVItemID = null;
            double? DrainageArea_km2 = null;
            double? Factor = null;
            float Lat = 0.0f;
            float Lng = 0.0f;

            int.TryParse(fc["MikeScenarioTVItemID"], out MikeScenarioTVItemID);
            if (MikeScenarioTVItemID == 0)
                return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID));

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return ReturnMikeSourceError(mikeScenarioModel.Error);

            int.TryParse(fc["MikeSourceTVItemID"], out MikeSourceTVItemID);

            MikeSourceModel mikeSourceModel = null;
            if (MikeSourceTVItemID != 0)
            {
                mikeSourceModel = _MikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(MikeSourceTVItemID);
                if (!string.IsNullOrWhiteSpace(mikeSourceModel.Error))
                    return ReturnMikeSourceError(mikeSourceModel.Error);
            }

            MikeSourceName = fc["SourceName"].Trim();
            if (string.IsNullOrEmpty(MikeSourceName))
                return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.SourceName));

            if (!string.IsNullOrWhiteSpace(fc["Include"]))
            {
                Include = true;
            }

            if (!string.IsNullOrWhiteSpace(fc["IsRiver"]))
            {
                IsRiver = true;
            }

            if (!string.IsNullOrWhiteSpace(fc["IsContinuous"]))
            {
                IsContinuous = true;
            }

            float.TryParse(fc["Lat"], out Lat);
            if (Lat == 0.0f)
                return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.Lat));

            float.TryParse(fc["Lng"], out Lng);
            if (Lng == 0.0f)
                return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.Lng));

            if (!string.IsNullOrWhiteSpace(fc["UseHydrometric"]))
            {
                UseHydrometric = true;
            }

            if (!IsRiver)
            {
                UseHydrometric = false;
                HydrometricTVItemID = null;
                DrainageArea_km2 = null;
                Factor = null;
            }

            if (UseHydrometric)
            {
                int TempHydrometricTVItemID = 0;
                int.TryParse(fc["HydrometricTVItemID"], out TempHydrometricTVItemID);
                if (TempHydrometricTVItemID == 0)
                    return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.HydrometricTVItemID));

                HydrometricTVItemID = TempHydrometricTVItemID;

                double TempDrainageArea_km2 = 0.0D;
                double.TryParse(fc["DrainageArea_km2"], out TempDrainageArea_km2);
                if (TempDrainageArea_km2 == 0.0D)
                    return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.DrainageArea_km2));

                DrainageArea_km2 = TempDrainageArea_km2;

                double TempFactor = 0.0D;
                double.TryParse(fc["Factor"], out TempFactor);
                if (TempFactor == 0.0D)
                    return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.Factor));

                Factor = TempFactor;
            }

            MikeSourceModel mikeSourceModelRet = new MikeSourceModel();

            using (TransactionScope ts = new TransactionScope())
            {
                if (MikeSourceTVItemID == 0)
                {
                    MikeSourceModel mikeSourceAlreadyExist = _MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID).Where(c => c.MikeSourceTVText == MikeSourceName && c.MikeSourceTVItemID != MikeSourceTVItemID).FirstOrDefault();
                    if (mikeSourceAlreadyExist != null)
                        return ReturnMikeSourceError(string.Format(ServiceRes.MikeSource_AlreadyExist, MikeSourceName));

                    MikeSourceModel mikeSourceModelOld = new MikeSourceModel()
                    {
                        MikeSourceTVText = MikeSourceName,
                    };

                    string TVText = _MikeSourceService.CreateTVText(mikeSourceModelOld);
                    if (string.IsNullOrWhiteSpace(TVText))
                        return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                    TVItemModel tvItemMikeSourceModel = _TVItemService.PostAddChildTVItemDB(MikeScenarioTVItemID, TVText, TVTypeEnum.MikeSource);
                    if (!string.IsNullOrWhiteSpace(tvItemMikeSourceModel.Error))
                        return ReturnMikeSourceError(tvItemMikeSourceModel.Error);

                    List<MikeSourceModel> mikeSourceModelList = _MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID);

                    // Getting next available SourceNumberString
                    bool ok = false;
                    int i = 0;
                    string NewSourceNumberString = "";
                    while (!ok)
                    {
                        i += 1;
                        NewSourceNumberString = "SOURCE_" + i.ToString().Trim();

                        if (!mikeSourceModelList.Where(c => c.SourceNumberString == NewSourceNumberString).Any())
                        {
                            ok = true;
                        }

                        if (i > 2000)
                            return ReturnMikeSourceError(ServiceRes.CouldNotCreateNewSource);
                    }

                    MikeSourceModel mikeSourceModelNew = new MikeSourceModel();
                    mikeSourceModelNew.IsContinuous = IsContinuous;
                    mikeSourceModelNew.Include = Include;
                    mikeSourceModelNew.IsRiver = IsRiver;
                    mikeSourceModelNew.UseHydrometric = UseHydrometric;
                    mikeSourceModelNew.HydrometricTVItemID = HydrometricTVItemID;
                    mikeSourceModelNew.DrainageArea_km2 = DrainageArea_km2;
                    mikeSourceModelNew.Factor = Factor;
                    mikeSourceModelNew.LastUpdateDate_UTC = DateTime.UtcNow;
                    mikeSourceModelNew.SourceNumberString = NewSourceNumberString;
                    mikeSourceModelNew.MikeSourceTVItemID = tvItemMikeSourceModel.TVItemID;
                    mikeSourceModelNew.MikeSourceTVText = tvItemMikeSourceModel.TVText;

                    mikeSourceModelRet = _MikeSourceService.PostAddMikeSourceDB(mikeSourceModelNew);
                    if (!string.IsNullOrWhiteSpace(mikeSourceModelRet.Error))
                        return ReturnMikeSourceError(mikeSourceModelRet.Error);

                    List<Coord> coordListSource = new List<Coord>() { new Coord() { Lat = Lat, Lng = Lng } };

                    MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordListSource, MapInfoDrawTypeEnum.Point, TVTypeEnum.MikeSource, mikeSourceModelRet.MikeSourceTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnMikeSourceError(mapInfoModelRet.Error);


                    MikeSourceStartEndModel mikeSourceStartEndModelNew = new MikeSourceStartEndModel()
                    {
                        EndDateAndTime_Local = mikeScenarioModel.MikeScenarioEndDateTime_Local,
                        MikeSourceID = mikeSourceModelRet.MikeSourceID,
                        SourceFlowEnd_m3_day = 1234f,
                        SourceFlowStart_m3_day = 1234f,
                        SourcePollutionEnd_MPN_100ml = 3200000,
                        SourcePollutionStart_MPN_100ml = 3200000,
                        SourceSalinityEnd_PSU = 0f,
                        SourceSalinityStart_PSU = 0f,
                        SourceTemperatureEnd_C = 15f,
                        SourceTemperatureStart_C = 15f,
                        StartDateAndTime_Local = mikeScenarioModel.MikeScenarioStartDateTime_Local,
                    };

                    MikeSourceStartEndModel mikeSourceStartEndModelRet = _MikeSourceService._MikeSourceStartEndService.PostAddMikeSourceStartEndDB(mikeSourceStartEndModelNew);
                    if (!string.IsNullOrWhiteSpace(mikeSourceStartEndModelRet.Error))
                        return ReturnMikeSourceError(mikeSourceStartEndModelRet.Error);
                }
                else
                {
                    MikeSourceModel mikeSourceAlreadyExist = _MikeSourceService.GetMikeSourceModelListWithMikeScenarioTVItemIDDB(MikeScenarioTVItemID).Where(c => c.MikeSourceTVText == MikeSourceName && c.MikeSourceTVItemID != MikeSourceTVItemID).FirstOrDefault();
                    if (mikeSourceAlreadyExist != null)
                        return ReturnMikeSourceError(string.Format(ServiceRes.MikeSource_AlreadyExist, MikeSourceName));

                    mikeSourceModel.IsContinuous = IsContinuous;
                    mikeSourceModel.Include = Include;
                    mikeSourceModel.IsRiver = IsRiver;
                    mikeSourceModel.UseHydrometric = UseHydrometric;
                    mikeSourceModel.HydrometricTVItemID = HydrometricTVItemID;
                    mikeSourceModel.DrainageArea_km2 = DrainageArea_km2;
                    mikeSourceModel.Factor = Factor;
                    mikeSourceModel.MikeSourceTVText = MikeSourceName;

                    mikeSourceModelRet = _MikeSourceService.PostUpdateMikeSourceDB(mikeSourceModel);
                    if (!string.IsNullOrWhiteSpace(mikeSourceModelRet.Error))
                        return ReturnMikeSourceError(mikeSourceModelRet.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(MikeSourceTVItemID, TVTypeEnum.MikeSource, MapInfoDrawTypeEnum.Point);
                    if (mapInfoPointModelList.Count == 0)
                        return ReturnMikeSourceError(string.Format(ServiceRes._ShouldNotBeNullOrEmpty, ServiceRes.MapInfoPoint));

                    if (mapInfoPointModelList[0].Lat != Lat)
                    {
                        mapInfoPointModelList[0].Lat = Lat;
                    }

                    if (mapInfoPointModelList[0].Lng != Lng)
                    {
                        mapInfoPointModelList[0].Lng = Lng;
                    }

                    MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                        return ReturnMikeSourceError(mapInfoPointModelRet.Error);

                }

                ts.Complete();
            }

            return mikeSourceModelRet;
        }
        public MikeSourceModel PostMikeSourceDeleteDB(int MikeSourceTVItemID)
        {
            if (MikeSourceTVItemID == 0)
                return ReturnMikeSourceError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID));

            TVItemModel tvItemModelMikeScenario = _TVItemService.GetParentTVItemModelWithTVItemIDForLocationDB(MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMikeScenario.Error))
                return ReturnMikeSourceError(tvItemModelMikeScenario.Error);

            MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeScenario.TVItemID);
            if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                return ReturnMikeSourceError(mikeScenarioModel.Error);

            MikeSourceModel mikeSourceModel = _MikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeSourceModel.Error))
                return ReturnMikeSourceError(mikeSourceModel.Error);

            MikeSourceModel mikeSourceModelRet = new MikeSourceModel();

            using (TransactionScope ts = new TransactionScope())
            {
                mikeSourceModelRet = _MikeSourceService.PostDeleteMikeSourceWithTVItemIDDB(MikeSourceTVItemID);
                if (!string.IsNullOrWhiteSpace(mikeSourceModelRet.Error))
                    return ReturnMikeSourceError(mikeSourceModelRet.Error);

                ts.Complete();
            }

            return mikeSourceModelRet;
        }
        public MikeSourceStartEndModel PostMikeSourceStartEndAddDB(int MikeSourceTVItemID)
        {
            if (MikeSourceTVItemID == 0)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID));

            MikeSourceModel mikeSourceModelRet = _MikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeSourceModelRet.Error))
                return ReturnMikeSourceStartEndError(mikeSourceModelRet.Error);

            List<MikeSourceStartEndModel> mikeSourcestartEndModelList = _MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelListWithMikeSourceTVItemIDDB(mikeSourceModelRet.MikeSourceTVItemID);

            DateTime LatestDate = new DateTime(1966, 1, 1);
            foreach (MikeSourceStartEndModel mikeSourceStartEndModel in mikeSourcestartEndModelList)
            {
                if (mikeSourceStartEndModel.EndDateAndTime_Local > LatestDate)
                {
                    LatestDate = mikeSourceStartEndModel.EndDateAndTime_Local;
                }
            }

            MikeSourceStartEndModel mikeSourceStartEndModelNew = new MikeSourceStartEndModel()
            {
                MikeSourceID = mikeSourceModelRet.MikeSourceID,
                StartDateAndTime_Local = LatestDate.AddHours(1),
                EndDateAndTime_Local = LatestDate.AddHours(2),
                SourceFlowStart_m3_day = 1f,
                SourceFlowEnd_m3_day = 1f,
                SourcePollutionStart_MPN_100ml = 3200000,
                SourcePollutionEnd_MPN_100ml = 3200000,
                SourceSalinityStart_PSU = 0f,
                SourceSalinityEnd_PSU = 0f,
                SourceTemperatureStart_C = 15f,
                SourceTemperatureEnd_C = 15f,
            };

            MikeSourceStartEndModel mikeSourceStartEndModelRet = new MikeSourceStartEndModel();

            using (TransactionScope ts = new TransactionScope())
            {

                mikeSourceStartEndModelRet = _MikeSourceService._MikeSourceStartEndService.PostAddMikeSourceStartEndDB(mikeSourceStartEndModelNew);
                if (!string.IsNullOrWhiteSpace(mikeSourceStartEndModelRet.Error))
                    return ReturnMikeSourceStartEndError(mikeSourceStartEndModelRet.Error);

                ts.Complete();
            }

            return mikeSourceStartEndModelRet;
        }
        public MikeSourceStartEndModel PostMikeSourceStartEndDeleteDB(int MikeSourceStartEndID, int MikeSourceTVItemID)
        {
            if (MikeSourceTVItemID == 0)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID));

            if (MikeSourceStartEndID == 0)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartEndID));

            MikeSourceModel mikeSourceModel = _MikeSourceService.GetMikeSourceModelWithMikeSourceTVItemIDDB(MikeSourceTVItemID);
            if (!string.IsNullOrWhiteSpace(mikeSourceModel.Error))
                return ReturnMikeSourceStartEndError(mikeSourceModel.Error);

            MikeSourceStartEndModel mikeSourceStartEndModelRet = new MikeSourceStartEndModel();

            using (TransactionScope ts = new TransactionScope())
            {
                mikeSourceStartEndModelRet = _MikeSourceService._MikeSourceStartEndService.PostDeleteMikeSourceStartEndDB(MikeSourceStartEndID);
                if (!string.IsNullOrWhiteSpace(mikeSourceStartEndModelRet.Error))
                    return ReturnMikeSourceStartEndError(mikeSourceStartEndModelRet.Error);

                ts.Complete();
            }

            return mikeSourceStartEndModelRet;
        }
        public MikeSourceStartEndModel PostMikeSourceStartEndSaveDB(FormCollection fc)
        {
            int MikeSourceID = 0;
            int MikeSourceStartEndID = 0;
            int StartYear = 0;
            int StartMonth = 0;
            int StartDay = 0;
            int HourStart = -1;
            int MinuteStart = -1;
            int EndYear = 0;
            int EndMonth = 0;
            int EndDay = 0;
            int HourEnd = -1;
            int MinuteEnd = -1;
            float SourceFlowStart_m3_day = -1.0f;
            int SourcePollutionStart_MPN_100ml = -1;
            float SourceTemperatureStart_C = -10.0f;
            float SourceSalinityStart_PSU = -1.0f;
            float SourceFlowEnd_m3_day = -1.0f;
            int SourcePollutionEnd_MPN_100ml = -1;
            float SourceTemperatureEnd_C = -10.0f;
            float SourceSalinityEnd_PSU = -1.0f;

            int.TryParse(fc["MikeSourceID"], out MikeSourceID);
            if (MikeSourceID == 0)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceTVItemID));

            MikeSourceModel mikeSourceModel = _MikeSourceService.GetMikeSourceModelWithMikeSourceIDDB(MikeSourceID);
            if (!string.IsNullOrWhiteSpace(mikeSourceModel.Error))
                return ReturnMikeSourceStartEndError(mikeSourceModel.Error);

            int.TryParse(fc["MikeSourceStartEndID"], out MikeSourceStartEndID);
            if (MikeSourceStartEndID == 0)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartEndID));

            MikeSourceStartEndModel mikeSourceStartEndModel = _MikeSourceService._MikeSourceStartEndService.GetMikeSourceStartEndModelWithMikeSourceStartEndIDDB(MikeSourceStartEndID);
            if (!string.IsNullOrWhiteSpace(mikeSourceStartEndModel.Error))
                return ReturnMikeSourceStartEndError(mikeSourceStartEndModel.Error);

            DateTime StartDate = new DateTime(1900, 1, 1);
            DateTime EndDate = new DateTime(1900, 1, 1);
            if (mikeSourceModel.IsContinuous && !mikeSourceModel.UseHydrometric)
            {
                TVItemModel tvItemModelMikeSource = _TVItemService.GetTVItemModelWithTVItemIDDB(mikeSourceModel.MikeSourceTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelMikeSource.Error))
                    return ReturnMikeSourceStartEndError(tvItemModelMikeSource.Error);

                MikeScenarioModel mikeScenarioModel = GetMikeScenarioModelWithMikeScenarioTVItemIDDB(tvItemModelMikeSource.ParentID);
                if (!string.IsNullOrWhiteSpace(mikeScenarioModel.Error))
                    return ReturnMikeSourceStartEndError(mikeScenarioModel.Error);

                StartDate = mikeScenarioModel.MikeScenarioStartDateTime_Local;
                EndDate = mikeScenarioModel.MikeScenarioEndDateTime_Local;
            }
            else
            {
                int.TryParse(fc["MikeSourceStartYear"], out StartYear);
                if (StartYear == 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartYear));

                int.TryParse(fc["MikeSourceStartMonth"], out StartMonth);
                if (StartMonth == 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartMonth));

                int.TryParse(fc["MikeSourceStartDay"], out StartDay);
                if (StartDay == 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartDay));

                StartDate = new DateTime(StartYear, StartMonth, StartDay);

                string StartTime = fc["MikeSourceStartTime"];
                if (string.IsNullOrEmpty(StartTime))
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceStartTime));

                if (StartTime.Length != 5)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                if (StartTime[2].ToString() != ":")
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                int.TryParse(StartTime.Substring(0, 2), out HourStart);
                if (HourStart < 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                if (HourStart > 24)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                int.TryParse(StartTime.Substring(3, 2), out MinuteStart);
                if (MinuteStart < 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                if (MinuteStart > 60)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, StartTime));

                StartDate = StartDate.AddHours(HourStart);
                StartDate = StartDate.AddMinutes(MinuteStart);

                EndDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartDate.Hour, StartDate.Minute, StartDate.Second);

                int.TryParse(fc["MikeSourceEndYear"], out EndYear);
                if (EndYear == 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndYear));

                int.TryParse(fc["MikeSourceEndMonth"], out EndMonth);
                if (EndMonth == 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndMonth));

                int.TryParse(fc["MikeSourceEndDay"], out EndDay);
                if (EndDay == 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndDay));

                EndDate = new DateTime(EndYear, EndMonth, EndDay);

                string EndTime = fc["MikeSourceEndTime"];
                if (string.IsNullOrEmpty(EndTime))
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.MikeSourceEndTime));

                if (EndTime.Length != 5)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                if (EndTime[2].ToString() != ":")
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                int.TryParse(EndTime.Substring(0, 2), out HourEnd);
                if (HourEnd < 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                if (HourEnd > 24)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                int.TryParse(EndTime.Substring(3, 2), out MinuteEnd);
                if (MinuteEnd < 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                if (MinuteEnd > 60)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes.Time_NotWellFormed, EndTime));

                EndDate = EndDate.AddHours(HourEnd);
                EndDate = EndDate.AddMinutes(MinuteEnd);


                mikeSourceStartEndModel.StartDateAndTime_Local = StartDate;
            }

            float.TryParse(fc["SourceFlowStart_m3_day"], out SourceFlowStart_m3_day);
            if (SourceFlowStart_m3_day < 0.0f)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.SourceFlowStart_m3_day));

            int.TryParse(fc["SourcePollutionStart_MPN_100ml"], out SourcePollutionStart_MPN_100ml);
            if (SourcePollutionStart_MPN_100ml < 0)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.SourcePollutionStart_MPN_100ml));

            float.TryParse(fc["SourceTemperatureStart_C"], out SourceTemperatureStart_C);
            if (SourceTemperatureStart_C < -10.0f)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.SourceTemperatureStart_C));

            float.TryParse(fc["SourceSalinityStart_PSU"], out SourceSalinityStart_PSU);
            if (SourceSalinityStart_PSU < 0.0f)
                return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.SourceSalinityStart_PSU));

            mikeSourceStartEndModel.SourceFlowStart_m3_day = SourceFlowStart_m3_day;
            mikeSourceStartEndModel.SourcePollutionStart_MPN_100ml = SourcePollutionStart_MPN_100ml;
            mikeSourceStartEndModel.SourceTemperatureStart_C = SourceTemperatureStart_C;
            mikeSourceStartEndModel.SourceSalinityStart_PSU = SourceSalinityStart_PSU;
            if (!(bool)mikeSourceModel.IsContinuous)
            {
                mikeSourceStartEndModel.EndDateAndTime_Local = EndDate;

                float.TryParse(fc["SourceFlowEnd_m3_day"], out SourceFlowEnd_m3_day);
                if (SourceFlowEnd_m3_day < 0.0f)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.SourceFlowEnd_m3_day));

                int.TryParse(fc["SourcePollutionEnd_MPN_100ml"], out SourcePollutionEnd_MPN_100ml);
                if (SourcePollutionEnd_MPN_100ml < 0)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.SourcePollutionEnd_MPN_100ml));

                float.TryParse(fc["SourceTemperatureEnd_C"], out SourceTemperatureEnd_C);
                if (SourceTemperatureEnd_C < -10.0f)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.SourceTemperatureEnd_C));

                float.TryParse(fc["SourceSalinityEnd_PSU"], out SourceSalinityEnd_PSU);
                if (SourceSalinityEnd_PSU < 0.0f)
                    return ReturnMikeSourceStartEndError(string.Format(ServiceRes._IsRequired, ServiceRes.SourceSalinityEnd_PSU));

                mikeSourceStartEndModel.SourceFlowEnd_m3_day = SourceFlowEnd_m3_day;
                mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml = SourcePollutionEnd_MPN_100ml;
                mikeSourceStartEndModel.SourceTemperatureEnd_C = SourceTemperatureEnd_C;
                mikeSourceStartEndModel.SourceSalinityEnd_PSU = SourceSalinityEnd_PSU;
            }
            else
            {
                mikeSourceStartEndModel.EndDateAndTime_Local = EndDate;
                mikeSourceStartEndModel.SourceFlowEnd_m3_day = SourceFlowStart_m3_day;
                mikeSourceStartEndModel.SourcePollutionEnd_MPN_100ml = SourcePollutionStart_MPN_100ml;
                mikeSourceStartEndModel.SourceTemperatureEnd_C = SourceTemperatureStart_C;
                mikeSourceStartEndModel.SourceSalinityEnd_PSU = SourceSalinityStart_PSU;
            }

            MikeSourceStartEndModel mikeSourceStartEndModelRet = new MikeSourceStartEndModel();

            using (TransactionScope ts = new TransactionScope())
            {
                mikeSourceStartEndModelRet = _MikeSourceService._MikeSourceStartEndService.PostUpdateMikeSourceStartEndDB(mikeSourceStartEndModel);
                if (!string.IsNullOrWhiteSpace(mikeSourceStartEndModelRet.Error))
                    return ReturnMikeSourceStartEndError(mikeSourceStartEndModelRet.Error);

                ts.Complete();
            }

            return mikeSourceStartEndModelRet;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
