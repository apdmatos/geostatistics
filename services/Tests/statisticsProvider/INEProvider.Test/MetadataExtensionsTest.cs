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
    ///This is a test class for MetadataExtensionsTest and is intended
    ///to contain all MetadataExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MetadataExtensionsTest
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
        ///A test for ToIndicatorMetadata
        ///</summary>
        [TestMethod()]
        public void ToIndicatorMetadataTest()
        {
            var lastupdate = DateTime.Now.ToShortDateString();

            Metadata metadata = new Metadata
            {
                Designation = "Indicator 1",
                Abbreviation = "I1",
                TimeDimension = new TimeDimension {
                    Code = "T1",
                    Designation = "Time dimension",
                    Abbreviation = "TD",
                    Periods = new List<Period>{
                        new Period { Code= "1", Designation = "2010" }
                    }
                },
                GeoDimension = new INEService.Dimension {
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
            IndicatorMetadata actual = MetadataExtensions.ToIndicatorMetadata(metadata, indicatorId);
            Assert.AreEqual(expected, actual);
        }
    }
}
