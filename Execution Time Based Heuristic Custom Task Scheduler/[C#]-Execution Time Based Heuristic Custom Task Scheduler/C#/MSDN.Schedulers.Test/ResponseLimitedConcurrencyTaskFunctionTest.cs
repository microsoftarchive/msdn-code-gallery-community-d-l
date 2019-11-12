using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MSDN.Schedulers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSDN.Schedulers.Test
{
    [TestClass]
    public class ResponseLimitedConcurrencyTaskFunctionTest
    {
        [TestMethod]
        public void StepDecreaseTest()
        {
            var config = new List<ResponseLimitedConcurrencyStepDefinition>();
            config.Add(new ResponseLimitedConcurrencyStepDefinition(5, 500));
            config.Add(new ResponseLimitedConcurrencyStepDefinition(3, 5000));
            config.Add(new ResponseLimitedConcurrencyStepDefinition(2, Int32.MaxValue));

            Func<int, int> funcMdop = ResponseLimitedConcurrencyFunctionFactory.StepDecrement(config);

            Assert.AreEqual<int>(5, funcMdop(0), "Default should return 5");
            Assert.AreEqual<int>(5, funcMdop(500), "500ms should return 5");
            Assert.AreEqual<int>(3, funcMdop(501), "501ms should return 3");
            Assert.AreEqual<int>(3, funcMdop(4900), "4900ms should return 3");
            Assert.AreEqual<int>(3, funcMdop(5000), "5000ms should return 3");
            Assert.AreEqual<int>(2, funcMdop(5001), "5001ms should return 2");
        }

        [TestMethod]
        public void StepIncreaseTest()
        {
            var config = new List<ResponseLimitedConcurrencyStepDefinition>();
            config.Add(new ResponseLimitedConcurrencyStepDefinition(2, 500));
            config.Add(new ResponseLimitedConcurrencyStepDefinition(3, 5000));
            config.Add(new ResponseLimitedConcurrencyStepDefinition(5, Int32.MaxValue));

            Func<int, int> funcMdop = ResponseLimitedConcurrencyFunctionFactory.StepIncrement(config);

            Assert.AreEqual<int>(2, funcMdop(0), "Default should return 5");
            Assert.AreEqual<int>(2, funcMdop(500), "500ms should return 2");
            Assert.AreEqual<int>(3, funcMdop(501), "501ms should return 3");
            Assert.AreEqual<int>(3, funcMdop(4900), "4900ms should return 3");
            Assert.AreEqual<int>(3, funcMdop(5000), "5000ms should return 3");
            Assert.AreEqual<int>(5, funcMdop(5001), "5000ms should return 5");
        }

        [TestMethod]
        public void LinearDownTest()
        {
            Func<int, int> funcMdop = ResponseLimitedConcurrencyFunctionFactory.LinearDecreasing(5, 1, 2);

            Assert.AreEqual<int>(5, funcMdop(0), "Default should return 5");
            Assert.AreEqual<int>(5, funcMdop(900), "At under 1 second should return 5");
            Assert.AreEqual<int>(4, funcMdop(1000), "At 1 second should return 4");
            Assert.AreEqual<int>(4, funcMdop(1500), "At 1.5 seconds should return 4");
            Assert.AreEqual<int>(3, funcMdop(2000), "At 2 seconds should return 3");
            Assert.AreEqual<int>(2, funcMdop(3000), "At 3 seconds should return 2");
            Assert.AreEqual<int>(2, funcMdop(4000), "At 4 seconds should return 2");
        }

        [TestMethod]
        public void LinearUpTest()
        {
            Func<int, int> funcMdop = ResponseLimitedConcurrencyFunctionFactory.LinearIncreasing(2, 1, 5);

            Assert.AreEqual<int>(2, funcMdop(0), "Default should return 2");
            Assert.AreEqual<int>(2, funcMdop(900), "At under 1 second should return 2");
            Assert.AreEqual<int>(3, funcMdop(1000), "At 1 second should return 3");
            Assert.AreEqual<int>(3, funcMdop(1500), "At 1.5 seconds should return 3");
            Assert.AreEqual<int>(4, funcMdop(2000), "At 2 seconds should return 4");
            Assert.AreEqual<int>(5, funcMdop(3000), "At 3 seconds should return 5");
            Assert.AreEqual<int>(5, funcMdop(4000), "At 4 seconds should return 5");
        }
    }
}
