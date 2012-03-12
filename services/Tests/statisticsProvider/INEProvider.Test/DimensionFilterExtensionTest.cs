using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using INEProvider.Extensions.Provider2INE;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for DimensionFilterExtensionTest and is intended
    ///to contain all DimensionFilterExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DimensionFilterExtensionTest
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
        ///A test for ToDimensionFilter
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void ToDimensionFilterTest1()
        {
            DimensionFilter filter = null; // TODO: Initialize to an appropriate value
            DimensionFilter expected = null; // TODO: Initialize to an appropriate value
            DimensionFilter actual;
            actual = DimensionFilterExtension.ToDimensionFilter(filter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimensionFilterEnumerable
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void ToDimensionFilterEnumerableTest1()
        {
            IEnumerable<DimensionFilter> filter = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> actual;
            actual = DimensionFilterExtension.ToDimensionFilterEnumerable(filter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimensionFilter
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void ToDimensionFilterTest()
        {
            DimensionFilter filter = null; // TODO: Initialize to an appropriate value
            DimensionFilter expected = null; // TODO: Initialize to an appropriate value
            DimensionFilter actual;
            actual = DimensionFilterExtension.ToDimensionFilter(filter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimensionFilterEnumerable
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void ToDimensionFilterEnumerableTest()
        {
            IEnumerable<DimensionFilter> filter = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> actual;
            actual = DimensionFilterExtension.ToDimensionFilterEnumerable(filter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
