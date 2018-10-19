using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.IO;
using System.Web.Mvc;
using System.Net.Mail;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class LabSheetTubeMPNDetailService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public MWQMRunService _MWQMRunService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public MWQMSiteService _MWQMSiteService { get; private set; }
        public MWQMSampleService _MWQMSampleService { get; private set; }
        public TVFileService _TVFileService { get; private set; }
        public AppTaskService _AppTaskService { get; private set; }
        public ContactService _ContactService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public LabSheetTubeMPNDetailService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MWQMRunService = new MWQMRunService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MWQMSiteService = new MWQMSiteService(LanguageRequest, User);
            _MWQMSampleService = new MWQMSampleService(LanguageRequest, User);
            _TVFileService = new TVFileService(LanguageRequest, User);
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _ContactService = new ContactService(LanguageRequest, User);
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
        public override string SendEmail(MailMessage mail)
        {
            return base.SendEmail(mail);
        }

        // Check
        public string LabSheetTubeMPNDetailModelOK(LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel)
        {
            string retStr = FieldCheckNotZeroInt(labSheetTubeMPNDetailModel.LabSheetDetailID, ServiceRes.LabSheetDetailID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(labSheetTubeMPNDetailModel.Ordinal, ServiceRes.Ordinal, 0, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(labSheetTubeMPNDetailModel.MWQMSiteTVItemID, ServiceRes.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            if (labSheetTubeMPNDetailModel.SampleDateTime != null)
            {
                retStr = FieldCheckNotNullDateTime(labSheetTubeMPNDetailModel.SampleDateTime, ServiceRes.SampleDateTime);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            if (labSheetTubeMPNDetailModel.MPN != -999)
            {
                retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetTubeMPNDetailModel.MPN, ServiceRes.MPN, 1, 100000000);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(labSheetTubeMPNDetailModel.Tube10, ServiceRes.Tube10, 0, 5);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(labSheetTubeMPNDetailModel.Tube1_0, ServiceRes.Tube1_0, 0, 5);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(labSheetTubeMPNDetailModel.Tube0_1, ServiceRes.Tube0_1, 0, 5);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetTubeMPNDetailModel.Salinity, ServiceRes.Salinity, 0, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(labSheetTubeMPNDetailModel.Temperature, ServiceRes.Temperature, -12, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(labSheetTubeMPNDetailModel.ProcessedBy, ServiceRes.ProcessedBy, 10);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.SampleTypeOK(labSheetTubeMPNDetailModel.SampleType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(labSheetTubeMPNDetailModel.SiteComment, ServiceRes.SiteComment, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillLabSheetTubeMPNDetail(LabSheetTubeMPNDetail labSheetTubeMPNDetail, LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel, ContactOK contactOK)
        {
            labSheetTubeMPNDetail.LabSheetTubeMPNDetailID = labSheetTubeMPNDetailModel.LabSheetTubeMPNDetailID;
            labSheetTubeMPNDetail.LabSheetDetailID = labSheetTubeMPNDetailModel.LabSheetDetailID;
            labSheetTubeMPNDetail.Ordinal = labSheetTubeMPNDetailModel.Ordinal;
            labSheetTubeMPNDetail.MWQMSiteTVItemID = labSheetTubeMPNDetailModel.MWQMSiteTVItemID;
            labSheetTubeMPNDetail.SampleDateTime = labSheetTubeMPNDetailModel.SampleDateTime;
            labSheetTubeMPNDetail.MPN = labSheetTubeMPNDetailModel.MPN;
            labSheetTubeMPNDetail.Tube10 = labSheetTubeMPNDetailModel.Tube10;
            labSheetTubeMPNDetail.Tube1_0 = labSheetTubeMPNDetailModel.Tube1_0;
            labSheetTubeMPNDetail.Tube0_1 = labSheetTubeMPNDetailModel.Tube0_1;
            labSheetTubeMPNDetail.Salinity = labSheetTubeMPNDetailModel.Salinity;
            labSheetTubeMPNDetail.Temperature = labSheetTubeMPNDetailModel.Temperature;
            labSheetTubeMPNDetail.ProcessedBy = labSheetTubeMPNDetailModel.ProcessedBy;
            labSheetTubeMPNDetail.SampleType = (int)labSheetTubeMPNDetailModel.SampleType;
            labSheetTubeMPNDetail.SiteComment = labSheetTubeMPNDetailModel.SiteComment;
            labSheetTubeMPNDetail.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                labSheetTubeMPNDetail.LastUpdateContactTVItemID = 2;
            }
            else
            {
                labSheetTubeMPNDetail.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetLabSheetTubeMPNDetailModelCountDB()
        {
            int LabSheetTubeMPNDetailModelCount = (from c in db.LabSheetTubeMPNDetails
                                                   select c).Count();

            return LabSheetTubeMPNDetailModelCount;
        }
        public LabSheetTubeMPNDetailModel GetLabSheetTubeMPNDetailModelExistDB(LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel)
        {
            LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelRet = (from c in db.LabSheetTubeMPNDetails
                                                                        where c.LabSheetDetailID == labSheetTubeMPNDetailModel.LabSheetDetailID
                                                                        && c.MWQMSiteTVItemID == labSheetTubeMPNDetailModel.MWQMSiteTVItemID
                                                                        && c.SampleDateTime == labSheetTubeMPNDetailModel.SampleDateTime
                                                                        && c.SampleType == (int)labSheetTubeMPNDetailModel.SampleType
                                                                        orderby c.Ordinal
                                                                        select new LabSheetTubeMPNDetailModel
                                                                        {
                                                                            Error = "",
                                                                            LabSheetTubeMPNDetailID = c.LabSheetTubeMPNDetailID,
                                                                            LabSheetDetailID = c.LabSheetDetailID,
                                                                            Ordinal = c.Ordinal,
                                                                            MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                            SampleDateTime = c.SampleDateTime,
                                                                            MPN = c.MPN,
                                                                            Tube10 = c.Tube10,
                                                                            Tube1_0 = c.Tube1_0,
                                                                            Tube0_1 = c.Tube0_1,
                                                                            Salinity = (float)c.Salinity,
                                                                            Temperature = (float)c.Temperature,
                                                                            ProcessedBy = c.ProcessedBy,
                                                                            SampleType = (SampleTypeEnum)c.SampleType,
                                                                            SiteComment = c.SiteComment,
                                                                            LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                            LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                        }).FirstOrDefault<LabSheetTubeMPNDetailModel>();

            if (labSheetTubeMPNDetailModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetTubeMPNDetail,
                    ServiceRes.LabSheetDetailID + "," +
                    ServiceRes.MWQMSiteTVItemID + "," +
                    ServiceRes.SampleDateTime + "," +
                    ServiceRes.SampleType,
                    labSheetTubeMPNDetailModel.LabSheetDetailID + "," +
                    labSheetTubeMPNDetailModel.MWQMSiteTVItemID + "," +
                    labSheetTubeMPNDetailModel.SampleDateTime + "," +
                    labSheetTubeMPNDetailModel.SampleType));

            return labSheetTubeMPNDetailModelRet;
        }
        public List<LabSheetTubeMPNDetailModel> GetLabSheetTubeMPNDetailModelListWithLabSheetDetailIDDB(int LabSheetDetailID)
        {
            List<LabSheetTubeMPNDetailModel> LabSheetTubeMPNDetailModelList = (from c in db.LabSheetTubeMPNDetails
                                                                               where c.LabSheetDetailID == LabSheetDetailID
                                                                               orderby c.Ordinal
                                                                               select new LabSheetTubeMPNDetailModel
                                                                               {
                                                                                   Error = "",
                                                                                   LabSheetTubeMPNDetailID = c.LabSheetTubeMPNDetailID,
                                                                                   LabSheetDetailID = c.LabSheetDetailID,
                                                                                   Ordinal = c.Ordinal,
                                                                                   MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                                   SampleDateTime = c.SampleDateTime,
                                                                                   MPN = c.MPN,
                                                                                   Tube10 = c.Tube10,
                                                                                   Tube1_0 = c.Tube1_0,
                                                                                   Tube0_1 = c.Tube0_1,
                                                                                   Salinity = (float)c.Salinity,
                                                                                   Temperature = (float)c.Temperature,
                                                                                   ProcessedBy = c.ProcessedBy,
                                                                                   SampleType = (SampleTypeEnum)c.SampleType,
                                                                                   SiteComment = c.SiteComment,
                                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                               }).ToList<LabSheetTubeMPNDetailModel>();

            return LabSheetTubeMPNDetailModelList;
        }
        public List<LabSheetTubeMPNDetailModel> GetLabSheetTubeMPNDetailModelListWithMWQMSiteTVItemIDDB(int MWQMSiteTVItemID)
        {
            List<LabSheetTubeMPNDetailModel> LabSheetTubeMPNDetailModelList = (from c in db.LabSheetTubeMPNDetails
                                                                               where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                                                               orderby c.Ordinal
                                                                               select new LabSheetTubeMPNDetailModel
                                                                               {
                                                                                   Error = "",
                                                                                   LabSheetTubeMPNDetailID = c.LabSheetTubeMPNDetailID,
                                                                                   LabSheetDetailID = c.LabSheetDetailID,
                                                                                   Ordinal = c.Ordinal,
                                                                                   MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                                   SampleDateTime = c.SampleDateTime,
                                                                                   MPN = c.MPN,
                                                                                   Tube10 = c.Tube10,
                                                                                   Tube1_0 = c.Tube1_0,
                                                                                   Tube0_1 = c.Tube0_1,
                                                                                   Salinity = (float)c.Salinity,
                                                                                   Temperature = (float)c.Temperature,
                                                                                   ProcessedBy = c.ProcessedBy,
                                                                                   SampleType = (SampleTypeEnum)c.SampleType,
                                                                                   SiteComment = c.SiteComment,
                                                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                               }).ToList<LabSheetTubeMPNDetailModel>();

            return LabSheetTubeMPNDetailModelList;
        }
        public LabSheetTubeMPNDetailModel GetLabSheetTubeMPNDetailModelWithLabSheetTubeMPNDetailIDDB(int LabSheetTubeMPNDetailID)
        {
            LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel = (from c in db.LabSheetTubeMPNDetails
                                                                     where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                                                                     orderby c.Ordinal
                                                                     select new LabSheetTubeMPNDetailModel
                                                                     {
                                                                         Error = "",
                                                                         LabSheetTubeMPNDetailID = c.LabSheetTubeMPNDetailID,
                                                                         LabSheetDetailID = c.LabSheetDetailID,
                                                                         Ordinal = c.Ordinal,
                                                                         MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                                         SampleDateTime = c.SampleDateTime,
                                                                         MPN = c.MPN,
                                                                         Tube10 = c.Tube10,
                                                                         Tube1_0 = c.Tube1_0,
                                                                         Tube0_1 = c.Tube0_1,
                                                                         Salinity = (float)c.Salinity,
                                                                         Temperature = (float)c.Temperature,
                                                                         ProcessedBy = c.ProcessedBy,
                                                                         SampleType = (SampleTypeEnum)c.SampleType,
                                                                         SiteComment = c.SiteComment,
                                                                         LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                                         LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                                     }).FirstOrDefault<LabSheetTubeMPNDetailModel>();

            if (labSheetTubeMPNDetailModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.LabSheetTubeMPNDetail, ServiceRes.LabSheetTubeMPNDetailID, LabSheetTubeMPNDetailID));

            return labSheetTubeMPNDetailModel;
        }
        public LabSheetTubeMPNDetail GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDB(int LabSheetTubeMPNDetailID)
        {
            LabSheetTubeMPNDetail labSheetTubeMPNDetail = (from c in db.LabSheetTubeMPNDetails
                                                           where c.LabSheetTubeMPNDetailID == LabSheetTubeMPNDetailID
                                                           orderby c.Ordinal
                                                           select c).FirstOrDefault<LabSheetTubeMPNDetail>();

            return labSheetTubeMPNDetail;
        }

        // Helper
        public LabSheetTubeMPNDetailModel ReturnError(string Error)
        {
            return new LabSheetTubeMPNDetailModel() { Error = Error };
        }

        // Post
        public LabSheetTubeMPNDetailModel PostAddLabSheetTubeMPNDetailDB(LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel)
        {
            string retStr = LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModelExist = GetLabSheetTubeMPNDetailModelExistDB(labSheetTubeMPNDetailModel);
            if (string.IsNullOrWhiteSpace(labSheetTubeMPNDetailModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.LabSheetTubeMPNDetail));

            LabSheetTubeMPNDetail labSheetTubeMPNDetailNew = new LabSheetTubeMPNDetail();
            retStr = FillLabSheetTubeMPNDetail(labSheetTubeMPNDetailNew, labSheetTubeMPNDetailModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.LabSheetTubeMPNDetails.Add(labSheetTubeMPNDetailNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheetTubeMPNDetails", labSheetTubeMPNDetailNew.LabSheetTubeMPNDetailID, LogCommandEnum.Add, labSheetTubeMPNDetailNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetLabSheetTubeMPNDetailModelWithLabSheetTubeMPNDetailIDDB(labSheetTubeMPNDetailNew.LabSheetTubeMPNDetailID);
        }
        public LabSheetTubeMPNDetailModel PostDeleteLabSheetTubeMPNDetailDB(int LabSheetTubeMPNDetailID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetTubeMPNDetail labSheetTubeMPNDetailToDelete = GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDB(LabSheetTubeMPNDetailID);
            if (labSheetTubeMPNDetailToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.LabSheetTubeMPNDetail));

            using (TransactionScope ts = new TransactionScope())
            {
                db.LabSheetTubeMPNDetails.Remove(labSheetTubeMPNDetailToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheetTubeMPNDetails", labSheetTubeMPNDetailToDelete.LabSheetTubeMPNDetailID, LogCommandEnum.Delete, labSheetTubeMPNDetailToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public LabSheetTubeMPNDetailModel PostUpdateLabSheetTubeMPNDetailDB(LabSheetTubeMPNDetailModel labSheetTubeMPNDetailModel)
        {
            string retStr = LabSheetTubeMPNDetailModelOK(labSheetTubeMPNDetailModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            LabSheetTubeMPNDetail labSheetTubeMPNDetailToUpdate = GetLabSheetTubeMPNDetailWithLabSheetTubeMPNDetailIDDB(labSheetTubeMPNDetailModel.LabSheetTubeMPNDetailID);
            if (labSheetTubeMPNDetailToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.LabSheetTubeMPNDetail));

            retStr = FillLabSheetTubeMPNDetail(labSheetTubeMPNDetailToUpdate, labSheetTubeMPNDetailModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("LabSheetTubeMPNDetails", labSheetTubeMPNDetailToUpdate.LabSheetTubeMPNDetailID, LogCommandEnum.Change, labSheetTubeMPNDetailToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetLabSheetTubeMPNDetailModelWithLabSheetTubeMPNDetailIDDB(labSheetTubeMPNDetailToUpdate.LabSheetTubeMPNDetailID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
