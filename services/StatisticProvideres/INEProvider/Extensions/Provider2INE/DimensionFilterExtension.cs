﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INEProvider.INEService;

namespace INEProvider.Extensions.Provider2INE
{
    static class DimensionFilterExtension
    {

        public static IEnumerable<DimensionFilter> ToDimensionFilterEnumerable(
            this IEnumerable<ProviderDataContracts.Filters.DimensionFilter> filter)
        {
            foreach (var f in filter)
                yield return f.ToDimensionFilter();

            yield break;
        }

        public static DimensionFilter ToDimensionFilter(this ProviderDataContracts.Filters.DimensionFilter filter)
        {
            ArrayOfDimensionCode codes = new ArrayOfDimensionCode();
            foreach (var attribute in filter.AttributeIDs)
            {
                codes.Add(attribute);
            }

            return new DimensionFilter { 
                Codes = codes,
                Order = int.Parse(filter.DimensionID)
            };
        }

    }
}