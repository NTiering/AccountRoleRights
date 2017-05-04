namespace App.Tests.Services
{
    using App.Services.Interfaces;
    using Contracts;
    using Contracts.DataModels;
    using Contracts.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System;

	[TestClass]
    public class RegisterTests
    {
        static Mock<IRegisterClient> client;

        [ClassInitialize]
        public static void Init(TestContext tc)
        {
            client = new Mock<IRegisterClient>();
            App.Services.Register.RegisterTypes(client.Object);
        }

        [TestMethod]
        public void Startup_Service_Is_Registered()
        {
            var typeExpected = typeof(IStartupService);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }

		[TestMethod]
        public void Account_Service_Is_Registered()
        {
            var typeExpected = typeof(IAccountService);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }
		
		[TestMethod]
        public void Role_Service_Is_Registered()
        {
            var typeExpected = typeof(IRoleService);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }
		
		[TestMethod]
        public void Right_Service_Is_Registered()
        {
            var typeExpected = typeof(IRightService);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }
		        

		[TestMethod]
        public void Account_Validator_Is_Registered()
        {
            var typeExpected = typeof(IValidator<IAccountDataModel>);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }
		
		[TestMethod]
        public void Role_Validator_Is_Registered()
        {
            var typeExpected = typeof(IValidator<IRoleDataModel>);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }
		
		[TestMethod]
        public void Right_Validator_Is_Registered()
        {
            var typeExpected = typeof(IValidator<IRightDataModel>);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }
				

        // ****************************** //
        // helpers                        //
        private static string GetErrorMessage(Type t)
        {
            var errorMsg = "No type registered for " + t.Name + " found in App.Services.Register.RegisterTypes method";
            return errorMsg;

        }

    }
}