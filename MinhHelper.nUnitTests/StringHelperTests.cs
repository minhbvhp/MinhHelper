using MinhHelper;
using NUnit.Framework;

namespace Tests
{
    public class StringHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
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