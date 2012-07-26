using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatisticsProxyServiceDefenitions.interfaces;
using DataStore.Common.Data_Interfaces;

namespace StatisticsProxyImpl.StatisticsManagement
{
    public partial class StatisticsManagement : IStatisticsIndicatorManagementService,
                                                IStatisticsProvidersManagementService,
                                                IStatisticsThemesManagementService
    {

        public IIndicatorDAO IndicatorDAO { get; set; }
        public IThemesDAO ThemesDAO { get; set; }
        public IProviderDAO ProviderDAO { get; set; }
        public IConfigurationDAO ConfigurationDAO { get; set; }

        public StatisticsManagement(
            IIndicatorDAO indicatorDAO, IThemesDAO themesDAO,
            IProviderDAO providerDAO, IConfigurationDAO configurationDAO)
        {
            IndicatorDAO = indicatorDAO;
            ThemesDAO = themesDAO;
            ProviderDAO = providerDAO;
            ConfigurationDAO = configurationDAO;
        }
    }
}
