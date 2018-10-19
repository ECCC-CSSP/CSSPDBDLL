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
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class MWQMSiteStartEndDateService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
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
        public string MWQMSiteStartEndDateModelOK(MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmSiteStartEndDateModel.MWQMSiteTVItemID, ServiceRes.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(mwqmSiteStartEndDateModel.StartDate, ServiceRes.StartDate);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (mwqmSiteStartEndDateModel.EndDate != null)
            {
                if (mwqmSiteStartEndDateModel.StartDate > mwqmSiteStartEndDateModel.EndDate)
                {
                    return string.Format(ServiceRes._IsLaterThan_, ServiceRes.StartDate, ServiceRes.EndDate);
                }
            }

            return "";
        }

        // Fill
        public string FillMWQMSiteStartEndDate(MWQMSiteStartEndDate mwqmSiteStartEndDate, MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel, ContactOK contactOK)
        {
            mwqmSiteStartEndDate.MWQMSiteTVItemID = mwqmSiteStartEndDateModel.MWQMSiteTVItemID;
            mwqmSiteStartEndDate.StartDate = mwqmSiteStartEndDateModel.StartDate;
            mwqmSiteStartEndDate.EndDate = mwqmSiteStartEndDateModel.EndDate;
            mwqmSiteStartEndDate.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmSiteStartEndDate.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmSiteStartEndDate.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMWQMSiteStartEndDateModelCountDB()
        {
            int MWQMSiteStartEndDateModelCount = (from c in db.MWQMSiteStartEndDates
                                                  select c).Count();

            return MWQMSiteStartEndDateModelCount;
        }
        public MWQMSiteStartEndDateModel GetMWQMSiteStartEndDateModelWithMWQMSiteStartEndDateIDDB(int MWQMSiteStartEndDateID)
        {
            MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel = (from c in db.MWQMSiteStartEndDates
                                                                   where c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID
                                                                   select new MWQMSiteStartEndDateModel
                                                                   {
                                                                       Error = "",
                                                                       MWQMSiteStartEndDateID = c.MWQMSiteStartEndDateID,
                                                                       MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                       StartDate = c.StartDate,
                                                                       EndDate = c.EndDate,
                                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                   }).FirstOrDefault<MWQMSiteStartEndDateModel>();

            if (mwqmSiteStartEndDateModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSiteStartEndDate, ServiceRes.MWQMSiteStartEndDateID, MWQMSiteStartEndDateID));

            return mwqmSiteStartEndDateModel;
        }
        public List<MWQMSiteStartEndDateModel> GetMWQMSiteStartEndDateModelListWithMWQMSiteTVItemIDDB(int MWQMSiteTVItemID)
        {
            List<MWQMSiteStartEndDateModel> mwqmSiteStartEndDateModelList = (from c in db.MWQMSiteStartEndDates
                                                                             where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                                                             orderby c.StartDate
                                                                             select new MWQMSiteStartEndDateModel
                                                                             {
                                                                                 Error = "",
                                                                                 MWQMSiteStartEndDateID = c.MWQMSiteStartEndDateID,
                                                                                 MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                                 StartDate = c.StartDate,
                                                                                 EndDate = c.EndDate,
                                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                             }).ToList<MWQMSiteStartEndDateModel>();


            return mwqmSiteStartEndDateModelList;
        }
        public MWQMSiteStartEndDateModel GetMWQMSiteStartEndDateExistDB(MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel)
        {
            MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = (from c in db.MWQMSiteStartEndDates
                                                                      where c.MWQMSiteTVItemID == mwqmSiteStartEndDateModel.MWQMSiteTVItemID
                                                                      && c.StartDate == mwqmSiteStartEndDateModel.StartDate
                                                                      select new MWQMSiteStartEndDateModel
                                                                      {
                                                                          Error = "",
                                                                          MWQMSiteStartEndDateID = c.MWQMSiteStartEndDateID,
                                                                          MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                          StartDate = c.StartDate,
                                                                          EndDate = c.EndDate,
                                                                          LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                          LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                      }).FirstOrDefault<MWQMSiteStartEndDateModel>();

            if (mwqmSiteStartEndDateModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSiteStartEndDate,
                    ServiceRes.MWQMSiteTVItemID + "," +
                    ServiceRes.Year + "," +
                    ServiceRes.Month + "," +
                    ServiceRes.Day + ",",
                    mwqmSiteStartEndDateModel.MWQMSiteTVItemID.ToString() + "," + 
                    mwqmSiteStartEndDateModel.StartDate.Year.ToString() + "," + 
                    mwqmSiteStartEndDateModel.StartDate.Month.ToString() + "," + 
                    mwqmSiteStartEndDateModel.StartDate.Day.ToString() + ","));

            return mwqmSiteStartEndDateModel;
        }
        public MWQMSiteStartEndDate GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDB(int MWQMSiteStartEndDateID)
        {
            MWQMSiteStartEndDate mwqmSiteStartEndDate = (from c in db.MWQMSiteStartEndDates
                                                                      where c.MWQMSiteStartEndDateID == MWQMSiteStartEndDateID
                                                                      select c).FirstOrDefault<MWQMSiteStartEndDate>();

            return mwqmSiteStartEndDate;
        }

        // Helper
        public MWQMSiteStartEndDateModel ReturnError(string Error)
        {
            return new MWQMSiteStartEndDateModel() { Error = Error };
        }

        // Post
        public MWQMSiteStartEndDateModel MWQMSiteStartEndDateAddOrModifyDB(FormCollection fc)
        {
            int MWQMSiteStartEndDateID = 0;
            int MWQMSiteTVItemID = 0;
            int StartDateYear = 0;
            int StartDateMonth = 0;
            int StartDateDay = 0;
            int EndDateYear = 0;
            int EndDateMonth = 0;
            int EndDateDay = 0;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int.TryParse(fc["MWQMSiteStartEndDateID"], out MWQMSiteStartEndDateID);
            // could be 0 if 0 then we need to add the new MWQMSiteStartEndDate 

            MWQMSiteStartEndDateModel mwqmSiteStartEndDateNewOrToChange = new MWQMSiteStartEndDateModel();

            if (MWQMSiteStartEndDateID > 0)
            {
                mwqmSiteStartEndDateNewOrToChange = GetMWQMSiteStartEndDateModelWithMWQMSiteStartEndDateIDDB(MWQMSiteStartEndDateID);
                if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateNewOrToChange.Error))
                    return ReturnError(mwqmSiteStartEndDateNewOrToChange.Error);
            }

            int.TryParse(fc["MWQMSiteTVItemID"], out MWQMSiteTVItemID);
            if (MWQMSiteTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID));

            mwqmSiteStartEndDateNewOrToChange.MWQMSiteTVItemID = MWQMSiteTVItemID;

            // Start Date
            int.TryParse(fc["StartDateYear"], out StartDateYear);
            if (StartDateYear == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartDateYear));

            int.TryParse(fc["StartDateMonth"], out StartDateMonth);
            if (StartDateMonth == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartDateMonth));

            int.TryParse(fc["StartDateDay"], out StartDateDay);
            if (StartDateDay == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StartDateDay));

            mwqmSiteStartEndDateNewOrToChange.StartDate = new DateTime(StartDateYear, StartDateMonth, StartDateDay);

            // End Date
            int.TryParse(fc["EndDateYear"], out EndDateYear);
            if (EndDateYear == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndDateYear));

            int.TryParse(fc["EndDateMonth"], out EndDateMonth);
            if (EndDateMonth == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndDateMonth));

            int.TryParse(fc["EndDateDay"], out EndDateDay);
            if (EndDateDay == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.EndDateDay));

            if (EndDateYear > 0)
            {
                mwqmSiteStartEndDateNewOrToChange.EndDate = new DateTime(EndDateYear, EndDateMonth, EndDateDay);
            }
            else
            {
                mwqmSiteStartEndDateNewOrToChange.EndDate = null;
            }

            MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = new MWQMSiteStartEndDateModel();

            using (TransactionScope ts = new TransactionScope())
            {
                if (MWQMSiteStartEndDateID == 0)
                {
                    mwqmSiteStartEndDateModelRet = PostAddMWQMSiteStartEndDateDB(mwqmSiteStartEndDateNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateModelRet.Error))
                        return ReturnError(mwqmSiteStartEndDateModelRet.Error);
                }
                else
                {
                    mwqmSiteStartEndDateModelRet = PostUpdateMWQMSiteStartEndDateDB(mwqmSiteStartEndDateNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateModelRet.Error))
                        return ReturnError(mwqmSiteStartEndDateModelRet.Error);
                }

                ts.Complete();
            }
            return mwqmSiteStartEndDateModelRet;
        }
        public MWQMSiteStartEndDateModel PostAddMWQMSiteStartEndDateDB(MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel)
        {
            string retStr = MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExit = _TVItemService.GetTVItemModelWithTVItemIDDB(mwqmSiteStartEndDateModel.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExit.Error))
                return ReturnError(tvItemModelExit.Error);

            MWQMSiteStartEndDateModel MWQMSiteStartEndDateModelExist = GetMWQMSiteStartEndDateExistDB(mwqmSiteStartEndDateModel);
            if (string.IsNullOrWhiteSpace(MWQMSiteStartEndDateModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSiteStartEndDate));

            MWQMSiteStartEndDate mwqmSiteStartEndDateNew = new MWQMSiteStartEndDate();
            retStr = FillMWQMSiteStartEndDate(mwqmSiteStartEndDateNew, mwqmSiteStartEndDateModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSiteStartEndDates.Add(mwqmSiteStartEndDateNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSiteStartEndDates", mwqmSiteStartEndDateNew.MWQMSiteStartEndDateID, LogCommandEnum.Add, mwqmSiteStartEndDateNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSiteStartEndDateModelWithMWQMSiteStartEndDateIDDB(mwqmSiteStartEndDateNew.MWQMSiteStartEndDateID);
        }
        public MWQMSiteStartEndDateModel PostDeleteMWQMSiteStartEndDateDB(int MWQMSiteStartEndDateID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSiteStartEndDate mwqmSiteStartEndDateToDelete = GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDB(MWQMSiteStartEndDateID);
            if (mwqmSiteStartEndDateToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSiteStartEndDate));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSiteStartEndDates.Remove(mwqmSiteStartEndDateToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSiteStartEndDates", mwqmSiteStartEndDateToDelete.MWQMSiteStartEndDateID, LogCommandEnum.Delete, mwqmSiteStartEndDateToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public MWQMSiteStartEndDateModel PostUpdateMWQMSiteStartEndDateDB(MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel)
        {
            string retStr = MWQMSiteStartEndDateModelOK(mwqmSiteStartEndDateModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSiteStartEndDate mwqmSiteStartEndDateToUpdate = GetMWQMSiteStartEndDateWithMWQMSiteStartEndDateIDDB(mwqmSiteStartEndDateModel.MWQMSiteStartEndDateID);
            if (mwqmSiteStartEndDateToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSiteStartEndDate));

            retStr = FillMWQMSiteStartEndDate(mwqmSiteStartEndDateToUpdate, mwqmSiteStartEndDateModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSiteStartEndDates", mwqmSiteStartEndDateToUpdate.MWQMSiteStartEndDateID, LogCommandEnum.Change, mwqmSiteStartEndDateToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSiteStartEndDateModelWithMWQMSiteStartEndDateIDDB(mwqmSiteStartEndDateToUpdate.MWQMSiteStartEndDateID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}