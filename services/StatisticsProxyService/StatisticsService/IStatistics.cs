using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderDataContracts.Metadata;
using System.ServiceModel.Web;
using System.Web.Script.Services;

namespace StatisticsService
{
    [ServiceContract]
    public interface IStatistics
    {
        [OperationContract]
        [WebGet(ResponseFormat=WebMessageFormat.Json, UriTemplate="sourceid={sourceid}&indicatorid={indicatorid}")]
        IndicatorMetadata GetMetadata(string sourceid, string indicatorid);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "sourceid={sourceid}&indicatorid={indicatorid}")]
        DataSerie GetDataSerie(string sourceid, string indicatorid, string axisDimension, string selectedDimensions);
    }

    [DataContract]
    public class DataSerie
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        //public List<Dimensions> MyProperty { get; set; }
    }
}
