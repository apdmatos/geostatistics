using INEProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using ProviderDataContracts.Values;
using Moq;
using INEProvider.INEService;
using System.Linq;
using INEProvider.request;
using INEProvider.Aggregator;

namespace INEProvider.Test
{
    /// <summary>
    ///This is a test class for INEStatisticsProviderTest and is intended
    ///to contain all INEStatisticsProviderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class INEStatisticsProviderTest
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
        ///A test for INEStatisticsProvider Constructor
        ///</summary>
        [TestMethod()]
        public void INEStatisticsProviderConstructorTest()
        {
            INEStatisticsProvider target = new INEStatisticsProvider(null, null);
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for GetMetadata
        ///</summary>
        [TestMethod()]
        public void GetMetadataTest()
        {
            var lastupdate = DateTime.Now.ToShortDateString();
            Metadata ineMetadata = new Metadata
            {
                Designation = "Indicator 1",
                Abbreviation = "I1",
                TimeDimension = new TimeDimension
                {
                    Code = "T1",
                    Designation = "Time dimension",
                    Abbreviation = "TD",
                    Periods = new List<Period>{
                        new Period { Code= "1", Designation = "2010" }
                    }
                },
                GeoDimension = new INEService.Dimension
                {
                    Code = "Geo1",
                    Designation = "Dimensao geografica",
                    Abbreviation = "DG",
                    ClassificationCode = "00320",
                    LowestClassificationLevel = 2
                },
                Url = "http://nowhere.com",
                IndicatorUrl = "http://nowhere.com",
                DataLastUpdate = lastupdate
            };
            Mock<IINERequesterWrapper> ineMock = new Mock<IINERequesterWrapper>();
            ineMock.Setup(m => m.GetMetadata(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(ineMetadata);


            INEStatisticsProvider target = new INEStatisticsProvider(ineMock.Object, null);
            string indicatorId = "1";
            IndicatorMetadata expected = new IndicatorMetadata
            {
                ID = indicatorId,
                IndicatorName = "Indicator 1",
                IndicatorNameAbbr = "I1",
                Dimensions = new List<ProviderDataContracts.Metadata.Dimension>
                {
                    new ProviderDataContracts.Metadata.Dimension { 
                        ID = "1", 
                        DimensionType = DimensionType.Temporal, 
                        Name = "Time dimension",
                        NameAbbr = "TD",
                        Attributes = new List<DimensionAttribute> {
                            new DimensionAttribute { ID = "1", Name = "2010" }
                        }
                    }, 
                    new ProviderDataContracts.Metadata.Dimension { 
                        ID = "2", 
                        DimensionType = DimensionType.Geographic, 
                        Name = "Dimensao geografica",
                        NameAbbr = "DG",
                        Attributes = new List<DimensionAttribute> {
                            new GeoAttributeHierarchy { 
                                ID = "PT",
                                Name = "Portugal",
                                Configuration = new List<GeoAttributeConfiguration>{
                                    new GeoAttributeConfiguration { ID = "NUTS1", Level = 2, Name = "NUTS 1" }
                                }
                            }
                        }
                    }
                },
                LastUpdate = DateTime.Parse(lastupdate),
                SourceName = "Instituto Nacional de Estatísticas",
                SourceNameAbbr = "INE",
                SourceURL = "http://nowhere.com"
            };
            IndicatorMetadata actual = target.GetMetadata(indicatorId);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetValues
        ///</summary>
        [TestMethod()]
        public void GetValuesTest()
        {
            INEService.IndicatorValues ineValues = new INEService.IndicatorValues
            {
                IndicatorValueList = new List<INEService.IndicatorValue> {
                    new INEService.IndicatorValue{
                        Value = 1,
                        IndicatorCode = "1",
                        Dimensions = new List<INEProvider.INEService.DimensionFilter>
                        {
                            new INEProvider.INEService.DimensionFilter { Order = 1, Codes = new ArrayOfDimensionCode { "S7A2010" } },
                            new INEProvider.INEService.DimensionFilter { Order = 2, Codes = new ArrayOfDimensionCode { "1" } },
                        }
                    }
                }
            };
            Mock<IINERequesterWrapper> ineMock = new Mock<IINERequesterWrapper>();
            ineMock.Setup(m => m.GetValues(
                It.IsAny<string>(),
                It.IsAny<List<INEProvider.INEService.DimensionFilter>>(),
                It.IsAny<ValuesReturnType>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<int>())).Returns(ineValues);


            IEnumerable<ProviderDataContracts.Values.IndicatorValue> aggregatorValues = new ProviderDataContracts.Values.IndicatorValue[] { 
                new ProviderDataContracts.Values.IndicatorValue { 
                    Value = 1,
                    Filters = new List<ProviderDataContracts.Filters.DimensionFilter> { 
                        new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "1", AttributeIDs = new List<string> { "S7A2010" } },
                        new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "2", AttributeIDs = new List<string> { "1" } }
                    }
                }
            };
            Mock<IAggregator> agregatorMock = new Mock<IAggregator>();
            agregatorMock.Setup(m => m.AggregateValues(
                It.IsAny<IEnumerable<INEService.IndicatorValue>>(),
                It.IsAny<IEnumerable<ProviderDataContracts.Filters.DimensionFilter>>())).Returns(aggregatorValues);


            INEStatisticsProvider target = new INEStatisticsProvider(ineMock.Object, agregatorMock.Object);
            string indicatorId = "1";
            IEnumerable<ProviderDataContracts.Filters.DimensionFilter> filters = null;
            IEnumerable<ProviderDataContracts.Values.IndicatorValue> expected = new List<ProviderDataContracts.Values.IndicatorValue> {
                new ProviderDataContracts.Values.IndicatorValue
                {
                    Value = 1,
                    Filters = new List<ProviderDataContracts.Filters.DimensionFilter> { 
                        new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "1", AttributeIDs = new List<string> { "S7A2010" } },
                        new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "2", AttributeIDs = new List<string> { "1" } }
                    }
                }
            };
            IEnumerable<ProviderDataContracts.Values.IndicatorValue> actual = target.GetValues(indicatorId, null, null);
            Assert.IsTrue(Enumerable.SequenceEqual<ProviderDataContracts.Values.IndicatorValue>(expected, actual));
        }
    }
}
