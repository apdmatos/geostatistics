using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Model;
using DataStore.Common.templates;
using DataStore.DAO.builders;
using System.Data;
using DataStore.DAO.utils;

namespace DataStore.DAO
{
    public class ProviderDAO
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

        public int GetTotalProviders()
        {
            return DbTemplateHelper<int>.GetValueBySQLQuery("select count(*) from providerview", null);
        }
    }
}
