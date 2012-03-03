using System;
using DataStore.Common.Model;
using System.Collections.Generic;


namespace DataStore.Common.Data_Interfaces
{
    public interface IConfigurationDAO
    {
        Configuration GetConfiguration(int indicatorId, string geoLevel);
        
        IEnumerable<Configuration> GetConfigurations(int indicatorId);
        
        string GetShapefileConfigurationURL(int indicatorId, string geoLevel);
    }
}
