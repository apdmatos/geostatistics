using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Common.Model;
using DataStore.DbHelpers.templates;
using DataStore.DAO.builders;
using System.Data;
using DataStore.DAO.utils;
using DataStore.Common.Data_Interfaces;
using System.Data.Common;

namespace DataStore.DAO
{
    public class ProviderDAO : BaseDAO, IProviderDAO
    {

        public ProviderDAO() { }
        public ProviderDAO(DbConnection connection) 
        {
            Connection = connection;
        }


        public int AddProvider(Provider p)
        {
            return DbTemplateHelper<int>.GetValueByProcedure(
                Connection,
                "config.insertprovider",
                new DbParameterHelper[] 
                {
                    new DbParameterHelper(DbType.String, "p_name", p.Name),
                    new DbParameterHelper(DbType.String, "p_nameAbbr", p.NameAbbr),
                    new DbParameterHelper(DbType.String, "p_serviceUrl", p.ServiceURL),
                    new DbParameterHelper(DbType.String, "p_url", p.URL),
                });
        }

        public IEnumerable<Provider> GetProviders(int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<Provider>.GetListByProcedure(
                    Connection,
                    DataStoreModelBuilders.DataReader2Provider,
                    "config.getProviders",
                    new DbParameterHelper[]
                    {
                        new DbParameterHelper(DbType.Int32, "p_page", DbUtils.ReturnsDefaultDbNumber(page)),
                        new DbParameterHelper(DbType.Int32, "p_recordsPerPage", DbUtils.ReturnsDefaultDbNumber(recordsPerPage)),
                    });
        }

        public long GetTotalProviders()
        {
            return DbTemplateHelper<long>.GetValueBySQLQuery(Connection, "select count(*) from config.providerview", null);
        }
    }
}
