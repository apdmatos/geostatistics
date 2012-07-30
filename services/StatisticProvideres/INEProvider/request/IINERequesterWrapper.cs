using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using INEProvider.INEService;

namespace INEProvider.request
{
    public interface IINERequesterWrapper
    {
        Metadata GetMetadata(string indicator, bool getCategories, string language);
        IndicatorValues GetValues(string indicator, List<DimensionFilter> dimensionFilter, ValuesReturnType valuesType, string language, int pageNumber, int recordsPerPage);
        List<Category> GetClassificationCategories(string classification, int highestClassificationLevel, int lowestClassificationLevel, string language, int pageNumber, int recordsPerPage);
    }
}
