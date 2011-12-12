using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderDataContracts.Metadata;
using System.ServiceModel.Web;
using System.Web.Script.Services;
using ProviderDataContracts.Filters;

namespace StatisticsService
{
    [ServiceContract]
    public interface IStatistics
    {
        [OperationContract]
        //[WebGet(ResponseFormat=WebMessageFormat.Json, UriTemplate="sourceid={sourceid}&indicatorid={indicatorid}")]
        IndicatorMetadata GetMetadata(string sourceid, string indicatorid);

        [OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "sourceid={sourceid}&indicatorid={indicatorid}")]
        DataSerie GetDataSerie(string sourceid, string indicatorid, DimensionFilter axisDimension, List<DimensionFilter> selectedDimensions);
    }

    [DataContract]
    public class DataSerie
    {
        [DataMember]
        public Location Location { get; set; }

        [DataMember]
        public IEnumerable<DataSerieValues> Values { get; set; }
    }

    [DataContract]
    public class DataSerieValues 
    {
        [DataMember]
        public double Value { get; set; }

        [DataMember]
        public DimensionFilter AxisDimension { get; set; }

        [DataMember]
        public IEnumerable<DimensionFilter> SelectedDimensions { get; set; }
    }

    [DataContract]
    public class Location
    {
        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }
    }
}
