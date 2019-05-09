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
using System.Threading;
using System.Globalization;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;
using System.IO;

namespace CSSPDBDLL.Services
{
    public class PolSourceSiteInputToolService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public PolSourceSiteInputToolService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
        }
        #endregion Constructors

        #region Helper
        public TVItemModel ReturnError(string Error)
        {
            return new TVItemModel() { Error = Error };
        }
        #endregion Helper

        #region Functions public
        public TVItemModel CreateOrModifyInfrastructureDB(int MunicipalityTVItemID, int TVItemID, string TVText, bool IsActive,
            float? Lat, float? Lng, float? LatOutfall, float? LngOutfall, string CommentEN, string CommentFR, InfrastructureTypeEnum? InfrastructureType,
            FacilityTypeEnum? FacilityType, bool? IsMechanicallyAerated, int? NumberOfCells, int? NumberOfAeratedCells, AerationTypeEnum? AerationType,
            PreliminaryTreatmentTypeEnum? PreliminaryTreatmentType, PrimaryTreatmentTypeEnum? PrimaryTreatmentType,
            SecondaryTreatmentTypeEnum? SecondaryTreatmentType, TertiaryTreatmentTypeEnum? TertiaryTreatmentType,
            DisinfectionTypeEnum? DisinfectionType, CollectionSystemTypeEnum? CollectionSystemType, AlarmSystemTypeEnum? AlarmSystemType,
            float? DesignFlow_m3_day, float? AverageFlow_m3_day, float? PeakFlow_m3_day, int? PopServed, bool? CanOverflow,
            float? PercFlowOfTotal, float? AverageDepth_m, int? NumberOfPorts,
            float? PortDiameter_m, float? PortSpacing_m, float? PortElevation_m, float? VerticalAngle_deg, float? HorizontalAngle_deg,
            float? DecayRate_per_day, float? NearFieldVelocity_m_s, float? FarFieldVelocity_m_s, float? ReceivingWaterSalinity_PSU,
            float? ReceivingWaterTemperature_C, int? ReceivingWater_MPN_per_100ml, float? DistanceFromShore_m,
            int? SeeOtherMunicipalityTVItemID, string SeeOtherMunicipalityText, int? PumpsToTVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            if (InfrastructureType == null)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureType)}");
            }

            TVTypeEnum tvTypeInfrasturture = TVTypeEnum.Error;

            switch (InfrastructureType)
            {
                case InfrastructureTypeEnum.LiftStation:
                    {
                        tvTypeInfrasturture = TVTypeEnum.LiftStation;
                    }
                    break;
                case InfrastructureTypeEnum.LineOverflow:
                    {
                        tvTypeInfrasturture = TVTypeEnum.LineOverflow;
                    }
                    break;
                case InfrastructureTypeEnum.Other:
                    {
                        tvTypeInfrasturture = TVTypeEnum.OtherInfrastructure;
                    }
                    break;
                case InfrastructureTypeEnum.SeeOtherMunicipality:
                    {
                        tvTypeInfrasturture = TVTypeEnum.SeeOtherMunicipality;
                    }
                    break;
                case InfrastructureTypeEnum.WWTP:
                    {
                        tvTypeInfrasturture = TVTypeEnum.WasteWaterTreatmentPlant;
                    }
                    break;
                default:
                    break;
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, user);
            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, user);
            TVItemLinkService tvItemLinkService = new TVItemLinkService(LanguageRequest, user);

            if (MunicipalityTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.MunicipalityTVItemID)}");
            }

            TVItemModel tvItemModelMunicipality = tvItemService.GetTVItemModelWithTVItemIDDB(MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
            {
                return ReturnError($"ERROR: {tvItemModelMunicipality.Error}");
            }

            if (TVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            if (string.IsNullOrWhiteSpace(TVText))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.TVText)}");
            }

            InfrastructureModel infrastructureModelRet = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
            if (TVItemID >= 10000000 || !string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
            {
                TVItemModel tvItemModelInfrastructure = tvItemService.PostAddChildTVItemDB(MunicipalityTVItemID, TVText, TVTypeEnum.Infrastructure);
                if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelInfrastructure.Error}");
                }

                InfrastructureModel infrastructureModelNew = new InfrastructureModel();
                infrastructureModelNew.InfrastructureTVItemID = tvItemModelInfrastructure.TVItemID;
                infrastructureModelNew.InfrastructureTVText = TVText;

                infrastructureModelRet = infrastructureService.PostAddInfrastructureDB(infrastructureModelNew);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModelRet.Error}");
                }

                // changing comment (EN)
                InfrastructureLanguageModel infrastructureLanguageModelEN = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet.InfrastructureID, LanguageEnum.en);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelEN.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelEN.Error}");
                }

                infrastructureLanguageModelEN.Comment = CommentEN;

                InfrastructureLanguageModel infrastructureLanguageModelENRet = infrastructureService._InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelEN);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelENRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelENRet.Error}");
                }

                // changing comment (FR)
                InfrastructureLanguageModel infrastructureLanguageModelFR = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet.InfrastructureID, LanguageEnum.fr);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFR.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelFR.Error}");
                }

                infrastructureLanguageModelEN.Comment = CommentFR;

                InfrastructureLanguageModel infrastructureLanguageModelFRRet = infrastructureService._InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelFR);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFRRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelFRRet.Error}");
                }

                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat == null ? 0.0f : (float)Lat, Lng = Lng == null ? 0.0f : (float)Lng, Ordinal = 0 },
                };

                List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                foreach (MapInfoModel mapInfoModel in mapInfoModelList)
                {
                    MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet2.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoModelRet2.Error}");
                    }
                }

                MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, tvTypeInfrasturture, tvItemModelInfrastructure.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                {
                    return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                }

                List<Coord> coordListOutfall = new List<Coord>()
                {
                    new Coord() { Lat = LatOutfall == null ? 0.0f : (float)LatOutfall, Lng = LngOutfall == null ? 0.0f : (float)LngOutfall, Ordinal = 0 },
                };

                MapInfoModel mapInfoModelRetOutfall = mapInfoService.CreateMapInfoObjectDB(coordListOutfall, MapInfoDrawTypeEnum.Point, TVTypeEnum.Outfall, tvItemModelInfrastructure.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRetOutfall.Error))
                {
                    return ReturnError($"ERROR: {mapInfoModelRetOutfall.Error}");
                }

            }

            if (string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
            {
                // changing TVText if required
                TVItemModel tvItemModelInfrastructure = tvItemService.GetTVItemModelWithTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelInfrastructure.Error}");
                }

                tvItemModelInfrastructure.TVText = TVText;
                tvItemModelInfrastructure.IsActive = IsActive;

                TVItemModel tvItemModelInfrastructureRet = tvItemService.PostUpdateTVItemDB(tvItemModelInfrastructure);
                if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructureRet.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelInfrastructureRet.Error}");
                }

                List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(infrastructureModelRet.InfrastructureTVItemID);
                foreach (MapInfoModel mapInfoModel in mapInfoModelList)
                {
                    if (!(mapInfoModel.TVType == tvTypeInfrasturture || mapInfoModel.TVType == TVTypeEnum.Outfall))
                    {
                        MapInfoModel mapInfoModelRet2 = mapInfoService.PostDeleteMapInfoDB(mapInfoModel.MapInfoID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModelRet2.Error))
                        {
                            return ReturnError($"ERROR: {mapInfoModelRet2.Error}");
                        }
                    }
                }

                // changing Lat, Lng if required
                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat == null ? 0.0f : (float)Lat, Lng = Lng == null ? 0.0f : (float)Lng, Ordinal = 0 },
                };

                List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeInfrasturture, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count == 0)
                {
                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, tvTypeInfrasturture, infrastructureModelRet.InfrastructureTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                    }

                    mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, tvTypeInfrasturture, MapInfoDrawTypeEnum.Point);
                }

                if (mapInfoPointModelList[0].Lat != coordList[0].Lat || mapInfoPointModelList[0].Lng != coordList[0].Lng)
                {
                    mapInfoPointModelList[0].Lat = coordList[0].Lat;
                    mapInfoPointModelList[0].Lng = coordList[0].Lng;
                    MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelList[0]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoPointModelRet.Error}");
                    }
                }

                // changing LatOutfall, LngOutfall if required
                List<Coord> coordListOutfall = new List<Coord>()
                {
                    new Coord() { Lat = LatOutfall == null ? 0.0f : (float)LatOutfall, Lng = LngOutfall == null ? 0.0f : (float)LngOutfall, Ordinal = 0 },
                };
                List<MapInfoPointModel> mapInfoPointModelOufallList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
                if (mapInfoPointModelList.Count == 0)
                {
                    MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordListOutfall, MapInfoDrawTypeEnum.Point, TVTypeEnum.Outfall, infrastructureModelRet.InfrastructureTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                    }
                    mapInfoPointModelOufallList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(infrastructureModelRet.InfrastructureTVItemID, TVTypeEnum.Outfall, MapInfoDrawTypeEnum.Point);
                }

                if (mapInfoPointModelOufallList[0].Lat != coordListOutfall[0].Lat || mapInfoPointModelOufallList[0].Lng != coordListOutfall[0].Lng)
                {
                    mapInfoPointModelOufallList[0].Lat = coordListOutfall[0].Lat;
                    mapInfoPointModelOufallList[0].Lng = coordListOutfall[0].Lng;

                    MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelOufallList[0]);
                    if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                    {
                        return ReturnError($"ERROR: {mapInfoPointModelRet.Error}");
                    }
                }

                // changing Infrastructure
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModelRet.Error}");
                }

                infrastructureModelRet.InfrastructureType = InfrastructureType;

                if (InfrastructureType == InfrastructureTypeEnum.WWTP)
                {
                    infrastructureModelRet.FacilityType = FacilityType;
                    infrastructureModelRet.PreliminaryTreatmentType = PreliminaryTreatmentType;
                    infrastructureModelRet.PrimaryTreatmentType = PrimaryTreatmentType;
                    infrastructureModelRet.SecondaryTreatmentType = SecondaryTreatmentType;
                    infrastructureModelRet.TertiaryTreatmentType = TertiaryTreatmentType;
                    infrastructureModelRet.DisinfectionType = DisinfectionType;
                    infrastructureModelRet.CollectionSystemType = CollectionSystemType;
                    infrastructureModelRet.AlarmSystemType = AlarmSystemType;
                    infrastructureModelRet.NumberOfCells = NumberOfCells;
                    infrastructureModelRet.NumberOfAeratedCells = NumberOfAeratedCells;
                    infrastructureModelRet.IsMechanicallyAerated = IsMechanicallyAerated;
                    infrastructureModelRet.AerationType = AerationType;
                    infrastructureModelRet.DesignFlow_m3_day = DesignFlow_m3_day;
                    infrastructureModelRet.AverageFlow_m3_day = AverageFlow_m3_day;
                    infrastructureModelRet.PeakFlow_m3_day = PeakFlow_m3_day;
                    infrastructureModelRet.PopServed = PopServed;
                    infrastructureModelRet.CanOverflow = CanOverflow;
                    infrastructureModelRet.PercFlowOfTotal = PercFlowOfTotal;
                    infrastructureModelRet.AverageDepth_m = AverageDepth_m;
                    infrastructureModelRet.NumberOfPorts = NumberOfPorts;
                    infrastructureModelRet.PortDiameter_m = PortDiameter_m;
                    infrastructureModelRet.PortSpacing_m = PortSpacing_m;
                    infrastructureModelRet.PortElevation_m = PortElevation_m;
                    infrastructureModelRet.VerticalAngle_deg = VerticalAngle_deg;
                    infrastructureModelRet.HorizontalAngle_deg = HorizontalAngle_deg;
                    infrastructureModelRet.DecayRate_per_day = DecayRate_per_day;
                    infrastructureModelRet.NearFieldVelocity_m_s = NearFieldVelocity_m_s;
                    infrastructureModelRet.FarFieldVelocity_m_s = FarFieldVelocity_m_s;
                    infrastructureModelRet.ReceivingWaterSalinity_PSU = ReceivingWaterSalinity_PSU;
                    infrastructureModelRet.ReceivingWaterTemperature_C = ReceivingWaterTemperature_C;
                    infrastructureModelRet.ReceivingWater_MPN_per_100ml = ReceivingWater_MPN_per_100ml;
                    infrastructureModelRet.DistanceFromShore_m = DistanceFromShore_m;
                }
                else if (InfrastructureType == InfrastructureTypeEnum.LiftStation || InfrastructureType == InfrastructureTypeEnum.LineOverflow)
                {
                    infrastructureModelRet.FacilityType = null;
                    infrastructureModelRet.PreliminaryTreatmentType = null;
                    infrastructureModelRet.PrimaryTreatmentType = null;
                    infrastructureModelRet.SecondaryTreatmentType = null;
                    infrastructureModelRet.TertiaryTreatmentType = null;
                    infrastructureModelRet.DisinfectionType = null;
                    infrastructureModelRet.CollectionSystemType = null;
                    infrastructureModelRet.NumberOfAeratedCells = null;
                    infrastructureModelRet.IsMechanicallyAerated = null;
                    infrastructureModelRet.AerationType = null;
                    infrastructureModelRet.DesignFlow_m3_day = null;
                    infrastructureModelRet.AverageFlow_m3_day = null;
                    infrastructureModelRet.PeakFlow_m3_day = null;
                    infrastructureModelRet.PopServed = null;
                    infrastructureModelRet.AverageDepth_m = AverageDepth_m;
                    infrastructureModelRet.NumberOfPorts = NumberOfPorts;
                    infrastructureModelRet.PortDiameter_m = PortDiameter_m;
                    infrastructureModelRet.PortSpacing_m = PortSpacing_m;
                    infrastructureModelRet.PortElevation_m = PortElevation_m;
                    infrastructureModelRet.VerticalAngle_deg = VerticalAngle_deg;
                    infrastructureModelRet.HorizontalAngle_deg = HorizontalAngle_deg;
                    infrastructureModelRet.DecayRate_per_day = DecayRate_per_day;
                    infrastructureModelRet.NearFieldVelocity_m_s = NearFieldVelocity_m_s;
                    infrastructureModelRet.FarFieldVelocity_m_s = FarFieldVelocity_m_s;
                    infrastructureModelRet.ReceivingWaterSalinity_PSU = ReceivingWaterSalinity_PSU;
                    infrastructureModelRet.ReceivingWaterTemperature_C = ReceivingWaterTemperature_C;
                    infrastructureModelRet.ReceivingWater_MPN_per_100ml = ReceivingWater_MPN_per_100ml;
                    infrastructureModelRet.DistanceFromShore_m = DistanceFromShore_m;
                }
                else
                {
                    infrastructureModelRet.FacilityType = null;
                    infrastructureModelRet.PreliminaryTreatmentType = null;
                    infrastructureModelRet.PrimaryTreatmentType = null;
                    infrastructureModelRet.SecondaryTreatmentType = null;
                    infrastructureModelRet.TertiaryTreatmentType = null;
                    infrastructureModelRet.DisinfectionType = null;
                    infrastructureModelRet.CollectionSystemType = null;
                    infrastructureModelRet.NumberOfAeratedCells = null;
                    infrastructureModelRet.IsMechanicallyAerated = null;
                    infrastructureModelRet.AerationType = null;
                    infrastructureModelRet.DesignFlow_m3_day = null;
                    infrastructureModelRet.AverageFlow_m3_day = null;
                    infrastructureModelRet.PeakFlow_m3_day = null;
                    infrastructureModelRet.PopServed = null;
                    infrastructureModelRet.AverageDepth_m = null;
                    infrastructureModelRet.NumberOfPorts = null;
                    infrastructureModelRet.PortDiameter_m = null;
                    infrastructureModelRet.PortSpacing_m = null;
                    infrastructureModelRet.PortElevation_m = null;
                    infrastructureModelRet.VerticalAngle_deg = null;
                    infrastructureModelRet.HorizontalAngle_deg = null;
                    infrastructureModelRet.DecayRate_per_day = null;
                    infrastructureModelRet.NearFieldVelocity_m_s = null;
                    infrastructureModelRet.FarFieldVelocity_m_s = null;
                    infrastructureModelRet.ReceivingWaterSalinity_PSU = null;
                    infrastructureModelRet.ReceivingWaterTemperature_C = null;
                    infrastructureModelRet.ReceivingWater_MPN_per_100ml = null;
                    infrastructureModelRet.DistanceFromShore_m = null;
                }

                if (InfrastructureType == InfrastructureTypeEnum.LiftStation || InfrastructureType == InfrastructureTypeEnum.LineOverflow)
                {
                    infrastructureModelRet.AlarmSystemType = AlarmSystemType;
                    infrastructureModelRet.CanOverflow = CanOverflow;
                    infrastructureModelRet.PercFlowOfTotal = PercFlowOfTotal;
                }

                if (InfrastructureType == InfrastructureTypeEnum.SeeOtherMunicipality)
                {
                    if (SeeOtherMunicipalityTVItemID != null && SeeOtherMunicipalityTVItemID != 0)
                    {
                        infrastructureModelRet.SeeOtherMunicipalityTVItemID = SeeOtherMunicipalityTVItemID;
                    }
                }
                else
                {
                    infrastructureModelRet.SeeOtherMunicipalityTVItemID = null;
                }

                InfrastructureModel infrastructureModelRet2 = infrastructureService.PostUpdateInfrastructureDB(infrastructureModelRet);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet2.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModelRet2.Error}");
                }

                // changing comment (EN) if required
                InfrastructureLanguageModel infrastructureLanguageModelEN = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet2.InfrastructureID, LanguageEnum.en);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelEN.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelEN.Error}");
                }

                if (infrastructureLanguageModelEN.Comment != CommentEN)
                {
                    infrastructureLanguageModelEN.Comment = CommentEN;

                    InfrastructureLanguageModel infrastructureLanguageModelENRet = infrastructureService._InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelEN);
                    if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelENRet.Error))
                    {
                        return ReturnError($"ERROR: {infrastructureLanguageModelENRet.Error}");
                    }
                }

                // changing comment (FR)
                InfrastructureLanguageModel infrastructureLanguageModelFR = infrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModelRet2.InfrastructureID, LanguageEnum.fr);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFR.Error))
                {
                    return ReturnError($"ERROR: {infrastructureLanguageModelFR.Error}");
                }

                if (infrastructureLanguageModelFR.Comment != CommentFR)
                {
                    infrastructureLanguageModelFR.Comment = CommentFR;

                    InfrastructureLanguageModel infrastructureLanguageModelFRRet = infrastructureService._InfrastructureLanguageService.PostUpdateInfrastructureLanguageDB(infrastructureLanguageModelFR);
                    if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFRRet.Error))
                    {
                        return ReturnError($"ERROR: {infrastructureLanguageModelFRRet.Error}");
                    }
                }

                if (PumpsToTVItemID != null && PumpsToTVItemID > 0)
                {
                    List<int> TVItemLinkIDListToDelete = new List<int>();

                    List<TVItemLinkModel> tvItemLinkModelList = tvItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(infrastructureModelRet2.InfrastructureTVItemID);
                    foreach (TVItemLinkModel tvItemLinkModel2 in tvItemLinkModelList)
                    {
                        if (tvItemLinkModel2.FromTVType == TVTypeEnum.Infrastructure && tvItemLinkModel2.ToTVType == TVTypeEnum.Infrastructure)
                        {
                            if (tvItemLinkModel2.ToTVItemID != PumpsToTVItemID)
                            {
                                TVItemLinkIDListToDelete.Add(tvItemLinkModel2.TVItemLinkID);
                            }
                        }
                    }

                    foreach (int tvItemLinkIDToDelete in TVItemLinkIDListToDelete)
                    {
                        TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostDeleteTVItemLinkWithTVItemLinkIDDB(tvItemLinkIDToDelete);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                        {
                            return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                        }
                    }

                    TVItemLinkModel tvItemLinkModel = tvItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(infrastructureModelRet2.InfrastructureTVItemID, (int)PumpsToTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    {
                        TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                        {
                            FromTVItemID = infrastructureModelRet2.InfrastructureTVItemID,
                            ToTVItemID = (int)PumpsToTVItemID,
                            FromTVType = TVTypeEnum.Infrastructure,
                            ToTVType = TVTypeEnum.Infrastructure,
                            StartDateTime_Local = DateTime.UtcNow.AddDays(-1),
                            EndDateTime_Local = DateTime.UtcNow,
                            Ordinal = 0,
                            TVLevel = 0,
                            TVPath = "p" + infrastructureModelRet2.InfrastructureTVItemID + "p" + PumpsToTVItemID,
                        };

                        TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                        {
                            return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                        }
                    }
                    else
                    {
                        tvItemLinkModel.FromTVItemID = infrastructureModelRet2.InfrastructureTVItemID;
                        tvItemLinkModel.ToTVItemID = (int)PumpsToTVItemID;
                        tvItemLinkModel.FromTVType = TVTypeEnum.Infrastructure;
                        tvItemLinkModel.ToTVType = TVTypeEnum.Infrastructure;
                        tvItemLinkModel.StartDateTime_Local = DateTime.UtcNow.AddDays(-1);
                        tvItemLinkModel.EndDateTime_Local = DateTime.UtcNow;
                        tvItemLinkModel.Ordinal = 0;
                        tvItemLinkModel.TVLevel = 0;
                        tvItemLinkModel.TVPath = "p" + infrastructureModelRet2.InfrastructureTVItemID + "p" + PumpsToTVItemID;

                        TVItemLinkModel tvItemLinkModelRet = tvItemLinkService.PostUpdateTVItemLinkDB(tvItemLinkModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModelRet.Error))
                        {
                            return ReturnError($"ERROR: {tvItemLinkModelRet.Error}");
                        }
                    }
                }

            }

            return ReturnError($"{infrastructureModelRet.InfrastructureTVItemID}");
        }
        public TVItemModel CreateNewPollutionSourceSiteDB(int SubsectorTVItemID, int TVItemID, string TVText, int SiteNumber, float Lat, float Lng, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);
            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, user);

            if (SubsectorTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.SubsectorTVItemID)}");
            }

            TVItemModel tvItemModelSS = tvItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSS.Error))
            {
                return ReturnError($"ERROR: {tvItemModelSS.Error}");
            }

            if (TVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            if (string.IsNullOrWhiteSpace(TVText))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._IsRequired, ServiceRes.TVText)}");
            }



            PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
            if (TVItemID >= 10000000 || !string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
            {
                int Site = polSourceSiteService.GetNextAvailableSiteNumberWithParentTVItemIDDB(SubsectorTVItemID);

                TVText = TVText.Replace("000000".Substring(0, SiteNumber.ToString().Length) + SiteNumber.ToString(), "000000".Substring(0, Site.ToString().Length) + Site.ToString());
                TVItemModel tvItemModelPSS = tvItemService.PostAddChildTVItemDB(SubsectorTVItemID, TVText, TVTypeEnum.PolSourceSite);
                if (!string.IsNullOrWhiteSpace(tvItemModelPSS.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelPSS.Error}");
                }

                PolSourceSiteModel polSourceSiteModelNew = new PolSourceSiteModel();
                polSourceSiteModelNew.PolSourceSiteTVItemID = tvItemModelPSS.TVItemID;
                polSourceSiteModelNew.PolSourceSiteTVText = TVText;
                polSourceSiteModelNew.IsPointSource = false;
                polSourceSiteModelNew.Site = Site;

                polSourceSiteModelRet = polSourceSiteService.PostAddPolSourceSiteDB(polSourceSiteModelNew);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                {
                    return ReturnError($"ERROR: {polSourceSiteModelRet.Error}");
                }

                List<Coord> coordList = new List<Coord>()
                {
                    new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                };

                MapInfoModel mapInfoModelRet = mapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.PolSourceSite, tvItemModelPSS.TVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModelRet.Error))
                {
                    return ReturnError($"ERROR: {mapInfoModelRet.Error}");
                }
            }
            else
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._NeedToBeMoreThan_, ServiceRes.TVItemID, "10000000")}");
            }

            return ReturnError($"{polSourceSiteModelRet.PolSourceSiteTVItemID}");
        }
        public TVItemModel CreateNewObsDateDB(int PSSTVItemID, DateTime NewObsDate, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);
            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, user);

            if (PSSTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }

            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(PSSTVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
            {
                return ReturnError($"ERROR: {polSourceSiteModel.Error}");
            }

            if (NewObsDate.Year < 1980 || NewObsDate > DateTime.Now)
            {
                return ReturnError($"ERROR: {ServiceRes.DateOfObservationShouldBeBetween1980AndToday}");
            }

            PolSourceObservationModel polSourceObservationModelNew = new PolSourceObservationModel();
            polSourceObservationModelNew.PolSourceSiteTVItemID = PSSTVItemID;
            polSourceObservationModelNew.PolSourceSiteID = polSourceSiteModel.PolSourceSiteID;
            polSourceObservationModelNew.ContactTVItemID = contactModel.ContactTVItemID;
            polSourceObservationModelNew.ObservationDate_Local = NewObsDate;
            polSourceObservationModelNew.Observation_ToBeDeleted = "-";

            PolSourceObservationModel polSourceObservationModelRet = polSourceObservationService.PostAddPolSourceObservationDB(polSourceObservationModelNew);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModelRet.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationModelRet.Error}");
            }

            return ReturnError($"{polSourceObservationModelRet.PolSourceObservationID}");
        }
        public TVItemModel RemoveIssueDB(int ObsID, int IssueID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, user);
            PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, user);

            if (ObsID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }
            if (ObsID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "ObsID", "10000000")}");
            }

            PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(ObsID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationModel.Error}");
            }

            if (IssueID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }

            List<PolSourceObservationIssueModel> polSourceObservationIssueModelList = polSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(ObsID);

            bool DidDelete = false;
            foreach (PolSourceObservationIssueModel polSourceObservationIssueModel in polSourceObservationIssueModelList)
            {
                if (polSourceObservationIssueModel.PolSourceObservationIssueID == IssueID)
                {
                    PolSourceObservationIssueModel polSourceObservationIssueModelRet = polSourceObservationIssueService.GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(IssueID);
                    if (string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet.Error))
                    {
                        PolSourceObservationIssueModel polSourceObservationIssueModelRetDel = polSourceObservationIssueService.PostDeletePolSourceObservationIssueDB(IssueID);
                        if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRetDel.Error))
                        {
                            return ReturnError(polSourceObservationIssueModelRetDel.Error);
                        }

                    }


                    DidDelete = true;
                }
            }

            if (!DidDelete)
            {
                return ReturnError("ERROR: Issue already deleted");
            }

            return ReturnError("");

        }
        public TVItemModel SavePSSOrInfrastructureAddressDB(int ProvinceTVItemID, int TVItemID, string StreetNumber, string StreetName, int StreetType, string Municipality, string PostalCode, bool CreateMunicipality, bool IsPSS, bool IsInfrastructure, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            AddressService addressService = new AddressService(LanguageRequest, user);
            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);
            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, user);

            // doing Province
            if (ProvinceTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.ProvinceTVItemID)}");
            }

            TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProvince.Error))
            {
                return ReturnError($"ERROR: {tvItemModelProvince.Error}");
            }

            if (TVItemID == 0)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID));
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000"));
            }

            if (string.IsNullOrWhiteSpace(Municipality))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Municipality));
            }

            if (IsPSS)
            {
                PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                {
                    return ReturnError($"ERROR: {polSourceSiteModel.Error}");
                }
            }

            if (IsInfrastructure)
            {
                InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModel.Error}");
                }
            }

            TVItemModel tvItemModelMunicipality = new TVItemModel();
            if (CreateMunicipality)
            {
                tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                {
                    tvItemModelMunicipality = tvItemService.PostAddChildTVItemDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                    if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                    {
                        return ReturnError($"ERROR: {string.Format(ServiceRes.CouldNotCreateMunicipality_, Municipality)}");
                    }
                }
            }
            else
            {
                tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
                if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                {
                    return ReturnError($"ERROR: {string.Format(ServiceRes.CouldNotFindMunicipality_, Municipality)}");
                }
            }

            List<TVItemModel> tvItemModelParents = tvItemService.GetParentsTVItemModelList(tvItemModelMunicipality.TVPath);

            AddressModel addressModelNew = new AddressModel();
            addressModelNew.AddressType = AddressTypeEnum.Civic;
            addressModelNew.StreetNumber = StreetNumber;
            addressModelNew.StreetName = StreetName;
            addressModelNew.StreetType = (StreetTypeEnum)StreetType;
            addressModelNew.MunicipalityTVItemID = tvItemModelMunicipality.TVItemID;
            addressModelNew.ProvinceTVItemID = tvItemModelProvince.TVItemID;
            addressModelNew.CountryTVItemID = tvItemModelProvince.ParentID;
            addressModelNew.PostalCode = PostalCode;

            string TVTextAddress = addressService.CreateTVText(addressModelNew);

            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
            {
                return ReturnError($"ERROR: {tvItemModelRoot.Error}");
            }

            AddressModel addressModelRet = new AddressModel();
            AddressModel addressModelRet2 = addressService.GetAddressModelExistDB(addressModelNew);
            if (!string.IsNullOrWhiteSpace(addressModelRet2.Error))
            {
                TVItemModel tvItemModelAddress = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVTextAddress, TVTypeEnum.Address);
                if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                {
                    return ReturnError($"ERROR: {tvItemModelAddress.Error}");
                }

                addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

                addressModelRet = addressService.PostAddAddressDB(addressModelNew);
                if (!string.IsNullOrWhiteSpace(addressModelRet.Error))
                {
                    return ReturnError($"ERROR: {addressModelRet.Error}");
                }
            }

            if (IsPSS)
            {
                PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                {
                    return ReturnError($"ERROR: {polSourceSiteModel.Error}");
                }

                polSourceSiteModel.CivicAddressTVItemID = addressModelRet.AddressTVItemID;
                PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                {
                    return ReturnError($"ERROR: {polSourceSiteModelRet.Error}");
                }
            }

            if (IsInfrastructure)
            {
                InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
                if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModel.Error}");
                }

                infrastructureModel.CivicAddressTVItemID = addressModelRet.AddressTVItemID;
                InfrastructureModel infrastructureModelRet = infrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                {
                    return ReturnError($"ERROR: {infrastructureModelRet.Error}");
                }
            }

            return ReturnError($"{addressModelRet.AddressTVItemID}");
        }
        public TVItemModel SaveLatLngWithTVTypeDB(int TVItemID, float Lat, float Lng, TVTypeEnum TVType, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, user);

            if (TVItemID == 0)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID));
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000"));
            }

            List<MapInfoModel> mapInfoModelList = mapInfoService.GetMapInfoModelListWithTVItemIDDB(TVItemID);

            foreach (MapInfoModel mapInfoModel in mapInfoModelList)
            {
                if (mapInfoModel.TVType == TVType)
                {
                    if (mapInfoModel.MapInfoDrawType == MapInfoDrawTypeEnum.Point)
                    {
                        List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemID, TVType, MapInfoDrawTypeEnum.Point);

                        if (mapInfoPointModelList.Count > 0)
                        {
                            foreach (MapInfoPointModel mapInfoPointModel in mapInfoPointModelList)
                            {
                                if (mapInfoPointModel.Lat != Lat || mapInfoPointModel.Lng != Lng)
                                {
                                    mapInfoPointModel.Lat = Lat;
                                    mapInfoPointModel.Lng = Lng;

                                    MapInfoPointModel mapInfoPointModelRet = mapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModel);
                                    if (!string.IsNullOrWhiteSpace(mapInfoPointModel.Error))
                                    {
                                        return ReturnError(mapInfoPointModel.Error);
                                    }
                                }

                                break; // just do first
                            }

                        }
                        break;
                    }
                }
            }

            return ReturnError("");
        }
        public TVItemModel SavePictureInfoDB(int TVItemID, int PictureTVItemID, string FileName, string Description, string Extension, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVFileService tvFileService = new TVFileService(LanguageRequest, user);

            if (TVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000")}");
            }

            TVItemModel tvItemModelPSS = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelPSS.Error))
            {
                return ReturnError($"ERROR: {tvItemModelPSS.Error}");
            }

            if (PictureTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "PictureTVItemID")}");
            }

            if (PictureTVItemID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "PictureTVItemID", "10000000")}");
            }

            TVFileModel tvFileModelPicture = tvFileService.GetTVFileModelWithTVFileTVItemIDDB(PictureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelPicture.Error))
            {
                return ReturnError($"ERROR: {tvFileModelPicture.Error}");
            }

            FileInfo fi = new FileInfo(tvFileModelPicture.ServerFilePath + tvFileModelPicture.ServerFileName);

            if (!fi.Exists)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.File_DoesNotExist, fi.FullName)}");
            }

            tvFileModelPicture.ServerFileName = FileName + Extension;
            tvFileModelPicture.FileDescription = Description;

            TVFileModel tvFileModelPictureRet = tvFileService.PostUpdateTVFileDB(tvFileModelPicture);
            if (!string.IsNullOrWhiteSpace(tvFileModelPictureRet.Error))
            {
                return ReturnError($"ERROR: {tvFileModelPictureRet.Error}");
            }

            return ReturnError($"{tvFileModelPictureRet.TVFileTVItemID}");

        }
        public TVItemModel RemovePictureDB(int TVItemID, int PictureTVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVFileService tvFileService = new TVFileService(LanguageRequest, user);

            if (TVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID)}");
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000")}");
            }

            TVItemModel tvItemModelPSS = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelPSS.Error))
            {
                return ReturnError($"ERROR: {tvItemModelPSS.Error}");
            }

            if (PictureTVItemID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "PictureTVItemID")}");
            }

            if (PictureTVItemID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "PictureTVItemID", "10000000")}");
            }

            TVFileModel tvFileModelPicture = tvFileService.GetTVFileModelWithTVFileTVItemIDDB(PictureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelPicture.Error))
            {
                return ReturnError($"ERROR: {tvFileModelPicture.Error}");
            }

            TVFileModel tvFileModelRet = tvFileService.PostDeleteTVFileWithTVItemIDDB(PictureTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
            {
                return ReturnError($"ERROR: {tvFileModelRet.Error}");
            }

            return ReturnError($"");

        }
        public TVItemModel SavePSSObsIssueDB(int ObsID, int IssueID, int Ordinal, string ObservationInfo, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, user);
            PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, user);

            if (ObsID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }
            if (ObsID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "ObsID", "10000000")}");
            }

            PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(ObsID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationModel.Error}");
            }

            if (IssueID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }

            List<PolSourceObservationIssueModel> polSourceObservationIssueModelList = polSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(ObsID);

            PolSourceObservationIssueModel polSourceObservationIssueModelExist = null;
            foreach (PolSourceObservationIssueModel polSourceObservationIssueModel in polSourceObservationIssueModelList)
            {
                if (polSourceObservationIssueModel.PolSourceObservationIssueID == IssueID)
                {
                    polSourceObservationIssueModelExist = polSourceObservationIssueModel;
                    break;
                }
            }

            PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = new PolSourceObservationIssueModel();
            if (polSourceObservationIssueModelExist != null)
            {
                polSourceObservationIssueModelExist.Ordinal = Ordinal;
                polSourceObservationIssueModelExist.ObservationInfo = ObservationInfo;
                polSourceObservationIssueModelExist.PolSourceObsInfoList = ObservationInfo.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => (PolSourceObsInfoEnum)int.Parse(c)).ToList();

                polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModelExist);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet2.Error))
                {
                    return ReturnError($"ERROR: {polSourceObservationIssueModelRet2.Error}");
                }
            }
            else
            {
                PolSourceObservationIssueModel polSourceObservationIssueModelNew = new PolSourceObservationIssueModel();
                polSourceObservationIssueModelNew.PolSourceObservationID = ObsID;
                polSourceObservationIssueModelNew.Ordinal = Ordinal;
                polSourceObservationIssueModelNew.ObservationInfo = ObservationInfo;
                polSourceObservationIssueModelNew.PolSourceObsInfoList = ObservationInfo.Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(c => (PolSourceObsInfoEnum)int.Parse(c)).ToList();

                polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostAddPolSourceObservationIssueDB(polSourceObservationIssueModelNew);
                if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet2.Error))
                {
                    return ReturnError($"ERROR: {polSourceObservationIssueModelRet2.Error}");
                }
            }

            return ReturnError($"{polSourceObservationIssueModelRet2.PolSourceObservationIssueID}");

        }
        public TVItemModel SavePSSObsIssueExtraCommentDB(int ObsID, int IssueID, string ExtraComment, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            PolSourceObservationService polSourceObservationService = new PolSourceObservationService(LanguageRequest, user);
            PolSourceObservationIssueService polSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, user);

            if (ObsID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }
            if (ObsID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "ObsID", "10000000")}");
            }

            PolSourceObservationModel polSourceObservationModel = polSourceObservationService.GetPolSourceObservationModelWithPolSourceObservationIDDB(ObsID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationModel.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationModel.Error}");
            }

            if (IssueID == 0)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBe0, "ObsID")}");
            }
            if (IssueID >= 10000000)
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes._ShouldNotBeMoreThan_, "IssueID", "10000000")}");
            }

            PolSourceObservationIssueModel polSourceObservationIssueModel = polSourceObservationIssueService.GetPolSourceObservationIssueModelWithPolSourceObservationIssueIDDB(IssueID);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModel.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationIssueModel.Error}");
            }

            polSourceObservationIssueModel.ExtraComment = ExtraComment;

            PolSourceObservationIssueModel polSourceObservationIssueModelRet2 = polSourceObservationIssueService.PostUpdatePolSourceObservationIssueDB(polSourceObservationIssueModel);
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueModelRet2.Error))
            {
                return ReturnError($"ERROR: {polSourceObservationIssueModelRet2.Error}");
            }

            return ReturnError($"");

        }
        public TVItemModel SavePSSTVTextAndIsActiveDB(int TVItemID, string TVText, bool IsActive, bool IsPointSource, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, user);
            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);

            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemModel tvItemModel = tvItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
            {
                return ReturnError(tvItemModel.Error);
            }

            tvItemModel.IsActive = IsActive;

            TVItemModel tvItemModelRet = tvItemService.PostUpdateTVItemDB(tvItemModel);
            if (!string.IsNullOrWhiteSpace(tvItemModelRet.Error))
            {
                return ReturnError(tvItemModelRet.Error);
            }

            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
            polSourceSiteModel.IsPointSource = IsPointSource;

            PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
            {
                return ReturnError(polSourceSiteModelRet.Error);
            }

            MapInfoService mapInfoService = new MapInfoService(LanguageRequest, user);

            if (TVItemID == 0)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID));
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000"));
            }

            foreach (LanguageEnum lang in LanguageListAllowable)
            {
                TVItemLanguageModel tvItemLanguageModel = tvItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(TVItemID, lang);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                {
                    return ReturnError(tvItemLanguageModel.Error);
                }

                tvItemLanguageModel.TVText = TVText;

                TVItemLanguageModel tvItemLanguageModelRet = tvItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                if (!string.IsNullOrWhiteSpace(tvItemLanguageModelRet.Error))
                {
                    return ReturnError(tvItemLanguageModelRet.Error);
                }


            }

            return ReturnError("");
        }
        public TVItemModel UserExistDB(string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            return ReturnError("");
        }
        public TVItemModel InfrastructureExistDB(int TVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            InfrastructureService infrastructureService = new InfrastructureService(LanguageRequest, user);
            InfrastructureModel infrastructureModel = infrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
            {
                return ReturnError("ERROR: " + string.Format(ServiceRes._DoesNotExist, ServiceRes.Infrastructure));
            }

            return ReturnError("");
        }
        public TVItemModel PSSExistDB(int TVItemID, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            PolSourceSiteService polSourceSiteService = new PolSourceSiteService(LanguageRequest, user);
            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
            {
                return ReturnError("ERROR: " + string.Format(ServiceRes._DoesNotExist, ServiceRes.PolSourceSite));
            }

            return ReturnError("");
        }
        public TVItemModel MunicipalityExistDB(int ProvinceTVItemID, string Municipality, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemModel tvItemModelProvince = tvItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelProvince.Error))
            {
                return ReturnError("ERROR: " + tvItemModelProvince.Error);
            }

            TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(ProvinceTVItemID, Municipality, TVTypeEnum.Municipality);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
            {
                return ReturnError("ERROR: " + tvItemModelMunicipality.Error);
            }

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}