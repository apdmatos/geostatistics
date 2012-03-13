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
        public void GetGeographicLevelNameTest()
        {
            GeographicLevels level = new GeographicLevels(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = INEServiceHepers.GetGeographicLevelName(level);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
