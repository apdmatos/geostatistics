using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatisticsProxyServiceDefenitions.interfaces;
using DataStore.Common.Model;
using DataStore.Common.Data_Interfaces;
using DataStore.DAO;

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
            using (ThemesDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return ThemesDAO.AddTheme(theme);
            }
        }

        public int AddSubTheme(SubTheme subtheme)
        {
            using (ThemesDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return ThemesDAO.AddSubTheme(subtheme);
            }
        }

        public IEnumerable<Theme> GetThemes(int providerid)
        {
            using (ThemesDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return ThemesDAO.GetProviderThemes(providerid);
            }
        }

        public IEnumerable<SubTheme> GetSubThemes(int providerid, int themeid)
        {
            using (ThemesDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return ThemesDAO.GetProviderSubThemes(providerid, themeid);
            }
        }

        #endregion
    }
}
