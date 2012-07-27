using System;
using DataStore.Common.Model;
using System.Collections.Generic;
using DataStore.DTO.Data_Interfaces;

namespace DataStore.Common.Data_Interfaces
{
    public interface IIndicatorDAO : IBaseDAO
    {
        int AddIndicator(Indicator indidcator);

        Indicator GetIndicatorById(int providerId, int indicatorId);
        
        IEnumerable<Indicator> GetIndicatorsByProviderId(int providerId, int? page, int? recordsPerPage);
        
        IEnumerable<Indicator> GetIndicatorsBySubThemeId(int providerId, int themeId, int subthemeId, int? page, int? recordsPerPage);
        
        long GetTotalIndicators(int providerId, int? themeId = null, int? subThemeId = null);
    }
}
