using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StatisticsProxyServiceDefenitions.data_models;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Filters;
using StatisticsProxyServiceDefenitions.interfaces;
using StatisticsServices.RestService.parameters_parser;

namespace StatisticsServices.RestService
{
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

        public IndicatorValues GetIndicatorValues(int sourceid, int indicatorid, string filterDimensions, string projectedDimensions)
        {
            IEnumerable<DimensionFilter> filters = filterDimensions != null ? parser.ParseDimensionFilterList(filterDimensions) : null;
            IEnumerable<DimensionFilter> projected = projectedDimensions != null ? parser.ParseDimensionFilterList(projectedDimensions) : null;

            return service.GetIndicatorValues(sourceid, indicatorid, filters, projected);
        }
    }
}