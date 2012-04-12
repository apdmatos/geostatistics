using System;
using System.Collections.Generic;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;
namespace INEProvider.Aggregator
{
    public interface IAggregator
    {
        IEnumerable<IndicatorValue> AggregateValues(IEnumerable<INEService.IndicatorValue> indicatorValueList, IEnumerable<DimensionFilter> projectedDimensions);
    }
}
