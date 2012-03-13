using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Metadata;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for MetadataExtensionsTest and is intended
    ///to contain all MetadataExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MetadataExtensionsTest
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
        ///A test for ToIndicatorMetadata
        ///</summary>
        public void ToIndicatorMetadataTest()
        {
            Metadata metadata = null; // TODO: Initialize to an appropriate value
            string indicatorId = string.Empty; // TODO: Initialize to an appropriate value
            IndicatorMetadata expected = null; // TODO: Initialize to an appropriate value
            IndicatorMetadata actual;
            actual = MetadataExtensions.ToIndicatorMetadata(metadata, indicatorId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
