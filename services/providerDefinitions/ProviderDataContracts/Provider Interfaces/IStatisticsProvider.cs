using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProviderDataContracts.Metadata;
using System.ServiceModel;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;

namespace ProviderDataContracts.Metadata.Provider_Interfaces
{
    [ServiceContract]
    public interface IStatisticsProvider
    {
        [OperationContract] 
        IndicatorMetadata GetMetadata(string indicatorId);

        [OperationContract]
        IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters, IEnumerable<DimensionFilter> projected);

        [OperationContract]
        IndicatorValueRange GetIndicatorValuesRange(string indicatorId, IEnumerable<DimensionFilter> filters, IEnumerable<DimensionFilter> projected, String geographicLevel);

        [OperationContract]
        IEnumerable<DimensionAttribute> GetAttributes(string indicatorId, string dimensionId, string attributeRootId, int level);
    }
}
