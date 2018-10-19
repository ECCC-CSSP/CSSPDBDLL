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
using System.IO;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class SamplingPlanEmailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public AppTaskService _AppTaskService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public TVFileService _TVFileService { get; private set; }
        public MWQMSubsectorService _MWQMSubsectorService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
            _MWQMSubsectorService = new MWQMSubsectorService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
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
        public string SamplingPlanEmailModelOK(SamplingPlanEmailModel SamplingPlanEmailModel)
        {
            string retStr = FieldCheckIfNotNullNotZeroInt(SamplingPlanEmailModel.SamplingPlanID, ServiceRes.SamplingPlanID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(SamplingPlanEmailModel.Email, ServiceRes.Email, 3, 150);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillSamplingPlanEmail(SamplingPlanEmail SamplingPlanEmail, SamplingPlanEmailModel SamplingPlanEmailModel, ContactOK contactOK)
        {
            SamplingPlanEmail.SamplingPlanID = SamplingPlanEmailModel.SamplingPlanID;
            SamplingPlanEmail.Email = SamplingPlanEmailModel.Email;
            SamplingPlanEmail.IsContractor = SamplingPlanEmailModel.IsContractor;
            SamplingPlanEmail.LabSheetHasValueOver500 = SamplingPlanEmailModel.LabSheetHasValueOver500;
            SamplingPlanEmail.LabSheetReceived = SamplingPlanEmailModel.LabSheetReceived;
            SamplingPlanEmail.LabSheetAccepted = SamplingPlanEmailModel.LabSheetAccepted;
            SamplingPlanEmail.LabSheetRejected = SamplingPlanEmailModel.LabSheetRejected;
            SamplingPlanEmail.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                SamplingPlanEmail.LastUpdateContactTVItemID = 2;
            }
            else
            {
                SamplingPlanEmail.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetSamplingPlanEmailModelCountDB()
        {
            int SamplingPlanEmailModelCount = (from c in db.SamplingPlanEmails
                                               select c).Count();

            return SamplingPlanEmailModelCount;
        }
        public SamplingPlanEmailModel GetSamplingPlanEmailModelExistDB(SamplingPlanEmailModel SamplingPlanEmailModel)
        {
            SamplingPlanEmailModel SamplingPlanEmailModelRet = (from c in db.SamplingPlanEmails
                                                                let samplingPlanName = (from p in db.SamplingPlans where c.SamplingPlanID == p.SamplingPlanID select p.SamplingPlanName).FirstOrDefault()
                                                                where c.SamplingPlanID == SamplingPlanEmailModel.SamplingPlanID
                                                                && c.Email == SamplingPlanEmailModel.Email
                                                                select new SamplingPlanEmailModel
                                                                {
                                                                    Error = "",
                                                                    SamplingPlanEmailID = c.SamplingPlanEmailID,
                                                                    Email = c.Email,
                                                                    IsContractor = c.IsContractor,
                                                                    LabSheetHasValueOver500 = c.LabSheetHasValueOver500,
                                                                    LabSheetReceived = c.LabSheetReceived,
                                                                    LabSheetAccepted = c.LabSheetAccepted,
                                                                    LabSheetRejected = c.LabSheetRejected,
                                                                    LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                    LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                }).FirstOrDefault<SamplingPlanEmailModel>();


            if (SamplingPlanEmailModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.SamplingPlanID,
                    ServiceRes.Email,
                    SamplingPlanEmailModel.SamplingPlanID + "," +
                    SamplingPlanEmailModel.Email));

            return SamplingPlanEmailModelRet;
        }
        public List<SamplingPlanEmailModel> GetSamplingPlanEmailModelListWithSamplingPlanIDDB(int SamplingPlanID)
        {
            List<SamplingPlanEmailModel> SamplingPlanEmailModelList = (from c in db.SamplingPlanEmails
                                                                       let samplingPlanName = (from p in db.SamplingPlans where c.SamplingPlanID == p.SamplingPlanID select p.SamplingPlanName).FirstOrDefault()
                                                                       where c.SamplingPlanID == SamplingPlanID
                                                                       orderby c.Email
                                                                       select new SamplingPlanEmailModel
                                                                       {
                                                                           Error = "",
                                                                           SamplingPlanEmailID = c.SamplingPlanEmailID,
                                                                           Email = c.Email,
                                                                           IsContractor = c.IsContractor,
                                                                           LabSheetHasValueOver500 = c.LabSheetHasValueOver500,
                                                                           LabSheetReceived = c.LabSheetReceived,
                                                                           LabSheetAccepted = c.LabSheetAccepted,
                                                                           LabSheetRejected = c.LabSheetRejected,
                                                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                       }).ToList<SamplingPlanEmailModel>();

            return SamplingPlanEmailModelList;
        }
        public SamplingPlanEmailModel GetSamplingPlanEmailModelWithSamplingPlanEmailIDDB(int SamplingPlanEmailID)
        {
            SamplingPlanEmailModel SamplingPlanEmailModel = (from c in db.SamplingPlanEmails
                                                             let samplingPlanName = (from p in db.SamplingPlans where c.SamplingPlanID == p.SamplingPlanID select p.SamplingPlanName).FirstOrDefault()
                                                             where c.SamplingPlanEmailID == SamplingPlanEmailID
                                                             select new SamplingPlanEmailModel
                                                             {
                                                                 Error = "",
                                                                 SamplingPlanEmailID = c.SamplingPlanEmailID,
                                                                 Email = c.Email,
                                                                 IsContractor = c.IsContractor,
                                                                 LabSheetHasValueOver500 = c.LabSheetHasValueOver500,
                                                                 LabSheetReceived = c.LabSheetReceived,
                                                                 LabSheetAccepted = c.LabSheetAccepted,
                                                                 LabSheetRejected = c.LabSheetRejected,
                                                                 LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                 LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                             }).FirstOrDefault<SamplingPlanEmailModel>();

            if (SamplingPlanEmailModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.SamplingPlanEmail,
                    ServiceRes.SamplingPlanEmailID,
                    SamplingPlanEmailID.ToString()));


            return SamplingPlanEmailModel;
        }
        public SamplingPlanEmail GetSamplingPlanEmailWithSamplingPlanEmailIDDB(int SamplingPlanEmailID)
        {
            SamplingPlanEmail SamplingPlanEmail = (from c in db.SamplingPlanEmails
                                                   where c.SamplingPlanEmailID == SamplingPlanEmailID
                                                   select c).FirstOrDefault<SamplingPlanEmail>();

            return SamplingPlanEmail;
        }

        // Helper
        public SamplingPlanEmailModel ReturnError(string Error)
        {
            return new SamplingPlanEmailModel() { Error = Error };
        }
        // Post
        public SamplingPlanEmailModel SamplingPlanEmailAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int SamplingPlanEmailID = 0;
            int SamplingPlanID = 0;
            string Email = "";
            bool IsContractor = false;
            bool LabSheetHasValueOver500 = false;
            bool LabSheetReceived = false;
            bool LabSheetAccepted = false;
            bool LabSheetRejected = false;

            int.TryParse(fc["SamplingPlanEmailID"], out SamplingPlanEmailID);
            // if 0 then want to add new SamplingPlanEmail else want to modify

            int.TryParse(fc["SamplingPlanID"], out SamplingPlanID);
            if (SamplingPlanID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SamplingPlanID));

            Email = fc["Email"];
            if (string.IsNullOrWhiteSpace(Email))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Email));


            if (!string.IsNullOrWhiteSpace(fc["IsContractor"]))
            {
                if (bool.Parse(fc["IsContractor"]))
                {
                    IsContractor = true;
                }
            }

            if (!string.IsNullOrWhiteSpace(fc["LabSheetHasValueOver500"]))
            {
                if (bool.Parse(fc["LabSheetHasValueOver500"]))
                {
                    LabSheetHasValueOver500 = true;
                }
            }

            if (!string.IsNullOrWhiteSpace(fc["LabSheetReceived"]))
            {
                if (bool.Parse(fc["LabSheetReceived"]))
                {
                    LabSheetReceived = true;
                }
            }

            if (!string.IsNullOrWhiteSpace(fc["LabSheetAccepted"]))
            {
                if (bool.Parse(fc["LabSheetAccepted"]))
                {
                    LabSheetAccepted = true;
                }
            }

            if (!string.IsNullOrWhiteSpace(fc["LabSheetRejected"]))
            {
                if (bool.Parse(fc["LabSheetRejected"]))
                {
                    LabSheetRejected = true;
                }
            }

            SamplingPlanEmailModel SamplingPlanEmailModelRet = new SamplingPlanEmailModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (SamplingPlanEmailID == 0)
                {
                    SamplingPlanEmailModel SamplingPlanEmailModelNew = new SamplingPlanEmailModel()
                    {
                        SamplingPlanID = SamplingPlanID,
                        Email = Email,
                        IsContractor = IsContractor,
                        LabSheetHasValueOver500 = LabSheetHasValueOver500,
                        LabSheetReceived = LabSheetReceived,
                        LabSheetAccepted = LabSheetAccepted,
                        LabSheetRejected = LabSheetRejected,
                    };

                    SamplingPlanEmailModelRet = PostAddSamplingPlanEmailDB(SamplingPlanEmailModelNew);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanEmailModelRet.Error))
                        ReturnError(SamplingPlanEmailModelRet.Error);

                }
                else
                {
                    SamplingPlanEmailModel SamplingPlanEmailModelToUpdate = GetSamplingPlanEmailModelWithSamplingPlanEmailIDDB(SamplingPlanEmailID);
                    SamplingPlanEmailModelToUpdate.SamplingPlanID = SamplingPlanID;
                    SamplingPlanEmailModelToUpdate.Email = Email;
                    SamplingPlanEmailModelToUpdate.IsContractor = IsContractor;
                    SamplingPlanEmailModelToUpdate.LabSheetHasValueOver500 = LabSheetHasValueOver500;
                    SamplingPlanEmailModelToUpdate.LabSheetReceived = LabSheetReceived;
                    SamplingPlanEmailModelToUpdate.LabSheetAccepted = LabSheetAccepted;
                    SamplingPlanEmailModelToUpdate.LabSheetRejected = LabSheetRejected;

                    SamplingPlanEmailModelRet = PostUpdateSamplingPlanEmailDB(SamplingPlanEmailModelToUpdate);
                    if (!string.IsNullOrWhiteSpace(SamplingPlanEmailModelRet.Error))
                        ReturnError(SamplingPlanEmailModelRet.Error);
                }

                ts.Complete();
            }

            return SamplingPlanEmailModelRet;
        }
        public SamplingPlanEmailModel PostAddSamplingPlanEmailDB(SamplingPlanEmailModel SamplingPlanEmailModel)
        {
            string retStr = SamplingPlanEmailModelOK(SamplingPlanEmailModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanEmailModel SamplingPlanEmailModelExist = GetSamplingPlanEmailModelExistDB(SamplingPlanEmailModel);
            if (string.IsNullOrWhiteSpace(SamplingPlanEmailModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.SamplingPlanEmail));

            SamplingPlanEmail SamplingPlanEmailNew = new SamplingPlanEmail();
            retStr = FillSamplingPlanEmail(SamplingPlanEmailNew, SamplingPlanEmailModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.SamplingPlanEmails.Add(SamplingPlanEmailNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanEmails", SamplingPlanEmailNew.SamplingPlanEmailID, LogCommandEnum.Add, SamplingPlanEmailNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSamplingPlanEmailModelWithSamplingPlanEmailIDDB(SamplingPlanEmailNew.SamplingPlanEmailID);
        }
        public SamplingPlanEmailModel PostDeleteSamplingPlanEmailDB(int SamplingPlanEmailID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanEmail SamplingPlanEmailToDelete = GetSamplingPlanEmailWithSamplingPlanEmailIDDB(SamplingPlanEmailID);
            if (SamplingPlanEmailToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.SamplingPlanEmail));

            using (TransactionScope ts = new TransactionScope())
            {
                db.SamplingPlanEmails.Remove(SamplingPlanEmailToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanEmails", SamplingPlanEmailToDelete.SamplingPlanEmailID, LogCommandEnum.Delete, SamplingPlanEmailToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public SamplingPlanEmailModel PostUpdateSamplingPlanEmailDB(SamplingPlanEmailModel SamplingPlanEmailModel)
        {
            string retStr = SamplingPlanEmailModelOK(SamplingPlanEmailModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            SamplingPlanEmail SamplingPlanEmailToUpdate = GetSamplingPlanEmailWithSamplingPlanEmailIDDB(SamplingPlanEmailModel.SamplingPlanEmailID);
            if (SamplingPlanEmailToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.SamplingPlanEmail));

            retStr = FillSamplingPlanEmail(SamplingPlanEmailToUpdate, SamplingPlanEmailModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("SamplingPlanEmails", SamplingPlanEmailToUpdate.SamplingPlanEmailID, LogCommandEnum.Change, SamplingPlanEmailToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetSamplingPlanEmailModelWithSamplingPlanEmailIDDB(SamplingPlanEmailToUpdate.SamplingPlanEmailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
