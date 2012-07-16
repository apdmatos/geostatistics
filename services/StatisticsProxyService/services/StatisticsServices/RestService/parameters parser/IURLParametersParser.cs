using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Filters;

namespace StatisticsServices.RestService.parameters_parser
{
    public interface IURLParametersParser
    {
        IEnumerable<DimensionFilter> ParseDimensionFilterList(string dimensionsFilter);

        DimensionFilter ParseDimensionFilter(string dimensionFilter);
    }
}