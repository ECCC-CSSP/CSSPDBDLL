using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CSSPDBDLL.Models;
using System.Collections.Generic;
using System;
using CSSPDBDLL.Services.Resources;
using System.Transactions;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Threading;
using System.Globalization;
using CSSPModelsDLL.Models;
using CSSPEnumsDLL.Enums;
using System.Net;

namespace CSSPDBDLL.Services
{
    public class TVFileService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public AppTaskService _AppTaskService { get; private set; }
        public MapInfoService _MapInfoService { get; private set; }
        public TVItemService _TVItemService { get; private set; }
        public LogService _LogService { get; private set; }
        public TVFileLanguageService _TVFileLanguageService { get; private set; }
        public ReportTypeService _ReportTypeService { get; private set; }
        public PolSourceSiteService _PolSourceSiteService { get; private set; }
        public InfrastructureService _InfrastructureService { get; private set; }
        public TVItemLinkService _TVItemLinkService { get; private set; }
        public AddressService _AddressService { get; private set; }
        public PolSourceObservationService _PolSourceObservationService { get; private set; }
        public PolSourceObservationIssueService _PolSourceObservationIssueService { get; private set; }
        public ContactService _ContactService { get; private set; }
        public TelService _TelService { get; private set; }
        public EmailService _EmailService { get; private set; }
        #endregion Properties

        #region Constructors
        public TVFileService(LanguageEnum LanguageRequest, IPrincipal User)
            : base(LanguageRequest, User)
        {
            _AppTaskService = new AppTaskService(LanguageRequest, User);
            _MapInfoService = new MapInfoService(LanguageRequest, User);
            _TVItemService = new TVItemService(LanguageRequest, User);
            _LogService = new LogService(LanguageRequest, User);
            _TVFileLanguageService = new TVFileLanguageService(LanguageRequest, User);
            _ReportTypeService = new ReportTypeService(LanguageRequest, User);
            _PolSourceSiteService = new PolSourceSiteService(LanguageRequest, User);
            _InfrastructureService = new InfrastructureService(LanguageRequest, User);
            _TVItemLinkService = new TVItemLinkService(LanguageRequest, User);
            _AddressService = new AddressService(LanguageRequest, User);
            _PolSourceObservationService = new PolSourceObservationService(LanguageRequest, User);
            _PolSourceObservationIssueService = new PolSourceObservationIssueService(LanguageRequest, User);
            _ContactService = new ContactService(LanguageRequest, User);
            _TelService = new TelService(LanguageRequest, User);
            _EmailService = new EmailService(LanguageRequest, User);
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
        public string TVFileModelOK(TVFileModel tvFileModel)
        {
            string retStr = FieldCheckNotZeroInt(tvFileModel.TVFileTVItemID, ServiceRes.TVItemID);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.LanguageOK(tvFileModel.Language);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.FilePurposeOK(tvFileModel.FilePurpose);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.FileTypeOK(tvFileModel.FileType);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(tvFileModel.FileDescription, ServiceRes.FileDescription, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullAndWithinRangeInt(tvFileModel.FileSize_kb, ServiceRes.FileSize_kb, -1, 2000000000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(tvFileModel.FileInfo, ServiceRes.FileInfo, 100000);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotNullDateTime(tvFileModel.FileCreatedDate_UTC, ServiceRes.FileCreatedDate_UTC);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(tvFileModel.ClientFilePath, ServiceRes.ClientFilePath, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckNotEmptyAndMaxLengthString(tvFileModel.ServerFileName, ServiceRes.ServerFileName, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullMaxLengthString(tvFileModel.ServerFilePath, ServiceRes.ServerFilePath, 250);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = FieldCheckIfNotNullWithinRangeInt(tvFileModel.Year, ServiceRes.Year, 1980, 2050);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = _BaseEnumService.DBCommandOK(tvFileModel.DBCommand);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            return "";
        }

        // Fill
        public string FillTVFile(TVFile tvFileNew, TVFileModel tvFileModel, ContactOK contactOK)
        {
            tvFileNew.DBCommand = (int)tvFileModel.DBCommand;
            tvFileNew.TVFileTVItemID = tvFileModel.TVFileTVItemID;
            tvFileNew.TemplateTVType = (int?)tvFileModel.TemplateTVType;
            tvFileNew.ReportTypeID = tvFileModel.ReportTypeID;
            tvFileNew.Parameters = tvFileModel.Parameters;
            tvFileNew.Year = tvFileModel.Year;
            tvFileNew.Language = (int)tvFileModel.Language;
            tvFileNew.FilePurpose = (int)tvFileModel.FilePurpose;
            tvFileNew.FileType = (int)tvFileModel.FileType;
            tvFileNew.FileSize_kb = tvFileModel.FileSize_kb;
            tvFileNew.FileInfo = tvFileModel.FileInfo;
            tvFileNew.FileCreatedDate_UTC = tvFileModel.FileCreatedDate_UTC;
            tvFileNew.FromWater = tvFileModel.FromWater;
            tvFileNew.ClientFilePath = tvFileModel.ClientFilePath;
            tvFileNew.ServerFileName = tvFileModel.ServerFileName;
            tvFileNew.ServerFilePath = tvFileModel.ServerFilePath;
            tvFileNew.LastUpdateDate_UTC = DateTime.UtcNow;
            if (contactOK == null)
            {
                tvFileNew.LastUpdateContactTVItemID = 2;
            }
            else
            {
                tvFileNew.LastUpdateContactTVItemID = contactOK.ContactTVItemID;
            }

            return "";
        }
        public TVFileModel ReturnError(string Error)
        {
            return new TVFileModel() { Error = Error };
        }

        // Get
        public FileTypeEnum GetFileType(string FileType)
        {
            FileTypeEnum fileType = FileTypeEnum.Error;
            FileType = FileType.Replace(".", "").ToUpper();

            switch (FileType)
            {
                case "ERROR":
                    {
                        fileType = FileTypeEnum.Error;
                    }
                    break;
                case "DFS0":
                    {
                        fileType = FileTypeEnum.DFS0;
                    }
                    break;
                case "DFS1":
                    {
                        fileType = FileTypeEnum.DFS1;
                    }
                    break;
                case "DFSU":
                    {
                        fileType = FileTypeEnum.DFSU;
                    }
                    break;
                case "KMZ":
                    {
                        fileType = FileTypeEnum.KMZ;
                    }
                    break;
                case "LOG":
                    {
                        fileType = FileTypeEnum.LOG;
                    }
                    break;
                case "M21FM":
                    {
                        fileType = FileTypeEnum.M21FM;
                    }
                    break;
                case "M3FM":
                    {
                        fileType = FileTypeEnum.M3FM;
                    }
                    break;
                case "MDF":
                    {
                        fileType = FileTypeEnum.MDF;
                    }
                    break;
                case "MESH":
                    {
                        fileType = FileTypeEnum.MESH;
                    }
                    break;
                case "XLSX":
                    {
                        fileType = FileTypeEnum.XLSX;
                    }
                    break;
                case "DOCX":
                    {
                        fileType = FileTypeEnum.DOCX;
                    }
                    break;
                case "PDF":
                    {
                        fileType = FileTypeEnum.PDF;
                    }
                    break;
                case "JPG":
                    {
                        fileType = FileTypeEnum.JPG;
                    }
                    break;
                case "JPEG":
                    {
                        fileType = FileTypeEnum.JPEG;
                    }
                    break;
                case "GIF":
                    {
                        fileType = FileTypeEnum.GIF;
                    }
                    break;
                case "PNG":
                    {
                        fileType = FileTypeEnum.PNG;
                    }
                    break;
                case "HTML":
                    {
                        fileType = FileTypeEnum.HTML;
                    }
                    break;
                case "TXT":
                    {
                        fileType = FileTypeEnum.TXT;
                    }
                    break;
                case "XYZ":
                    {
                        fileType = FileTypeEnum.XYZ;
                    }
                    break;
                case "KML":
                    {
                        fileType = FileTypeEnum.KML;
                    }
                    break;
                case "CSV":
                    {
                        fileType = FileTypeEnum.CSV;
                    }
                    break;
                case "WMV":
                    {
                        fileType = FileTypeEnum.WMV;
                    }
                    break;
                default:
                    break;
            }

            return fileType;
        }
        public string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext); // henter info fra windows registry
            if (regKey != null && regKey.GetValue("Content Type") != null)
            {
                mimeType = regKey.GetValue("Content Type").ToString();
            }
            else if (ext == ".png") // a couple of extra info, due to missing information on the server
            {
                mimeType = "image/png";
            }
            return mimeType;
        }
        public string GetServerFilePath(int TVItemID)
        {
            string ServerFilePath = BasePath + TVItemID.ToString() + @"\";

            ServerFilePath = ChoseEDriveOrCDrive(ServerFilePath);

            return ServerFilePath;
        }
        public TVFile GetTVFileExistDB(TVFileModel tvFileModel)
        {
            TVFile TVFile = (from c in db.TVFiles
                             where c.TVFileTVItemID == tvFileModel.TVFileTVItemID
                             && c.Language == (int)tvFileModel.Language
                             && c.FilePurpose == (int)tvFileModel.FilePurpose
                             && c.FileType == (int)tvFileModel.FileType
                             && c.FileSize_kb == tvFileModel.FileSize_kb
                             && c.FileCreatedDate_UTC == tvFileModel.FileCreatedDate_UTC
                             && c.ClientFilePath == tvFileModel.ClientFilePath
                             && c.ServerFileName == tvFileModel.ServerFileName
                             && c.ServerFilePath == tvFileModel.ServerFilePath
                             select c).FirstOrDefault<TVFile>();

            return TVFile;
        }
        public TVFileModel GetTVFileModelExistDB(TVFileModel tvFileModel)
        {
            TVFileModel tvFileModelRet = (from c in db.TVFiles
                                          from cl in db.TVFileLanguages
                                          let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                          where c.TVFileTVItemID == tvFileModel.TVFileTVItemID
                                          && c.TVFileID == cl.TVFileID
                                          && cl.Language == (int)LanguageRequest
                                          && c.Language == (int)tvFileModel.Language
                                          && c.FilePurpose == (int)tvFileModel.FilePurpose
                                          && c.FileType == (int)tvFileModel.FileType
                                          && c.FileSize_kb == tvFileModel.FileSize_kb
                                          && c.FileCreatedDate_UTC == tvFileModel.FileCreatedDate_UTC
                                          && c.ServerFileName == tvFileModel.ServerFileName
                                          && c.ServerFilePath == tvFileModel.ServerFilePath
                                          select new TVFileModel
                                          {
                                              Error = "",
                                              TVFileID = c.TVFileID,
                                              DBCommand = (DBCommandEnum)c.DBCommand,
                                              TVFileTVItemID = c.TVFileTVItemID,
                                              TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                              ReportTypeID = c.ReportTypeID,
                                              Parameters = c.Parameters,
                                              Year = c.Year,
                                              TVFileTVText = tvText,
                                              Language = (LanguageEnum)c.Language,
                                              FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                              FileType = (FileTypeEnum)c.FileType,
                                              FileDescription = cl.FileDescription,
                                              FileSize_kb = c.FileSize_kb,
                                              FileInfo = c.FileInfo,
                                              FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                              FromWater = c.FromWater,
                                              ClientFilePath = c.ClientFilePath,
                                              ServerFileName = c.ServerFileName,
                                              ServerFilePath = c.ServerFilePath,
                                              LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                              LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                          }).FirstOrDefault<TVFileModel>();

            if (tvFileModelRet == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_,
                    ServiceRes.TVFile,
                    ServiceRes.Language + "," +
                    ServiceRes.FilePurpose + "," +
                    ServiceRes.FileType + "," +
                    ServiceRes.FileSize_kb + "," +
                    ServiceRes.FileCreatedDate_UTC + "," +
                    ServiceRes.ServerFilePath + "," +
                    ServiceRes.ServerFileName,
                    tvFileModel.Language.ToString() + "," +
                    tvFileModel.FilePurpose.ToString() + "," +
                    tvFileModel.FileType.ToString() + "," +
                    tvFileModel.FileSize_kb + "," +
                    tvFileModel.FileCreatedDate_UTC + "," +
                    tvFileModel.ServerFilePath + "," +
                    tvFileModel.ServerFileName));

            return tvFileModelRet;
        }
        public int GetTVFileModelCountDB()
        {
            int TVFileModelCount = (from c in db.TVFiles
                                    select c).Count();

            return TVFileModelCount;
        }
        public List<TVFileModel> GetTVFileModelListWithParentTVItemIDDB(int ParentTVItemID)
        {
            TVItemModel tvItemModelParent = _TVItemService.GetTVItemModelWithTVItemIDDB(ParentTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
            {
                return new List<TVFileModel>();
            }

            TVItemModel tvItemModelRoot = _TVItemService.GetRootTVItemModelDB();
            if (!string.IsNullOrWhiteSpace(tvItemModelRoot.Error))
            {
                return new List<TVFileModel>();
            }

            List<TVFileModel> TVFileModelNoTemplateList = (from c in db.TVFiles
                                                           from cl in db.TVFileLanguages
                                                           from t in db.TVItems
                                                           let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                                           where c.TVFileTVItemID == t.TVItemID
                                                           && c.TVFileID == cl.TVFileID
                                                           && cl.Language == (int)LanguageRequest
                                                           && t.TVPath.StartsWith(tvItemModelParent.TVPath + "p")
                                                           && t.ParentID == ParentTVItemID
                                                           && c.FilePurpose != (int)FilePurposeEnum.Template
                                                           orderby c.ServerFileName
                                                           select new TVFileModel
                                                           {
                                                               Error = "",
                                                               TVFileID = c.TVFileID,
                                                               DBCommand = (DBCommandEnum)c.DBCommand,
                                                               TVFileTVItemID = c.TVFileTVItemID,
                                                               TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                                               ReportTypeID = c.ReportTypeID,
                                                               Parameters = c.Parameters,
                                                               Year = c.Year,
                                                               TVFileTVText = tvText,
                                                               Language = (LanguageEnum)c.Language,
                                                               FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                                               FileType = (FileTypeEnum)c.FileType,
                                                               FileDescription = cl.FileDescription,
                                                               FileSize_kb = c.FileSize_kb,
                                                               FileInfo = c.FileInfo,
                                                               FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                                               FromWater = c.FromWater,
                                                               ClientFilePath = c.ClientFilePath,
                                                               ServerFileName = c.ServerFileName,
                                                               ServerFilePath = c.ServerFilePath,
                                                               LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                               LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                           }).ToList<TVFileModel>();

            List<TVFileModel> TVFileModelTemplateList = (from c in db.TVFiles
                                                         from cl in db.TVFileLanguages
                                                         from t in db.TVItems
                                                         from d in db.DocTemplates
                                                         let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                                         where c.TVFileTVItemID == t.TVItemID
                                                         && c.TVFileID == cl.TVFileID
                                                         && cl.Language == (int)LanguageRequest
                                                         && d.TVFileTVItemID == t.TVItemID
                                                         && t.ParentID == tvItemModelRoot.TVItemID
                                                         && c.FilePurpose == (int)FilePurposeEnum.Template
                                                         && d.TVType == (int)tvItemModelParent.TVType
                                                         orderby c.ServerFileName
                                                         select new TVFileModel
                                                         {
                                                             Error = "",
                                                             TVFileID = c.TVFileID,
                                                             DBCommand = (DBCommandEnum)c.DBCommand,
                                                             TVFileTVItemID = c.TVFileTVItemID,
                                                             TVFileTVText = tvText,
                                                             Language = (LanguageEnum)c.Language,
                                                             FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                                             FileType = (FileTypeEnum)c.FileType,
                                                             FileDescription = cl.FileDescription,
                                                             FileSize_kb = c.FileSize_kb,
                                                             FileInfo = c.FileInfo,
                                                             FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                                             FromWater = c.FromWater,
                                                             ClientFilePath = c.ClientFilePath,
                                                             ServerFileName = c.ServerFileName,
                                                             ServerFilePath = c.ServerFilePath,
                                                             LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                             LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                         }).ToList<TVFileModel>();


            return TVFileModelNoTemplateList.Concat(TVFileModelTemplateList).ToList();
        }
        public TVFileModel GetTVFileModelWithTVFileTVItemIDDB(int TVFileTVItemID)
        {
            TVFileModel tvFileModel = (from c in db.TVFiles
                                       from cl in db.TVFileLanguages
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                       where c.TVFileTVItemID == TVFileTVItemID
                                       && c.TVFileID == cl.TVFileID
                                       && cl.Language == (int)LanguageRequest
                                       orderby c.ServerFileName
                                       select new TVFileModel
                                       {
                                           Error = "",
                                           TVFileID = c.TVFileID,
                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                           TVFileTVItemID = c.TVFileTVItemID,
                                           TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                           ReportTypeID = c.ReportTypeID,
                                           Parameters = c.Parameters,
                                           Year = c.Year,
                                           TVFileTVText = tvText,
                                           Language = (LanguageEnum)c.Language,
                                           FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                           FileType = (FileTypeEnum)c.FileType,
                                           FileDescription = cl.FileDescription,
                                           FileSize_kb = c.FileSize_kb,
                                           FileInfo = c.FileInfo,
                                           FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                           FromWater = c.FromWater,
                                           ClientFilePath = c.ClientFilePath,
                                           ServerFileName = c.ServerFileName,
                                           ServerFilePath = c.ServerFilePath,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       }).FirstOrDefault<TVFileModel>();

            if (tvFileModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFile, ServiceRes.TVFileTVItemID, TVFileTVItemID));

            return tvFileModel;
        }
        public TVFileModel GetTVFileModelWithServerFilePathAndServerFileNameDB(string FilePath, string FileName)
        {
            TVFileModel tvFileModel = (from c in db.TVFiles
                                       from cl in db.TVFileLanguages
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                       where c.ServerFilePath == FilePath
                                       && c.TVFileID == cl.TVFileID
                                       && cl.Language == (int)LanguageRequest
                                       && c.ServerFileName == FileName
                                       select new TVFileModel
                                       {
                                           Error = "",
                                           TVFileID = c.TVFileID,
                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                           TVFileTVItemID = c.TVFileTVItemID,
                                           TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                           ReportTypeID = c.ReportTypeID,
                                           Parameters = c.Parameters,
                                           Year = c.Year,
                                           TVFileTVText = tvText,
                                           Language = (LanguageEnum)c.Language,
                                           FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                           FileType = (FileTypeEnum)c.FileType,
                                           FileDescription = cl.FileDescription,
                                           FileSize_kb = c.FileSize_kb,
                                           FileInfo = c.FileInfo,
                                           FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                           FromWater = c.FromWater,
                                           ClientFilePath = c.ClientFilePath,
                                           ServerFileName = c.ServerFileName,
                                           ServerFilePath = c.ServerFilePath,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       }).FirstOrDefault<TVFileModel>();

            if (tvFileModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFile, ServiceRes.FullFileName, FilePath + FileName));

            return tvFileModel;
        }
        public List<TVFileModel> GetTVFileNotLoaded(int MikeScenarioTVItemID)
        {
            if (MikeScenarioTVItemID == 0)
                return new List<TVFileModel>() { new TVFileModel() { Error = string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID) } };

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(MikeScenarioTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return new List<TVFileModel>() { new TVFileModel() { Error = tvItemModel.Error } };

            List<TVFileModel> tvFileModelNotLoaded = (from c in db.TVFiles
                                                      from cl in db.TVFileLanguages
                                                      from t in db.TVItems
                                                      let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                                      where c.TVFileTVItemID == t.TVItemID
                                                      && c.TVFileID == cl.TVFileID
                                                      && cl.Language == (int)LanguageRequest
                                                      && t.ParentID == MikeScenarioTVItemID
                                                      && c.FileSize_kb == 0
                                                      orderby c.ServerFileName
                                                      select new TVFileModel
                                                      {
                                                          Error = "",
                                                          TVFileID = c.TVFileID,
                                                          DBCommand = (DBCommandEnum)c.DBCommand,
                                                          TVFileTVItemID = c.TVFileTVItemID,
                                                          TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                                          ReportTypeID = c.ReportTypeID,
                                                          Parameters = c.Parameters,
                                                          Year = c.Year,
                                                          TVFileTVText = tvText,
                                                          Language = (LanguageEnum)c.Language,
                                                          FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                                          FileType = (FileTypeEnum)c.FileType,
                                                          FileDescription = cl.FileDescription,
                                                          FileSize_kb = c.FileSize_kb,
                                                          FileInfo = c.FileInfo,
                                                          FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                                          FromWater = c.FromWater,
                                                          ClientFilePath = c.ClientFilePath,
                                                          ServerFileName = c.ServerFileName,
                                                          ServerFilePath = c.ServerFilePath,
                                                          LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                          LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                      }).ToList<TVFileModel>();

            return tvFileModelNotLoaded;

        }
        public TVFile GetTVFileWithServerFilePathAndServerFileNameDB(string FilePath, string FileName)
        {
            TVFile tvFile = (from c in db.TVFiles
                             let tvText = (from cl in db.TVItemLanguages where cl.Language == (int)LanguageRequest && cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                             where c.ServerFilePath == FilePath
                             && c.ServerFileName == FileName
                             select c).FirstOrDefault<TVFile>();

            return tvFile;
        }
        public TVFile GetTVFileWithTVFileIDDB(int TVFileID)
        {
            TVFile TVFile = (from c in db.TVFiles
                             where c.TVFileID == TVFileID
                             select c).FirstOrDefault<TVFile>();

            return TVFile;
        }
        public TVFile GetTVFileWithTVItemIDAndTVFileTypeM21FMOrM3FM(int TVItemID)
        {
            TVFile tvfile = (from cf in db.TVFiles
                             where cf.TVFileTVItemID == TVItemID
                             && (cf.FileType == (int)FileTypeEnum.M21FM || cf.FileType == (int)FileTypeEnum.M3FM)
                             select cf).FirstOrDefault<TVFile>();

            return tvfile;
        }
        public TVFileModel GetTVFileModelWithTVItemIDAndTVFileTypeM21FMOrM3FMDB(int MikeScenarioTVItemID)
        {
            TVFileModel tvFileModel = (from c in db.TVFiles
                                       from cl in db.TVFileLanguages
                                       from t in db.TVItems
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                       where c.TVFileTVItemID == t.TVItemID
                                       && c.TVFileID == cl.TVFileID
                                       && cl.Language == (int)LanguageRequest
                                       && t.ParentID == MikeScenarioTVItemID
                                       && (c.FileType == (int)FileTypeEnum.M21FM || c.FileType == (int)FileTypeEnum.M3FM)
                                       select new TVFileModel
                                       {
                                           Error = "",
                                           TVFileID = c.TVFileID,
                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                           TVFileTVItemID = c.TVFileTVItemID,
                                           TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                           ReportTypeID = c.ReportTypeID,
                                           Parameters = c.Parameters,
                                           Year = c.Year,
                                           TVFileTVText = tvText,
                                           Language = (LanguageEnum)c.Language,
                                           FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                           FileType = (FileTypeEnum)c.FileType,
                                           FileDescription = cl.FileDescription,
                                           FileSize_kb = c.FileSize_kb,
                                           FileInfo = c.FileInfo,
                                           FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                           FromWater = c.FromWater,
                                           ClientFilePath = c.ClientFilePath,
                                           ServerFileName = c.ServerFileName,
                                           ServerFilePath = c.ServerFilePath,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       }).FirstOrDefault<TVFileModel>();

            if (tvFileModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFile, ServiceRes.TVItemID, MikeScenarioTVItemID));

            return tvFileModel;
        }
        public TVFileModel GetTVFileModelWithTVItemIDAndTVFileTypeLogDB(int MikeScenarioTVItemID)
        {
            TVFileModel tvFileModel = (from c in db.TVFiles
                                       from cl in db.TVFileLanguages
                                       from t in db.TVItems
                                       let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                       where c.TVFileTVItemID == t.TVItemID
                                       && c.TVFileID == cl.TVFileID
                                       && cl.Language == (int)LanguageRequest
                                       && t.ParentID == MikeScenarioTVItemID
                                       && c.FileType == (int)FileTypeEnum.LOG
                                       select new TVFileModel
                                       {
                                           Error = "",
                                           TVFileID = c.TVFileID,
                                           DBCommand = (DBCommandEnum)c.DBCommand,
                                           TVFileTVItemID = c.TVFileTVItemID,
                                           TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                           ReportTypeID = c.ReportTypeID,
                                           Parameters = c.Parameters,
                                           Year = c.Year,
                                           TVFileTVText = tvText,
                                           Language = (LanguageEnum)c.Language,
                                           FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                           FileType = (FileTypeEnum)c.FileType,
                                           FileDescription = cl.FileDescription,
                                           FileSize_kb = c.FileSize_kb,
                                           FileInfo = c.FileInfo,
                                           FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                           FromWater = c.FromWater,
                                           ClientFilePath = c.ClientFilePath,
                                           ServerFileName = c.ServerFileName,
                                           ServerFilePath = c.ServerFilePath,
                                           LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                           LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                       }).FirstOrDefault<TVFileModel>();

            if (tvFileModel == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFile, ServiceRes.TVItemID, MikeScenarioTVItemID));

            return tvFileModel;
        }
        public List<TVFileModel> GetTVFileModelListWithTVItemIDAndTVFilePurposeMIKE_InputDB(int MikeScenarioTVItemID)
        {
            List<TVFileModel> tvFileModelList = (from c in db.TVFiles
                                                 from cl in db.TVFileLanguages
                                                 from t in db.TVItems
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                                 where c.TVFileTVItemID == t.TVItemID
                                                 && c.TVFileID == cl.TVFileID
                                                 && cl.Language == (int)LanguageRequest
                                                 && t.ParentID == MikeScenarioTVItemID
                                                 && (c.FileType == (int)FilePurposeEnum.MikeInput || c.FileType == (int)FilePurposeEnum.MikeInputMDF)
                                                 select new TVFileModel
                                                 {
                                                     Error = "",
                                                     TVFileID = c.TVFileID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
                                                     TVFileTVItemID = c.TVFileTVItemID,
                                                     TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                                     ReportTypeID = c.ReportTypeID,
                                                     Parameters = c.Parameters,
                                                     Year = c.Year,
                                                     TVFileTVText = tvText,
                                                     Language = (LanguageEnum)c.Language,
                                                     FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                                     FileType = (FileTypeEnum)c.FileType,
                                                     FileDescription = cl.FileDescription,
                                                     FileSize_kb = c.FileSize_kb,
                                                     FileInfo = c.FileInfo,
                                                     FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                                     FromWater = c.FromWater,
                                                     ClientFilePath = c.ClientFilePath,
                                                     ServerFileName = c.ServerFileName,
                                                     ServerFilePath = c.ServerFilePath,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).ToList<TVFileModel>();

            return tvFileModelList;
        }
        public List<TVFileModel> GetTVFileModelListWithReportTypeIDDB(int ReportTypeID)
        {
            if (ReportTypeID == 0)
                return new List<TVFileModel>() { new TVFileModel() { Error = string.Format(ServiceRes._IsRequired, ServiceRes.ReportTypeID) } };

            ReportTypeModel reportTypeModel = _ReportTypeService.GetReportTypeModelWithReportTypeIDDB(ReportTypeID);
            if (!string.IsNullOrWhiteSpace(reportTypeModel.Error))
                return new List<TVFileModel>() { new TVFileModel() { Error = reportTypeModel.Error } };

            List<TVFileModel> tvFileModelList = (from c in db.TVFiles
                                                 from cl in db.TVFileLanguages
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                                 where c.TVFileID == cl.TVFileID
                                                 && cl.Language == (int)LanguageRequest
                                                 && c.ReportTypeID == ReportTypeID
                                                 orderby c.ServerFileName
                                                 select new TVFileModel
                                                 {
                                                     Error = "",
                                                     TVFileID = c.TVFileID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
                                                     TVFileTVItemID = c.TVFileTVItemID,
                                                     TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                                     ReportTypeID = c.ReportTypeID,
                                                     Parameters = c.Parameters,
                                                     Year = c.Year,
                                                     TVFileTVText = tvText,
                                                     Language = (LanguageEnum)c.Language,
                                                     FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                                     FileType = (FileTypeEnum)c.FileType,
                                                     FileDescription = cl.FileDescription,
                                                     FileSize_kb = c.FileSize_kb,
                                                     FileInfo = c.FileInfo,
                                                     FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                                     FromWater = c.FromWater,
                                                     ClientFilePath = c.ClientFilePath,
                                                     ServerFileName = c.ServerFileName,
                                                     ServerFilePath = c.ServerFilePath,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).ToList<TVFileModel>();

            return tvFileModelList;

        }
        public List<TVFileModel> GetTVFileModelListWithReportTypeIDAndTVItemIDDB(int ReportTypeID, int TVItemID)
        {
            if (ReportTypeID == 0)
                return new List<TVFileModel>() { new TVFileModel() { Error = string.Format(ServiceRes._IsRequired, ServiceRes.ReportTypeID) } };

            ReportTypeModel reportTypeModel = _ReportTypeService.GetReportTypeModelWithReportTypeIDDB(ReportTypeID);
            if (!string.IsNullOrWhiteSpace(reportTypeModel.Error))
                return new List<TVFileModel>() { new TVFileModel() { Error = reportTypeModel.Error } };

            List<TVFileModel> tvFileModelList = (from c in db.TVFiles
                                                 from cl in db.TVFileLanguages
                                                 from t in db.TVItems
                                                 let tvText = (from cl in db.TVItemLanguages where cl.TVItemID == c.TVFileTVItemID select cl.TVText).FirstOrDefault<string>()
                                                 where t.TVItemID == c.TVFileTVItemID
                                                 && c.TVFileID == cl.TVFileID
                                                 && cl.Language == (int)LanguageRequest
                                                 && c.ReportTypeID == ReportTypeID
                                                 && t.ParentID == TVItemID
                                                 orderby c.ServerFileName
                                                 select new TVFileModel
                                                 {
                                                     Error = "",
                                                     TVFileID = c.TVFileID,
                                                     DBCommand = (DBCommandEnum)c.DBCommand,
                                                     TVFileTVItemID = c.TVFileTVItemID,
                                                     TemplateTVType = (TVTypeEnum?)c.TemplateTVType,
                                                     ReportTypeID = c.ReportTypeID,
                                                     Parameters = c.Parameters,
                                                     Year = c.Year,
                                                     TVFileTVText = tvText,
                                                     Language = (LanguageEnum)c.Language,
                                                     FilePurpose = (FilePurposeEnum)c.FilePurpose,
                                                     FileType = (FileTypeEnum)c.FileType,
                                                     FileDescription = cl.FileDescription,
                                                     FileSize_kb = c.FileSize_kb,
                                                     FileInfo = c.FileInfo,
                                                     FileCreatedDate_UTC = c.FileCreatedDate_UTC,
                                                     FromWater = c.FromWater,
                                                     ClientFilePath = c.ClientFilePath,
                                                     ServerFileName = c.ServerFileName,
                                                     ServerFilePath = c.ServerFilePath,
                                                     LastUpdateDate_UTC = c.LastUpdateDate_UTC,
                                                     LastUpdateContactTVItemID = c.LastUpdateContactTVItemID,
                                                 }).ToList<TVFileModel>();

            return tvFileModelList;

        }

        // Helper

        public string ChoseEDriveOrCDrive(string ServerFilePath)
        {
            if (System.Environment.UserName == "charl" || System.Environment.UserName == "leblancc" || System.Environment.UserName == "admin-leblancc" || System.Environment.UserName == "WMON01DTCHLEBL2$")
            {
                ServerFilePath = ServerFilePath.Replace(@"C:\", @"E:\");
            }
            else
            {
                ServerFilePath = ServerFilePath.Replace(@"E:\", @"C:\");
            }

            return ServerFilePath;
        }
        public List<string> GetAllowableExt()
        {
            return new List<string>() { ".accde", ".csv", ".doc", ".docx", ".htm", ".html", ".jpeg", ".jpg", ".gif", ".kml", ".kmz", ".log", ".mdb", ".pdf", ".png", ".ppt", ".pptx", ".txt", ".xls", ".xlsx", ".wmv" };
        }
        public List<string> GetAllowableTemplateExt()
        {
            return new List<string>() { ".docx", ".xlsx", ".kml" };
        }
        public List<string> GetAllowableMime()
        {
            return new List<string>()
            {
                "application/msaccess.exec",
                "application/vnd.ms-excel",
                "application/msword",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "text/html",
                "text/html",
                "image/jpeg",
                "image/jpeg",
                "image/gif",
                "application/vnd.google-earth.kml+xml",
                "application/vnd.google-earth.kmz",
                "application/unknown",
                "application/msaccess",
                "application/pdf",
                "image/png",
                "application/vnd.ms-powerpoint",
                "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                "text/plain",
                "application/vnd.ms-excel",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", };
        }
        public List<string> GetAllowableFileGeneratedType()
        {
            return new List<string>() { ".kmz", ".docx", ".xlsx", ".html", ".pdf", ".txt" };
        }
        public bool GetFileExist(FileInfo fi)
        {
            return fi.Exists;
        }
        public bool IsAllowableFileGeneratedType(FileInfo fi, List<string> allowableFileGeneratedType)
        {
            return allowableFileGeneratedType.Contains(fi.Extension);
        }
        public TVFileModel FileEditSaveDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            int TVFileTVItemID = 0;
            int tempInt = 0;
            LanguageEnum Language = LanguageEnum.Error;
            FilePurposeEnum FilePurpose = FilePurposeEnum.Error;
            string FileDescription = "";
            string SaveAsFileName = "";
            bool? FromWater = null;
            int? Year = null;

            int.TryParse(fc["TVFileTVItemID"], out TVFileTVItemID);
            if (TVFileTVItemID == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVFileTVItemID));

            int.TryParse(fc["Language"], out tempInt);
            if (tempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.Language));

            Language = (LanguageEnum)tempInt;

            int.TryParse(fc["Year"], out tempInt);
            if (tempInt == 0)
            {
                tempInt = DateTime.Now.Year;
            }

            Year = tempInt;

            int.TryParse(fc["FilePurpose"], out tempInt);
            if (tempInt == 0)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.FilePurpose));

            FilePurpose = (FilePurposeEnum)tempInt;

            FileDescription = fc["FileDescription"];
            if (string.IsNullOrWhiteSpace(FileDescription))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.FileDescription));

            SaveAsFileName = fc["SaveAsFileName"];
            if (string.IsNullOrWhiteSpace(SaveAsFileName))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SaveAsFileName));

            if (fc["FromWater"] != null)
            {
                if (string.IsNullOrWhiteSpace(fc["FromWater"]))
                {
                    FromWater = null;
                }
                else
                {
                    FromWater = true;
                }
            }

            TVFileModel tvFileModelRet = GetTVFileModelWithTVFileTVItemIDDB(TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
                return ReturnError(tvFileModelRet.Error);

            tvFileModelRet.FilePurpose = FilePurpose;
            tvFileModelRet.FileDescription = FileDescription;
            tvFileModelRet.FromWater = FromWater;
            tvFileModelRet.Language = Language;
            tvFileModelRet.Year = Year;

            FileInfo fiActual = new FileInfo(tvFileModelRet.ServerFilePath + tvFileModelRet.ServerFileName);
            if (!fiActual.Exists)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_, fiActual.FullName));

            FileInfo fiNew = new FileInfo(tvFileModelRet.ServerFilePath + SaveAsFileName + fiActual.Extension);

            using (TransactionScope ts = new TransactionScope())
            {
                if (fiActual.FullName != fiNew.FullName)
                {
                    if (fiNew.Exists)
                        return ReturnError(string.Format(ServiceRes._AlreadyExists, fiNew.FullName));

                    TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(tvFileModelRet.TVFileTVItemID);
                    if (string.IsNullOrWhiteSpace(SaveAsFileName))
                        return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.SaveAsFileName));

                    foreach (LanguageEnum lang in LanguageListAllowable)
                    {
                        TVItemLanguageModel tvItemLanguageModel = _TVItemService._TVItemLanguageService.GetTVItemLanguageModelWithTVItemIDAndLanguageDB(tvItemModel.TVItemID, lang);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);

                        tvItemLanguageModel.TVText = fiNew.Name;

                        TVItemLanguageModel tvItemLanguageModelRet = _TVItemService._TVItemLanguageService.PostUpdateTVItemLanguageDB(tvItemLanguageModel);
                        if (!string.IsNullOrWhiteSpace(tvItemLanguageModel.Error))
                            return ReturnError(tvItemLanguageModel.Error);
                    }

                    tvFileModelRet.ServerFileName = fiNew.Name;

                    //File.Copy(ChoseEDriveOrCDrive(fiActual.FullName), ChoseEDriveOrCDrive(fiNew.FullName));

                    //fiNew = new FileInfo(fiNew.FullName);
                    //if (!fiNew.Exists)
                    //    return ReturnError(string.Format(ServiceRes.CouldNotFind_, fiActual.FullName));

                    //File.Delete(ChoseEDriveOrCDrive(fiActual.FullName));
                }

                tvFileModelRet = PostUpdateTVFileDB(tvFileModelRet);
                if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
                    return ReturnError(tvFileModelRet.Error);

                ts.Complete();
            }
            return ReturnError("");
        }
        public TVFileModel CreateArcGISDocumentDB(FormCollection fc)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            int TVItemID = 0;
            string ProvinceTVItemIDText = "";
            bool Active = false;
            bool Inactive = false;
            string DocType = "";

            if (!int.TryParse(fc["TVItemID"], out TVItemID))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID));

            ProvinceTVItemIDText = fc["ProvinceTVItemIDText"];
            if (string.IsNullOrWhiteSpace(ProvinceTVItemIDText))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ProvinceTVItemIDText));

            Active = bool.Parse(fc["Active"]);
            Inactive = bool.Parse(fc["Inactive"]);

            DocType = fc["DocType"];
            if (string.IsNullOrWhiteSpace(DocType))
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.DocType));

            if (!Active && !Inactive)
                return ReturnError(string.Format(ServiceRes._IsRequired, ServiceRes.ActiveOrInactive));

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(TVItemID, TVItemID, AppTaskCommandEnum.ExportToArcGIS);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return ReturnError(appTaskModelExist.Error);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "ProvinceTVItemIDText", Value = ProvinceTVItemIDText.Replace(",", "_").ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "Active", Value = Active.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "Inactive", Value = Inactive.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "DocType", Value = DocType.ToString() });

            StringBuilder sbParameters = new StringBuilder();
            int count = 0;
            foreach (AppTaskParameter atp in appTaskParameterList)
            {
                if (count == 0)
                {
                    sbParameters.Append("|||");
                }
                sbParameters.Append(atp.Name + "," + atp.Value + "|||");
                count += 1;
            }

            AppTaskModel appTaskModelNew = new AppTaskModel()
            {
                DBCommand = DBCommandEnum.Original,
                TVItemID = TVItemID,
                TVItemID2 = TVItemID,
                AppTaskCommand = AppTaskCommandEnum.ExportToArcGIS,
                ErrorText = "",
                StatusText = ServiceRes.ExportToArcGIS,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = sbParameters.ToString(),
                Language = LanguageRequest,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
            };

            AppTaskModel appTaskModelRet = _AppTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                return ReturnError(appTaskModelRet.Error);

            return ReturnError("");
        }
        public string GetInfrastructuresForInputToolDB(int MunicipalityTVItemID)
        {
            StringBuilder sb = new StringBuilder();

            string ServerFilePath = GetServerFilePath(MunicipalityTVItemID);

            TVItemModel tvItemModelMunicipality = _TVItemService.GetTVItemModelWithTVItemIDDB(MunicipalityTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelMunicipality.Error))
            {
                return tvItemModelMunicipality.Error;
            }

            string TVText = tvItemModelMunicipality.TVText;
            if (TVText.Contains(" "))
            {
                TVText = TVText.Substring(0, TVText.IndexOf(" ")).Trim();
            }

            DirectoryInfo di = new DirectoryInfo(ChoseEDriveOrCDrive(ServerFilePath));

            string illegalChar = "<>:\"/\\|?*.";

            string NewTVText = TVText;
            foreach (char c in illegalChar)
            {
                TVText = TVText.Replace(c.ToString(), "_");
            }

            FileInfo fi = new FileInfo(ChoseEDriveOrCDrive(ServerFilePath) + TVText + ".txt");

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    return ex.Message + (ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : "");
                }
            }

            sb.AppendLine("VERSION\t1\t");
            DateTime CurrentTime = DateTime.UtcNow;
            sb.AppendLine($"DOCDATE\t{CurrentTime.Year}|{CurrentTime.Month.ToString("0#")}|{CurrentTime.Day.ToString("0#")}|{CurrentTime.Hour.ToString("0#")}|{CurrentTime.Minute.ToString("0#")}|{CurrentTime.Second.ToString("0#")}\t");

            TVItemModel tvItemModelProvince = null;
            List<TVItemModel> tvItemModelParentList = _TVItemService.GetParentsTVItemModelList(tvItemModelMunicipality.TVPath);

            foreach (TVItemModel tvItemModel in tvItemModelParentList)
            {
                if (tvItemModel.TVType == TVTypeEnum.Province)
                {
                    tvItemModelProvince = tvItemModel;
                    break;
                }
            }

            if (tvItemModelProvince == null)
            {
                return string.Format(ServiceRes.CouldNotFindParent_WithChild_Equal_, ServiceRes.Province, ServiceRes.Municipality, tvItemModelMunicipality.TVPath);
            }

            List<TVItemModel> tvItemModelMunicipalityList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProvince.TVItemID, TVTypeEnum.Municipality);

            string MunicipalityListText = "";
            foreach (TVItemModel tvItemModel in tvItemModelMunicipalityList)
            {
                MunicipalityListText = MunicipalityListText + tvItemModel.TVText.Replace("\t", "_").Replace("|", "_").Replace("[", "_").Replace("]", "_") + "[" + tvItemModel.TVItemID + "]" + "|";
            }

            sb.AppendLine($"PROVINCETVITEMID\t{ tvItemModelProvince.TVItemID }");
            sb.AppendLine($"PROVINCEMUNICIPALITIES\t{ MunicipalityListText }");

            sb.AppendLine($"MUNICIPALITY\t{tvItemModelMunicipality.TVItemID}\t{tvItemModelMunicipality.TVText}\t");

            MapInfo mapInfo = new MapInfo();
            MapInfoPoint mapInfoPoint = new MapInfoPoint();

            var mapInfoList = (from mi in _TVItemService.db.MapInfos
                               from mip in _TVItemService.db.MapInfoPoints
                               where mi.MapInfoID == mip.MapInfoID
                               && mi.TVType == (int)TVTypeEnum.Municipality
                               && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                               && mi.TVItemID == tvItemModelMunicipality.TVItemID
                               select new { mi, mip }).ToList();

            mapInfo = mapInfoList.Where(c => c.mi.TVItemID == tvItemModelMunicipality.TVItemID).Select(c => c.mi).FirstOrDefault();
            mapInfoPoint = mapInfoList.Where(c => c.mip.MapInfoID == mapInfo.MapInfoID).Select(c => c.mip).FirstOrDefault();

            string LatText2 = mapInfoPoint != null ? mapInfoPoint.Lat.ToString("F5") : "";
            string LngText2 = mapInfoPoint != null ? mapInfoPoint.Lng.ToString("F5") : "";
            sb.AppendLine($"MUNICIPALITYLATLNG\t{LatText2}\t{LngText2}\t");

            List<TVItemLinkModel> tvItemLinkModelList = _TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(tvItemModelMunicipality.TVItemID);

            foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList)
            {
                if (tvItemLinkModel.FromTVType == TVTypeEnum.Municipality && tvItemLinkModel.ToTVType == TVTypeEnum.Contact)
                {
                    ContactModel contactModel = _ContactService.GetContactModelWithContactTVItemIDDB(tvItemLinkModel.ToTVItemID);

                    TVItemModel tvItemModelContact = _TVItemService.GetTVItemModelWithTVItemIDDB(tvItemLinkModel.ToTVItemID);

                    if (string.IsNullOrWhiteSpace(tvItemModelContact.Error))
                    {
                        string IsActiveContactTxt = (tvItemModelContact.IsActive ? "true" : "false");
                        int contactTitle = contactModel.ContactTitle == null ? ((int)ContactTitleEnum.Error) : ((int)contactModel.ContactTitle);
                        if (string.IsNullOrWhiteSpace(contactModel.Error))
                        {
                            sb.AppendLine($"CONTACT\t{contactModel.ContactTVItemID}\t{contactModel.FirstName}\t{contactModel.Initial}\t{contactModel.LastName}\t{contactModel.LoginEmail}\t{contactTitle}\t{IsActiveContactTxt}\t");
                        }
                        else
                        {
                            sb.AppendLine($"CONTACT\tERROR\tERROR\tERROR\tERROR\tERROR\tERROR\tERROR\t");
                        }
                    }
                    else
                    {
                        sb.AppendLine($"CONTACT\tERROR\tERROR\tERROR\tERROR\tERROR\tERROR\tERROR\t");
                    }

                    List<TVItemLinkModel> tvItemLinkModelList2 = _TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(tvItemLinkModel.ToTVItemID);

                    // doing Telephone
                    foreach (TVItemLinkModel tvItemLinkModel2 in tvItemLinkModelList2)
                    {
                        if (tvItemLinkModel2.FromTVType == TVTypeEnum.Contact && tvItemLinkModel2.ToTVType == TVTypeEnum.Tel)
                        {
                            TelModel telModel = _TelService.GetTelModelWithTelTVItemIDDB(tvItemLinkModel2.ToTVItemID);

                            if (string.IsNullOrWhiteSpace(telModel.Error))
                            {
                                sb.AppendLine($"CONTACTTELEPHONE\t{telModel.TelTVItemID}\t{(int)telModel.TelType}\t{telModel.TelNumber}\t");
                            }
                            else
                            {
                                sb.AppendLine($"CONTACTTELEPHONE\tERROR\tERROR\tERROR\t");
                            }
                        }
                    }

                    // doing Email
                    foreach (TVItemLinkModel tvItemLinkModel2 in tvItemLinkModelList2)
                    {
                        if (tvItemLinkModel2.FromTVType == TVTypeEnum.Contact && tvItemLinkModel2.ToTVType == TVTypeEnum.Email)
                        {
                            EmailModel emailModel = _EmailService.GetEmailModelWithEmailTVItemIDDB(tvItemLinkModel2.ToTVItemID);

                            if (string.IsNullOrWhiteSpace(emailModel.Error))
                            {
                                sb.AppendLine($"CONTACTEMAIL\t{emailModel.EmailTVItemID}\t{(int)emailModel.EmailType}\t{emailModel.EmailAddress}\t");
                            }
                            else
                            {
                                sb.AppendLine($"CONTACTEMAIL\tERROR\tERROR\tERROR\t");
                            }
                        }
                    }

                    // doing Contact Address
                    foreach (TVItemLinkModel tvItemLinkModel2 in tvItemLinkModelList2)
                    {
                        if (tvItemLinkModel2.FromTVType == TVTypeEnum.Contact && tvItemLinkModel2.ToTVType == TVTypeEnum.Address)
                        {
                            AddressModel addressModel = _AddressService.GetAddressModelWithAddressTVItemIDDB(tvItemLinkModel2.ToTVItemID);

                            if (string.IsNullOrWhiteSpace(addressModel.Error))
                            {
                                sb.AppendLine($"CONTACTADDRESS\t{addressModel.AddressTVItemID}\t{addressModel.MunicipalityTVText}\t{((int)addressModel.AddressType).ToString()}\t{addressModel.StreetNumber}\t{addressModel.StreetName}\t{((int)addressModel.StreetType).ToString()}\t{addressModel.PostalCode}\t");
                            }
                            else
                            {
                                sb.AppendLine($"CONTACTADDRESS\tERROR\tERROR\tERROR\tERROR\tERROR\tERROR\tERROR\t");
                            }
                        }
                    }
                }
            }

            List<TVItemModel> tvItemModelInfrastructureList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelMunicipality.TVItemID, TVTypeEnum.Infrastructure);

            foreach (TVItemModel tvItemModelInfrastructure in tvItemModelInfrastructureList)
            {
                InfrastructureModel infrastructureModel = _InfrastructureService.GetInfrastructureModelWithInfrastructureTVItemIDDB(tvItemModelInfrastructure.TVItemID);

                if (infrastructureModel == null || infrastructureModel.InfrastructureType == null)
                {
                    continue;
                }

                MapInfo mapInfoOutfall = new MapInfo();
                MapInfoPoint mapInfoPointOutfall = new MapInfoPoint();

                TVTypeEnum tvTypeInfrastructure = TVTypeEnum.Error;

                if (infrastructureModel.InfrastructureType == InfrastructureTypeEnum.LiftStation)
                {
                    tvTypeInfrastructure = TVTypeEnum.LiftStation;
                }
                else if (infrastructureModel.InfrastructureType == InfrastructureTypeEnum.WWTP)
                {
                    tvTypeInfrastructure = TVTypeEnum.WasteWaterTreatmentPlant;
                }
                else if (infrastructureModel.InfrastructureType == InfrastructureTypeEnum.LineOverflow)
                {
                    tvTypeInfrastructure = TVTypeEnum.LineOverflow;
                }
                else if (infrastructureModel.InfrastructureType == InfrastructureTypeEnum.Other)
                {
                    tvTypeInfrastructure = TVTypeEnum.OtherInfrastructure;
                }
                else if (infrastructureModel.InfrastructureType == InfrastructureTypeEnum.SeeOtherMunicipality)
                {
                    tvTypeInfrastructure = TVTypeEnum.SeeOtherMunicipality;
                }
                else
                {
                    tvTypeInfrastructure = TVTypeEnum.Error;
                }

                if (tvTypeInfrastructure == TVTypeEnum.OtherInfrastructure)
                {
                    continue;
                }

                mapInfoList = (from mi in _TVItemService.db.MapInfos
                               from mip in _TVItemService.db.MapInfoPoints
                               where mi.MapInfoID == mip.MapInfoID
                               && mi.TVType == (int)tvTypeInfrastructure
                               && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                               && mi.TVItemID == tvItemModelInfrastructure.TVItemID
                               select new { mi, mip }).ToList();

                mapInfo = mapInfoList.Where(c => c.mi.TVItemID == tvItemModelInfrastructure.TVItemID).Select(c => c.mi).FirstOrDefault();
                mapInfoPoint = mapInfoList.Where(c => c.mip.MapInfoID == mapInfo.MapInfoID).Select(c => c.mip).FirstOrDefault();

                var mapInfoListOutfall = (from mi in _TVItemService.db.MapInfos
                                          from mip in _TVItemService.db.MapInfoPoints
                                          where mi.MapInfoID == mip.MapInfoID
                                          && mi.TVType == (int)TVTypeEnum.Outfall
                                          && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                          && mi.TVItemID == tvItemModelInfrastructure.TVItemID
                                          select new { mi, mip }).ToList();

                mapInfoOutfall = mapInfoListOutfall.Where(c => c.mi.TVItemID == tvItemModelInfrastructure.TVItemID).Select(c => c.mi).FirstOrDefault();
                mapInfoPointOutfall = mapInfoListOutfall.Where(c => c.mip.MapInfoID == mapInfoOutfall.MapInfoID).Select(c => c.mip).FirstOrDefault();

                string IsActiveTxt = (tvItemModelInfrastructure.IsActive ? "true" : "false");

                sb.AppendLine($"-----\t-------------------------------------------------\t");
                sb.AppendLine($"INFRASTRUCTURE\t{tvItemModelInfrastructure.TVItemID}\t{infrastructureModel.LastUpdateDate_UTC.Year}|" +
                    $"{infrastructureModel.LastUpdateDate_UTC.Month.ToString("0#")}|{infrastructureModel.LastUpdateDate_UTC.Day.ToString("0#")}|" +
                    $"{infrastructureModel.LastUpdateDate_UTC.Hour.ToString("0#")}|{infrastructureModel.LastUpdateDate_UTC.Minute.ToString("0#")}|" +
                    $"{infrastructureModel.LastUpdateDate_UTC.Second.ToString("0#")}\t{IsActiveTxt}\t");

                string LatText = mapInfoPoint != null ? mapInfoPoint.Lat.ToString("F5") : "";
                string LngText = mapInfoPoint != null ? mapInfoPoint.Lng.ToString("F5") : "";
                sb.AppendLine($"LATLNG\t{LatText}\t{LngText}\t");

                string LatOutfallText = mapInfoPointOutfall != null ? mapInfoPointOutfall.Lat.ToString("F5") : "";
                string LngOutfallText = mapInfoPointOutfall != null ? mapInfoPointOutfall.Lng.ToString("F5") : "";
                sb.AppendLine($"LATLNGOUTFALL\t{LatOutfallText}\t{LngOutfallText}\t");

                while (tvItemModelInfrastructure.TVText.Contains("  "))
                {
                    tvItemModelInfrastructure.TVText = tvItemModelInfrastructure.TVText.Replace("  ", " ");
                }
                sb.AppendLine($"TVTEXT\t{tvItemModelInfrastructure.TVText.Replace(",", "_").Replace("\t", "_").Replace("\r", "_").Replace("\n", "_")}\t");


                TVTypeEnum tvTypeInf = TVTypeEnum.Error;
                switch (infrastructureModel.InfrastructureType)
                {
                    case InfrastructureTypeEnum.LiftStation:
                        {
                            tvTypeInf = TVTypeEnum.LiftStation;
                        }
                        break;
                    case InfrastructureTypeEnum.LineOverflow:
                        {
                            tvTypeInf = TVTypeEnum.LineOverflow;
                        }
                        break;
                    case InfrastructureTypeEnum.WWTP:
                        {
                            tvTypeInf = TVTypeEnum.WasteWaterTreatmentPlant;
                        }
                        break;
                    default:
                        break;
                }

                // getting line path for infrastructure to other infrastructure
                List<MapInfoPoint> mapInfoPointInfList = (from mi in _TVItemService.db.MapInfos
                                                          from mip in _TVItemService.db.MapInfoPoints
                                                          where mi.MapInfoID == mip.MapInfoID
                                                          && mi.TVType == (int)tvTypeInf
                                                          && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Polyline
                                                          && mi.TVItemID == tvItemModelInfrastructure.TVItemID
                                                          select mip).ToList();

                StringBuilder LinePathInf = new StringBuilder();
                int mapInfoID = 0;
                if (mapInfoPointInfList.Count > 0)
                {
                    mapInfoID = mapInfoPointInfList[0].MapInfoID;
                    foreach (MapInfoPoint mapInfoPointInf in mapInfoPointInfList)
                    {
                        LinePathInf.Append($"|{mapInfoPointInf.Lat.ToString("F5")},{mapInfoPointInf.Lng.ToString("F5")}");
                    }
                }
                else
                {
                    mapInfoID = 10000000;
                    LinePathInf.Append($"|{ LatText },{ LngText }|{ LatText },{ LngText }");
                }

                sb.AppendLine($"LINEPATHINF\t{mapInfoID}\t{LinePathInf}\t");

                // getting line path for infrastructure to outfall
                List<MapInfoPoint> mapInfoPointInfOutList = (from mi in _TVItemService.db.MapInfos
                                                          from mip in _TVItemService.db.MapInfoPoints
                                                          where mi.MapInfoID == mip.MapInfoID
                                                          && mi.TVType == (int)TVTypeEnum.Outfall
                                                          && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Polyline
                                                          && mi.TVItemID == tvItemModelInfrastructure.TVItemID
                                                          select mip).ToList();

                StringBuilder LinePathInfOut = new StringBuilder();
                int mapInfoIDOut = 0;
                if (mapInfoPointInfOutList.Count > 0)
                {
                    mapInfoIDOut = mapInfoPointInfOutList[0].MapInfoID;
                    foreach (MapInfoPoint mapInfoPointInfOut in mapInfoPointInfOutList)
                    {
                        LinePathInfOut.Append($"|{mapInfoPointInfOut.Lat.ToString("F5")},{mapInfoPointInfOut.Lng.ToString("F5")}");
                    }
                }
                else
                {
                    mapInfoIDOut = 10000000;
                    LinePathInfOut.Append($"|{ LatText },{ LngText }|{ LatOutfallText },{ LngOutfallText }");
                }

                sb.AppendLine($"LINEPATHINFOUTFALL\t{mapInfoIDOut}\t{LinePathInfOut}\t");

                sb.AppendLine($"LINEPATHCHANGED\tfalse\t");

                string CommentEN = "";
                string CommentFR = "";

                InfrastructureLanguageModel infrastructureLanguageModelEN = _InfrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModel.InfrastructureID, LanguageEnum.en);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelEN.Error))
                {
                    return infrastructureLanguageModelEN.Error;
                }

                CommentEN = string.IsNullOrWhiteSpace(infrastructureLanguageModelEN.Comment) ? "" : infrastructureLanguageModelEN.Comment.Replace("\r\n", "|||").Replace("\n", "|||").Replace("\r", "|||").Replace("\t", "_");
                sb.AppendLine($"COMMENTEN\t{CommentEN}\t");

                InfrastructureLanguageModel infrastructureLanguageModelFR = _InfrastructureService._InfrastructureLanguageService.GetInfrastructureLanguageModelWithInfrastructureIDAndLanguageDB(infrastructureModel.InfrastructureID, LanguageEnum.fr);
                if (!string.IsNullOrWhiteSpace(infrastructureLanguageModelFR.Error))
                {
                    return infrastructureLanguageModelFR.Error;
                }

                CommentFR = string.IsNullOrWhiteSpace(infrastructureLanguageModelFR.Comment) ? "" : infrastructureLanguageModelFR.Comment.Replace("\r\n", "|||").Replace("\n", "|||").Replace("\r", "|||").Replace("\t", "_");
                sb.AppendLine($"COMMENTFR\t{CommentFR}\t");

                string INFRASTRUCTURETYPE = infrastructureModel.InfrastructureType != null ? ((int)infrastructureModel.InfrastructureType).ToString() : "";
                sb.AppendLine($"INFRASTRUCTURETYPE\t{INFRASTRUCTURETYPE}\t");
                string FACILITYTYPE = infrastructureModel.FacilityType != null ? ((int)infrastructureModel.FacilityType).ToString() : "";
                sb.AppendLine($"FACILITYTYPE\t{FACILITYTYPE}\t");
                string ISMECHANICALLYAERATED = infrastructureModel.IsMechanicallyAerated != null ? ((bool)infrastructureModel.IsMechanicallyAerated) == true ? "true" : "false" : "";
                sb.AppendLine($"ISMECHANICALLYAERATED\t{ISMECHANICALLYAERATED}\t");
                string NUMBEROFCELLS = infrastructureModel.NumberOfCells != null ? ((int)infrastructureModel.NumberOfCells).ToString() : "";
                sb.AppendLine($"NUMBEROFCELLS\t{NUMBEROFCELLS}\t");
                string NUMBEROFAERATEDCELLS = infrastructureModel.NumberOfAeratedCells != null ? ((int)infrastructureModel.NumberOfAeratedCells).ToString() : "";
                sb.AppendLine($"NUMBEROFAERATEDCELLS\t{NUMBEROFAERATEDCELLS}\t");
                string AERATIONTYPE = infrastructureModel.AerationType != null ? ((int)infrastructureModel.AerationType).ToString() : "";
                sb.AppendLine($"AERATIONTYPE\t{AERATIONTYPE}\t");
                string PRELIMINARYTREATMENTTYPE = infrastructureModel.PreliminaryTreatmentType != null ? ((int)infrastructureModel.PreliminaryTreatmentType).ToString() : "";
                sb.AppendLine($"PRELIMINARYTREATMENTTYPE\t{PRELIMINARYTREATMENTTYPE}\t");
                string PRIMARYTREATMENTTYPE = infrastructureModel.PrimaryTreatmentType != null ? ((int)infrastructureModel.PrimaryTreatmentType).ToString() : "";
                sb.AppendLine($"PRIMARYTREATMENTTYPE\t{PRIMARYTREATMENTTYPE}\t");
                string SECONDARYTREATMENTTYPE = infrastructureModel.SecondaryTreatmentType != null ? ((int)infrastructureModel.SecondaryTreatmentType).ToString() : "";
                sb.AppendLine($"SECONDARYTREATMENTTYPE\t{SECONDARYTREATMENTTYPE}\t");
                string TERTIARYTREATMENTTYPE = infrastructureModel.TertiaryTreatmentType != null ? ((int)infrastructureModel.TertiaryTreatmentType).ToString() : "";
                sb.AppendLine($"TERTIARYTREATMENTTYPE\t{TERTIARYTREATMENTTYPE}\t");
                string DISINFECTIONTYPE = infrastructureModel.DisinfectionType != null ? ((int)infrastructureModel.DisinfectionType).ToString() : "";
                sb.AppendLine($"DISINFECTIONTYPE\t{DISINFECTIONTYPE}\t");
                string COLLECTIONSYSTEMTYPE = infrastructureModel.CollectionSystemType != null ? ((int)infrastructureModel.CollectionSystemType).ToString() : "";
                sb.AppendLine($"COLLECTIONSYSTEMTYPE\t{COLLECTIONSYSTEMTYPE}\t");
                string ALARMSYSTEMTYPE = infrastructureModel.AlarmSystemType != null ? ((int)infrastructureModel.AlarmSystemType).ToString() : "";
                sb.AppendLine($"ALARMSYSTEMTYPE\t{ALARMSYSTEMTYPE}\t");
                string DESIGNFLOW_M3_DAY = infrastructureModel.DesignFlow_m3_day != null ? ((float)infrastructureModel.DesignFlow_m3_day).ToString("F3") : "";
                sb.AppendLine($"DESIGNFLOW_M3_DAY\t{DESIGNFLOW_M3_DAY}\t");
                string AVERAGEFLOW_M3_DAY = infrastructureModel.AverageFlow_m3_day != null ? ((float)infrastructureModel.AverageFlow_m3_day).ToString("F3") : "";
                sb.AppendLine($"AVERAGEFLOW_M3_DAY\t{AVERAGEFLOW_M3_DAY}\t");
                string PEAKFLOW_M3_DAY = infrastructureModel.PeakFlow_m3_day != null ? ((float)infrastructureModel.PeakFlow_m3_day).ToString("F3") : "";
                sb.AppendLine($"PEAKFLOW_M3_DAY\t{PEAKFLOW_M3_DAY}\t");
                string POPSERVED = infrastructureModel.PopServed != null ? ((int)infrastructureModel.PopServed).ToString() : "";
                sb.AppendLine($"POPSERVED\t{POPSERVED}\t");
                string CANOVERFLOW = infrastructureModel.CanOverflow != null ? ((bool)infrastructureModel.CanOverflow) == true ? "true" : "false" : "";
                sb.AppendLine($"CANOVERFLOW\t{CANOVERFLOW}\t");
                string VALVETYPE = infrastructureModel.ValveType != null ? ((int)infrastructureModel.ValveType).ToString() : "";
                sb.AppendLine($"VALVETYPE\t{VALVETYPE}\t");
                string HASBACKUPPOWER = infrastructureModel.HasBackupPower != null ? ((bool)infrastructureModel.HasBackupPower) == true ? "true" : "false" : "";
                sb.AppendLine($"HASBACKUPPOWER\t{HASBACKUPPOWER}\t");
                string PERCFLOWOFTOTAL = infrastructureModel.PercFlowOfTotal != null ? ((float)infrastructureModel.PercFlowOfTotal).ToString("F3") : "";
                sb.AppendLine($"PERCFLOWOFTOTAL\t{PERCFLOWOFTOTAL}\t");
                string AVERAGEDEPTH_M = infrastructureModel.AverageDepth_m != null ? ((float)infrastructureModel.AverageDepth_m).ToString("F3") : "";
                sb.AppendLine($"AVERAGEDEPTH_M\t{AVERAGEDEPTH_M}\t");
                string NUMBEROFPORTS = infrastructureModel.NumberOfPorts != null ? ((int)infrastructureModel.NumberOfPorts).ToString() : "";
                sb.AppendLine($"NUMBEROFPORTS\t{NUMBEROFPORTS}\t");
                string PORTDIAMETER_M = infrastructureModel.PortDiameter_m != null ? ((float)infrastructureModel.PortDiameter_m).ToString("F3") : "";
                sb.AppendLine($"PORTDIAMETER_M\t{PORTDIAMETER_M}\t");
                string PORTSPACING_M = infrastructureModel.PortSpacing_m != null ? ((float)infrastructureModel.PortSpacing_m).ToString("F3") : "";
                sb.AppendLine($"PORTSPACING_M\t{PORTSPACING_M}\t");
                string PORTELEVATION_M = infrastructureModel.PortElevation_m != null ? ((float)infrastructureModel.PortElevation_m).ToString("F3") : "";
                sb.AppendLine($"PORTELEVATION_M\t{PORTELEVATION_M}\t");
                string VERTICALANGLE_DEG = infrastructureModel.VerticalAngle_deg != null ? ((float)infrastructureModel.VerticalAngle_deg).ToString("F3") : "";
                sb.AppendLine($"VERTICALANGLE_DEG\t{VERTICALANGLE_DEG}\t");
                string HORIZONTALANGLE_DEG = infrastructureModel.HorizontalAngle_deg != null ? ((float)infrastructureModel.HorizontalAngle_deg).ToString("F3") : "";
                sb.AppendLine($"HORIZONTALANGLE_DEG\t{HORIZONTALANGLE_DEG}\t");
                string DECAYRATE_PER_DAY = infrastructureModel.DecayRate_per_day != null ? ((float)infrastructureModel.DecayRate_per_day).ToString("F3") : "";
                sb.AppendLine($"DECAYRATE_PER_DAY\t{DECAYRATE_PER_DAY}\t");
                string NEARFIELDVELOCITY_M_S = infrastructureModel.NearFieldVelocity_m_s != null ? ((float)infrastructureModel.NearFieldVelocity_m_s).ToString("F3") : "";
                sb.AppendLine($"NEARFIELDVELOCITY_M_S\t{NEARFIELDVELOCITY_M_S}\t");
                string FARFIELDVELOCITY_M_S = infrastructureModel.FarFieldVelocity_m_s != null ? ((float)infrastructureModel.FarFieldVelocity_m_s).ToString("F3") : "";
                sb.AppendLine($"FARFIELDVELOCITY_M_S\t{FARFIELDVELOCITY_M_S}\t");
                string RECEIVINGWATERSALINITY_PSU = infrastructureModel.ReceivingWaterSalinity_PSU != null ? ((float)infrastructureModel.ReceivingWaterSalinity_PSU).ToString("F3") : "";
                sb.AppendLine($"RECEIVINGWATERSALINITY_PSU\t{RECEIVINGWATERSALINITY_PSU}\t");
                string RECEIVINGWATERTEMPERATURE_C = infrastructureModel.ReceivingWaterTemperature_C != null ? ((float)infrastructureModel.ReceivingWaterTemperature_C).ToString("F3") : "";
                sb.AppendLine($"RECEIVINGWATERTEMPERATURE_C\t{RECEIVINGWATERTEMPERATURE_C}\t");
                string RECEIVINGWATER_MPN_PER_100ML = infrastructureModel.ReceivingWater_MPN_per_100ml != null ? ((int)infrastructureModel.ReceivingWater_MPN_per_100ml).ToString() : "";
                sb.AppendLine($"RECEIVINGWATER_MPN_PER_100ML\t{RECEIVINGWATER_MPN_PER_100ML}\t");
                string DISTANCEFROMSHORE_M = infrastructureModel.DistanceFromShore_m != null ? ((float)infrastructureModel.DistanceFromShore_m).ToString("F3") : "";
                sb.AppendLine($"DISTANCEFROMSHORE_M\t{DISTANCEFROMSHORE_M}\t");
                string SeeOtherMunicipalityTVItemID = infrastructureModel.SeeOtherMunicipalityTVItemID != null ? ((int)infrastructureModel.SeeOtherMunicipalityTVItemID).ToString() : "";
                string SeeOtherMunicipalityText = "";
                foreach (TVItemModel tvItemModel in tvItemModelMunicipalityList)
                {
                    if (tvItemModel.TVItemID == infrastructureModel.SeeOtherMunicipalityTVItemID)
                    {
                        SeeOtherMunicipalityText = tvItemModel.TVText;
                    }
                }
                sb.AppendLine($"SEEOTHERMUNICIPALITY\t{ SeeOtherMunicipalityTVItemID }\t{ SeeOtherMunicipalityText.Replace(",", "_").Replace("\t", "_").Replace("\r", "_").Replace("\n", "_") }\t");

                List<TVItemLinkModel> tvItemLinkModelList2 = _TVItemLinkService.GetTVItemLinkModelListWithFromTVItemIDDB(tvItemModelInfrastructure.TVItemID);
                foreach (TVItemLinkModel tvItemLinkModel in tvItemLinkModelList2)
                {
                    if (tvItemLinkModel.FromTVItemID == tvItemModelInfrastructure.TVItemID && tvItemLinkModel.FromTVType == TVTypeEnum.Infrastructure)
                    {
                        if (tvItemLinkModel.ToTVItemID != tvItemModelInfrastructure.TVItemID && tvItemLinkModel.ToTVType == TVTypeEnum.Infrastructure)
                        {
                            string PUMPSTOTVITEMID = tvItemLinkModel.ToTVItemID.ToString();
                            sb.AppendLine($"PUMPSTOTVITEMID\t{PUMPSTOTVITEMID}\t");
                            break;
                        }
                    }
                }

                //List<MapInfoPoint> mapInfoPointListPath = (from mi in _TVItemService.db.MapInfos
                //                                           from mip in _TVItemService.db.MapInfoPoints
                //                                           where mi.MapInfoID == mip.MapInfoID
                //                                           && mi.TVType == (int)tvTypeInfrastructure
                //                                           && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Polyline
                //                                           && mi.TVItemID == tvItemModelInfrastructure.TVItemID
                //                                           select mip).ToList();

                //string PATHCOORDLIST = "";
                //foreach (MapInfoPoint mip in mapInfoPointListPath.OrderBy(c => c.Ordinal))
                //{
                //    PATHCOORDLIST = PATHCOORDLIST + mip.Lat.ToString("F5") + "|" + mip.Lng.ToString("F5") + " ";
                //}

                //sb.AppendLine($"PATHCOORDLIST\t{PATHCOORDLIST}\t");


                if (infrastructureModel.CivicAddressTVItemID != null)
                {
                    AddressModel addressModel = _AddressService.GetAddressModelWithAddressTVItemIDDB((int)infrastructureModel.CivicAddressTVItemID);

                    if (string.IsNullOrWhiteSpace(addressModel.Error))
                    {
                        sb.AppendLine($"ADDRESS\t{addressModel.AddressTVItemID}\t{addressModel.MunicipalityTVText}\t{((int)addressModel.AddressType).ToString()}\t{addressModel.StreetNumber}\t{addressModel.StreetName}\t{((int)addressModel.StreetType).ToString()}\t{addressModel.PostalCode}\t");
                    }
                }

                List<TVItemModel> tvItemModelPictureList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelInfrastructure.TVItemID, TVTypeEnum.File);
                List<TVFileModel> tvFileModelList = GetTVFileModelListWithParentTVItemIDDB(tvItemModelInfrastructure.TVItemID);

                foreach (TVItemModel tvItemModelPicture in tvItemModelPictureList)
                {
                    TVFileModel tvFileModel = tvFileModelList.Where(c => c.TVFileTVItemID == tvItemModelPicture.TVItemID).FirstOrDefault();

                    if (tvFileModel != null)
                    {
                        FileInfo fiExt = new FileInfo(tvFileModel.ServerFilePath + tvFileModel.ServerFileName);

                        if (fiExt.Extension.ToLower() == ".jpg")
                        {
                            sb.AppendLine($"PICTURE\t{tvItemModelPicture.TVItemID}\t{tvFileModel.ServerFileName.Replace("\r", "_").Replace("\n", "_").Replace("\t", "_")}\t{fiExt.Extension}\t{tvFileModel.FileDescription.Replace("\r", "_").Replace("\n", "_").Replace("\t", "_")}\t");
                            sb.AppendLine($"FROMWATER\t{tvFileModel.FromWater}\t");
                        }
                    }
                }

            }

            try
            {
                StreamWriter sw = fi.CreateText();
                sw.Write(sb.ToString());
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return "";
        }
        public string GetPollutionSourceSitesForInputToolDB(int SubsectorTVItemID)
        {
            StringBuilder sb = new StringBuilder();
            int PolSourceObservationIDNotExistCount = 10000000;

            string ServerFilePath = GetServerFilePath(SubsectorTVItemID);

            TVItemModel tvItemModelSS = _TVItemService.GetTVItemModelWithTVItemIDDB(SubsectorTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelSS.Error))
            {
                return tvItemModelSS.Error;
            }

            string TVText = tvItemModelSS.TVText;
            if (TVText.Contains(" "))
            {
                TVText = TVText.Substring(0, TVText.IndexOf(" ")).Trim();
            }

            DirectoryInfo di = new DirectoryInfo(ChoseEDriveOrCDrive(ServerFilePath));

            FileInfo fi = new FileInfo(ChoseEDriveOrCDrive(ServerFilePath) + TVText + ".txt");

            if (!di.Exists)
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    return ex.Message + (ex.InnerException != null ? " InnerException: " + ex.InnerException.Message : "");
                }
            }

            sb.AppendLine("VERSION\t1\t");
            DateTime CurrentTime = DateTime.UtcNow;
            sb.AppendLine($"DOCDATE\t{CurrentTime.Year}|{CurrentTime.Month.ToString("0#")}|{CurrentTime.Day.ToString("0#")}|{CurrentTime.Hour.ToString("0#")}|{CurrentTime.Minute.ToString("0#")}|{CurrentTime.Second.ToString("0#")}\t");

            TVItemModel tvItemModelProvince = null;
            List<TVItemModel> tvItemModelParentList = _TVItemService.GetParentsTVItemModelList(tvItemModelSS.TVPath);

            foreach (TVItemModel tvItemModel in tvItemModelParentList)
            {
                if (tvItemModel.TVType == TVTypeEnum.Province)
                {
                    tvItemModelProvince = tvItemModel;
                    break;
                }
            }

            if (tvItemModelProvince == null)
            {
                return string.Format(ServiceRes.CouldNotFindParent_WithChild_Equal_, ServiceRes.Province, ServiceRes.Subsector, tvItemModelSS.TVPath);
            }

            List<TVItemModel> tvItemModelMunicipalityList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProvince.TVItemID, TVTypeEnum.Municipality);

            string MunicipalityListText = "";
            foreach (TVItemModel tvItemModel in tvItemModelMunicipalityList)
            {
                MunicipalityListText = MunicipalityListText + tvItemModel.TVText.Replace("\t", "_").Replace("|", "_").Replace("[", "_").Replace("]", "_") + "[" + tvItemModel.TVItemID + "]" + "|";
            }

            sb.AppendLine($"PROVINCETVITEMID\t{ tvItemModelProvince.TVItemID }");
            sb.AppendLine($"PROVINCEMUNICIPALITIES\t{ MunicipalityListText }");

            sb.AppendLine($"SUBSECTOR\t{tvItemModelSS.TVItemID}\t{tvItemModelSS.TVText}\t");

            List<TVItemModel> tvItemModelPSSList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSS.TVItemID, TVTypeEnum.PolSourceSite);

            List<PolSourceSiteModel> polSourceSiteModelList = _PolSourceSiteService.GetPolSourceSiteModelListWithSubsectorTVItemIDDB(tvItemModelSS.TVItemID);
            foreach (TVItemModel tvItemModelPSS in tvItemModelPSSList.Where(c => c.IsActive == true))
            {
                PolSourceSiteModel polSourceSiteModel = polSourceSiteModelList.Where(c => c.PolSourceSiteTVItemID == tvItemModelPSS.TVItemID).FirstOrDefault();

                if (polSourceSiteModel == null)
                {
                    continue;
                }

                var mapInfoList = (from mi in _TVItemService.db.MapInfos
                                   from mip in _TVItemService.db.MapInfoPoints
                                   where mi.MapInfoID == mip.MapInfoID
                                   && mi.TVType == (int)TVTypeEnum.PolSourceSite
                                   && mi.MapInfoDrawType == (int)MapInfoDrawTypeEnum.Point
                                   && mi.TVItemID == polSourceSiteModel.PolSourceSiteTVItemID
                                   select new { mi, mip }).ToList();

                MapInfo mapInfo = mapInfoList.Where(c => c.mi.TVItemID == tvItemModelPSS.TVItemID).Select(c => c.mi).FirstOrDefault();
                MapInfoPoint mapInfoPoint = mapInfoList.Where(c => c.mip.MapInfoID == mapInfo.MapInfoID).Select(c => c.mip).FirstOrDefault();

                string IsActiveTxt = (tvItemModelPSS.IsActive ? "true" : "false");
                string IsPointSourceTxt = (polSourceSiteModel.IsPointSource ? "true" : "false");

                sb.AppendLine($"-----\t-------------------------------------------------\t");
                sb.AppendLine($"PSS\t{tvItemModelPSS.TVItemID}\t{mapInfoPoint.Lat.ToString("F5")}\t{mapInfoPoint.Lng.ToString("F5")}\t{IsActiveTxt}\t{IsPointSourceTxt}\t");
                sb.AppendLine($"SITENUMB\t{polSourceSiteModel.Site}\t");

                while (tvItemModelPSS.TVText.Contains("  "))
                {
                    tvItemModelPSS.TVText = tvItemModelPSS.TVText.Replace("  ", " ");
                }
                sb.AppendLine($"TVTEXT\t{tvItemModelPSS.TVText.Replace(",", "_").Replace("\t", "_").Replace("\r", "_").Replace("\n", "_")}\t");

                if (polSourceSiteModel.CivicAddressTVItemID != null)
                {
                    AddressModel addressModel = _AddressService.GetAddressModelWithAddressTVItemIDDB((int)polSourceSiteModel.CivicAddressTVItemID);

                    if (string.IsNullOrWhiteSpace(addressModel.Error))
                    {
                        sb.AppendLine($"ADDRESS\t{addressModel.AddressTVItemID}\t{addressModel.MunicipalityTVText}\t{((int)addressModel.AddressType).ToString()}\t{addressModel.StreetNumber}\t{addressModel.StreetName}\t{((int)addressModel.StreetType).ToString()}\t{addressModel.PostalCode}\t");
                    }
                }

                List<TVItemModel> tvItemModelPictureList = _TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelPSS.TVItemID, TVTypeEnum.File);
                List<TVFileModel> tvFileModelList = GetTVFileModelListWithParentTVItemIDDB(tvItemModelPSS.TVItemID);

                foreach (TVItemModel tvItemModelPicture in tvItemModelPictureList)
                {
                    TVFileModel tvFileModel = tvFileModelList.Where(c => c.TVFileTVItemID == tvItemModelPicture.TVItemID).FirstOrDefault();

                    if (tvFileModel != null)
                    {
                        FileInfo fiExt = new FileInfo(tvFileModel.ServerFilePath + tvFileModel.ServerFileName);

                        if (fiExt.Extension.ToLower() == ".jpg")
                        {
                            sb.AppendLine($"PICTURE\t{tvItemModelPicture.TVItemID}\t{tvFileModel.ServerFileName.Replace("\r", "_").Replace("\n", "_").Replace("\t", "_")}\t{fiExt.Extension}\t{tvFileModel.FileDescription.Replace("\r", "_").Replace("\n", "_").Replace("\t", "_")}\t");
                            sb.AppendLine($"FROMWATER\t{tvFileModel.FromWater}\t");
                        }
                    }
                }

                PolSourceObservationModel polSourceObservationModelLatest = _PolSourceObservationService.GetPolSourceObservationModelLatestWithPolSourceSiteIDDB(polSourceSiteModel.PolSourceSiteID);

                if (string.IsNullOrWhiteSpace(polSourceObservationModelLatest.Error))
                {
                    DateTime ObsDateTime = polSourceObservationModelLatest.ObservationDate_Local;
                    DateTime LatestUpdateDateTime = polSourceObservationModelLatest.LastUpdateDate_UTC;
                    sb.AppendLine($"OBS\t{polSourceObservationModelLatest.PolSourceObservationID}\t{LatestUpdateDateTime.Year}|{LatestUpdateDateTime.Month.ToString("0#")}|{LatestUpdateDateTime.Day.ToString("0#")}|{LatestUpdateDateTime.Hour.ToString("0#")}|{LatestUpdateDateTime.Minute.ToString("0#")}|{LatestUpdateDateTime.Second.ToString("0#")}\t{ObsDateTime.Year}|{ObsDateTime.Month.ToString("0#")}|{ObsDateTime.Day.ToString("0#")}\t");
                }
                else
                {
                    DateTime ObsDateTime = DateTime.Now;
                    DateTime LatestUpdateDateTime = DateTime.Now;
                    sb.AppendLine($"OBS\t{PolSourceObservationIDNotExistCount}\t{LatestUpdateDateTime.Year}|{LatestUpdateDateTime.Month.ToString("0#")}|{LatestUpdateDateTime.Day.ToString("0#")}|{LatestUpdateDateTime.Hour.ToString("0#")}|{LatestUpdateDateTime.Minute.ToString("0#")}|{LatestUpdateDateTime.Second.ToString("0#")}\t{ObsDateTime.Year}|{ObsDateTime.Month.ToString("0#")}|{ObsDateTime.Day.ToString("0#")}\t");

                    PolSourceObservationIDNotExistCount += 1;
                }

                if (!string.IsNullOrWhiteSpace(polSourceObservationModelLatest.Observation_ToBeDeleted))
                {
                    sb.AppendLine($"OLDWRITTENDESC\t{polSourceObservationModelLatest.Observation_ToBeDeleted.Replace("\r", "_").Replace("\n", "_").Replace("\t", "_")}\t");
                }

                string url = @"http://wmon01dtchlebl2.ncr.int.ec.gc.ca/csspwebtoolsjoe/en-CA/TVItem/_TVItemMoreInfo?Q=!View%2F%2Fcsspwebtoolsjoe%2Fen-CA%2F%23!View%2FNB-06-020%20(Bouctouche)%20-%20NB-06-020-002%20(Bouctouche%20River%20and%20Harbour)%7C%7C%7C635%7C%7C%7C30001000002000000000000000000000&TVItemID=" + tvItemModelPSS.TVItemID + @"&NumberOfSample=30";
                try
                {
                    List<string> OldSelectList = new List<string>();
                    string OldSelect = "";

                    using (WebClient webClient = new WebClient())
                    {
                        WebProxy webProxy = new WebProxy();
                        webClient.Proxy = webProxy;


                        var json_data = string.Empty;
                        byte[] responseBytes = webClient.DownloadData(url);
                        OldSelect = Encoding.UTF8.GetString(responseBytes);

                        int Pos = 1;
                        while (Pos > 0)
                        {
                            Pos = OldSelect.IndexOf(@"Selected Description:");
                            if (Pos > 0)
                            {
                                Pos += @"Selected Description:".Length;
                                OldSelect = OldSelect.Substring(Pos);

                                Pos = OldSelect.IndexOf(@"<span>");
                                if (Pos > 0)
                                {
                                    Pos += @"<span>".Length;
                                    OldSelect = OldSelect.Substring(Pos);

                                    int Pos2 = OldSelect.IndexOf("</span>");
                                    if (Pos2 > 0)
                                    {
                                        string SelectText = OldSelect.Substring(0, Pos2);

                                        if (SelectText.Length > 0)
                                        {
                                            OldSelectList.Add(SelectText);
                                        }

                                        OldSelect = OldSelect.Substring(Pos2);
                                    }
                                }
                                else
                                {
                                    OldSelect = "";
                                }
                            }
                            else
                            {
                                OldSelect = "";
                            }
                        }
                    }

                    foreach (string s in OldSelectList)
                    {
                        sb.AppendLine($"OLDISSUETEXT\t{s.Replace("\r", "_").Replace("\n", "_").Replace("\t", "_")}\t");
                    }

                }
                catch (Exception)
                {
                    // nothing
                }
                List<PolSourceObservationIssueModel> polSourceObservationIssueModelList = _PolSourceObservationIssueService.GetPolSourceObservationIssueModelListWithPolSourceObservationIDDB(polSourceObservationModelLatest.PolSourceObservationID);

                foreach (PolSourceObservationIssueModel polSourceObservationIssueModel in polSourceObservationIssueModelList.OrderBy(c => c.Ordinal))
                {
                    DateTime LatestUpdateDateTime = polSourceObservationIssueModel.LastUpdateDate_UTC;
                    sb.AppendLine($"ISSUE\t{polSourceObservationIssueModel.PolSourceObservationIssueID}\t{polSourceObservationIssueModel.Ordinal}\t{LatestUpdateDateTime.Year}|{LatestUpdateDateTime.Month.ToString("0#")}|{LatestUpdateDateTime.Day.ToString("0#")}|{LatestUpdateDateTime.Hour.ToString("0#")}|{LatestUpdateDateTime.Minute.ToString("0#")}|{LatestUpdateDateTime.Second.ToString("0#")}\t{polSourceObservationIssueModel.ObservationInfo.Trim()}\t");
                    if (string.IsNullOrWhiteSpace(polSourceObservationIssueModel.ExtraComment))
                    {
                        sb.AppendLine($"EXTRACOMMENT\t{""}\t");
                    }
                    else
                    {
                        sb.AppendLine($"EXTRACOMMENT\t{polSourceObservationIssueModel.ExtraComment.Replace("\r\n", "|||").Replace("\n", "|||").Replace("\r", "|||").Replace("\t", "     ")}\t");
                    }
                }
            }

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

            return "";
        }
        public string CreateDocumentFromTemplateDB(FormCollection fc)
        {
            int TVItemID = 0;
            int DocTemplateID = 0;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            int.TryParse(fc["TVItemID"], out TVItemID);
            if (TVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            int.TryParse(fc["DocTemplateID"], out DocTemplateID);
            if (DocTemplateID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.DocTemplateID);

            DocTemplateService _DocTemplateService = new DocTemplateService(LanguageRequest, User);

            DocTemplateModel docTemplateModel = _DocTemplateService.GetDocTemplateModelWithDocTemplateIDDB(DocTemplateID);
            if (!string.IsNullOrWhiteSpace(docTemplateModel.Error))
                return docTemplateModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(TVItemID, TVItemID, AppTaskCommandEnum.CreateDocumentFromTemplate);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "TVItemID", Value = TVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "DocTemplateID", Value = DocTemplateID.ToString() });

            StringBuilder sbParameters = new StringBuilder();
            int count = 0;
            foreach (AppTaskParameter atp in appTaskParameterList)
            {
                if (count == 0)
                {
                    sbParameters.Append("|||");
                }
                sbParameters.Append(atp.Name + "," + atp.Value + "|||");
                count += 1;
            }
            AppTaskModel appTaskModelNew = new AppTaskModel()
            {
                DBCommand = DBCommandEnum.Original,
                TVItemID = TVItemID,
                TVItemID2 = TVItemID,
                AppTaskCommand = AppTaskCommandEnum.CreateDocumentFromTemplate,
                ErrorText = "",
                StatusText = string.Format(ServiceRes.CreatingDocumentFromTemplate_, docTemplateModel.FileName),
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = sbParameters.ToString(),
                Language = LanguageRequest,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
            };

            AppTaskModel appTaskModelRet = _AppTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                return appTaskModelRet.Error;

            return "";
        }
        public string CreateDocxPDFDB(FormCollection fc)
        {
            int TVItemID = 0;
            int TVFileTVItemID = 0;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            int.TryParse(fc["TVItemID"], out TVItemID);
            if (TVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID);

            TVItemModel tvItemModelParent = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                return tvItemModelParent.Error;


            int.TryParse(fc["TVFileTVItemID"], out TVFileTVItemID);
            if (TVFileTVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.TVFileTVItemID);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(TVItemID, TVItemID, AppTaskCommandEnum.CreateDocxPDF);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "TVItemID", Value = TVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "TVFileTVItemID", Value = TVFileTVItemID.ToString() });

            StringBuilder sbParameters = new StringBuilder();
            int count = 0;
            foreach (AppTaskParameter atp in appTaskParameterList)
            {
                if (count == 0)
                {
                    sbParameters.Append("|||");
                }
                sbParameters.Append(atp.Name + "," + atp.Value + "|||");
                count += 1;
            }
            AppTaskModel appTaskModelNew = new AppTaskModel()
            {
                DBCommand = DBCommandEnum.Original,
                TVItemID = TVItemID,
                TVItemID2 = TVItemID,
                AppTaskCommand = AppTaskCommandEnum.CreateDocxPDF,
                ErrorText = "",
                StatusText = ServiceRes.CreatingPDFFromWordDocument,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = sbParameters.ToString(),
                Language = LanguageRequest,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
            };

            AppTaskModel appTaskModelRet = _AppTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                return appTaskModelRet.Error;

            return "";
        }
        public string CreateXlsxPDFDB(FormCollection fc)
        {
            int TVItemID = 0;
            int TVFileTVItemID = 0;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            int.TryParse(fc["TVItemID"], out TVItemID);
            if (TVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID);

            TVItemModel tvItemModelParent = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelParent.Error))
                return tvItemModelParent.Error;


            int.TryParse(fc["TVFileTVItemID"], out TVFileTVItemID);
            if (TVFileTVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.TVFileTVItemID);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(TVItemID, TVItemID, AppTaskCommandEnum.CreateXlsxPDF);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            appTaskParameterList.Add(new AppTaskParameter() { Name = "TVItemID", Value = TVItemID.ToString() });
            appTaskParameterList.Add(new AppTaskParameter() { Name = "TVFileTVItemID", Value = TVFileTVItemID.ToString() });

            StringBuilder sbParameters = new StringBuilder();
            int count = 0;
            foreach (AppTaskParameter atp in appTaskParameterList)
            {
                if (count == 0)
                {
                    sbParameters.Append("|||");
                }
                sbParameters.Append(atp.Name + "," + atp.Value + "|||");
                count += 1;
            }
            AppTaskModel appTaskModelNew = new AppTaskModel()
            {
                DBCommand = DBCommandEnum.Original,
                TVItemID = TVItemID,
                TVItemID2 = TVItemID,
                AppTaskCommand = AppTaskCommandEnum.CreateXlsxPDF,
                ErrorText = "",
                StatusText = ServiceRes.CreatingPDFFromExcelDocument,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = sbParameters.ToString(),
                Language = LanguageRequest,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
            };

            AppTaskModel appTaskModelRet = _AppTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                return appTaskModelRet.Error;

            return "";
        }
        public string CreateDocumentFromParametersDB(FormCollection fc)
        {
            int TVItemID = 0;
            int ReportTypeID = 0;

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return contactOK.Error;

            int.TryParse(fc["TVItemID"], out TVItemID);
            if (TVItemID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID);

            int.TryParse(fc["ReportTypeID"], out ReportTypeID);
            if (ReportTypeID == 0)
                return string.Format(ServiceRes._IsRequired, ServiceRes.ReportTypeID);

            TVItemModel tvItemModel = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                return tvItemModel.Error;

            ReportTypeModel reportTypeModel = _ReportTypeService.GetReportTypeModelWithReportTypeIDDB(ReportTypeID);
            if (!string.IsNullOrWhiteSpace(reportTypeModel.Error))
                return tvItemModel.Error;

            AppTaskModel appTaskModelExist = _AppTaskService.GetAppTaskModelWithTVItemIDTVItemID2AndCommandDB(TVItemID, TVItemID, AppTaskCommandEnum.CreateDocumentFromParameters);
            if (string.IsNullOrWhiteSpace(appTaskModelExist.Error))
                return string.Format(ServiceRes._AlreadyExists, ServiceRes.AppTask);

            List<AppTaskParameter> appTaskParameterList = new List<AppTaskParameter>();
            for (int i = 0, countItem = fc.AllKeys.Count(); i < countItem; i++)
            {
                if (fc.AllKeys[i] != "__RequestVerificationToken")
                {
                    appTaskParameterList.Add(new AppTaskParameter() { Name = fc.AllKeys[i], Value = fc.Get(i) });
                }
            }

            StringBuilder sbParameters = new StringBuilder();
            int count = 0;
            foreach (AppTaskParameter atp in appTaskParameterList)
            {
                if (count == 0)
                {
                    sbParameters.Append("|||");
                }
                sbParameters.Append(atp.Name + "," + atp.Value + "|||");
                count += 1;
            }
            AppTaskModel appTaskModelNew = new AppTaskModel()
            {
                DBCommand = DBCommandEnum.Original,
                TVItemID = TVItemID,
                TVItemID2 = TVItemID,
                AppTaskCommand = AppTaskCommandEnum.CreateDocumentFromParameters,
                ErrorText = "",
                StatusText = ServiceRes.CreateDocumentFromParameters,
                AppTaskStatus = AppTaskStatusEnum.Created,
                PercentCompleted = 1,
                Parameters = sbParameters.ToString(),
                Language = LanguageRequest,
                StartDateTime_UTC = DateTime.UtcNow,
                EndDateTime_UTC = null,
                EstimatedLength_second = null,
                RemainingTime_second = null,
            };

            AppTaskModel appTaskModelRet = _AppTaskService.PostAddAppTask(appTaskModelNew);
            if (!string.IsNullOrWhiteSpace(appTaskModelRet.Error))
                return appTaskModelRet.Error;

            return "";
        }
        public TVFileModel PostAddTVFileDB(TVFileModel tvFileModel)
        {
            string retStr = TVFileModelOK(tvFileModel);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVFile tvFileExist = GetTVFileExistDB(tvFileModel);
            if (tvFileExist != null)
                return ReturnError(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVFile));

            TVFile tvFileNew = new TVFile();
            retStr = FillTVFile(tvFileNew, tvFileModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            TVItemModel tvItemModelTVFile = _TVItemService.GetTVItemModelWithTVItemIDDB(tvFileNew.TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvItemModelTVFile.Error))
                return ReturnError(tvItemModelTVFile.Error);

            using (TransactionScope ts = new TransactionScope())
            {
                db.TVFiles.Add(tvFileNew);
                retStr = DoAddChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVFiles", tvFileNew.TVFileID, LogCommandEnum.Add, tvFileNew);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    TVFileLanguageModel tvFileLanguageModelNew = new TVFileLanguageModel()
                    {
                        DBCommand = DBCommandEnum.Original,
                        Language = lang,
                        FileDescription = tvFileModel.FileDescription,
                        TranslationStatus = (lang == LanguageRequest ? TranslationStatusEnum.Translated : TranslationStatusEnum.NotTranslated),
                        TVFileID = tvFileNew.TVFileID,
                    };

                    TVFileLanguageModel tvFileLanguageModelRet = _TVFileLanguageService.PostAddTVFileLanguageDB(tvFileLanguageModelNew);
                    if (!string.IsNullOrWhiteSpace(tvFileLanguageModelRet.Error))
                        return ReturnError(tvFileLanguageModelRet.Error);
                }

                ts.Complete();
            }
            return GetTVFileModelWithTVFileTVItemIDDB(tvFileNew.TVFileTVItemID);
        }
        public TVFileModel PostDeleteTVFileDB(int TVFileID)
        {
            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVFile tvFileToDelete = GetTVFileWithTVFileIDDB(TVFileID);
            if (tvFileToDelete == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVFile));

            int TVItemID = tvFileToDelete.TVFileTVItemID;

            using (TransactionScope ts = new TransactionScope())
            {
                if (tvFileToDelete.FilePurpose == (int)FilePurposeEnum.Template)
                {
                    DocTemplateService docTemplateService = new DocTemplateService(LanguageRequest, User);

                    DocTemplateModel docTemplateModelRet = docTemplateService.PostDeleteDocTemplateWithTVFileTVItemIDDB(tvFileToDelete.TVFileTVItemID);
                    if (!string.IsNullOrWhiteSpace(docTemplateModelRet.Error))
                    {
                        // do nothing
                        // it's possible that the DocTemplat has already been deleted
                    }
                }

                FileInfo fi = new FileInfo(ChoseEDriveOrCDrive(tvFileToDelete.ServerFilePath + tvFileToDelete.ServerFileName));

                db.TVFiles.Remove(tvFileToDelete);
                string retStr = DoDeleteChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVFiles", tvFileToDelete.TVFileID, LogCommandEnum.Delete, tvFileToDelete);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                TVItemModel tvItemModelToDelete = _TVItemService.GetTVItemModelWithTVItemIDDB(TVItemID);
                if (string.IsNullOrWhiteSpace(tvItemModelToDelete.Error))
                {
                    TVItemModel tvItemModel = _TVItemService.PostDeleteTVItemWithTVItemIDDB(TVItemID);
                    if (!string.IsNullOrWhiteSpace(tvItemModel.Error))
                        return ReturnError(tvItemModel.Error);

                }

                try
                {
                    fi.Delete();
                }
                catch (Exception ex)
                {
                    return ReturnError(string.Format(ServiceRes.CouldNotDeleteError_, ex.Message));
                }

                ts.Complete();
            }

            return ReturnError("");
        }
        public TVFileModel PostDeleteTVFileWithTVItemIDDB(int TVFileTVItemID)
        {
            TVFileModel tvFileModel = GetTVFileModelWithTVFileTVItemIDDB(TVFileTVItemID);
            if (!string.IsNullOrWhiteSpace(tvFileModel.Error))
                return ReturnError(tvFileModel.Error);

            TVFileModel tvFileModelRet = PostDeleteTVFileDB(tvFileModel.TVFileID);
            if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
                return ReturnError(tvFileModelRet.Error);

            return ReturnError("");
        }
        public TVFileModel PostUpdateTVFileDB(TVFileModel tvFileModel)
        {
            bool ShouldRenameFile = false;
            string OldFileName = "";
            string retStr = TVFileModelOK(tvFileModel);
            if (!string.IsNullOrEmpty(retStr))
                return ReturnError(retStr);

            ContactOK contactOK = IsContactOK();
            if (!string.IsNullOrEmpty(contactOK.Error))
                return ReturnError(contactOK.Error);

            TVFile tvFileToUpdate = GetTVFileWithTVFileIDDB(tvFileModel.TVFileID);
            if (tvFileToUpdate == null)
                return ReturnError(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVFile));

            if (tvFileToUpdate.ServerFileName != tvFileModel.ServerFileName)
            {
                ShouldRenameFile = true;
                OldFileName = tvFileToUpdate.ServerFileName;
            }

            retStr = FillTVFile(tvFileToUpdate, tvFileModel, contactOK);
            if (!string.IsNullOrWhiteSpace(retStr))
                return ReturnError(retStr);

            using (TransactionScope ts = new TransactionScope())
            {
                if (ShouldRenameFile)
                {
                    FileInfo fi = new FileInfo(ChoseEDriveOrCDrive(tvFileToUpdate.ServerFilePath + OldFileName));
                    if (!fi.Exists)
                        return ReturnError(string.Format(ServiceRes.File_DoesNotExist, tvFileToUpdate.ServerFilePath + OldFileName));

                    FileInfo fi2 = new FileInfo(fi.FullName.Replace(OldFileName, tvFileModel.ServerFileName));
                    if (fi2.Exists)
                        return ReturnError(string.Format(ServiceRes.File_AlreadyExist, fi.FullName.Replace(OldFileName, tvFileModel.ServerFileName)));

                    try
                    {
                        File.Copy(fi.FullName, fi.FullName.Replace(OldFileName, tvFileModel.ServerFileName));
                    }
                    catch (Exception ex)
                    {
                        return ReturnError(ex.Message + " - " + (ex.InnerException != null ? ex.InnerException.Message : ""));
                    }
                    try
                    {
                        fi.Delete();
                    }
                    catch (Exception ex)
                    {
                        return ReturnError(ex.Message + " - " + (ex.InnerException != null ? ex.InnerException.Message : ""));
                    }
                }
                retStr = DoUpdateChanges();
                if (!string.IsNullOrWhiteSpace(retStr))
                    return ReturnError(retStr);

                LogModel logModel = _LogService.PostAddLogForObj("TVFiles", tvFileToUpdate.TVFileID, LogCommandEnum.Change, tvFileToUpdate);
                if (!string.IsNullOrWhiteSpace(logModel.Error))
                    return ReturnError(logModel.Error);

                TVFileLanguageModel tvFileLanguageModel = _TVFileLanguageService.GetTVFileLanguageModelWithTVFileIDAndLanguageDB(tvFileToUpdate.TVFileID, LanguageRequest);
                if (!string.IsNullOrWhiteSpace(tvFileLanguageModel.Error))
                    return ReturnError(tvFileLanguageModel.Error);

                tvFileLanguageModel.FileDescription = tvFileModel.FileDescription;
                tvFileLanguageModel.TranslationStatus = TranslationStatusEnum.Translated;

                if (string.IsNullOrWhiteSpace(tvFileLanguageModel.FileDescription))
                    tvFileLanguageModel.FileDescription = tvFileToUpdate.ServerFileName + " description";

                TVFileLanguageModel tvFileLanguageModelRet = _TVFileLanguageService.PostUpdateTVFileLanguageDB(tvFileLanguageModel);
                if (!string.IsNullOrWhiteSpace(tvFileLanguageModelRet.Error))
                    return ReturnError(tvFileLanguageModelRet.Error);

                ts.Complete();
            }
            return GetTVFileModelWithTVFileTVItemIDDB(tvFileToUpdate.TVFileTVItemID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
