using App.Contracts;
using Moq;
using App.Contracts.Dals;
using App.Contracts.Services;
using App.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using App.Contracts.DataModels;
using System;

namespace App.Tests.Services.Validation
{
    [TestClass]
    public class AccountServiceTest
    {        
        [TestMethod]
        public void Can_Resolve_AccountService()
        {
            var service = registerClient.Get<IAccountService>();
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Valid_AccountDataModels_cause_no_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();

            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 0, errors.Count + " validation errors found when none expected");
        }

        [TestMethod]
        public void Valid_AccountDataModels_can_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();

            var result = service.TrySave(model, errors);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_returns_correct_AccountDataModel()
        {
            var model = GetValidDataModel(true);
            accountDal.Setup(x => x.Get(33, It.IsAny<IModelContext>())).Returns(model);

            var errors = new List<IModelError>();
            var result = registerClient.Get<IAccountService>().Get(33, errors);

            Assert.AreEqual(model, result);
        }

        [TestMethod]
        public void Get_no_DeliveryDataModels()
        {
            var model = GetValidDataModel(true);
            accountDal.Setup(x => x.Get(33, It.IsAny<IModelContext>())).Returns(model);

            var errors = new List<IModelError>();
            var result = registerClient.Get<IAccountService>().Get(44, errors);

            Assert.IsNull(result);
        }
        

        [TestMethod]
        public void Missing_Username_properites_on_new_UsernameDataModels_cause_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.Username = null; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_new_Username_properties_on_UsernameDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.Username = null; 
            var result = service.TrySave(model, errors);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Required_Username_properites_on_existing_UsernameDataModels_cause_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
            model.Username = null; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_existing_UsernameDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
                       
            model.Username = null;       
            var result = service.TrySave(model, errors);
            Assert.IsFalse(result);
        }
         

        [TestMethod]
        public void Missing_Password_properites_on_new_PasswordDataModels_cause_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.Password = String.Empty; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_new_Password_properties_on_PasswordDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.Password = String.Empty; 
            var result = service.TrySave(model, errors);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Required_Password_properites_on_existing_PasswordDataModels_cause_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
            model.Password = String.Empty; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_existing_PasswordDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
                       
            model.Password = String.Empty;       
            var result = service.TrySave(model, errors);
            Assert.IsFalse(result);
        }
         

        [TestMethod]
        public void Missing_AccountValidFrom_properites_on_new_AccountValidFromDataModels_cause_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.AccountValidFrom = DateTime.MinValue; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_new_AccountValidFrom_properties_on_AccountValidFromDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.AccountValidFrom = DateTime.MinValue; 
            var result = service.TrySave(model, errors);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Required_AccountValidFrom_properites_on_existing_AccountValidFromDataModels_cause_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
            model.AccountValidFrom = DateTime.MinValue; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_existing_AccountValidFromDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
                       
            model.AccountValidFrom = DateTime.MinValue;       
            var result = service.TrySave(model, errors);
            Assert.IsFalse(result);
        }
         

        [TestMethod]
        public void Missing_AccountValidTo_properites_on_new_AccountValidToDataModels_cause_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.AccountValidTo = DateTime.MinValue; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_new_AccountValidTo_properties_on_AccountValidToDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.AccountValidTo = DateTime.MinValue; 
            var result = service.TrySave(model, errors);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Required_AccountValidTo_properites_on_existing_AccountValidToDataModels_cause_errors()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
            model.AccountValidTo = DateTime.MinValue; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_existing_AccountValidToDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IAccountService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
                       
            model.AccountValidTo = DateTime.MinValue;       
            var result = service.TrySave(model, errors);
            Assert.IsFalse(result);
        }
         

        // ******************************
        //   helpers        
        private static IAccountDataModel GetValidDataModel(bool isNew)
        {
            var rtn = new Mock<IAccountDataModel>();
            rtn.SetupAllProperties();
            rtn.SetupGet(x => x.IsNew).Returns(isNew);
            rtn.Object.Username = "some string __ !!!  look ";             rtn.Object.Password = "some hashed string";             rtn.Object.LastLoggedIn = DateTime.Now;             rtn.Object.LoginAttempts = 42;             rtn.Object.IsLockedOut = true;             rtn.Object.AccountValidFrom = DateTime.Now;             rtn.Object.AccountValidTo = DateTime.Now;             rtn.Object.LoginStartAt = "12:01";             rtn.Object.LoginUntil = "12:01";             return rtn.Object;
        }  
        
        private static RegisterClient registerClient;
        private static Mock<IAccountDal> accountDal;
            private static Mock<IEntityChangeHandler<IAccountDataModel>> accountChangeHandler;    
        private static Mock<IRightDal> rightDal;
            private static Mock<IEntityChangeHandler<IRightDataModel>> rightChangeHandler;    
        private static Mock<IRoleDal> roleDal;
            private static Mock<IEntityChangeHandler<IRoleDataModel>> roleChangeHandler;    


    
        [TestInitialize]
        public void Startup()
        {
            registerClient = new RegisterClient();
            App.Services.Register.RegisterTypes(registerClient);

      
            accountDal = new Mock<IAccountDal>();
            registerClient.Register(typeof(IAccountDal), accountDal.Object);

            accountChangeHandler = new Mock<IEntityChangeHandler<IAccountDataModel >>();
            registerClient.Register(typeof(IEntityChangeHandler<IAccountDataModel>), accountChangeHandler.Object);
      
            rightDal = new Mock<IRightDal>();
            registerClient.Register(typeof(IRightDal), rightDal.Object);

            rightChangeHandler = new Mock<IEntityChangeHandler<IRightDataModel >>();
            registerClient.Register(typeof(IEntityChangeHandler<IRightDataModel>), rightChangeHandler.Object);
      
            roleDal = new Mock<IRoleDal>();
            registerClient.Register(typeof(IRoleDal), roleDal.Object);

            roleChangeHandler = new Mock<IEntityChangeHandler<IRoleDataModel >>();
            registerClient.Register(typeof(IEntityChangeHandler<IRoleDataModel>), roleChangeHandler.Object);
        }

    }
}