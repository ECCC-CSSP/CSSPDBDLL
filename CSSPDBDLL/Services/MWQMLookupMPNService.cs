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
    public class MWQMLookupMPNService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
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
        public string MWQMLookupMPNModelOK(MWQMLookupMPNModel mwqmLookupMPNModel)
        {
            string retStr = FieldCheckNotNullAndWithinRangeInt(mwqmLookupMPNModel.Tubes10, ServiceRes.Tubes10, 0, 5);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmLookupMPNModel.Tubes1, ServiceRes.Tubes1, 0, 5);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmLookupMPNModel.Tubes01, ServiceRes.Tubes01, 0, 5);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeDouble(mwqmLookupMPNModel.MPN_100ml, ServiceRes.MPN_100ml, 0, 1700);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(mwqmLookupMPNModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMWQMLookupMPN(MWQMLookupMPN mwqmLookupMPNNew, MWQMLookupMPNModel mwqmLookupMPNModel, ContactOK contactOK)
        {
            mwqmLookupMPNNew.DBCommand = (int)mwqmLookupMPNModel.DBCommand;
            mwqmLookupMPNNew.Tubes01 = mwqmLookupMPNModel.Tubes01;
            mwqmLookupMPNNew.Tubes1 = mwqmLookupMPNModel.Tubes1;
            mwqmLookupMPNNew.Tubes10 = mwqmLookupMPNModel.Tubes10;
            mwqmLookupMPNNew.MPN_100ml = mwqmLookupMPNModel.MPN_100ml;
            mwqmLookupMPNNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmLookupMPNNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmLookupMPNNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMWQMLookupMPNModelCountDB()
        {
            int MWQMLookupMPNModelCount = (from c in db.MWQMLookupMPNs
                                           select c).Count();

            return MWQMLookupMPNModelCount;
        }
        public List<MWQMLookupMPNModel> GetMWQMLookupMPNModelListDB()
        {
            List<MWQMLookupMPNModel> mwqmLookupMPNModelList = (from c in db.MWQMLookupMPNs
                                                               select new MWQMLookupMPNModel
                                                               {
                                                                   Error = "",
                                                                   MWQMLookupMPNID = c.MWQMLookupMPNID,
                                                                   DBCommand = (DBCommandEnum)c.DBCommand,
                                                                   Tubes01 = c.Tubes01,
                                                                   Tubes1 = c.Tubes1,
                                                                   Tubes10 = c.Tubes10,
                                                                   MPN_100ml = c.MPN_100ml,
                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                               }).ToList<MWQMLookupMPNModel>();

            return mwqmLookupMPNModelList;
        }
        public MWQMLookupMPNModel GetMWQMLookupMPNModelWithMWQMLookupMPNIDDB(int MWQMLookupMPNID)
        {
            MWQMLookupMPNModel mwqmLookupMPNModel = (from c in db.MWQMLookupMPNs
                                                     where c.MWQMLookupMPNID == MWQMLookupMPNID
                                                     select new MWQMLookupMPNModel
                                                     {
                                                         Error = "",
                                                         MWQMLookupMPNID = c.MWQMLookupMPNID,
                                                         DBCommand = (DBCommandEnum)c.DBCommand,
                                                         Tubes01 = c.Tubes01,
                                                         Tubes1 = c.Tubes1,
                                                         Tubes10 = c.Tubes10,
                                                         MPN_100ml = c.MPN_100ml,
                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                     }).FirstOrDefault<MWQMLookupMPNModel>();

            if (mwqmLookupMPNModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMLookupMPN, ServiceRes.MWQMLookupMPNID, MWQMLookupMPNID));

            return mwqmLookupMPNModel;
        }
        public MWQMLookupMPN GetMWQMLookupMPNWithMWQMLookupMPNIDDB(int MWQMLookupMPNID)
        {
            MWQMLookupMPN mwqmLookupMPN = (from c in db.MWQMLookupMPNs
                                           where c.MWQMLookupMPNID == MWQMLookupMPNID
                                           select c).FirstOrDefault<MWQMLookupMPN>();

            return mwqmLookupMPN;
        }
        public MWQMLookupMPN GetMWQMLookupMPNExistDB(int Tubes10, int Tubes1, int Tubes01, int MPN_100ml)
        {
            MWQMLookupMPN mwqmLookupMPN = (from c in db.MWQMLookupMPNs
                                           where c.Tubes10 == Tubes10
                                           && c.Tubes1 == Tubes1
                                           && c.Tubes01 == Tubes01
                                           && c.MPN_100ml == MPN_100ml
                                           select c).FirstOrDefault<MWQMLookupMPN>();

            return mwqmLookupMPN;
        }

        // Helper
        public MWQMLookupMPNModel ReturnError(string Error)
        {
            return new MWQMLookupMPNModel() { Error = Error };
        }

        // Post
        public MWQMLookupMPNModel PostAddMWQMLookupMPNDB(MWQMLookupMPNModel mwqmLookupMPNModel)
        {
            string retStr = MWQMLookupMPNModelOK(mwqmLookupMPNModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMLookupMPN mwqmLookupMPNExist = GetMWQMLookupMPNExistDB(mwqmLookupMPNModel.Tubes10, mwqmLookupMPNModel.Tubes1, mwqmLookupMPNModel.Tubes01, mwqmLookupMPNModel.MPN_100ml);
            if (mwqmLookupMPNExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMLookupMPN));

            MWQMLookupMPN mwqmLookupMPNNew = new MWQMLookupMPN();
            retStr = FillMWQMLookupMPN(mwqmLookupMPNNew, mwqmLookupMPNModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMLookupMPNs.Add(mwqmLookupMPNNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMLookupMPNs", mwqmLookupMPNNew.MWQMLookupMPNID, LogCommandEnum.Add, mwqmLookupMPNNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMLookupMPNModelWithMWQMLookupMPNIDDB(mwqmLookupMPNNew.MWQMLookupMPNID);
        }
        public MWQMLookupMPNModel PostDeleteMWQMLookupMPNDB(int MWQMLookupMPNID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMLookupMPN MWQMLookupMPNToDelete = GetMWQMLookupMPNWithMWQMLookupMPNIDDB(MWQMLookupMPNID);
            if (MWQMLookupMPNToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMLookupMPN));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMLookupMPNs.Remove(MWQMLookupMPNToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMLookupMPNs", MWQMLookupMPNToDelete.MWQMLookupMPNID, LogCommandEnum.Delete, MWQMLookupMPNToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public MWQMLookupMPNModel PostUpdateMWQMLookupMPNDB(MWQMLookupMPNModel mwqmLookupMPNModel)
        {
            string retStr = MWQMLookupMPNModelOK(mwqmLookupMPNModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMLookupMPN mwqmLookupMPNToUpdate = GetMWQMLookupMPNWithMWQMLookupMPNIDDB(mwqmLookupMPNModel.MWQMLookupMPNID);
            if (mwqmLookupMPNToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMLookupMPN));

            retStr = FillMWQMLookupMPN(mwqmLookupMPNToUpdate, mwqmLookupMPNModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMLookupMPNs", mwqmLookupMPNToUpdate.MWQMLookupMPNID, LogCommandEnum.Change, mwqmLookupMPNToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMLookupMPNModelWithMWQMLookupMPNIDDB(mwqmLookupMPNToUpdate.MWQMLookupMPNID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
