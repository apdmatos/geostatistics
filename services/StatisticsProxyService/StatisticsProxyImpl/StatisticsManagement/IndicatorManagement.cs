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
            using (IndicatorDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return IndicatorDAO.GetIndicatorById(providerid, indicatorid);
            }
        }

        public PaginationWrapper<Indicator> GetIndicators(int providerid, int pageNumber, int recordsPerPage)
        {
            using (IndicatorDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return new PaginationWrapper<Indicator>
                {
                    Elements = IndicatorDAO.GetIndicatorsByProviderId(providerid, pageNumber, recordsPerPage),
                    Total = IndicatorDAO.GetTotalIndicators(providerid),
                    Page = pageNumber,
                    RecordsPerPage = recordsPerPage,
                };
            }
        }

        public PaginationWrapper<Indicator> GetIndicatorsByThemeId(
            int providerid, int themeid, int subthemeid, int pageNumber, int recordsPerPage)
        {
            using (IndicatorDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return new PaginationWrapper<Indicator>
                {
                    Elements = IndicatorDAO.GetIndicatorsBySubThemeId(providerid, themeid, subthemeid, pageNumber, recordsPerPage),
                    Total = IndicatorDAO.GetTotalIndicators(providerid, themeid, subthemeid),
                    Page = pageNumber,
                    RecordsPerPage = recordsPerPage,
                };
            }
        }

        public int AddIndicator(Indicator indicator)
        {
            using (IndicatorDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return IndicatorDAO.AddIndicator(indicator);
            }
        }

        public int AddConfiguration(int indicatorid, Configuration config)
        {
            using (ConfigurationDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return ConfigurationDAO.AddConfiguration(indicatorid, config);
            }
        }

        public IEnumerable<Configuration> GetIndicatorConfigurations(int providerid, int indicatorid)
        {
            using (ConfigurationDAO.Connection = ConnectionSettings.CreateDBConnection())
            {
                return ConfigurationDAO.GetConfigurations(indicatorid);
            }
        }

        #endregion
    }
}
