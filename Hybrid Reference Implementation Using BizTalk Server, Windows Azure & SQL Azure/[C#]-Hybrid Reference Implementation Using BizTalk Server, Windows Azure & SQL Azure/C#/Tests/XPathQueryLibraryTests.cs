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

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Contoso.Cloud.Integration.Framework.Configuration;
    using System.Diagnostics;
    #endregion

    /// <summary>
    /// Summary description for XPathQueryLibraryTests
    /// </summary>
    [TestClass]
    public class XPathQueryLibraryTests
    {
        public XPathQueryLibraryTests()
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ValidateXPathExpressions()
        {
            XPathQueryLibrary xPathLib = ApplicationConfiguration.Current.XPathQueries;

            Assert.IsNotNull(xPathLib.Queries, "Unable to load the XPathQueryLibrary configuration sections");
            Assert.IsTrue(xPathLib.Namespaces.Count > 0, "Namespaces are not found");
            Assert.IsTrue(xPathLib.Queries.Count > 0, "XPath expressions are not found");

            NamespaceInfo ns1 = xPathLib.Namespaces.Get("GComInternalSchemas");

            Assert.IsNotNull(ns1, "Namespace definition (GComInternalSchemas) is not found");
            Assert.IsFalse(String.IsNullOrEmpty(ns1.Name), "Namespace is missing its title");
            Assert.IsFalse(String.IsNullOrEmpty(ns1.Prefix), "Namespace is missing its prefix");

            XPathQueryInfo query1 = xPathLib.Queries.Get("InventoryReportRoot");
            XPathQueryInfo query2 = xPathLib.Queries.Get("InventoryHeader");
            XPathQueryInfo query3 = xPathLib.Queries.Get("InventoryReferenceNumber");

            Assert.IsFalse(String.IsNullOrEmpty(query1.XPath), "XPath expression (InventoryReportRoot) is empty");
            Assert.IsFalse(String.IsNullOrEmpty(query2.XPath), "XPath expression (InventoryHeader) is empty");
            Assert.IsFalse(String.IsNullOrEmpty(query3.XPath), "XPath expression (InventoryReferenceNumber) is empty");
            Assert.IsTrue(query1.XPath.Contains("ns0"), "XPath expression doesn't contain XML namespace prefix");
            Assert.IsTrue(query2.XPath.Contains("{$"), "XPath expression doesn't contain a macro");
            Assert.IsTrue(query3.XPath.Contains("{$"), "XPath expression doesn't contain a macro");

            string parsedQuery1 = xPathLib.GetXPathQuery(query1.Name);
            string parsedQuery2 = xPathLib.GetXPathQuery(query2.Name);
            string parsedQuery3 = xPathLib.GetXPathQuery(query3.Name);

            Assert.IsFalse(parsedQuery1.Contains("ns0"), "XPath expression must not contain XML namespace prefix");
            Assert.IsFalse(parsedQuery2.Contains("{$"), "XPath expression must not contain a macro");
            Assert.IsFalse(parsedQuery3.Contains("{$"), "XPath expression must not contain a macro");

            XPathQueryInfo lastNameQuery = xPathLib.Queries.Get("LastName");
            Trace.WriteLine(String.Format("Original lastNameQuery = {0}", lastNameQuery.XPath));

            string parsedLastNameQuery = xPathLib.GetXPathQuery("LastName");
            Trace.WriteLine(String.Format("Parsed lastNameQuery = {0}", parsedLastNameQuery));
        }
    }
}
