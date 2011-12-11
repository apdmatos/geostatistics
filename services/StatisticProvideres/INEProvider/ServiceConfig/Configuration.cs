using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INEProvider.ServiceConfig
{
    public static class Configuration
    {
        public static string LANGUAGE = "PT";
        public static string SOURCE_NAME_ABBR = "INE";
        public static string SOURCE_NAME = "Instituto Nacional de Estatísticas";

        public static int TIME_DIMENSION_ORDER = 1;
        public static int GEO_DIMENSION_ORDER = 2;
        public static int OTHER_DIMENSIONS_START_ORDER = 3;

        public static int MAX_RECORDS_PER_PAGE = 10000;
    }
}