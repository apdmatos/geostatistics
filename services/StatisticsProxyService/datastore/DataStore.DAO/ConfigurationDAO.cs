using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Common.Model;
using DataStore.DbHelpers.templates;
using DataStore.DAO.builders;
using System.Data;
using DataStore.Common.Data_Interfaces;
using System.Data.Common;

namespace DataStore.DAO
{
    public class ConfigurationDAO : BaseDAO, IConfigurationDAO
    {

        public ConfigurationDAO() { }
        public ConfigurationDAO(DbConnection connection) 
        {
            Connection = connection;
        }

        public int AddConfiguration(int indicatorId, Configuration config)
        {
            return DbTemplateHelper<int>.GetValueByProcedure(
                Connection,
                "config.addconfiguration",
                new DbParameterHelper[]
                {
                    new DbParameterHelper(DbType.String,    "p_geolevel",       config.GeoLevel),
                    new DbParameterHelper(DbType.Int32,     "p_shapefileid",    config.Shapefile.ID),
                    new DbParameterHelper(DbType.Int32,     "p_indicatorid",    indicatorId)
                });
        }

        public IEnumerable<Configuration> GetConfigurations(int indicatorId)
        {
            return DbTemplateHelper<Configuration>.GetListByProcedure(
                    Connection,
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
                    Connection,
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
                        Connection,
                        "config.getShapefileConfigurarionURL",
                        new DbParameterHelper[]
                        {
                            new DbParameterHelper(DbType.Int32, "p_indicatorId", indicatorId),
                            new DbParameterHelper(DbType.String, "p_geolevel", geoLevel)
                        });
        }
    }
}
