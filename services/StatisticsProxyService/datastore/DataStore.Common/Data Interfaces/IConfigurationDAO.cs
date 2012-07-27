using System;
using DataStore.Common.Model;
using System.Collections.Generic;
using DataStore.DTO.Data_Interfaces;


namespace DataStore.Common.Data_Interfaces
{
    public interface IConfigurationDAO : IBaseDAO
    {
        int AddConfiguration(int indicatorId, Configuration config);

        Configuration GetConfiguration(int indicatorId, string geoLevel);
        
        IEnumerable<Configuration> GetConfigurations(int indicatorId);
        
        string GetShapefileConfigurationURL(int indicatorId, string geoLevel);
    }
}
