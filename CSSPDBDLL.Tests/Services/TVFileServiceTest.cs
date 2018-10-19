using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Transactions;
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.IO;
using System.Web;
using System.Web.Routing;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for TVFileServiceTest
    /// </summary>
    [TestClass]
    public class TVFileServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "TVFile";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private TVFileService tvFileService { get; set; }
        private TVItemService tvItemService { get; set; }
        private TestDBService testDBService { get; set; }
        private MWQMPlanService mwqmPlanService { get; set; }
        private MWQMPlanSubsectorService mwqmPlanSubsectorService { get; set; }
        private MWQMPlanSubsectorSiteService mwqmPlanSubsectorSiteService { get; set; }
        private RandomService randomService { get; set; }
        private TVFileModel tvFileModelNew { get; set; }
        private TVFile tvFile { get; set; }
        private ShimTVFileService shimTVFileService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimAppTaskService shimAppTaskService { get; set; }
        private MikeScenarioService mikeScenarioService { get; set; }
        private AppTaskService appTaskService { get; set; }
        private MikeScenarioServiceTest mikeScenarioServiceTest { get; set; }
        private ShimMapInfoService shimMapInfoService { get; set; }
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #endregion Properties

        #region Constructors
        public TVFileServiceTest()
        {
            setupData = new SetupData();
        }
        #endregion Constructors

        #region Initialize and Cleanup
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion Initialize and Cleanup

        #region Testing Methods public
        [TestMethod]
        public void TVFileService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Assert.IsNotNull(tvFileService);
                Assert.IsNotNull(tvFileService.db);
                Assert.IsNotNull(tvFileService._AppTaskService);
                Assert.IsNotNull(tvFileService._MapInfoService);
                Assert.IsNotNull(tvFileService._TVItemService);
                Assert.IsNotNull(tvFileService.LanguageRequest);
                Assert.IsNotNull(tvFileService.User);
                Assert.AreEqual(user.Identity.Name, tvFileService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), tvFileService.LanguageRequest);
                Assert.IsNotNull(tvFileService._AppTaskService);
                Assert.IsNotNull(tvFileService._MapInfoService);
                Assert.IsNotNull(tvFileService._TVItemService);
                Assert.IsNotNull(tvFileService._LogService);
            }
        }
        [TestMethod]
        public void TVFileService_TVFileModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModel = AddTVFileModel();
                    Assert.AreEqual("", tvFileModel.Error);

                    #region Good
                    tvFileModelNew.TVFileTVItemID = tvFileModel.TVFileTVItemID;
                    FillTVFileModel(tvFileModelNew);

                    string retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion Good

                    #region TVItemID
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.TVFileTVItemID = 0;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.TVItemID), retStr);

                    tvFileModelNew.TVFileTVItemID = tvFileModel.TVFileTVItemID;
                    FillTVFileModel(tvFileModelNew);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion TVItemdID

                    #region Language
                    FillTVFileModel(tvFileModelNew);
                    int Min = 2;
                    int Max = 2;

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.Language = LanguageEnum.en;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.Language = (LanguageEnum)1000;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);
                    #endregion Language

                    #region FilePurpose
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FilePurpose = (FilePurposeEnum)1000;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FilePurpose), retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FilePurpose = FilePurposeEnum.MikeInput;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FilePurpose

                    #region FileType
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FileType = (FileTypeEnum)1000;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.FileType), retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FileType = FileTypeEnum.M3FM;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion

                    #region FileDescription
                    FillTVFileModel(tvFileModelNew);
                    //Max = 100000;
                    tvFileModelNew.FileDescription = randomService.RandomString("", 0);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FileDescription = randomService.RandomString("", 20);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    // Max not tested
                    #endregion FileDescription

                    #region FileSize_kb
                    FillTVFileModel(tvFileModelNew);
                    Min = -1;
                    Max = 2000000000;
                    tvFileModelNew.FileSize_kb = Min - 1;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FileSize_kb, Min, Max), retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FileSize_kb = Max + 1;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._RangeIsBetween_And_, ServiceRes.FileSize_kb, Min, Max), retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FileSize_kb = Max - 1;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FileSize_kb = Min;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FileSize_kb = Max;

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion FileSize_kb

                    #region FileInfo
                    FillTVFileModel(tvFileModelNew);
                    //Max = 100000;
                    tvFileModelNew.FileInfo = randomService.RandomString("", 0);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.FileInfo = randomService.RandomString("", 30);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    // Max not tested
                    #endregion FileInfo

                    #region ClientFilePath
                    FillTVFileModel(tvFileModelNew);
                    Max = 250;
                    tvFileModelNew.ClientFilePath = randomService.RandomString("", 0);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ClientFilePath = randomService.RandomString("", Max + 1);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ClientFilePath, Max), retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ClientFilePath = randomService.RandomString("", Max - 1);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ClientFilePath = randomService.RandomString("", Max);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ClientFilePath

                    #region ServerFileName
                    FillTVFileModel(tvFileModelNew);
                    Max = 250;
                    tvFileModelNew.ServerFileName = randomService.RandomString("", 0);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ServerFileName), retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = randomService.RandomString("", Max + 1);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ServerFileName, Max), retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = randomService.RandomString("", Max - 1);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = randomService.RandomString("", Max);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ServerFileName

                    #region ServerFilePath
                    FillTVFileModel(tvFileModelNew);
                    Max = 250;
                    tvFileModelNew.ServerFilePath = randomService.RandomString("", 0);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFilePath = randomService.RandomString("", Max + 1);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.ServerFilePath, Max), retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFilePath = randomService.RandomString("", Max - 1);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);

                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFilePath = randomService.RandomString("", Max);

                    retStr = tvFileService.TVFileModelOK(tvFileModelNew);
                    Assert.AreEqual("", retStr);
                    #endregion ServerFilePath
                }
            }
        }
        [TestMethod]
        public void TVFileService_FillTVFile_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tvFileModelNew.TVFileTVItemID = randomService.RandomTVItem(TVTypeEnum.Root).TVItemID;
                    FillTVFileModel(tvFileModelNew);

                    ContactOK contactOK = tvFileService.IsContactOK();

                    string retStr = tvFileService.FillTVFile(tvFile, tvFileModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, tvFile.LastUpdateContactTVItemID);

                    contactOK = null;
                    retStr = tvFileService.FillTVFile(tvFile, tvFileModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, tvFile.LastUpdateContactTVItemID);
                }
            }
        }
        [TestMethod]
        public void TVFileService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    TVFileModel tvFileModelRet = tvFileService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetFileType_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> tvTypeStrList = new List<string>() { "ERROR", "DFS0", "DFS1", "DFSU", "KMZ", "LOG", "M21FM", "M3FM", "MDF", "MESH", "XLSX", "DOCX", "PDF", "JPG", "JPEG", "GIF", "PNG", "HTML", "TXT", "XYZ", "KML", "CSV" };
                    List<FileTypeEnum> tvTypeEnumDocList = new List<FileTypeEnum>() { FileTypeEnum.Error, FileTypeEnum.DFS0, FileTypeEnum.DFS1, FileTypeEnum.DFSU, FileTypeEnum.KMZ, FileTypeEnum.LOG, FileTypeEnum.M21FM, FileTypeEnum.M3FM, FileTypeEnum.MDF, FileTypeEnum.MESH, FileTypeEnum.XLSX, FileTypeEnum.DOCX, FileTypeEnum.PDF, FileTypeEnum.JPG, FileTypeEnum.JPEG, FileTypeEnum.GIF, FileTypeEnum.PNG, FileTypeEnum.HTML, FileTypeEnum.TXT, FileTypeEnum.XYZ, FileTypeEnum.KML, FileTypeEnum.CSV };
                    Assert.AreEqual(22, Enum.GetNames(typeof(FileTypeEnum)).Count());
                    Assert.AreEqual(22, tvTypeStrList.Count);

                    for (int i = 0, count = tvTypeStrList.Count; i < count; i++)
                    {
                        FileTypeEnum fileTypeEnum = tvFileService.GetFileType(tvTypeStrList[i]);
                        Assert.AreEqual(tvTypeEnumDocList[i], fileTypeEnum);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetMimeType_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> testExtList = tvFileService.GetAllowableExt();
                    List<string> mimeTypeList = tvFileService.GetAllowableMime(); ;
                    Assert.AreEqual(testExtList.Count, mimeTypeList.Count);

                    for (int i = 0, count = testExtList.Count; i < count; i++)
                    {
                        string mimeType = tvFileService.GetMimeType("testing" + testExtList[i]);
                        Assert.AreEqual(mimeTypeList[i], mimeType);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetServerFilePath_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModel = randomService.RandomTVItem(TVTypeEnum.Root);

                    if (System.Environment.UserName == "leblancc" || System.Environment.UserName == "admin-leblancc" || System.Environment.UserName == "WMON01DTCHLEBL2$")
                    {
                        string retStr = tvFileService.GetServerFilePath(tvItemModel.TVItemID);
                        Assert.IsTrue(retStr.StartsWith(@"E:\"));
                        Assert.AreEqual(@"\1\", retStr.Substring(retStr.Length - 3));
                    }
                    else
                    {
                        string retStr = tvFileService.GetServerFilePath(tvItemModel.TVItemID);
                        Assert.IsTrue(retStr.StartsWith(@"C:\"));
                        Assert.AreEqual(@"\1\", retStr.Substring(retStr.Length - 3));
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    TVFile tvFileRet = tvFileService.GetTVFileExistDB(tvFileModelRet);
                    Assert.AreEqual(tvFileModelRet.TVFileID, tvFileRet.TVFileID);

                    tvFileModelRet.TVFileTVItemID = 0;
                    TVFile tvFileRet2 = tvFileService.GetTVFileExistDB(tvFileModelRet);
                    Assert.IsNull(tvFileRet2);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModel = AddTVFileModel();

                    TVFileModel tvFileModelRet1 = tvFileService.GetTVFileModelExistDB(tvFileModel);
                    Assert.AreEqual("", tvFileModelRet1.Error);

                    tvFileModel.TVFileTVItemID = 0;
                    TVFileModel tvFileModelRet2 = tvFileService.GetTVFileModelExistDB(tvFileModel);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_,
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
                    tvFileModel.ServerFileName), tvFileModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int tvFileCount = tvFileService.GetTVFileModelCountDB();

                    TVFileModel tvFileModel = AddTVFileModel();
                    Assert.AreEqual("", tvFileModel.Error);

                    int tvFileCount2 = tvFileService.GetTVFileModelCountDB();
                    Assert.AreEqual(tvFileCount + 1, tvFileCount2);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelListWithParentTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    TVItemModel tvItemModel = tvFileService._TVItemService.GetTVItemModelWithTVItemIDDB(tvFileModelRet.TVFileTVItemID);
                    Assert.AreEqual("", tvItemModel.Error);

                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModel.ParentID);
                    Assert.IsTrue(tvFileModelList.Count > 0);
                    Assert.IsTrue(tvFileModelList.Where(c => c.TVFileTVItemID == tvFileModelRet.TVFileTVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelListWithParentTVItemIDDB_Template_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    TVFileModel tvFileModelRet2 = AddTVFileModelTemplate();
                    Assert.AreEqual("", tvFileModelRet2.Error);

                    TVItemModel tvItemModel = tvFileService._TVItemService.GetTVItemModelWithTVItemIDDB(tvFileModelRet.TVFileTVItemID);
                    Assert.AreEqual("", tvItemModel.Error);

                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModel.ParentID);
                    Assert.IsTrue(tvFileModelList.Count > 0);
                    Assert.IsTrue(tvFileModelList.Where(c => c.TVFileTVItemID == tvFileModelRet.TVFileTVItemID).Any());
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelWithTVFileTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    TVFileModel tvFileModelRet2 = tvFileService.GetTVFileModelWithTVFileTVItemIDDB(tvFileModelRet.TVFileTVItemID);
                    Assert.AreEqual(tvFileModelRet.TVFileID, tvFileModelRet2.TVFileID);

                    int TVFileTVItemID = 0;
                    TVFileModel tvFileRet2 = tvFileService.GetTVFileModelWithTVFileTVItemIDDB(TVFileTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFile, ServiceRes.TVFileTVItemID, TVFileTVItemID), tvFileRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelWithServerFilePathAndServerFileNameDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    string FilePath = tvFileModelRet.ServerFilePath;
                    string FileName = tvFileModelRet.ServerFileName;
                    TVFileModel tvFileModelRet2 = tvFileService.GetTVFileModelWithServerFilePathAndServerFileNameDB(FilePath, FileName);
                    Assert.AreEqual("", tvFileModelRet2.Error);
                    Assert.AreEqual(tvFileModelRet.TVFileID, tvFileModelRet2.TVFileID);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelWithServerFilePathAndServerFileNameDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    string FilePath = "Error" + tvFileModelRet.ServerFilePath;
                    string FileName = "Error" + tvFileModelRet.ServerFileName;
                    TVFileModel tvFileModelRet2 = tvFileService.GetTVFileModelWithServerFilePathAndServerFileNameDB(FilePath, FileName);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFile, ServiceRes.FullFileName, FilePath + FileName), tvFileModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileNotLoaded_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    TVItemModel tvItemModelMikeFile = tvFileService._TVItemService.PostAddChildTVItemDB(tvItemModelMikeScenario.TVItemID, randomService.RandomString("mike doc ", 20), TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelMikeFile.Error);

                    tvFileModelNew.TVFileTVItemID = tvItemModelMikeFile.TVItemID;
                    FillTVFileModel(tvFileModelNew);

                    tvFileModelNew.FileSize_kb = 0;

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModelRet.Error);

                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileNotLoaded(tvItemModelMikeScenario.TVItemID);
                    Assert.IsTrue(tvFileModelList.Count > 0);
                    Assert.IsTrue(tvFileModelList.Where(c => c.TVFileID == tvFileModelRet.TVFileID).Any());
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileNotLoaded_MikeScenarioTVItemID_Zero_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int MikeScenarioTVItemID = 0;
                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileNotLoaded(MikeScenarioTVItemID);
                    Assert.IsTrue(tvFileModelList.Count == 1);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.MikeScenarioTVItemID), tvFileModelList[0].Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileNotLoaded_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelMikeScenario = randomService.RandomTVItem(TVTypeEnum.MikeScenario);
                    Assert.AreEqual("", tvItemModelMikeScenario.Error);

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        List<TVFileModel> tvFileModelList = tvFileService.GetTVFileNotLoaded(tvItemModelMikeScenario.TVItemID);
                        Assert.IsTrue(tvFileModelList.Count == 1);
                        Assert.AreEqual(ErrorText, tvFileModelList[0].Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileWithServerFilePathAndServerFileNameDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    string FilePath = tvFileModelRet.ServerFilePath;
                    string FileName = tvFileModelRet.ServerFileName;
                    TVFile tvFileRet = tvFileService.GetTVFileWithServerFilePathAndServerFileNameDB(FilePath, FileName);
                    Assert.AreEqual(tvFileModelRet.TVFileID, tvFileRet.TVFileID);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileWithServerFilePathAndServerFileNameDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    string FilePath = "Error" + tvFileModelRet.ServerFilePath;
                    string FileName = "Error" + tvFileModelRet.ServerFileName;
                    TVFile tvFileRet = tvFileService.GetTVFileWithServerFilePathAndServerFileNameDB(FilePath, FileName);
                    Assert.IsNull(tvFileRet);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileWithTVFileIDDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    TVFile tvFileRet = tvFileService.GetTVFileWithTVFileIDDB(tvFileModelRet.TVFileID);
                    Assert.AreEqual(tvFileModelRet.TVFileID, tvFileRet.TVFileID);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileWithTVFileIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    TVFile tvFileRet = tvFileService.GetTVFileWithTVFileIDDB(0);
                    Assert.IsNull(tvFileRet);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileWithTVItemIDAndTVFileTypeM21FMOrM3FM_Good_M21FM_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = mikeScenarioServiceTest.AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    string TVText = randomService.RandomString("File Name TVText ", 28);
                    TVItemModel tvItemModelTVFile = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModel.MikeScenarioTVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelTVFile.Error);

                    TVFileModel tvFileModelNew = new TVFileModel();
                    tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = "testing.m21fm";
                    tvFileModelNew.ServerFilePath = tvFileService.GetServerFilePath(tvFileModelNew.TVFileTVItemID);
                    tvFileModelNew.FileType = FileTypeEnum.M21FM;

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModelRet.Error);

                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 },
                    };

                    MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.File, tvItemModelTVFile.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    TVFile tvFileRet = tvFileService.GetTVFileWithTVItemIDAndTVFileTypeM21FMOrM3FM(tvFileModelRet.TVFileTVItemID);
                    Assert.IsNotNull(tvFileRet);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileWithTVItemIDAndTVFileTypeM21FMOrM3FM_Good_M3FM_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = mikeScenarioServiceTest.AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    string TVText = randomService.RandomString("File Name TVText ", 28);
                    TVItemModel tvItemModelTVFile = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModel.MikeScenarioTVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelTVFile.Error);

                    TVFileModel tvFileModelNew = new TVFileModel();
                    tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = "testing.m3fm";
                    tvFileModelNew.ServerFilePath = tvFileService.GetServerFilePath(tvFileModelNew.TVFileTVItemID);
                    tvFileModelNew.FileType = FileTypeEnum.M3FM;

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModelRet.Error);

                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 },
                    };

                    MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.File, tvItemModelTVFile.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    TVFile tvFileRet = tvFileService.GetTVFileWithTVItemIDAndTVFileTypeM21FMOrM3FM(tvFileModelRet.TVFileTVItemID);
                    Assert.IsNotNull(tvFileRet);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileWithTVItemIDAndTVFileTypeM21FMOrM3FM_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = mikeScenarioServiceTest.AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    string TVText = randomService.RandomString("File Name TVText ", 28);
                    TVItemModel tvItemModelTVFile = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModel.MikeScenarioTVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelTVFile.Error);

                    TVFileModel tvFileModelNew = new TVFileModel();
                    tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = "testing.m21fm";
                    tvFileModelNew.ServerFilePath = tvFileService.GetServerFilePath(tvFileModelNew.TVFileTVItemID);
                    tvFileModelNew.FileType = FileTypeEnum.PNG;

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModelRet.Error);

                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 },
                    };

                    MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.File, tvItemModelTVFile.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    TVFile tvFileRet = tvFileService.GetTVFileWithTVItemIDAndTVFileTypeM21FMOrM3FM(tvFileModelRet.TVFileTVItemID);
                    Assert.IsNull(tvFileRet);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelWithTVItemIDAndTVFileTypeM21FMOrM3FMDB_Good_M21FM_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = mikeScenarioServiceTest.AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    string TVText = randomService.RandomString("File Name TVText ", 28);
                    TVItemModel tvItemModelTVFile = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModel.MikeScenarioTVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelTVFile.Error);

                    TVFileModel tvFileModelNew = new TVFileModel();
                    tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = "testing.m21fm";
                    tvFileModelNew.ServerFilePath = tvFileService.GetServerFilePath(tvFileModelNew.TVFileTVItemID);
                    tvFileModelNew.FileType = FileTypeEnum.M21FM;

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModelRet.Error);

                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 },
                    };

                    MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.File, tvItemModelTVFile.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    TVFileModel tvFileModelRet2 = tvFileService.GetTVFileModelWithTVItemIDAndTVFileTypeM21FMOrM3FMDB(mikeScenarioModel.MikeScenarioTVItemID);
                    Assert.AreEqual("", tvFileModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelWithTVItemIDAndTVFileTypeM21FMOrM3FMDB_Good_M3FM_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = mikeScenarioServiceTest.AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    string TVText = randomService.RandomString("File Name TVText ", 28);
                    TVItemModel tvItemModelTVFile = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModel.MikeScenarioTVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelTVFile.Error);

                    TVFileModel tvFileModelNew = new TVFileModel();
                    tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = "testing.m3fm";
                    tvFileModelNew.ServerFilePath = tvFileService.GetServerFilePath(tvFileModelNew.TVFileTVItemID);
                    tvFileModelNew.FileType = FileTypeEnum.M3FM;

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModelRet.Error);

                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 },
                    };

                    MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.File, tvItemModelTVFile.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    TVFileModel tvFileModelRet2 = tvFileService.GetTVFileModelWithTVItemIDAndTVFileTypeM21FMOrM3FMDB(mikeScenarioModel.MikeScenarioTVItemID);
                    Assert.AreEqual("", tvFileModelRet2.Error);

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelWithTVItemIDAndTVFileTypeM21FMOrM3FMDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = mikeScenarioServiceTest.AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    string TVText = randomService.RandomString("File Name TVText ", 28);
                    TVItemModel tvItemModelTVFile = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModel.MikeScenarioTVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelTVFile.Error);

                    TVFileModel tvFileModelNew = new TVFileModel();
                    tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = "testing.png";
                    tvFileModelNew.ServerFilePath = tvFileService.GetServerFilePath(tvFileModelNew.TVFileTVItemID);
                    tvFileModelNew.FileType = FileTypeEnum.PNG;

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModelRet.Error);

                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 },
                    };

                    MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.File, tvItemModelTVFile.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);


                    TVFileModel tvFileModelRet2 = tvFileService.GetTVFileModelWithTVItemIDAndTVFileTypeM21FMOrM3FMDB(tvFileModelRet.TVFileTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.TVFile, ServiceRes.TVItemID, tvFileModelRet.TVFileTVItemID), tvFileModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetTVFileModelListWithTVItemIDAndTVFilePurposeMIKE_InputDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    MikeScenarioModel mikeScenarioModel = mikeScenarioServiceTest.AddMikeScenarioModel();
                    Assert.AreEqual("", mikeScenarioModel.Error);

                    string TVText = randomService.RandomString("File Name TVText ", 28);
                    TVItemModel tvItemModelTVFile = mikeScenarioService._TVItemService.PostAddChildTVItemDB(mikeScenarioModel.MikeScenarioTVItemID, TVText, TVTypeEnum.File);
                    Assert.AreEqual("", tvItemModelTVFile.Error);

                    TVFileModel tvFileModelNew = new TVFileModel();
                    tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
                    FillTVFileModel(tvFileModelNew);
                    tvFileModelNew.ServerFileName = "testing.dfs1";
                    tvFileModelNew.ServerFilePath = tvFileService.GetServerFilePath(tvFileModelNew.TVFileTVItemID);
                    tvFileModelNew.FileType = FileTypeEnum.DFS1;
                    tvFileModelNew.FilePurpose = FilePurposeEnum.MikeInput;

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.AreEqual("", tvFileModelRet.Error);

                    List<Coord> coordList = new List<Coord>()
                    {
                        new Coord() { Lat = randomService.RandomFloat(45, 50), Lng = randomService.RandomFloat(-123, -66), Ordinal = 0 },
                    };

                    MapInfoModel mapInfoModelRet = mikeScenarioService._MapInfoService.CreateMapInfoObjectDB(coordList, MapInfoDrawTypeEnum.Point, TVTypeEnum.File, tvItemModelTVFile.TVItemID);
                    Assert.AreEqual("", mapInfoModelRet.Error);

                    List<TVFileModel> tvFileModelList = tvFileService.GetTVFileModelListWithTVItemIDAndTVFilePurposeMIKE_InputDB(mikeScenarioModel.MikeScenarioTVItemID);
                    Assert.IsTrue(tvFileModelList.Count > 0);
                    Assert.IsTrue(tvFileModelList.Where(c => c.TVFileID == tvFileModelRet.TVFileID).Any());
                }
            }
        }
        [TestMethod]
        public void TVFileService_ChoseEDriveOrCDrive_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string StartPath = @"C:\";

                    string retStr = tvFileService.ChoseEDriveOrCDrive(StartPath);

                    if (System.Environment.UserName == "leblancc" || System.Environment.UserName == "admin-leblancc" || System.Environment.UserName == "WMON01DTCHLEBL2$")
                    {
                        Assert.IsTrue(retStr.StartsWith("E:"));
                    }
                    else
                    {
                        Assert.IsTrue(retStr.StartsWith("C:"));
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetAllowableExt_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> strList = tvFileService.GetAllowableExt();

                    List<string> okList = new List<string>() { ".accde", ".csv", ".doc", ".docx", ".htm", ".html", ".jpeg", ".jpg", ".gif", ".kml", ".kmz", ".log", ".mdb", ".pdf", ".png", ".ppt", ".pptx", ".txt", ".xls", ".xlsx", };
                    Assert.AreEqual(okList.Count, strList.Count);
                    for (int i = 0, count = okList.Count; i < count; i++)
                    {
                        Assert.AreEqual(okList[i], strList[i]);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetAllowableTemplateExt_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> strList = tvFileService.GetAllowableTemplateExt();

                    List<string> okList = new List<string>() { ".docx", ".xlsx", ".kml" };
                    Assert.AreEqual(okList.Count, strList.Count);
                    for (int i = 0, count = okList.Count; i < count; i++)
                    {
                        Assert.AreEqual(okList[i], strList[i]);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetAllowableMime_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> strList = tvFileService.GetAllowableMime();

                    List<string> okList = new List<string>()
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
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    };
                    Assert.AreEqual(okList.Count, strList.Count);
                    for (int i = 0, count = okList.Count; i < count; i++)
                    {
                        Assert.AreEqual(okList[i], strList[i]);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_GetAllowableFileGeneratedType_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> strList = tvFileService.GetAllowableFileGeneratedType();

                    List<string> okList = new List<string>() { ".kmz", ".docx", ".xlsx", ".html", ".pdf", ".txt" };
                    Assert.AreEqual(okList.Count, strList.Count);
                    for (int i = 0, count = okList.Count; i < count; i++)
                    {
                        Assert.AreEqual(okList[i], strList[i]);
                    }

                }
            }
        }
        [TestMethod]
        public void TVFileService_GetFileExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    // don't need to test this
                }
            }
        }
        [TestMethod]
        public void TVFileService_IsAllowableFileType_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    List<string> strList = tvFileService.GetAllowableFileGeneratedType();
                    FileInfo fi = new FileInfo("testing.html");

                    bool allowRet = tvFileService.IsAllowableFileGeneratedType(fi, strList);
                    Assert.IsTrue(allowRet);

                    fi = new FileInfo("testing.notgood");

                    allowRet = tvFileService.IsAllowableFileGeneratedType(fi, strList);
                    Assert.IsFalse(allowRet);
                }
            }
        }
        [TestMethod]
        public void TVFileService_FileUploadDB_CantTestThisAtThisTime_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    Assert.IsTrue(true);
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddUpdateDeleteTVFile_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();

                    DirectoryInfo di = new DirectoryInfo(tvFileModelRet.ServerFilePath);

                    if (!di.Exists)
                    {
                        di.Create();
                    }

                    di = new DirectoryInfo(tvFileModelRet.ServerFilePath);
                    Assert.IsTrue(di.Exists);

                    StreamWriter sw = new StreamWriter(tvFileModelRet.ServerFilePath + tvFileModelRet.ServerFileName);

                    for (int i = 0; i < 10; i++)
                    {
                        sw.WriteLine("Testing" + i.ToString());
                    }

                    sw.Close();

                    TVFileModel tvFileModelRet2 = tvFileService.PostUpdateTVFileDB(tvFileModelRet);
                    TVFileModel tvFileModelRet3 = tvFileService.PostDeleteTVFileDB(tvFileModelRet2.TVFileID);
                    Assert.AreEqual("", tvFileModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_TVFileModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelTVFile = randomService.RandomTVItem(TVTypeEnum.File);
                Assert.AreEqual("", tvItemModelTVFile.Error);

                TVFileModel tvFileModel = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelTVFile.ParentID).FirstOrDefault();
                Assert.AreEqual("", tvFileModel.Error);

                tvFileModel.ServerFileName = "Unique" + tvFileModel.ServerFileName;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.TVFileModelOKTVFileModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModel);
                        Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelTVFile = randomService.RandomTVItem(TVTypeEnum.File);
                Assert.AreEqual("", tvItemModelTVFile.Error);

                TVFileModel tvFileModel = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelTVFile.ParentID).FirstOrDefault();
                Assert.AreEqual("", tvFileModel.Error);

                tvFileModel.ServerFileName = "Unique" + tvFileModel.ServerFileName;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModel);
                        Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_GetTVFileExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelTVFile = randomService.RandomTVItem(TVTypeEnum.File);
                Assert.AreEqual("", tvItemModelTVFile.Error);

                TVFileModel tvFileModel = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelTVFile.ParentID).FirstOrDefault();
                Assert.AreEqual("", tvFileModel.Error);

                tvFileModel.ServerFileName = "Unique" + tvFileModel.ServerFileName;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVFileService.GetTVFileExistDBTVFileModel = (a) =>
                        {
                            return new TVFile();
                        };

                        TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModel);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.TVFile), tvFileModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_FillTVFile_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelTVFile = randomService.RandomTVItem(TVTypeEnum.File);
                Assert.AreEqual("", tvItemModelTVFile.Error);

                TVFileModel tvFileModel = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelTVFile.ParentID).FirstOrDefault();
                Assert.AreEqual("", tvFileModel.Error);

                tvFileModel.ServerFileName = "Unique" + tvFileModel.ServerFileName;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.FillTVFileTVFileTVFileModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModel);
                        Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_GetTVItemModelWithTVItemIDForLocationDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelTVFile = randomService.RandomTVItem(TVTypeEnum.File);
                Assert.AreEqual("", tvItemModelTVFile.Error);

                TVFileModel tvFileModel = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelTVFile.ParentID).FirstOrDefault();
                Assert.AreEqual("", tvFileModel.Error);

                tvFileModel.ServerFileName = "Unique" + tvFileModel.ServerFileName;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.GetTVItemModelWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModel);
                        Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                TVItemModel tvItemModelTVFile = randomService.RandomTVItem(TVTypeEnum.File);
                Assert.AreEqual("", tvItemModelTVFile.Error);

                TVFileModel tvFileModel = tvFileService.GetTVFileModelListWithParentTVItemIDDB(tvItemModelTVFile.ParentID).FirstOrDefault();
                Assert.AreEqual("", tvFileModel.Error);

                tvFileModel.ServerFileName = "Unique" + tvFileModel.ServerFileName;

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModel);
                        Assert.AreEqual(ErrorText, tvFileModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVFileService.FillTVFileTVFileTVFileModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        TVFileModel tvFileModelRet = AddTVFileModel();
                        Assert.IsTrue(tvFileModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListBad[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tvFileModelNew.TVFileTVItemID = randomService.RandomTVItem(TVTypeEnum.Root).TVItemID;
                    FillTVFileModel(tvFileModelNew);

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.IsNotNull(tvFileModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tvFileModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostAddTVFileDB_NeedToBeLoggedIn_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[3], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    tvFileModelNew.TVFileTVItemID = randomService.RandomTVItem(TVTypeEnum.Root).TVItemID;
                    FillTVFileModel(tvFileModelNew);

                    TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
                    Assert.IsNotNull(tvFileModelRet);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, tvFileModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostDeleteTVFile_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet2 = tvFileService.PostDeleteTVFileDB(tvFileModelRet.TVFileID);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostDeleteTVFile_GetTVFileWithTVFileIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVFileService.GetTVFileWithTVFileIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVFileModel tvFileModelRet2 = tvFileService.PostDeleteTVFileDB(tvFileModelRet.TVFileID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.TVFile), tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostDeleteTVFile_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    DirectoryInfo di = new DirectoryInfo(tvFileModelRet.ServerFilePath);

                    if (!di.Exists)
                    {
                        di.Create();
                    }

                    di = new DirectoryInfo(tvFileModelRet.ServerFilePath);
                    Assert.IsTrue(di.Exists);

                    StreamWriter sw = new StreamWriter(tvFileModelRet.ServerFilePath + tvFileModelRet.ServerFileName);

                    for (int i = 0; i < 10; i++)
                    {
                        sw.WriteLine("Testing" + i.ToString());
                    }

                    sw.Close();

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVFileModel tvFileModelRet2 = tvFileService.PostDeleteTVFileDB(tvFileModelRet.TVFileID);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostDeleteTVFile_PostDeleteTVItemWithTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVItemService.PostDeleteTVItemWithTVItemIDDBInt32 = (a) =>
                        {
                            return new TVItemModel() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet2 = tvFileService.PostDeleteTVFileDB(tvFileModelRet.TVFileID);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostDeleteTVFileWithTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    DirectoryInfo di = new DirectoryInfo(tvFileModelRet.ServerFilePath);

                    if (!di.Exists)
                    {
                        di.Create();
                    }

                    di = new DirectoryInfo(tvFileModelRet.ServerFilePath);
                    Assert.IsTrue(di.Exists);

                    StreamWriter sw = new StreamWriter(tvFileModelRet.ServerFilePath + tvFileModelRet.ServerFileName);

                    for (int i = 0; i < 10; i++)
                    {
                        sw.WriteLine("Testing" + i.ToString());
                    }

                    sw.Close();

                    TVFileModel tvFileModelRet2 = tvFileService.PostDeleteTVFileWithTVItemIDDB(tvFileModelRet.TVFileTVItemID);
                    Assert.AreEqual("", tvFileModelRet2.Error);
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostDeleteTVFileWithTVItemIDDB_GetTVFileModelWithTVFileTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.GetTVFileModelWithTVFileTVItemIDDBInt32 = (a) =>
                        {
                            return new TVFileModel() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet2 = tvFileService.PostDeleteTVFileWithTVItemIDDB(tvFileModelRet.TVFileID);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostDeleteTVFileWithTVItemIDDB_PostDeleteTVFileDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.PostDeleteTVFileDBInt32 = (a) =>
                        {
                            return new TVFileModel() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet2 = tvFileService.PostDeleteTVFileWithTVItemIDDB(tvFileModelRet.TVFileTVItemID);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostUpdateTVFile_TVFileModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.TVFileModelOKTVFileModel = (a) =>
                        {
                            return ErrorText;
                        };

                        TVFileModel tvFileModelRet2 = UpdateTVFileModel(tvFileModelRet);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostUpdateTVFile_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        TVFileModel tvFileModelRet2 = UpdateTVFileModel(tvFileModelRet);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostUpdateTVFile_GetTVFileWithTVFileIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimTVFileService.GetTVFileWithTVFileIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        TVFileModel tvFileModelRet2 = UpdateTVFileModel(tvFileModelRet);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.TVFile), tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostUpdateTVFile_FillTVFile_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.FillTVFileTVFileTVFileModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        TVFileModel tvFileModelRet2 = UpdateTVFileModel(tvFileModelRet);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void TVFileService_PostUpdateTVFile_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVFileModel tvFileModelRet = AddTVFileModel();
                    Assert.AreEqual("", tvFileModelRet.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        TVFileModel tvFileModelRet2 = tvFileService.PostUpdateTVFileDB(tvFileModelRet);
                        Assert.AreEqual(ErrorText, tvFileModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Function
        public MWQMPlanModel AddMWQMPlanModel()
        {
            TVItemModel tvItemModelProvince = randomService.RandomTVItem(TVTypeEnum.Province);
            Assert.AreEqual("", tvItemModelProvince.Error);

            MWQMPlanModel mwqmPlanModelNew = new MWQMPlanModel()
            {
                ProvinceTVItemID = tvItemModelProvince.TVItemID,
                ConfigFileName = "config_" + randomService.RandomString("", 20) + ".txt",
                ForGroupName = randomService.RandomString("", 20),
                Year = randomService.RandomInt(2015, 2020),
                SecretCode = randomService.RandomString("", 8),
                CreatorTVItemID = 2,
            };

            MWQMPlanModel mwqmPlanModelRet = mwqmPlanService.PostAddMWQMPlanDB(mwqmPlanModelNew);
            Assert.AreEqual("", mwqmPlanModelRet.Error);

            List<TVItemModel> tvItemModelSubsectorList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelProvince.TVItemID, TVTypeEnum.Subsector);

            int countSubsector = 0;
            foreach (TVItemModel tvItemModelSubsector in tvItemModelSubsectorList)
            {
                List<TVItemModel> tvItemModelSubsectorSiteList = tvItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelSubsector.TVItemID, TVTypeEnum.MWQMSite);
                if (tvItemModelSubsectorSiteList.Count > 0)
                {
                    countSubsector += 1;
                    if (countSubsector > 3)
                    {
                        break;
                    }

                    MWQMPlanSubsectorModel mwqmPlanSubsectorModelNew = new MWQMPlanSubsectorModel()
                    {
                        MWQMPlanID = mwqmPlanModelRet.MWQMPlanID,
                        SubsectorTVItemID = tvItemModelSubsector.TVItemID,
                    };

                    MWQMPlanSubsectorModel mwqmPlanSubsectorModelRet = mwqmPlanSubsectorService.PostAddMWQMPlanSubsectorDB(mwqmPlanSubsectorModelNew);
                    Assert.AreEqual("", mwqmPlanSubsectorModelRet.Error);

                    int countSite = 0;
                    foreach (TVItemModel tvItemModelSusectorSite in tvItemModelSubsectorSiteList)
                    {
                        countSite += 1;
                        if (countSite > 3)
                        {
                            break;
                        }
                        MWQMPlanSubsectorSiteModel mwqmPlanSubsectorSiteModelNew = new MWQMPlanSubsectorSiteModel()
                        {
                            IsDuplicate = (countSite == 1 ? true : false),
                            MWQMPlanSubsectorID = mwqmPlanSubsectorModelRet.MWQMPlanSubsectorID,
                            MWQMSiteTVItemID = tvItemModelSusectorSite.TVItemID,
                        };

                        MWQMPlanSubsectorSiteModel mwqmPlanSubsectorSiteModelRet = mwqmPlanSubsectorSiteService.PostAddMWQMPlanSubsectorSiteDB(mwqmPlanSubsectorSiteModelNew);
                        Assert.AreEqual("", mwqmPlanSubsectorSiteModelRet.Error);

                    }
                }
            }

            return mwqmPlanModelRet;
        }
        public TVFileModel AddTVFileModel()
        {
            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            Assert.AreEqual("", tvItemModelRoot.Error);

            TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
            Assert.AreEqual("", tvItemModelCanada.Error);

            string FileName = "thisisauniquefilename.txt";
            TVItemModel tvItemModelTVFile = tvFileService._TVItemService.PostAddChildTVItemDB(tvItemModelCanada.TVItemID, FileName, TVTypeEnum.File);
            if (!string.IsNullOrWhiteSpace(tvItemModelTVFile.Error))
            {
                return new TVFileModel() { Error = tvItemModelTVFile.Error };
            }

            tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
            FillTVFileModel(tvFileModelNew);

            tvFileModelNew.ServerFileName = FileName;

            TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
            if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
            {
                return tvFileModelRet;
            }

            CompareTVFileModels(tvFileModelNew, tvFileModelRet);

            return tvFileModelRet;
        }
        public TVFileModel AddTVFileModelTemplate()
        {
            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            Assert.AreEqual("", tvItemModelRoot.Error);

            TVItemModel tvItemModelCanada = tvItemService.GetChildTVItemModelWithParentIDAndTVTextAndTVTypeDB(tvItemModelRoot.TVItemID, "Canada", TVTypeEnum.Country);
            Assert.AreEqual("", tvItemModelCanada.Error);

            string FileName = "thisisauniquefilename2.docx";
            TVItemModel tvItemModelTVFile = tvFileService._TVItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, FileName, TVTypeEnum.File);
            if (!string.IsNullOrWhiteSpace(tvItemModelTVFile.Error))
            {
                return new TVFileModel() { Error = tvItemModelTVFile.Error };
            }

            tvFileModelNew.TVFileTVItemID = tvItemModelTVFile.TVItemID;
            FillTVFileModel(tvFileModelNew);

            tvFileModelNew.FilePurpose = FilePurposeEnum.Template;
            tvFileModelNew.FileType = FileTypeEnum.DOCX;

            TVFileModel tvFileModelRet = tvFileService.PostAddTVFileDB(tvFileModelNew);
            if (!string.IsNullOrWhiteSpace(tvFileModelRet.Error))
            {
                return tvFileModelRet;
            }

            CompareTVFileModels(tvFileModelNew, tvFileModelRet);

            DocTemplateModel docTemplateModelNew = new DocTemplateModel()
            {
                TVFileTVItemID = tvFileModelRet.TVFileTVItemID,
                FileName = FileName,
                TVType = TVTypeEnum.Country,
            };

            DocTemplateService docTemplateService = new DocTemplateService(tvFileService.LanguageRequest, tvFileService.User);
            DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModelNew);
            Assert.AreEqual("", docTemplateModelRet.Error);

            return tvFileModelRet;
        }
        private FormCollection GetFormCollectionForFileGenerateDB(TVItemModel tvItemModel, FileInfo fi)
        {
            FormCollection fc = new FormCollection();
            fc.Add("TVItemID", tvItemModel.TVItemID.ToString());
            fc.Add("FileName", fi.Name);

            return fc;
        }
        public void CompareTVFileModels(TVFileModel tvFileModelRet, TVFileModel tvFileModel)
        {
            Assert.AreEqual(tvFileModelRet.TVFileTVItemID, tvFileModel.TVFileTVItemID);
            Assert.AreEqual(tvFileModelRet.Language, tvFileModel.Language);
            Assert.AreEqual(tvFileModelRet.FilePurpose, tvFileModel.FilePurpose);
            Assert.AreEqual(tvFileModelRet.FileType, tvFileModel.FileType);
            Assert.AreEqual(tvFileModelRet.FileDescription, tvFileModel.FileDescription);
            Assert.AreEqual(tvFileModelRet.FileSize_kb, tvFileModel.FileSize_kb);
            Assert.AreEqual(tvFileModelRet.FileInfo, tvFileModel.FileInfo);
            Assert.AreEqual(tvFileModelRet.FileCreatedDate_UTC, tvFileModel.FileCreatedDate_UTC);
            Assert.AreEqual(tvFileModelRet.ClientFilePath, tvFileModel.ClientFilePath);
            Assert.AreEqual(tvFileModelRet.ServerFileName, tvFileModel.ServerFileName);
            //Assert.AreEqual(tvFileModelRet.ServerFilePath, tvFileModel.ServerFilePath);
        }
        public void FillTVFileModel(TVFileModel tvFileModel)
        {
            tvFileModel.TVFileTVItemID = tvFileModel.TVFileTVItemID;
            tvFileModel.Language = LanguageEnum.en;
            tvFileModel.FilePurpose = FilePurposeEnum.Image;
            tvFileModel.FileType = FileTypeEnum.PNG;
            tvFileModel.FileDescription = randomService.RandomString("File Description", 200);
            tvFileModel.FileSize_kb = randomService.RandomInt(1, 2000000);
            tvFileModel.FileInfo = randomService.RandomString("File Info", 200);
            tvFileModel.FileCreatedDate_UTC = randomService.RandomDateTime();
            tvFileModel.ClientFilePath = "";
            tvFileModel.ServerFileName = randomService.RandomString("ServerFileName_", 20) + ".html";
            tvFileModel.ServerFilePath = tvFileService.GetServerFilePath(tvFileModel.TVFileTVItemID).Replace(@"C:\", @"E:\");
            Assert.IsTrue(tvFileModel.TVFileTVItemID != 0);
            Assert.IsTrue(tvFileModel.Language == LanguageEnum.en);
            Assert.IsTrue(tvFileModel.FilePurpose == FilePurposeEnum.Image);
            Assert.IsTrue(tvFileModel.FileType == FileTypeEnum.PNG);
            Assert.IsTrue(tvFileModel.FileDescription.Length == 200);
            Assert.IsTrue(tvFileModel.FileSize_kb >= 1 && tvFileModel.FileSize_kb <= 2000000);
            Assert.IsTrue(tvFileModel.FileInfo.Length == 200);
            Assert.IsTrue(tvFileModel.FileCreatedDate_UTC != null);
            Assert.IsTrue(tvFileModel.ClientFilePath.Length == 0);
            Assert.IsTrue(tvFileModel.ServerFileName.Length == 25);
            Assert.IsTrue(tvFileModel.ServerFilePath.Length >= 0);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            tvFileService = new TVFileService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mikeScenarioService = new MikeScenarioService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            appTaskService = new AppTaskService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileModelNew = new TVFileModel();
            tvFile = new TVFile();
            mikeScenarioServiceTest = new MikeScenarioServiceTest();
            mikeScenarioServiceTest.SetupTest(contactModelToDo, culture);
            mwqmPlanService = new MWQMPlanService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmPlanSubsectorService = new MWQMPlanSubsectorService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            mwqmPlanSubsectorSiteService = new MWQMPlanSubsectorSiteService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);

        }
        private void SetupShim()
        {
            shimTVFileService = new ShimTVFileService(tvFileService);
            shimTVItemService = new ShimTVItemService(tvFileService._TVItemService);
            shimAppTaskService = new ShimAppTaskService(tvFileService._AppTaskService);
            shimMapInfoService = new ShimMapInfoService(tvFileService._MapInfoService);
        }
        public TVFileModel UpdateTVFileModel(TVFileModel tvFileModel)
        {
            FillTVFileModel(tvFileModel);

            TVFileModel tvFileModelRet2 = tvFileService.PostUpdateTVFileDB(tvFileModel);
            if (!string.IsNullOrWhiteSpace(tvFileModelRet2.Error))
            {
                return tvFileModelRet2;
            }

            CompareTVFileModels(tvFileModel, tvFileModelRet2);

            return tvFileModelRet2;
        }
        #endregion Function
    }
}


