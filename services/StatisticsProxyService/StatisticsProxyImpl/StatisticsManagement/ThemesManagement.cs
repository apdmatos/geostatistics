using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatisticsProxyServiceDefenitions.interfaces;
using DataStore.Common.Model;
using DataStore.Common.Data_Interfaces;

namespace StatisticsProxyImpl.StatisticsManagement
{
    public partial class StatisticsManagement : IStatisticsIndicatorManagementService,
                                                IStatisticsProvidersManagementService,
                                                IStatisticsThemesManagementService
    {
    //public partial class ThemesManagement : IStatisticsThemesManagementService
    //{
    //    public IThemesDAO ThemesDAO { get; set; }

    //    public ThemesManagement(IThemesDAO themesDAO)
    //    {
    //        ThemesDAO = themesDAO;
    //    }

        #region IStatisticsThemesManagementService

        public int AddTheme(Theme theme)
        {
            return ThemesDAO.AddTheme(theme);
        }

        public int AddSubTheme(SubTheme subtheme)
        {
            return ThemesDAO.AddSubTheme(subtheme);
        }

        public IEnumerable<Theme> GetThemes(int providerid)
        {
            return ThemesDAO.GetProviderThemes(providerid);
        }

        public IEnumerable<SubTheme> GetSubThemes(int providerid, int themeid)
        {
            return ThemesDAO.GetProviderSubThemes(providerid, themeid);
        }

        #endregion
    }
}
