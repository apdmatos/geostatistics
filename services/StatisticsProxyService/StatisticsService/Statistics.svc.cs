using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderDataContracts.Metadata;
using ProviderServiceInterface;
using ProviderDataContracts.Filters;
using ProviderDataContracts.Values;

namespace StatisticsService
{
    // JSONP
    // http://jasonkelly.net/2009/05/using-jquery-jsonp-for-cross-domain-ajax-with-wcf-services/
    // Testar complex objects com jsonp
    // Ver se consegue ler com uri template
    // -------- 
    // Formato axis: id,attrid1,attrid2,attrid3
    // Formato dimensions: id,attrid1,attrid2#id,attr1,attr2,...
    public class Statistics : IStatistics
    {
        string endpoint = "http://localhost:9606/Statistics.svc";
        
        public IndicatorMetadata GetMetadata(string sourceid, string indicatorid)
        {
            ChannelFactory<IStatisticsProvider> channel = new ChannelFactory<IStatisticsProvider>(
                    "providerConfiguration",
                    new EndpointAddress(endpoint));
            IndicatorMetadata metadata = null;

            try
            {
                IStatisticsProvider provider = channel.CreateChannel();
                metadata = provider.GetMetadata(indicatorid);
                metadata.SourceID = sourceid;
            }
            finally {
                channel.Close();
            }

            return metadata;
        }

        public DataSerie GetDataSerie(string sourceid, string indicatorid, DimensionFilter axisDimension, List<DimensionFilter> selectedDimensions)
        {

            DataSerie serie = null;
            ChannelFactory<IStatisticsProvider> channel = new ChannelFactory<IStatisticsProvider>(
                    "providerConfiguration",
                    new EndpointAddress(endpoint));

            try
            {
                IStatisticsProvider provider = channel.CreateChannel();
                
                //join filters
                List<DimensionFilter> filters = JoinFilters(selectedDimensions, axisDimension);
                
                // get values
                IEnumerable<IndicatorValue> values = provider.GetValues(indicatorid, filters);

                // group values
                Dictionary<string, DataSerieValues> groupedValues = new Dictionary<string, DataSerieValues>();
                foreach (var value in values)
                {
                    DimensionFilter axisFilter = value.Filters.Where(f => f.DimensionID == axisDimension.DimensionID).FirstOrDefault();
                    string axisAttributeId = axisFilter.AttributeIDs.First();
                    if (!groupedValues.ContainsKey(axisFilter.DimensionID))
                    {
                        DataSerieValues dataSerie = new DataSerieValues { 
                            Value = 0,
                            AxisDimension = axisFilter,
                            SelectedDimensions = value.Filters
                        };

                        groupedValues.Add(axisAttributeId, dataSerie);
                    }

                    groupedValues[axisAttributeId].Value += value.Value;
                }


                serie = new DataSerie { 
                    Values = groupedValues.Values.ToList()
                };

            }
            finally
            {
                channel.Close();
            }


            return serie;
        }

        private List<DimensionFilter> JoinFilters(List<DimensionFilter> selected, DimensionFilter axis)
        {

            bool merged = false;
            List<DimensionFilter> filters = new List<DimensionFilter>();
            foreach (var filter in selected)
            {
                if (filter.DimensionID == axis.DimensionID)
                {
                    IEnumerable<string> distinctValues = filter.AttributeIDs.Concat(axis.AttributeIDs).Distinct();
                    List<string> attrs = new List<string>(distinctValues);

                    filters.Add(new DimensionFilter { 
                        AttributeIDs = attrs,
                        DimensionID = filter.DimensionID
                    });

                    merged = true;
                }
                else
                    filters.Add(filter);
            }

            if (!merged) {
                filters.Add(axis);
            }

            return filters;
        }
    }
}
