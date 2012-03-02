using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Model;
using System.Collections.Generic;

namespace DataStore.DAO.Tests
{
    
    
    /// <summary>
    ///This is a test class for ConfigurationDAOTest and is intended
    ///to contain all ConfigurationDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfigurationDAOTest
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
        ///A test for ConfigurationDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ConfigurationDAOConstructorTest()
        {
            ConfigurationDAO target = new ConfigurationDAO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetConfiguration
        ///</summary>
        [TestMethod()]
        public void GetConfigurationTest()
        {
            ConfigurationDAO target = new ConfigurationDAO(); // TODO: Initialize to an appropriate value
            int indicatorId = 0; // TODO: Initialize to an appropriate value
            string geoLevel = string.Empty; // TODO: Initialize to an appropriate value
            Configuration expected = null; // TODO: Initialize to an appropriate value
            Configuration actual;
            actual = target.GetConfiguration(indicatorId, geoLevel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetConfigurations
        ///</summary>
        [TestMethod()]
        public void GetConfigurationsTest()
        {
            ConfigurationDAO target = new ConfigurationDAO(); // TODO: Initialize to an appropriate value
            int indicatorId = 0; // TODO: Initialize to an appropriate value
            IEnumerable<Configuration> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Configuration> actual;
            actual = target.GetConfigurations(indicatorId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetShapefileConfigurationURL
        ///</summary>
        [TestMethod()]
        public void GetShapefileConfigurationURLTest()
        {
            ConfigurationDAO target = new ConfigurationDAO(); // TODO: Initialize to an appropriate value
            int indicatorId = 0; // TODO: Initialize to an appropriate value
            string geoLevel = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.GetShapefileConfigurationURL(indicatorId, geoLevel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
