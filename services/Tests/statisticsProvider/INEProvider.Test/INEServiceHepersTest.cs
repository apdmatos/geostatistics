using INEProvider.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.Model;

namespace INEProvider.Test
{
    /// <summary>
    ///This is a test class for INEServiceHepersTest and is intended
    ///to contain all INEServiceHepersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class INEServiceHepersTest
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
        ///A test for GetGeographicLevelName
        ///</summary>
        public void GetGeographicLevelNameNUTS1Test()
        {
            GeographicLevels level = GeographicLevels.NUTS1;
            string expected = "NUTS1";
            string actual = INEServiceHepers.GetGeographicLevelName(level);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetGeographicLevelName
        ///</summary>
        public void GetGeographicLevelNameNUTS2Test()
        {
            GeographicLevels level = GeographicLevels.NUTS2;
            string expected = "NUTS2";
            string actual = INEServiceHepers.GetGeographicLevelName(level);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetGeographicLevelName
        ///</summary>
        public void GetGeographicLevelNameNUTS3Test()
        {
            GeographicLevels level = GeographicLevels.NUTS3;
            string expected = "NUTS3";
            string actual = INEServiceHepers.GetGeographicLevelName(level);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetGeographicLevelName
        ///</summary>
        public void GetGeographicLevelNameMunicipalityTest()
        {
            GeographicLevels level = GeographicLevels.Municipality;
            string expected = "Concelhos";
            string actual = INEServiceHepers.GetGeographicLevelName(level);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetGeographicLevelName
        ///</summary>
        public void GetGeographicLevelNameParishTest()
        {
            GeographicLevels level = GeographicLevels.Parish;
            string expected = "Freguesias";
            string actual = INEServiceHepers.GetGeographicLevelName(level);
            Assert.AreEqual(expected, actual);
        }
    }
}
