using System;
using System.Collections.Generic;
using DataStore.Common.Model;


namespace DataStore.Common.Data_Interfaces
{
    public interface IProviderDAO
    {
        int AddProvider(Provider p);

        IEnumerable<Provider> GetProviders(int? page, int? recordsPerPage);
        
        long GetTotalProviders();
    }
}
