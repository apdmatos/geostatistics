using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderDataContracts.Metadata;
using System.ServiceModel.Web;
using StatisticsProxyServiceDefenitions.data_models;
using ProviderDataContracts.Values;

namespace StatisticsServices.RestService
{
    [ServiceContract]
    public interface IStatistics
    {
        [OperationContract]
        [WebGet(
            UriTemplate="Metadata?sourceid={sourceid}&indicatorid={indicatorid}", 
            ResponseFormat=WebMessageFormat.Json)]
        IndicatorMetadata GetMetadata(int sourceid, int indicatorid);

        [OperationContract]
        [WebGet(
            UriTemplate = "GetIndicatorValues?sourceid={sourceid}&indicatorid={indicatorid}&filterDimensions={filterDimensions}&projectedDimensions={projectedDimensions}",
            ResponseFormat = WebMessageFormat.Json)]
        IndicatorValues GetIndicatorValues(int sourceid, int indicatorid, string filterDimensions, string projectedDimensions);

        [OperationContract]
        [WebGet(
            UriTemplate = "GetIndicatorRange?sourceid={sourceid}&indicatorid={indicatorid}&filterDimensions={filterDimensions}&projectedDimensions={projectedDimensions}&shapeLevel={shapeLevel}",
            ResponseFormat = WebMessageFormat.Json)]
        IndicatorValueRange GetIndicatorValuesRange(int sourceid, int indicatorid, string filterDimensions, string projectedDimensions, string shapeLevel);

        [OperationContract]
        [WebGet(
            UriTemplate = "Attributes?sourceid={sourceid}&indicatorid={indicatorid}&dimensionid={dimensionid}&attributeRootid={attributeRootid}&level={level}",
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<DimensionAttribute> GetAttributes(int sourceid, int indicatorid, string dimensionid, string attributeRootid, int level);
    }
}
