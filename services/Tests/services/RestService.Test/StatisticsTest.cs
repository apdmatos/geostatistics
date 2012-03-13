using RestService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using RestService.parameters_parser;
using StatisticsProxyServiceDefenitions.interfaces;
using StatisticsProxyServiceDefenitions.data_models;
using ProviderDataContracts.Metadata;
using System.Collections.Generic;
using Moq;
using ProviderDataContracts.Filters;
using ProviderDataContracts.Values;

namespace RestService.Test
{
    
    
    /// <summary>
    ///This is a test class for StatisticsTest and is intended
    ///to contain all StatisticsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class StatisticsTest
    {


        private TestContext testContextInstance;
        private static IndicatorMetadata metadata;
        private static IEnumerable<DataSerieValues> values;
        private static IStatisticsProxyService serviceImplementation;

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

            values = new DataSerieValues[] {
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

            var mock = new Mock<IStatisticsProxyService>();
            mock.Setup(m => m.GetMetadata(It.IsAny<int>(), It.IsAny<int>())).Returns(metadata);
            mock.Setup(m => m.GetDataSerie(
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<DimensionFilter>(),
                It.IsAny<IEnumerable<DimensionFilter>>())
            ).Returns(new DataSerie { Values = values });

            serviceImplementation = mock.Object;
        }

        /// <summary>
        ///A test for Statistics Constructor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("D:\\ISEL\\Tese\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        //[UrlToTest("http://localhost:36590/Statistics.svc")]
        public void StatisticsConstructorTest()
        {
            IURLParametersParser parser = null;
            IStatisticsProxyService service = null;
            Statistics target = new Statistics(parser, service);
            Assert.AreNotEqual(null, target);
        }

        /// <summary>
        ///A test for GetDataSerie
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("D:\\ISEL\\Tese\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        //[UrlToTest("http://localhost:36590/")]
        public void GetDataSerieTest()
        {

            var mock = new Mock<IURLParametersParser>();
            mock.Setup(m => m.ParseDimensionFilterList(It.IsAny<string>())).Returns(new List<DimensionFilter>());
            mock.Setup(m => m.ParseDimensionFilter(It.IsAny<string>())).Returns(new DimensionFilter());
            
            IURLParametersParser parser = mock.Object;
            Statistics target = new Statistics(parser, serviceImplementation);
            int sourceid = 1;
            int indicatorid = 1;
            string axisDimension = "1,1,2";
            string selectedDimensions = "1,1,2#2,1,2";
            DataSerie expected = new DataSerie { Values = values };
            DataSerie actual = target.GetDataSerie(sourceid, indicatorid, axisDimension, selectedDimensions);
            Assert.AreEqual(expected, actual);

            mock.Verify(m => m.ParseDimensionFilterList(selectedDimensions));
            mock.Verify(m => m.ParseDimensionFilter(axisDimension));
        }

        /// <summary>
        ///A test for GetMetadata
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        //[HostType("ASP.NET")]
        //[AspNetDevelopmentServerHost("D:\\ISEL\\Tese\\src\\services\\StatisticsProxyService\\services\\RestService", "/")]
        //[UrlToTest("http://localhost:36590/")]
        public void GetMetadataTest()
        {
            IURLParametersParser parser = null;
            Statistics target = new Statistics(parser, serviceImplementation);
            int sourceid = 1;
            int indicatorid = 1;
            IndicatorMetadata expected = metadata;
            IndicatorMetadata actual = target.GetMetadata(sourceid, indicatorid);
            Assert.AreEqual(expected, actual);
        }
    }
}
