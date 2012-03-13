using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using INEProvider.Extensions.Provider2INE;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for DimensionFilterExtensionTest and is intended
    ///to contain all DimensionFilterExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DimensionFilterExtensionTest
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
        ///A test for ToDimensionFilter
        ///</summary>
        public void ToDimensionFilterTest1()
        {
            DimensionFilter filter = null; // TODO: Initialize to an appropriate value
            DimensionFilter expected = null; // TODO: Initialize to an appropriate value
            DimensionFilter actual;
            actual = DimensionFilterExtension.ToDimensionFilter(filter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimensionFilterEnumerable
        ///</summary>
        public void ToDimensionFilterEnumerableTest1()
        {
            IEnumerable<DimensionFilter> filter = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> actual;
            actual = DimensionFilterExtension.ToDimensionFilterEnumerable(filter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimensionFilter
        ///</summary>
        public void ToDimensionFilterTest()
        {
            DimensionFilter filter = null; // TODO: Initialize to an appropriate value
            DimensionFilter expected = null; // TODO: Initialize to an appropriate value
            DimensionFilter actual;
            actual = DimensionFilterExtension.ToDimensionFilter(filter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimensionFilterEnumerable
        ///</summary>
        public void ToDimensionFilterEnumerableTest()
        {
            IEnumerable<DimensionFilter> filter = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<DimensionFilter> actual;
            actual = DimensionFilterExtension.ToDimensionFilterEnumerable(filter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
