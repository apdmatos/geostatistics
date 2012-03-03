using System;
using System.Collections.Generic;
using DataStore.Common.Model;

namespace DataStore.Common.Data_Interfaces
{
    public interface IThemesDAO
    {
        IEnumerable<SubTheme> GetProviderSubThemes(int providerId, int themeId);

        IEnumerable<Theme> GetProviderThemes(int providerId);
    }
}
