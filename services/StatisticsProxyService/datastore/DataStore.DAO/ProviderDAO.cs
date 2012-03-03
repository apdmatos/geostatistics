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

namespace DataStore.DAO
{
    public class ProviderDAO : IProviderDAO
    {
        public IEnumerable<Provider> GetProviders(int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<Provider>.GetListByProcedure(
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
            return DbTemplateHelper<long>.GetValueBySQLQuery("select count(*) from config.providerview", null);
        }
    }
}
