﻿using System;
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
        IndicatorMetadata GetMetadata(string sourceid, string indicatorid);

        [OperationContract]
        [WebGet(
            UriTemplate = "DataSerie?sourceid={sourceid}&indicatorid={indicatorid}&axisDimension={axisDimension}&selectedDimensions={selectedDimensions}", 
            ResponseFormat = WebMessageFormat.Json)]
        DataSerie GetDataSerie(string sourceid, string indicatorid, string axisDimension, string selectedDimensions);
    }
}