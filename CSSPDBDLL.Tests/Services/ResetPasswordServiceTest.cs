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
using System.Transactions;
using CSSPWebToolsDBDLL.Services.Fakes;
using System.Globalization;
using System.Threading;
using Microsoft.QualityTools.Testing.Fakes;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for ResetPasswordServiceTest
    /// </summary>
    [TestClass]
    public class ResetPasswordServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "ResetPassword";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private ResetPasswordService resetPasswordService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private ResetPasswordModel resetPasswordModelNew { get; set; }
        private ResetPassword resetPassword { get; set; }
        private ShimResetPasswordService shimResetPasswordService { get; set; }
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
        public ResetPasswordServiceTest()
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
        public void ResetPasswordService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange

                Assert.IsNotNull(resetPasswordService);
                Assert.IsNotNull(resetPasswordService.db);
                Assert.IsNotNull(resetPasswordService.LanguageRequest);
                Assert.IsNotNull(resetPasswordService.User);
                Assert.AreEqual(user.Identity.Name, resetPasswordService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), resetPasswordService.LanguageRequest);
            }
        }
        [TestMethod]
        public void ResetPasswordService_ResetPasswordModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillResetPasswordModel(resetPasswordModelNew);
                    resetPasswordModelNew.Code = "";

                    string retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Code), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    int Max = 8;
                    resetPasswordModelNew.Code = resetPasswordModelNew.Code + "a";

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Code, Max), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    int Min = 8;
                    resetPasswordModelNew.Code = resetPasswordModelNew.Code.Substring(1);

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Code, Min), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    resetPasswordModelNew.Email = "";

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Email), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    Max = 255;
                    resetPasswordModelNew.Email = randomService.RandomString("Email", Max + 1) + "@ec.gc.ca";

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, Max), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    resetPasswordModelNew.Email = "charles.leblanc.ec.gc.ca";

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, resetPasswordModelNew.Email), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    resetPasswordModelNew.Password = "";

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Password), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    Max = 100;
                    resetPasswordModelNew.Password = randomService.RandomString("pass", Max + 1);

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Password, Max), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    Min = 6;
                    resetPasswordModelNew.Password = randomService.RandomString("pass", Min - 1);

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._MinLengthIs_, ServiceRes.Password, Min), retStr);

                    FillResetPasswordModel(resetPasswordModelNew);
                    resetPasswordModelNew.ConfirmPassword = "";

                    retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.ConfirmPassword), retStr);
                }
            }
        }
        [TestMethod]
        public void ResetPasswordService_ResetPasswordModelOK_Email_CouldNotFindEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    FillResetPasswordModel(resetPasswordModelNew);
                    resetPasswordModelNew.Email = "Charles.LeBlancNotFind@ec.gc.ca";

                    string retStr = resetPasswordService.ResetPasswordModelOK(resetPasswordModelNew);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_, ServiceRes.EmailIN), retStr);
                }
            }
        }
        [TestMethod]
        public void ResetPasswordService_ResetPasswordModelOK_CleanResetPasswordWithEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                string Email = "Charles.LeBlanc2@Canada.ca";
                int skip = 0;
                int take = 10000;

                using (TransactionScope ts = new TransactionScope())
                {
                    List<ResetPasswordModel> resetPasswordModelList = resetPasswordService.GetResetPasswordModelListDB(skip, take);

                    if (resetPasswordModelList.Count > 0)
                    {
                        foreach (ResetPasswordModel rpm in resetPasswordModelList)
                        {
                            ResetPasswordModel resetPasswordModelRet2 = resetPasswordService.PostDeleteResetPasswordDB(rpm.ResetPasswordID);
                            Assert.AreEqual("", resetPasswordModelRet2.Error);
                        }
                    }

                    ResetPasswordModel resetPasswordModelNew = new ResetPasswordModel();
                    FillResetPasswordModel(resetPasswordModelNew);
                    resetPasswordModelNew.ExpireDate_Local = DateTime.Today.AddDays(-1);

                    ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModelNew);

                    // Assert Email MoreThan255
                    Assert.IsNotNull(resetPasswordModelRet);
                    Assert.AreEqual(resetPasswordModelNew.Code, resetPasswordModelRet.Code);

                    int count = resetPasswordService.GetResetPasswordModelCountDB();
                    Assert.AreEqual(1, count);

                    string retStr2 = resetPasswordService.CleanResetPasswordWithEmail(Email);
                    Assert.AreEqual("", retStr2);

                    count = resetPasswordService.GetResetPasswordModelCountDB();
                    Assert.AreEqual(0, count);
                }
            }
        }
        [TestMethod]
        public void ResetPasswordService_FillResetPassword_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = AddResetPasswordModelWithPassDate();

                    ResetPassword resetPassword = new ResetPassword();

                    ContactOK contactOK = null;

                    string retStr = resetPasswordService.FillResetPassword(resetPassword, resetPasswordModel, contactOK);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void ResetPasswordService_GetResetPasswordModelCount_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int skip = 0;
                    int take = 100000;
                    List<ResetPasswordModel> resetPasswordModelList = resetPasswordService.GetResetPasswordModelListDB(skip, take);

                    foreach (ResetPasswordModel rpm in resetPasswordModelList)
                    {
                        ResetPasswordModel resetPasswordModelRet2 = resetPasswordService.PostDeleteResetPasswordDB(rpm.ResetPasswordID);

                        Assert.AreEqual("", resetPasswordModelRet2.Error);
                    }

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    // Act for Add
                    int resetPasswordCount = resetPasswordService.GetResetPasswordModelCountDB();
                    Assert.AreEqual(1, resetPasswordCount);

                }
            }
        }
        [TestMethod]
        public void ResetPasswordService_GetResetPasswordModelListDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    int skip = 0;
                    int take = 100000;
                    List<ResetPasswordModel> resetPasswordModelList = resetPasswordService.GetResetPasswordModelListDB(skip, take);

                    foreach (ResetPasswordModel rpm in resetPasswordModelList)
                    {
                        ResetPasswordModel resetPasswordModelRet2 = resetPasswordService.PostDeleteResetPasswordDB(rpm.ResetPasswordID);

                        Assert.AreEqual("", resetPasswordModelRet2.Error);
                    }

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    // Act 
                    resetPasswordModelList = resetPasswordService.GetResetPasswordModelListDB(skip, take);
                    Assert.AreEqual(1, resetPasswordModelList.Count);

                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_GetResetPasswordModelListWithEmailDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    // Act 
                    List<ResetPasswordModel> resetPasswordModelListRet = resetPasswordService.GetResetPasswordModelListWithEmailDB(resetPasswordModelRet.Email);
                    Assert.IsTrue(resetPasswordModelListRet.Count > 0);

                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_GetResetPasswordModelListWithCodeDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    // Act 
                    List<ResetPasswordModel> resetPasswordModelListRet = resetPasswordService.GetResetPasswordModelListWithCodeDB(resetPasswordModelRet.Code);
                    Assert.IsTrue(resetPasswordModelListRet.Count > 0);

                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_GetResetPasswordModelListWithCodeAndEmailDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    // Act 
                    ResetPasswordModel resetPasswordModelRet2 = resetPasswordService.GetResetPasswordModelWithCodeAndEmailDB(resetPasswordModelRet.Code, resetPasswordModelRet.Email);
                    Assert.AreEqual(resetPasswordModelRet.Code, resetPasswordModelRet2.Code);
                    Assert.AreEqual(resetPasswordModelRet.Email, resetPasswordModelRet2.Email);

                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_GetResetPasswordModelListWithResetPasswordIDDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    // Act 
                    ResetPasswordModel resetPasswordModelRet2 = resetPasswordService.GetResetPasswordModelWithResetPasswordIDDB(resetPasswordModelRet.ResetPasswordID);
                    Assert.IsNotNull(resetPasswordModelRet2);

                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_CleanResetPasswordWithEmail_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    ResetPasswordModel resetPasswordModel = AddResetPasswordModelWithPassDate();

                    string retStr = resetPasswordService.CleanResetPasswordWithEmail(contactModelListGood[0].LoginEmail);
                    Assert.AreEqual("", retStr);

                    ResetPasswordModel resetPasswordModelret = resetPasswordService.GetResetPasswordModelWithCodeAndEmailDB(resetPasswordModel.Code, resetPasswordModel.Email);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.ResetPassword, ServiceRes.Code + "," + ServiceRes.Email, resetPasswordModel.Code + "," + resetPasswordModel.Email), resetPasswordModelret.Error);

                }
            }
        }
        [TestMethod]
        public void ResetPasswordService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    ResetPasswordModel resetPasswordModelret = resetPasswordService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, resetPasswordModelret.Error);
                }
            }
        }
        [TestMethod]
        public void ResetPasswordService_PostAddResetPasswordDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    // Act 
                    ResetPasswordModel resetPasswordModelRet2 = resetPasswordService.GetResetPasswordModelWithResetPasswordIDDB(resetPasswordModelRet.ResetPasswordID);
                    Assert.IsNotNull(resetPasswordModelRet2);
                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_PostAddResetPasswordDB_ResetPasswordModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimResetPasswordService.ResetPasswordModelOKResetPasswordModel = (a) =>
                        {
                            return ErrorText;
                        };

                        FillResetPasswordModel(resetPasswordModelNew);

                        ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModelNew);
                    }
                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_PostAddResetPasswordDB_FillResetPassword_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimResetPasswordService.FillResetPasswordResetPasswordResetPasswordModelContactOK = (a, b, c) =>
                        {
                            return ErrorText;
                        };

                        FillResetPasswordModel(resetPasswordModelNew);

                        ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModelNew);
                    }
                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_PostAddResetPasswordDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimResetPasswordService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        FillResetPasswordModel(resetPasswordModelNew);

                        ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModelNew);
                    }
                }

            }
        }
        [TestMethod]
        public void ResetPasswordService_PostDeleteResetPasswordDB_GetResetPasswordWithResetPasswordIDDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    using (ShimsContext.Create())
                    {
                        //string ErrorText = "ErrorText";
                        SetupShim();
                        shimResetPasswordService.GetResetPasswordWithResetPasswordIDDBInt32 = (a) =>
                        {
                            return null;
                        };

                        ResetPasswordModel resetPasswordModelRet2 = resetPasswordService.PostDeleteResetPasswordDB(resetPasswordModelRet.ResetPasswordID);

                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.ResetPassword), resetPasswordModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void ResetPasswordService_PostDeleteResetPasswordDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {

                    ResetPasswordModel resetPasswordModelRet = AddResetPasswordModel();

                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        SetupShim();
                        shimResetPasswordService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        ResetPasswordModel resetPasswordModelRet2 = resetPasswordService.PostDeleteResetPasswordDB(resetPasswordModelRet.ResetPasswordID);

                        Assert.AreEqual(ErrorText, resetPasswordModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public ResetPasswordModel AddResetPasswordModel()
        {
            ResetPasswordModel resetPasswordModelNew = new ResetPasswordModel();
            FillResetPasswordModel(resetPasswordModelNew);

            ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModelNew);
            if (!string.IsNullOrWhiteSpace(resetPasswordModelRet.Error))
            {
                return resetPasswordModelRet;
            }

            Assert.IsNotNull(resetPasswordModelRet);
            CompareResetPasswordModels(resetPasswordModelNew, resetPasswordModelRet);

            return resetPasswordModelRet;
        }
        public ResetPasswordModel AddResetPasswordModelWithPassDate()
        {
            ResetPasswordModel resetPasswordModelNew = new ResetPasswordModel();
            FillResetPasswordModelWithPassDate(resetPasswordModelNew);

            ResetPasswordModel resetPasswordModelRet = resetPasswordService.PostAddResetPasswordDB(resetPasswordModelNew);
            if (!string.IsNullOrWhiteSpace(resetPasswordModelRet.Error))
            {
                return resetPasswordModelRet;
            }

            Assert.IsNotNull(resetPasswordModelRet);
            CompareResetPasswordModels(resetPasswordModelNew, resetPasswordModelRet);

            return resetPasswordModelRet;
        }
        private void CompareResetPasswordModels(ResetPasswordModel ResetPasswordModel, ResetPasswordModel ResetPasswordModelRet)
        {
            Assert.AreEqual(ResetPasswordModel.Code, ResetPasswordModelRet.Code);
            Assert.AreEqual(ResetPasswordModel.Email, ResetPasswordModelRet.Email);
            TimeSpan ts = new TimeSpan(ResetPasswordModelRet.ExpireDate_Local.Ticks - ResetPasswordModel.ExpireDate_Local.Ticks);
            Assert.IsTrue(ts.TotalSeconds < 5);
        }
        private void FillResetPasswordModel(ResetPasswordModel resetPasswordModel)
        {
            resetPasswordModel.Code = randomService.RandomInt(12345678, 98765432).ToString();
            resetPasswordModel.Email = randomService.RandomString("Charles.LeBlanc2@Canada.ca", "Charles.LeBlanc2@Canada.ca".Length);
            resetPasswordModel.Password = randomService.RandomPassword();
            resetPasswordModel.ConfirmPassword = resetPasswordModel.Password;
            resetPasswordModel.ExpireDate_Local = DateTime.UtcNow.AddDays(1);

            Assert.IsTrue(resetPasswordModel.Code.Length == 8);
            Assert.IsTrue(resetPasswordModel.Email == "Charles.LeBlanc2@Canada.ca");
            Assert.IsTrue(resetPasswordModel.Password.Length > 8);
            Assert.IsTrue(resetPasswordModel.ConfirmPassword.Length > 8);
            Assert.AreEqual(resetPasswordModel.Password, resetPasswordModel.ConfirmPassword);
            Assert.IsTrue(resetPasswordModel.ExpireDate_Local != null);
        }
        private void FillResetPasswordModelWithPassDate(ResetPasswordModel resetPasswordModel)
        {
            resetPasswordModel.Code = randomService.RandomInt(12345678, 98765432).ToString();
            resetPasswordModel.Email = randomService.RandomString("Charles.LeBlanc2@Canada.ca", "Charles.LeBlanc2@Canada.ca".Length);
            resetPasswordModel.Password = randomService.RandomPassword();
            resetPasswordModel.ConfirmPassword = resetPasswordModel.Password;
            resetPasswordModel.ExpireDate_Local = DateTime.UtcNow.AddDays(-10);

            Assert.IsTrue(resetPasswordModel.Code.Length == 8);
            Assert.IsTrue(resetPasswordModel.Email == "Charles.LeBlanc2@Canada.ca");
            Assert.IsTrue(resetPasswordModel.Password.Length > 8);
            Assert.IsTrue(resetPasswordModel.ConfirmPassword.Length > 8);
            Assert.AreEqual(resetPasswordModel.Password, resetPasswordModel.ConfirmPassword);
            Assert.IsTrue(resetPasswordModel.ExpireDate_Local != null);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            if (contactModelToDo == null)
            {
                user = null;
            }
            else
            {
                contactModel = contactModelToDo;
                user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            }
            resetPasswordService = new ResetPasswordService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            resetPasswordModelNew = new ResetPasswordModel();
            resetPassword = new ResetPassword();
        }
        private void SetupShim()
        {
            shimResetPasswordService = new ShimResetPasswordService(resetPasswordService);
        }
        #endregion Functions private
    }
}

