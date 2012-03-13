using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Values;
using System.Collections.Generic;

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
        public void ToIndicatorValueTest()
        {
            IndicatorValue inevalue = null; // TODO: Initialize to an appropriate value
            IndicatorValue expected = null; // TODO: Initialize to an appropriate value
            IndicatorValue actual;
            actual = IndicatorValueExtension.ToIndicatorValue(inevalue);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToIndicatorValueEnumerable
        ///</summary>
        public void ToIndicatorValueEnumerableTest()
        {
            IEnumerable<IndicatorValue> ineValues = null; // TODO: Initialize to an appropriate value
            IEnumerable<IndicatorValue> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<IndicatorValue> actual;
            actual = IndicatorValueExtension.ToIndicatorValueEnumerable(ineValues);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
