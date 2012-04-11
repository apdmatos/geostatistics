using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderDataContracts.Metadata;
using System.ServiceModel.Web;
using StatisticsProxyServiceDefenitions.data_models;

namespace RestService
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
    }
}
