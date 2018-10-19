using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;
using System.Web.Mvc;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services;
using CSSPEnumsDLL.Services.Resources;

namespace CSSPDBDLL.Services
{
    public class AddressService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public TVItemService _TVItemService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public PolSourceSiteService _PolSourceSiteService { get; private set; }
        public InfrastructureService _InfrastructureService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public LogService _LogService { get; private set; }

        #endregion Properties

        #region Constructors
        public AddressService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _TVItemService = new TVItemService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
            _PolSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
            _InfrastructureService = new InfrastructureService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
        }
        #endregion Constructors

        #region Functions public
        // Override
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
        public string AddressModelOK(AddressModel addressModel)
        {
            string retStr = FieldCheckIfNotNullMaxLengthString(addressModel.StreetName, ServiceRes.StreetName, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(addressModel.StreetNumber, ServiceRes.StreetNumber, 50);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(addressModel.MunicipalityTVItemID, ServiceRes.MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(addressModel.ProvinceTVItemID, ServiceRes.ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(addressModel.CountryTVItemID, ServiceRes.CountryTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.AddressTypeOK(addressModel.AddressType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.StreetTypeOK(addressModel.StreetType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotZeroInt(addressModel.AddressTVItemID, ServiceRes.AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(addressModel.GoogleAddressText, ServiceRes.GoogleAddressText, 200);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(addressModel.LatLngText, ServiceRes.LatLngText, 100);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillAddress(Address address, AddressModel addressModel, ContactOK contactOK)
        {
            address.AddressTVItemID = addressModel.AddressTVItemID;
            address.MunicipalityTVItemID = addressModel.MunicipalityTVItemID;
            address.ProvinceTVItemID = addressModel.ProvinceTVItemID;
            address.CountryTVItemID = addressModel.CountryTVItemID;
            address.StreetType = (int)addressModel.StreetType;
            address.AddressType = (int)addressModel.AddressType;
            address.StreetName = addressModel.StreetName;
            address.StreetNumber = addressModel.StreetNumber;
            address.PostalCode = addressModel.PostalCode;
            address.GoogleAddressText = addressModel.GoogleAddressText;
            address.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                address.LastUpdateContactTVItemID = 2;
            }
            else
            {
                address.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }

        // Get
        public int GetAddressModelCountDB()
        {
            int addressModelCount = (from c in db.Addresses
                                     select c).Count();

            return addressModelCount;
        }
        public AddressModel GetAddressModelWithAddressIDDB(int AddressID)
        {
            AddressModel addressModel = (from c in db.Addresses
                                         let muni = (from cl in db.TVItemLanguages where cl.TVItemID == c.MunicipalityTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let prov = (from cl in db.TVItemLanguages where cl.TVItemID == c.ProvinceTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let country = (from cl in db.TVItemLanguages where cl.TVItemID == c.CountryTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let mip = (from mi in db.MapInfos
                                                    from mip in db.MapInfoPoints
                                                    where mi.MapInfoID == mip.MapInfoID
                                                    && mi.TVItemID == c.AddressTVItemID
                                                    && mi.TVType == (int)TVTypeEnum.Address
                                                    && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                    select mip).FirstOrDefault()
                                         where c.AddressID == AddressID
                                         select new AddressModel
                                         {
                                             Error = "",
                                             AddressID = c.AddressID,
                                             AddressTVItemID = c.AddressTVItemID,
                                             AddressTVText = "",
                                             AddressType = (AddressTypeEnum)c.AddressType,
                                             AddressTypeText = "",
                                             MunicipalityTVItemID = c.MunicipalityTVItemID,
                                             MunicipalityTVText = muni,
                                             ProvinceTVItemID = c.ProvinceTVItemID,
                                             ProvinceTVText = prov,
                                             CountryTVItemID = c.CountryTVItemID,
                                             CountryTVText = country,
                                             StreetName = c.StreetName,
                                             StreetNumber = c.StreetNumber,
                                             StreetType = (StreetTypeEnum)c.StreetType,
                                             StreetTypeText = "",
                                             PostalCode = c.PostalCode,
                                             GoogleAddressText = c.GoogleAddressText,
                                             LatLngText = mip.Lat + " " + mip.Lng,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<AddressModel>();

            if (addressModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Address, ServiceRes.AddressID, AddressID));
            }
            else
            {
                addressModel.AddressTypeText = _BaseEnumService.GetEnumText_AddressTypeEnum(addressModel.AddressType);
                addressModel.StreetTypeText = _BaseEnumService.GetEnumText_StreetTypeEnum((StreetTypeEnum)addressModel.StreetType);
            }
            return addressModel;
        }
        public AddressModel GetAddressModelWithAddressTVItemIDDB(int AddressTVItemID)
        {
            AddressModel addressModel = (from c in db.Addresses
                                         let muni = (from cl in db.TVItemLanguages where cl.TVItemID == c.MunicipalityTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let prov = (from cl in db.TVItemLanguages where cl.TVItemID == c.ProvinceTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let country = (from cl in db.TVItemLanguages where cl.TVItemID == c.CountryTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let mip = (from mi in db.MapInfos
                                                    from mip in db.MapInfoPoints
                                                    where mi.MapInfoID == mip.MapInfoID
                                                    && mi.TVItemID == c.AddressTVItemID
                                                    && mi.TVType == (int)TVTypeEnum.Address
                                                    && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                    select mip).FirstOrDefault()
                                         where c.AddressTVItemID == AddressTVItemID
                                         select new AddressModel
                                         {
                                             Error = "",
                                             AddressID = c.AddressID,
                                             AddressTVItemID = c.AddressTVItemID,
                                             AddressTVText = "",
                                             AddressType = (AddressTypeEnum)c.AddressType,
                                             AddressTypeText = "",
                                             MunicipalityTVItemID = c.MunicipalityTVItemID,
                                             MunicipalityTVText = muni,
                                             ProvinceTVItemID = c.ProvinceTVItemID,
                                             ProvinceTVText = prov,
                                             CountryTVItemID = c.CountryTVItemID,
                                             CountryTVText = country,
                                             StreetName = c.StreetName,
                                             StreetNumber = c.StreetNumber,
                                             StreetType = (StreetTypeEnum)c.StreetType,
                                             StreetTypeText = "",
                                             PostalCode = c.PostalCode,
                                             GoogleAddressText = c.GoogleAddressText,
                                             LatLngText = mip.Lat + " " + mip.Lng,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<AddressModel>();

            if (addressModel == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Address, ServiceRes.AddressTVItemID, AddressTVItemID));
            }
            else
            {
                addressModel.AddressTypeText = _BaseEnumService.GetEnumText_AddressTypeEnum(addressModel.AddressType);
                addressModel.StreetTypeText = _BaseEnumService.GetEnumText_StreetTypeEnum((StreetTypeEnum)addressModel.StreetType);
            }
            return addressModel;
        }
        public Address GetAddressWithAddressIDDB(int AddressID)
        {
            Address address = (from c in db.Addresses
                               where c.AddressID == AddressID
                               select c).FirstOrDefault<Address>();
            return address;
        }
        public AddressModel GetAddressModelExistDB(AddressModel addressModel)
        {
            AddressModel addressModelRet = (from c in db.Addresses
                                         let muni = (from cl in db.TVItemLanguages where cl.TVItemID == c.MunicipalityTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let prov = (from cl in db.TVItemLanguages where cl.TVItemID == c.ProvinceTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let country = (from cl in db.TVItemLanguages where cl.TVItemID == c.CountryTVItemID && cl.Language == (int)LanguageRequest select cl.TVText).FirstOrDefault<string>()
                                         let mip = (from mi in db.MapInfos
                                                    from mip in db.MapInfoPoints
                                                    where mi.MapInfoID == mip.MapInfoID
                                                    && mi.TVItemID == c.AddressTVItemID
                                                    && mi.TVType == (int)TVTypeEnum.Address
                                                    && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                                    select mip).FirstOrDefault()
                                         where c.StreetNumber == addressModel.StreetNumber
                                         && c.StreetName == addressModel.StreetName
                                         && c.StreetType == (int)addressModel.StreetType
                                         && c.MunicipalityTVItemID == addressModel.MunicipalityTVItemID
                                         && c.ProvinceTVItemID == addressModel.ProvinceTVItemID
                                         && c.CountryTVItemID == addressModel.CountryTVItemID
                                         && c.PostalCode == addressModel.PostalCode
                                            select new AddressModel
                                         {
                                             Error = "",
                                             AddressID = c.AddressID,
                                             AddressTVItemID = c.AddressTVItemID,
                                             AddressTVText = "",
                                             AddressType = (AddressTypeEnum)c.AddressType,
                                             AddressTypeText = "",
                                             MunicipalityTVItemID = c.MunicipalityTVItemID,
                                             MunicipalityTVText = muni,
                                             ProvinceTVItemID = c.ProvinceTVItemID,
                                             ProvinceTVText = prov,
                                             CountryTVItemID = c.CountryTVItemID,
                                             CountryTVText = country,
                                             StreetName = c.StreetName,
                                             StreetNumber = c.StreetNumber,
                                             StreetType = (StreetTypeEnum)c.StreetType,
                                             StreetTypeText = "",
                                             PostalCode = c.PostalCode,
                                             GoogleAddressText = c.GoogleAddressText,
                                             LatLngText = mip.Lat + " " + mip.Lng,
                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                         }).FirstOrDefault<AddressModel>();

            if (addressModelRet == null)
            {
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.Address, 
                    ServiceRes.StreetNumber + ", " +
                    ServiceRes.StreetName + ", " +
                    ServiceRes.StreetType + ", " +
                    ServiceRes.MunicipalityTVItemID + ", " +
                    ServiceRes.ProvinceTVItemID + ", " +
                    ServiceRes.CountryTVItemID, 
                    addressModel.StreetNumber + ", " +
                    addressModel.StreetName + ", " +
                    addressModel.StreetType + ", " +
                    addressModel.MunicipalityTVItemID + ", " +
                    addressModel.ProvinceTVItemID + ", " +
                    addressModel.CountryTVItemID));
            }
            else
            {
                addressModelRet.AddressTypeText = _BaseEnumService.GetEnumText_AddressTypeEnum(addressModel.AddressType);
                addressModelRet.StreetTypeText = _BaseEnumService.GetEnumText_StreetTypeEnum((StreetTypeEnum)addressModel.StreetType);
            }

            return addressModelRet;
        }

        // Helper
        public string CreateTVText(AddressModel addressModel)
        {
            return addressModel.StreetNumber + " " + addressModel.StreetName + " [" + addressModel.CountryTVItemID + "," + addressModel.ProvinceTVItemID + "," + addressModel.MunicipalityTVItemID + "," + addressModel.StreetType.ToString() + "]";
        }
        public AddressModel ReturnError(string Error)
        {
            return new AddressModel() { Error = Error };
        }

        // Post
        public AddressModel PostAddOrModifyDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ContactTVItemID = 0;
            int AddressTVItemID = 0;
            int CountryTVItemID = 0;
            int ProvinceTVItemID = 0;
            int MunicipalityTVItemID = 0;
            int StreetTypeInt = 0;
            StreetTypeEnum StreetType = StreetTypeEnum.Error;
            string StreetName = "";
            string StreetNumber = "";
            int AddressTypeInt = 0;
            AddressTypeEnum AddressType = AddressTypeEnum.Error;
            string PostalCode = "";
            string GoogleAddressText = "";
            string LatLngText = "";
            float Lat = 0.0f;
            float Lng = 0.0f;

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            if (ContactTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            int.TryParse(fc["AddressTVItemID"], out AddressTVItemID);
            // if 0 then want to add new TVItem else want to modify

            int.TryParse(fc["CountryTVItemID"], out CountryTVItemID);
            if (CountryTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.CountryTVItemID));

            int.TryParse(fc["ProvinceTVItemID"], out ProvinceTVItemID);
            if (ProvinceTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID));

            int.TryParse(fc["MunicipalityTVItemID"], out MunicipalityTVItemID);
            if (MunicipalityTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID));

            int.TryParse(fc["StreetType"], out StreetTypeInt);
            if (StreetTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetType));

            StreetType = (StreetTypeEnum)StreetTypeInt;

            StreetNumber = fc["StreetNumber"];
            if (string.IsNullOrWhiteSpace(StreetNumber))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetNumber));

            StreetName = fc["StreetName"];
            if (string.IsNullOrWhiteSpace(StreetName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetName));

            int.TryParse(fc["AddressType"], out AddressTypeInt);
            if (AddressTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AddressType));

            AddressType = (AddressTypeEnum)AddressTypeInt;

            PostalCode = fc["PostalCode"];
            if (PostalCode == null)
                PostalCode = "";

            GoogleAddressText = fc["GoogleAddressText"];
            if (GoogleAddressText == null)
                GoogleAddressText = "";

            LatLngText = fc["LatLngText"];
            if (LatLngText == null)
                LatLngText = "";

            if (!string.IsNullOrWhiteSpace(LatLngText))
            {
                LatLngText = LatLngText.Trim();
                Lat = float.Parse(LatLngText.Substring(0, LatLngText.IndexOfAny(", ".ToCharArray())));
                Lng = float.Parse(LatLngText.Substring(LatLngText.LastIndexOfAny(", ".ToCharArray())));
            }

            AddressModel addressModel = new AddressModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (AddressTVItemID == 0)
                {
                    TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
                    if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                        return ReturnError(tvItemModelRoot.Error);

                    TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                        return ReturnError(tvItemModelContact.Error);

                    AddressModel addressModelNew = new AddressModel()
                    {
                        CountryTVItemID = CountryTVItemID,
                        ProvinceTVItemID = ProvinceTVItemID,
                        MunicipalityTVItemID = MunicipalityTVItemID,
                        StreetName = StreetName,
                        StreetNumber = StreetNumber,
                        StreetType = StreetType,
                        AddressType = AddressType,
                        PostalCode = PostalCode,
                        GoogleAddressText = GoogleAddressText,
                        LatLngText = LatLngText,
                    };

                    string TVText = CreateTVText(addressModelNew);
                    if (string.IsNullOrWhiteSpace(TVText))
                        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                    TVItemModel tvItemModelAddress = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Address);
                    if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                    {
                        // Should add
                        tvItemModelAddress = _TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Address);
                        if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                            return ReturnError(tvItemModelAddress.Error);

                        addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

                        addressModel = PostAddAddressDB(addressModelNew);
                        if (!string.IsNullOrWhiteSpace(addressModel.Error))
                            return ReturnError(addressModel.Error);
                    }

                    addressModel = GetAddressModelWithAddressTVItemIDDB(tvItemModelAddress.TVItemID);
                    if (!string.IsNullOrWhiteSpace(addressModel.Error))
                        return ReturnError(addressModel.Error);

                    TVItemLinkModel tvItemLinkModelNew = new TVItemLinkModel()
                    {
                        FromTVItemID = tvItemModelContact.TVItemID,
                        ToTVItemID = tvItemModelAddress.TVItemID,
                        FromTVType = tvItemModelContact.TVType,
                        ToTVType = TVTypeEnum.Address,
                        StartDateTime_Local = DateTime.Now,
                        Ordinal = 0,
                        TVLevel = 0,
                        TVPath = "p" + tvItemModelContact.TVItemID + "p" + tvItemModelAddress.TVItemID,
                    };

                    TVItemLinkModel tvItemLinkModel = _TVItemLinkService.GetTVItemLinkModelWithFromTVItemIDAndToTVItemIDDB(tvItemModelContact.TVItemID, tvItemModelAddress.TVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    {
                        tvItemLinkModel = _TVItemLinkService.PostAddTVItemLinkDB(tvItemLinkModelNew);
                        if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                            return ReturnError(tvItemLinkModel.Error);
                    }

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(addressModel.AddressTVItemID, TVTypeEnum.Address, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelList.Count == 0)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                        };

                        MapInfoModel mapInfoModel = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, addressModel.AddressTVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                            return ReturnError(mapInfoModel.Error);
                    }
                    else
                    {
                        MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelList[0].MapInfoPointID);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            return ReturnError(mapInfoPointModelRet.Error);

                        mapInfoPointModelRet.Lat = Lat;
                        mapInfoPointModelRet.Lng = Lng;
                        mapInfoPointModelRet.Ordinal = 0;

                        mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);

                    }
                }
                else
                {
                    AddressModel addressModelToChange = GetAddressModelWithAddressTVItemIDDB(AddressTVItemID);
                    if (!string.IsNullOrWhiteSpace(addressModelToChange.Error))
                        return ReturnError(addressModelToChange.Error);

                    addressModelToChange.CountryTVItemID = CountryTVItemID;
                    addressModelToChange.ProvinceTVItemID = ProvinceTVItemID;
                    addressModelToChange.MunicipalityTVItemID = MunicipalityTVItemID;
                    addressModelToChange.StreetName = StreetName;
                    addressModelToChange.StreetNumber = StreetNumber;
                    addressModelToChange.StreetType = StreetType;
                    addressModelToChange.AddressType = AddressType;
                    addressModelToChange.PostalCode = PostalCode;
                    addressModelToChange.GoogleAddressText = GoogleAddressText;
                    addressModelToChange.LatLngText = LatLngText;

                    addressModel = PostUpdateAddressDB(addressModelToChange);
                    if (!string.IsNullOrWhiteSpace(addressModel.Error))
                        return ReturnError(addressModel.Error);

                    foreach (LanguageEnum Lang in LanguageListAllowable)
                    {
                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(addressModelToChange.AddressTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);

                        tvItemLanguageModel.TVText = CreateTVText(addressModelToChange);

                        tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(addressModel.AddressTVItemID, TVTypeEnum.Address, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelList.Count == 0)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                        };

                        MapInfoModel mapInfoModel = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, addressModel.AddressTVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                            return ReturnError(mapInfoModel.Error);
                    }
                    else
                    {
                        MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelList[0].MapInfoPointID);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            return ReturnError(mapInfoPointModelRet.Error);

                        mapInfoPointModelRet.Lat = Lat;
                        mapInfoPointModelRet.Lng = Lng;
                        mapInfoPointModelRet.Ordinal = 0;

                        mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);

                    }

                }

                ts.Complete();
            }

            return addressModel;
        }
        public AddressModel PostAddOrModifyInfrastructureDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int InfrastructureTVItemID = 0;
            int AddressTVItemID = 0;
            int CountryTVItemID = 0;
            int ProvinceTVItemID = 0;
            int MunicipalityTVItemID = 0;
            int StreetTypeInt = 0;
            StreetTypeEnum StreetType = StreetTypeEnum.Error;
            string StreetName = "";
            string StreetNumber = "";
            int AddressTypeInt = 0;
            AddressTypeEnum AddressType = AddressTypeEnum.Error;
            string PostalCode = "";
            string GoogleAddressText = "";
            string LatLngText = "";
            float Lat = 0.0f;
            float Lng = 0.0f;

            int.TryParse(fc["InfrastructureTVItemID"], out InfrastructureTVItemID);
            if (InfrastructureTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID));

            InfrastructureModel infrastructureModel = _InfrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                return ReturnError(infrastructureModel.Error);

            int.TryParse(fc["AddressTVItemID"], out AddressTVItemID);
            // if 0 then want to add new TVItem else want to modify

            int.TryParse(fc["CountryTVItemID"], out CountryTVItemID);
            if (CountryTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.CountryTVItemID));

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(CountryTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnError(tvItemModel.Error);

            int.TryParse(fc["ProvinceTVItemID"], out ProvinceTVItemID);
            if (ProvinceTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID));

            tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(ProvinceTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnError(tvItemModel.Error);

            int.TryParse(fc["MunicipalityTVItemID"], out MunicipalityTVItemID);
            if (MunicipalityTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID));

            tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return ReturnError(tvItemModel.Error);

            int.TryParse(fc["StreetType"], out StreetTypeInt);
            if (StreetTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetType));

            StreetType = (StreetTypeEnum)StreetTypeInt;

            StreetNumber = fc["StreetNumber"];
            if (string.IsNullOrWhiteSpace(StreetNumber))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetNumber));

            StreetName = fc["StreetName"];
            if (string.IsNullOrWhiteSpace(StreetName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetName));

            int.TryParse(fc["AddressType"], out AddressTypeInt);
            if (AddressTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AddressType));

            AddressType = (AddressTypeEnum)AddressTypeInt;

            PostalCode = fc["PostalCode"];
            if (PostalCode == null)
                PostalCode = "";

            GoogleAddressText = fc["GoogleAddressText"];
            if (GoogleAddressText == null)
                GoogleAddressText = "";

            LatLngText = fc["LatLngText"];
            if (LatLngText == null)
                LatLngText = "";

            if (!string.IsNullOrWhiteSpace(LatLngText))
            {
                LatLngText = LatLngText.Trim();
                Lat = float.Parse(LatLngText.Substring(0, LatLngText.IndexOfAny(" ".ToCharArray())));
                Lng = float.Parse(LatLngText.Substring(LatLngText.LastIndexOfAny(" ".ToCharArray())));
            }

            AddressModel addressModel = new AddressModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (AddressTVItemID == 0)
                {
                    TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
                    if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                        return ReturnError(tvItemModelRoot.Error);

                    TVItemModel tvItemModelInfrastructure = _TVItemService.GetTVItemModelWithTVItemIDDB(InfrastructureTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelInfrastructure.Error))
                        return ReturnError(tvItemModelInfrastructure.Error);

                    AddressModel addressModelNew = new AddressModel()
                    {
                        CountryTVItemID = CountryTVItemID,
                        ProvinceTVItemID = ProvinceTVItemID,
                        MunicipalityTVItemID = MunicipalityTVItemID,
                        StreetName = StreetName,
                        StreetNumber = StreetNumber,
                        StreetType = StreetType,
                        AddressType = AddressType,
                        PostalCode = PostalCode,
                        GoogleAddressText = GoogleAddressText,
                        LatLngText = LatLngText,
                    };

                    string TVText = CreateTVText(addressModelNew);
                    if (string.IsNullOrWhiteSpace(TVText))
                        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                    TVItemModel tvItemModelAddress = _TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Address);
                    if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                        return ReturnError(tvItemModelAddress.Error);

                    addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

                    addressModel = PostAddAddressDB(addressModelNew);
                    if (!string.IsNullOrWhiteSpace(addressModel.Error))
                        return ReturnError(addressModel.Error);

                    addressModel = GetAddressModelWithAddressTVItemIDDB(tvItemModelAddress.TVItemID);
                    if (!string.IsNullOrWhiteSpace(addressModel.Error))
                        return ReturnError(addressModel.Error);

                    infrastructureModel.CivicAddressTVItemID = addressModel.AddressTVItemID;

                    InfrastructureModel infrastructureModelRet = _InfrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                        return ReturnError(infrastructureModelRet.Error);

                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                    };

                    MapInfoModel mapInfoModel = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, addressModel.AddressTVItemID);
                    if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                        return ReturnError(mapInfoModel.Error);
                }
                else
                {
                    AddressModel addressModelToChange = GetAddressModelWithAddressTVItemIDDB(AddressTVItemID);
                    if (!string.IsNullOrWhiteSpace(addressModelToChange.Error))
                        return ReturnError(addressModelToChange.Error);

                    addressModelToChange.CountryTVItemID = CountryTVItemID;
                    addressModelToChange.ProvinceTVItemID = ProvinceTVItemID;
                    addressModelToChange.MunicipalityTVItemID = MunicipalityTVItemID;
                    addressModelToChange.StreetName = StreetName;
                    addressModelToChange.StreetNumber = StreetNumber;
                    addressModelToChange.StreetType = StreetType;
                    addressModelToChange.AddressType = AddressType;
                    addressModelToChange.PostalCode = PostalCode;
                    addressModelToChange.GoogleAddressText = GoogleAddressText;
                    addressModelToChange.LatLngText = LatLngText;

                    addressModel = PostUpdateAddressDB(addressModelToChange);
                    if (!string.IsNullOrWhiteSpace(addressModel.Error))
                        return ReturnError(addressModel.Error);

                    infrastructureModel.CivicAddressTVItemID = addressModel.AddressTVItemID;

                    InfrastructureModel infrastructureModelRet = _InfrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                    if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                        return ReturnError(infrastructureModel.Error);

                    foreach (LanguageEnum Lang in LanguageListAllowable)
                    {
                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(addressModelToChange.AddressTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);

                        tvItemLanguageModel.TVText = CreateTVText(addressModel);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModel.TVText))
                            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(addressModel.AddressTVItemID, TVTypeEnum.Address, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelList.Count == 0)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                        };

                        MapInfoModel mapInfoModel = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, addressModel.AddressTVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                            return ReturnError(mapInfoModel.Error);
                    }
                    else
                    {
                        MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelList[0].MapInfoPointID);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            return ReturnError(mapInfoPointModelRet.Error);

                        mapInfoPointModelRet.Lat = Lat;
                        mapInfoPointModelRet.Lng = Lng;
                        mapInfoPointModelRet.Ordinal = 0;

                        mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            return ReturnError(mapInfoPointModelRet.Error);
                    }
                }

                ts.Complete();
            }

            return addressModel;
        }
        public AddressModel PostAddOrModifyPolSourceSiteDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int PolSourceSiteTVItemID = 0;
            int AddressTVItemID = 0;
            int CountryTVItemID = 0;
            int ProvinceTVItemID = 0;
            int MunicipalityTVItemID = 0;
            int StreetTypeInt = 0;
            StreetTypeEnum StreetType = StreetTypeEnum.Error;
            string StreetName = "";
            string StreetNumber = "";
            int AddressTypeInt = 0;
            AddressTypeEnum AddressType = AddressTypeEnum.Error;
            string PostalCode = "";
            string GoogleAddressText = "";
            string LatLngText = "";
            float Lat = 0.0f;
            float Lng = 0.0f;

            int.TryParse(fc["PolSourceSiteTVItemID"], out PolSourceSiteTVItemID);
            if (PolSourceSiteTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID));

            PolSourceSiteModel polSourceSiteModel = _PolSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                return ReturnError(polSourceSiteModel.Error);

            int.TryParse(fc["AddressTVItemID"], out AddressTVItemID);
            // if 0 then want to add new TVItem else want to modify

            int.TryParse(fc["CountryTVItemID"], out CountryTVItemID);
            if (CountryTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.CountryTVItemID));

            int.TryParse(fc["ProvinceTVItemID"], out ProvinceTVItemID);
            if (ProvinceTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemID));

            int.TryParse(fc["MunicipalityTVItemID"], out MunicipalityTVItemID);
            if (MunicipalityTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.MunicipalityTVItemID));

            int.TryParse(fc["StreetType"], out StreetTypeInt);
            if (StreetTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetType));

            StreetType = (StreetTypeEnum)StreetTypeInt;

            StreetNumber = fc["StreetNumber"];
            if (string.IsNullOrWhiteSpace(StreetNumber))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetNumber));

            StreetName = fc["StreetName"];
            if (string.IsNullOrWhiteSpace(StreetName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.StreetName));

            int.TryParse(fc["AddressType"], out AddressTypeInt);
            if (AddressTypeInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AddressType));

            AddressType = (AddressTypeEnum)AddressTypeInt;

            PostalCode = fc["PostalCode"];
            if (PostalCode == null)
                PostalCode = "";

            GoogleAddressText = fc["GoogleAddressText"];
            if (GoogleAddressText == null)
                GoogleAddressText = "";

            LatLngText = fc["LatLngText"];
            if (LatLngText == null)
                LatLngText = "";

            if (!string.IsNullOrWhiteSpace(LatLngText))
            {
                LatLngText = LatLngText.Trim();
                Lat = float.Parse(LatLngText.Substring(0, LatLngText.IndexOfAny(", ".ToCharArray())));
                Lng = float.Parse(LatLngText.Substring(LatLngText.LastIndexOfAny(", ".ToCharArray())));
            }

            AddressModel addressModel = new AddressModel();
            using (TransactionScope ts = new TransactionScope())
            {
                if (AddressTVItemID == 0)
                {
                    TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
                    if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
                        return ReturnError(tvItemModelRoot.Error);

                    TVItemModel tvItemModelPolSourceSite = _TVItemService.GetTVItemModelWithTVItemIDDB(PolSourceSiteTVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModelPolSourceSite.Error))
                        return ReturnError(tvItemModelPolSourceSite.Error);

                    AddressModel addressModelNew = new AddressModel()
                    {
                        CountryTVItemID = CountryTVItemID,
                        ProvinceTVItemID = ProvinceTVItemID,
                        MunicipalityTVItemID = MunicipalityTVItemID,
                        StreetName = StreetName,
                        StreetNumber = StreetNumber,
                        StreetType = StreetType,
                        AddressType = AddressType,
                        PostalCode = PostalCode,
                        GoogleAddressText = GoogleAddressText,
                        LatLngText = LatLngText,
                    };

                    string TVText = CreateTVText(addressModelNew);
                    if (string.IsNullOrWhiteSpace(TVText))
                        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                    TVItemModel tvItemModelAddress = _TVItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Address);
                    if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                    {
                        // Should add
                        tvItemModelAddress = _TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, TVText, TVTypeEnum.Address);
                        if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                            return ReturnError(tvItemModelAddress.Error);

                        addressModelNew.AddressTVItemID = tvItemModelAddress.TVItemID;

                        addressModel = PostAddAddressDB(addressModelNew);
                        if (!string.IsNullOrWhiteSpace(addressModel.Error))
                            return ReturnError(addressModel.Error);
                    }

                    addressModel = GetAddressModelWithAddressTVItemIDDB(tvItemModelAddress.TVItemID);
                    if (!string.IsNullOrWhiteSpace(addressModel.Error))
                        return ReturnError(addressModel.Error);

                    polSourceSiteModel.CivicAddressTVItemID = addressModel.AddressTVItemID;

                    PolSourceSiteModel polSourceSiteModelRet = _PolSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
                    if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                        return ReturnError(polSourceSiteModelRet.Error);

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(addressModel.AddressTVItemID, TVTypeEnum.Address, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelList.Count == 0)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                        };

                        MapInfoModel mapInfoModel = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, addressModel.AddressTVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                            return ReturnError(mapInfoModel.Error);
                    }
                    else
                    {
                        MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelList[0].MapInfoPointID);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            return ReturnError(mapInfoPointModelRet.Error);

                        mapInfoPointModelRet.Lat = Lat;
                        mapInfoPointModelRet.Lng = Lng;
                        mapInfoPointModelRet.Ordinal = 0;

                        mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);

                    }
                }
                else
                {
                    AddressModel addressModelToChange = GetAddressModelWithAddressTVItemIDDB(AddressTVItemID);
                    if (!string.IsNullOrWhiteSpace(addressModelToChange.Error))
                        return ReturnError(addressModelToChange.Error);

                    addressModelToChange.CountryTVItemID = CountryTVItemID;
                    addressModelToChange.ProvinceTVItemID = ProvinceTVItemID;
                    addressModelToChange.MunicipalityTVItemID = MunicipalityTVItemID;
                    addressModelToChange.StreetName = StreetName;
                    addressModelToChange.StreetNumber = StreetNumber;
                    addressModelToChange.StreetType = StreetType;
                    addressModelToChange.AddressType = AddressType;
                    addressModelToChange.PostalCode = PostalCode;
                    addressModelToChange.GoogleAddressText = GoogleAddressText;
                    addressModelToChange.LatLngText = LatLngText;

                    addressModel = PostUpdateAddressDB(addressModelToChange);
                    if (!string.IsNullOrWhiteSpace(addressModel.Error))
                        return ReturnError(addressModel.Error);

                    polSourceSiteModel.CivicAddressTVItemID = addressModel.AddressTVItemID;

                    PolSourceSiteModel polSourceSiteModelRet = _PolSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
                    if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                        return ReturnError(polSourceSiteModelRet.Error);

                    foreach (LanguageEnum Lang in LanguageListAllowable)
                    {
                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(addressModelToChange.AddressTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);

                        tvItemLanguageModel.TVText = CreateTVText(addressModelToChange);

                        tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }

                    List<MapInfoPointModel> mapInfoPointModelList = _MapInfoService._MapInfoPointService.GetMapInfoPointModelListWithTVItemIDAndTVTypeAndMapInfoDrawTypeDB(addressModel.AddressTVItemID, TVTypeEnum.Address, MapInfoDrawTypeEnum.Point);

                    if (mapInfoPointModelList.Count == 0)
                    {
                        List<Coord> coordList = new List<Coord>()
                        {
                            new Coord() { Lat = Lat, Lng = Lng, Ordinal = 0 },
                        };

                        MapInfoModel mapInfoModel = _MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.Address, addressModel.AddressTVItemID);
                        if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                            return ReturnError(mapInfoModel.Error);
                    }
                    else
                    {
                        MapInfoPointModel mapInfoPointModelRet = _MapInfoService._MapInfoPointService.GetMapInfoPointModelWithMapInfoPointIDDB(mapInfoPointModelList[0].MapInfoPointID);
                        if (!string.IsNullOrWhiteSpace(mapInfoPointModelRet.Error))
                            return ReturnError(mapInfoPointModelRet.Error);

                        mapInfoPointModelRet.Lat = Lat;
                        mapInfoPointModelRet.Lng = Lng;
                        mapInfoPointModelRet.Ordinal = 0;

                        mapInfoPointModelRet = _MapInfoService._MapInfoPointService.PostUpdateMapInfoPointDB(mapInfoPointModelRet);

                    }
                }

                ts.Complete();
            }

            return addressModel;
        }
        public AddressModel PostAddAddressDB(AddressModel addressModel)
        {
            string retStr = AddressModelOK(addressModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVItemModel tvItemModelAddressExist = _TVItemService.GetTVItemModelWithTVItemIDDB(addressModel.AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelAddressExist.Error))
                return ReturnError(tvItemModelAddressExist.Error);

            Address addressNew = new Address();
            retStr = FillAddress(addressNew, addressModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                db.Addresses.Add(addressNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Addresses", addressNew.AddressID, LogCommandEnum.Add, addressNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                ts.Complete();
            }

            return GetAddressModelWithAddressIDDB(addressNew.AddressID);
        }
        public AddressModel PostDeleteAddressDB(int addressID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Address addressToDelete = GetAddressWithAddressIDDB(addressID);
            if (addressToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.Address));

            int TVItemIDToDelete = addressToDelete.AddressTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                db.Addresses.Remove(addressToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Addresses", addressToDelete.AddressID, LogCommandEnum.Delete, addressToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                try
                {
                    TVItemModel tvItemModelRet = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemIDToDelete);
                }
                catch (Exception)
                {
                }

                ts.Complete();
            }
            return ReturnError("");
        }
        public AddressModel PostDeleteAddressUnderContactTVItemIDDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int ContactTVItemID = 0;
            int AddressTVItemID = 0;

            int.TryParse(fc["ContactTVItemID"], out ContactTVItemID);
            if (ContactTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ContactTVItemID));

            int.TryParse(fc["AddressTVItemID"], out AddressTVItemID);
            if (AddressTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AddressTVItemID));

            TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(ContactTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                return ReturnError(tvItemModelContact.Error);

            TVItemModel tvItemModelAddress = _TVItemService.GetTVItemModelWithTVItemIDDB(AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                return ReturnError(tvItemModelAddress.Error);

            AddressModel addressModel = GetAddressModelWithAddressTVItemIDDB(AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(addressModel.Error))
                return ReturnError(addressModel.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                MapInfoModel mapInfoModel = _MapInfoService.PostDeleteMapInfoWithTVItemIDDB(addressModel.AddressTVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                    return ReturnError(mapInfoModel.Error);

                TVItemLinkModel tvItemLinkModel = _TVItemLinkService.PostDeleteTVItemLinkWithFromTVItemIDAndToTVItemIDDB(tvItemModelContact.TVItemID, tvItemModelAddress.TVItemID);
                if (!string.IsNullOrWhiteSpace(tvItemLinkModel.Error))
                    return ReturnError(tvItemLinkModel.Error);

                AddressModel addressModelDel = PostDeleteAddressDB(addressModel.AddressID);
                //if (!string.IsNullOrWhiteSpace(addressModelDel.Error))
                //    return ReturnError(addressModelDel.Error);

                ts.Complete();
            }

            return new AddressModel() { Error = "" }; // no error
        }
        public AddressModel PostDeleteAddressUnderPolSourceSiteTVItemIDDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int PolSourceSiteTVItemID = 0;
            int AddressTVItemID = 0;

            int.TryParse(fc["PolSourceSiteTVItemID"], out PolSourceSiteTVItemID);
            if (PolSourceSiteTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.PolSourceSiteTVItemID));

            int.TryParse(fc["AddressTVItemID"], out AddressTVItemID);
            if (AddressTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AddressTVItemID));

            PolSourceSiteModel polSourceSiteModel = _PolSourceSiteService.GetPolSourceSiteModelWithPolSourceSiteTVItemIDDB(PolSourceSiteTVItemID);
            if (!string.IsNullOrWhiteSpace(polSourceSiteModel.Error))
                return ReturnError(polSourceSiteModel.Error);

            polSourceSiteModel.CivicAddressTVItemID = null;

            TVItemModel tvItemModelAddress = _TVItemService.GetTVItemModelWithTVItemIDDB(AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                return ReturnError(tvItemModelAddress.Error);

            AddressModel addressModel = GetAddressModelWithAddressTVItemIDDB(AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(addressModel.Error))
                return ReturnError(addressModel.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                MapInfoModel mapInfoModel = _MapInfoService.PostDeleteMapInfoWithTVItemIDDB(addressModel.AddressTVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                    return ReturnError(mapInfoModel.Error);

                PolSourceSiteModel polSourceSiteModelRet = _PolSourceSiteService.PostUpdatePolSourceSiteDB(polSourceSiteModel);
                if (!string.IsNullOrWhiteSpace(polSourceSiteModelRet.Error))
                    return ReturnError(polSourceSiteModelRet.Error);

                // try to delete
                AddressModel addressModelDel = PostDeleteAddressDB(addressModel.AddressID);
                //if (!string.IsNullOrWhiteSpace(addressModelDel.Error)) // might have others using the address
                //    return ReturnError(addressModelDel.Error);

                ts.Complete();
            }

            return new AddressModel() { Error = "" }; // no error
        }
        public AddressModel PostDeleteAddressUnderInfrastructureTVItemIDDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrWhiteSpace(contactOK.Error))
                return ReturnError(contactOK.Error);

            int InfrastructureTVItemID = 0;
            int AddressTVItemID = 0;

            int.TryParse(fc["InfrastructureTVItemID"], out InfrastructureTVItemID);
            if (InfrastructureTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.InfrastructureTVItemID));

            int.TryParse(fc["AddressTVItemID"], out AddressTVItemID);
            if (AddressTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.AddressTVItemID));

            InfrastructureModel infrastructureModel = _InfrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(InfrastructureTVItemID);
            if (!string.IsNullOrWhiteSpace(infrastructureModel.Error))
                return ReturnError(infrastructureModel.Error);

            infrastructureModel.CivicAddressTVItemID = null;

            TVItemModel tvItemModelAddress = _TVItemService.GetTVItemModelWithTVItemIDDB(AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelAddress.Error))
                return ReturnError(tvItemModelAddress.Error);

            AddressModel addressModel = GetAddressModelWithAddressTVItemIDDB(AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(addressModel.Error))
                return ReturnError(addressModel.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                MapInfoModel mapInfoModel = _MapInfoService.PostDeleteMapInfoWithTVItemIDDB(addressModel.AddressTVItemID);
                if (!string.IsNullOrWhiteSpace(mapInfoModel.Error))
                    return ReturnError(mapInfoModel.Error);

                InfrastructureModel infrastructureModelRet = _InfrastructureService.PostUpdateInfrastructureDB(infrastructureModel);
                if (!string.IsNullOrWhiteSpace(infrastructureModelRet.Error))
                    return ReturnError(infrastructureModelRet.Error);

                // try to delete
                AddressModel addressModelDel = PostDeleteAddressDB(addressModel.AddressID);
                //if (!string.IsNullOrWhiteSpace(addressModelDel.Error)) // might have others using the address
                //    return ReturnError(addressModelDel.Error);

                ts.Complete();
            }

            return new AddressModel() { Error = "" }; // no error
        }
        public AddressModel PostUpdateAddressDB(AddressModel addressModel)
        {
            string retStr = AddressModelOK(addressModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            Address addressToUpdate = GetAddressWithAddressIDDB(addressModel.AddressID);
            if (addressToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.Address));

            retStr = FillAddress(addressToUpdate, addressModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("Addresses", addressToUpdate.AddressID, LogCommandEnum.Change, addressToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum Lang in LanguageListAllowable)
                {
                    if (Lang == LanguageRequest)
                    {
                        TVItemLanguageModel tvItemLanguageModelToUpdate = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(addressToUpdate.AddressTVItemID, Lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.Error))
                            return ReturnError(tvItemLanguageModelToUpdate.Error);

                        tvItemLanguageModelToUpdate.TVText = CreateTVText(addressModel);
                        if (string.IsNullOrWhiteSpace(tvItemLanguageModelToUpdate.TVText))
                            return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVText));

                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModelToUpdate);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }
                }

                ts.Complete();
            }
            return GetAddressModelWithAddressIDDB(addressToUpdate.AddressID);
        }
        public AddressModel PostDeleteAddressWithAddressTVItemIDDB(int AddressTVItemID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            AddressModel addressModelToDelete = GetAddressModelWithAddressTVItemIDDB(AddressTVItemID);
            if (!string.IsNullOrWhiteSpace(addressModelToDelete.Error))
                return ReturnError(addressModelToDelete.Error);

            addressModelToDelete = PostDeleteAddressDB(addressModelToDelete.AddressID);
            if (!string.IsNullOrWhiteSpace(addressModelToDelete.Error))
                return ReturnError(addressModelToDelete.Error);

            return ReturnError("");
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
