using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Values;

namespace INEProvider.Extensions.INE2Provider
{
    static class IndicatorValueExtension
    {

        public static IEnumerable<IndicatorValue> ToIndicatorValueEnumerable(this IEnumerable<INEService.IndicatorValue> ineValues)
        {
            foreach (var value in ineValues)
            {
                yield return value.ToIndicatorValue();
            }

            yield break;
        }

        public static IndicatorValue ToIndicatorValue(this INEService.IndicatorValue inevalue) 
        {
            return new IndicatorValue { 
                Value = Convert.ToDouble(inevalue.Value),
                Filters = inevalue.Dimensions.ToDimensionFilterEnumerable()
            };
        }

    }
}