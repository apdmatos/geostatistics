using INEProvider.Aggregator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Collections.Generic;
using ProviderDataContracts.Filters;
using ProviderDataContracts.Values;
using System.Linq;

namespace INEProvider.Test
{
    
    
    /// <summary>
    ///This is a test class for DefaultAggregatorImplTest and is intended
    ///to contain all DefaultAggregatorImplTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DefaultAggregatorImplTest
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
        ///A test for DefaultAggregatorImpl Constructor
        ///</summary>
        [TestMethod()]
        public void DefaultAggregatorImplConstructorTest()
        {
            DefaultAggregatorImpl target = new DefaultAggregatorImpl();
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for AggregateValues
        ///</summary>
        [TestMethod()]
        public void AggregateValuesTest()
        {
            DefaultAggregatorImpl target = new DefaultAggregatorImpl();
            IEnumerable<INEService.IndicatorValue> indicatorValueList = new INEService.IndicatorValue[]
            {
                new INEService.IndicatorValue { 
                    Value = 1,
                    Dimensions = new List<INEService.DimensionFilter>{
                        new INEService.DimensionFilter { Order=1, Codes = new INEService.ArrayOfDimensionCode() { "2010" } },
                        new INEService.DimensionFilter { Order=2, Codes = new INEService.ArrayOfDimensionCode() { "PT" } },
                        new INEService.DimensionFilter { Order=3, Codes = new INEService.ArrayOfDimensionCode() { "M" } }
                    }
                },
                new INEService.IndicatorValue { 
                    Value = 1,
                    Dimensions = new List<INEService.DimensionFilter>{
                        new INEService.DimensionFilter { Order=1, Codes = new INEService.ArrayOfDimensionCode() { "2010" } },
                        new INEService.DimensionFilter { Order=2, Codes = new INEService.ArrayOfDimensionCode() { "PT" } },
                        new INEService.DimensionFilter { Order=3, Codes = new INEService.ArrayOfDimensionCode() { "F" } }
                    }
                },
                new INEService.IndicatorValue { 
                    Value = 1,
                    Dimensions = new List<INEService.DimensionFilter>{
                        new INEService.DimensionFilter { Order=1, Codes = new INEService.ArrayOfDimensionCode() { "2011" } },
                        new INEService.DimensionFilter { Order=2, Codes = new INEService.ArrayOfDimensionCode() { "PT" } },
                        new INEService.DimensionFilter { Order=3, Codes = new INEService.ArrayOfDimensionCode() { "M" } }
                    }
                },
                new INEService.IndicatorValue { 
                    Value = 1,
                    Dimensions = new List<INEService.DimensionFilter>{
                        new INEService.DimensionFilter { Order=1, Codes = new INEService.ArrayOfDimensionCode() { "2011" } },
                        new INEService.DimensionFilter { Order=2, Codes = new INEService.ArrayOfDimensionCode() { "PT" } },
                        new INEService.DimensionFilter { Order=3, Codes = new INEService.ArrayOfDimensionCode() { "F" } }
                    }
                }
            };
            IEnumerable<DimensionFilter> projectedDimensions = new DimensionFilter[]
            {
                new DimensionFilter { DimensionID="3", AttributeIDs=new string[]{ "M", "F" } }
            };
            IEnumerable<IndicatorValue> expected = new IndicatorValue[]
            {
                new IndicatorValue { 
                    Value = 2,
                    Filters = new DimensionFilter[]{
                        new DimensionFilter { DimensionID = "1", AttributeIDs = new string[]{ "2010", "2011" } },
                        new DimensionFilter { DimensionID = "2", AttributeIDs = new string[]{ "PT" } },
                    },
                    Projected = new DimensionFilter[]{
                        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[]{ "M" } }
                    }
                },
                new IndicatorValue { 
                    Value = 2,
                    Filters = new DimensionFilter[]{
                        new DimensionFilter { DimensionID = "1", AttributeIDs = new string[]{ "2010", "2011" } },
                        new DimensionFilter { DimensionID = "2", AttributeIDs = new string[]{ "PT" } },
                    },
                    Projected = new DimensionFilter[]{
                        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[]{ "F" } }
                    }
                }
            };
            IEnumerable<IndicatorValue> actual = target.AggregateValues(indicatorValueList, projectedDimensions);
            Assert.IsTrue(Enumerable.SequenceEqual<IndicatorValue>(expected, actual));
        }

        /// <summary>
        ///A test for GetAggregatorKey
        ///</summary>
        [TestMethod()]
        public void GetAggregatorKeyTest()
        {
            DefaultAggregatorImpl_Accessor target = new DefaultAggregatorImpl_Accessor();
            IEnumerable<DimensionFilter> filters = new DimensionFilter[]{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } }
            }; ;
            string expected = "112212";
            string actual = target.GetAggregatorKey(filters);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for JoinFilters
        ///</summary>
        [TestMethod()]
        public void JoinFiltersTest()
        {
            DefaultAggregatorImpl_Accessor target = new DefaultAggregatorImpl_Accessor();
            IEnumerable<DimensionFilter> dest = new DimensionFilter[]{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } }
            };
            IEnumerable<DimensionFilter> source = new DimensionFilter[]{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "2", "3", "4" } },
                new DimensionFilter { DimensionID = "5", AttributeIDs = new string[] { "1", "2" } }
            };
            target.JoinFilters(dest, source);


            IEnumerable<DimensionFilter> expected = new DimensionFilter[]{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2", "3", "4" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } }
            };

            Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(dest, expected));
        }
    }
}
