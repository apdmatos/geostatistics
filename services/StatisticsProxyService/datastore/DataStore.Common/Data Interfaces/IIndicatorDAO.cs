using System;
using DataStore.Common.Model;
using System.Collections.Generic;

namespace DataStore.Common.Data_Interfaces
{
    public interface IIndicatorDAO
    {
        Indicator GetIndicatorById(int providerId, int indicatorId);
        
        IEnumerable<Indicator> GetIndicatorsByProviderId(int providerId, int? page, int? recordsPerPage);
        
        IEnumerable<Indicator> GetIndicatorsBySubThemeId(int providerId, int themeId, int subthemeId, int? page, int? recordsPerPage);
        
        long GetTotalIndicators(int providerId, int? themeId = null, int? subThemeId = null);
    }
}
