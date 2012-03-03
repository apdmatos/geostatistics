using System;
using System.Collections.Generic;
using DataStore.Common.Model;


namespace DataStore.Common.Data_Interfaces
{
    public interface IProviderDAO
    {
        IEnumerable<Provider> GetProviders(int? page, int? recordsPerPage);
        
        long GetTotalProviders();
    }
}
