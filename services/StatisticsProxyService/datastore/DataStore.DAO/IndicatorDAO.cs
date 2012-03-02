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
    public class IndicatorDAO
    {
        public IEnumerable<Indicator> GetIndicatorsByProviderId(int providerId, int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<Indicator>.GetListByProcedure(
                    DataStoreModelBuilders.DataReader2Indicator,
                    "config.getIndicatorsByProviderId",
                    new DbParameterHelper[]
                    {
                        new DbParameterHelper(DbType.Int32, "p_providerId", providerId),
                        new DbParameterHelper(DbType.Int32, "p_page", DbUtils.ReturnsDefaultDbNumber(page)),
                        new DbParameterHelper(DbType.Int32, "p_recordsPerPage", DbUtils.ReturnsDefaultDbNumber(recordsPerPage)),
                    });
        }

        public IEnumerable<Indicator> GetIndicatorsBySubThemeId(int providerId, int themeId, int subthemeId, int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<Indicator>.GetListByProcedure(
                    DataStoreModelBuilders.DataReader2Indicator,
                    "config.getIndicatorsBySubThemeId",
                    new DbParameterHelper[]
                    {
                        new DbParameterHelper(DbType.Int32, "p_providerId", providerId),
                        new DbParameterHelper(DbType.Int32, "p_themeId", themeId),
                        new DbParameterHelper(DbType.Int32, "p_subthemeId", subthemeId),
                        new DbParameterHelper(DbType.Int32, "p_page", DbUtils.ReturnsDefaultDbNumber(page)),
                        new DbParameterHelper(DbType.Int32, "p_recordsPerPage", DbUtils.ReturnsDefaultDbNumber(recordsPerPage)),
                    });
        }

        public Indicator GetIndicatorById(int indicatorId)
        {
            return DbTemplateHelper<Indicator>.GetObjectBySQLQuery(
                    DataStoreModelBuilders.DataReader2Indicator,
                    string.Format("select provider_id, provider_name, provider_nameabbr, provider_serviceurl, provider_url, indicator_id, indicator_sourceid, indicator_name, indicator_nameabbr, indicator_theme_id, indicator_subthemeid from indicatorview where indicator_id={0}", indicatorId),
                    null);
        }

        public int GetTotalIndicators(int providerId, int? themeId = null, int? subThemeId = null)
        {
            string query = string.Format("select count(*) from indicatorview where provider_id = {0}{1}",
                                providerId,
                                themeId.HasValue ? string.Format(" and provider_themeid={0}{1}", 
                                                        themeId.Value,
                                                        subThemeId.HasValue ? string.Format(" and indicator_subthemeid={0}", subThemeId.Value) : string.Empty) :
                                                   string.Empty);

            return DbTemplateHelper<int>.GetValueBySQLQuery(query, null);
        }
    }
}
