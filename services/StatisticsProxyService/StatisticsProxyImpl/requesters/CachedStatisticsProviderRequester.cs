using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;

namespace StatisticsProxyImpl.requesters
{
    //TODO: incompleted...
    public class CachedStatisticsProviderRequester : IStatisticsRequestStrategy
    {
        private IStatisticsRequestStrategy _requester;

        ////TODO: add cache parameter type
        public CachedStatisticsProviderRequester(IStatisticsRequestStrategy requester)
        {
            _requester = requester;
        }

        public IndicatorMetadata GetMetadata(string indicatorId)
        {
            //TODO: Check first on cache
            return _requester.GetMetadata(indicatorId);
        }

        public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters)
        {
            //TODO: Check first on cache
            return _requester.GetValues(indicatorId, filters);
        }

        public void Dispose()
        {
            _requester.Dispose();
        }
    }
}
