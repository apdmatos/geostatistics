using INEProvider;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using ProviderDataContracts.Values;
using Moq;
using INEProvider.factory;
using INEProvider.INEService;
using System.Linq;

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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for INEStatisticsProvider Constructor
        ///</summary>
        [TestMethod()]
        public void INEStatisticsProviderConstructorTest()
        {
            INEStatisticsProvider target = new INEStatisticsProvider(null);
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for GetMetadata
        ///</summary>
        [TestMethod()]
        public void GetMetadataTest()
        {
            //var lastupdate = DateTime.Now.ToShortDateString();
            //Metadata ineMetadata = new Metadata
            //{
            //    Designation = "Indicator 1",
            //    Abbreviation = "I1",
            //    TimeDimension = new TimeDimension
            //    {
            //        Code = "T1",
            //        Designation = "Time dimension",
            //        Abbreviation = "TD",
            //        Periods = new List<Period>{
            //            new Period { Code= "1", Designation = "2010" }
            //        }
            //    },
            //    GeoDimension = new INEService.Dimension
            //    {
            //        Code = "Geo1",
            //        Designation = "Dimensao geografica",
            //        Abbreviation = "DG",
            //        ClassificationCode = "00320",
            //        LowestClassificationLevel = 2
            //    },
            //    Url = "http://nowhere.com",
            //    IndicatorUrl = "http://nowhere.com",
            //    DataLastUpdate = lastupdate
            //};
            //Mock<StatisticsClient> ineMock = new Mock<StatisticsClient>();
            //ineMock.Setup(m => m.GetMetadata(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>())).Returns(ineMetadata);

            //Mock<IStatisticsClientProxyFactory> factoryMock = new Mock<IStatisticsClientProxyFactory>();
            //factoryMock.Setup(m => m.CreateStatisticsClient()).Returns(ineMock.Object);


            //INEStatisticsProvider target = new INEStatisticsProvider(factoryMock.Object);
            //string indicatorId = "1";
            //IndicatorMetadata expected = new IndicatorMetadata
            //{
            //    ID = indicatorId,
            //    IndicatorName = "Indicator 1",
            //    IndicatorNameAbbr = "I1",
            //    Dimensions = new List<ProviderDataContracts.Metadata.Dimension>
            //    {
            //        new ProviderDataContracts.Metadata.Dimension { 
            //            ID = "1", 
            //            DimensionType = DimensionType.Temporal, 
            //            Name = "Time dimension",
            //            NameAbbr = "TD",
            //            Attributes = new List<DimensionAttribute> {
            //                new DimensionAttribute { ID = "1", Name = "2010" }
            //            }
            //        }, 
            //        new ProviderDataContracts.Metadata.Dimension { 
            //            ID = "2", 
            //            DimensionType = DimensionType.Geographic, 
            //            Name = "Dimensao geografica",
            //            NameAbbr = "DG",
            //            Attributes = new List<DimensionAttribute> {
            //                new GeoAttributeHierarchy { 
            //                    ID = "NUTS1",
            //                    Level = 2,
            //                    Name = "NUTS 1"
            //                }
            //            }
            //        }
            //    },
            //    LastUpdate = DateTime.Parse(lastupdate),
            //    SourceName = "Instituto Nacional de Estatísticas",
            //    SourceNameAbbr = "INE",
            //    SourceURL = "http://nowhere.com"
            //};
            //IndicatorMetadata actual = target.GetMetadata(indicatorId);
            //Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetValues
        ///</summary>
        [TestMethod()]
        public void GetValuesTest()
        {
            //INEService.IndicatorValues ineValues = new INEService.IndicatorValues
            //{
            //    IndicatorValueList = new List<INEService.IndicatorValue> {
            //        new INEService.IndicatorValue{
            //            Value = 1,
            //            IndicatorCode = "1",
            //            Dimensions = new List<INEProvider.INEService.DimensionFilter>
            //            {
            //                new INEProvider.INEService.DimensionFilter { Order = 1, Codes = new ArrayOfDimensionCode { "S7A2010" } },
            //                new INEProvider.INEService.DimensionFilter { Order = 2, Codes = new ArrayOfDimensionCode { "1" } },
            //            }
            //        }
            //    }
            //};

            //Mock<StatisticsClient> ineMock = new Mock<StatisticsClient>();
            //ineMock.Setup(m => m.GetValues(
            //    It.IsAny<string>(),
            //    It.IsAny<List<INEProvider.INEService.DimensionFilter>>(),
            //    It.IsAny<ValuesReturnType>(),
            //    It.IsAny<string>(),
            //    It.IsAny<int>(),
            //    It.IsAny<int>())).Returns(ineValues);

            //Mock<IStatisticsClientProxyFactory> factoryMock = new Mock<IStatisticsClientProxyFactory>();
            //factoryMock.Setup(m => m.CreateStatisticsClient()).Returns(ineMock.Object);


            //INEStatisticsProvider target = new INEStatisticsProvider(factoryMock.Object);
            //string indicatorId = "1";
            //IEnumerable<ProviderDataContracts.Filters.DimensionFilter> filters = null;
            //IEnumerable<ProviderDataContracts.Values.IndicatorValue> expected = new List<ProviderDataContracts.Values.IndicatorValue> {
            //    new ProviderDataContracts.Values.IndicatorValue
            //    {
            //        Value = 1,
            //        Filters = new List<ProviderDataContracts.Filters.DimensionFilter> { 
            //            new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "1", AttributeIDs = new List<string> { "S7A2010" } },
            //            new ProviderDataContracts.Filters.DimensionFilter { DimensionID = "2", AttributeIDs = new List<string> { "1" } }
            //        }
            //    }
            //};
            //IEnumerable<ProviderDataContracts.Values.IndicatorValue> actual = target.GetValues(indicatorId, filters);
            //Assert.IsTrue(Enumerable.SequenceEqual<ProviderDataContracts.Values.IndicatorValue>(expected, actual));
        }
    }
}
