//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The test library contains a set of general unit tests.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
namespace Contoso.Cloud.Integration.Tests
{
    #region Using statements
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Configuration;
    using System.Collections.Specialized;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
    using Microsoft.Practices.EnterpriseLibrary.Data;

    using Contoso.Cloud.Integration.Framework;
    using Contoso.Cloud.Integration.Framework.Data;
    using System.Data.Common;
    #endregion

    /// <summary>
    /// Summary description for RetryPolicyTests
    /// </summary>
    [TestClass]
    public class SqlAzureRetryPolicyTests
    {
        public SqlAzureRetryPolicyTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestNoRetryPolicy()
        {
            RetryPolicy noRetryPolicy = RetryPolicy.NoRetry;
            int execCount = 0;

            try
            {
                noRetryPolicy.ExecuteAction(() =>
                {
                    execCount++;
                    throw new ApplicationException("Forced Exception");
                });
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            Assert.AreEqual<int>(1, execCount, "The action was not executed the expected amount of times");
        }

        [TestMethod]
        public void TestDefaultRetryPolicyWithNonRetryableError()
        {
            RetryPolicy defaultPolicy = RetryPolicyFactory.GetDefaultSqlConnectionRetryPolicy();
            int execCount = 0;

            try
            {
                defaultPolicy.ExecuteAction(() =>
                {
                    execCount++;
                    throw new ApplicationException("Forced Exception");
                });
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            Assert.AreEqual<int>(1, execCount, "The action was not executed the expected amount of times");
        }

        [TestMethod]
        public void TestDefaultRetryPolicyWithRetryableError()
        {
            RetryPolicy defaultPolicy = RetryPolicyFactory.GetDefaultSqlConnectionRetryPolicy();
            int execCount = 0;

            try
            {
                defaultPolicy.ExecuteAction(() =>
                {
                    execCount++;

                    throw new TimeoutException("Forced Exception");
                });
            }
            catch (TimeoutException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            Assert.AreEqual<int>(RetryPolicy.DefaultClientRetryCount, execCount - 1, "The action was not retried using the expected amount of times");
        }

        [TestMethod]
        public void TestBackoffRetryPolicyWithRetryableError()
        {
            RetryPolicy retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, RetryPolicy.DefaultMinBackoff, RetryPolicy.DefaultMaxBackoff, RetryPolicy.DefaultClientBackoff);
            int execCount = 0;

            try
            {
                retryPolicy.ExecuteAction(() =>
                {
                    execCount++;

                    throw new TimeoutException("Forced Exception");
                });
            }
            catch (TimeoutException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            Assert.AreEqual<int>(RetryPolicy.DefaultClientRetryCount, execCount - 1, "The action was not retried using the expected amount of times");
        }

        [TestMethod]
        public void TestProgressiveIncrementRetryPolicyWithRetryableError()
        {
            TimeSpan initialInterval = RetryPolicy.DefaultRetryInterval;
            TimeSpan increment = RetryPolicy.DefaultRetryInterval;
            RetryPolicy retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount, initialInterval, increment);

            int execCount = 0;
            TimeSpan totalDelay;
            Stopwatch stopwatch = Stopwatch.StartNew();

            TestRetryPolicy(retryPolicy, out execCount, out totalDelay);

            stopwatch.Stop();

            Assert.AreEqual<int>(RetryPolicy.DefaultClientRetryCount, execCount, "The action was not retried using the expected amount of times");
            Assert.IsTrue(stopwatch.ElapsedMilliseconds >= totalDelay.TotalMilliseconds, "Unexpected duration of retry block");
        }

        [TestMethod]
        public void TestRetryCallback()
        {
            RetryPolicy retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(RetryPolicy.DefaultClientRetryCount);
            int callbackCount = 0;

            retryPolicy.RetryOccurred += (currentRetryCount, lastException, delay) =>
            {
                callbackCount++;

                Trace.WriteLine(String.Format("Current Retry Count: {0}", currentRetryCount));
                Trace.WriteLine(String.Format("Last Exception: {0}", lastException.Message));
                Trace.WriteLine(String.Format("Delay (ms): {0}", delay.TotalMilliseconds));
            };

            try
            {
                retryPolicy.ExecuteAction(() =>
                {
                    throw new TimeoutException("Forced Exception");
                });
            }
            catch (TimeoutException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            Assert.AreEqual<int>(RetryPolicy.DefaultClientRetryCount, callbackCount, "The callback has not been made using the expected amount of times");

        }

        [TestMethod]
        public void TestRetryPolicyUsagePatterns()
        {
            // Initialize a retry policy using static configuration settings embedded into the code.
            RetryPolicy retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(10, TimeSpan.FromMilliseconds(500));

            // Initialize a retry policy using application configuration settings (recommended).
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            RetryPolicy configurablePolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(Convert.ToInt32(appSettings["RetryCount"]),
                TimeSpan.FromMilliseconds(Convert.ToDouble(appSettings["InitialInterval"])),
                TimeSpan.FromMilliseconds(Convert.ToDouble(appSettings["IncrementValue"])));

            // Initialize a SqlAzureConnection instance using the retry policy settings stored in the
            // SQL connection string which is read from the application configuration file.
            string connString = ConfigurationManager.ConnectionStrings["SQLAzureTest"].ConnectionString;
            using (ReliableSqlConnection azureConnection = new ReliableSqlConnection(connString))
            {
                // At this point, the connection object is retry policy-aware.
                // Both azureConnection.ConnectionRetryPolicy and azureConnection.CommandRetryPolicy
                // have been initialized with the retry policy settings from the connection string.
                // ...
            }
        }

        [TestMethod]
        public void TestRetryStrategyInExtensionMethods()
        {
            int maxRetryCount = 5;
            RetryPolicy retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(maxRetryCount, TimeSpan.FromMilliseconds(500));
            int callbackCount = 0;

            retryPolicy.RetryOccurred += (currentRetryCount, lastException, delay) =>
            {
                callbackCount++;

                Trace.WriteLine(String.Format("Current Retry Count: {0}", currentRetryCount));
                Trace.WriteLine(String.Format("Last Exception: {0}", lastException.Message));
                Trace.WriteLine(String.Format("Delay (ms): {0}", delay.TotalMilliseconds));
            };

            try
            {
                // Action #1
                retryPolicy.ExecuteAction(() =>
                {
                    SimulateFailure(retryPolicy);
                });
            }
            catch (TimeoutException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            // NO LONGER VALID STRATEGY (initial implementation)
            // We expect to call the SimulateFailure method (maxRetryCount + 1) number of times (first pass + maxRetryCount attempts).
            // Each time we call SimulateFailure, we are going to retry for maxRetryCount times. The callback method is shared, hence it will be invoked
            // whenever we retry inside SimulateFailure as well as outside. The outer retry will impose extra hits on the callback method.
            // Therefore we should account for these extra calls and add further maxRetryCount number of attempts. Hence, the formula below.
            // int expectedRetryCount = (maxRetryCount + 1) * maxRetryCount + maxRetryCount;

            int expectedRetryCount = maxRetryCount;

            Assert.AreEqual<int>(expectedRetryCount, callbackCount, "The action was not retried using the expected amount of times");
        }

        [TestMethod]
        public void TestFastFirstRetry()
        {
            RetryPolicy retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(1, TimeSpan.FromMinutes(10));
            retryPolicy.FastFirstRetry = true;

            Stopwatch stopwatch = Stopwatch.StartNew();
            
            try
            {
                retryPolicy.ExecuteAction(() =>
                {
                    SimulateFailure(retryPolicy);
                });
            }
            catch (TimeoutException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            stopwatch.Stop();
            Assert.IsFalse(stopwatch.Elapsed.TotalSeconds > 5, "FastFirstRetry does not seem to work correctly");

            retryPolicy = new RetryPolicy<SqlAzureTransientErrorDetectionStrategy>(2, TimeSpan.FromSeconds(1));
            stopwatch.Start();

            try
            {
                retryPolicy.ExecuteAction(() =>
                {
                    SimulateFailure(retryPolicy);
                });
            }
            catch (TimeoutException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            stopwatch.Stop();
            Assert.IsTrue(stopwatch.Elapsed.TotalSeconds >= 1 && stopwatch.Elapsed.TotalSeconds < 2, "FastFirstRetry does not seem to work correctly");
        }

        #region Private methods
        internal static void TestRetryPolicy(RetryPolicy retryPolicy, out int retryCount, out TimeSpan totalDelay)
        {
            int callbackCount = 0;
            double totalDelayInMs = 0;

            retryPolicy.RetryOccurred += (currentRetryCount, lastException, delay) =>
            {
                callbackCount++;
                totalDelayInMs += delay.TotalMilliseconds;
            };

            try
            {
                retryPolicy.ExecuteAction(() =>
                {
                    throw new TimeoutException("Forced Exception");
                });
            }
            catch (TimeoutException ex)
            {
                Assert.AreEqual("Forced Exception", ex.Message);
            }

            retryCount = callbackCount;
            totalDelay = TimeSpan.FromMilliseconds(totalDelayInMs);
        }

        private static void SimulateFailure(RetryPolicy retryPolicy)
        {
            try
            {
                // Action #2
                retryPolicy.ExecuteAction(() =>
                {
                    throw new TimeoutException("Forced Exception");
                });
            }
            catch (Exception ex)
            {
                // By now, we exhausted all retry attempts when establishing a connection. This means we should also
                // stop retrying the SQL command. Should we not do that, we will continue retrying substantially 
                // increasing the command execution time. The strategy here is that we wrap the transient error into an 
                // RetryLimitExceededException and re-throw. This will ensure that the command will not be retried.
                throw new RetryLimitExceededException(ex);
            }
        }
        #endregion
    }
}
