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
    public class RightServiceTest
    {        
        [TestMethod]
        public void Can_Resolve_RightService()
        {
            var service = registerClient.Get<IRightService>();
            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Valid_RightDataModels_cause_no_errors()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();

            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 0, errors.Count + " validation errors found when none expected");
        }

        [TestMethod]
        public void Valid_RightDataModels_can_be_saved()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();

            var result = service.TrySave(model, errors);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Get_returns_correct_RightDataModel()
        {
            var model = GetValidDataModel(true);
            rightDal.Setup(x => x.Get(33, It.IsAny<IModelContext>())).Returns(model);

            var errors = new List<IModelError>();
            var result = registerClient.Get<IRightService>().Get(33, errors);

            Assert.AreEqual(model, result);
        }

        [TestMethod]
        public void Get_no_DeliveryDataModels()
        {
            var model = GetValidDataModel(true);
            rightDal.Setup(x => x.Get(33, It.IsAny<IModelContext>())).Returns(model);

            var errors = new List<IModelError>();
            var result = registerClient.Get<IRightService>().Get(44, errors);

            Assert.IsNull(result);
        }
        

        [TestMethod]
        public void Missing_Name_properites_on_new_NameDataModels_cause_errors()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.Name = null; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_new_Name_properties_on_NameDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.Name = null; 
            var result = service.TrySave(model, errors);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Required_Name_properites_on_existing_NameDataModels_cause_errors()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
            model.Name = null; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_existing_NameDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
                       
            model.Name = null;       
            var result = service.TrySave(model, errors);
            Assert.IsFalse(result);
        }
         

        [TestMethod]
        public void Missing_Key_properites_on_new_KeyDataModels_cause_errors()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.Key = null; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_new_Key_properties_on_KeyDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(true);
            var errors = new List<IModelError>();
            model.Key = null; 
            var result = service.TrySave(model, errors);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Required_Key_properites_on_existing_KeyDataModels_cause_errors()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
            model.Key = null; 
            service.TrySave(model, errors);

            Assert.IsTrue(errors.Count == 1, errors.Count + " validation errors found when one (1) expected");
        }

        [TestMethod]
        public void Required_existing_KeyDataModels_cannot_be_saved()
        {
            var service = registerClient.Get<IRightService>();
            var model = GetValidDataModel(false);
            var errors = new List<IModelError>();
                       
            model.Key = null;       
            var result = service.TrySave(model, errors);
            Assert.IsFalse(result);
        }
         

        // ******************************
        //   helpers        
        private static IRightDataModel GetValidDataModel(bool isNew)
        {
            var rtn = new Mock<IRightDataModel>();
            rtn.SetupAllProperties();
            rtn.SetupGet(x => x.IsNew).Returns(isNew);
            rtn.Object.Name = "some string __ !!!  look ";             rtn.Object.Key = "some string __ !!!  look ";             rtn.Object.IsAssignable = true;             return rtn.Object;
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