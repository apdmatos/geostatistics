using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Metadata;
using System.Collections.Generic;
using System.Linq;

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
        [TestMethod()]
        public void INEPeriodToDimensionAttributeTest()
        {
            Period period = new Period { 
                Code = "STA2010",
                Designation = "2010",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now
            };
            DimensionAttribute expected = new DimensionAttribute { 
                ID = "STA2010",
                Name = "2010"
            };
            DimensionAttribute actual = CategoryExtension.ToDimensionAttribute(period);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToDimensionAttribute
        ///</summary>
        [TestMethod()]
        public void INEDimensionToDimensionAttributeTest()
        {
            Category category = new Category { 
                Code = "D1",
                Designation = "Dimension 1",
                Level = 1
            };
            bool hierarchical = false;
            DimensionAttribute expected = new DimensionAttribute { 
                ID = "D1",
                Name = "Dimension 1"
            };
            DimensionAttribute actual;
            actual = CategoryExtension.ToDimensionAttribute(category, hierarchical);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToDimensionAttribute
        ///</summary>
        [TestMethod()]
        public void INEDimensionToDimensionHierarchyAttributeAttributeTest()
        {
            Category category = new Category
            {
                Code = "D1",
                Designation = "Dimension 1",
                Level = 1
            };
            bool hierarchical = true;
            DimensionAttribute expected = new HierarchyAttribute
            {
                ID = "D1",
                Name = "Dimension 1",
            };
            DimensionAttribute actual = CategoryExtension.ToDimensionAttribute(category, hierarchical);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToDimensionAttributeEnumerable
        ///</summary>
        [TestMethod()]
        public void INEDimensionsEnumerableToDimensionAttributeEnumerableTest()
        {
            Category category = new Category
            {
                Code = "D1",
                Designation = "Dimension 1",
                Level = 1
            };
            var expected = new List<DimensionAttribute> {
                new DimensionAttribute { ID = "1", Name = "Category 1" },
                new DimensionAttribute { ID = "2", Name = "Category 2" },
                new DimensionAttribute { ID = "3", Name = "Category 3" }
            };

            var categories = new List<Period> { 
                new Period { Code = "1", Designation = "Category 1" },
                new Period { Code = "2", Designation = "Category 2" },
                new Period { Code = "3", Designation = "Category 3" }
            };
            
            IEnumerable<DimensionAttribute> actual = CategoryExtension.ToDimensionAttributeEnumerable<Period>(categories, CategoryExtension.ToDimensionAttribute);
            Assert.IsTrue(Enumerable.SequenceEqual<DimensionAttribute>(expected, actual));
        }
    }
}
