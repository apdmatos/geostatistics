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
using INEProvider.Aggregator;
using INEProvider.Helpers;

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

        public IndicatorValueRange GetIndicatorValuesRange(string indicatorId, IEnumerable<DimensionFilter> filters, IEnumerable<DimensionFilter> projected, string geographicLevel)
        {
            //Join filters
            IEnumerable<DimensionFilter> joinedFilters = projected != null ? filters.Union(projected) : filters;
            List<INEService.DimensionFilter> dFilters = joinedFilters.ToDimensionFilterEnumerable().ToList();

            // add level
            INEServiceHepers.SetGeographicLevel(dFilters.Where(d => d.Order == Configuration.GEO_DIMENSION_ORDER).First(), geographicLevel);

            INEService.IndicatorValues ineValues = _requester.GetValues(
                    indicatorId,
                    dFilters,
                    INEService.ValuesReturnType.OnlyValues,
                    Configuration.LANGUAGE,
                    1,
                    Configuration.MAX_RECORDS_PER_PAGE);

            // Aggregate values by projected filters
            IEnumerable<IndicatorValue> values = null;
            if (projected != null) values =  _aggregator.AggregateValues(ineValues.IndicatorValueList, projected);
            else values = ineValues.IndicatorValueList.ToIndicatorValueEnumerable().ToList();

            if (values == null) return null;

            IndicatorValue max = null, min = null;
            foreach (var value in values)
            {
                if (max == null || value.Value > max.Value)
                    max = value;

                if (min == null || value.Value < min.Value)
                    min = value;
            }

            return new IndicatorValueRange
            {
                Maximum = max,
                Minimum = min
            };

        }

        public IEnumerable<DimensionAttribute> GetAttributes(string indicatorId, string dimensionId, string attributeRootId, int level)
        {
            INEService.Metadata metadata = _requester.GetMetadata(indicatorId, false, Configuration.LANGUAGE);
            if (metadata != null)
            {
                INEService.Dimension d = metadata.GetDimension(dimensionId);
                if (d != null)
                {
                    IEnumerable<INEService.Category> categories = _requester.GetClassificationCategories(d.ClassificationCode, level, level, Configuration.LANGUAGE, 1, Configuration.MAX_RECORDS_PER_PAGE).Where(c => c.ParentCategoryCode == attributeRootId);
                    return categories.ToDimensionAttributeEnumerable(d.LowestClassificationLevel);
                }
            }
                
            return null;
        }
    }
}
