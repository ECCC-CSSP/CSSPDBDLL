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
    public class DrogueRunService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public DrogueRunPositionService _DrogueRunPositionService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public DrogueRunService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _DrogueRunPositionService = new DrogueRunPositionService(LanguageRequest, User);
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
        public string DrogueRunModelOK(DrogueRunModel drogueRunModel)
        {
            string retStr = FieldCheckNotZeroInt(drogueRunModel.SubsectorTVItemID, ServiceRes.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(drogueRunModel.DrogueNumber, ServiceRes.DrogueNumber, 1, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DrogueTypeOK(drogueRunModel.DrogueType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(drogueRunModel.RunStartDateTime, ServiceRes.RunStartDateTime);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(drogueRunModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillDrogueRun(DrogueRun drogueRunNew, DrogueRunModel drogueRunModel, ContactOK contactOK)
        {
            drogueRunNew.DBCommand = (int)drogueRunModel.DBCommand;
            drogueRunNew.SubsectorTVItemID = drogueRunModel.SubsectorTVItemID;
            drogueRunNew.DrogueNumber = drogueRunModel.DrogueNumber;
            drogueRunNew.DrogueType = (int)drogueRunModel.DrogueType;
            drogueRunNew.RunStartDateTime = drogueRunModel.RunStartDateTime;
            drogueRunNew.IsRisingTide = drogueRunModel.IsRisingTide;
            drogueRunNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                drogueRunNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                drogueRunNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetDrogueRunModelCountDB()
        {
            int DrogueRunModelCount = (from c in db.DrogueRuns
                                       select c).Count();

            return DrogueRunModelCount;
        }
        public DrogueRunModel GetDrogueRunModelWithDrogueRunIDDB(int DrogueRunID)
        {
            DrogueRunModel DrogueRunModel = (from c in db.DrogueRuns
                                             where c.DrogueRunID == DrogueRunID
                                             select new DrogueRunModel
                                             {
                                                 Error = "",
                                                 DrogueRunID = c.DrogueRunID,
                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                 SubsectorTVItemID = c.SubsectorTVItemID,
                                                 DrogueNumber = c.DrogueNumber,
                                                 DrogueType = (DrogueTypeEnum)c.DrogueType,
                                                 RunStartDateTime = c.RunStartDateTime,
                                                 IsRisingTide = c.IsRisingTide,
                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             }).FirstOrDefault<DrogueRunModel>();

            if (DrogueRunModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DrogueRun, ServiceRes.DrogueRunID, DrogueRunID));

            return DrogueRunModel;
        }
        public List<DrogueRunModel> GetDrogueRunModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<DrogueRunModel> DrogueRunModelList = (from c in db.DrogueRuns
                                                       where c.SubsectorTVItemID == SubsectorTVItemID
                                                       orderby c.DrogueNumber
                                                       select new DrogueRunModel
                                                       {
                                                           Error = "",
                                                           DrogueRunID = c.DrogueRunID,
                                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                                           SubsectorTVItemID = c.SubsectorTVItemID,
                                                           DrogueNumber = c.DrogueNumber,
                                                           DrogueType = (DrogueTypeEnum)c.DrogueType,
                                                           RunStartDateTime = c.RunStartDateTime,
                                                           IsRisingTide = c.IsRisingTide,
                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                       }).ToList<DrogueRunModel>();

            return DrogueRunModelList;
        }
        public DrogueRunModel GetDrogueRunModelExistDB(DrogueRunModel drogueRunModel)
        {
            DrogueRunModel DrogueRunModel = (from c in db.DrogueRuns
                                             where c.SubsectorTVItemID == drogueRunModel.SubsectorTVItemID
                                             && c.DrogueNumber == drogueRunModel.DrogueNumber
                                             && c.DrogueType == (int)drogueRunModel.DrogueType
                                             && c.RunStartDateTime == drogueRunModel.RunStartDateTime
                                             select new DrogueRunModel
                                             {
                                                 Error = "",
                                                 DrogueRunID = c.DrogueRunID,
                                                 DBCommand = (DBCommandEnum)c.DBCommand,
                                                 SubsectorTVItemID = c.SubsectorTVItemID,
                                                 DrogueNumber = c.DrogueNumber,
                                                 DrogueType = (DrogueTypeEnum)c.DrogueType,
                                                 RunStartDateTime = c.RunStartDateTime,
                                                 IsRisingTide = c.IsRisingTide,
                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                             }).FirstOrDefault<DrogueRunModel>();

            if (DrogueRunModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DrogueRun,
                    ServiceRes.SubsectorTVItemID + "," +
                    ServiceRes.DrogueNumber + "," +
                    ServiceRes.DrogueType + "," +
                    ServiceRes.RunStartDateTime,
                    drogueRunModel.SubsectorTVItemID + "," +
                    drogueRunModel.DrogueNumber + "," +
                    drogueRunModel.DrogueType + "," +
                    drogueRunModel.RunStartDateTime));

            return DrogueRunModel;
        }
        public DrogueRun GetDrogueRunWithDrogueRunIDDB(int DrogueRunID)
        {
            DrogueRun DrogueRun = (from c in db.DrogueRuns
                                   where c.DrogueRunID == DrogueRunID
                                   orderby c.DrogueRunID descending
                                   select c).FirstOrDefault<DrogueRun>();
            return DrogueRun;
        }
        public DrogueRunModel ReturnError(string Error)
        {
            return new DrogueRunModel() { Error = Error };
        }

        // Post
        public DrogueRunModel PostAddOrModifyDB(FormCollection fc)
        {
            int tempInt = 0;
            int DrogueRunID = 0;
            int SubsectorTVItemID = 0;
            int DrogueNumber = 0;
            int TakeValueEveryXMinutes = 0;
            int TakeValueEveryXSeconds = 0;
            bool IsRisingTide = true;

            DrogueTypeEnum DrogueType = DrogueTypeEnum.Error;
            DateTime RunStartDateTime = DateTime.Now;
            string DroguePoints = "";

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);


            int.TryParse(fc["DrogueRunID"], out DrogueRunID);
            // could be 0 if 0 then we need to add the new DrogueRun 

            DrogueRunModel drogueRunModelToChange = new DrogueRunModel();
            if (DrogueRunID != 0)
            {
                drogueRunModelToChange = GetDrogueRunModelWithDrogueRunIDDB(DrogueRunID);
                if (!string.IsNullOrWhiteSpace(drogueRunModelToChange.Error))
                {
                    return drogueRunModelToChange;
                }
            }

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            int.TryParse(fc["TakeValueEveryXMinutes"], out TakeValueEveryXMinutes);

            TakeValueEveryXSeconds = TakeValueEveryXMinutes * 60;

            int.TryParse(fc["DrogueNumber"], out DrogueNumber);
            if (DrogueNumber == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DrogueNumber));

            if (string.IsNullOrWhiteSpace(fc["DrogueType"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DrogueType));
            else
            {
                int.TryParse(fc["DrogueType"], out tempInt);
                DrogueType = (DrogueTypeEnum)tempInt;
            }

            if (string.IsNullOrWhiteSpace(fc["IsRisingTide"]))
            {
                IsRisingTide = false;
            }

            DroguePoints = fc["DroguePoints"];

            DrogueRunModel drogueRunModelRet = new DrogueRunModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (DrogueRunID == 0)
                {
                    DrogueRunModel drogueRunModelNew = new DrogueRunModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        DrogueNumber = DrogueNumber,
                        DrogueType = DrogueType,
                        RunStartDateTime = RunStartDateTime,
                        SubsectorTVItemID = SubsectorTVItemID,
                        IsRisingTide = IsRisingTide,
                    };

                    drogueRunModelRet = PostAddDrogueRunDB(drogueRunModelNew);
                }
                else
                {
                    drogueRunModelToChange.DrogueNumber = DrogueNumber;
                    drogueRunModelToChange.DrogueType = DrogueType;
                    drogueRunModelToChange.RunStartDateTime = RunStartDateTime;
                    drogueRunModelToChange.IsRisingTide = IsRisingTide;

                    drogueRunModelRet = PostUpdateDrogueRunDB(drogueRunModelToChange);
                }

                //    ts.Complete();
                //}

                if (string.IsNullOrWhiteSpace(drogueRunModelRet.Error))
                {
                    int Ordinal = 0;
                    List<DrogueRunPositionModel> drogueRunPositionModelList = new List<DrogueRunPositionModel>();
                    List<string> lineList = DroguePoints.Split("\r\n".ToCharArray(), StringSplitOptions.None).ToList();

                    DateTime OldStepDate = new DateTime();
                    foreach (string s in lineList)
                    {
                        if (s.Trim().Length == 0)
                        {
                            continue;
                        }

                        List<string> lineValList = s.Split(" ".ToCharArray(), StringSplitOptions.None).ToList();
                        if (lineValList.Count != 4)
                        {
                            return ReturnError(ServiceRes.DroguePointsNotWellFormed);
                        }

                        if (!float.TryParse(lineValList[0], out float Lat))
                        {
                            return ReturnError(string.Format(ServiceRes.CouldNotParse_, ServiceRes.Lat));
                        }

                        if (!float.TryParse(lineValList[1], out float Lng))
                        {
                            return ReturnError(string.Format(ServiceRes.CouldNotParse_, ServiceRes.Lng));
                        }

                        if (!int.TryParse(lineValList[2].Substring(0, 4), out int Year))
                        {
                            return ReturnError(string.Format(ServiceRes.CouldNotParse_, ServiceRes.Year));
                        }

                        string MonthText = lineValList[2].Substring(5, 2);
                        if (MonthText.StartsWith("0"))
                        {
                            MonthText = MonthText.Substring(1);
                        }
                        if (!int.TryParse(MonthText, out int Month))
                        {
                            return ReturnError(string.Format(ServiceRes.CouldNotParse_, ServiceRes.Month));
                        }

                        string DayText = lineValList[2].Substring(8, 2);
                        if (DayText.StartsWith("0"))
                        {
                            DayText = DayText.Substring(1);
                        }
                        if (!int.TryParse(DayText, out int Day))
                        {
                            return ReturnError(string.Format(ServiceRes.CouldNotParse_, ServiceRes.Day));
                        }

                        string HourText = lineValList[3].Substring(0, 2);
                        if (HourText.StartsWith("0"))
                        {
                            HourText = HourText.Substring(1);
                        }
                        if (!int.TryParse(HourText, out int Hour))
                        {
                            return ReturnError(string.Format(ServiceRes.CouldNotParse_, ServiceRes.Hour));
                        }

                        string MinuteText = lineValList[3].Substring(3, 2);
                        if (MinuteText.StartsWith("0"))
                        {
                            MinuteText = MinuteText.Substring(1);
                        }
                        if (!int.TryParse(MinuteText, out int Minute))
                        {
                            return ReturnError(string.Format(ServiceRes.CouldNotParse_, ServiceRes.Minute));
                        }

                        if (!int.TryParse(lineValList[3].Substring(6, 2), out int Second))
                        {
                            return ReturnError(string.Format(ServiceRes.CouldNotParse_, ServiceRes.Second));
                        }

                        DateTime StepDate = new DateTime(Year, Month, Day, Hour, Minute, Second);

                        if (StepDate <= OldStepDate)
                        {
                            return ReturnError(string.Format(ServiceRes.DatesAreNotAllInChronologicalOrder_And_, StepDate, OldStepDate));
                        }

                        TimeSpan timeSpan = new TimeSpan(StepDate.Ticks - OldStepDate.Ticks);

                        if (timeSpan.TotalSeconds > TakeValueEveryXSeconds || TakeValueEveryXMinutes == 0)
                        {
                            DrogueRunPositionModel drogueRunPositionModel = new DrogueRunPositionModel()
                            {
                                DBCommand = DBCommandEnum.Original,
                                StepLat = Lat,
                                StepLng = Lng,
                                StepDateTime_Local = StepDate,
                                Ordinal = Ordinal,
                                DrogueRunID = drogueRunModelRet.DrogueRunID,
                                CalculatedSpeed_m_s = 0.0f,
                                CalculatedDirection_deg = 0.0f,
                            };

                            drogueRunPositionModelList.Add(drogueRunPositionModel);

                            Ordinal += 1;

                            OldStepDate = StepDate;
                        }
                    }

                    for (int i = 0, count = drogueRunPositionModelList.Count - 1; i < count; i++)
                    {
                        double dist = _MapInfoService.CalculateDistance((double)drogueRunPositionModelList[i].StepLat * d2r, (double)drogueRunPositionModelList[i].StepLng * d2r, (double)drogueRunPositionModelList[i + 1].StepLat * d2r, (double)drogueRunPositionModelList[i + 1].StepLng * d2r, base.R);
                        TimeSpan timeSpan = new TimeSpan(drogueRunPositionModelList[i + 1].StepDateTime_Local.Ticks - drogueRunPositionModelList[i].StepDateTime_Local.Ticks);
                        float Speed = Math.Abs((float)(dist / timeSpan.TotalSeconds));
                        drogueRunPositionModelList[i].CalculatedSpeed_m_s = Speed;

                        double StepLat = drogueRunPositionModelList[i + 1].StepLat - drogueRunPositionModelList[i].StepLat;
                        double StepLng = drogueRunPositionModelList[i + 1].StepLng - drogueRunPositionModelList[i].StepLng;

                        double angle = Math.Atan2(StepLat, StepLng) * 180 / Math.PI;

                        if (StepLat >= 0.0D && StepLng >= 0.0D)
                        {
                            angle = 90 - angle;
                        }
                        else if (StepLat <= 0.0D && StepLng >= 0.0D)
                        {
                            angle = 90 + Math.Abs(angle);
                        }
                        else if (StepLat <= 0.0D && StepLng <= 0.0D)
                        {
                            angle = 90 + Math.Abs(angle);
                        }
                        else if (StepLat >= 0.0D && StepLng <= 0.0D)
                        {
                            angle = 360 - Math.Abs(angle) + 90;
                        }
                        else
                        {
                            angle = 0.0f;
                        }

                        if (drogueRunPositionModelList[i].StepLat == drogueRunPositionModelList[i + 1].StepLat && drogueRunPositionModelList[i].StepLng == drogueRunPositionModelList[i + 1].StepLng)
                        {
                            Speed = 0.0f;
                            angle = 0.0f;
                        }

                        drogueRunPositionModelList[i].CalculatedDirection_deg = (float)angle;
                    }

                    if (drogueRunPositionModelList.Count > 1)
                    {
                        drogueRunPositionModelList[drogueRunPositionModelList.Count - 1].CalculatedSpeed_m_s = drogueRunPositionModelList[drogueRunPositionModelList.Count - 2].CalculatedSpeed_m_s;
                        drogueRunPositionModelList[drogueRunPositionModelList.Count - 1].CalculatedDirection_deg = drogueRunPositionModelList[drogueRunPositionModelList.Count - 2].CalculatedDirection_deg;
                    }

                    List<DrogueRunPositionModel> drogueRunPositionModelListInDB = _DrogueRunPositionService.GetDrogueRunPositionModelListWithDrogueRunIDDB(drogueRunModelRet.DrogueRunID).OrderBy(c => c.Ordinal).ToList();

                    if (drogueRunPositionModelList.Count == drogueRunPositionModelListInDB.Count)
                    {
                        for (int i = 0, count = drogueRunPositionModelList.Count; i < count; i++)
                        {
                            drogueRunPositionModelList[i].DrogueRunPositionID = drogueRunPositionModelListInDB[i].DrogueRunPositionID;
                            DrogueRunPositionModel drogueRunPositionModel = _DrogueRunPositionService.PostUpdateDrogueRunPositionDB(drogueRunPositionModelList[i]);
                            if (!string.IsNullOrWhiteSpace(drogueRunPositionModel.Error))
                            {
                                return ReturnError(drogueRunPositionModel.Error);
                            }
                        }
                    }
                    else if (drogueRunPositionModelList.Count > drogueRunPositionModelListInDB.Count)
                    {
                        for (int i = 0, count = drogueRunPositionModelListInDB.Count; i < count; i++)
                        {
                            drogueRunPositionModelList[i].DrogueRunPositionID = drogueRunPositionModelListInDB[i].DrogueRunPositionID;
                            DrogueRunPositionModel drogueRunPositionModel = _DrogueRunPositionService.PostUpdateDrogueRunPositionDB(drogueRunPositionModelList[i]);
                            if (!string.IsNullOrWhiteSpace(drogueRunPositionModel.Error))
                            {
                                return ReturnError(drogueRunPositionModel.Error);
                            }
                        }
                        for (int i = drogueRunPositionModelListInDB.Count, count = drogueRunPositionModelList.Count; i < count; i++)
                        {
                            DrogueRunPositionModel drogueRunPositionModel = _DrogueRunPositionService.PostAddDrogueRunPositionDB(drogueRunPositionModelList[i]);
                            if (!string.IsNullOrWhiteSpace(drogueRunPositionModel.Error))
                            {
                                return ReturnError(drogueRunPositionModel.Error);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0, count = drogueRunPositionModelList.Count; i < count; i++)
                        {
                            drogueRunPositionModelList[i].DrogueRunPositionID = drogueRunPositionModelListInDB[i].DrogueRunPositionID;
                            DrogueRunPositionModel drogueRunPositionModel = _DrogueRunPositionService.PostUpdateDrogueRunPositionDB(drogueRunPositionModelList[i]);
                            if (!string.IsNullOrWhiteSpace(drogueRunPositionModel.Error))
                            {
                                return ReturnError(drogueRunPositionModel.Error);
                            }
                        }
                        for (int i = drogueRunPositionModelList.Count, count = drogueRunPositionModelListInDB.Count; i < count; i++)
                        {
                            DrogueRunPositionModel drogueRunPositionModel = _DrogueRunPositionService.PostDeleteDrogueRunPositionDB(drogueRunPositionModelListInDB[i].DrogueRunPositionID);
                            if (!string.IsNullOrWhiteSpace(drogueRunPositionModel.Error))
                            {
                                return ReturnError(drogueRunPositionModel.Error);
                            }
                        }
                    }

                    if (drogueRunPositionModelList.Count > 0)
                    {
                        drogueRunModelRet.RunStartDateTime = drogueRunPositionModelList[0].StepDateTime_Local;

                        drogueRunModelRet = PostUpdateDrogueRunDB(drogueRunModelRet);
                    }

                    ts.Complete();
                }
            }

            return drogueRunModelRet;
        }
        public DrogueRunModel PostAddDrogueRunDB(DrogueRunModel drogueRunModel)
        {
            string retStr = DrogueRunModelOK(drogueRunModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(drogueRunModel.SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            DrogueRunModel DrogueRunModelExist = GetDrogueRunModelExistDB(drogueRunModel);
            if (string.IsNullOrWhiteSpace(DrogueRunModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.DrogueRun));

            DrogueRun drogueRunNew = new DrogueRun();
            retStr = FillDrogueRun(drogueRunNew, drogueRunModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.DrogueRuns.Add(drogueRunNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRuns", drogueRunNew.DrogueRunID, LogCommandEnum.Add, drogueRunNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDrogueRunModelWithDrogueRunIDDB(drogueRunNew.DrogueRunID);
        }
        public DrogueRunModel PostDeleteDrogueRunDB(int DrogueRunID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DrogueRun drogueRunToDelete = GetDrogueRunWithDrogueRunIDDB(DrogueRunID);
            if (drogueRunToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.DrogueRun));

            using (TransactionScope ts = new TransactionScope())
            {
                db.DrogueRuns.Remove(drogueRunToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRuns", drogueRunToDelete.DrogueRunID, LogCommandEnum.Delete, drogueRunToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public DrogueRunModel PostUpdateDrogueRunDB(DrogueRunModel drogueRunModel)
        {
            string retStr = DrogueRunModelOK(drogueRunModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            DrogueRun drogueRunToUpdate = GetDrogueRunWithDrogueRunIDDB(drogueRunModel.DrogueRunID);
            if (drogueRunToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.DrogueRun));

            retStr = FillDrogueRun(drogueRunToUpdate, drogueRunModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("DrogueRuns", drogueRunToUpdate.DrogueRunID, LogCommandEnum.Change, drogueRunToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetDrogueRunModelWithDrogueRunIDDB(drogueRunToUpdate.DrogueRunID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
