using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using System.Linq;

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
        [TestMethod()]
        public void ToDimensionFilterTest()
        {
            INEProvider.INEService.DimensionFilter filter = new INEProvider.INEService.DimensionFilter
            {
                Codes = new ArrayOfDimensionCode { "1", "2", "3" },
                Order = 1,
                AllFromLevel = 2
            };
            ProviderDataContracts.Filters.DimensionFilter expected = new ProviderDataContracts.Filters.DimensionFilter
            {
                DimensionID = "1",
                AttributeIDs = new List<string> { "1", "2", "3" }
            };
            ProviderDataContracts.Filters.DimensionFilter actual = DimensionFilterExtension.ToDimensionFilter(filter);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToDimensionFilterEnumerable
        ///</summary>
        [TestMethod()]
        public void ToDimensionFilterEnumerableTest()
        {
            IEnumerable<INEProvider.INEService.DimensionFilter> filter = new List<INEProvider.INEService.DimensionFilter>
            {
                new INEProvider.INEService.DimensionFilter { Order = 3, Codes = new ArrayOfDimensionCode { "1", "2", "3" } }
            };
            IEnumerable<ProviderDataContracts.Filters.DimensionFilter> expected = new List<ProviderDataContracts.Filters.DimensionFilter>
            {
                new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "3", AttributeIDs = new List<string> { "1", "2", "3" } }
            };

            IEnumerable<ProviderDataContracts.Filters.DimensionFilter> actual = DimensionFilterExtension.ToDimensionFilterEnumerable(filter);
            Assert.IsTrue(Enumerable.SequenceEqual<ProviderDataContracts.Filters.DimensionFilter>(expected, actual));
        }
    }
}
