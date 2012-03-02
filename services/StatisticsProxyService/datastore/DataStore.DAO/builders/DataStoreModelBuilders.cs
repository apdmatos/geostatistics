using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Model;
using System.Data.Common;
using System.Data;


namespace DataStore.DAO.builders
{
    internal static class DataStoreModelBuilders
    {
        public static Configuration DataReader2Configuration(IDataReader reader)
        {
            if (reader["configuration_id"] == null) return null;
            return new Configuration
            {
                ID          = (int)reader["configuration_id"],
                GeoLevel    = (string)reader["configuration_geolevel"],
                Shapefile   = DataReader2Shapefile(reader)
            };
        }

        public static Indicator DataReader2Indicator(IDataReader reader)
        {
            if (reader["indicator_id"] == null) return null;
            return new Indicator
            {
                ID          = (int)reader["indicator_id"],
                Name        = (string)reader["indicator_name"],
                NameAbbr    = (string)reader["indicator_nameabbr"],
                Provider    = DataReader2Provider(reader),
                SourceID    = (string)reader["indicator_sourceid"],
                SubThemeID  = (int)reader["indicator_subthemeid"],
                ThemeID     = (int)reader["indicator_themeid"]
            };
        }

        public static Provider DataReader2Provider(IDataReader reader)
        {
            if (reader["provider_id"] == null) return null;
            return new Provider
            {
                ID          = (int)reader["provider_id"],
                Name        = (string)reader["provider_name"],
                NameAbbr    = (string)reader["provider_nameabbr"],
                ServiceURL  = (string)reader["provider_serviceurl"],
                URL         = (string)reader["provider_url"]
            };
        }

        public static ShapefileGroup DataReader2ShapefileGroup(IDataReader reader)
        {
            if (reader["shapefilegroup_id"] == null) return null;
            return new ShapefileGroup
            {
                ID      = (int)reader["shapefilegroup_name"],
                Name    = (string)reader["shapefilegroup_name"]
            };
        }

        public static Shapefile DataReader2Shapefile(IDataReader reader)
        {
            if (reader["shapefile_id"] == null) return null;
            return new Shapefile
            {
                Group       = DataReader2ShapefileGroup(reader),
                ID          = (int)reader["shapefile_id"],
                Level       = (int)reader["shapefile_level"],
                Name        = (string)reader["shapefile_name"],
                Path        = (string)reader["shapefile_path"],
                FileName    = (string)reader["shapefile_filename"]
            };
        }

        public static Theme DataReader2Theme(IDataReader reader)
        {
            if (reader["theme_id"] == null) return null;
            return new Theme 
            {
                ID          = (int)reader["theme_id"],
                Name        = (string)reader["theme_name"],
                NameAbbr    = (string)reader["theme_nameabbr"],
                ProviderID  = (int)reader["provider_id"]
            };
        }

        public static SubTheme DataReader2SubTheme(IDataReader reader)
        {
            if (reader["subtheme_id"] == null) return null;
            return new SubTheme
            {
                ID          = (int)reader["subtheme_id"],
                Name        = (string)reader["subtheme_name"],
                NameAbbr    = (string)reader["subtheme_nameabbr"],
                ProviderID  = (int)reader["provider_id"],
                ThemeID     = (int)reader["theme_id"]
            };
        }
    }
}
