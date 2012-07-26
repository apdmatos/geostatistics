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
    //public partial class ProviderManagement : IStatisticsProvidersManagementService
    //{
    //    public IProviderDAO ProviderDAO { get; set; }

    //    public ProviderManagement(IProviderDAO providerDAO)
    //    {
    //        ProviderDAO = providerDAO;
    //    }

        #region IStatisticsProvidersManagementService

        public int AddProvider(Provider p)
        {
            return ProviderDAO.AddProvider(p);
        }

        public PaginationWrapper<Provider> GetProviders(int pageNumber, int recordsPerPage)
        {
            return new PaginationWrapper<Provider>
            {
                Elements = ProviderDAO.GetProviders(pageNumber, recordsPerPage),
                Page = pageNumber,
                RecordsPerPage = recordsPerPage,
                Total = ProviderDAO.GetTotalProviders()
            };

            
        }

        #endregion
    }
}
