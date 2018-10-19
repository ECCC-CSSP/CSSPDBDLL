using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;

namespace CSSPDBDLL.Services
{
    public class TVItemStatService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        #endregion Properties

        #region Constructors
        public TVItemStatService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
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
        public string TVItemStatModelOK(TVItemStatModel tvItemStatModel)
        {
            string retStr = FieldCheckNotZeroInt(tvItemStatModel.TVItemID, ServiceRes.TVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.TVTypeOK(tvItemStatModel.TVType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTVItemStat(TVItemStat tvItemStat, TVItemStatModel tvItemStatModel, ContactOK contactOK)
        {
            tvItemStat.TVItemID = tvItemStatModel.TVItemID;
            tvItemStat.TVType = (int)tvItemStatModel.TVType;
            tvItemStat.ChildCount = tvItemStatModel.ChildCount;
            tvItemStat.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tvItemStat.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tvItemStat.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetChildCount(TVItemModel tvItemModel, TVTypeEnum ChildTVType)
        {
            int ChildCount = -1;
            switch (ChildTVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Root)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Address
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItemModel.TVType == TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let addressCount = (from cll in db.TVItemLinks
                                                                  where cll.FromTVItemID == c.TVItemID
                                                                  && cll.ToTVType == (int)TVTypeEnum.Address
                                                                  select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItemModel.TVItemID
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select addressCount).DefaultIfEmpty().Sum()
                                              +
                                              (from c in db.TVItems
                                               from ci in db.Infrastructures
                                               where c.TVItemID == ci.InfrastructureTVItemID
                                               && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                               && ci.CivicAddressTVItemID > 0
                                               select c).Count()
                                          +
                                          (from c in db.TVItems
                                           from ci in db.PolSourceSites
                                           where c.TVItemID == ci.PolSourceSiteTVItemID
                                           && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                           && ci.CivicAddressTVItemID > 0
                                           select c).Count()
;
                            }
                            else
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let addressCount = (from cll in db.TVItemLinks
                                                                  where cll.FromTVItemID == c.TVItemID
                                                                  && cll.ToTVType == (int)TVTypeEnum.Address
                                                                  select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select addressCount).DefaultIfEmpty().Sum()
                                              +
                                              (from c in db.TVItems
                                               from ci in db.Infrastructures
                                               where c.TVItemID == ci.InfrastructureTVItemID
                                               && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                               && ci.CivicAddressTVItemID > 0
                                               select c).Count()
                                          +
                                          (from c in db.TVItems
                                           from ci in db.PolSourceSites
                                           where c.TVItemID == ci.PolSourceSiteTVItemID
                                           && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                           && ci.CivicAddressTVItemID > 0
                                           select c).Count()
;
                            };
                        }
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Area
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.BoxModel:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Infrastructure)
                        {
                            ChildCount = (from b in db.BoxModels
                                          where b.InfrastructureTVItemID == tvItemModel.TVItemID
                                          select b).Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          from b in db.BoxModels
                                          where c.TVItemID == b.InfrastructureTVItemID
                                          && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          select b).Count();
                        }
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Root || tvItemModel.TVType == TVTypeEnum.Country || tvItemModel.TVType == TVTypeEnum.Province)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.ClimateSite
                                          select c).Count();
                        }
                        else if (tvItemModel.TVType == TVTypeEnum.Area || tvItemModel.TVType == TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Climate
                                          select c).Count();
                        }
                        else if (tvItemModel.TVType == TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItemModel.TVItemID
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Climate
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Municipality)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cl in db.TVItemLinks
                                          where c.TVItemID == cl.FromTVItemID
                                          && c.TVItemID == tvItemModel.TVItemID
                                          && cl.ToTVType == (int)TVTypeEnum.Contact
                                          select c).Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          from cl in db.TVItemLinks
                                          where c.TVItemID == cl.FromTVItemID
                                          && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && cl.ToTVType == (int)TVTypeEnum.Contact
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Country
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Root)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Email
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItemModel.TVType == TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let emailCount = (from cll in db.TVItemLinks
                                                                where cll.FromTVItemID == c.TVItemID
                                                                && cll.ToTVType == (int)TVTypeEnum.Email
                                                                select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItemModel.TVItemID
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select emailCount).DefaultIfEmpty().Sum();
                            }
                            else
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let emailCount = (from cll in db.TVItemLinks
                                                                where cll.FromTVItemID == c.TVItemID
                                                                && cll.ToTVType == (int)TVTypeEnum.Email
                                                                select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select emailCount).DefaultIfEmpty().Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        int TVLevelFile = tvItemModel.TVLevel + 1;
                        ChildCount = (from c in db.TVItems
                                      from f in db.TVFiles
                                      where c.TVItemID == f.TVFileTVItemID
                                      && c.TVLevel == TVLevelFile
                                      && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.File
                                      && f.FilePurpose != (int)FilePurposeEnum.Template
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Root || tvItemModel.TVType == TVTypeEnum.Country || tvItemModel.TVType == TVTypeEnum.Province)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.HydrometricSite
                                          select c).Count();
                        }
                        else if (tvItemModel.TVType == TVTypeEnum.Area || tvItemModel.TVType == TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Hydrometric
                                          select c).Count();
                        }
                        else if (tvItemModel.TVType == TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItemModel.TVItemID
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Hydrometric
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Infrastructure
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.LiftStation:
                    {
                        ChildCount = (from c in db.TVItems
                                      from inf in db.Infrastructures
                                      where c.TVItemID == inf.InfrastructureTVItemID
                                      && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && inf.InfrastructureType == (int)InfrastructureTypeEnum.LiftStation
                                      select inf).Count();
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.MikeScenario
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.MikeSource
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Municipality
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.MWQMSite)
                        {
                            ChildCount = (from c in db.MWQMSamples
                                          where c.MWQMSiteTVItemID == tvItemModel.TVItemID
                                          select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.MWQMRun
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.MWQMRun)
                        {
                            ChildCount = (from c in db.MWQMSamples
                                          where c.MWQMRunTVItemID == tvItemModel.TVItemID
                                          select c.MWQMSiteTVItemID).Distinct().Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.MWQMSite
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSiteSample:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.MWQMRun)
                        {
                            ChildCount = (from s in db.MWQMSamples
                                          where s.MWQMRunTVItemID == tvItemModel.TVItemID
                                          select s).Count();
                        }
                        else if (tvItemModel.TVType == TVTypeEnum.MWQMSite)
                        {
                            ChildCount = (from s in db.MWQMSamples
                                          where s.MWQMSiteTVItemID == tvItemModel.TVItemID
                                          select s).Count();
                        }
                        else
                        {
                            ChildCount = 0;
                            if ((from c in db.TVItems
                                 where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                 && c.TVType == (int)TVTypeEnum.MWQMSite
                                 select c).Any())
                            {
                                ChildCount = (from c in db.TVItems
                                              let count = (from s in db.MWQMSamples
                                                           where s.MWQMSiteTVItemID == c.TVItemID
                                                           select s).Count()
                                              where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                              && c.TVType == (int)TVTypeEnum.MWQMSite
                                              select count).Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.PolSourceSite
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Province
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Sector
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Subsector
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Spill:
                    {
                        ChildCount = (from c in db.TVItems
                                      from s in db.Spills
                                      where (c.TVItemID == s.MunicipalityTVItemID
                                      || c.TVItemID == s.InfrastructureTVItemID)
                                      && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && (c.TVType == (int)TVTypeEnum.Municipality
                                      || c.TVType == (int)TVTypeEnum.Infrastructure)
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Root)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Tel
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItemModel.TVType == TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let telCount = (from cll in db.TVItemLinks
                                                                where cll.FromTVItemID == c.TVItemID
                                                                && cll.ToTVType == (int)TVTypeEnum.Tel
                                                                select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItemModel.TVItemID
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select telCount).DefaultIfEmpty().Sum();
                            }
                            else
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let telCount = (from cll in db.TVItemLinks
                                                                where cll.FromTVItemID == c.TVItemID
                                                                && cll.ToTVType == (int)TVTypeEnum.Tel
                                                                select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select telCount).DefaultIfEmpty().Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Root || tvItemModel.TVType == TVTypeEnum.Country || tvItemModel.TVType == TVTypeEnum.Province)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.TideSite
                                          select c).Count();
                        }
                        else if (tvItemModel.TVType == TVTypeEnum.Area || tvItemModel.TVType == TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Tide
                                          select c).Count();
                        }
                        else if (tvItemModel.TVType == TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItemModel.TVItemID
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Tide
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.TotalFile:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.File
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.VisualPlumesScenario:
                    {
                        if (tvItemModel.TVType == TVTypeEnum.Infrastructure)
                        {
                            ChildCount = (from v in db.VPScenarios
                                          where v.InfrastructureTVItemID == tvItemModel.TVItemID
                                          select v).Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          from v in db.VPScenarios
                                          where c.TVItemID == v.InfrastructureTVItemID
                                          && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                          select v).Count();
                        }
                    }
                    break;
                case TVTypeEnum.WasteWaterTreatmentPlant:
                    {
                        ChildCount = (from c in db.TVItems
                                      from inf in db.Infrastructures
                                      where c.TVItemID == inf.InfrastructureTVItemID
                                      && c.TVPath.StartsWith(tvItemModel.TVPath + "p")
                                      && inf.InfrastructureType == (int)InfrastructureTypeEnum.WWTP
                                      select inf).Count();
                    }
                    break;
                default:
                    break;
            }

            return ChildCount;
        }
        public int GetChildCount2(TVItem tvItem, TVTypeEnum ChildTVType)
        {
            int ChildCount = -1;
            switch (ChildTVType)
            {
                case TVTypeEnum.Address:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Root)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Address
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItem.TVType == (int)TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let addressCount = (from cll in db.TVItemLinks
                                                                  where cll.FromTVItemID == c.TVItemID
                                                                  && cll.ToTVType == (int)TVTypeEnum.Address
                                                                  select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItem.TVItemID
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select addressCount).DefaultIfEmpty().Sum()
                                              +
                                              (from c in db.TVItems
                                               from ci in db.Infrastructures
                                               where c.TVItemID == ci.InfrastructureTVItemID
                                               && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                               && ci.CivicAddressTVItemID > 0
                                               select c).Count()
                                          +
                                          (from c in db.TVItems
                                           from ci in db.PolSourceSites
                                           where c.TVItemID == ci.PolSourceSiteTVItemID
                                           && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                           && ci.CivicAddressTVItemID > 0
                                           select c).Count()
;
                            }
                            else
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let addressCount = (from cll in db.TVItemLinks
                                                                  where cll.FromTVItemID == c.TVItemID
                                                                  && cll.ToTVType == (int)TVTypeEnum.Address
                                                                  select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select addressCount).DefaultIfEmpty().Sum()
                                              +
                                              (from c in db.TVItems
                                               from ci in db.Infrastructures
                                               where c.TVItemID == ci.InfrastructureTVItemID
                                               && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                               && ci.CivicAddressTVItemID > 0
                                               select c).Count()
                                          +
                                          (from c in db.TVItems
                                           from ci in db.PolSourceSites
                                           where c.TVItemID == ci.PolSourceSiteTVItemID
                                           && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                           && ci.CivicAddressTVItemID > 0
                                           select c).Count()
;
                            };
                        }
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Area
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.BoxModel:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Infrastructure)
                        {
                            ChildCount = (from b in db.BoxModels
                                          where b.InfrastructureTVItemID == tvItem.TVItemID
                                          select b).Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          from b in db.BoxModels
                                          where c.TVItemID == b.InfrastructureTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          select b).Count();
                        }
                    }
                    break;
                case TVTypeEnum.ClimateSite:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Root || tvItem.TVType == (int)TVTypeEnum.Country || tvItem.TVType == (int)TVTypeEnum.Province)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.ClimateSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == (int)TVTypeEnum.Area || tvItem.TVType == (int)TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Climate
                                          select c).Count();
                        }
                        else if (tvItem.TVType == (int)TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItem.TVItemID
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Climate
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Contact:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Municipality)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cl in db.TVItemLinks
                                          where c.TVItemID == cl.FromTVItemID
                                          && c.TVItemID == tvItem.TVItemID
                                          && cl.ToTVType == (int)TVTypeEnum.Contact
                                          select c).Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          from cl in db.TVItemLinks
                                          where c.TVItemID == cl.FromTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && cl.ToTVType == (int)TVTypeEnum.Contact
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Country
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Email:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Root)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Email
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItem.TVType == (int)TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let emailCount = (from cll in db.TVItemLinks
                                                                where cll.FromTVItemID == c.TVItemID
                                                                && cll.ToTVType == (int)TVTypeEnum.Email
                                                                select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItem.TVItemID
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select emailCount).DefaultIfEmpty().Sum();
                            }
                            else
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let emailCount = (from cll in db.TVItemLinks
                                                                where cll.FromTVItemID == c.TVItemID
                                                                && cll.ToTVType == (int)TVTypeEnum.Email
                                                                select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select emailCount).DefaultIfEmpty().Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.File:
                    {
                        int TVLevelFile = tvItem.TVLevel + 1;
                        ChildCount = (from c in db.TVItems
                                      from f in db.TVFiles
                                      where c.TVItemID == f.TVFileTVItemID
                                      && c.TVLevel == TVLevelFile
                                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.File
                                      && f.FilePurpose != (int)FilePurposeEnum.Template
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.HydrometricSite:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Root || tvItem.TVType == (int)TVTypeEnum.Country || tvItem.TVType == (int)TVTypeEnum.Province)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.HydrometricSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == (int)TVTypeEnum.Area || tvItem.TVType == (int)TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Hydrometric
                                          select c).Count();
                        }
                        else if (tvItem.TVType == (int)TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItem.TVItemID
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Hydrometric
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Infrastructure
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.LiftStation:
                    {
                        ChildCount = (from c in db.TVItems
                                      from inf in db.Infrastructures
                                      where c.TVItemID == inf.InfrastructureTVItemID
                                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && inf.InfrastructureType == (int)InfrastructureTypeEnum.LiftStation
                                      select inf).Count();
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.MikeScenario
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.MikeSource:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.MikeSource
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Municipality
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.MWQMSite)
                        {
                            ChildCount = (from c in db.MWQMSamples
                                          where c.MWQMSiteTVItemID == tvItem.TVItemID
                                          select c.MWQMRunTVItemID).Distinct().Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.MWQMRun
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.MWQMRun)
                        {
                            ChildCount = (from c in db.MWQMSamples
                                          where c.MWQMRunTVItemID == tvItem.TVItemID
                                          select c.MWQMSiteTVItemID).Distinct().Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.MWQMSite
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.MWQMSiteSample:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.MWQMRun)
                        {
                            ChildCount = (from s in db.MWQMSamples
                                          where s.MWQMRunTVItemID == tvItem.TVItemID
                                          select s).Count();
                        }
                        else if (tvItem.TVType == (int)TVTypeEnum.MWQMSite)
                        {
                            ChildCount = (from s in db.MWQMSamples
                                          where s.MWQMSiteTVItemID == tvItem.TVItemID
                                          select s).Count();
                        }
                        else
                        {
                            ChildCount = 0;
                            if ((from c in db.TVItems
                                 where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                 && c.TVType == (int)TVTypeEnum.MWQMSite
                                 select c).Any())
                            {
                                ChildCount = (from c in db.TVItems
                                              let count = (from s in db.MWQMSamples
                                                           where s.MWQMSiteTVItemID == c.TVItemID
                                                           select s).Count()
                                              where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && c.TVType == (int)TVTypeEnum.MWQMSite
                                              select count).Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.PolSourceSite
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Province
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Sector
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.Subsector
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Spill:
                    {
                        ChildCount = (from c in db.TVItems
                                      from s in db.Spills
                                      where (c.TVItemID == s.MunicipalityTVItemID
                                      || c.TVItemID == s.InfrastructureTVItemID)
                                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && (c.TVType == (int)TVTypeEnum.Municipality
                                      || c.TVType == (int)TVTypeEnum.Infrastructure)
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.Tel:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Root)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Tel
                                          select c).Count();
                        }
                        else
                        {
                            if (tvItem.TVType == (int)TVTypeEnum.Municipality)
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let telCount = (from cll in db.TVItemLinks
                                                              where cll.FromTVItemID == c.TVItemID
                                                              && cll.ToTVType == (int)TVTypeEnum.Tel
                                                              select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVItemID == tvItem.TVItemID
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select telCount).DefaultIfEmpty().Sum();
                            }
                            else
                            {
                                ChildCount = (from c in db.TVItems
                                              from cl in db.TVItemLinks
                                              let telCount = (from cll in db.TVItemLinks
                                                              where cll.FromTVItemID == c.TVItemID
                                                              && cll.ToTVType == (int)TVTypeEnum.Tel
                                                              select cll).DefaultIfEmpty().Count()
                                              where c.TVItemID == cl.FromTVItemID
                                              && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                              && cl.ToTVType == (int)TVTypeEnum.Contact
                                              select telCount).DefaultIfEmpty().Sum();
                            }
                        }
                    }
                    break;
                case TVTypeEnum.TideSite:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Root || tvItem.TVType == (int)TVTypeEnum.Country || tvItem.TVType == (int)TVTypeEnum.Province)
                        {
                            ChildCount = (from c in db.TVItems
                                          where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.TideSite
                                          select c).Count();
                        }
                        else if (tvItem.TVType == (int)TVTypeEnum.Area || tvItem.TVType == (int)TVTypeEnum.Sector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Tide
                                          select c).Count();
                        }
                        else if (tvItem.TVType == (int)TVTypeEnum.Subsector)
                        {
                            ChildCount = (from c in db.TVItems
                                          from cu in db.UseOfSites
                                          where c.TVItemID == cu.SubsectorTVItemID
                                          && c.TVItemID == tvItem.TVItemID
                                          && c.TVType == (int)TVTypeEnum.Subsector
                                          && cu.SiteType == (int)SiteTypeEnum.Tide
                                          select c).Count();
                        }
                    }
                    break;
                case TVTypeEnum.TotalFile:
                    {
                        ChildCount = (from c in db.TVItems
                                      where c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && c.TVType == (int)TVTypeEnum.File
                                      select c).Count();
                    }
                    break;
                case TVTypeEnum.VisualPlumesScenario:
                    {
                        if (tvItem.TVType == (int)TVTypeEnum.Infrastructure)
                        {
                            ChildCount = (from v in db.VPScenarios
                                          where v.InfrastructureTVItemID == tvItem.TVItemID
                                          select v).Count();
                        }
                        else
                        {
                            ChildCount = (from c in db.TVItems
                                          from v in db.VPScenarios
                                          where c.TVItemID == v.InfrastructureTVItemID
                                          && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                          select v).Count();
                        }
                    }
                    break;
                case TVTypeEnum.WasteWaterTreatmentPlant:
                    {
                        ChildCount = (from c in db.TVItems
                                      from inf in db.Infrastructures
                                      where c.TVItemID == inf.InfrastructureTVItemID
                                      && c.TVPath.StartsWith(tvItem.TVPath + "p")
                                      && inf.InfrastructureType == (int)InfrastructureTypeEnum.WWTP
                                      select inf).Count();
                    }
                    break;
                default:
                    break;
            }

            return ChildCount;
        }
        public List<TVTypeEnum> GetSubTVTypeForTVItemStat(TVTypeEnum TVType)
        {
            List<TVTypeEnum> SubTVTypeList = new List<TVTypeEnum>();
            switch (TVType)
            {
                case TVTypeEnum.Root:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.Address,
                            TVTypeEnum.Area,
                            TVTypeEnum.ClimateSite,
                            TVTypeEnum.Contact,
                            TVTypeEnum.Country,
                            TVTypeEnum.Email,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            TVTypeEnum.MWQMSite,
                            TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Province,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            TVTypeEnum.Tel,
                            TVTypeEnum.TideSite,
                            TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                        };
                    }
                    break;
                case TVTypeEnum.Area:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.Address,
                            TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            TVTypeEnum.MWQMSite,
                            TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            TVTypeEnum.TideSite,
                            TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                            TVTypeEnum.Contact,
                        };
                    }
                    break;
                case TVTypeEnum.Country:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.Area,
                            TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            TVTypeEnum.MWQMSite,
                            TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Province,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            TVTypeEnum.TideSite,
                            TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                            TVTypeEnum.Address,
                            TVTypeEnum.TotalFile,
                            TVTypeEnum.Contact,
                        };
                    }
                    break;
                case TVTypeEnum.Infrastructure:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.File,
                            TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                        };
                    }
                    break;
                case TVTypeEnum.MikeScenario:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            TVTypeEnum.MikeSource,
                        };
                    }
                    break;
                case TVTypeEnum.Municipality:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.Address,
                            TVTypeEnum.Contact,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                        };
                    }
                    break;
                case TVTypeEnum.MWQMSite:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.File,
                            TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.MWQMRun,
                        };
                    }
                    break;
                case TVTypeEnum.PolSourceSite:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.Address,
                            TVTypeEnum.File,
                        };
                    }
                    break;
                case TVTypeEnum.Province:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.Address,
                            TVTypeEnum.Area,
                            TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            TVTypeEnum.TotalFile,
                            TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            TVTypeEnum.MWQMSite,
                            TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Sector,
                            TVTypeEnum.Subsector,
                            TVTypeEnum.TideSite,
                            TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                            TVTypeEnum.Contact,
                        };
                    }
                    break;
                case TVTypeEnum.Sector:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            TVTypeEnum.MWQMSite,
                            TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.Subsector,
                            TVTypeEnum.TideSite,
                            TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                            TVTypeEnum.Address,
                            TVTypeEnum.Contact,
                            TVTypeEnum.TotalFile,
                        };
                    }
                    break;
                case TVTypeEnum.Subsector:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.ClimateSite,
                            TVTypeEnum.File,
                            TVTypeEnum.HydrometricSite,
                            TVTypeEnum.Infrastructure,
                            TVTypeEnum.MikeScenario,
                            TVTypeEnum.Municipality,
                            TVTypeEnum.MWQMSite,
                            TVTypeEnum.MWQMRun,
                            TVTypeEnum.PolSourceSite,
                            TVTypeEnum.TideSite,
                            TVTypeEnum.MWQMSiteSample,
                            TVTypeEnum.WasteWaterTreatmentPlant,
                            TVTypeEnum.LiftStation,
                            TVTypeEnum.Spill,
                            TVTypeEnum.BoxModel,
                            TVTypeEnum.VisualPlumesScenario,
                            TVTypeEnum.Address,
                            TVTypeEnum.Contact,
                            TVTypeEnum.TotalFile,
                        };
                    }
                    break;
                case TVTypeEnum.MWQMRun:
                    {
                        SubTVTypeList = new List<TVTypeEnum>()
                        {
                            TVTypeEnum.File,
                            TVTypeEnum.MWQMSite,
                            TVTypeEnum.MWQMSiteSample,
                        };
                    }
                    break;
                default:
                    break;
            }

            return SubTVTypeList;
        }
        public List<TVItemStatModel> GetTVItemStatModelListWithTVItemIDDB(int TVItemID)
        {
            List<TVItemStatModel> tvItemStatModelList = (from c in db.TVItemStats
                                                         where c.TVItemID == TVItemID
                                                         select new TVItemStatModel
                                                         {
                                                             Error = "",
                                                             TVItemStatID = c.TVItemStatID,
                                                             TVItemID = c.TVItemID,
                                                             TVType = (TVTypeEnum)c.TVType,
                                                             ChildCount = c.ChildCount,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                                         }).ToList<TVItemStatModel>();


            return tvItemStatModelList;
        }
        public TVItemStatModel GetTVItemStatModelWithTVItemIDAndTVTypeDB(int TVItemID, TVTypeEnum TVType)
        {
            TVItemStatModel tvItemStatModel = (from c in db.TVItemStats
                                               where c.TVItemID == TVItemID
                                               && c.TVType == (int)TVType
                                               select new TVItemStatModel
                                               {
                                                   Error = "",
                                                   TVItemStatID = c.TVItemStatID,
                                                   TVItemID = c.TVItemID,
                                                   TVType = (TVTypeEnum)c.TVType,
                                                   ChildCount = c.ChildCount,
                                                   LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                   LastUpdateContactTVItemID = c.LastUpdateContactTVItemID
                                               }).FirstOrDefault<TVItemStatModel>();

            if (tvItemStatModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVItem, ServiceRes.TVItemID + "," + ServiceRes.TVType, TVItemID.ToString() + "," + TVType.ToString()));

            return tvItemStatModel;
        }
        public List<TVItemStat> GetTVItemStatListWithTVItemIDDB(int TVItemID)
        {
            List<TVItemStat> tvItemStatList = (from c in db.TVItemStats
                                               where c.TVItemID == TVItemID
                                               select c).ToList<TVItemStat>();

            return tvItemStatList;
        }
        public TVItemStat GetTVItemStatWithTVItemIDAndTVTypeDB(int TVItemID, TVTypeEnum TVType)
        {
            TVItemStat tvItemStat = (from c in db.TVItemStats
                                     where c.TVItemID == TVItemID
                                     && c.TVType == (int)TVType
                                     select c).FirstOrDefault<TVItemStat>();

            return tvItemStat;
        }

        // Helper
        public TVItemStatModel ReturnError(string Error)
        {
            return new TVItemStatModel() { Error = Error };
        }

        // Post
        public TVItemStatModel PostAddTVItemStatDB(TVItemStatModel tvItemStatModel)
        {
            string retStr = TVItemStatModelOK(tvItemStatModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemStatModel tvItemStatModelExist = GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemStatModel.TVItemID, (TVTypeEnum)tvItemStatModel.TVType);
            if (string.IsNullOrWhiteSpace(tvItemStatModelExist.Error))
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVItem));

            TVItemStat tvItemStatNew = new TVItemStat();

            retStr = FillTVItemStat(tvItemStatNew, tvItemStatModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVItemStats.Add(tvItemStatNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemStats", tvItemStatNew.TVItemStatID, LogCommandEnum.Add, tvItemStatNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemStatModel.TVItemID, tvItemStatModel.TVType);
        }
        public TVItemStatModel PostDeleteTVItemStatWithTVItemIDDB(int TVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            List<TVItemStat> tvItemStatToDeleteList = GetTVItemStatListWithTVItemIDDB(TVItemID);

            using (TransactionScope ts = new TransactionScope())
            {
                foreach (TVItemStat tvItemStat in tvItemStatToDeleteList)
                {
                    db.TVItemStats.Remove(tvItemStat);

                    LogModel logModel = _LogService.PostAddLogForObj("TVItemStats", tvItemStat.TVItemStatID, LogCommandEnum.Delete, tvItemStat);
                    if (!string.IsNullOrWhiteSpace(logModel.Error))
                        return ReturnError(logModel.Error);
                }

                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);


                ts.Complete();
            }

            return ReturnError("");
        }
        public TVItemStatModel PostUpdateTVItemStatDB(TVItemStatModel tvItemStatModel)
        {
            string retStr = TVItemStatModelOK(tvItemStatModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemStat tvItemStatToUpdate = GetTVItemStatWithTVItemIDAndTVTypeDB(tvItemStatModel.TVItemID, tvItemStatModel.TVType);
            if (tvItemStatToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVItemStat));

            retStr = FillTVItemStat(tvItemStatToUpdate, tvItemStatModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVItemStats", tvItemStatToUpdate.TVItemStatID, LogCommandEnum.Change, tvItemStatToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }
            return GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemStatModel.TVItemID, tvItemStatModel.TVType);
        }

        // Set
        public string SetTVItemStatForTVItemIDAndParentsTVItemID(int TVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            List<TVItemModel> tvItemModelParents = _TVItemService.GetParentsTVItemModelList(tvItemModel.TVPath);

            foreach (TVItemModel tvItemModelParent in tvItemModelParents)
            {
                string retStr = SetTVItemStatForTVItemID(tvItemModelParent.TVItemID);
                if (!string.IsNullOrWhiteSpace(retStr))
                    return retStr;
            }

            return "";
        }
        public string SetTVItemStatForTVItemID(int TVItemID)
        {
            ContactOK contactOK = IsContactOK();
            //if (!string.IsNullOrEmpty(contactOK.Error))
            //    return contactOK.Error;

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            List<TVTypeEnum> SubTVTypeList = GetSubTVTypeForTVItemStat(tvItemModel.TVType);

            foreach (TVTypeEnum tvType in SubTVTypeList)
            {
                TVItemStatModel tvItemStatModel = GetTVItemStatModelWithTVItemIDAndTVTypeDB(TVItemID, tvType);
                TVItemStatModel tvItemStatModelRet = new TVItemStatModel();

                using (TransactionScope ts = new TransactionScope())
                {
                    if (!string.IsNullOrWhiteSpace(tvItemStatModel.Error))
                    {
                        int ChildCount = GetChildCount(tvItemModel, tvType);

                        tvItemStatModel = new TVItemStatModel()
                        {
                            TVItemID = TVItemID,
                            TVType = (TVTypeEnum)tvType,
                            ChildCount = ChildCount,
                        };

                        TVItemStat tvItemStatNew = new TVItemStat();
                        string retStr = FillTVItemStat(tvItemStatNew, tvItemStatModel, contactOK);
                        if (!string.IsNullOrWhiteSpace(retStr))
                            return retStr;

                        tvItemStatModelRet = PostAddTVItemStatDB(tvItemStatModel);
                        if (!string.IsNullOrWhiteSpace(tvItemStatModelRet.Error))
                            return tvItemStatModelRet.Error;
                    }
                    else
                    {
                        int ChildCount = GetChildCount(tvItemModel, tvType);

                        if (tvItemStatModel.ChildCount != ChildCount)
                        {
                            tvItemStatModel.ChildCount = ChildCount;
                            tvItemStatModelRet = PostUpdateTVItemStatDB(tvItemStatModel);
                            if (!string.IsNullOrWhiteSpace(tvItemStatModelRet.Error))
                                return tvItemStatModelRet.Error;
                        }
                    }

                    ts.Complete();
                }
            }

            return "";
        }
        public TVItemStatModel SetTVItemStatForTVItemIDAndTVType(int TVItemID, TVTypeEnum TVType)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnError(tvItemModel.Error);

            int ChildCount = GetChildCount(tvItemModel, TVType);

            TVItemStatModel tvItemStatModel = GetTVItemStatModelWithTVItemIDAndTVTypeDB(TVItemID, TVType);
            bool StatExist = false;
            if (!string.IsNullOrWhiteSpace(tvItemStatModel.Error))
            {
                StatExist = true;
                tvItemStatModel = new TVItemStatModel();
            }

            tvItemStatModel.TVItemID = TVItemID;
            tvItemStatModel.TVType = (TVTypeEnum)TVType;
            tvItemStatModel.ChildCount = ChildCount;

            TVItemStat tvItemStatNew = new TVItemStat();
            string retStr = FillTVItemStat(tvItemStatNew, tvItemStatModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            TVItemStatModel tvItemStatModelRet = new TVItemStatModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (StatExist)
                {
                    tvItemStatModelRet = PostAddTVItemStatDB(tvItemStatModel);
                }
                else
                {
                    tvItemStatModelRet = PostUpdateTVItemStatDB(tvItemStatModel);
                }
                if (!string.IsNullOrWhiteSpace(tvItemStatModelRet.Error))
                    return ReturnError(tvItemStatModelRet.Error);

                ts.Complete();
            }

            return GetTVItemStatModelWithTVItemIDAndTVTypeDB(tvItemStatModelRet.TVItemID, tvItemStatModelRet.TVType);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
