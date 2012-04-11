using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;

namespace INEProvider.Helpers
{
    class Aggregator
    {
        private class AggregationHelper 
        { 
            
        }


        public IEnumerable<IndicatorValue> AggregateValues(
            IEnumerable<INEService.IndicatorValue> indicatorValueList, 
            IEnumerable<DimensionFilter> projectedDimensions) 
        {
            //int[] indexes = new int[projectedDimensions.Count()];
            //while (true)
            //{
            //    List<DimensionFilter> projected = new List<DimensionFilter>();
            //    IEnumerable<INEService.IndicatorValue> ineValues = indicatorValueList;
            //    for (int i = 0; i < indexes.Length; i++)
            //    {
            //        projected.Add(new DimensionFilter { 
            //            DimensionID = projectedDimensions.ElementAt(i).DimensionID,
            //            AttributeIDs = new [] { projectedDimensions.ElementAt(i).AttributeIDs.ElementAt(indexes[i]) },
            //        });

            //        ineValues = ineValues.Where(v => v.Dimensions

            //    }
            //}

            //yield break;
        }
    }
}