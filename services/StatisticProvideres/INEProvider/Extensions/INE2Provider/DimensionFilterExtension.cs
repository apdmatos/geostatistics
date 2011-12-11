using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Filters;

namespace INEProvider.Extensions.INE2Provider
{
    static class DimensionFilterExtension
    {
        public static IEnumerable<DimensionFilter> ToDimensionFilterEnumerable(this IEnumerable<INEService.DimensionFilter> filter)
        {
            foreach (var f in filter)
            {
                yield return f.ToDimensionFilter();
            }

            yield break;
        }

        public static DimensionFilter ToDimensionFilter(this INEService.DimensionFilter filter) 
        {
            List<String> attributes = new List<string>();
            foreach (var code in filter.Codes)
                attributes.Add(code);

            return new DimensionFilter { 
                DimensionID = filter.Order.ToString(),
                AttributeIDs = attributes
            };
        }

    }
}