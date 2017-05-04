using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Tests.Helpers;
using App.Services.Encryption;

namespace App.Tests.Services
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void Can_hash_string()
        {
            var str = "Some string";
            var encrypted = registerClient.Get<ICryptoProvider>().CreateHash(str);

            Assert.AreNotEqual(encrypted, str);
        }

        [TestMethod]
        public void Dual_hashes_give_same_result()
        {
            var str = "Some string";
            var encrypted1 = registerClient.Get<ICryptoProvider>().CreateHash(str);

            var encrypted2 = registerClient.Get<ICryptoProvider>().CreateHash(encrypted1);

            Assert.AreEqual(encrypted1, encrypted2);
        }

        [TestMethod]
        public void Can_encrypt_string()
        {
            var str = "Some string";
            var encrypted = registerClient.Get<ICryptoProvider>().Encrypt(str, passPhrase);

            Assert.AreNotEqual(encrypted, str);
        }

        [TestMethod]
        public void Dual_encryption_give_same_result()
        {
            var str = "Some string";
            var encrypted1 = registerClient.Get<ICryptoProvider>().Encrypt(str, passPhrase);

            var encrypted2 = registerClient.Get<ICryptoProvider>().Encrypt(encrypted1, passPhrase);

            Assert.AreEqual(encrypted1, encrypted2);
        }

        [TestMethod]
        public void Can_dencrypt_string()
        {
            var str = "Some string";
            var encrypted1 = registerClient.Get<ICryptoProvider>().Encrypt(str, passPhrase);

            var decrypted = registerClient.Get<ICryptoProvider>().Decrypt(encrypted1, passPhrase);

            Assert.AreEqual(str, decrypted);
        }

        // ******************************
        //   helpers
        private static RegisterClient registerClient;
        private static string passPhrase = "asd&1223< _";

        [TestInitialize]
        public void Startup()
        {
            registerClient = new RegisterClient();
            App.Services.Register.RegisterTypes(registerClient);
            
        }
    }
}
