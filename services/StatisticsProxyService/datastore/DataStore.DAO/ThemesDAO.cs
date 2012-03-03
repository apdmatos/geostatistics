using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Common;
using DataStore.DbHelpers.templates;
using DataStore.DAO.builders;

namespace DataStore.DAO
{
    public class ThemesDAO
    {
        public IEnumerable<Theme> GetProviderThemes(int providerId)
        {
            return DbTemplateHelper<Theme>.GetListBySQLQuery(
                    DataStoreModelBuilders.DataReader2Theme,
                    string.Format("SELECT theme_id, provider_id, theme_name, theme_nameabbr FROM config.themeview where provider_id={0}", providerId),
                    null);
        }

        public IEnumerable<SubTheme> GetProviderSubThemes(int providerId, int themeId)
        {
            return DbTemplateHelper<SubTheme>.GetListBySQLQuery(
                    DataStoreModelBuilders.DataReader2SubTheme,
                    string.Format("SELECT subtheme_id, theme_id, provider_id, subtheme_name, subtheme_nameabbr FROM config.subthemeview where provider_id={0} and theme_id={1}", providerId, themeId),
                    null);
        }
    }
}
