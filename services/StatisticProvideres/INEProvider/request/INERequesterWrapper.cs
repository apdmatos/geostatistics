using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using INEProvider.INEService;

namespace INEProvider.request
{
    public class INERequestWrapper : IINERequesterWrapper
    {
        public Metadata GetMetadata(string indicator, bool getCategories, string language)
        {
            using (INEProvider.INEService.StatisticsClient service = new INEProvider.INEService.StatisticsClient())
            {
                return service.GetMetadata(indicator, getCategories, language);
            }
        }

        public IndicatorValues GetValues(string indicator, List<DimensionFilter> dimensionFilter, ValuesReturnType valuesType, string language, int pageNumber, int recordsPerPage)
        {
            using (INEProvider.INEService.StatisticsClient service = new INEProvider.INEService.StatisticsClient())
            {
                return service.GetValues(indicator, dimensionFilter, valuesType, language, pageNumber, recordsPerPage);
            }
        }
    }
}