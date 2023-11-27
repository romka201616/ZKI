using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab4_Net;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        ForTest test = new ForTest();

        [TestMethod]
        public void TestMethod1()
        {
            test.CezarPhraze = "abcdefg";
            test.CezarKey = 1;
            string result = test.EncryptCezar();
            Assert.AreEqual(result, "bcdefgh");
        }


    }
}
