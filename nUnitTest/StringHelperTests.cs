using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinhHelper;
using System;

namespace nUnitTest
{
    [TestClass]
    public class StringHelperTests
    {
        [TestMethod]
        public void RemoveRedundantWhitespaces_Test()
        {
            //Assign
            string test = "Tran  Khoa               Minh";

            //Act
            var afterRemove = test.RemoveRedundantWhitespaces();

            //Assert
            Assert.AreEqual("Tran Khoa Minh", afterRemove);
        }
    }
}
