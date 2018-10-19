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
using Microsoft.QualityTools.Testing.Fakes;
using System.Threading;
using System.Globalization;
using CSSPEnumsDLL.Enums;
using CSSPModelsDLL.Models;

namespace CSSPWebToolsDBDLL.Tests.Services
{
    /// <summary>
    /// Summary description for AspNetUserServiceTest
    /// </summary>
    [TestClass]
    public class AspNetUserServiceTest : SetupData
    {
        #region Variables
        private TestContext testContextInstance;
        private SetupData setupData;
        private string TableName = "AspNetUser";
        private string Plurial = "s";
        #endregion Variables

        #region Properties
        private ContactModel contactModel { get; set; }
        private IPrincipal user { get; set; }
        private AspNetUserService aspNetUserService { get; set; }
        private TestDBService testDBService { get; set; }
        private RandomService randomService { get; set; }
        private AspNetUserModel aspNetUserModelNew { get; set; }
        private AspNetUser aspNetUser { get; set; }
        private ShimAspNetUserService shimAspNetUserService { get; set; }
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
        public AspNetUserServiceTest()
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

        #region Testing Methods Public
        [TestMethod]
        public void AspNetUserService_Constructor_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                // In Arrange
                Assert.IsNotNull(aspNetUserService);
                Assert.IsNotNull(aspNetUserService._UserManager);
                Assert.IsNotNull(aspNetUserService.db);
                Assert.IsNotNull(aspNetUserService.LanguageRequest);
                Assert.IsNotNull(aspNetUserService.User);
                Assert.AreEqual(user.Identity.Name, aspNetUserService.User.Identity.Name);
                Assert.AreEqual((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), aspNetUserService.LanguageRequest);
            }
        }
        [TestMethod]
        public void AspNetUserService_AspNetUserModelOK_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                RandomService randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
                AspNetUserModel aspNetUserModelNew = new AspNetUserModel();

                #region LoginEmail
                FillAspNetUserModelNew(aspNetUserModelNew);
                aspNetUserModelNew.LoginEmail = "";

                string retStr = aspNetUserService.AspNetUserModelOK(aspNetUserModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Email), retStr);

                FillAspNetUserModelNew(aspNetUserModelNew);
                aspNetUserModelNew.LoginEmail = randomService.RandomEmail().Replace("@", ".");

                retStr = aspNetUserService.AspNetUserModelOK(aspNetUserModelNew);
                Assert.AreEqual(string.Format(ServiceRes._EmailNotWellFormed, aspNetUserModelNew.LoginEmail), retStr);

                int Max = 255;
                FillAspNetUserModelNew(aspNetUserModelNew);
                aspNetUserModelNew.LoginEmail = (new String("a".ToCharArray()[0], Max)) + randomService.RandomEmail().Replace("@", ".");

                retStr = aspNetUserService.AspNetUserModelOK(aspNetUserModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Email, Max), retStr);
                #endregion LoginEmail Already Exist

                #region Password
                FillAspNetUserModelNew(aspNetUserModelNew);
                aspNetUserModelNew.Password = "";

                retStr = aspNetUserService.AspNetUserModelOK(aspNetUserModelNew);
                Assert.AreEqual(string.Format(ServiceRes._IsRequired, ServiceRes.Password), retStr);

                Max = 100;
                FillAspNetUserModelNew(aspNetUserModelNew);
                aspNetUserModelNew.Password = randomService.RandomString("", Max + 1);

                retStr = aspNetUserService.AspNetUserModelOK(aspNetUserModelNew);
                Assert.AreEqual(string.Format(ServiceRes._MaxLengthIs_, ServiceRes.Password, Max), retStr);
                #endregion Password
            }
        }
        [TestMethod]
        public void AspNetUserService_FillAspNetUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "GoodCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                    AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);

                    AspNetUser aspNetUser = new AspNetUser();

                    string retStr = aspNetUserService.FillAspNetUser(aspNetUser, aspNetUserModel);
                    Assert.AreEqual("", retStr);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_GetAspNetUserModelCount_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int aspNetUserCountBefore = aspNetUserService.GetAspNetUserModelCountDB();

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModelRet = AddAspNetUserModel();

                    int aspNetUserCountAfter = aspNetUserService.GetAspNetUserModelCountDB();
                    Assert.AreEqual(aspNetUserCountBefore + 1, aspNetUserCountAfter);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_GetAspNetUserModelDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                int aspNetUserCountBefore = aspNetUserService.GetAspNetUserModelCountDB();

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModelRet = AddAspNetUserModel();

                    int skip = 0;
                    int take = 10000000;
                    List<AspNetUserModel> aspNetUserModelList = aspNetUserService.GetAspNetUserModelDB(skip, take);
                    Assert.AreEqual(aspNetUserCountBefore + 1, aspNetUserModelList.Count);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_GetAspNetUserModelWithEmailDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModelRet = AddAspNetUserModel();

                    AspNetUserModel aspNetUserModelRet2 = aspNetUserService.GetAspNetUserModelWithEmailDB(aspNetUserModelRet.Email);
                    Assert.IsNotNull(aspNetUserModelRet2);
                    CompareAspNetUserModels(aspNetUserModelRet, aspNetUserModelRet2);

                    string Email = "Not@email.com";
                    AspNetUserModel aspNetUserModelRet3 = aspNetUserService.GetAspNetUserModelWithEmailDB(Email);
                    Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_With_Equal_, ServiceRes.AspNetUser, ServiceRes.Email, Email), aspNetUserModelRet3.Error);

                }
            }
        }
        [TestMethod]
        public void AspNetUserService_GetAspNetUserWithEmailDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModelRet = AddAspNetUserModel();

                    AspNetUser aspNetUserRet2 = aspNetUserService.GetAspNetUserWithEmailDB(aspNetUserModelRet.Email);
                    Assert.IsNotNull(aspNetUserRet2);
                    Assert.AreEqual(aspNetUserRet2.Email, aspNetUserModelRet.Email);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_GetAspNetUserWithIdDB_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModelRet = AddAspNetUserModel();

                    AspNetUser aspNetUserRet2 = aspNetUserService.GetAspNetUserWithIdDB(aspNetUserModelRet.Id);
                    Assert.IsNotNull(aspNetUserRet2);
                    Assert.AreEqual(aspNetUserRet2.Email, aspNetUserModelRet.Email);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_CreateUser_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "GoodCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                    AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);


                    string LoginEmail = "NewUser@ec.gc.ca";
                    //string Password = "Test2!Allo";
                    ApplicationUser2 applicationUser = new ApplicationUser2() { UserName = LoginEmail, Email = LoginEmail };

                    //// not implemented yet
                    //                    //IdentityResult result = aspNetUserService.CreateUser(applicationUser, Password);

                    //                    //Assert.AreEqual("", result.Succeeded);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_ReturnError_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                using (TransactionScope ts = new TransactionScope())
                {
                    string ErrorText = "ErrorText";
                    AspNetUserModel aspNetUserModelRet = aspNetUserService.ReturnError(ErrorText);
                    Assert.AreEqual(ErrorText, aspNetUserModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddFirstAspNetUserDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModel);
                        Assert.IsNotNull(aspNetUserModelRet);
                        Assert.AreEqual(aspNetUserModelRet.LoginEmail, aspNetUserModel.LoginEmail);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddFirstAspNetUserDB_GetAspNetUserModelCountDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 1;
                        };

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModel);
                        Assert.AreEqual(string.Format(ServiceRes.ToAddFirst_Requires_TableToBeEmpty, ServiceRes.AspNetUser), aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddFirstAspNetUserDB_AspNetUserModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimAspNetUserService.AspNetUserModelOKAspNetUserModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModel);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddFirstAspNetUserDB_GetAspNetUserWithEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimAspNetUserService.GetAspNetUserWithEmailDBString = (a) =>
                        {
                            return new AspNetUser();
                        };

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModel);
                        Assert.AreEqual(string.Format(ServiceRes.UserWithLoginEmail_AlreadyExist, aspNetUserModel.LoginEmail), aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddFirstAspNetUserDB_FillAspNetUser_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimAspNetUserService.FillAspNetUserAspNetUserAspNetUserModel = (a, b) =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModel);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddFirstAspNetUserDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimAspNetUserService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModel);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddFirstAspNetUserDB_AddFirstUser_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "CharlesFirstTest.LeBlanc@ec.gc.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserModelCountDB = () =>
                        {
                            return 0;
                        };
                        shimAspNetUserService.FillAspNetUserAspNetUserAspNetUserModel = (a, b) =>
                        {
                            return "";
                        };

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddFirstAspNetUserDB(aspNetUserModel);
                        Assert.IsTrue(aspNetUserModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddDeleteUpdateAspNetUserDB_Good_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "GoodCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                    Assert.IsNotNull(aspNetUserModelRet);
                    Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
                    Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
                    Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

                    string LoginEmail = "MoreGoodUpdateCharles.LeBlanc2@Canada.ca";
                    string Password = "CCharles2!";

                    ApplicationUser2 applicationUser = new ApplicationUser2() { UserName = LoginEmail };
                    try
                    {
                        IdentityResult result = aspNetUserService.CreateUser(applicationUser, Password);
                    }
                    catch (Exception)
                    {
                        //return new AspNetUserModel() { Error = ex.Message };
                    }
                    aspNetUserModelRet.Password = Password;
                    aspNetUserModelRet.LoginEmail = LoginEmail;
                    aspNetUserModelRet.Email = LoginEmail;
                    aspNetUserModelRet.EmailConfirmed = applicationUser.EmailConfirmed;
                    aspNetUserModelRet.PasswordHash = applicationUser.PasswordHash;
                    aspNetUserModelRet.SecurityStamp = applicationUser.SecurityStamp;
                    aspNetUserModelRet.PhoneNumber = applicationUser.PhoneNumber;
                    aspNetUserModelRet.PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed;
                    aspNetUserModelRet.TwoFactorEnabled = applicationUser.TwoFactorEnabled;
                    aspNetUserModelRet.LockoutEndDateUtc = applicationUser.LockoutEndDateUtc;
                    aspNetUserModelRet.LockoutEnabled = applicationUser.LockoutEnabled;
                    aspNetUserModelRet.AccessFailedCount = applicationUser.AccessFailedCount;
                    aspNetUserModelRet.UserName = LoginEmail;

                    AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostUpdateAspNetUserDB(aspNetUserModelRet);
                    Assert.IsNotNull(aspNetUserModelRet2);
                    Assert.AreEqual(aspNetUserModelRet.LoginEmail, aspNetUserModelRet2.LoginEmail);
                    Assert.AreEqual(aspNetUserModelRet.LoginEmail, aspNetUserModelRet2.UserName);
                    Assert.AreEqual(aspNetUserModelRet.LoginEmail, aspNetUserModelRet2.Email);

                    AspNetUserModel aspNetUserModelRet3 = aspNetUserService.PostDeleteAspNetUserWithIdDB(aspNetUserModelRet2.Id);
                    Assert.AreEqual("", aspNetUserModelRet3.Error);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddAspNetUserDB_Error_AlreadyExist_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "Charles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                    Assert.AreEqual(string.Format(ServiceRes.UserWithLoginEmail_AlreadyExist, aspNetUserModel.LoginEmail), aspNetUserModelRet.Error);
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddAspNetUserDB_AspNetUserModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "Charles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        string ErrorText = "ErrorText";
                        ShimAspNetUserService shimAspNetUserService = new ShimAspNetUserService(aspNetUserService);
                        shimAspNetUserService.AspNetUserModelOKAspNetUserModel = (a) =>
                        {
                            return ErrorText;
                        };
                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddAspNetUserDB_GetAspNetUserWithEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserWithEmailDBString = (a) =>
                        {
                            return new AspNetUser();
                        };
                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.AreEqual(string.Format(ServiceRes.UserWithLoginEmail_AlreadyExist, aspNetUserModel.LoginEmail), aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddAspNetUserDB_IsContactOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAspNetUserService.IsContactOK = () =>
                        {
                            return new ContactOK() { Error = ErrorText };
                        };
                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddAspNetUserDB_FillAspNetUserModel_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAspNetUserService.FillAspNetUserAspNetUserAspNetUserModel = (a, b) =>
                        {
                            return ErrorText;
                        };
                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddAspNetUserDB_DoAddChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        string ErrorText = "ErrorText";
                        shimAspNetUserService.DoAddChanges = () =>
                        {
                            return ErrorText;
                        };
                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostAddAspNetUserDB_AddUser_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();
                        //string ErrorText = "ErrorText";
                        shimAspNetUserService.FillAspNetUserAspNetUserAspNetUserModel = (a, b) =>
                        {
                            return "";
                        };
                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.IsTrue(aspNetUserModelRet.Error.StartsWith(string.Format(ServiceRes.CouldNotAddError_, "").Substring(0, 10)));
                    }
                }
            }
        }
        //[TestMethod]
        //public void AspNetUserService_PostDeleteAspNetUserWithIdDB_IsContactOK_Error_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            using (ShimsContext.Create())
        //            {
        //                SetupShim();

        //                AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
        //                Assert.IsNotNull(aspNetUserModelRet);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

        //                string ErrorText = "ErrorText";
        //                shimAspNetUserService.IsContactOK = () =>
        //                {
        //                    return new ContactOK() { Error = ErrorText };
        //                };

        //                AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostDeleteAspNetUserWithIdDB(aspNetUserModelRet.Id);
        //                Assert.AreEqual(ErrorText, aspNetUserModelRet2.Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void AspNetUserService_PostDeleteAspNetUserWithIdDB_GetAspNetUserWithEmailDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.IsNotNull(aspNetUserModelRet);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

                        //string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserWithIdDBString = (a) =>
                        {
                            return null;
                        };

                        AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostDeleteAspNetUserWithIdDB(aspNetUserModelRet.Id);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AspNetUser), aspNetUserModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostDeleteAspNetUserWithIdDB_DoDeleteChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.IsNotNull(aspNetUserModelRet);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

                        string ErrorText = "ErrorText";
                        shimAspNetUserService.DoDeleteChanges = () =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostDeleteAspNetUserWithIdDB(aspNetUserModelRet.Id);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostDeleteAspNetUserWithIdDB_Delete_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.IsNotNull(aspNetUserModelRet);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

                        //string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserWithIdDBString = (a) =>
                        {
                            return null;
                        };

                        AspNetUserModel aspNetUserModelRe2 = aspNetUserService.PostDeleteAspNetUserWithIdDB(aspNetUserModelRet.Id);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToDelete, ServiceRes.AspNetUser), aspNetUserModelRe2.Error);
                    }
                }
            }
        }
        //[TestMethod]
        //public void AspNetUserService_PostDeleteAspNetUserWithIdDB_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            using (ShimsContext.Create())
        //            {
        //                SetupShim();

        //                AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
        //                Assert.IsNotNull(aspNetUserModelRet);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

        //                string ErrorText = "ErrorText";
        //                shimAspNetUserService.IsContactOK = () =>
        //                {
        //                    return new ContactOK() { Error = ErrorText };
        //                };

        //                AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostDeleteAspNetUserWithIdDB(aspNetUserModelRet.Id);
        //                Assert.AreEqual(ErrorText, aspNetUserModelRet2.Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void AspNetUserService_PostUpdateAspNetUserDB_AspNetUserModelOK_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.IsNotNull(aspNetUserModelRet);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

                        string ErrorText = "ErrorText";
                        shimAspNetUserService.AspNetUserModelOKAspNetUserModel = (a) =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostUpdateAspNetUserDB(aspNetUserModelRet);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet2.Error);
                    }
                }
            }
        }
        //[TestMethod]
        //public void AspNetUserService_PostUpdateAspNetUserDB_IsContactOK_Error_Test()
        //{
        //    foreach (CultureInfo culture in setupData.cultureListGood)
        //    {
        //        SetupTest(contactModelListGood[0], culture);

        //        AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            using (ShimsContext.Create())
        //            {
        //                SetupShim();

        //                AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
        //                Assert.IsNotNull(aspNetUserModelRet);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
        //                Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

        //                string ErrorText = "ErrorText";
        //                shimAspNetUserService.IsContactOK = () =>
        //                {
        //                    return new ContactOK() { Error = ErrorText };
        //                };

        //                AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostUpdateAspNetUserDB(aspNetUserModel);
        //                Assert.AreEqual(ErrorText, aspNetUserModelRet2.Error);
        //            }
        //        }
        //    }
        //}
        [TestMethod]
        public void AspNetUserService_PostUpdateAspNetUserDB_GetAspNetUserWithIdDB_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.IsNotNull(aspNetUserModelRet);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

                        //string ErrorText = "ErrorText";
                        shimAspNetUserService.GetAspNetUserWithIdDBString = (a) =>
                        {
                            return null;
                        };

                        AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostUpdateAspNetUserDB(aspNetUserModel);
                        Assert.AreEqual(string.Format(ServiceRes.CouldNotFind_ToUpdate, ServiceRes.AspNetUser), aspNetUserModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostUpdateAspNetUserDB_FillAspNetUser_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.IsNotNull(aspNetUserModelRet);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

                        string ErrorText = "ErrorText";
                        shimAspNetUserService.FillAspNetUserAspNetUserAspNetUserModel = (a, b) =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostUpdateAspNetUserDB(aspNetUserModel);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet2.Error);
                    }
                }
            }
        }
        [TestMethod]
        public void AspNetUserService_PostUpdateAspNetUserDB_DoUpdateChanges_Error_Test()
        {
            foreach (CultureInfo culture in setupData.cultureListGood)
            {
                SetupTest(contactModelListGood[0], culture);

                AspNetUserModel aspNetUserModel = new AspNetUserModel() { LoginEmail = "AnotherCharles.LeBlanc2@Canada.ca", Password = "Charles2!" };

                using (TransactionScope ts = new TransactionScope())
                {
                    using (ShimsContext.Create())
                    {
                        SetupShim();

                        AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModel, true);
                        Assert.IsNotNull(aspNetUserModelRet);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.LoginEmail);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.UserName);
                        Assert.AreEqual(aspNetUserModel.LoginEmail, aspNetUserModelRet.Email);

                        string ErrorText = "ErrorText";
                        shimAspNetUserService.DoUpdateChanges = () =>
                        {
                            return ErrorText;
                        };

                        AspNetUserModel aspNetUserModelRet2 = aspNetUserService.PostUpdateAspNetUserDB(aspNetUserModel);
                        Assert.AreEqual(ErrorText, aspNetUserModelRet2.Error);
                    }
                }
            }
        }
        #endregion Testing Methods Public

        #region Testing Methods Private
        #endregion Testing Methods Private

        #region Functions private
        public AspNetUserModel AddAspNetUserModel()
        {
            FillAspNetUserModelNew(aspNetUserModelNew);

            AspNetUserModel aspNetUserModelRet = aspNetUserService.PostAddAspNetUserDB(aspNetUserModelNew, true);
            if (!string.IsNullOrWhiteSpace(aspNetUserModelRet.Error))
            {
                return aspNetUserModelRet;
            }

            Assert.IsNotNull(aspNetUserModelRet);
            CompareAspNetUserModels(aspNetUserModelNew, aspNetUserModelRet);

            return aspNetUserModelRet;
        }
        public void FillAspNetUserModelNew(AspNetUserModel aspNetUserModel)
        {
            string LoginEmail = randomService.RandomEmail();
            string Password = randomService.RandomPassword();

            ApplicationUser2 applicationUser = new ApplicationUser2() { UserName = LoginEmail };

            UserManager<ApplicationUser2> userManager = new UserManager<ApplicationUser2>(new UserStore<ApplicationUser2>(new IdentityDbContext("CSSPWebToolsDBEntities")));

            try
            {
                IdentityResult result = userManager.Create(applicationUser, Password);
            }
            catch (Exception)
            {
                // nothing for now
            }

            aspNetUserModel.Id = applicationUser.Id;
            aspNetUserModel.Email = LoginEmail;
            aspNetUserModel.EmailConfirmed = applicationUser.EmailConfirmed;
            aspNetUserModel.PasswordHash = applicationUser.PasswordHash;
            aspNetUserModel.SecurityStamp = applicationUser.SecurityStamp;
            aspNetUserModel.PhoneNumber = applicationUser.PhoneNumber;
            aspNetUserModel.PhoneNumberConfirmed = applicationUser.PhoneNumberConfirmed;
            aspNetUserModel.TwoFactorEnabled = applicationUser.TwoFactorEnabled;
            aspNetUserModel.LockoutEndDateUtc = applicationUser.LockoutEndDateUtc;
            aspNetUserModel.LockoutEnabled = applicationUser.LockoutEnabled;
            aspNetUserModel.AccessFailedCount = applicationUser.AccessFailedCount;
            aspNetUserModel.UserName = LoginEmail;
            aspNetUserModel.LoginEmail = LoginEmail;
            aspNetUserModel.Password = Password;

            Assert.IsFalse(string.IsNullOrWhiteSpace(LoginEmail));
            Assert.IsFalse(string.IsNullOrWhiteSpace(Password));
            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.Id));
            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.Email));
            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.PasswordHash));
            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.SecurityStamp));
            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.UserName));
            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.LoginEmail));
            Assert.IsFalse(string.IsNullOrWhiteSpace(aspNetUserModel.Password));
            Assert.AreEqual(LoginEmail, aspNetUserModel.LoginEmail);
            Assert.AreEqual(Password, aspNetUserModel.Password);
        }
        public void CompareAspNetUserModels(AspNetUserModel aspNetUserModelNew, AspNetUserModel aspNetUserModelRet)
        {
            Assert.AreEqual(aspNetUserModelNew.Email, aspNetUserModelRet.Email);
            Assert.AreEqual(aspNetUserModelNew.EmailConfirmed, aspNetUserModelRet.EmailConfirmed);
            Assert.AreEqual(aspNetUserModelNew.PhoneNumber, aspNetUserModelRet.PhoneNumber);
            Assert.AreEqual(aspNetUserModelNew.PhoneNumberConfirmed, aspNetUserModelRet.PhoneNumberConfirmed);
            Assert.AreEqual(aspNetUserModelNew.TwoFactorEnabled, aspNetUserModelRet.TwoFactorEnabled);
            Assert.AreEqual(aspNetUserModelNew.LockoutEndDateUtc, aspNetUserModelRet.LockoutEndDateUtc);
            Assert.AreEqual(aspNetUserModelNew.LockoutEnabled, aspNetUserModelRet.LockoutEnabled);
            Assert.AreEqual(aspNetUserModelNew.AccessFailedCount, aspNetUserModelRet.AccessFailedCount);
            Assert.AreEqual(aspNetUserModelNew.UserName, aspNetUserModelRet.UserName);
        }
        public void SetupTest(ContactModel contactModelToDo, CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            contactModel = contactModelToDo;
            if (contactModelToDo == null)
            {
                user = null;
            }
            else
            {
                user = new GenericPrincipal(new GenericIdentity(contactModel.LoginEmail, "Forms"), null);
            }
            aspNetUserService = new AspNetUserService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            testDBService = new TestDBService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user, TableName, Plurial);
            randomService = new RandomService((culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en), user);
            aspNetUserModelNew = new AspNetUserModel();
            aspNetUser = new AspNetUser();
        }
        private void SetupShim()
        {
            shimAspNetUserService = new ShimAspNetUserService(aspNetUserService);
        }
        #endregion Functions private
    }
}

