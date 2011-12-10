using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProviderDataContracts.Metadata;
using System.ServiceModel;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;

namespace ProviderServiceInterface
{
    [ServiceContract]
    public interface IStatisticsProvider
    {
        [OperationContract] 
        IndicatorMetadata GetMetadata(string indicatorId);

        [OperationContract]
        List<IndicatorValue> GetValues(string indicatorId, List<DimensionFilter> filters);
    }
}
