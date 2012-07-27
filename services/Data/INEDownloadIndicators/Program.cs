using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Common.Model;
using DataStore.DAO;
using System.Configuration;
using System.Data.Common;

namespace INEDownloadIndicators
{
    class Program
    {
        public static string GEOVERSION = "00320";
        public static string LANGUAGE = "PT";

        public enum GEOLevels
        {
            NUTS1 = 2,
            NUTS2 = 3,
            NUTS3 = 4,
            Municipality = 5,
            Parish = 6
        }

        public static Dictionary<GEOLevels, int> SHAPEFILE_IDS = new Dictionary<GEOLevels, int> 
        { 
            { GEOLevels.NUTS1, 4 },
            { GEOLevels.NUTS2, 5 },
            { GEOLevels.NUTS3, 6 },
            { GEOLevels.Municipality, 2 },
            { GEOLevels.Parish, 3 }
        };

        static void Main(string[] args)
        {
            ConnectionSettings.SetConnectionSettings(
                ConfigurationManager.ConnectionStrings["db"].ConnectionString,
                ConfigurationManager.ConnectionStrings["db"].ProviderName);

            using (DbConnection conn = ConnectionSettings.CreateDBConnection())
            {
                conn.Open();
                using (DbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        INEService.StatisticsClient client = new INEService.StatisticsClient();

                        Provider p = addProvider(conn);
                        IEnumerable<ExtendedSubTheme> subthemes = AddThemes(conn, p, client);
                        addIndicators(conn, p, subthemes, client);

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        static Provider addProvider(DbConnection conn)
        {
            Console.WriteLine(":::::::::: Adding provider :::::::::");

            Provider p = new Provider
            {
                Name = "Instituto Nacional de Estatística",
                NameAbbr = "INE",
                ServiceURL = "http://localhost:42136/INEStatisticsProvider.svc",
                URL = "http://www.ine.pt"
            };

            ProviderDAO provider = new ProviderDAO(conn);
            p.ID = provider.AddProvider(p);

            return p;
        }

        static IEnumerable<ExtendedSubTheme> AddThemes(DbConnection conn, Provider p, INEService.Statistics ine)
        {
            Console.WriteLine(":::::::::: Adding themes :::::::::");

            var themesDAO = new ThemesDAO(conn);

            var insertedThemes = new List<ExtendedTheme>();
            var insertedSubThemes = new List<ExtendedSubTheme>();

            INEService.Theme[] themes = ine.GetThemes(GEOVERSION, 2, LANGUAGE, 1, 100000);
            var filteredThemes = themes.Where(t => t.ThemeLevel == 2);
            foreach (var theme in filteredThemes)
            {
                Console.WriteLine("... Adding theme: {0} ....", theme.Designation);

                ExtendedTheme t = new ExtendedTheme
                {
                    Name = theme.Designation,
                    NameAbbr = theme.Designation,
                    ProviderID = p.ID,
                    SourceThemeCode = theme.Code
                };
                t.ID = themesDAO.AddTheme(t);

                insertedThemes.Add(t);
            }

            // subthemes
            var filteredSubThemes = themes.Where(t => t.ThemeLevel == 3);
            foreach (var subtheme in filteredSubThemes)
            {
                Console.WriteLine("... Adding subtheme: {0} ....", subtheme.Designation);

                ExtendedSubTheme sub = new ExtendedSubTheme
                {
                    Name = subtheme.Designation,
                    NameAbbr = subtheme.Designation,
                    ProviderID = p.ID,
                    ThemeID = insertedThemes.Where(it => it.SourceThemeCode == subtheme.ParentCode).First().ID,
                    SourceThemeCode = subtheme.Code
                };

                sub.ID = themesDAO.AddSubTheme(sub);
                insertedSubThemes.Add(sub);
            }

            return insertedSubThemes;
        }

        private static void addIndicators(DbConnection conn, Provider p, IEnumerable<ExtendedSubTheme> subthemes, INEService.Statistics ine)
        {
            Console.WriteLine(":::::::::: Adding indicatores :::::::::");

            var indicatorDAO = new IndicatorDAO(conn);

            foreach (var subtheme in subthemes)
            {
                INEService.IndicatorPlus indicators = ine.GetIndicatorsByTheme(GEOVERSION, subtheme.SourceThemeCode, LANGUAGE, 2, 1, 10000);
                foreach (var indicator in indicators.Indicators)
                {
                    Console.WriteLine("... Adding indicator: {0} ....", subtheme.NameAbbr);

                    Indicator convertedIndicator = new Indicator
                    {
                        Name = indicator.Designation,
                        NameAbbr = indicator.Abbreviation,
                        Provider = p,
                        SourceID = indicator.Code,
                        SubThemeID = subtheme.ID,
                        ThemeID = subtheme.ThemeID
                    };
                    convertedIndicator.ID = indicatorDAO.AddIndicator(convertedIndicator);

                    addConfiguration(conn, convertedIndicator, indicator.GeoLevelCode);
                }
            }
        }

        public static void addConfiguration(DbConnection conn, Indicator indicator, string lowestGeoLevel)
        {
            var configurationDAO = new ConfigurationDAO(conn);
            for (int geoLevel = int.Parse(lowestGeoLevel); geoLevel >= 2; --geoLevel)
            {
                GEOLevels level = (GEOLevels)geoLevel;

                Console.WriteLine("... Adding configuration: {0} ....", level.ToString());
                
                DataStore.Common.Model.Configuration config = new DataStore.Common.Model.Configuration
                {
                    GeoLevel = level.ToString(),
                    Shapefile = new Shapefile
                    {
                        ID = SHAPEFILE_IDS[level]
                    }
                };
                configurationDAO.AddConfiguration(indicator.ID, config);
            }
        }
    }
}
