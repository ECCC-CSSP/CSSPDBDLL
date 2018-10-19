using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSSPWebToolsDBDLL.Tests.SetupInfo;
using CSSPWebToolsDBDLL.Models;
using System.Security.Principal;
using CSSPWebToolsDBDLL.Services;
using CSSPWebToolsDBDLL.Services.Resources;
using System.Transactions;
using CSSPWebToolsDBDLL.Services.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Linq;
using System.Globalization;
using System.Threading;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;
using System.IO;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for DocTemplateServiceTest
    /// </summary>
    [TestClass]
    public class DocTemplateServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "DocTemplate";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private DocTemplateService docTemplateService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private DocTemplateModel docTemplateModelNew { get; set; }
        private DocTemplate docTemplate { get; set; }
        private ShimDocTemplateService shimDocTemplateService { get; set; }
        private ShimTVItemService shimTVItemService { get; set; }
        private ShimTVFileService shimTVFileService { get; set; }
        private TVItemService tvItemService { get; set; }
        private TVFileService tvFileService { get; set; }
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
        public DocTemplateServiceTest()
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
        public void DocTemplateService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                Assert.IsNotNull(docTemplateService);
                Assert.IsNotNull(docTemplateService.db);
                Assert.IsNotNull(docTemplateService.LanguageRequest);
                Assert.IsNotNull(docTemplateService.User);
                Assert.AreEqual(user.Identity.Name, docTemplateService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), docTemplateService.LanguageRequest);
                Assert.IsNotNull(docTemplateService._TVItemService);
                Assert.IsNotNull(docTemplateService._LogService);
                Assert.IsNotNull(docTemplateService._TVFileService);
            }
        }
        [TestMethod]
        public void DocTemplateService_DocTemplateModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    #region Good
                    FillDocTemplateModel(docTemplateModel);

                    string retStr = docTemplateService.DocTemplateModelOK(docTemplateModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Good

                    #region Language
                    FillDocTemplateModel(docTemplateModel);
                    docTemplateModelNew.Language = (LanguageEnum)10000;

                    retStr = docTemplateService.DocTemplateModelOK(docTemplateModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.Language), retStr);

                    FillDocTemplateModel(docTemplateModel);
                    docTemplateModelNew.Language = LanguageEnum.en;

                    retStr = docTemplateService.DocTemplateModelOK(docTemplateModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion Language

                    #region TVType
                    FillDocTemplateModel(docTemplateModel);
                    docTemplateModelNew.TVType = TVTypeEnum.Error;

                    retStr = docTemplateService.DocTemplateModelOK(docTemplateModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVType), retStr);

                    FillDocTemplateModel(docTemplateModel);
                    docTemplateModelNew.TVType = TVTypeEnum.Subsector;

                    retStr = docTemplateService.DocTemplateModelOK(docTemplateModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion TVType

                    #region TVFileTVItemID
                    FillDocTemplateModel(docTemplateModel);
                    docTemplateModelNew.TVFileTVItemID = 0;

                    retStr = docTemplateService.DocTemplateModelOK(docTemplateModelNew);
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.TVFileTVItemID), retStr);

                    FillDocTemplateModel(docTemplateModel);
                    docTemplateModelNew.TVFileTVItemID = 1;

                    retStr = docTemplateService.DocTemplateModelOK(docTemplateModelNew);
                    Assert.IsNotNull("", retStr);
                    #endregion TVFileTVItemID

                    #region FileName
                    FillDocTemplateModel(docTemplateModel);
                    docTemplateModelNew.FileName = "";
                    Assert.IsNotNull(string.Format(ServiceRes._IsRequired, ServiceRes.FileName), retStr);

                    FillDocTemplateModel(docTemplateModel);
                    docTemplateModelNew.FileName = randomService.RandomString("", 30);
                    Assert.IsNotNull("", retStr);
                    #endregion FileName
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_FillDocTemplate_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    TVItemModel tvItemModelInfrastructure = randomService.RandomTVItem(TVTypeEnum.Infrastructure);
                    Assert.AreEqual("", tvItemModelInfrastructure.Error);

                    TVItemModel tvItemModelMunicipality = randomService.RandomTVItem(TVTypeEnum.Municipality);
                    Assert.AreEqual("", tvItemModelMunicipality.Error);

                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    ContactOK contactOK = docTemplateService.IsContactOK();

                    string retStr = docTemplateService.FillDocTemplate(docTemplate, docTemplateModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(contactOK.ContactTVItemID, docTemplate.LastUpdateContactTVItemID);

                    contactOK = null;

                    retStr = docTemplateService.FillDocTemplate(docTemplate, docTemplateModelNew, contactOK);
                    Assert.AreEqual("", retStr);
                    Assert.AreEqual(2, docTemplate.LastUpdateContactTVItemID);
                }
                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_GetDocTemplateModelCountDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModelRet = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModelRet.Error);

                    int docTemplateCount = docTemplateService.GetDocTemplateModelCountDB();
                    Assert.AreEqual(testDBService.Count + 1, docTemplateCount);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_GetDocTemplateModelWithTVFileIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModelRet = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModelRet.Error);

                    DocTemplateModel docTemplateModel = docTemplateService.GetDocTemplateModelWithTVFileTVItemIDDB((int)docTemplateModelRet.TVFileTVItemID);
                    Assert.AreEqual("", docTemplateModel.Error);

                    int TVFileTVItemID = 0;
                    docTemplateModel = docTemplateService.GetDocTemplateModelWithTVFileTVItemIDDB(TVFileTVItemID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DocTemplate, ServiceRes.TVFileTVItemID, TVFileTVItemID.ToString()), docTemplateModel.Error);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_GetDocTemplateModelListWithTVTypeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModelRet = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModelRet.Error);

                    List<DocTemplateModel> docTemplateModelList = docTemplateService.GetDocTemplateModelListWithTVTypeDB(docTemplateModelRet.TVType);
                    Assert.IsTrue(docTemplateModelList.Where(c => c.DocTemplateID == docTemplateModelRet.DocTemplateID).Any());

                    TVTypeEnum TVType = TVTypeEnum.Error;
                    docTemplateModelList = docTemplateService.GetDocTemplateModelListWithTVTypeDB(TVType);
                    Assert.AreEqual(0, docTemplateModelList.Count);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_GetDocTemplateModelWithDocTemplateIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModelRet = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModelRet.Error);

                    DocTemplateModel docTemplateModelRet2 = docTemplateService.GetDocTemplateModelWithDocTemplateIDDB(docTemplateModelRet.DocTemplateID);
                    Assert.AreEqual(docTemplateModelRet.DocTemplateID, docTemplateModelRet2.DocTemplateID);

                    int DocTemplateID = 0;
                    DocTemplateModel docTemplateRet2 = docTemplateService.GetDocTemplateModelWithDocTemplateIDDB(DocTemplateID);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DocTemplate, ServiceRes.DocTemplateID, DocTemplateID), docTemplateRet2.Error);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_GetDocTemplateWithDocTemplateIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModelRet = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModelRet.Error);

                    DocTemplate docTemplateRet = docTemplateService.GetDocTemplateWithDocTemplateIDDB(docTemplateModelRet.DocTemplateID);
                    Assert.AreEqual(docTemplateModelRet.DocTemplateID, docTemplateRet.DocTemplateID);

                    DocTemplate docTemplateRet2 = docTemplateService.GetDocTemplateWithDocTemplateIDDB(0);
                    Assert.IsNull(docTemplateRet2);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_GetDocTemplateModelExistDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModelRet = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModelRet.Error);

                    DocTemplateModel docTemplateModelRet2 = docTemplateService.GetDocTemplateModelExistDB(docTemplateModelRet);
                    Assert.AreEqual("", docTemplateModelRet2.Error);

                    string FileName = "CertainlyUniqueFileName2.docx";

                    docTemplateModelRet.FileName = FileName;
                    docTemplateModelRet2 = docTemplateService.GetDocTemplateModelExistDB(docTemplateModelRet);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.DocTemplate, ServiceRes.TVType + "," + ServiceRes.FileName, docTemplateModelRet.TVType.ToString() + "," + docTemplateModelRet.FileName), docTemplateModelRet2.Error);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    DocTemplateModel docTemplateModelRet = docTemplateService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, docTemplateModelRet.Error);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_GenerateFileNameForTemplate_Root_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModelRet = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModelRet.Error);

                    TVItemModel tvItemModelParent = docTemplateService._TVItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelParent.Error);

                    string serverFilePath = docTemplateService._TVFileService.GetServerFilePath(tvItemModelParent.TVItemID);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(serverFilePath));

                    string fileName = docTemplateService.GenerateFileNameForDocTemplate(docTemplateModelRet.DocTemplateID, tvItemModelParent.TVItemID, culture.TwoLetterISOLanguageName);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(fileName));

                    FileInfo fi = new FileInfo(docTemplateService._TVFileService.ChoseEDriveOrCDrive(tvFileService.GetServerFilePath(tvItemModelParent.TVItemID)) + fileName);
                    Assert.IsNotNull(fi);
                    Assert.IsFalse(fi.FullName.StartsWith("ERROR"));
                    Assert.IsFalse(fi.FullName.Contains(@"/" + tvItemModelParent.TVItemID + @"/"));
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_GenerateFileNameForTemplate_Canada_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModelRet = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModelRet.Error);

                    TVItemModel tvItemModelRoot= docTemplateService._TVItemService.GetRootTVItemModelDB();
                    Assert.AreEqual("", tvItemModelRoot.Error);

                    TVItemModel tvItemModelParent = docTemplateService._TVItemService.GetChildrenTVItemModelListWithTVItemIDAndTVTypeDB(tvItemModelRoot.TVItemID, TVTypeEnum.Country).Where(c => c.TVText == "Canada").FirstOrDefault();
                    Assert.AreEqual("", tvItemModelParent.Error);

                    string serverFilePath = docTemplateService._TVFileService.GetServerFilePath(tvItemModelParent.TVItemID);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(serverFilePath));

                    string fileName = docTemplateService.GenerateFileNameForDocTemplate(docTemplateModelRet.DocTemplateID, tvItemModelParent.TVItemID, culture.TwoLetterISOLanguageName);
                    Assert.IsFalse(string.IsNullOrWhiteSpace(fileName));

                    FileInfo fi = new FileInfo(docTemplateService._TVFileService.ChoseEDriveOrCDrive(tvFileService.GetServerFilePath(tvItemModelParent.TVItemID)) + fileName);
                    Assert.IsNotNull(fi);
                    Assert.IsFalse(fi.FullName.StartsWith("ERROR"));
                    Assert.IsFalse(fi.FullName.Contains(@"/" + tvItemModelParent.TVItemID + @"/"));
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddUpdateDeleteDocTemplate_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    string FileName = "CertainlyUniqueFileName2.docx";

                    docTemplateModel.FileName = FileName;
                    DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
                    Assert.AreEqual("", docTemplateModelRet2.Error);

                    DocTemplateModel docTemplateModelRet3 = docTemplateService.PostDeleteDocTemplateWithDocTemplateIDDB(docTemplateModelRet2.DocTemplateID);
                    Assert.AreEqual("", docTemplateModelRet3.Error);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_DocTemplateModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.DocTemplateModelOKDocTemplateModel = (a) =>
                        {
                            return ErrorText;
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_GetTVFileModelWithTVFileTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.GetTVFileModelWithTVFileTVItemIDDBInt32 = (a) =>
                        {
                            return new TVFileModel() { Error = ErrorText };
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_GetDocTemplateModelExistDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimDocTemplateService.GetDocTemplateModelExistDBDocTemplateModel = (a) =>
                        {
                            return new DocTemplateModel() { Error = "" };
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(string.Format(ServiceRes._AlreadyExists, ServiceRes.DocTemplate), docTemplateModelRet.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_FillDocTemplate_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.FillDocTemplateDocTemplateDocTemplateModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet.Error);
                    }
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_Add_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimDocTemplateService.FillDocTemplateDocTemplateDocTemplateModelContactOK = (a, b, c) =>
                        {
                            return "";
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                        Assert.IsTrue(docTemplateModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_BadUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    SetupTest(contactModelListBad[0], culture);

                    string FileName = "CertainlyUniqueFileName2.docx";

                    docTemplateModel.FileName = FileName;

                    DocTemplateModel docTemplateModelRet2 = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, docTemplateModelRet2.Error);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostAddDocTemplateDB_UserEmailNotValidated_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.IsNotNull(docTemplateModel);

                    SetupTest(contactModelListGood[3], culture);

                    string FileName = "CertainlyUniqueFileName2.docx";

                    docTemplateModel.FileName = FileName;

                    DocTemplateModel docTemplateModelRet2 = docTemplateService.PostAddDocTemplateDB(docTemplateModel);
                    Assert.AreEqual(ServiceRes.NeedToBeLoggedIn, docTemplateModelRet2.Error);
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostDeleteDocTemplateDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostDeleteDocTemplateWithDocTemplateIDDB(docTemplateModel.DocTemplateID);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostDeleteDocTemplateDB_GetDocTemplateWithDocTemplateIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimDocTemplateService.GetDocTemplateWithDocTemplateIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostDeleteDocTemplateWithDocTemplateIDDB(docTemplateModel.DocTemplateID);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.DocTemplate), docTemplateModelRet2.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostDeleteDocTemplateDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostDeleteDocTemplateWithDocTemplateIDDB(docTemplateModel.DocTemplateID);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostDeleteDocTemplateWithTVFileTVItemIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostDeleteDocTemplateWithTVFileTVItemIDDB(docTemplateModel.TVFileTVItemID);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostUpdateDocTemplateDB_DocTemplateModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.DocTemplateModelOKDocTemplateModel = (a) =>
                        {
                            return ErrorText;
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostUpdateDocTemplateDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostUpdateDocTemplateDB_GetTVFileModelWithTVFileTVItemIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.GetTVFileModelWithTVFileTVItemIDDBInt32 = (a) =>
                        {
                            return new TVFileModel() { Error = ErrorText };
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostUpdateDocTemplateDB_GetDocTemplateWithDocTemplateIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimDocTemplateService.GetDocTemplateWithDocTemplateIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.DocTemplate), docTemplateModelRet2.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostUpdateDocTemplateDB_FillDocTemplate_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.FillDocTemplateDocTemplateDocTemplateModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }

                    CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
                }
            }
        }
        [TestMethod]
        public void DocTemplateService_PostUpdateDocTemplateDB_PostUpdateTVFileDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimTVFileService.PostUpdateTVFileDBTVFileModel = (a) =>
                        {
                            return new TVFileModel() { Error = ErrorText };
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }
                }

                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        [TestMethod]
        public void DocTemplateService_PostUpdateDocTemplateDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    DocTemplateModel docTemplateModel = AddDocTemplateModel();
                    Assert.AreEqual("", docTemplateModel.Error);

                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimDocTemplateService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        string FileName = "CertainlyUniqueFileName2.docx";

                        docTemplateModel.FileName = FileName;
                        DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
                        Assert.AreEqual(ErrorText, docTemplateModelRet2.Error);
                    }
                }
                CleanTemporaryFile(docTemplateService._TVItemService.GetRootTVItemModelDB().TVItemID);
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public DocTemplateModel AddDocTemplateModel()
        {
            TVItemModel tvItemModelRoot = tvItemService.GetRootTVItemModelDB();
            Assert.AreEqual("", tvItemModelRoot.Error);

            string FileName = "CertainlyUniqueFileName.docx";

            TVItemModel tvItemModelChild = tvItemService.PostAddChildTVItemDB(tvItemModelRoot.TVItemID, FileName.Replace(".docx", ""), TVTypeEnum.File);
            Assert.AreEqual("", tvItemModelChild.Error);

            string ServerFilePath = tvFileService.GetServerFilePath(tvItemModelRoot.TVItemID);

            TVFileModel tvFileModelNew = new TVFileModel()
            {
                TVFileTVItemID = tvItemModelChild.TVItemID,
                Language = LanguageEnum.en,
                FilePurpose = FilePurposeEnum.Template,
                FileType = FileTypeEnum.DOCX,
                FileDescription = randomService.RandomString("File Description", 200),
                FileSize_kb = randomService.RandomInt(1, 2000000),
                FileInfo = randomService.RandomString("File Info", 200),
                FileCreatedDate_UTC = randomService.RandomDateTime(),
                ClientFilePath = "",
                ServerFileName = FileName,
                ServerFilePath = ServerFilePath,
            };

            TVFileModel tvFileModel = tvFileService.PostAddTVFileDB(tvFileModelNew);
            Assert.AreEqual("", tvFileModel.Error);

            FileInfo fi = new FileInfo(tvFileModelNew.ServerFilePath + tvFileModelNew.ServerFileName);

            if (fi.Exists)
            {
                fi.Delete();
            }

            StreamWriter sw = fi.CreateText();
            sw.WriteLine("|||Write something in the file|||");
            sw.Flush();
            sw.Close();

            docTemplateModelNew.Language = LanguageEnum.en;
            docTemplateModelNew.TVType = TVTypeEnum.Root;
            docTemplateModelNew.TVFileTVItemID = tvItemModelChild.TVItemID;
            docTemplateModelNew.FileName = FileName;

            Assert.IsTrue(docTemplateModelNew.TVType == TVTypeEnum.Root);
            Assert.IsTrue(docTemplateModelNew.TVFileTVItemID != 0);
            Assert.IsTrue(docTemplateModelNew.FileName.Length > 0);

            DocTemplateModel docTemplateModelRet = docTemplateService.PostAddDocTemplateDB(docTemplateModelNew);
            if (!string.IsNullOrWhiteSpace(docTemplateModelRet.Error))
            {
                return docTemplateModelRet;
            }

            CompareDocTemplateModels(docTemplateModelNew, docTemplateModelRet);

            return docTemplateModelRet;
        }
        public void CleanTemporaryFile(int TVItemID)
        {
            string ServerFilePath = tvFileService.GetServerFilePath(TVItemID);

            List<string> FileToRemoveList = new List<string>() { ServerFilePath + "CertainlyUniqueFileName.docx", ServerFilePath + "CertainlyUniqueFileName2.docx" };

            foreach (string fileName in FileToRemoveList)
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)
                    fi.Delete();
            }

        }
        public DocTemplateModel UpdateDocTemplateModel(DocTemplateModel docTemplateModel)
        {
            string FileName = "CertainlyUniqueFileName2.docx";

            docTemplateModel.FileName = FileName;

            DocTemplateModel docTemplateModelRet2 = docTemplateService.PostUpdateDocTemplateDB(docTemplateModel);
            if (!string.IsNullOrWhiteSpace(docTemplateModelRet2.Error))
            {
                return docTemplateModelRet2;
            }

            CompareDocTemplateModels(docTemplateModel, docTemplateModelRet2);

            return docTemplateModelRet2;
        }
        private void CompareDocTemplateModels(DocTemplateModel docTemplateModelNew, DocTemplateModel docTemplateModelRet)
        {
            Assert.AreEqual(docTemplateModelNew.Language, docTemplateModelRet.Language);
            Assert.AreEqual(docTemplateModelNew.TVType, docTemplateModelRet.TVType);
            Assert.AreEqual(docTemplateModelNew.TVFileTVItemID, docTemplateModelRet.TVFileTVItemID);
            Assert.AreEqual(docTemplateModelNew.FileName, docTemplateModelRet.FileName);
        }
        private void FillDocTemplateModel(DocTemplateModel docTemplateModel)
        {
            docTemplateModelNew.Language = docTemplateModel.Language;
            docTemplateModelNew.TVType = docTemplateModel.TVType;
            docTemplateModelNew.TVFileTVItemID = docTemplateModel.TVFileTVItemID;
            docTemplateModelNew.FileName = docTemplateModel.FileName;

            Assert.IsTrue(docTemplateModelNew.TVType == TVTypeEnum.Root);
            Assert.IsTrue(docTemplateModelNew.TVFileTVItemID != 0);
            Assert.IsTrue(docTemplateModelNew.FileName.Length > 0);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            docTemplateService = new DocTemplateService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvItemService = new TVItemService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            tvFileService = new TVFileService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            docTemplateModelNew = new DocTemplateModel();
            docTemplate = new DocTemplate();
        }
        private void SetupShim()
        {
            shimDocTemplateService = new ShimDocTemplateService(docTemplateService);
            shimTVItemService = new ShimTVItemService(docTemplateService._TVItemService);
            shimTVFileService = new ShimTVFileService(docTemplateService._TVFileService);
        }
        #endregion Functions private
    }
}

