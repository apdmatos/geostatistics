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

        public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters)
        {
            List<INEService.DimensionFilter> ineFilter = filters.ToDimensionFilterEnumerable().ToList();
            INEService.IndicatorValues ineValues = _requester.GetValues(indicatorId, 
                    ineFilter, INEService.ValuesReturnType.OnlyValues,
                    Configuration.LANGUAGE, 1, Configuration.MAX_RECORDS_PER_PAGE);

            return ineValues.IndicatorValueList.ToIndicatorValueEnumerable().ToList();
       }
    }
}
