using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using StatisticsProxyServiceDefenitions.data_models;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Filters;

namespace StatisticsProxyServiceDefenitions.interfaces
{
    [ServiceContract]
    public interface IStatisticsProxyService
    {
        [OperationContract]
        IndicatorMetadata GetMetadata(int sourceid, int indicatorid);

        [OperationContract]
        IndicatorValues GetIndicatorValues(int sourceid, int indicatorid, IEnumerable<DimensionFilter> filterDimensions, IEnumerable<DimensionFilter> projectedDimensions);
    }
}
