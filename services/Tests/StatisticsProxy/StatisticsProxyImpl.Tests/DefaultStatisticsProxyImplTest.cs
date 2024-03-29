﻿using StatisticsProxyImpl;
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
                        new HierarchyAttribute { 
                            ID = "PT",
                            Name = "Portugal",
                            LazyLoad = true
                        }
                    },
                    AggregationLevels = new List<AggregationLevel> {
                        new AggregationLevel { ID = "Districts", Level = 1, Name = "Distritos" },
                        new AggregationLevel { ID = "Municipalities", Level = 2, Name = "Municipios" }
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

            values = new IndicatorValue[] {
                new IndicatorValue { 
                    Value = 2, 
                    Projected = new DimensionFilter[] {
                        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "M" } }
                    },
                    Filters = new DimensionFilter[] {
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2010", "2011" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } }
                    }
                },
                new IndicatorValue { 
                    Value = 4, 
                    Projected = new DimensionFilter[] {
                        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "F" } }
                    },
                    Filters = new DimensionFilter[] {
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2010", "2011" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } }
                    }
                }
            };

            var requesterMock = new Mock<IStatisticsRequestStrategy>();
            requesterMock.Setup(m => m.GetMetadata(It.IsAny<string>())).Returns(metadata);
            requesterMock.Setup(m => m.GetValues(It.IsAny<string>(), It.IsAny<IEnumerable<DimensionFilter>>(), It.IsAny<IEnumerable<DimensionFilter>>())).Returns(values);

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
        public void GetDataProjectedBySpecifiedDimensionTest()
        {
            DefaultStatisticsProxyImpl target = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
            int sourceid = 1;
            int indicatorid = 1;
            IEnumerable<DimensionFilter> projectedDimensions = new DimensionFilter[]
            { 
                new DimensionFilter{ DimensionID = "3", AttributeIDs = new string[]{ "M", "F" } }
            };
            IEnumerable<DimensionFilter> filterDimensions = new DimensionFilter[]
            { 
                new DimensionFilter{ DimensionID = "1", AttributeIDs = new string[]{ "2010", "2011" } },
                new DimensionFilter{ DimensionID = "2", AttributeIDs = new string[]{ "PT" } }
            };

            IEnumerable<IndicatorValue> expectedValues = new IndicatorValue[] {
                new IndicatorValue { 
                    Value = 2, 
                    Projected = new DimensionFilter[] {
                        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "M" } }
                    },
                    Filters = new DimensionFilter[] {
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2010", "2011" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } }
                    }
                },
                new IndicatorValue { 
                    Value = 4, 
                    Projected = new DimensionFilter[] {
                        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "F" } }
                    },
                    Filters = new DimensionFilter[] {
                        new DimensionFilter{ DimensionID = "1", AttributeIDs = new List<string>{ "2010", "2011" } },
                        new DimensionFilter{ DimensionID = "2", AttributeIDs = new List<string>{ "PT" } }
                    }
                }
            };
            IndicatorValues actual = target.GetIndicatorValues(sourceid, indicatorid, filterDimensions, projectedDimensions);
            Assert.IsTrue(Enumerable.SequenceEqual<IndicatorValue>(expectedValues, actual.Values));
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

        ///// <summary>
        /////A test for AddSelectedDimensions
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("StatisticsProxyImpl.dll")]
        //public void AddSelectedDimensionsTest()
        //{
        //    //DefaultStatisticsProxyImpl proxy = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
        //    //PrivateObject param0 = new PrivateObject(proxy);
        //    //DefaultStatisticsProxyImpl_Accessor target = new DefaultStatisticsProxyImpl_Accessor(param0);
        //    //Dictionary<string, Dictionary<string, DefaultStatisticsProxyImpl_Accessor.DimensionAttributesHelper>> selectedDimensionsHelper = new Dictionary<string, Dictionary<string, DefaultStatisticsProxyImpl_Accessor.DimensionAttributesHelper>>();
        //    //DimensionFilter axisDimension = new DimensionFilter
        //    //{
        //    //    AttributeIDs = new List<string> { "1" },
        //    //    DimensionID = "1"
        //    //};

        //    //var filters = new List<DimensionFilter>{ 
        //    //    new DimensionFilter { AttributeIDs = new List<string>{ "1" }, DimensionID = "1" },
        //    //    new DimensionFilter { AttributeIDs = new List<string>{ "1" }, DimensionID = "2" },
        //    //    new DimensionFilter { AttributeIDs = new List<string>{ "1" }, DimensionID = "3" }
        //    //};

        //    //target.AddSelectedDimensions(selectedDimensionsHelper, axisDimension, filters);

        //    //IEnumerable<DimensionFilter> expectedValues = new List<DimensionFilter>{ 
        //    //    new DimensionFilter { AttributeIDs = new List<string>{ "1" }, DimensionID = "1" },
        //    //    new DimensionFilter { AttributeIDs = new List<string>{ "1" }, DimensionID = "2" },
        //    //    new DimensionFilter { AttributeIDs = new List<string>{ "1" }, DimensionID = "3" }
        //    //}; ;

        //    //Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(expectedValues, filters));
        //    //Assert.Equals(selectedDimensionsHelper.Keys.Count(), 1);
        //    //Assert.Equals(selectedDimensionsHelper["1"].Keys.Count(), 3);
        //    //Assert.Equals(selectedDimensionsHelper["1"]["1"].AttributesEnumerable.Count(), 1);

        //    Assert.Inconclusive("TODO: Implement code to verify target");
        //}

        ///// <summary>
        /////A test for JoinFilters
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("StatisticsProxyImpl.dll")]
        //public void JoinFiltersTest()
        //{
        //    DefaultStatisticsProxyImpl proxy = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
        //    PrivateObject param0 = new PrivateObject(proxy);
        //    DefaultStatisticsProxyImpl_Accessor target = new DefaultStatisticsProxyImpl_Accessor(param0);

        //    IEnumerable<DimensionFilter> selected = new DimensionFilter[]{
        //        new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } }
        //    };
        //    DimensionFilter axis = new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } };

        //    List<DimensionFilter> expected = new List<DimensionFilter>{
        //        new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } }
        //    };

        //    List<DimensionFilter> actual = target.JoinFilters(selected, axis);
        //    Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(expected, actual));
        //}

        ///// <summary>
        /////A test for JoinFilters
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("StatisticsProxyImpl.dll")]
        //public void JoinFiltersWithAxisDimensionAtSelectedValuesTest()
        //{
        //    DefaultStatisticsProxyImpl proxy = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
        //    PrivateObject param0 = new PrivateObject(proxy);
        //    DefaultStatisticsProxyImpl_Accessor target = new DefaultStatisticsProxyImpl_Accessor(param0);

        //    IEnumerable<DimensionFilter> selected = new DimensionFilter[]{
        //        new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } }
        //    };
        //    DimensionFilter axis = new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } };

        //    List<DimensionFilter> expected = new List<DimensionFilter>{
        //        new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } }
        //    };

        //    List<DimensionFilter> actual = target.JoinFilters(selected, axis);
        //    Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(expected, actual));
        //}

        ///// <summary>
        /////A test for JoinFilters
        /////</summary>
        //[TestMethod()]
        //[DeploymentItem("StatisticsProxyImpl.dll")]
        //public void JoinFiltersWithSomeAxisDimensionAtSelectedValuesTest()
        //{
        //    DefaultStatisticsProxyImpl proxy = new DefaultStatisticsProxyImpl(configKey, indicatorRepository, factory);
        //    PrivateObject param0 = new PrivateObject(proxy);
        //    DefaultStatisticsProxyImpl_Accessor target = new DefaultStatisticsProxyImpl_Accessor(param0);

        //    IEnumerable<DimensionFilter> selected = new DimensionFilter[]{
        //        new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2" } }
        //    };
        //    DimensionFilter axis = new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } };

        //    List<DimensionFilter> expected = new List<DimensionFilter>{
        //        new DimensionFilter { DimensionID = "1", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "2", AttributeIDs = new string[] { "1", "2" } },
        //        new DimensionFilter { DimensionID = "3", AttributeIDs = new string[] { "2", "3" } }
        //    };

        //    List<DimensionFilter> actual = target.JoinFilters(selected, axis);
        //    Assert.IsTrue(Enumerable.SequenceEqual<DimensionFilter>(expected, actual));
        //}
    }
}
