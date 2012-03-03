using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Common;
using DataStore.DbHelpers.templates;
using DataStore.DAO.builders;
using System.Data;

namespace DataStore.DAO
{
    public class ConfigurationDAO
    {
        public IEnumerable<Configuration> GetConfigurations(int indicatorId)
        {
            return DbTemplateHelper<Configuration>.GetListByProcedure(
                    DataStoreModelBuilders.DataReader2Configuration,
                    "config.getconfigurations",
                    new DbParameterHelper[]
                    {
                        new DbParameterHelper(DbType.Int32, "p_indicatorId", indicatorId),
                        new DbParameterHelper(DbType.String, "p_geolevel", DBNull.Value)
                    });
        }

        public Configuration GetConfiguration(int indicatorId, string geoLevel)
        {
            return DbTemplateHelper<Configuration>.GetObjectByProcedure(
                    DataStoreModelBuilders.DataReader2Configuration,
                    "config.getconfigurations",
                    new DbParameterHelper[]
                    {
                        new DbParameterHelper(DbType.Int32, "p_indicatorId", indicatorId),
                        new DbParameterHelper(DbType.String, "p_geolevel", geoLevel)
                    });
        }

        public string GetShapefileConfigurationURL(int indicatorId, string geoLevel)
        {
            return DbTemplateHelper<string>.GetValueByProcedure(
                        "config.getShapefileConfigurarionURL",
                        new DbParameterHelper[]
                        {
                            new DbParameterHelper(DbType.Int32, "p_indicatorId", indicatorId),
                            new DbParameterHelper(DbType.String, "p_geolevel", geoLevel)
                        });
        }
    }
}
