using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Metadata;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for DimensionExtensionTest and is intended
    ///to contain all DimensionExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DimensionExtensionTest
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
        ///A test for GeoDimensionToDimension
        ///</summary>
        public void GeoDimensionToDimensionTest()
        {
            Dimension ineDimension = null; // TODO: Initialize to an appropriate value
            Dimension expected = null; // TODO: Initialize to an appropriate value
            Dimension actual;
            actual = DimensionExtension.GeoDimensionToDimension(ineDimension);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimension
        ///</summary>
        public void ToDimensionTest()
        {
            Dimension ineDimension = null; // TODO: Initialize to an appropriate value
            int order = 0; // TODO: Initialize to an appropriate value
            DimensionType type = new DimensionType(); // TODO: Initialize to an appropriate value
            Dimension expected = null; // TODO: Initialize to an appropriate value
            Dimension actual;
            actual = DimensionExtension.ToDimension(ineDimension, order, type);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimension
        ///</summary>
        public void ToDimensionTest1()
        {
            TimeDimension ineDimension = null; // TODO: Initialize to an appropriate value
            Dimension expected = null; // TODO: Initialize to an appropriate value
            Dimension actual;
            actual = DimensionExtension.ToDimension(ineDimension);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
