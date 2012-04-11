using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Filters;

namespace RestService.parameters_parser
{
    class URLParameterDefaultImpl : IURLParametersParser
    {
        /// <summary>
        /// Converts a string into a DimensionFilter list
        /// </summary>
        /// <param name="dimensionsFilter">
        ///     Parameter should have the following format:
        ///     id,attrid1,attrid2#id,attr1,attr2,...
        /// </param>
        /// <returns>A dimension filter list</returns>
        public IEnumerable<DimensionFilter> ParseDimensionFilterList(string dimensionsFilter)
        {
            string[] filters = dimensionsFilter.Split('#');
            foreach (var filter in filters)
                yield return ParseDimensionFilter(filter);

            yield break;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dimensionFilter">
        ///     Parameter should have the following format:
        ///     id,attrid1,attrid2
        /// </param>
        /// <returns></returns>
        public DimensionFilter ParseDimensionFilter(string dimensionFilter)
        {
            if (dimensionFilter == null) return null;

            string[] filter = dimensionFilter.Split(',');

            return new DimensionFilter { 
                DimensionID = filter[0],
                AttributeIDs = filter.Skip(1).ToList(),
            };
        }
    }
}