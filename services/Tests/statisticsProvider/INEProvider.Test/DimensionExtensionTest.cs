using INEProvider.Extensions.INE2Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using INEProvider.INEService;
using ProviderDataContracts.Metadata;
using System.Collections.Generic;

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
            //INEProvider.INEService.Dimension ineDimension = new INEService.Dimension
            //{
            //    Code = "1",
            //    Designation = "Dimension 1",
            //    Abbreviation = "D1",
            //    Categories = new List<Category> { 
            //        new Category { Code = "1", Designation = "Category 1", Level = 1 },
            //        new Category { Code = "1.1", Designation = "Category 1.1", Level = 2, ParentCategoryCode = "1" },
            //        new Category { Code = "2", Designation = "Category 2", Level = 1 }
            //    }
            //};
            //Dimension expected = null; // TODO: Initialize to an appropriate value
            //Dimension actual;
            //actual = DimensionExtension.GeoDimensionToDimension(ineDimension);
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ToDimension
        ///</summary>
        public void ToDimensionTest()
        {
            INEProvider.INEService.Dimension ineDimension = new INEService.Dimension
            {
                Code = "1",
                Designation = "Dimension 1",
                Abbreviation = "D1",
                Categories = new List<Category> { 
                    new Category { Code = "1", Designation = "Category 1", Level = 1 },
                    new Category { Code = "1.1", Designation = "Category 1.1", Level = 2, ParentCategoryCode = "1" },
                    new Category { Code = "2", Designation = "Category 2", Level = 1 }
                }
            };
            int order = 3;
            ProviderDataContracts.Metadata.Dimension expected = new ProviderDataContracts.Metadata.Dimension
            {
                ID = order.ToString(),
                Name = "Dimension 1",
                NameAbbr = "D1",
                DimensionType = DimensionType.Other,
                Attributes = new List<DimensionAttribute> { 
                    new HierarchyAttribute { 
                        ID = "1", 
                        Name = "Category 1", 
                        ChildAttributes = new List<DimensionAttribute> { 
                            new DimensionAttribute { ID= "1.1", Name = "Category 1.1" }
                        }
                    },
                    new DimensionAttribute { ID = "2", Name = "Category 2" }
                }
            };

            ProviderDataContracts.Metadata.Dimension actual = DimensionExtension.ToDimension(ineDimension, order, DimensionType.Other);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToDimension
        ///</summary>
        public void INETimeDimensionToDimensionTest()
        {
            TimeDimension ineDimension = new TimeDimension {
                Code = "1",
                Abbreviation = "D1",
                Designation = "Dimension 1",
                Periods = new List<Period> { 
                    new Period { Code = "1", Designation="Designation 1" },
                    new Period { Code = "2", Designation="Designation 2" },
                    new Period { Code = "3", Designation="Designation 3" }
                }
            };
            ProviderDataContracts.Metadata.Dimension expected = new ProviderDataContracts.Metadata.Dimension
            {
                ID = "1",
                Name = "Dimension 1",
                NameAbbr = "D1",
                DimensionType = DimensionType.Temporal,
                Attributes = new List<DimensionAttribute> { 
                    new DimensionAttribute { ID = "1", Name = "Designation 1" },
                    new DimensionAttribute { ID = "2", Name = "Designation 2" },
                    new DimensionAttribute { ID = "3", Name = "Designation 3" }
                }
            };
            ProviderDataContracts.Metadata.Dimension actual = DimensionExtension.ToDimension(ineDimension);
            Assert.AreEqual(expected, actual);
        }
    }
}
