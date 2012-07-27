using System;
using System.Collections.Generic;
using DataStore.Common.Model;
using DataStore.DTO.Data_Interfaces;


namespace DataStore.Common.Data_Interfaces
{
    public interface IProviderDAO : IBaseDAO
    {
        int AddProvider(Provider p);

        IEnumerable<Provider> GetProviders(int? page, int? recordsPerPage);
        
        long GetTotalProviders();
    }
}
