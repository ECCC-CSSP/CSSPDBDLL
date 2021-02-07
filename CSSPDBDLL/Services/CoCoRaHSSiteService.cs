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
    public class CoCoRaHSSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CoCoRaHSSiteService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        //public override string CoCoRaHSDoAddChanges()
        //{
        //    return base.CoCoRaHSDoAddChanges();
        //}
        //public override string CoCoRaHSDoDeleteChanges()
        //{
        //    return base.CoCoRaHSDoDeleteChanges();
        //}
        //public override string CoCoRaHSDoUpdateChanges()
        //{
        //    return base.CoCoRaHSDoUpdateChanges();
        //}

        // Check
        public string CoCoRaHSSiteModelOK(CoCoRaHSSiteModel coCoRaHSSiteModel)
        {
            string retStr = FieldCheckNotNullAndMinMaxLengthString(coCoRaHSSiteModel.StationNumber, ServiceRes.StationNumber, 2, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(coCoRaHSSiteModel.StationName, ServiceRes.StationName, 2, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(coCoRaHSSiteModel.Latitude, ServiceRes.Latitude, -90.0D, 90.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(coCoRaHSSiteModel.Longitude, ServiceRes.Longitude, -180.0D, 180.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(coCoRaHSSiteModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillCoCoRaHSSite(CoCoRaHSSite coCoRaHSSiteNew, CoCoRaHSSiteModel coCoRaHSSiteModel, ContactOK contactOK)
        {
            coCoRaHSSiteNew.DBCommand = (int)coCoRaHSSiteModel.DBCommand;
            coCoRaHSSiteNew.StationNumber = coCoRaHSSiteModel.StationNumber;
            coCoRaHSSiteNew.StationName = coCoRaHSSiteModel.StationName;
            coCoRaHSSiteNew.Latitude = coCoRaHSSiteModel.Latitude;
            coCoRaHSSiteNew.Longitude = coCoRaHSSiteModel.Longitude;
            coCoRaHSSiteNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                coCoRaHSSiteNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                coCoRaHSSiteNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetCoCoRaHSSiteModelCountDB()
        {
            int CoCoRaHSSiteModelCount = (from c in db.CoCoRaHSSites
                                          select c).Count();

            return CoCoRaHSSiteModelCount;
        }
        public CoCoRaHSSiteModel GetCoCoRaHSSiteModelWithCoCoRaHSSiteIDDB(string StationNumber)
        {
            CoCoRaHSSiteModel coCoRaHSSiteModel = (from c in db.CoCoRaHSSites
                                                   where c.StationNumber == StationNumber
                                                   select new CoCoRaHSSiteModel
                                                   {
                                                       Error = "",
                                                       CoCoRaHSSiteID = c.CoCoRaHSSiteID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       StationNumber = c.StationNumber,
                                                       StationName = c.StationName,
                                                       Latitude = c.Latitude,
                                                       Longitude = c.Longitude,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).FirstOrDefault<CoCoRaHSSiteModel>();

            if (coCoRaHSSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.CoCoRaHSSite, ServiceRes.StationNumber, StationNumber));

            return coCoRaHSSiteModel;
        }
        public CoCoRaHSSiteModel GetCoCoRaHSSiteModelWithCoCoRaHSSiteIDDB(int CoCoRaHSSiteID)
        {
            CoCoRaHSSiteModel coCoRaHSSiteModel = (from c in db.CoCoRaHSSites
                                                   where c.CoCoRaHSSiteID == CoCoRaHSSiteID
                                                   select new CoCoRaHSSiteModel
                                                   {
                                                       Error = "",
                                                       CoCoRaHSSiteID = c.CoCoRaHSSiteID,
                                                       DBCommand = (DBCommandEnum)c.DBCommand,
                                                       StationNumber = c.StationNumber,
                                                       StationName = c.StationName,
                                                       Latitude = c.Latitude,
                                                       Longitude = c.Longitude,
                                                       LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                       LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                   }).FirstOrDefault<CoCoRaHSSiteModel>();

            if (coCoRaHSSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.CoCoRaHSSite, ServiceRes.CoCoRaHSSiteID, CoCoRaHSSiteID));

            return coCoRaHSSiteModel;
        }
        public CoCoRaHSSiteModel GetCoCoRaHSSiteModelExistDB(CoCoRaHSSiteModel coCoRaHSSiteModel)
        {
            CoCoRaHSSiteModel coCoRaHSSiteModelRet = (from c in db.CoCoRaHSSites
                                                      where c.StationNumber == coCoRaHSSiteModel.StationNumber
                                                      && c.StationName == coCoRaHSSiteModel.StationName
                                                      select new CoCoRaHSSiteModel
                                                      {
                                                          Error = "",
                                                          CoCoRaHSSiteID = c.CoCoRaHSSiteID,
                                                          DBCommand = (DBCommandEnum)c.DBCommand,
                                                          StationNumber = c.StationNumber,
                                                          StationName = c.StationName,
                                                          Latitude = c.Latitude,
                                                          Longitude = c.Longitude,
                                                          LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                          LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                      }).FirstOrDefault<CoCoRaHSSiteModel>();

            if (coCoRaHSSiteModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.CoCoRaHSSite,
                    ServiceRes.StationNumber + "," +
                    ServiceRes.StationName,
                    coCoRaHSSiteModel.StationNumber + "," +
                    coCoRaHSSiteModel.StationName));

            return coCoRaHSSiteModelRet;
        }
        public CoCoRaHSSite GetCoCoRaHSSiteWithCoCoRaHSSiteIDDB(int CoCoRaHSSiteID)
        {
            CoCoRaHSSite CoCoRaHSSite = (from c in db.CoCoRaHSSites
                                         where c.CoCoRaHSSiteID == CoCoRaHSSiteID
                                         select c).FirstOrDefault<CoCoRaHSSite>();
            return CoCoRaHSSite;
        }

        // Helper
        public string CreateTVText(CoCoRaHSSiteModel coCoRaHSSiteModel)
        {
            string retStr = "CoCoRaHS " + coCoRaHSSiteModel.StationName + " (" + coCoRaHSSiteModel.StationNumber + ")";

            return retStr;
        }
        public CoCoRaHSSiteModel ReturnError(string Error)
        {
            return new CoCoRaHSSiteModel() { Error = Error };
        }

        // Post
        public CoCoRaHSSiteModel PostAddCoCoRaHSSiteDB(CoCoRaHSSiteModel coCoRaHSSiteModel)
        {
            string retStr = CoCoRaHSSiteModelOK(coCoRaHSSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            CoCoRaHSSite coCoRaHSSiteNew = new CoCoRaHSSite();

            retStr = FillCoCoRaHSSite(coCoRaHSSiteNew, coCoRaHSSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.CoCoRaHSSites.Add(coCoRaHSSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }
            return GetCoCoRaHSSiteModelWithCoCoRaHSSiteIDDB(coCoRaHSSiteNew.CoCoRaHSSiteID);
        }
        public CoCoRaHSSiteModel PostDeleteCoCoRaHSSiteDB(int CoCoRaHSSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            CoCoRaHSSite coCoRaHSSiteToDelete = GetCoCoRaHSSiteWithCoCoRaHSSiteIDDB(CoCoRaHSSiteID);
            if (coCoRaHSSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.CoCoRaHSSite));

            using (TransactionScope ts = new TransactionScope())
            {
                db.CoCoRaHSSites.Remove(coCoRaHSSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }

            return ReturnError("");
        }
        public CoCoRaHSSiteModel PostUpdateCoCoRaHSSiteDB(CoCoRaHSSiteModel coCoRaHSSiteModel)
        {
            string retStr = CoCoRaHSSiteModelOK(coCoRaHSSiteModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            CoCoRaHSSite coCoRaHSSiteToUpdate = GetCoCoRaHSSiteWithCoCoRaHSSiteIDDB(coCoRaHSSiteModel.CoCoRaHSSiteID);
            if (coCoRaHSSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.CoCoRaHSSite));

            retStr = FillCoCoRaHSSite(coCoRaHSSiteToUpdate, coCoRaHSSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }
            return GetCoCoRaHSSiteModelWithCoCoRaHSSiteIDDB(coCoRaHSSiteToUpdate.CoCoRaHSSiteID);
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
