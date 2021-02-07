using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;


namespace CSSPDBDLL.Services
{
    public class BoxModelService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public BoxModelLanguageService _BoxModelLanguageService { get; set; }
        public BoxModelResultService _BoxModelResultService { get; set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public BoxModelService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _BoxModelLanguageService = new BoxModelLanguageService(LanguageRequest, User);
            _BoxModelResultService = new BoxModelResultService(LanguageRequest, User);
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
        public string BoxModelModelOK(BoxModelModel boxModelModel)
        {
            string retStr = FieldCheckNotZeroInt(boxModelModel.InfrastructureTVItemID, ServiceRes.InfraTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(boxModelModel.ScenarioName, ServiceRes.ScenarioName, 2, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(boxModelModel.Discharge_m3_day, ServiceRes.Discharge_m3_day, (double)1D, (double)30000000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(boxModelModel.Depth_m, ServiceRes.Depth_m, (double)0.01D, (double)10000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(boxModelModel.Temperature_C, ServiceRes.Temperature_C, (double)0.1D, (double)35D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(boxModelModel.Dilution, ServiceRes.Dilution, (double)1D, (double)30000000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(boxModelModel.DecayRate_per_day, ServiceRes.DecayRate_per_day, (double)0.0001D, (double)1000D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(boxModelModel.FCUntreated_MPN_100ml, ServiceRes.FCUntreated_MPN_100ml, 1, 30000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(boxModelModel.FCPreDisinfection_MPN_100ml, ServiceRes.FCPreDisinfection_MPN_100ml, 1, 30000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(boxModelModel.Concentration_MPN_100ml, ServiceRes.Concentration_MPN_100ml, 1, 30000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(boxModelModel.DischargeDuration_hour, ServiceRes.DischargeDuration_hour, 1, 24);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(boxModelModel.T90_hour, ServiceRes.T90_hour, 1, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(boxModelModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }
        public string CheckUniquenessOfBoxModelScenarioNameDB(int InfrastructureTVItemID, int BoxModelID, string ScenarioName)
        {
            BoxModelModel boxModelModel = (from c in db.BoxModels
                                                     let scenarioName = (from bl in db.BoxModelLanguages where bl.Language == (int)LanguageRequest && bl.BoxModelID == c.BoxModelID select bl.ScenarioName).FirstOrDefault<string>()
                                                     where c.InfrastructureTVItemID == InfrastructureTVItemID
                                                     orderby scenarioName
                                                     select new BoxModelModel
                                                     {
                                                         Error = "",
                                                         BoxModelID = c.BoxModelID,
                                                         DBCommand = (DBCommandEnum)c.DBCommand,
                                                         ScenarioName = scenarioName,
                                                         InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                         Discharge_m3_day = c.Discharge_m3_day,
                                                         Depth_m = c.Depth_m,
                                                         Temperature_C = c.Temperature_C,
                                                         Dilution = c.Dilution,
                                                         DecayRate_per_day = c.DecayRate_per_day,
                                                         FCUntreated_MPN_100ml = c.FCUntreated_MPN_100ml,
                                                         FCPreDisinfection_MPN_100ml = c.FCPreDisinfection_MPN_100ml,
                                                         Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                                         DischargeDuration_hour = c.DischargeDuration_hour,
                                                         T90_hour = c.T90_hour,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).Where(c => c.ScenarioName == ScenarioName && c.BoxModelID != BoxModelID).FirstOrDefault();

            if (boxModelModel == null)
            {
                return "true";
            }

            return string.Format(ServiceRes._AlreadyExists, ScenarioName);
        }

        // Fill
        public string FillBoxModel(BoxModel boxModel, BoxModelModel boxModelModel, ContactOK contactOK)
        {
            boxModel.DBCommand = (int)boxModelModel.DBCommand;
            boxModel.InfrastructureTVItemID = boxModelModel.InfrastructureTVItemID;
            boxModel.Discharge_m3_day = boxModelModel.Discharge_m3_day;
            boxModel.Depth_m = boxModelModel.Depth_m;
            boxModel.Temperature_C = boxModelModel.Temperature_C;
            boxModel.Dilution = boxModelModel.Dilution;
            boxModel.DecayRate_per_day = boxModelModel.DecayRate_per_day;
            boxModel.FCUntreated_MPN_100ml = boxModelModel.FCUntreated_MPN_100ml;
            boxModel.FCPreDisinfection_MPN_100ml = boxModelModel.FCPreDisinfection_MPN_100ml;
            boxModel.Concentration_MPN_100ml = boxModelModel.Concentration_MPN_100ml;
            boxModel.DischargeDuration_hour = boxModelModel.DischargeDuration_hour;
            boxModel.T90_hour = boxModelModel.T90_hour;
            boxModel.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                boxModel.LastUpdateContactTVItemID = 2;
            }
            else
            {
                boxModel.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetBoxModelModelCountDB()
        {
            int BoxModelModelCount = (from c in db.BoxModels
                                      select c).Count();

            return BoxModelModelCount;
        }
        public List<BoxModelModel> GetBoxModelModelOrderByScenarioNameDB(int InfrastructureTVItemID)
        {
            List<BoxModelModel> boxModelModelList = (from c in db.BoxModels
                                                     let scenarioName = (from bl in db.BoxModelLanguages where bl.Language == (int)LanguageRequest && bl.BoxModelID == c.BoxModelID select bl.ScenarioName).FirstOrDefault<string>()
                                                     where c.InfrastructureTVItemID == InfrastructureTVItemID
                                                     orderby scenarioName
                                                     select new BoxModelModel
                                                     {
                                                         Error = "",
                                                         BoxModelID = c.BoxModelID,
                                                         DBCommand = (DBCommandEnum)c.DBCommand,
                                                         ScenarioName = scenarioName,
                                                         InfrastructureTVItemID = c.InfrastructureTVItemID,
                                                         Discharge_m3_day = c.Discharge_m3_day,
                                                         Depth_m = c.Depth_m,
                                                         Temperature_C = c.Temperature_C,
                                                         Dilution = c.Dilution,
                                                         DecayRate_per_day = c.DecayRate_per_day,
                                                         FCUntreated_MPN_100ml = c.FCUntreated_MPN_100ml,
                                                         FCPreDisinfection_MPN_100ml = c.FCPreDisinfection_MPN_100ml,
                                                         Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                                         DischargeDuration_hour = c.DischargeDuration_hour,
                                                         T90_hour = c.T90_hour,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).ToList<BoxModelModel>();

            return boxModelModelList;
        }
        public BoxModelModel GetBoxModelModelWithBoxModelIDDB(int BoxModelID)
        {
            BoxModelModel boxModelModel = (from c in db.BoxModels
                                           let scenarioName = (from bl in db.BoxModelLanguages where bl.Language == (int)LanguageRequest && bl.BoxModelID == c.BoxModelID select bl.ScenarioName).FirstOrDefault<string>()
                                           where c.BoxModelID == BoxModelID
                                           select new BoxModelModel
                                           {
                                               Error = "",
                                               BoxModelID = c.BoxModelID,
                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                               ScenarioName = scenarioName,
                                               InfrastructureTVItemID = c.InfrastructureTVItemID,
                                               Discharge_m3_day = c.Discharge_m3_day,
                                               Depth_m = c.Depth_m,
                                               Temperature_C = c.Temperature_C,
                                               Dilution = c.Dilution,
                                               DecayRate_per_day = c.DecayRate_per_day,
                                               FCUntreated_MPN_100ml = c.FCUntreated_MPN_100ml,
                                               FCPreDisinfection_MPN_100ml = c.FCPreDisinfection_MPN_100ml,
                                               Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                               DischargeDuration_hour = c.DischargeDuration_hour,
                                               T90_hour = c.T90_hour,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<BoxModelModel>();

            if (boxModelModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModel, ServiceRes.BoxModelID, BoxModelID));

            return boxModelModel;
        }
        public BoxModelModel GetBoxModelModelWithInfrastructureTVItemIDAndScenarioNameDB(int InfrastructureTVItemID, string ScenarioName)
        {
            BoxModelModel boxModelModel = (from c in db.BoxModels
                                           from cl in db.BoxModelLanguages
                                           let scenarioName = (from bl in db.BoxModelLanguages where bl.Language == (int)LanguageRequest && bl.BoxModelID == c.BoxModelID select bl.ScenarioName).FirstOrDefault<string>()
                                           where c.BoxModelID == cl.BoxModelID
                                           && c.InfrastructureTVItemID == InfrastructureTVItemID
                                           && cl.ScenarioName == ScenarioName
                                           select new BoxModelModel
                                           {
                                               Error = "",
                                               BoxModelID = c.BoxModelID,
                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                               ScenarioName = scenarioName,
                                               InfrastructureTVItemID = c.InfrastructureTVItemID,
                                               Discharge_m3_day = c.Discharge_m3_day,
                                               Depth_m = c.Depth_m,
                                               Temperature_C = c.Temperature_C,
                                               Dilution = c.Dilution,
                                               DecayRate_per_day = c.DecayRate_per_day,
                                               FCUntreated_MPN_100ml = c.FCUntreated_MPN_100ml,
                                               FCPreDisinfection_MPN_100ml = c.FCPreDisinfection_MPN_100ml,
                                               Concentration_MPN_100ml = c.Concentration_MPN_100ml,
                                               DischargeDuration_hour = c.DischargeDuration_hour,
                                               T90_hour = c.T90_hour,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<BoxModelModel>();

            if (boxModelModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.BoxModel, ServiceRes.InfrastructureTVItemID + "," + ServiceRes.ScenarioName, InfrastructureTVItemID + "," + ScenarioName));

            return boxModelModel;
        }
        public BoxModel GetBoxModelWithBoxModelIDDB(int BoxModelID)
        {
            BoxModel boxModel = (from c in db.BoxModels
                                 where c.BoxModelID == BoxModelID
                                 select c).FirstOrDefault<BoxModel>();

            return boxModel;
        }
        public BoxModel GetBoxModelWithInfrastructureTVItemIDAndScenarioNameDB(int InfrastructureTVItemID, string ScenarioName)
        {
            BoxModel boxModel = (from c in db.BoxModels
                                 from cl in db.BoxModelLanguages
                                 where c.BoxModelID == cl.BoxModelID
                                 && c.InfrastructureTVItemID == InfrastructureTVItemID
                                 && cl.ScenarioName == ScenarioName
                                 && cl.Language == (int)LanguageRequest
                                 select c).FirstOrDefault<BoxModel>();

            return boxModel;
        }

        // Helper
        public BoxModelModel AddOrUpdateBoxModelResultModel(BoxModelModel boxModelModel)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            bool ShouldAdd = true;
            for (int i = 1; i < 6; i++)
            {
                BoxModelResultModel boxModelResultModel;
                BoxModelResultModel boxModelResultModelRet = _BoxModelResultService.GetBoxModelResultModelWithBoxModelIDAndResultTypeDB(boxModelModel.BoxModelID, (BoxModelResultTypeEnum)i);
                if (!string.IsNullOrWhiteSpace(boxModelResultModelRet.Error))
                {
                    ShouldAdd = true;
                    boxModelResultModel = new BoxModelResultModel();
                }
                else
                {
                    ShouldAdd = false;
                    boxModelResultModel = boxModelResultModelRet;
                }
                boxModelResultModel.DBCommand = DBCommandEnum.Original;
                boxModelResultModel.BoxModelID = boxModelModel.BoxModelID;
                boxModelResultModel.BoxModelResultType = (BoxModelResultTypeEnum)i;
                switch (i)
                {
                    case (int)BoxModelResultTypeEnum.Dilution:
                        {
                            boxModelResultModel.Volume_m3 = (boxModelModel.Discharge_m3_day * (boxModelModel.DischargeDuration_hour / 24) * boxModelModel.Dilution);
                        }
                        break;
                    case (int)BoxModelResultTypeEnum.NoDecayUntreated:
                        {
                            boxModelResultModel.Volume_m3 = (boxModelModel.Discharge_m3_day * (boxModelModel.DischargeDuration_hour / 24) * boxModelModel.FCUntreated_MPN_100ml) / boxModelModel.Concentration_MPN_100ml;
                        }
                        break;
                    case (int)BoxModelResultTypeEnum.NoDecayPreDisinfection:
                        {
                            boxModelResultModel.Volume_m3 = (boxModelModel.Discharge_m3_day * (boxModelModel.DischargeDuration_hour / 24) * boxModelModel.FCPreDisinfection_MPN_100ml) / boxModelModel.Concentration_MPN_100ml;
                        }
                        break;
                    case (int)BoxModelResultTypeEnum.DecayUntreated:
                        {
                            boxModelResultModel.Volume_m3 = (boxModelModel.Discharge_m3_day * (boxModelModel.DischargeDuration_hour / 24) * (boxModelModel.FCUntreated_MPN_100ml - boxModelModel.Concentration_MPN_100ml)) / boxModelModel.DecayRate_per_day / boxModelModel.Concentration_MPN_100ml;
                        }
                        break;
                    case (int)BoxModelResultTypeEnum.DecayPreDisinfection:
                        {
                            boxModelResultModel.Volume_m3 = (boxModelModel.Discharge_m3_day * (boxModelModel.DischargeDuration_hour / 24) * (boxModelModel.FCPreDisinfection_MPN_100ml - boxModelModel.Concentration_MPN_100ml)) / boxModelModel.DecayRate_per_day / boxModelModel.Concentration_MPN_100ml;
                        }
                        break;
                    default:
                        break;
                }
                boxModelResultModel.Surface_m2 = boxModelResultModel.Volume_m3 / boxModelModel.Depth_m;
                boxModelResultModel.Radius_m = Math.Sqrt(2 * ((double)boxModelResultModel.Volume_m3) / boxModelModel.Depth_m / Math.PI);

                if (boxModelModel.FixLength == false && boxModelModel.FixWidth == false)
                {
                    boxModelResultModel.FixLength = false;
                    boxModelResultModel.FixWidth = false;
                    boxModelResultModel.RectLength_m = Math.Sqrt((double)boxModelResultModel.Volume_m3 / boxModelModel.Depth_m);
                    boxModelResultModel.RectWidth_m = boxModelResultModel.RectLength_m;
                }
                else if (boxModelModel.FixLength == true)
                {
                    boxModelResultModel.FixLength = true;
                    boxModelResultModel.FixWidth = false;

                    boxModelResultModel.RectLength_m = boxModelModel.Length_m;
                    boxModelResultModel.RectWidth_m = boxModelResultModel.Volume_m3 / (boxModelModel.Depth_m * boxModelResultModel.RectLength_m);
                }
                else if (boxModelModel.FixWidth == true)
                {
                    boxModelResultModel.FixLength = false;
                    boxModelResultModel.FixWidth = true;

                    boxModelResultModel.RectWidth_m = boxModelModel.Width_m;
                    boxModelResultModel.RectLength_m = boxModelResultModel.Volume_m3 / (boxModelModel.Depth_m * boxModelResultModel.RectWidth_m);
                }

                BoxModelResultModel boxModelResultModelRet2 = new BoxModelResultModel();
                if (ShouldAdd)
                {
                    boxModelResultModelRet2 = _BoxModelResultService.PostAddBoxModelResultDB(boxModelResultModel);
                }
                else
                {
                    boxModelResultModelRet2 = _BoxModelResultService.PostUpdateBoxModelResultDB(boxModelResultModel);
                }

                if (!string.IsNullOrWhiteSpace(boxModelResultModelRet2.Error))
                    return ReturnError(boxModelResultModelRet2.Error);
            }

            return GetBoxModelModelWithBoxModelIDDB(boxModelModel.BoxModelID);
        }
        public CalDecay CalculateDecayDB(double T90_hour, double Temperature_C)
        {
            if (T90_hour == 0)
            {
                return new CalDecay() { Error = string.Format(ServiceRes._IsRequired, ServiceRes.T90_hour), Decay = -1 };
            }

            if (Temperature_C == 0)
            {
                return new CalDecay() { Error = string.Format(ServiceRes._IsRequired, ServiceRes.Temperature_C), Decay = -1 };
            }

            double K20 = Math.Log(10) / ((double)T90_hour / 24);
            double KTemp = K20 * Math.Pow(1.07, ((double)Temperature_C - 20));

            return new CalDecay() { Error = "", Decay = KTemp };
        }
        public BoxModelModel CopyBoxModelScenarioDB(int BoxModelID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            BoxModelModel boxModelModelToCopy = GetBoxModelModelWithBoxModelIDDB(BoxModelID);
            if (!string.IsNullOrWhiteSpace(boxModelModelToCopy.Error))
                return ReturnError(boxModelModelToCopy.Error);

            BoxModelModel boxModelModelNew = new BoxModelModel()
            {
                DBCommand = DBCommandEnum.Original,
                Concentration_MPN_100ml = boxModelModelToCopy.Concentration_MPN_100ml,
                DecayRate_per_day = boxModelModelToCopy.DecayRate_per_day,
                Depth_m = boxModelModelToCopy.Depth_m,
                Dilution = boxModelModelToCopy.Dilution,
                FCPreDisinfection_MPN_100ml = boxModelModelToCopy.FCPreDisinfection_MPN_100ml,
                FCUntreated_MPN_100ml = boxModelModelToCopy.FCUntreated_MPN_100ml,
                Discharge_m3_day = boxModelModelToCopy.Discharge_m3_day,
                DischargeDuration_hour = boxModelModelToCopy.DischargeDuration_hour,
                T90_hour = boxModelModelToCopy.T90_hour,
                Temperature_C = boxModelModelToCopy.Temperature_C,
                InfrastructureTVItemID = boxModelModelToCopy.InfrastructureTVItemID,
                FixLength = boxModelModelToCopy.FixLength,
                FixWidth = boxModelModelToCopy.FixWidth,
                Length_m = boxModelModelToCopy.Length_m,
                Width_m = boxModelModelToCopy.Width_m,
                ScenarioName = "_ " + ServiceRes.CopyOf + " " + boxModelModelToCopy.ScenarioName,
            };

            BoxModelModel boxModelModelRet = PostAddBoxModelDB(boxModelModelNew);
            if (!string.IsNullOrWhiteSpace(boxModelModelRet.Error))
                return ReturnError(boxModelModelRet.Error);

            return boxModelModelRet;
        }
        public BoxModelModel CreateNewBMScenarioDB(int InfrastructureTVItemID)
        {
            if (InfrastructureTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID));

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            double Discharge_m3_day = 1234f;
            double DischargeDuration_hour = 24f;
            int Dilution = 1000;
            double T90_hour = 6f;
            double Temperature_C = 10f;
            double DecayRate_per_day = 4.6821f;
            double Depth_m = 2f;
            int FCUntreated_MPN_100ml = 3200000;
            int FCPreDisinfection_MPN_100ml = 800;
            int Concentration_MPN_100ml = 14;

            BoxModelModel boxModelModelNew = new BoxModelModel()
            {
                DBCommand = DBCommandEnum.Original,
                Concentration_MPN_100ml = Concentration_MPN_100ml,
                DecayRate_per_day = DecayRate_per_day,
                Depth_m = Depth_m,
                Dilution = Dilution,
                FCPreDisinfection_MPN_100ml = FCPreDisinfection_MPN_100ml,
                FCUntreated_MPN_100ml = FCUntreated_MPN_100ml,
                Discharge_m3_day = Discharge_m3_day,
                DischargeDuration_hour = DischargeDuration_hour,
                T90_hour = T90_hour,
                Temperature_C = Temperature_C,
                InfrastructureTVItemID = InfrastructureTVItemID,
                ScenarioName = "__ " + ServiceRes.NewBoxModelScenario,
            };

            BoxModelModel boxModelModelRet = PostAddBoxModelDB(boxModelModelNew);
            if (!string.IsNullOrWhiteSpace(boxModelModelRet.Error))
                return ReturnError(boxModelModelRet.Error);

            return boxModelModelRet;
        }
        public BoxModelModel ReturnError(string Error)
        {
            return new BoxModelModel() { Error = Error };
        }
        public BoxModelModel SaveBoxModelScenarioDB(FormCollection fc)
        {
            int BoxModelID = 0;
            double Discharge_m3_day = 0;
            double DischargeDuration_hour = 0;
            int Dilution = 0;
            double T90_hour = 0;
            double Temperature_C = 0;
            double DecayRate_per_day = 0;
            double Depth_m = 0;
            int FCUntreated_MPN_100ml = 0;
            int FCPreDisinfection_MPN_100ml = 0;
            int Concentration_MPN_100ml = 0;
            bool FixLength = false;
            bool FixWidth = false;
            double Length_m = 0.0D;
            double Width_m = 0.0D;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int.TryParse(fc["BoxModelID"], out BoxModelID);
            if (BoxModelID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.BoxModelID));

            BoxModelModel boxModelModelToChange = GetBoxModelModelWithBoxModelIDDB(BoxModelID);
            if (!string.IsNullOrWhiteSpace(boxModelModelToChange.Error))
                return ReturnError(boxModelModelToChange.Error);

            string ScenarioName = fc["ScenarioName"];
            if (string.IsNullOrWhiteSpace(ScenarioName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ScenarioName));
            boxModelModelToChange.ScenarioName = ScenarioName;

            string retStr = CheckUniquenessOfBoxModelScenarioNameDB(boxModelModelToChange.InfrastructureTVItemID, boxModelModelToChange.BoxModelID, ScenarioName);
            if (retStr != "true")
                return ReturnError(retStr);

            double.TryParse(fc["T90_hour"], out T90_hour);
            if (T90_hour == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.T90_hour));
            boxModelModelToChange.T90_hour = T90_hour;

            double.TryParse(fc["Temperature_C"], out Temperature_C);
            if (Temperature_C == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Temperature_C));
            boxModelModelToChange.Temperature_C = Temperature_C;

            double.TryParse(fc["DecayRate_per_day"], out DecayRate_per_day);
            if (DecayRate_per_day == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DecayRate_per_day));
            boxModelModelToChange.DecayRate_per_day = DecayRate_per_day;

            double.TryParse(fc["Discharge_m3_day"], out Discharge_m3_day);
            if (Discharge_m3_day == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Discharge_m3_day));
            boxModelModelToChange.Discharge_m3_day = Discharge_m3_day;

            double.TryParse(fc["DischargeDuration_hour"], out DischargeDuration_hour);
            if (DischargeDuration_hour == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DischargeDuration_hour));
            boxModelModelToChange.DischargeDuration_hour = DischargeDuration_hour;

            int.TryParse(fc["Dilution"], out Dilution);
            if (Dilution == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Dilution));
            boxModelModelToChange.Dilution = Dilution;

            double.TryParse(fc["Depth_m"], out Depth_m);
            if (Depth_m == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Depth_m));
            boxModelModelToChange.Depth_m = Depth_m;

            int.TryParse(fc["FCUntreated_MPN_100ml"], out FCUntreated_MPN_100ml);
            if (FCUntreated_MPN_100ml == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.FCUntreated_MPN_100ml));
            boxModelModelToChange.FCUntreated_MPN_100ml = FCUntreated_MPN_100ml;

            int.TryParse(fc["FCPreDisinfection_MPN_100ml"], out FCPreDisinfection_MPN_100ml);
            if (FCPreDisinfection_MPN_100ml == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.FCPreDisinfection_MPN_100ml));
            boxModelModelToChange.FCPreDisinfection_MPN_100ml = FCPreDisinfection_MPN_100ml;

            int.TryParse(fc["Concentration_MPN_100ml"], out Concentration_MPN_100ml);
            if (Concentration_MPN_100ml == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Concentration_MPN_100ml));
            boxModelModelToChange.Concentration_MPN_100ml = Concentration_MPN_100ml;

            if (fc["FixLength"] != null)
                FixLength = true;
            else
                FixLength = false;

            if (fc["FixWidth"] != null)
                FixWidth = true;
            else
                FixWidth = false;

            if (FixLength)
            {
                double.TryParse(fc["Length_m"], out Length_m);
                if (Length_m <= 0.0D)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Length_m));
                boxModelModelToChange.Length_m = Length_m;
            }
            if (FixWidth)
            {
                double.TryParse(fc["Width_m"], out Width_m);
                if (Width_m <= 0.0D)
                    return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Width_m));
                boxModelModelToChange.Width_m = Width_m;
            }

            if (FixLength == true && FixWidth == true)
                return ReturnError(ServiceRes.FixLengthAndFixWidthShouldNotBeCheckedAtTheSameTime);
            if (FixLength == true)
            {
                if (Length_m < 1.0D)
                    return ReturnError(ServiceRes.LengthShouldNotBeZeroWhenFixLengthIsChecked);
            }
            if (FixWidth == true)
            {
                if (Width_m < 1.0D)
                    return ReturnError(ServiceRes.WidthShouldNotBeZeroWhenFixWidthIsChecked);
            }
            boxModelModelToChange.FixLength = FixLength;
            boxModelModelToChange.FixWidth = FixWidth;
            boxModelModelToChange.DBCommand = DBCommandEnum.Original;
            using (TransactionScope ts = new TransactionScope())
            {
                BoxModelModel boxModelModelRet = PostUpdateBoxModelDB(boxModelModelToChange);
                if (!string.IsNullOrWhiteSpace(boxModelModelRet.Error))
                    return ReturnError(boxModelModelRet.Error);

                ts.Complete();
            }
            return boxModelModelToChange;
        }

        // Post
        public BoxModelModel PostAddBoxModelDB(BoxModelModel boxModelModel)
        {
            string retStr = BoxModelModelOK(boxModelModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            BoxModel boxModelExist = GetBoxModelWithInfrastructureTVItemIDAndScenarioNameDB(boxModelModel.InfrastructureTVItemID, boxModelModel.ScenarioName);
            if (boxModelExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.BoxModel));

            BoxModel boxModelNew = new BoxModel();
            retStr = FillBoxModel(boxModelNew, boxModelModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.BoxModels.Add(boxModelNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModels", boxModelNew.BoxModelID, LogCommandEnum.Add, boxModelNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    BoxModelLanguageModel boxModelLanguageModel = new BoxModelLanguageModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        BoxModelID = boxModelNew.BoxModelID,
                        Language = Lang,
                        ScenarioName = boxModelModel.ScenarioName,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    BoxModelLanguageModel boxModelLanguageModelRet = _BoxModelLanguageService.PostAddBoxModelLanguageDB(boxModelLanguageModel);
                    if (!string.IsNullOrEmpty(boxModelLanguageModelRet.Error))
                        return ReturnError(string.Format(ServiceRes.CouldNotAddError_, boxModelLanguageModelRet.Error));
                }

                // Calculating results and adding results in BoxModelResults
                boxModelModel.BoxModelID = boxModelNew.BoxModelID;
                BoxModelModel boxModelModelRet2 = AddOrUpdateBoxModelResultModel(boxModelModel);
                if (!string.IsNullOrWhiteSpace(boxModelModelRet2.Error))
                    return ReturnError(boxModelModelRet2.Error);

                ts.Complete();
            }

            return GetBoxModelModelWithBoxModelIDDB(boxModelNew.BoxModelID);
        }
        public BoxModelModel PostDeleteBoxModelDB(int BoxModelID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            BoxModel boxModelToDelete = GetBoxModelWithBoxModelIDDB(BoxModelID);
            if (boxModelToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.BoxModel));

            using (TransactionScope ts = new TransactionScope())
            {
                db.BoxModels.Remove(boxModelToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModels", boxModelToDelete.BoxModelID, LogCommandEnum.Delete, boxModelToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public BoxModelModel PostUpdateBoxModelDB(BoxModelModel boxModelModel)
        {
            string retStr = BoxModelModelOK(boxModelModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            BoxModel boxModelToUpdate = GetBoxModelWithBoxModelIDDB(boxModelModel.BoxModelID);
            if (boxModelToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.BoxModel));

            retStr = FillBoxModel(boxModelToUpdate, boxModelModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("BoxModels", boxModelToUpdate.BoxModelID, LogCommandEnum.Change, boxModelToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    BoxModelLanguageModel boxModelLanguageModel = new BoxModelLanguageModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        BoxModelID = boxModelModel.BoxModelID,
                        Language = Lang,
                        ScenarioName = boxModelModel.ScenarioName,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    BoxModelLanguageModel boxModelLanguageModelRet = _BoxModelLanguageService.PostUpdateBoxModelLanguageDB(boxModelLanguageModel);
                    if (!string.IsNullOrEmpty(boxModelLanguageModelRet.Error))
                        return ReturnError(string.Format(ServiceRes.CouldNotAddError_, boxModelLanguageModelRet.Error));
                }

                // Calculating results and adding results in BoxModelResults
                boxModelModel.BoxModelID = boxModelToUpdate.BoxModelID;
                BoxModelModel boxModelModelRet2 = AddOrUpdateBoxModelResultModel(boxModelModel);
                if (!string.IsNullOrWhiteSpace(boxModelModelRet2.Error))
                    return ReturnError(boxModelModelRet2.Error);

                ts.Complete();
            }

            return GetBoxModelModelWithBoxModelIDDB(boxModelToUpdate.BoxModelID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
