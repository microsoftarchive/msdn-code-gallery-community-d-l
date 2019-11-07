using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDevelopmentSample.Tests
{
    [TestClass]
    public class UnitTest1
    {
        // first write the tests, create & use the classes / methods on the go - use CTRL + . command to quickly create code stubs
        // next, write the code to make all test methods pass, possibly refactoring iteratively

        /// <summary>
        /// Tests MyMath.Add functionality
        /// </summary>
        [TestMethod]
        public void TestAdd()
        {
            // verify if add returns the expected value of 0
            Assert.AreEqual(0, MyMath.Add(10, -10));

            // verify if add returns the expected value of 1234567890
            Assert.AreEqual(1234567890, MyMath.Add(0, 1234567890));
        }
    }
}
