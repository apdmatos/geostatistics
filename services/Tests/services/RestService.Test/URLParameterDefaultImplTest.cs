﻿using RestService.parameters_parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ProviderDataContracts.Filters;
using System.Collections.Generic;

namespace RestService.Test
{
    
    
    /// <summary>
    ///This is a test class for URLParameterDefaultImplTest and is intended
    ///to contain all URLParameterDefaultImplTest Unit Tests
    ///</summary>
    [TestClass()]
    public class URLParameterDefaultImplTest
    {


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
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for URLParameterDefaultImpl Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        [UrlToTest("http://localhost:36590/")]
        public void URLParameterDefaultImplConstructorTest()
        {
            URLParameterDefaultImpl target = new URLParameterDefaultImpl();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for ParseDimensionFilter
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        [UrlToTest("http://localhost:36590/")]
        public void ParseDimensionFilterTest()
        {
            URLParameterDefaultImpl target = new URLParameterDefaultImpl(); // TODO: Initialize to an appropriate value
            string dimensionFilter = string.Empty; // TODO: Initialize to an appropriate value
            DimensionFilter expected = null; // TODO: Initialize to an appropriate value
            DimensionFilter actual;
            actual = target.ParseDimensionFilter(dimensionFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ParseDimensionFilterList
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        [UrlToTest("http://localhost:36590/")]
        public void ParseDimensionFilterListTest()
        {
            URLParameterDefaultImpl target = new URLParameterDefaultImpl(); // TODO: Initialize to an appropriate value
            string dimensionsFilter = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> actual;
            actual = target.ParseDimensionFilterList(dimensionsFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
