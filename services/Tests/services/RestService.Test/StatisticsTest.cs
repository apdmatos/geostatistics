using RestService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using RestService.parameters_parser;
using StatisticsProxyServiceDefenitions.interfaces;
using StatisticsProxyServiceDefenitions.data_models;
using ProviderDataContracts.Metadata;

namespace RestService.Test
{
    
    
    /// <summary>
    ///This is a test class for StatisticsTest and is intended
    ///to contain all StatisticsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StatisticsTest
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
        ///A test for Statistics Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        [UrlToTest("http://localhost:36590/")]
        public void StatisticsConstructorTest()
        {
            IURLParametersParser parser = null; // TODO: Initialize to an appropriate value
            IStatisticsProxyService service = null; // TODO: Initialize to an appropriate value
            Statistics target = new Statistics(parser, service);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetDataSerie
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        [UrlToTest("http://localhost:36590/")]
        public void GetDataSerieTest()
        {
            IURLParametersParser parser = null; // TODO: Initialize to an appropriate value
            IStatisticsProxyService service = null; // TODO: Initialize to an appropriate value
            Statistics target = new Statistics(parser, service); // TODO: Initialize to an appropriate value
            int sourceid = 0; // TODO: Initialize to an appropriate value
            int indicatorid = 0; // TODO: Initialize to an appropriate value
            string axisDimension = string.Empty; // TODO: Initialize to an appropriate value
            string selectedDimensions = string.Empty; // TODO: Initialize to an appropriate value
            DataSerie expected = null; // TODO: Initialize to an appropriate value
            DataSerie actual;
            actual = target.GetDataSerie(sourceid, indicatorid, axisDimension, selectedDimensions);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetMetadata
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("D:\\Projects\\My Projects\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        [UrlToTest("http://localhost:36590/")]
        public void GetMetadataTest()
        {
            IURLParametersParser parser = null; // TODO: Initialize to an appropriate value
            IStatisticsProxyService service = null; // TODO: Initialize to an appropriate value
            Statistics target = new Statistics(parser, service); // TODO: Initialize to an appropriate value
            int sourceid = 0; // TODO: Initialize to an appropriate value
            int indicatorid = 0; // TODO: Initialize to an appropriate value
            IndicatorMetadata expected = null; // TODO: Initialize to an appropriate value
            IndicatorMetadata actual;
            actual = target.GetMetadata(sourceid, indicatorid);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
