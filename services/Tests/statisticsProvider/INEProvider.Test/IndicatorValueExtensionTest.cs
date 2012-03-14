using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Values;
using System.Collections.Generic;
using System.Linq;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for IndicatorValueExtensionTest and is intended
    ///to contain all IndicatorValueExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IndicatorValueExtensionTest
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
        ///A test for ToIndicatorValue
        ///</summary>
        [TestMethod()]
        public void ToIndicatorValueTest()
        {
            INEService.IndicatorValue inevalue = new INEService.IndicatorValue
            {
                Value = 1,
                IndicatorCode = "1",
                Dimensions = new List<DimensionFilter>
                {
                    new DimensionFilter { Order = 1, Codes = new ArrayOfDimensionCode { "S7A2010" } },
                    new DimensionFilter { Order = 2, Codes = new ArrayOfDimensionCode { "1" } },
                }
            };
            ProviderDataContracts.Values.IndicatorValue expected = new ProviderDataContracts.Values.IndicatorValue
            {
                Value = 1,
                Filters = new List<ProviderDataContracts.Filters.DimensionFilter> { 
                    new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "1", AttributeIDs = new List<string> { "S7A2010" } },
                    new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "2", AttributeIDs = new List<string> { "1" } }
                }
            };
            ProviderDataContracts.Values.IndicatorValue actual = IndicatorValueExtension.ToIndicatorValue(inevalue);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToIndicatorValueEnumerable
        ///</summary>
        [TestMethod()]
        public void ToIndicatorValueEnumerableTest()
        {
            IEnumerable<INEProvider.INEService.IndicatorValue> ineValues = new List<INEProvider.INEService.IndicatorValue>
            {
                new INEService.IndicatorValue
                {
                    Value = 1,
                    IndicatorCode = "1",
                    Dimensions = new List<DimensionFilter>
                    {
                        new DimensionFilter { Order = 1, Codes = new ArrayOfDimensionCode { "S7A2010" } },
                        new DimensionFilter { Order = 2, Codes = new ArrayOfDimensionCode { "1" } },
                    }
                }
            };
            IEnumerable<ProviderDataContracts.Values.IndicatorValue> expected = new List<ProviderDataContracts.Values.IndicatorValue>
            {
                new ProviderDataContracts.Values.IndicatorValue
                {
                    Value = 1,
                    Filters = new List<ProviderDataContracts.Filters.DimensionFilter> { 
                        new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "1", AttributeIDs = new List<string> { "S7A2010" } },
                        new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "2", AttributeIDs = new List<string> { "1" } }
                    }
                }
            };
            IEnumerable<ProviderDataContracts.Values.IndicatorValue> actual = IndicatorValueExtension.ToIndicatorValueEnumerable(ineValues);
            Assert.IsTrue(Enumerable.SequenceEqual<ProviderDataContracts.Values.IndicatorValue>(expected, actual));
        }
    }
}
