﻿using System;
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
using INEProvider.Aggregator;

namespace INEProvider
{
    public class INEStatisticsProvider : IStatisticsProvider
    {
        private IINERequesterWrapper _requester;
        private IAggregator _aggregator;

        public INEStatisticsProvider(IINERequesterWrapper requester, IAggregator aggregator) 
        {
            _requester = requester;
            _aggregator = aggregator;
        }

        public IndicatorMetadata GetMetadata(string indicatorId)
        {
            return _requester.GetMetadata(indicatorId, true, Configuration.LANGUAGE).ToIndicatorMetadata(indicatorId);
        }

        public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters, IEnumerable<DimensionFilter> projected)
        {
            //Join filters
            IEnumerable<DimensionFilter> joinedFilters = projected != null ? filters.Union(projected) : filters;

            INEService.IndicatorValues ineValues = _requester.GetValues(
                    indicatorId,
                    joinedFilters.ToDimensionFilterEnumerable().ToList(), 
                    INEService.ValuesReturnType.OnlyValues,
                    Configuration.LANGUAGE, 
                    1, 
                    Configuration.MAX_RECORDS_PER_PAGE);

            // Aggregate values by projected filters
            if (projected != null) return _aggregator.AggregateValues(ineValues.IndicatorValueList, projected);
            return ineValues.IndicatorValueList.ToIndicatorValueEnumerable().ToList();
        }       
    }
}
