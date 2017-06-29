namespace App.Dals.Services
{
    using Contracts;
    using Contracts.Dals;
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
            App.Dal.Register.RegisterTypes(client.Object);
        }
                

        [TestMethod]
        public void AccountDal_Is_Registered()
        {
            var typeExpected = typeof(IAccountDal);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }
        
        [TestMethod]
        public void RightDal_Is_Registered()
        {
            var typeExpected = typeof(IRightDal);

            client.Verify(x => x.Register(typeExpected, It.IsAny<Type>(), ""),
                Times.Once, GetErrorMessage(typeExpected));
        }
        
        [TestMethod]
        public void RoleDal_Is_Registered()
        {
            var typeExpected = typeof(IRoleDal);

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