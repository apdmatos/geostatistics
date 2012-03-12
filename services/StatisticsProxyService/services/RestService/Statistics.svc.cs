﻿using ProviderDataContracts.Metadata;
using StatisticsProxyServiceDefenitions.data_models;
using StatisticsProxyServiceDefenitions.interfaces;
using RestService.parameters_parser;
using ProviderDataContracts.Filters;
using System.Collections.Generic;
using System.ServiceModel.Activation;

namespace RestService
{
    // TODO: Ver isto
    // JSONP
    // http://jasonkelly.net/2009/05/using-jquery-jsonp-for-cross-domain-ajax-with-wcf-services/
    // Testar complex objects com jsonp
    // Ver se consegue ler com uri template
    // -------- 
    // Formato axis: id,attrid1,attrid2,attrid3
    // Formato dimensions: id,attrid1,attrid2#id,attr1,attr2,...
    public class Statistics : IStatistics
    {
        private IURLParametersParser parser;
        private IStatisticsProxyService service;

        public Statistics(IURLParametersParser parser, IStatisticsProxyService service)
        {
            this.parser = parser;
            this.service = service;
        }

        public IndicatorMetadata GetMetadata(int sourceid, int indicatorid)
        {
            return service.GetMetadata(sourceid, indicatorid);
        }

        public DataSerie GetDataSerie(int sourceid, int indicatorid, string axisDimension, string selectedDimensions)
        {
            DimensionFilter axis = parser.ParseDimensionFilter(axisDimension);
            IEnumerable<DimensionFilter> selected = parser.ParseDimensionFilterList(selectedDimensions);

            return service.GetDataSerie(sourceid, indicatorid, axis, selected);
        }
    }
}
