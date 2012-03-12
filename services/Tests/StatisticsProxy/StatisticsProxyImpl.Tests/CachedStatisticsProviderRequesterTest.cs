using StatisticsProxyImpl.requesters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using ProviderDataContracts.Values;
using ProviderDataContracts.Metadata;
using Moq;

namespace StatisticsProxyImpl.Tests
{
    /// <summary>
    ///This is a test class for CachedStatisticsProviderRequesterTest and is intended
    ///to contain all CachedStatisticsProviderRequesterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CachedStatisticsProviderRequesterTest
    {

        private TestContext testContextInstance;
        private static IStatisticsRequestStrategy requester;

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

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            
            List<Dimension> dimensions = new List<Dimension> { 
                new Dimension {
                    ID = "1",
                    DimensionType = DimensionType.Temporal,
                    Name = "Ano",
                    NameAbbr = "Ano",
                    Attributes = new List<DimensionAttribute> {
                        new DimensionAttribute { ID = "2010", Name = "2010" },
                        new DimensionAttribute { ID = "2011", Name = "2011" }
                    }
                },
                new Dimension {
                    ID = "2",
                    DimensionType = DimensionType.Geographic,
                    Name = "Geografia",
                    NameAbbr = "Geografia",
                    Attributes = new List<DimensionAttribute> {
                        new GeoAttributeHierarchy {
                            ID = "PT",
                            Level = 1,
                            Name = "Distritos",
                            GeoHierachyConfiguration = new GeoAttributeHierarchy {
                                Level = 2,
                                Name = "Municípios"
                            }
                        }
                    }
                },
                new Dimension {
                    ID = "3",
                    DimensionType = DimensionType.Other,
                    Name = "Género",
                    NameAbbr = "Género",
                    Attributes = new List<DimensionAttribute> {
                        new HierarchyAttribute {
                            ID = "all",
                            Name = "Todos",
                            ChildAttributes = new List<DimensionAttribute> {
                                new DimensionAttribute { ID = "M", Name = "Masculino" },
                                new DimensionAttribute { ID = "F", Name = "Feminino" }
                            }
                        }
                    }
                }
            };

            var metadata = new IndicatorMetadata { 
                ID = "1",
                IndicatorName = "Indicator 1",
                IndicatorNameAbbr = "I1",
                LastUpdate = DateTime.Now,
                SourceName = "Test provider",
                SourceNameAbbr = "TP",
                SourceURL = "http://nowhere.com",
                Dimensions = dimensions
            };

            var values = new List<IndicatorValue>
            {
                new IndicatorValue { 
                    Value = 1, 
                    Filters = new List<DimensionFilter> { 
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "1" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "1" } } 
                    }
                }
            };

            var mock = new Mock<IStatisticsRequestStrategy>();
            mock.Setup(m => m.GetMetadata(It.IsAny<string>())).Returns(metadata);
            mock.Setup(m => m.GetValues(It.IsAny<string>(), It.IsAny<IEnumerable<DimensionFilter>>())).Returns(values);

            requester = mock.Object;
        }

        /// <summary>
        ///A test for GetValues that is not on cache
        ///</summary>
        [TestMethod()]
        public void GetValuesCahceMissTest()
        {
            CachedStatisticsProviderRequester target = new CachedStatisticsProviderRequester(requester);
            string indicatorId = "1";
            IEnumerable<DimensionFilter> filters = null;
            IEnumerable<IndicatorValue> actual = target.GetValues(indicatorId, filters);
            Assert.AreNotEqual(null, actual);
        }

        /// <summary>
        ///A test for GetValues that is not on cache
        ///</summary>
        [TestMethod()]
        public void GetValuesCahceHitTest()
        {
            //TODO: implement this
        }

        /// <summary>
        ///A test for GetMetadata that is not on cache
        ///</summary>
        [TestMethod()]
        public void GetMetadataCacheMissTest()
        {
            CachedStatisticsProviderRequester target = new CachedStatisticsProviderRequester(requester);
            string indicatorId = "1";
            IndicatorMetadata actual = target.GetMetadata(indicatorId);
            Assert.AreNotEqual(null, actual);

            //TODO: check if its on cache
        }

        /// <summary>
        ///A test for GetMetadata that is on cache
        ///</summary>
        [TestMethod()]
        public void GetMetadataCacheHitTest()
        {
            //TODO: implement this...
        }

        /// <summary>
        ///A test for Dispose
        ///</summary>
        [TestMethod()]
        public void DisposeTest()
        {
            var mock = new Mock<IStatisticsRequestStrategy>();
            mock.Setup(c => c.Dispose());
            CachedStatisticsProviderRequester target = new CachedStatisticsProviderRequester(mock.Object);
            target.Dispose();
            mock.Verify(c => c.Dispose());
        }

        /// <summary>
        ///A test for CachedStatisticsProviderRequester Constructor
        ///</summary>
        [TestMethod()]
        public void CachedStatisticsProviderRequesterConstructorTest()
        {
            CachedStatisticsProviderRequester target = new CachedStatisticsProviderRequester(requester);
            Assert.AreNotEqual(null, target);
        }
    }
}
