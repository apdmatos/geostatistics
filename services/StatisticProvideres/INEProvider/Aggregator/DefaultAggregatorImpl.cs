using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;
using System.Text;
using INEProvider.Extensions.INE2Provider;
namespace INEProvider.Aggregator
{
    class DefaultAggregatorImpl : IAggregator
    {
        public IEnumerable<IndicatorValue> AggregateValues(IEnumerable<INEService.IndicatorValue> indicatorValueList, IEnumerable<DimensionFilter> projectedDimensions) 
        {
            if (projectedDimensions == null || projectedDimensions.Count() == 0) 
                return indicatorValueList.ToIndicatorValueEnumerable();

            Dictionary<string, IndicatorValue> indicatorValues = new Dictionary<string, IndicatorValue>();
            foreach (var value in indicatorValueList)
            {
                IEnumerable<DimensionFilter> projected = GetDimensionFilters(value, projectedDimensions, (filter) => filter != null).ToList();
                IEnumerable<DimensionFilter> filtered = GetDimensionFilters(value, projectedDimensions, (filter) => filter == null).ToList();

                string projectedDimensionsKey = GetAggregatorKey(projected);
                if (!indicatorValues.ContainsKey(projectedDimensionsKey))
                {
                    indicatorValues.Add(projectedDimensionsKey, new IndicatorValue
                    {
                        Value = 0,
                        Filters = filtered,
                        Projected = projected
                    });
                }
                else 
                {
                    indicatorValues[projectedDimensionsKey].Value += (double)value.Value;
                    JoinFilters(indicatorValues[projectedDimensionsKey].Filters, filtered);
                }
            }

            return indicatorValues.Values;
        }

        private delegate bool Evaluate(DimensionFilter d);
        private IEnumerable<DimensionFilter> GetDimensionFilters(INEService.IndicatorValue value, IEnumerable<DimensionFilter> projectedDimensions, Evaluate eval) 
        {
            foreach (var d in value.Dimensions)
            {
                DimensionFilter filter = projectedDimensions.Where(proj => d.Order.ToString() == proj.DimensionID).FirstOrDefault();
                if (eval(filter)) yield return d.ToDimensionFilter();
            }

            yield break;
        }

        private string GetAggregatorKey(IEnumerable<DimensionFilter> filters)
        {
            StringBuilder builder = new StringBuilder();
            IEnumerable<DimensionFilter> sortedFilters = filters.OrderBy(d => d.DimensionID);
            foreach (var filter in sortedFilters)
            {
                builder.Append(filter.DimensionID);
                foreach (var attr in filter.AttributeIDs)
                    builder.Append(attr);
            }

            return builder.ToString();
        }

        private void JoinFilters(IEnumerable<DimensionFilter> dest, IEnumerable<DimensionFilter> source) 
        {
            foreach (var sourceFilter in source)
            {
                var destFilter = dest.Where(f => f.DimensionID == sourceFilter.DimensionID).FirstOrDefault();
                if (destFilter.AttributeIDs.ElementAt(0) != sourceFilter.AttributeIDs.ElementAt(0))
                    destFilter.AttributeIDs = destFilter.AttributeIDs.Concat(sourceFilter.AttributeIDs).Distinct().ToList();
            }
        }
    }
}