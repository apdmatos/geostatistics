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
    public interface IStatisticsProxyService
    {
        [OperationContract]
        IndicatorMetadata GetMetadata(int sourceid, int indicatorid);

        [OperationContract]
        DataSerie GetDataSerie(int sourceid, int indicatorid, DimensionFilter axisDimension, IEnumerable<DimensionFilter> selectedDimensions);
    }
}
