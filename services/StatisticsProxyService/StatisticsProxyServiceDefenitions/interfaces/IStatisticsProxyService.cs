using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using StatisticsProxyServiceDefenitions.data_models;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Filters;
using ProviderDataContracts.Values;

namespace StatisticsProxyServiceDefenitions.interfaces
{
    [ServiceContract]
    public interface IStatisticsProxyService
    {
        [OperationContract]
        IndicatorMetadata GetMetadata(int sourceid, int indicatorid);

        [OperationContract]
        IndicatorValues GetIndicatorValues(int sourceid, int indicatorid, IEnumerable<DimensionFilter> filterDimensions, IEnumerable<DimensionFilter> projectedDimensions);

        [OperationContract]
        IndicatorValueRange GetIndicatorValuesRange(int sourceid, int indicatorid, IEnumerable<DimensionFilter> filterDimensions, IEnumerable<DimensionFilter> projectedDimensions, String shapeLevel);

        [OperationContract]
        IEnumerable<DimensionAttribute> GetAttributes(int sourceid, int indicatorid, string dimensionid, string attributeRootId, int level);
    }
}
