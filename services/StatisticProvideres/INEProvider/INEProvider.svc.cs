using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderServiceInterface;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;

namespace INEProvider
{
    public class INEProvider : IStatisticsProvider
    {

        public IndicatorMetadata GetMetadata(string indicatorId)
        {
            throw new NotImplementedException();
        }

        public List<IndicatorValue> GetValues(string indicatorId, List<DimensionFilter> filters)
        {
            throw new NotImplementedException();
        }
    }
}
