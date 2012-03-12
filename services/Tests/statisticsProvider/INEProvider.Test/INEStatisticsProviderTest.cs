using INEProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using ProviderDataContracts.Values;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for INEStatisticsProviderTest and is intended
    ///to contain all INEStatisticsProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class INEStatisticsProviderTest
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
        ///A test for INEStatisticsProvider Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void INEStatisticsProviderConstructorTest()
        {
            INEStatisticsProvider target = new INEStatisticsProvider();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetMetadata
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void GetMetadataTest()
        {
            INEStatisticsProvider target = new INEStatisticsProvider(); // TODO: Initialize to an appropriate value
            string indicatorId = string.Empty; // TODO: Initialize to an appropriate value
            IndicatorMetadata expected = null; // TODO: Initialize to an appropriate value
            IndicatorMetadata actual;
            actual = target.GetMetadata(indicatorId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetValues
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void GetValuesTest()
        {
            INEStatisticsProvider target = new INEStatisticsProvider(); // TODO: Initialize to an appropriate value
            string indicatorId = string.Empty; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> filters = null; // TODO: Initialize to an appropriate value
            IEnumerable<IndicatorValue> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<IndicatorValue> actual;
            actual = target.GetValues(indicatorId, filters);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
