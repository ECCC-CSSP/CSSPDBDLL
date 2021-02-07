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
    public class MWQMSiteService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }
        public MWQMSiteStartEndDateService _MWQMSiteStartEndDateService { get; private set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _MWQMSiteStartEndDateService = new MWQMSiteStartEndDateService(LanguageRequest, User);
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
        public string MWQMSiteModelOK(MWQMSiteModel mwqmSiteModel)
        {
            string retStr = FieldCheckNotZeroInt(mwqmSiteModel.MWQMSiteTVItemID, ServiceRes.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mwqmSiteModel.MWQMSiteTVText, ServiceRes.MWQMSiteTVText, 1, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndMinMaxLengthString(mwqmSiteModel.MWQMSiteNumber, ServiceRes.MWQMSiteNumber, 1, 8);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(mwqmSiteModel.MWQMSiteDescription, ServiceRes.MWQMSiteDescription, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.MWQMSiteLatestClassificationOK(mwqmSiteModel.MWQMSiteLatestClassification);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }


            retStr = FieldCheckNotNullAndWithinRangeInt(mwqmSiteModel.Ordinal, ServiceRes.Ordinal, 0, 1000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(mwqmSiteModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillMWQMSite(MWQMSite mwqmSite, MWQMSiteModel mwqmSiteModel, ContactOK contactOK)
        {
            mwqmSite.DBCommand = (int)mwqmSiteModel.DBCommand;
            mwqmSite.MWQMSiteTVItemID = mwqmSiteModel.MWQMSiteTVItemID;
            mwqmSite.MWQMSiteNumber = mwqmSiteModel.MWQMSiteNumber;
            mwqmSite.MWQMSiteDescription = mwqmSiteModel.MWQMSiteDescription;
            mwqmSite.MWQMSiteLatestClassification = (int)mwqmSiteModel.MWQMSiteLatestClassification;
            mwqmSite.Ordinal = mwqmSiteModel.Ordinal;
            mwqmSite.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                mwqmSite.LastUpdateContactTVItemID = 2;
            }
            else
            {
                mwqmSite.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public void GetMWQMSiteMapInfoStatDB(int TVItemID, TVLocation tvlNew, int NumberOfSamples)
        {
            string routineNumberText = ((int)SampleTypeEnum.Routine).ToString() + ",";
            List<MWQMSample> mwqmSampleList = (from w in db.MWQMSites
                                               from s in db.MWQMSamples
                                               where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                               && w.MWQMSiteTVItemID == TVItemID
                                               && s.SampleTypesText.Contains(routineNumberText)
                                               orderby s.SampleDateTime_Local descending
                                               select s).Take(NumberOfSamples).ToList<MWQMSample>();

            int SampCount = mwqmSampleList.Count();
            int MinFC = 0;
            int MaxFC = 0;
            if (SampCount > 0)
            {
                MinFC = (int)mwqmSampleList.Min(c => c.FecCol_MPN_100ml);
                MaxFC = (int)mwqmSampleList.Max(c => c.FecCol_MPN_100ml);

                if (mwqmSampleList.Count >= 4)
                {
                    CalculateMWQMSiteStat(mwqmSampleList, tvlNew, MinFC, MaxFC, SampCount);
                }
                else
                {
                    tvlNew.SubTVType = TVTypeEnum.LessThan10;
                    tvlNew.TVText = SampCount.ToString() + " - " + tvlNew.TVText;
                    tvlNew.TVText += " - " + ServiceRes.LessThan10Samples + " - " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) + "]";
                }
            }
            else
            {
                tvlNew.SubTVType = TVTypeEnum.NoData;
                tvlNew.TVText = SampCount.ToString() + " - " + tvlNew.TVText;
                tvlNew.TVText += " - " + ServiceRes.NoData;
            }
        }
        public void GetMWQMSiteMapInfoStatOneDayDB(int TVItemID, TVLocation tvlNew, DateTime SampleDate)
        {
            string routineNumberText = ((int)SampleTypeEnum.Routine).ToString() + ",";
            List<MWQMSample> mwqmSampleList = (from w in db.MWQMSites
                                               from s in db.MWQMSamples
                                               where w.MWQMSiteTVItemID == s.MWQMSiteTVItemID
                                               && w.MWQMSiteTVItemID == TVItemID
                                               && (s.SampleDateTime_Local.Year == SampleDate.Year
                                               && s.SampleDateTime_Local.Month == SampleDate.Month
                                               && s.SampleDateTime_Local.Day == SampleDate.Day)
                                               && s.SampleTypesText.Contains(routineNumberText)
                                               orderby s.SampleDateTime_Local descending
                                               select s).ToList<MWQMSample>();

            if (mwqmSampleList.Count >= 1)
            {
                CalculateMWQMSiteStatOneDay(mwqmSampleList, tvlNew);
            }
            else
            {
                tvlNew.SubTVType = TVTypeEnum.NoData;
                tvlNew.TVText += " - " + ServiceRes.NoData;
            }
        }
        public int GetMWQMSiteModelCountDB()
        {
            int MWQMSiteModelCount = (from c in db.MWQMSites
                                      select c).Count();

            return MWQMSiteModelCount;
        }
        public MWQMSiteModel GetMWQMSiteModelWithMWQMSiteIDDB(int MWQMSiteID)
        {
            MWQMSiteModel MWQMSiteModel = (from c in db.MWQMSites
                                           let mwqmSiteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                           where c.MWQMSiteID == MWQMSiteID
                                           select new MWQMSiteModel
                                           {
                                               Error = "",
                                               MWQMSiteID = c.MWQMSiteID,
                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                               MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                               MWQMSiteTVText = mwqmSiteName,
                                               MWQMSiteNumber = c.MWQMSiteNumber,
                                               MWQMSiteDescription = c.MWQMSiteDescription,
                                               MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)c.MWQMSiteLatestClassification,
                                               Ordinal = c.Ordinal,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<MWQMSiteModel>();

            if (MWQMSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSite, ServiceRes.MWQMSiteID, MWQMSiteID));

            return MWQMSiteModel;
        }
        public MWQMSiteModel GetMWQMSiteModelWithMWQMSiteTVItemIDDB(int MWQMSiteTVItemID)
        {
            MWQMSiteModel MWQMSiteModel = (from c in db.MWQMSites
                                           let mwqmSiteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                                           where c.MWQMSiteTVItemID == MWQMSiteTVItemID
                                           select new MWQMSiteModel
                                           {
                                               Error = "",
                                               MWQMSiteID = c.MWQMSiteID,
                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                               MWQMSiteTVItemID = c.MWQMSiteTVItemID,
                                               MWQMSiteTVText = mwqmSiteName,
                                               MWQMSiteNumber = c.MWQMSiteNumber,
                                               MWQMSiteDescription = c.MWQMSiteDescription,
                                               MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)c.MWQMSiteLatestClassification,
                                               Ordinal = c.Ordinal,
                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                           }).FirstOrDefault<MWQMSiteModel>();

            if (MWQMSiteModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.MWQMSite, ServiceRes.MWQMSiteTVItemID, MWQMSiteTVItemID));

            return MWQMSiteModel;
        }
        public List<MWQMSiteModel> GetMWQMSiteModelListWithSubsectorTVItemIDDB(int SubsectorTVItemID)
        {
            return (from t in db.TVItems
                    from s in db.MWQMSites
                    let mwqmSiteName = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == s.MWQMSiteTVItemID select cl.TVText).FirstOrDefault<string>()
                    where t.TVItemID == s.MWQMSiteTVItemID
                    && t.ParentID == SubsectorTVItemID
                    select new MWQMSiteModel
                    {
                        Error = "",
                        MWQMSiteID = s.MWQMSiteID,
                        DBCommand = (DBCommandEnum)s.DBCommand,
                        MWQMSiteTVItemID = s.MWQMSiteTVItemID,
                        MWQMSiteTVText = mwqmSiteName,
                        MWQMSiteNumber = s.MWQMSiteNumber,
                        MWQMSiteDescription = s.MWQMSiteDescription,
                        MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)s.MWQMSiteLatestClassification,
                        Ordinal = s.Ordinal,
                        LastUpdateDate_UTC = s.LastUpdateDate_UTC,
                        LastUpdateContactTVItemID = s.LastUpdateContactTVItemID,
                    }).ToList();
        }
        public List<DateTime> GetMWQMSiteRunWithTVItemIDSubsectorDB(int SubsectorTVItemID)
        {
            if (SubsectorTVItemID == 0)
                return new List<DateTime>();

            List<DateTime> mwqmSiteRunDateList = new List<DateTime>();

            var mwqmSiteRunYearMonthDayList = (from c in db.TVItems
                                               from s in db.MWQMSamples
                                               where c.TVItemID == s.MWQMSiteTVItemID
                                               && c.ParentID == SubsectorTVItemID
                                               select new
                                               {
                                                   Year = s.SampleDateTime_Local.Year,
                                                   Month = s.SampleDateTime_Local.Month,
                                                   Day = s.SampleDateTime_Local.Day,
                                               }).Distinct().ToList();

            foreach (var mwqmYMDAndCount in mwqmSiteRunYearMonthDayList)
            {
                mwqmSiteRunDateList.Add(new DateTime(mwqmYMDAndCount.Year, mwqmYMDAndCount.Month, mwqmYMDAndCount.Day));
            }

            return mwqmSiteRunDateList.OrderByDescending(c => c).ToList();
        }
        public List<MWQMSiteSampleFCModel> GetMWQMSiteSamplesWithMovingAverageDB(int MWQMSiteTVItemID, int MovingAverage, int MinNumberForAverage)
        {
            if (MWQMSiteTVItemID == 0)
                return new List<MWQMSiteSampleFCModel>();

            return CalculateMWQMSiteStatMovingAverage(MWQMSiteTVItemID, MovingAverage, MinNumberForAverage);
        }
        public MWQMSite GetMWQMSiteWithMWQMSiteIDDB(int MWQMSiteID)
        {
            MWQMSite MWQMSite = (from c in db.MWQMSites
                                 where c.MWQMSiteID == MWQMSiteID
                                 select c).FirstOrDefault<MWQMSite>();

            return MWQMSite;
        }

        // Helper
        public void CalculateMWQMSiteStat(List<MWQMSample> mwqmSampleList, TVLocation tvlNew, int MinFC, int MaxFC, int SampCount)
        {
            List<double> GeoMeanList = (from c in mwqmSampleList
                                        orderby c.FecCol_MPN_100ml
                                        select (c.FecCol_MPN_100ml < 2 ? 1.9D : (double)c.FecCol_MPN_100ml)).ToList<double>();

            double P90 = (float)_TVItemService.GetP90(GeoMeanList);
            double GeoMean = (float)_TVItemService.GeometricMean(GeoMeanList);
            double Median = (float)_TVItemService.GetMedian(GeoMeanList);
            double PercOver43 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 43).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
            double PercOver260 = (float)((((double)mwqmSampleList.Where(c => c.FecCol_MPN_100ml > 260).Count()) / (double)mwqmSampleList.Count()) * 100.0D);
            int MinYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Min().Year;
            int MaxYear = mwqmSampleList.Select(c => c.SampleDateTime_Local).Max().Year;

            CalculateMWQMSiteStatLetterAndSubTVType(tvlNew, P90, GeoMean, Median, PercOver43, PercOver260);

            tvlNew.TVText += " - " + ServiceRes.GM + ": [" + (GeoMean < 2.0D ? "<2" : string.Format("{0:F2}", GeoMean)) +
                "] " + ServiceRes.Med + ": [" + (Median < 2.0D ? "<2" :string.Format("{0:F2}", Median)) +
                "] " + ServiceRes.P90 + ": [" + string.Format("{0:F2}", P90) +
                "] >43: [" + string.Format("{0:F2}%", PercOver43) +
                "] >260: [" + string.Format("{0:F2}%", PercOver260) +
                "] " + ServiceRes.Min + ": [" + (MinFC < 2.0D ? "<2" : string.Format("{0:F0}", MinFC)) +
                "] " + ServiceRes.Max + ": [" + (MaxFC < 2.0D ? "<2" : string.Format("{0:F0}", MaxFC)) +
                "] " + ServiceRes.NumberOfSamples + ": [" + string.Format("{0:F0}", SampCount) +
                "] " + ServiceRes.StatPeriod + ": [" + string.Format("{0} - {1}", MinYear, MaxYear) + "]";

        }
        public void CalculateMWQMSiteStatLetterAndSubTVType(TVLocation tvlNew, double P90, double GeoMean, double Median, double PercOver43, double PercOver260)
        {
            int P90Int = (int)Math.Round((double)P90, 0);
            int GeoMeanInt = (int)Math.Round((double)GeoMean, 0);
            int MedianInt = (int)Math.Round((double)Median, 0);
            int PercOver43Int = (int)Math.Round((double)PercOver43, 0);
            int PercOver260Int = (int)Math.Round((double)PercOver260, 0);

            if ((GeoMeanInt > 88) || (MedianInt > 88) || (P90Int > 260) || (PercOver260Int > 10))
            {
                tvlNew.SubTVType = TVTypeEnum.NoDepuration;
                if ((GeoMeanInt > 181) || (MedianInt > 181) || (P90Int > 460) || (PercOver260Int > 18))
                {
                    tvlNew.TVText = "F - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 163) || (MedianInt > 163) || (P90Int > 420) || (PercOver260Int > 17))
                {
                    tvlNew.TVText = "E - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 144) || (MedianInt > 144) || (P90Int > 380) || (PercOver260Int > 15))
                {
                    tvlNew.TVText = "D - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 125) || (MedianInt > 125) || (P90Int > 340) || (PercOver260Int > 13))
                {
                    tvlNew.TVText = "C - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 107) || (MedianInt > 107) || (P90Int > 300) || (PercOver260Int > 12))
                {
                    tvlNew.TVText = "B - " + tvlNew.TVText;
                }
                else
                {
                    tvlNew.TVText = "A - " + tvlNew.TVText;
                }
            }
            else if ((GeoMeanInt > 14) || (MedianInt > 14) || (P90Int > 43) || (PercOver43Int > 10))
            {
                tvlNew.SubTVType = TVTypeEnum.Failed;
                if ((GeoMeanInt > 76) || (MedianInt > 76) || (P90Int > 224) || (PercOver43Int > 27))
                {
                    tvlNew.TVText = "F - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 63) || (MedianInt > 63) || (P90Int > 188) || (PercOver43Int > 23))
                {
                    tvlNew.TVText = "E - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 51) || (MedianInt > 51) || (P90Int > 152) || (PercOver43Int > 20))
                {
                    tvlNew.TVText = "D - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 39) || (MedianInt > 39) || (P90Int > 115) || (PercOver43Int > 17))
                {
                    tvlNew.TVText = "C - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 26) || (MedianInt > 26) || (P90Int > 79) || (PercOver43Int > 13))
                {
                    tvlNew.TVText = "B - " + tvlNew.TVText;
                }
                else
                {
                    tvlNew.TVText = "A - " + tvlNew.TVText;
                }
            }
            else
            {
                tvlNew.SubTVType = TVTypeEnum.Passed;
                if ((GeoMeanInt > 12) || (MedianInt > 12) || (P90Int > 36) || (PercOver43Int > 8))
                {
                    tvlNew.TVText = "F - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 9) || (MedianInt > 9) || (P90Int > 29) || (PercOver43Int > 7))
                {
                    tvlNew.TVText = "E - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 7) || (MedianInt > 7) || (P90Int > 22) || (PercOver43Int > 5))
                {
                    tvlNew.TVText = "D - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 5) || (MedianInt > 5) || (P90Int > 14) || (PercOver43Int > 3))
                {
                    tvlNew.TVText = "C - " + tvlNew.TVText;
                }
                else if ((GeoMeanInt > 2) || (MedianInt > 2) || (P90Int > 7) || (PercOver43Int > 2))
                {
                    tvlNew.TVText = "B - " + tvlNew.TVText;
                }
                else
                {
                    tvlNew.TVText = "A - " + tvlNew.TVText;
                }
            }
        }
        public List<MWQMSiteSampleFCModel> CalculateMWQMSiteStatMovingAverage(int MWQMSiteTVItemID, int MovingAverage, int MinNumberForAverage)
        {
            string SampleTypeText = ((int)SampleTypeEnum.Routine).ToString() + ",";
            List<MWQMSiteSampleFCModel> mwqmSampleFCList = (from s in db.TVItems
                                                            from sa in db.MWQMSamples
                                                            where s.TVItemID == sa.MWQMSiteTVItemID
                                                            && s.TVItemID == MWQMSiteTVItemID
                                                            && sa.SampleTypesText.Contains(SampleTypeText)
                                                            orderby sa.SampleDateTime_Local
                                                            select new MWQMSiteSampleFCModel
                                                            {
                                                                SampleDate = (DateTime)sa.SampleDateTime_Local,
                                                                FC = (int)sa.FecCol_MPN_100ml,
                                                                Sal = (float)sa.Salinity_PPT,
                                                                Temp = (float)sa.WaterTemp_C,
                                                                PH = (float)sa.PH,
                                                                Depth = (float)sa.Depth_m,
                                                            }).ToList();

            List<MWQMSiteSampleFCModel> SampleList = new List<MWQMSiteSampleFCModel>();

            foreach (MWQMSiteSampleFCModel csfc in mwqmSampleFCList)
            {
                SampleList.Add(csfc);

                csfc.SampCount = null;
                csfc.MinFC = null;
                csfc.MaxFC = null;
                csfc.GeoMean = null;
                csfc.Median = null;
                csfc.P90 = null;
                csfc.PercOver43 = null;
                csfc.PercOver260 = null;

                if (SampleList.Count > MovingAverage)
                {
                    SampleList.RemoveAt(0);
                }

                csfc.SampCount = SampleList.Count();
                if (csfc.SampCount > 0)
                {
                    csfc.MinFC = SampleList.Min(c => c.FC);
                    csfc.MaxFC = SampleList.Max(c => c.FC);
                }
                if (SampleList.Count >= MinNumberForAverage)
                {
                    List<double> GeoMeanList = (from c in SampleList
                                                orderby c.FC
                                                select (double)c.FC).ToList<double>();

                    csfc.P90 = (float)_TVItemService.GetP90(GeoMeanList);
                    csfc.GeoMean = (float)_TVItemService.GeometricMean(GeoMeanList);
                    csfc.Median = (float)_TVItemService.GetMedian(GeoMeanList);
                    csfc.PercOver43 = (float)((((double)SampleList.Where(c => c.FC > 43).Count()) / (double)SampleList.Count()) * 100.0D);
                    csfc.PercOver260 = (float)((((double)SampleList.Where(c => c.FC > 260).Count()) / (double)SampleList.Count()) * 100.0D);

                }
            }

            return mwqmSampleFCList;

        }
        public void CalculateMWQMSiteStatOneDay(List<MWQMSample> mwqmSampleList, TVLocation tvlNew)
        {
            double Mean = (from c in mwqmSampleList
                           orderby c.FecCol_MPN_100ml
                           select (double)c.FecCol_MPN_100ml).Average();

            CalculateMWQMSiteStatOneDayLetterAndSubTVType(tvlNew, Mean);


            tvlNew.TVText += " - (" + string.Format("{0:F0}", Mean) + ")";

        }
        public void CalculateMWQMSiteStatOneDayLetterAndSubTVType(TVLocation tvlNew, double Mean)
        {
            int MeanInt = (int)Math.Round((double)Mean, 0);

            if ((MeanInt > 88))
            {
                tvlNew.SubTVType = TVTypeEnum.NoDepuration;
                if (MeanInt > 181)
                {
                    tvlNew.TVText = "F - " + tvlNew.TVText;
                }
                else if (MeanInt > 163)
                {
                    tvlNew.TVText = "E - " + tvlNew.TVText;
                }
                else if (MeanInt > 144)
                {
                    tvlNew.TVText = "D - " + tvlNew.TVText;
                }
                else if (MeanInt > 125)
                {
                    tvlNew.TVText = "C - " + tvlNew.TVText;
                }
                else if (MeanInt > 107)
                {
                    tvlNew.TVText = "B - " + tvlNew.TVText;
                }
                else
                {
                    tvlNew.TVText = "A - " + tvlNew.TVText;
                }
            }
            else if (MeanInt > 14)
            {
                tvlNew.SubTVType = TVTypeEnum.Failed;
                if (MeanInt > 76)
                {
                    tvlNew.TVText = "F - " + tvlNew.TVText;
                }
                else if (MeanInt > 63)
                {
                    tvlNew.TVText = "E - " + tvlNew.TVText;
                }
                else if (MeanInt > 51)
                {
                    tvlNew.TVText = "D - " + tvlNew.TVText;
                }
                else if (MeanInt > 39)
                {
                    tvlNew.TVText = "C - " + tvlNew.TVText;
                }
                else if (MeanInt > 26)
                {
                    tvlNew.TVText = "B - " + tvlNew.TVText;
                }
                else
                {
                    tvlNew.TVText = "A - " + tvlNew.TVText;
                }
            }
            else
            {
                tvlNew.SubTVType = TVTypeEnum.Passed;
                if (MeanInt > 12)
                {
                    tvlNew.TVText = "F - " + tvlNew.TVText;
                }
                else if (MeanInt > 9)
                {
                    tvlNew.TVText = "E - " + tvlNew.TVText;
                }
                else if (MeanInt > 7)
                {
                    tvlNew.TVText = "D - " + tvlNew.TVText;
                }
                else if (MeanInt > 5)
                {
                    tvlNew.TVText = "C - " + tvlNew.TVText;
                }
                else if (MeanInt > 2)
                {
                    tvlNew.TVText = "B - " + tvlNew.TVText;
                }
                else
                {
                    tvlNew.TVText = "A - " + tvlNew.TVText;
                }
            }
        }
        public string CreateTVText(MWQMSiteModel mwqmSiteModel)
        {
            return mwqmSiteModel.MWQMSiteTVText;
        }
        public bool GetIsItSameObject(MWQMSiteModel mwqmSiteModel, TVItemModel tvItemModelMWQMSiteExit)
        {
            bool IsSame = false;
            if (mwqmSiteModel.MWQMSiteTVItemID == tvItemModelMWQMSiteExit.TVItemID)
            {
                IsSame = true;
            }

            return IsSame;
        }
        public MWQMSiteModel ReturnError(string Error)
        {
            return new MWQMSiteModel() { Error = Error };
        }

        // Post
        public MWQMSiteModel MWQMSiteSaveAllDB(FormCollection fc)
        {
            //int tempInt = 0;
            int SubsectorTVItemID = 0;
            int MWQMSiteTVItemID = 0;
            bool IsActive = true;
            string MWQMSiteTVText = "";
            string MWQMSiteNumber = "";
            string MWQMSiteDescription = "";
            double Lat = 0.0D;
            double Lng = 0.0D;
            int tempInt = 0;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int.TryParse(fc["SubsectorTVItemID"], out SubsectorTVItemID);
            if (SubsectorTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SubsectorTVItemID));

            TVItemModel tvItemModelSubsector = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSubsector.Error))
                return ReturnError(tvItemModelSubsector.Error);

            int.TryParse(fc["MWQMSiteTVItemID"], out MWQMSiteTVItemID);
            // could be 0 if 0 then we need to add the new MWQMSite 

            MWQMSiteModel mwqmSiteNewOrToChange = new MWQMSiteModel();

            if (fc["IsActive"] != null)
                IsActive = true;
            else
                IsActive = false;

            if (MWQMSiteTVItemID != 0)
            {
                mwqmSiteNewOrToChange = GetMWQMSiteModelWithMWQMSiteTVItemIDDB(MWQMSiteTVItemID);
                if (!string.IsNullOrWhiteSpace(mwqmSiteNewOrToChange.Error))
                    return ReturnError(mwqmSiteNewOrToChange.Error);
            }

            mwqmSiteNewOrToChange.DBCommand = DBCommandEnum.Original;

            MWQMSiteTVText = fc["MWQMSiteTVText"];
            if (string.IsNullOrWhiteSpace(MWQMSiteTVText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteTVText));

            if (MWQMSiteTVText.Contains("#"))
                return ReturnError(string.Format(ServiceRes.NameOfItemShouldNotContainThe_Character, "#"));

            mwqmSiteNewOrToChange.MWQMSiteTVText = MWQMSiteTVText;

            MWQMSiteNumber = fc["MWQMSiteNumber"];
            if (string.IsNullOrWhiteSpace(MWQMSiteNumber))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteNumber));

            mwqmSiteNewOrToChange.MWQMSiteNumber = MWQMSiteNumber;

            List<TVItemModel> tvItemModelMWQMSiteList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(SubsectorTVItemID, TVTypeEnum.MWQMSite);
            foreach (TVItemModel tvItemModelMWQMSite in tvItemModelMWQMSiteList)
            {
                if (tvItemModelMWQMSite.TVItemID != MWQMSiteTVItemID)
                {
                    MWQMSiteModel mwqmSiteModel = GetMWQMSiteModelWithMWQMSiteTVItemIDDB(tvItemModelMWQMSite.TVItemID);
                    if (!string.IsNullOrWhiteSpace(mwqmSiteModel.Error))
                        return ReturnError(mwqmSiteModel.Error);

                    if (mwqmSiteModel.MWQMSiteNumber == MWQMSiteNumber)
                    {
                        return ReturnError(string.Format(ServiceRes.MWQMSiteNumberHasToBeUniqueForSubsector));
                    }
                }
            }

            MWQMSiteDescription = fc["MWQMSiteDescription"];
            if (string.IsNullOrWhiteSpace(MWQMSiteDescription))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteDescription));

            mwqmSiteNewOrToChange.MWQMSiteDescription = MWQMSiteDescription;

            int.TryParse(fc["MWQMSiteLatestClassification"], out tempInt);
            if (tempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MWQMSiteLatestClassification));

            mwqmSiteNewOrToChange.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)tempInt;

            double.TryParse(fc["Lat"], out Lat);
            if (Lat == 0.0D)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lat));

            double.TryParse(fc["Lng"], out Lng);
            if (Lng == 0.0D)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Lng));

            List<Coord> coordList = new List<Coord>() { new Coord() { Lat = (float)Lat, Lng = (float)Lng, Ordinal = 0 } };

            MWQMSiteModel mwqmSiteModelRet = new MWQMSiteModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (MWQMSiteTVItemID == 0)
                {
                    TVItemModel tvItemModelNewMWQMSite = _TVItemService.PostAddChildTVItemDB(SubsectorTVItemID, MWQMSiteTVText, TVTypeEnum.MWQMSite);
                    if (!string.IsNullOrWhiteSpace(tvItemModelNewMWQMSite.Error))
                        return ReturnError(tvItemModelNewMWQMSite.Error);

                    mwqmSiteNewOrToChange.MWQMSiteTVItemID = tvItemModelNewMWQMSite.TVItemID;

                    mwqmSiteModelRet = PostAddMWQMSiteDB(mwqmSiteNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(mwqmSiteModelRet.Error))
                        return ReturnError(mwqmSiteModelRet.Error);
                }
                else
                {
                   mwqmSiteModelRet = PostUpdateMWQMSiteDB(mwqmSiteNewOrToChange);
                    if (!string.IsNullOrWhiteSpace(mwqmSiteModelRet.Error))
                        return ReturnError(mwqmSiteModelRet.Error);
                }


                List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(mwqmSiteModelRet.MWQMSiteTVItemID, TVTypeEnum.MWQMSite, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count == 0)
                {
                    MapInfoModel mapInfoModelRet = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.MWQMSite, mwqmSiteModelRet.MWQMSiteTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnError(mapInfoModelRet.Error);
                }
                else
                {
                    mapInfoPointModelList[0].Lat = coordList[0].Lat;
                    mapInfoPointModelList[0].Lng = coordList[0].Lng;

                    MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                        return ReturnError(mapInfoPointModelRet.Error);
                }

                TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(mwqmSiteModelRet.MWQMSiteTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                    return ReturnError(tvItemModel.Error);

                tvItemModel.IsActive = IsActive;
                tvItemModel.TVText = MWQMSiteTVText;

                TVItemModel tvItemModelRet = _TVItemService.PostUpdateTVItemDB(tvItemModel);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }
            return mwqmSiteModelRet;
        }
        public MWQMSiteModel PostAddMWQMSiteDB(MWQMSiteModel mwqmSiteModel)
        {
            string retStr = MWQMSiteModelOK(mwqmSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelExist = _TVItemService.GetTVItemModelWithTVItemIDDB(mwqmSiteModel.MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelExist.Error))
                return ReturnError(tvItemModelExist.Error);

            MWQMSite mwqmSiteNew = new MWQMSite();
            retStr = FillMWQMSite(mwqmSiteNew, mwqmSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSites.Add(mwqmSiteNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSites", mwqmSiteNew.MWQMSiteID, LogCommandEnum.Add, mwqmSiteNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSiteModelWithMWQMSiteIDDB(mwqmSiteNew.MWQMSiteID);
        }
        public MWQMSiteModel PostDeleteMWQMSiteDB(int MWQMSiteID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSite mwqmSiteToDelete = GetMWQMSiteWithMWQMSiteIDDB(MWQMSiteID);
            if (mwqmSiteToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.MWQMSite));

            int TVItemIDToDelete = mwqmSiteToDelete.MWQMSiteTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.MWQMSites.Remove(mwqmSiteToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSites", mwqmSiteToDelete.MWQMSiteID, LogCommandEnum.Delete, mwqmSiteToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                List<MWQMSiteStartEndDateModel> mwqmsiteStartEndDateModelList = _MWQMSiteStartEndDateService.GetMWQMSiteStartEndDateModelListWithMWQMSiteTVItemIDDB(mwqmSiteToDelete.MWQMSiteTVItemID);

                foreach (MWQMSiteStartEndDateModel mwqmSiteStartEndDateModel in mwqmsiteStartEndDateModelList)
                {
                    MWQMSiteStartEndDateModel mwqmSiteStartEndDateModelRet = _MWQMSiteStartEndDateService.PostDeleteMWQMSiteStartEndDateDB(mwqmSiteStartEndDateModel.MWQMSiteStartEndDateID);
                    if (!string.IsNullOrWhiteSpace(mwqmSiteStartEndDateModelRet.Error))
                        return ReturnError(mwqmSiteStartEndDateModelRet.Error);
                }

                List<MapInfoModel> mapInfoModelList = _MapInfoService.GetMapInfoModelListWithTVItemIDDB(mwqmSiteToDelete.MWQMSiteID);

                foreach (MapInfoModel mapInfoModel in mapInfoModelList)
                {
                    MapInfoModel mapInfoModelRet = _MapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                        return ReturnError(mapInfoModelRet.Error);
                }

                TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
                    return ReturnError(tvItemModelRet.Error);

                ts.Complete();
            }

            return ReturnError("");
        }
        public MWQMSiteModel PostDeleteMWQMSiteTVItemDB(int MWQMSiteTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSiteModel mwqmSiteModelToDelete = GetMWQMSiteModelWithMWQMSiteTVItemIDDB(MWQMSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(mwqmSiteModelToDelete.Error))
                return ReturnError(mwqmSiteModelToDelete.Error);

            MWQMSiteModel mwqmSiteModelRet = PostDeleteMWQMSiteDB(mwqmSiteModelToDelete.MWQMSiteID);
            if (!string.IsNullOrWhiteSpace(mwqmSiteModelRet.Error))
                return ReturnError(mwqmSiteModelRet.Error);

            return ReturnError("");
        }
        public MWQMSiteModel PostUpdateMWQMSiteDB(MWQMSiteModel mwqmSiteModel)
        {
            string retStr = MWQMSiteModelOK(mwqmSiteModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            MWQMSite mwqmSiteToUpdate = GetMWQMSiteWithMWQMSiteIDDB(mwqmSiteModel.MWQMSiteID);
            if (mwqmSiteToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.MWQMSite));

            retStr = FillMWQMSite(mwqmSiteToUpdate, mwqmSiteModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("MWQMSites", mwqmSiteToUpdate.MWQMSiteID, LogCommandEnum.Change, mwqmSiteToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetMWQMSiteModelWithMWQMSiteIDDB(mwqmSiteToUpdate.MWQMSiteID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}