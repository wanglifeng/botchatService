using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainCore;

namespace DomainCoreTest
{
    [TestClass]
    public class SHA1AlgorithmTest
    {
        [TestMethod,Ignore]
        public void EnctyptTest()
        {
            String str = "CareerBuilderChinaddee";
            Assert.AreEqual("1ee1b616d29f90b331960728734c24cdc8033755", SHA1Algorithm.Enctypt(str));
        }
    }
}
