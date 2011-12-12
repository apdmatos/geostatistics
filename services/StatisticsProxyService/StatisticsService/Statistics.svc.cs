using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderDataContracts.Metadata;
using ProviderServiceInterface;

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

        public DataSerie GetDataSerie(string sourceid, string indicatorid, string axisDimension, string selectedDimensions)
        {
            throw new NotImplementedException();
        }
    }
}
