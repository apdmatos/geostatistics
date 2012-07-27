using System;
using System.Collections.Generic;
using DataStore.Common.Model;
using DataStore.DTO.Data_Interfaces;

namespace DataStore.Common.Data_Interfaces
{
    public interface IThemesDAO : IBaseDAO
    {
        int AddTheme(Theme theme);

        int AddSubTheme(SubTheme subtheme);

        IEnumerable<SubTheme> GetProviderSubThemes(int providerId, int themeId);

        IEnumerable<Theme> GetProviderThemes(int providerId);
    }
}
