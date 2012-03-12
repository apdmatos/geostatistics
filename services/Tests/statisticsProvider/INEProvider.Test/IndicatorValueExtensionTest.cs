using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Values;
using System.Collections.Generic;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for IndicatorValueExtensionTest and is intended
    ///to contain all IndicatorValueExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IndicatorValueExtensionTest
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
        ///A test for ToIndicatorValue
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void ToIndicatorValueTest()
        {
            IndicatorValue inevalue = null; // TODO: Initialize to an appropriate value
            IndicatorValue expected = null; // TODO: Initialize to an appropriate value
            IndicatorValue actual;
            actual = IndicatorValueExtension.ToIndicatorValue(inevalue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToIndicatorValueEnumerable
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticProvideres\\INEProvider", "/")]
        [UrlToTest("http://localhost:42136/")]
        public void ToIndicatorValueEnumerableTest()
        {
            IEnumerable<IndicatorValue> ineValues = null; // TODO: Initialize to an appropriate value
            IEnumerable<IndicatorValue> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<IndicatorValue> actual;
            actual = IndicatorValueExtension.ToIndicatorValueEnumerable(ineValues);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
