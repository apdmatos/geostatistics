using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderServiceInterface;
using ProviderDataContracts.Filters;
using ProviderDataContracts.Values;
using ProviderDataContracts.Metadata;

namespace FakeStatisticsProvider
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Statistics" in code, svc and config file together.
    public class Statistics : IStatisticsProvider
    {

        public IndicatorMetadata GetMetadata(string indicatorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters)
        {
            throw new NotImplementedException();
        }
    }
}
