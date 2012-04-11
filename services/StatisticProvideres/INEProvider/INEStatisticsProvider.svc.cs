using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ProviderDataContracts.Metadata;
using ProviderDataContracts.Values;
using ProviderDataContracts.Filters;
using INEProvider.Extensions.INE2Provider;
using INEProvider.Extensions.Provider2INE;
using INEProvider.ServiceConfig;
using ProviderDataContracts.Metadata.Provider_Interfaces;
using INEProvider.request;

namespace INEProvider
{
    public class INEStatisticsProvider : IStatisticsProvider
    {
        private IINERequesterWrapper _requester;

        public INEStatisticsProvider(IINERequesterWrapper requester) 
        {
            _requester = requester;
        }

        public IndicatorMetadata GetMetadata(string indicatorId)
        {
            return _requester.GetMetadata(indicatorId, true, Configuration.LANGUAGE).ToIndicatorMetadata(indicatorId);
        }

       // public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters)
       // {
       //     List<INEService.DimensionFilter> ineFilter = filters.ToDimensionFilterEnumerable().ToList();
       //     INEService.IndicatorValues ineValues = _requester.GetValues(indicatorId, 
       //             ineFilter, INEService.ValuesReturnType.OnlyValues,
       //             Configuration.LANGUAGE, 1, Configuration.MAX_RECORDS_PER_PAGE);

       //     return ineValues.IndicatorValueList.ToIndicatorValueEnumerable().ToList();
       //}


        public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters, IEnumerable<DimensionFilter> projected)
        {
            //Join filters
            List<INEService.DimensionFilter> ineFilters = JoinFilters(filters, projected).ToDimensionFilterEnumerable().ToList();
            
            INEService.IndicatorValues ineValues = _requester.GetValues(
                    indicatorId,
                    ineFilters, 
                    INEService.ValuesReturnType.OnlyValues,
                    Configuration.LANGUAGE, 
                    1, 
                    Configuration.MAX_RECORDS_PER_PAGE);

            // Aggregate values by projected filters


            return null;
        }


        private List<DimensionFilter> JoinFilters(IEnumerable<DimensionFilter> filters, IEnumerable<DimensionFilter> projected)
        {
            List<DimensionFilter> joined = new List<DimensionFilter>(filters);
            foreach (var filter in filters)
            {
                var dimension = projected.Where(d => d.DimensionID == filter.DimensionID).FirstOrDefault();
                if (dimension != null) {
                    filter.AttributeIDs = filter.AttributeIDs.Concat(dimension.AttributeIDs).Distinct();
                }
            }

            return joined;
        }        
    }
}
