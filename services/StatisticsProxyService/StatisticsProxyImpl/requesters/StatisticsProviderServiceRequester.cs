using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;
using System.ServiceModel;
using ProviderDataContracts.Metadata.Provider_Interfaces;

namespace StatisticsProxyImpl.requesters
{
    public class StatisticsProviderServiceRequester : IStatisticsRequestStrategy
    {
        
        public StatisticsProviderServiceRequester(string endpoint, string configurationKey)
        {
            _endpoint = endpoint;
            _configKey = configurationKey;
        }

        public IndicatorMetadata GetMetadata(string indicatorId)
        {
            return GetChannel().GetMetadata(indicatorId);
        }

        public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters, IEnumerable<DimensionFilter> projected)
        {
            return GetChannel().GetValues(indicatorId, filters, projected);
        }

        public IndicatorValueRange GetValuesRange(string indicatorId, IEnumerable<DimensionFilter> filters, IEnumerable<DimensionFilter> projected, string shapeLevel)
        {
            return GetChannel().GetIndicatorValuesRange(indicatorId, filters, projected, shapeLevel);
        }

        public IEnumerable<DimensionAttribute> GetAttributes(string indicatorId, string dimensionId, string attributeRootId, int level)
        {
            return GetChannel().GetAttributes(indicatorId, dimensionId, attributeRootId, level);
        }

        public void Dispose()
        {
            if (_channel != null) _channel.Close();
        }

        private IStatisticsProvider GetChannel()
        {

            if (_provider == null)
            {
                _channel = new ChannelFactory<IStatisticsProvider>(
                   _configKey,
                   new EndpointAddress(_endpoint));

                _provider = _channel.CreateChannel();
            }

            return _provider;
        }

        private ChannelFactory<IStatisticsProvider> _channel;
        private IStatisticsProvider _provider;

        private string _endpoint;
        private string _configKey;
    }
}
