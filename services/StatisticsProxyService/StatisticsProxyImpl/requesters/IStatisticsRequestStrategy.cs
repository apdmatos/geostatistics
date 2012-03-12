using System;
using ProviderDataContracts.Metadata;
using System.Collections.Generic;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;
using DataStore.Common.Model;
namespace StatisticsProxyImpl.requesters
{
    public interface IStatisticsRequestStrategy : IDisposable
    {
        IndicatorMetadata GetMetadata(string indicatorId);
        IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters);
    }
}
