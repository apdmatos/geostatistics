using StatisticsProxyImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Common.Data_Interfaces;
using StatisticsProxyImpl.factories;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using StatisticsProxyServiceDefenitions.data_models;
using ProviderDataContracts.Metadata;
using Moq;
using DataStore.Common.Model;
using StatisticsProxyImpl.requesters;
using ProviderDataContracts.Values;
using System.Linq;

namespace StatisticsProxyImpl.Tests
{
    
    
    /// <summary>
    ///This is a test class for DefaultStatisticsProxyImplTest and is intended
    ///to contain all DefaultStatisticsProxyImplTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DefaultStatisticsProxyImplTest
    {
        private static string configKey;
        private static IIndicatorDAO indicatorRepository;
        private static IStatisticsProviderRequestFactory factory;


        private static IndicatorMetadata metadata;
        private static IEnumerable<IndicatorValue> values;

        private TestContext testContextInstance;

        private static Mock<IIndicatorDAO> GetIndicatorDAOMock()
        {
            var indicator = new Indicator
            {
                ID = 1,
                Name = "foo",
                NameAbbr = "foo",
                Provider = new Provider
                {
                    ID = 1,
                    Name = "provider 1",
                    ServiceURL = "http://nowhere.com",
                    URL = "http://nowhere.com"
                },
                SourceID = "1"
            };

            var mockIndicatorDAO = new Mock<IIndicatorDAO>();
            mockIndicatorDAO.Setup(m => m.GetIndicatorById(It.IsAny<int>(), It.IsAny<int>())).Returns(indicator);

            return mockIndicatorDAO;
        }

        private static Mock<IStatisticsRequestStrategy> GetRequestStrategyMock() 
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

            metadata = new IndicatorMetadata
            {
                ID = "1",
                IndicatorName = "Indicator 1",
                IndicatorNameAbbr = "I1",
                LastUpdate = DateTime.Now,
                SourceName = "Test provider",
                SourceNameAbbr = "TP",
                SourceURL = "http://nowhere.com",
                Dimensions = dimensions
            };

            values = new List<IndicatorValue>
            {
                new IndicatorValue { 
                    Value = 1, 
                    Filters = new List<DimensionFilter> { 
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2010" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } },
                        new DimensionFilter{ DimensionID = "3", AttributeIDs = new List<string>{ "M" } },
                    }
                },
                new IndicatorValue { 
                    Value = 1, 
                    Filters = new List<DimensionFilter> { 
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2011" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } },
                        new DimensionFilter{ DimensionID = "3", AttributeIDs = new List<string>{ "M" } },
                    }
                },
                new IndicatorValue { 
                    Value = 2, 
                    Filters = new List<DimensionFilter> { 
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2010" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } },
                        new DimensionFilter{ DimensionID = "3", AttributeIDs = new List<string>{ "F" } },
                    }
                },
                new IndicatorValue { 
                    Value = 2, 
                    Filters = new List<DimensionFilter> { 
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2011" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } },
                        new DimensionFilter{ DimensionID = "3", AttributeIDs = new List<string>{ "F" } },
                    }
                }
            };

            var requesterMock = new Mock<IStatisticsRequestStrategy>();
            requesterMock.Setup(m => m.GetMetadata(It.IsAny<string>())).Returns(metadata);
            requesterMock.Setup(m => m.GetValues(It.IsAny<string>(), It.IsAny<IEnumerable<DimensionFilter>>())).Returns(values);

            return requesterMock;
        }

        private static Mock<IStatisticsProviderRequestFactory> GetStatisticsProviderFactoryMock(Mock<IStatisticsRequestStrategy> request) 
        {
            var factoryMock = new Mock<IStatisticsProviderRequestFactory>();
            factoryMock.Setup(m => m.GetStatisticRequestStrategy(It.IsAny<string>(), It.IsAny<string>())).Returns(request.Object);

            return factoryMock;
        }

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

            indicatorRepository = GetIndicatorDAOMock().Object;
            factory = GetStatisticsProviderFactoryMock(GetRequestStrategyMock()).Object;
        }

        /// <summary>
        ///A test for DefaultStatisticsProxyImpl Constructor
        ///</summary>
        [TestMethod()]
        public void DefaultStatisticsProxyImplConstructorTest()
        {
            DefaultStatisticsProxyImpl target = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
            Assert.AreNotEqual(target, null);
        }

        /// <summary>
        ///A test for GetDataSerie
        ///</summary>
        [TestMethod()]
        public void GetDataSerieTest()
        {
            DefaultStatisticsProxyImpl target = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
            int sourceid = 1;
            int indicatorid = 1;
            DimensionFilter axisDimension = new DimensionFilter 
            { 
                AttributeIDs = new string[]{ "M", "F" },
                DimensionID = "3"
            };
            IEnumerable<DimensionFilter> selectedDimensions = new DimensionFilter[]
            { 
                new DimensionFilter{ DimensionID = "1", AttributeIDs = new string[]{ "2010", "2011" } },
                new DimensionFilter{ DimensionID = "2", AttributeIDs = new string[]{ "PT" } }
            };

            IEnumerable<DataSerieValues> expectedValues = new DataSerieValues[] {
                new DataSerieValues { 
                    Value = 2, 
                    AxisDimension = new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "M" } },
                    SelectedDimensions = new DimensionFilter[] {
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2010", "2011" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } },
                        new DimensionFilter{ DimensionID = "3", AttributeIDs = new List<string>{ "M" } },
                    }
                },
                new DataSerieValues { 
                    Value = 4, 
                    AxisDimension = new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "F" } },
                    SelectedDimensions = new DimensionFilter[] {
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2010", "2011" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } },
                        new DimensionFilter{ DimensionID = "3", AttributeIDs = new List<string>{ "F" } },
                    }
                }
            };
            DataSerie actual = target.GetDataSerie(sourceid, indicatorid, axisDimension, selectedDimensions);
            Assert.AreEqual(expectedValues, actual.Values);
        }

        /// <summary>
        ///A test for GetMetadata
        ///</summary>
        [TestMethod()]
        public void GetMetadataTest()
        {
            DefaultStatisticsProxyImpl target = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
            int sourceid = 1;
            int indicatorid = 1;
            IndicatorMetadata expected = metadata;
            IndicatorMetadata actual = target.GetMetadata(sourceid, indicatorid);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for JoinFilters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("StatisticsProxyImpl.dll")]
        public void JoinFiltersTest()
        {
            DefaultStatisticsProxyImpl proxy = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
            PrivateObject param0 = new PrivateObject(proxy);
            DefaultStatisticsProxyImpl_Accessor target = new DefaultStatisticsProxyImpl_Accessor(param0);

            IEnumerable<DimensionFilter> selected = new DimensionFilter[]{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } }
            };
            DimensionFilter axis = new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } };

            List<DimensionFilter> expected = new List<DimensionFilter>{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } }
            };

            List<DimensionFilter> actual = target.JoinFilters(selected, axis);
            Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(expected, actual));
        }

        /// <summary>
        ///A test for JoinFilters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("StatisticsProxyImpl.dll")]
        public void JoinFiltersWithAxisDimensionAtSelectedValuesTest()
        {
            DefaultStatisticsProxyImpl proxy = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
            PrivateObject param0 = new PrivateObject(proxy);
            DefaultStatisticsProxyImpl_Accessor target = new DefaultStatisticsProxyImpl_Accessor(param0);

            IEnumerable<DimensionFilter> selected = new DimensionFilter[]{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } }
            };
            DimensionFilter axis = new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } };

            List<DimensionFilter> expected = new List<DimensionFilter>{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } }
            };

            List<DimensionFilter> actual = target.JoinFilters(selected, axis);
            Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(expected, actual));
        }

        /// <summary>
        ///A test for JoinFilters
        ///</summary>
        [TestMethod()]
        [DeploymentItem("StatisticsProxyImpl.dll")]
        public void JoinFiltersWithSomeAxisDimensionAtSelectedValuesTest()
        {
            DefaultStatisticsProxyImpl proxy = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
            PrivateObject param0 = new PrivateObject(proxy);
            DefaultStatisticsProxyImpl_Accessor target = new DefaultStatisticsProxyImpl_Accessor(param0);

            IEnumerable<DimensionFilter> selected = new DimensionFilter[]{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2" } }
            };
            DimensionFilter axis = new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } };

            List<DimensionFilter> expected = new List<DimensionFilter>{
                new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
                new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } }
            };

            List<DimensionFilter> actual = target.JoinFilters(selected, axis);
            Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(expected, actual));
        }
    }
}
