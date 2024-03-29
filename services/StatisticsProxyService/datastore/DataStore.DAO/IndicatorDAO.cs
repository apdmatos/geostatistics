﻿using System;
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
    public class IndicatorDAO : BaseDAO, IIndicatorDAO
    {

        public IndicatorDAO() { }
        public IndicatorDAO(DbConnection connection) 
        {
            Connection = connection;
        }

        public int AddIndicator(Indicator indicator)
        {
            return DbTemplateHelper<int>.GetValueByProcedure(
                Connection,
                "config.insertindicator",
                new DbParameterHelper[] 
                {
                    new DbParameterHelper(DbType.String,    "p_name",           indicator.Name),
                    new DbParameterHelper(DbType.String,    "p_nameAbbr",       indicator.NameAbbr),
                    new DbParameterHelper(DbType.String,    "p_sourceid",       indicator.SourceID),
                    new DbParameterHelper(DbType.Int32,     "p_themeid",        indicator.ThemeID),
                    new DbParameterHelper(DbType.Int32,     "p_subthemeid",     indicator.SubThemeID),
                    new DbParameterHelper(DbType.Int32,     "p_providerid",     indicator.Provider.ID)
                });
        }

        public IEnumerable<Indicator> GetIndicatorsByProviderId(int providerId, int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<Indicator>.GetListByProcedure(
                    Connection,
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
                    Connection,
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

        public Indicator GetIndicatorById(int providerId, int indicatorId)
        {
            return DbTemplateHelper<Indicator>.GetObjectBySQLQuery(
                    Connection,
                    DataStoreModelBuilders.DataReader2Indicator,
                    string.Format("select provider_id, provider_name, provider_nameabbr, provider_serviceurl, provider_url, indicator_id, indicator_sourceid, indicator_name, indicator_nameabbr, indicator_themeid, indicator_subthemeid from config.indicatorview where indicator_id={0} and provider_id={1}", indicatorId, providerId),
                    null);
        }

        public long GetTotalIndicators(int providerId, int? themeId = null, int? subThemeId = null)
        {
            string query = string.Format("select count(*) from config.indicatorview where provider_id = {0}{1}",
                                providerId,
                                themeId.HasValue ? string.Format(" and indicator_themeid={0}{1}", 
                                                        themeId.Value,
                                                        subThemeId.HasValue ? string.Format(" and indicator_subthemeid={0}", subThemeId.Value) : string.Empty) :
                                                   string.Empty);

            return DbTemplateHelper<long>.GetValueBySQLQuery(Connection, query, null);
        }
    }
}
