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

namespace INEProvider
{
    public class INEStatisticsProvider : IStatisticsProvider
    {
        public IndicatorMetadata GetMetadata(string indicatorId)
        {
            IndicatorMetadata metadata = null;
            using (INEProvider.INEService.StatisticsClient service = new INEService.StatisticsClient()) 
            {
                metadata = service.GetMetadata(indicatorId, true, Configuration.LANGUAGE).ToIndicatorMetadata(indicatorId);
            }

            return metadata;
        }

        public IEnumerable<IndicatorValue> GetValues(string indicatorId, IEnumerable<DimensionFilter> filters)
        {
            IEnumerable<IndicatorValue> values = null;

            using (INEProvider.INEService.StatisticsClient service = new INEService.StatisticsClient())
            {
                List<INEService.DimensionFilter> ineFilter = filters.ToDimensionFilterEnumerable().ToList();
                INEService.IndicatorValues ineValues = service.GetValues(indicatorId, 
                        ineFilter, INEService.ValuesReturnType.OnlyValues,
                        Configuration.LANGUAGE, 1, Configuration.MAX_RECORDS_PER_PAGE);

                values = ineValues.IndicatorValueList.ToIndicatorValueEnumerable();
            }

            return values;
        }
    }
}
