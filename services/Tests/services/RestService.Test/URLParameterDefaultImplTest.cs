using RestService.parameters_parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using System.Linq;

namespace RestService.Test
{
    
    
    /// <summary>
    ///This is a test class for URLParameterDefaultImplTest and is intended
    ///to contain all URLParameterDefaultImplTest Unit Tests
    ///</summary>
    [TestClass()]
    public class URLParameterDefaultImplTest
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
        ///A test for URLParameterDefaultImpl Constructor
        ///</summary>
        [TestMethod()]
        public void URLParameterDefaultImplConstructorTest()
        {
            URLParameterDefaultImpl target = new URLParameterDefaultImpl();
            Assert.AreNotEqual(null, target);
        }

        /// <summary>
        ///A test for ParseDimensionFilter
        ///</summary>
        [TestMethod()]
        public void ParseDimensionFilterTest()
        {
            URLParameterDefaultImpl target = new URLParameterDefaultImpl(); 
            string dimensionFilter = "1,1,2,3";
            DimensionFilter expected = new DimensionFilter
            {
                DimensionID = "1",
                AttributeIDs = new List<string> { "1", "2", "3" }
            };
            DimensionFilter actual = target.ParseDimensionFilter(dimensionFilter);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ParseDimensionFilterList
        ///</summary>
        [TestMethod()]
        public void ParseDimensionFilterListTest()
        {
            URLParameterDefaultImpl target = new URLParameterDefaultImpl();
            string dimensionsFilter = "1,1,2,3,4#2,1,2,3,4";
            IEnumerable<DimensionFilter> expected = new List<DimensionFilter> 
            { 
                new DimensionFilter { DimensionID = "1", AttributeIDs= new List<string> { "1", "2", "3", "4" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs= new List<string> { "1", "2", "3", "4" } }
            }; 
            IEnumerable<DimensionFilter> actual = target.ParseDimensionFilterList(dimensionsFilter);
            Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(expected, actual));
        }
    }
}
