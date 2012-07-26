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
    //public partial class IndicatorManagement : IStatisticsIndicatorManagementService
    //{
    //    public IIndicatorDAO IndicatorDAO { get; set; }
    //    protected IConfigurationDAO ConfigurationDAO { get; set; }

    //    public IndicatorManagement(IIndicatorDAO indicatorDAO, IConfigurationDAO configurationDAO) 
    //    {
    //        IndicatorDAO = indicatorDAO;
    //        ConfigurationDAO = configurationDAO;
    //    }

        #region IStatisticsIndicatorManagementService

        public Indicator GetIndicatorById(int providerid, int indicatorid)
        {
            return IndicatorDAO.GetIndicatorById(providerid, indicatorid);
        }

        public PaginationWrapper<Indicator> GetIndicators(int providerid, int pageNumber, int recordsPerPage)
        {
            return new PaginationWrapper<Indicator> {
                Elements = IndicatorDAO.GetIndicatorsByProviderId(providerid, pageNumber, recordsPerPage),
                Total = IndicatorDAO.GetTotalIndicators(providerid),
                Page = pageNumber,
                RecordsPerPage = recordsPerPage,
            };
        }

        public PaginationWrapper<Indicator> GetIndicatorsByThemeId(
            int providerid, int themeid, int subthemeid, int pageNumber, int recordsPerPage)
        {
            return new PaginationWrapper<Indicator>
            {
                Elements = IndicatorDAO.GetIndicatorsBySubThemeId(providerid, themeid, subthemeid, pageNumber, recordsPerPage),
                Total = IndicatorDAO.GetTotalIndicators(providerid, themeid, subthemeid),
                Page = pageNumber,
                RecordsPerPage = recordsPerPage,
            };
        }

        public int AddIndicator(Indicator indicator)
        {
            return IndicatorDAO.AddIndicator(indicator);
        }

        public int AddConfiguration(int indicatorid, Configuration config)
        {
            return ConfigurationDAO.AddConfiguration(indicatorid, config);
        }

        public IEnumerable<Configuration> GetIndicatorConfigurations(int providerid, int indicatorid)
        {
            return ConfigurationDAO.GetConfigurations(indicatorid);
        }

        #endregion
    }
}
