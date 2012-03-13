using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Metadata;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for CategoryExtensionTest and is intended
    ///to contain all CategoryExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CategoryExtensionTest
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
        ///A test for ToDimensionAttribute
        ///</summary>
        public void ToDimensionAttributeTest()
        {
            Period period = null; // TODO: Initialize to an appropriate value
            DimensionAttribute expected = null; // TODO: Initialize to an appropriate value
            DimensionAttribute actual;
            actual = CategoryExtension.ToDimensionAttribute(period);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimensionAttribute
        ///</summary>
        public void ToDimensionAttributeTest1()
        {
            Category category = null; // TODO: Initialize to an appropriate value
            bool hierarchical = false; // TODO: Initialize to an appropriate value
            DimensionAttribute expected = null; // TODO: Initialize to an appropriate value
            DimensionAttribute actual;
            actual = CategoryExtension.ToDimensionAttribute(category, hierarchical);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
