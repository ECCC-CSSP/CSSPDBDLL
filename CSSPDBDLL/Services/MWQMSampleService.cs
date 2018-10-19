using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class MWQMSampleService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public MWQMSampleLanguageService _MWQMSampleLanguageService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public MWQMRunService _MWQMRunService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _MWQMSampleLanguageService = new MWQMSampleLanguageService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MWQMRunService = new MWQMRunService(LanguageRequest, User);
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
        public string MWQMSampleModelOK(MWQMSampleModel mwqmSampleModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmSampleModel.MWQMSiteTVItemID, ServiceRes.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(mwqmSampleModel.MWQMRunTVItemID, ServiceRes.MWQMRunTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(mwqmSampleModel.SampleDateTime_Local, ServiceRes.SampleDateTime_Local);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmSampleModel.Depth_m, ServiceRes.Depth_m, 0, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmSampleModel.FecCol_MPN_100ml, ServiceRes.FecCol_MPN_100ml, 0, 100000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmSampleModel.Salinity_PPT, ServiceRes.Salinity_PPT, 0, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmSampleModel.WaterTemp_C, ServiceRes.WaterTemp_C, -12, 40);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeDouble(mwqmSampleModel.PH, ServiceRes.PH, 0, 14);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(mwqmSampleModel.SampleTypesText, ServiceRes.SampleTypesText, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            List<SampleTypeEnum> SampleTypeList = mwqmSampleModel.SampleTypesText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((SampleTypeEnum)(int.Parse(c)))).ToList<SampleTypeEnum>();
            foreach (SampleTypeEnum sampleType in SampleTypeList)
            {
                retStr = _BaseEnumService.SampleTypeOK(sampleType);
                if (!string.IsNullOrWhiteSpace(retStr))
                {
                    return retStr;
                }
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmSampleModel.MWQMSampleNote, ServiceRes.MWQMSampleNote, 10000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }


            return "";
        }

        // Fill
        public string FillMWQMSample(MWQMSample mwqmSample, MWQMSampleModel mwqmSampleModel, ContactOK contactOK)
        {
            mwqmSample.MWQMSiteTVItemID = mwqmSampleModel.MWQMSiteTVItemID;
            mwqmSample.MWQMRunTVItemID = mwqmSampleModel.MWQMRunTVItemID;
            mwqmSample.Depth_m = mwqmSampleModel.Depth_m;
            mwqmSample.FecCol_MPN_100ml = mwqmSampleModel.FecCol_MPN_100ml;
            mwqmSample.PH = mwqmSampleModel.PH;
            mwqmSample.Salinity_PPT = mwqmSampleModel.Salinity_PPT;
            mwqmSample.SampleDateTime_Local = mwqmSampleModel.SampleDateTime_Local;
            mwqmSample.WaterTemp_C = mwqmSampleModel.WaterTemp_C;
            mwqmSample.SampleTypesText = mwqmSampleModel.SampleTypesText;
            mwqmSample.Tube_10 = mwqmSampleModel.Tube_10;
            mwqmSample.Tube_1_0 = mwqmSampleModel.Tube_1_0;
            mwqmSample.Tube_0_1 = mwqmSampleModel.Tube_0_1;
            mwqmSample.ProcessedBy = mwqmSampleModel.ProcessedBy;
            mwqmSample.UseForOpenData = mwqmSampleModel.UseForOpenData;
            mwqmSample.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmSample.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmSample.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetMWQMSampleModelCountDB()
        {
            int MWQMSampleModelCount = (from c in db.MWQMSamples
                                        select c).Count();

            return MWQMSampleModelCount;
        }
        public List<MWQMSampleModel> GetMWQMSampleModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<MWQMSampleModel> mwqmSampleModelList = (from r in db.MWQMRuns
                                                         from c in db.MWQMSamples
                                                         let mwqmSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let mwqmSampleNote = (from cl in db.MWQMSampleLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSampleID == c.MWQMSampleID select cl.MWQMSampleNote).FirstOrDefault<string>()
                                                         where r.MWQMRunTVItemID == c.MWQMRunTVItemID
                                                         && r.SubsectorTVItemID == SubsectorTVItemID
                                                         orderby mwqmSiteTVText
                                                         select new MWQMSampleModel
                                                         {
                                                             Error = "",
                                                             MWQMSampleID = c.MWQMSampleID,
                                                             MWQMSampleNote = mwqmSampleNote,
                                                             MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                             MWQMSiteTVText = mwqmSiteTVText,
                                                             MWQMRunTVItemID = c.MWQMRunTVItemID,
                                                             MWQMRunTVText = mwqmRunTVText,
                                                             Depth_m = c.Depth_m,
                                                             FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                                                             PH = c.PH,
                                                             Salinity_PPT = c.Salinity_PPT,
                                                             SampleDateTime_Local = c.SampleDateTime_Local,
                                                             WaterTemp_C = c.WaterTemp_C,
                                                             SampleTypesText = c.SampleTypesText,
                                                             Tube_10 = c.Tube_10,
                                                             Tube_1_0 = c.Tube_1_0,
                                                             Tube_0_1 = c.Tube_0_1,
                                                             ProcessedBy = c.ProcessedBy,
                                                             UseForOpenData = c.UseForOpenData,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).ToList<MWQMSampleModel>();

            foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList)
            {
                mwqmSampleModel.SampleTypeList = mwqmSampleModel.SampleTypesText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((SampleTypeEnum)(int.Parse(c)))).ToList<SampleTypeEnum>();
            }

            return mwqmSampleModelList;
        }
        public List<MWQMSampleModel> GetMWQMSampleModelListWithMWQMRunTVItemIDDB(int MWQMRunTVItemID)
        {
            List<MWQMSampleModel> mwqmSampleModelList = (from c in db.MWQMSamples
                                                         let mwqmSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let mwqmSampleNote = (from cl in db.MWQMSampleLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSampleID == c.MWQMSampleID select cl.MWQMSampleNote).FirstOrDefault<string>()
                                                         where c.MWQMRunTVItemID == MWQMRunTVItemID
                                                         orderby mwqmSiteTVText
                                                         select new MWQMSampleModel
                                                         {
                                                             Error = "",
                                                             MWQMSampleID = c.MWQMSampleID,
                                                             MWQMSampleNote = mwqmSampleNote,
                                                             MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                             MWQMSiteTVText = mwqmSiteTVText,
                                                             MWQMRunTVItemID = c.MWQMRunTVItemID,
                                                             MWQMRunTVText = mwqmRunTVText,
                                                             Depth_m = c.Depth_m,
                                                             FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                                                             PH = c.PH,
                                                             Salinity_PPT = c.Salinity_PPT,
                                                             SampleDateTime_Local = c.SampleDateTime_Local,
                                                             WaterTemp_C = c.WaterTemp_C,
                                                             SampleTypesText = c.SampleTypesText,
                                                             Tube_10 = c.Tube_10,
                                                             Tube_1_0 = c.Tube_1_0,
                                                             Tube_0_1 = c.Tube_0_1,
                                                             ProcessedBy = c.ProcessedBy,
                                                             UseForOpenData = c.UseForOpenData,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).ToList<MWQMSampleModel>();

            foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList)
            {
                mwqmSampleModel.SampleTypeList = mwqmSampleModel.SampleTypesText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((SampleTypeEnum)(int.Parse(c)))).ToList<SampleTypeEnum>();
            }

            return mwqmSampleModelList;
        }
        public List<MWQMSampleModel> GetMWQMSampleModelListWithMWQMSiteTVItemIDDB(int MWQMSiteTVItemID)
        {
            List<MWQMSampleModel> mwqmSampleModelList = (from c in db.MWQMSamples
                                                         let mwqmSiteTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let mwqmSampleNote = (from cl in db.MWQMSampleLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSampleID == c.MWQMSampleID select cl.MWQMSampleNote).FirstOrDefault<string>()
                                                         where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                                         orderby c.SampleDateTime_Local descending
                                                         select new MWQMSampleModel
                                                         {
                                                             Error = "",
                                                             MWQMSampleID = c.MWQMSampleID,
                                                             MWQMSampleNote = mwqmSampleNote,
                                                             MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                             MWQMSiteTVText = mwqmSiteTVText,
                                                             MWQMRunTVItemID = c.MWQMRunTVItemID,
                                                             MWQMRunTVText = mwqmRunTVText,
                                                             Depth_m = c.Depth_m,
                                                             FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                                                             PH = c.PH,
                                                             Salinity_PPT = c.Salinity_PPT,
                                                             SampleDateTime_Local = c.SampleDateTime_Local,
                                                             WaterTemp_C = c.WaterTemp_C,
                                                             SampleTypesText = c.SampleTypesText,
                                                             Tube_10 = c.Tube_10,
                                                             Tube_1_0 = c.Tube_1_0,
                                                             Tube_0_1 = c.Tube_0_1,
                                                             ProcessedBy = c.ProcessedBy,
                                                             UseForOpenData = c.UseForOpenData,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).ToList<MWQMSampleModel>();

            foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList)
            {
                mwqmSampleModel.SampleTypeList = mwqmSampleModel.SampleTypesText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((SampleTypeEnum)(int.Parse(c)))).ToList<SampleTypeEnum>();
            }

            return mwqmSampleModelList;
        }
        public MWQMSampleModel GetMWQMSampleModelWithMWQMSampleIDDB(int MWQMSampleID)
        {
            MWQMSampleModel mwqmSampleModel = (from c in db.MWQMSamples
                                               let siteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                               let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                               let mwqmSampleNote = (from cl in db.MWQMSampleLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSampleID == c.MWQMSampleID select cl.MWQMSampleNote).FirstOrDefault<string>()
                                               where c.MWQMSampleID == MWQMSampleID
                                               select new MWQMSampleModel
                                               {
                                                   Error = "",
                                                   MWQMSampleID = c.MWQMSampleID,
                                                   MWQMSampleNote = mwqmSampleNote,
                                                   MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                   MWQMSiteTVText = siteName,
                                                   MWQMRunTVItemID = c.MWQMRunTVItemID,
                                                   MWQMRunTVText = mwqmRunTVText,
                                                   Depth_m = c.Depth_m,
                                                   FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                                                   PH = c.PH,
                                                   Salinity_PPT = c.Salinity_PPT,
                                                   SampleDateTime_Local = c.SampleDateTime_Local,
                                                   WaterTemp_C = c.WaterTemp_C,
                                                   SampleTypesText = c.SampleTypesText,
                                                   Tube_10 = c.Tube_10,
                                                   Tube_1_0 = c.Tube_1_0,
                                                   Tube_0_1 = c.Tube_0_1,
                                                   ProcessedBy = c.ProcessedBy,
                                                   UseForOpenData = c.UseForOpenData,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                               }).FirstOrDefault<MWQMSampleModel>();


            if (mwqmSampleModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSample, ServiceRes.MWQMSampleID, MWQMSampleID));

            mwqmSampleModel.SampleTypeList = mwqmSampleModel.SampleTypesText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((SampleTypeEnum)(int.Parse(c)))).ToList<SampleTypeEnum>();

            return mwqmSampleModel;
        }
        public MWQMSampleModel GetMWQMSampleModelExistDB(MWQMSampleModel mwqmSampleModel)
        {
            MWQMSampleModel mwqmSampleModelRet = (from c in db.MWQMSamples
                                                  let siteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                  let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                                  let mwqmSampleNote = (from cl in db.MWQMSampleLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSampleID == c.MWQMSampleID select cl.MWQMSampleNote).FirstOrDefault<string>()
                                                  where c.MWQMSiteTVItemID == mwqmSampleModel.MWQMSiteTVItemID
                                                  && c.MWQMRunTVItemID == mwqmSampleModel.MWQMRunTVItemID
                                                  && c.SampleDateTime_Local == mwqmSampleModel.SampleDateTime_Local
                                                  && c.FecCol_MPN_100ml == mwqmSampleModel.FecCol_MPN_100ml
                                                  && c.Salinity_PPT == mwqmSampleModel.Salinity_PPT
                                                  && c.WaterTemp_C == mwqmSampleModel.WaterTemp_C
                                                  && c.SampleTypesText.Contains(mwqmSampleModel.SampleTypesText)
                                                  select new MWQMSampleModel
                                                  {
                                                      Error = "",
                                                      MWQMSampleID = c.MWQMSampleID,
                                                      MWQMSampleNote = mwqmSampleNote,
                                                      MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                      MWQMSiteTVText = siteName,
                                                      MWQMRunTVItemID = c.MWQMRunTVItemID,
                                                      MWQMRunTVText = mwqmRunTVText,
                                                      Depth_m = c.Depth_m,
                                                      FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                                                      PH = c.PH,
                                                      Salinity_PPT = c.Salinity_PPT,
                                                      SampleDateTime_Local = c.SampleDateTime_Local,
                                                      WaterTemp_C = c.WaterTemp_C,
                                                      SampleTypesText = c.SampleTypesText,
                                                      Tube_10 = c.Tube_10,
                                                      Tube_1_0 = c.Tube_1_0,
                                                      Tube_0_1 = c.Tube_0_1,
                                                      ProcessedBy = c.ProcessedBy,
                                                      UseForOpenData = c.UseForOpenData,
                                                      LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                      LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                  }).FirstOrDefault<MWQMSampleModel>();

            if (mwqmSampleModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSample,
                    ServiceRes.MWQMSiteTVItemID + "," +
                    ServiceRes.MWQMRunTVItemID + "," +
                    ServiceRes.SampleDateTime_Local + "," +
                    ServiceRes.Depth_m + "," +
                    ServiceRes.FecCol_MPN_100ml + "," +
                    ServiceRes.Salinity_PPT + "," +
                    ServiceRes.WaterTemp_C + "," +
                    ServiceRes.PH,
                    mwqmSampleModel.MWQMSiteTVItemID + "," +
                    mwqmSampleModel.MWQMRunTVItemID + "," +
                    mwqmSampleModel.SampleDateTime_Local + "," +
                    mwqmSampleModel.Depth_m + "," +
                    mwqmSampleModel.FecCol_MPN_100ml + "," +
                    mwqmSampleModel.Salinity_PPT + "," +
                    mwqmSampleModel.WaterTemp_C + "," +
                    mwqmSampleModel.PH));

            mwqmSampleModel.SampleTypeList = mwqmSampleModel.SampleTypesText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((SampleTypeEnum)(int.Parse(c)))).ToList<SampleTypeEnum>();

            return mwqmSampleModelRet;
        }
        public List<MWQMSampleModel> GetMWQMSampleModelListWithMWQMSiteTVItemIDAndSampleTypeTextAndSampleDateTimeDB(int MWQMSiteTVItemID, SampleTypeEnum SampleType, DateTime SampleDateTime_Local)
        {
            List<MWQMSampleModel> mwqmSampleModelList = (from c in db.MWQMSamples
                                                         let siteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let mwqmRunTVText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMRunTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         let mwqmSampleNote = (from cl in db.MWQMSampleLanguages where cl.Language == (int)LanguageRequest && cl.MWQMSampleID == c.MWQMSampleID select cl.MWQMSampleNote).FirstOrDefault<string>()
                                                         where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                                         && c.SampleTypesText.Contains(((int)SampleType).ToString() + ",")
                                                         && c.SampleDateTime_Local == SampleDateTime_Local
                                                         select new MWQMSampleModel
                                                         {
                                                             Error = "",
                                                             MWQMSampleID = c.MWQMSampleID,
                                                             MWQMSampleNote = mwqmSampleNote,
                                                             MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                                             MWQMSiteTVText = siteName,
                                                             MWQMRunTVItemID = c.MWQMRunTVItemID,
                                                             MWQMRunTVText = mwqmRunTVText,
                                                             Depth_m = c.Depth_m,
                                                             FecCol_MPN_100ml = c.FecCol_MPN_100ml,
                                                             PH = c.PH,
                                                             Salinity_PPT = c.Salinity_PPT,
                                                             SampleDateTime_Local = c.SampleDateTime_Local,
                                                             WaterTemp_C = c.WaterTemp_C,
                                                             SampleTypesText = c.SampleTypesText,
                                                             Tube_10 = c.Tube_10,
                                                             Tube_1_0 = c.Tube_1_0,
                                                             Tube_0_1 = c.Tube_0_1,
                                                             ProcessedBy = c.ProcessedBy,
                                                             UseForOpenData = c.UseForOpenData,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).ToList<MWQMSampleModel>();

            foreach (MWQMSampleModel mwqmSampleModel in mwqmSampleModelList)
            {
                mwqmSampleModel.SampleTypeList = mwqmSampleModel.SampleTypesText.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((SampleTypeEnum)(int.Parse(c)))).ToList<SampleTypeEnum>();
            }

            return mwqmSampleModelList;
        }
        public MWQMSample GetMWQMSampleWithMWQMSampleIDDB(int MWQMSampleID)
        {
            MWQMSample mwqmSample = (from c in db.MWQMSamples
                                     where c.MWQMSampleID == MWQMSampleID
                                     select c).FirstOrDefault<MWQMSample>();

            return mwqmSample;
        }
        public List<SubsectorMWQMSampleYear> GetMWQMSampleYearWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            List<SubsectorMWQMSampleYear> subsectorClimateSiteList = new List<SubsectorMWQMSampleYear>();

            List<DateTime> DateWhereSampleExist = (from t in db.TVItems
                                                   from s in db.MWQMSites
                                                   from msa in db.MWQMSamples
                                                   where t.TVItemID == s.MWQMSiteTVItemID
                                                   && s.MWQMSiteTVItemID == msa.MWQMSiteTVItemID
                                                   && t.ParentID == SubsectorTVItemID
                                                   select msa.SampleDateTime_Local).ToList();

            List<int> YearList = (from c in DateWhereSampleExist
                                  select c.Year).Distinct().ToList();

            foreach (int Year in YearList)
            {
                DateTime EarliestDate = (from d in DateWhereSampleExist
                                         where d.Year == Year
                                         select d).FirstOrDefault();

                DateTime LatestDate = (from d in DateWhereSampleExist
                                       where d.Year == Year
                                       select d).LastOrDefault();

                SubsectorMWQMSampleYear subsectorClimateSite = new SubsectorMWQMSampleYear()
                {
                    SubsectorTVItemID = SubsectorTVItemID,
                    Year = Year,
                    EarliestDate = EarliestDate,
                    LatestDate = LatestDate,
                };

                subsectorClimateSiteList.Add(subsectorClimateSite);

            }

            return subsectorClimateSiteList;
        }

        // Helper
        public MWQMSampleModel ReturnError(string Error)
        {
            return new MWQMSampleModel() { Error = Error };
        }

        // Post
        public MWQMSampleModel MWQMSampleAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            int MWQMSampleID = 0;
            int MWQMRunTVItemID = 0;
            int MWQMSiteTVItemID = 0;
            string SampleTime = "";
            int Hour = 0;
            int Minute = 0;
            int FecCol_MPN_100ml = -1;
            float? Salinity_PPT = 0.0f;
            float? WaterTemp_C = 0.0f;
            float? Depth_m = 0.0f;
            float? PH = 0.0f;
            string ProcessedBy = "";
            bool UseForOpenData = false;
            List<SampleTypeEnum> SampleTypeList = new List<SampleTypeEnum>() { SampleTypeEnum.Error };
            string MWQMSampleNote = "";

            // MWQMSampleID
            if (string.IsNullOrWhiteSpace(fc["MWQMSampleID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSampleID));

            int.TryParse(fc["MWQMSampleID"], out MWQMSampleID);
            if (MWQMSampleID == 0)
            {
                // could be 0 if adding new
            }

            MWQMSampleModel mwqmSampleModelToChange = new MWQMSampleModel();
            if (MWQMSampleID > 0)
            {
                mwqmSampleModelToChange = GetMWQMSampleModelWithMWQMSampleIDDB(MWQMSampleID);
                if (!string.IsNullOrWhiteSpace(mwqmSampleModelToChange.Error))
                    return ReturnError(mwqmSampleModelToChange.Error);
            }

            // MWQMRunTVItemID
            if (string.IsNullOrWhiteSpace(fc["MWQMRunTVItemID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID));

            int.TryParse(fc["MWQMRunTVItemID"], out MWQMRunTVItemID);

            if (MWQMRunTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMRunTVItemID));

            MWQMRunModel mwqmRunModel = _MWQMRunService.GetMWQMRunModelWithMWQMRunTVItemIDDB(MWQMRunTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqmRunModel.Error))
                return ReturnError(mwqmRunModel.Error);

            mwqmSampleModelToChange.MWQMRunTVItemID = MWQMRunTVItemID;

            // MWQMSiteTVItemID
            if (string.IsNullOrWhiteSpace(fc["MWQMSiteTVItemID"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID));

            int.TryParse(fc["MWQMSiteTVItemID"], out MWQMSiteTVItemID);

            if (MWQMSiteTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVItemID));

            TVItemModel tvItemModelMWQMSite = _TVItemService.GetTVItemModelWithTVItemIDDB(MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMWQMSite.Error))
                return ReturnError(tvItemModelMWQMSite.Error);

            if (MWQMSampleID > 0) // modify
            {
                if (mwqmSampleModelToChange.MWQMSiteTVItemID != MWQMSiteTVItemID)
                    return ReturnError(string.Format(ServiceRes._NotEqual, mwqmSampleModelToChange.MWQMSiteTVItemID + ", " + MWQMSiteTVItemID));
            }

            mwqmSampleModelToChange.MWQMSiteTVItemID = MWQMSiteTVItemID;

            // SampleTime
            SampleTime = fc["SampleTime"];
            if (string.IsNullOrWhiteSpace(SampleTime))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SampleTime));
            }
            else
            {
                if (SampleTime.Length != 5)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, SampleTime));

                if (SampleTime.Substring(2, 1) != ":")
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, SampleTime));

                try
                {
                    Hour = int.Parse(SampleTime.Substring(0, 2));
                    Minute = int.Parse(SampleTime.Substring(3, 2));
                }
                catch (Exception)
                {
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, SampleTime));
                }


                if (Hour < 0 || Hour > 23)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, SampleTime));

                if (Minute < 0 || Minute > 59)
                    return ReturnError(string.Format(ServiceRes.Time_NotWellFormed, SampleTime));

                DateTime SampleDate = new DateTime(mwqmRunModel.DateTime_Local.Year, mwqmRunModel.DateTime_Local.Month, mwqmRunModel.DateTime_Local.Day, Hour, Minute, 0);

                mwqmSampleModelToChange.SampleDateTime_Local = SampleDate;
            }

            // FecCol_MPN_100ml
            if (string.IsNullOrWhiteSpace(fc["FecCol_MPN_100ml"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.FecCol_MPN_100ml));

            int.TryParse(fc["FecCol_MPN_100ml"], out FecCol_MPN_100ml);

            if (FecCol_MPN_100ml < 0)
                return ReturnError(string.Format(ServiceRes._OnlyAllowsPositiveValues, ServiceRes.FecCol_MPN_100ml));

            mwqmSampleModelToChange.FecCol_MPN_100ml = FecCol_MPN_100ml;

            // WaterTemp_C
            if (string.IsNullOrWhiteSpace(fc["WaterTemp_C"]))
            {
                WaterTemp_C = null;
            }
            else
            {
                WaterTemp_C = float.Parse(fc["WaterTemp_C"]);
                if (WaterTemp_C < -15.0f || WaterTemp_C > 40.0f)
                    return ReturnError(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.WaterTemp_C, -15, 40));
            }

            mwqmSampleModelToChange.WaterTemp_C = WaterTemp_C;

            // Salinity_PPT
            if (string.IsNullOrWhiteSpace(fc["Salinity_PPT"]))
            {
                Salinity_PPT = null;
            }
            else
            {
                Salinity_PPT = float.Parse(fc["Salinity_PPT"]);
                if (Salinity_PPT < 0 || Salinity_PPT > 40)
                    return ReturnError(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Salinity_PPT, 0, 40));
            }

            mwqmSampleModelToChange.Salinity_PPT = Salinity_PPT;

            // Depth_m
            if (string.IsNullOrWhiteSpace(fc["Depth_m"]))
            {
                Depth_m = null;
            }
            else
            {
                Depth_m = float.Parse(fc["Depth_m"]);
                if (Depth_m < 0 || Depth_m > 10000)
                    return ReturnError(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.Depth_m, 0, 10000));
            }

            mwqmSampleModelToChange.Depth_m = Depth_m;

            // PH
            if (string.IsNullOrWhiteSpace(fc["PH"]))
            {
                PH = null;
            }
            else
            {
                PH = float.Parse(fc["PH"]);
                if (PH < 0)
                    return ReturnError(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.PH, 0, 14));
            }

            mwqmSampleModelToChange.PH = PH;

            // ProcessBy
            ProcessedBy = fc["ProcessedBy"];

            if (ProcessedBy == null)
            {
                mwqmSampleModelToChange.ProcessedBy = null;
            }
            else
            {
                if (ProcessedBy.Length > 10)
                    return ReturnError(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ProcessedBy, 10));

                mwqmSampleModelToChange.ProcessedBy = ProcessedBy.ToUpper();
            }

            if (!string.IsNullOrWhiteSpace(fc["UseForOpenData"]))
            {
                if (bool.Parse(fc["UseForOpenData"]))
                {
                    UseForOpenData = true;
                }
            }

            mwqmSampleModelToChange.UseForOpenData = UseForOpenData;

            // SampleTypesText
            if (string.IsNullOrWhiteSpace(fc["SampleTypes[]"]))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SampleTypes));

            SampleTypeList = fc["SampleTypes[]"].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => ((SampleTypeEnum)(int.Parse(c)))).ToList<SampleTypeEnum>();

            mwqmSampleModelToChange.SampleTypesText = "";
            foreach (SampleTypeEnum sampleType in SampleTypeList)
            {
                string retStr = _BaseEnumService.SampleTypeOK(sampleType);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                mwqmSampleModelToChange.SampleTypesText += ((int)sampleType).ToString() + ",";
            }

            // MWQMSampleNote
            MWQMSampleNote = fc["MWQMSampleNote"];

            if (string.IsNullOrWhiteSpace(MWQMSampleNote))
            {
                mwqmSampleModelToChange.MWQMSampleNote = null;
            }
            else
            {
                if (MWQMSampleNote.Length > 250)
                    return ReturnError(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Comment, 250));

                mwqmSampleModelToChange.MWQMSampleNote = MWQMSampleNote;
            }

            MWQMSampleModel mwqmSampleModelRet = new MWQMSampleModel();
            if (MWQMSampleID > 0)
            {
                mwqmSampleModelRet = PostUpdateMWQMSampleDB(mwqmSampleModelToChange);
                if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet.Error))
                    return ReturnError(mwqmSampleModelRet.Error);
            }
            else
            {
                mwqmSampleModelRet = PostAddMWQMSampleDB(mwqmSampleModelToChange);
                if (!string.IsNullOrWhiteSpace(mwqmSampleModelRet.Error))
                    return ReturnError(mwqmSampleModelRet.Error);
            }

            return mwqmSampleModelRet;
        }
        public MWQMSampleModel PostAddMWQMSampleDB(MWQMSampleModel mwqmSampleModel)
        {
            string retStr = MWQMSampleModelOK(mwqmSampleModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSampleModel mwqmSampleModelExist = GetMWQMSampleModelExistDB(mwqmSampleModel);
            if (string.IsNullOrWhiteSpace(mwqmSampleModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.MWQMSample));

            MWQMSample mwqmSampleNew = new MWQMSample();
            retStr = FillMWQMSample(mwqmSampleNew, mwqmSampleModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSamples.Add(mwqmSampleNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSamples", mwqmSampleNew.MWQMSampleID, LogCommandEnum.Add, mwqmSampleNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    MWQMSampleLanguageModel mwqmSampleLanguageModel = new MWQMSampleLanguageModel()
                    {
                        MWQMSampleID = mwqmSampleNew.MWQMSampleID,
                        Language = Lang,
                        MWQMSampleNote = mwqmSampleModel.MWQMSampleNote,
                        TranslationStatus = (Lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                    };

                    if (mwqmSampleLanguageModel.MWQMSampleNote == null)
                    {
                        mwqmSampleLanguageModel.MWQMSampleNote = ServiceRes.Empty;
                    }

                    MWQMSampleLanguageModel mwqmSampleLanguageModelRet = _MWQMSampleLanguageService.PostAddMWQMSampleLanguageDB(mwqmSampleLanguageModel);
                    if (!string.IsNullOrEmpty(mwqmSampleLanguageModelRet.Error))
                        return ReturnError(mwqmSampleLanguageModelRet.Error);
                }

                ts.Complete();
            }
            return GetMWQMSampleModelWithMWQMSampleIDDB(mwqmSampleNew.MWQMSampleID);
        }
        public MWQMSampleModel PostDeleteMWQMSampleDB(int MWQMSampleID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSample mwqmSampleToDelete = GetMWQMSampleWithMWQMSampleIDDB(MWQMSampleID);
            if (mwqmSampleToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSample));

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSamples.Remove(mwqmSampleToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSamples", mwqmSampleToDelete.MWQMSampleID, LogCommandEnum.Delete, mwqmSampleToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public MWQMSampleModel PostUpdateMWQMSampleDB(MWQMSampleModel mwqmSampleModel)
        {
            string retStr = MWQMSampleModelOK(mwqmSampleModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSample mwqmSampleToUpdate = GetMWQMSampleWithMWQMSampleIDDB(mwqmSampleModel.MWQMSampleID);
            if (mwqmSampleToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSample));

            retStr = FillMWQMSample(mwqmSampleToUpdate, mwqmSampleModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSamples", mwqmSampleToUpdate.MWQMSampleID, LogCommandEnum.Change, mwqmSampleToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        MWQMSampleLanguageModel mwqmSampleLanguageModel = new MWQMSampleLanguageModel()
                        {
                            MWQMSampleID = mwqmSampleModel.MWQMSampleID,
                            Language = Lang,
                            MWQMSampleNote = mwqmSampleModel.MWQMSampleNote ?? "",
                            TranslationStatus = TranslationStatusEnum.Translated,
                        };

                        if (!string.IsNullOrWhiteSpace(mwqmSampleModel.MWQMSampleNote))
                        {
                            mwqmSampleModel.MWQMSampleNote = ServiceRes.Empty;
                        }

                        MWQMSampleLanguageModel mwqmSampleLanguageModelRet = _MWQMSampleLanguageService.PostUpdateMWQMSampleLanguageDB(mwqmSampleLanguageModel);
                        if (!string.IsNullOrEmpty(mwqmSampleLanguageModelRet.Error))
                            return ReturnError(mwqmSampleLanguageModelRet.Error);
                    }
                }

                ts.Complete();
            }
            return GetMWQMSampleModelWithMWQMSampleIDDB(mwqmSampleToUpdate.MWQMSampleID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}