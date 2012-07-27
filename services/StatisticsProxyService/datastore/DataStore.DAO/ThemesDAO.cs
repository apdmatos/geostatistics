using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Common.Model;
using DataStore.DbHelpers.templates;
using DataStore.DAO.builders;
using DataStore.Common.Data_Interfaces;
using System.Data;
using System.Data.Common;

namespace DataStore.DAO
{
    public class ThemesDAO : BaseDAO, IThemesDAO
    {

        public ThemesDAO() { }
        public ThemesDAO(DbConnection connection) 
        {
            Connection = connection;
        }

        public int AddTheme(Theme theme)
        {
            return DbTemplateHelper<int>.GetValueByProcedure(
                Connection,
                "config.inserttheme",
                new DbParameterHelper[] 
                {
                    new DbParameterHelper(DbType.String,    "p_name",           theme.Name),
                    new DbParameterHelper(DbType.String,    "p_nameAbbr",       theme.NameAbbr),
                    new DbParameterHelper(DbType.Int32,     "p_providerid",     theme.ProviderID)
                });
        }

        public int AddSubTheme(SubTheme subtheme)
        {
            return DbTemplateHelper<int>.GetValueByProcedure(
                Connection,
                "config.insertsubtheme",
                new DbParameterHelper[] 
                {
                    new DbParameterHelper(DbType.String,    "p_name",           subtheme.Name),
                    new DbParameterHelper(DbType.String,    "p_nameAbbr",       subtheme.NameAbbr),
                    new DbParameterHelper(DbType.Int32,     "p_themeid",        subtheme.ThemeID),
                    new DbParameterHelper(DbType.Int32,     "p_providerid",     subtheme.ProviderID)
                });
        }

        public IEnumerable<Theme> GetProviderThemes(int providerId)
        {
            return DbTemplateHelper<Theme>.GetListBySQLQuery(
                    Connection,
                    DataStoreModelBuilders.DataReader2Theme,
                    string.Format("SELECT theme_id, provider_id, theme_name, theme_nameabbr FROM config.themeview where provider_id={0}", providerId),
                    null);
        }

        public IEnumerable<SubTheme> GetProviderSubThemes(int providerId, int themeId)
        {
            return DbTemplateHelper<SubTheme>.GetListBySQLQuery(
                    Connection,
                    DataStoreModelBuilders.DataReader2SubTheme,
                    string.Format("SELECT subtheme_id, theme_id, provider_id, subtheme_name, subtheme_nameabbr FROM config.subthemeview where provider_id={0} and theme_id={1}", providerId, themeId),
                    null);
        }
    }
}
