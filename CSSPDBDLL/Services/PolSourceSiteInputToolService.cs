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
        public TVItemModel SavePSSAddressDB(int SubsectorTVItemID, int TVItemID, string StreetNumber, string StreetName, int StreetType, string Municipality, string PostalCode, bool CreateMunicipality, string AdminEmail)
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
                return ReturnError(string.Format(ServiceRes._ShouldNotBe0, ServiceRes.TVItemID));
            }
            if (TVItemID >= 10000000)
            {
                return ReturnError(string.Format(ServiceRes._ShouldNotBeMoreThan_, ServiceRes.TVItemID, "10000000"));
            }

            PolSourceSiteModel polSourceSiteModel = polSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
            {
                return ReturnError($"ERROR: {polSourceSiteModel.Error}");
            }

            if (string.IsNullOrWhiteSpace(Municipality))
            {
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Municipality));
            }

            TVItemModel tvItemModelMunicipality = new TVItemModel();
            if (CreateMunicipality)
            {
                tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(SubsectorTVItemID, Municipality, TVTypeEnum.Municipality);
                if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                {
                    tvItemModelMunicipality = tvItemService.PostAddChildTVItemDB(SubsectorTVItemID, Municipality, TVTypeEnum.Municipality);
                    if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                    {
                        return ReturnError($"ERROR: {string.Format(ServiceRes.CouldNotCreateMunicipality_, Municipality)}");
                    }
                }
            }
            else
            {
                tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(SubsectorTVItemID, Municipality, TVTypeEnum.Municipality);
                if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
                {
                    return ReturnError($"ERROR: {string.Format(ServiceRes.CouldNotFindMunicipality_, Municipality)}");
                }
            }

            List<TVItemModel> tvItemModelParents = tvItemService.GetParentsTVItemModelList(tvItemModelMunicipality.TVPath);

            TVItemModel tvItemModelCountry = null;
            TVItemModel tvItemModelProvince = null;

            foreach (TVItemModel tvItemModel in tvItemModelParents)
            {
                if (tvItemModel.TVType == TVTypeEnum.Country)
                {
                    tvItemModelCountry = tvItemModel;
                }
                if (tvItemModel.TVType == TVTypeEnum.Province)
                {
                    tvItemModelProvince = tvItemModel;
                }
            }

            AddressModel addressModelNew = new AddressModel();
            addressModelNew.AddressType = AddressTypeEnum.Civic;
            addressModelNew.StreetNumber = StreetNumber;
            addressModelNew.StreetName = StreetName;
            addressModelNew.StreetType = (StreetTypeEnum)StreetType;
            addressModelNew.MunicipalityTVItemID = tvItemModelMunicipality.TVItemID;
            addressModelNew.ProvinceTVItemID = tvItemModelProvince.TVItemID;
            addressModelNew.CountryTVItemID = tvItemModelCountry.TVItemID;
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

            polSourceSiteModel.CivicAddressTVItemID = addressModelRet.AddressTVItemID;
            PolSourceSiteModel polSourceSiteModelRet = polSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
            {
                return ReturnError($"ERROR: {polSourceSiteModelRet.Error}");
            }

            return ReturnError($"{addressModelRet.AddressTVItemID}");
        }
        public TVItemModel SavePSSLatLngDB(int TVItemID, float Lat, float Lng, string AdminEmail)
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
                if (mapInfoModel.TVType == TVTypeEnum.PolSourceSite)
                {
                    if (mapInfoModel.MapInfoDrawType == MapInfoDrawTypeEnum.Point)
                    {
                        List<MapInfoPointModel> mapInfoPointModelList = mapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(TVItemID, TVTypeEnum.PolSourceSite, MapInfoDrawTypeEnum.Point);

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
        public TVItemModel SavePSSTVTextAndIsActiveDB(int TVItemID, string TVText, bool IsActive, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemLanguageService tvItemLanguageService = new TVItemLanguageService(LanguageRequest, user);

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
        public TVItemModel MunicipalityExistDB(int SubsectorTVItemID, string Municipality, string AdminEmail)
        {
            IPrincipal user = new GenericPrincipal(new GenericIdentity(AdminEmail, "Forms"), null);

            ContactService contactService = new ContactService(LanguageRequest, user);
            ContactModel contactModel = contactService.GetContactModelWithLoginEmailDB(AdminEmail);
            if (!string.IsNullOrWhiteSpace(contactModel.Error))
            {
                return ReturnError($"ERROR: {string.Format(ServiceRes.NoUserWithEmail_, AdminEmail)}");
            }

            TVItemService tvItemService = new TVItemService(LanguageRequest, user);
            TVItemModel tvItemModelSS = tvItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSS.Error))
            {
                return ReturnError("ERROR: " + tvItemModelSS.Error);
            }

            TVItemModel tvItemModelMunicipality = tvItemService.GetChildTVItemModelWithTVItemIDAndTVTextStartWithAndTVTypeDB(SubsectorTVItemID, Municipality, TVTypeEnum.Municipality);
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