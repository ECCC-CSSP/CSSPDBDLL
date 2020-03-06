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
    public class CoCoRaHSValueService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CoCoRaHSValueService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Functions public
        public override ContactOK IsContactOK()
        {
            return base.IsContactOK();
        }
        public override string CoCoRaHSDoAddChanges()
        {
            return base.CoCoRaHSDoAddChanges();
        }
        public override string CoCoRaHSDoDeleteChanges()
        {
            return base.CoCoRaHSDoDeleteChanges();
        }
        public override string CoCoRaHSDoUpdateChanges()
        {
            return base.CoCoRaHSDoUpdateChanges();
        }


        // Check
        public string CoCoRaHSValueModelOK(CoCoRaHSValueModel coCoRaHSValueModel)
        {
            string retStr = FieldCheckNotZeroInt(coCoRaHSValueModel.CoCoRaHSSiteID, ServiceRes.CoCoRaHSSiteID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(coCoRaHSValueModel.ObservationDateAndTime, ServiceRes.ObservationDateAndTime);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(coCoRaHSValueModel.TotalPrecipAmt, ServiceRes.TotalPrecipAmt, 0.0D, 100000.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(coCoRaHSValueModel.NewSnowDepth, ServiceRes.NewSnowDepth, 0.0D, 100000.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(coCoRaHSValueModel.NewSnowSWE, ServiceRes.NewSnowSWE, 0.0D, 100000.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(coCoRaHSValueModel.TotalSnowDepth, ServiceRes.TotalSnowDepth, 0.0D, 100000.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(coCoRaHSValueModel.TotalSnowSWE, ServiceRes.TotalSnowSWE, 0.0D, 100000.0D);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillCoCoRaHSValue(CoCoRaHSValue coCoRaHSValueNew, CoCoRaHSValueModel coCoRaHSValueModel, ContactOK contactOK)
        {
            coCoRaHSValueNew.CoCoRaHSSiteID = coCoRaHSValueModel.CoCoRaHSSiteID;
            coCoRaHSValueNew.ObservationDateAndTime = coCoRaHSValueModel.ObservationDateAndTime;
            coCoRaHSValueNew.TotalPrecipAmt = coCoRaHSValueModel.TotalPrecipAmt;
            coCoRaHSValueNew.NewSnowDepth = coCoRaHSValueModel.NewSnowDepth;
            coCoRaHSValueNew.NewSnowSWE = coCoRaHSValueModel.NewSnowSWE;
            coCoRaHSValueNew.TotalSnowDepth = coCoRaHSValueModel.TotalSnowDepth;
            coCoRaHSValueNew.TotalSnowSWE = coCoRaHSValueModel.TotalSnowSWE;
            coCoRaHSValueNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                coCoRaHSValueNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                coCoRaHSValueNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetCoCoRaHSValueModelCountDB()
        {
            int CoCoRaHSValueModelCount = (from c in CoCoRaHSdb.CoCoRaHSValues
                                           select c).Count();

            return CoCoRaHSValueModelCount;
        }
        public CoCoRaHSValueModel GetCoCoRaHSValueModelWithCoCoRaHSSiteIDDB(int CoCoRaHSSiteID)
        {
            CoCoRaHSValueModel coCoRaHSValueModel = (from c in CoCoRaHSdb.CoCoRaHSValues
                                                     where c.CoCoRaHSSiteID == CoCoRaHSSiteID
                                                     select new CoCoRaHSValueModel
                                                     {
                                                         Error = "",
                                                         CoCoRaHSValueID = c.CoCoRaHSValueID,
                                                         CoCoRaHSSiteID = c.CoCoRaHSSiteID,
                                                         ObservationDateAndTime = c.ObservationDateAndTime,
                                                         TotalPrecipAmt = c.TotalPrecipAmt,
                                                         NewSnowDepth = c.NewSnowDepth,
                                                         NewSnowSWE = c.NewSnowSWE,
                                                         TotalSnowDepth = c.TotalSnowDepth,
                                                         TotalSnowSWE = c.TotalSnowSWE,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<CoCoRaHSValueModel>();

            if (coCoRaHSValueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.CoCoRaHSValue, ServiceRes.CoCoRaHSSiteID, CoCoRaHSSiteID.ToString()));

            return coCoRaHSValueModel;
        }
        public CoCoRaHSValueModel GetCoCoRaHSValueModelWithCoCoRaHSValueIDDB(int CoCoRaHSValueID)
        {
            CoCoRaHSValueModel coCoRaHSValueModel = (from c in CoCoRaHSdb.CoCoRaHSValues
                                                     where c.CoCoRaHSValueID == CoCoRaHSValueID
                                                     select new CoCoRaHSValueModel
                                                     {
                                                         Error = "",
                                                         CoCoRaHSValueID = c.CoCoRaHSValueID,
                                                         CoCoRaHSSiteID = c.CoCoRaHSSiteID,
                                                         ObservationDateAndTime = c.ObservationDateAndTime,
                                                         TotalPrecipAmt = c.TotalPrecipAmt,
                                                         NewSnowDepth = c.NewSnowDepth,
                                                         NewSnowSWE = c.NewSnowSWE,
                                                         TotalSnowDepth = c.TotalSnowDepth,
                                                         TotalSnowSWE = c.TotalSnowSWE,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<CoCoRaHSValueModel>();

            if (coCoRaHSValueModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.CoCoRaHSValue, ServiceRes.CoCoRaHSValueID, CoCoRaHSValueID));

            return coCoRaHSValueModel;
        }
        public CoCoRaHSValueModel GetCoCoRaHSValueModelExistDB(CoCoRaHSValueModel coCoRaHSValueModel)
        {
            CoCoRaHSValueModel coCoRaHSValueModelRet = (from c in CoCoRaHSdb.CoCoRaHSValues
                                                        where c.CoCoRaHSSiteID == coCoRaHSValueModel.CoCoRaHSSiteID
                                                        && c.ObservationDateAndTime == coCoRaHSValueModel.ObservationDateAndTime
                                                        select new CoCoRaHSValueModel
                                                        {
                                                            Error = "",
                                                            CoCoRaHSValueID = c.CoCoRaHSValueID,
                                                            CoCoRaHSSiteID = c.CoCoRaHSSiteID,
                                                            ObservationDateAndTime = c.ObservationDateAndTime,
                                                            TotalPrecipAmt = c.TotalPrecipAmt,
                                                            NewSnowDepth = c.NewSnowDepth,
                                                            NewSnowSWE = c.NewSnowSWE,
                                                            TotalSnowDepth = c.TotalSnowDepth,
                                                            TotalSnowSWE = c.TotalSnowSWE,
                                                            LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                            LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                        }).FirstOrDefault<CoCoRaHSValueModel>();

            if (coCoRaHSValueModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.CoCoRaHSValue,
                    ServiceRes.CoCoRaHSSiteID + "," +
                    ServiceRes.ObservationDateAndTime,
                    coCoRaHSValueModel.CoCoRaHSSiteID + "," +
                    coCoRaHSValueModel.ObservationDateAndTime.ToString()));

            return coCoRaHSValueModelRet;
        }
        public CoCoRaHSValue GetCoCoRaHSValueWithCoCoRaHSValueIDDB(int CoCoRaHSValueID)
        {
            CoCoRaHSValue CoCoRaHSValue = (from c in CoCoRaHSdb.CoCoRaHSValues
                                           where c.CoCoRaHSValueID == CoCoRaHSValueID
                                           select c).FirstOrDefault<CoCoRaHSValue>();
            return CoCoRaHSValue;
        }

        // Helper
        public CoCoRaHSValueModel ReturnError(string Error)
        {
            return new CoCoRaHSValueModel() { Error = Error };
        }

        // Post
        public CoCoRaHSValueModel PostAddCoCoRaHSValueDB(CoCoRaHSValueModel coCoRaHSValueModel)
        {
            string retStr = CoCoRaHSValueModelOK(coCoRaHSValueModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            CoCoRaHSValue coCoRaHSValueNew = new CoCoRaHSValue();

            retStr = FillCoCoRaHSValue(coCoRaHSValueNew, coCoRaHSValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                CoCoRaHSdb.CoCoRaHSValues.Add(coCoRaHSValueNew);
                retStr = CoCoRaHSDoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }
            return GetCoCoRaHSValueModelWithCoCoRaHSValueIDDB(coCoRaHSValueNew.CoCoRaHSValueID);
        }
        public CoCoRaHSValueModel PostDeleteCoCoRaHSValueDB(int CoCoRaHSValueID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            CoCoRaHSValue coCoRaHSValueToDelete = GetCoCoRaHSValueWithCoCoRaHSValueIDDB(CoCoRaHSValueID);
            if (coCoRaHSValueToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.CoCoRaHSValue));

            using (TransactionScope ts = new TransactionScope())
            {
                CoCoRaHSdb.CoCoRaHSValues.Remove(coCoRaHSValueToDelete);
                string retStr = CoCoRaHSDoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }

            return ReturnError("");
        }
        public CoCoRaHSValueModel PostUpdateCoCoRaHSValueDB(CoCoRaHSValueModel coCoRaHSValueModel)
        {
            string retStr = CoCoRaHSValueModelOK(coCoRaHSValueModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            CoCoRaHSValue coCoRaHSValueToUpdate = GetCoCoRaHSValueWithCoCoRaHSValueIDDB(coCoRaHSValueModel.CoCoRaHSValueID);
            if (coCoRaHSValueToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.CoCoRaHSValue));

            retStr = FillCoCoRaHSValue(coCoRaHSValueToUpdate, coCoRaHSValueModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = CoCoRaHSDoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                ts.Complete();
            }
            return GetCoCoRaHSValueModelWithCoCoRaHSValueIDDB(coCoRaHSValueToUpdate.CoCoRaHSValueID);
        }

        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
