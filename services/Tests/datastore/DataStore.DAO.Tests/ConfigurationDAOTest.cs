using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Common.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataStore.DAO.Tests
{
    
    
    /// <summary>
    ///This is a test class for ConfigurationDAOTest and is intended
    ///to contain all ConfigurationDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ConfigurationDAOTest : BaseTestClass
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

        /// <summary>
        ///A test for ConfigurationDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ConfigurationDAOConstructorTest()
        {
            ConfigurationDAO target = new ConfigurationDAO();
            Assert.AreNotEqual(target, null);
        }

        /// <summary>
        ///A test for GetConfiguration
        ///</summary>
        [TestMethod()]
        public void GetConfigurationTest()
        {
            ConfigurationDAO target = new ConfigurationDAO();
            int indicatorId = 1;
            string geoLevel = "NUTS1";
            Configuration expected = new Configuration
            {
                ID = 1,
                GeoLevel = "NUTS1",
                Shapefile = new Shapefile
                {
                    ID = 4,
                    FileName = "nuts1.shp",
                    Name = "NUTS1",
                    Path = "D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\NUTS1",
                    Level = 1
                }
            };
 
            Configuration actual;
            actual = target.GetConfiguration(indicatorId, geoLevel);
            
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetConfigurations
        ///</summary>
        [TestMethod()]
        public void GetConfigurationsTest()
        {
            ConfigurationDAO target = new ConfigurationDAO();
            int indicatorId = 1;
            IEnumerable<Configuration> actual;
            actual = target.GetConfigurations(indicatorId);
            
            Assert.AreEqual(actual.Count(), 5);
            Assert.AreEqual(actual.ElementAt(0).GeoLevel, "NUTS1");
            Assert.AreEqual(actual.ElementAt(1).GeoLevel, "NUTS2");
            Assert.AreEqual(actual.ElementAt(2).GeoLevel, "NUTS3");
            Assert.AreEqual(actual.ElementAt(3).GeoLevel, "Municipalities");
            Assert.AreEqual(actual.ElementAt(4).GeoLevel, "Parishes");
        }

        /// <summary>
        ///A test for GetShapefileConfigurationURL
        ///</summary>
        [TestMethod()]
        public void GetShapefileConfigurationURLTest()
        {
            ConfigurationDAO target = new ConfigurationDAO(); // TODO: Initialize to an appropriate value
            int indicatorId = 1; 
            string geoLevel = "NUTS1"; 
            string expected = "D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\NUTS1\\nuts1.shp";
            string actual;
            actual = target.GetShapefileConfigurationURL(indicatorId, geoLevel);
            
            Assert.AreEqual(expected, actual);
        }
    }
}
