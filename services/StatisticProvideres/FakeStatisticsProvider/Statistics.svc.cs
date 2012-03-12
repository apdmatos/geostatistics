using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderDataContracts.Filters;
using ProviderDataContracts.Values;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Metadata.Provider_Interfaces;

namespace FakeStatisticsProvider
{
    public class Statistics : IStatisticsProvider
    {
        public IndicatorMetadata GetMetadata(string indicatorId)
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
                    Name = "Ano",
                    NameAbbr = "Ano",
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

            return new IndicatorMetadata { 
                ID = "1",
                IndicatorName = "Fake indicator",
                IndicatorNameAbbr = "Fake",
                LastUpdate = DateTime.Now,
                SourceName = "Fake indicators provider",
                SourceNameAbbr = "FIP",
                SourceURL = "http://nowhere.com",
                Dimensions = dimensions
            };

        }

        public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters)
        {
            Random r = new Random();
            List<IndicatorValue> values = new List<IndicatorValue>();
            int deep = filters.Count();
            int currDeep = 0;

            Dictionary<int, int> index = new Dictionary<int,int>();
            Dictionary<int, string> currAttributes = new Dictionary<int,string>();
            do{

                while(currDeep != deep){

                    if (!index.ContainsKey(currDeep)) index.Add(currDeep, 0);

                    int idx = index[currDeep];

                    if(!currAttributes.ContainsKey(currDeep)) 
                        currAttributes.Add(currDeep, string.Empty);

                    currAttributes[currDeep] = filters.ElementAt(currDeep).AttributeIDs.ElementAt(idx);
                    ++currDeep;
                }

                // adjust indexes
                for (int i = deep - 1; i >= 0; --i)
                {
                    ++index[i];
                    int idx = index[i];
                    if (idx >= filters.ElementAt(i).AttributeIDs.Count() && i != 0)
                        index[i] = 0;
                    else break;
                }

                currDeep = 0;

                // generate indicator value
                List<DimensionFilter> responseFilter = new List<DimensionFilter>();
                for (int i = 0; i < deep; i++)
                {
                    responseFilter.Add(new DimensionFilter
                    {
                        DimensionID = filters.ElementAt(i).DimensionID,
                        AttributeIDs = new List<string> { currAttributes[i] }
                    });
                }
                values.Add(new IndicatorValue { 
                    Value = r.Next(100),
                    Filters = responseFilter
                });

            } while(index[0] < filters.First().AttributeIDs.Count());


            return values;
        }
    }
}
