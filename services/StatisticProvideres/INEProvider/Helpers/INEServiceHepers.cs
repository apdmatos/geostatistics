using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INEProvider.Model;

namespace INEProvider.Helpers
{
    static class INEServiceHepers
    {
        public static string GetGeographicLevelName(GeographicLevels level) 
        {
            switch (level) {

                case GeographicLevels.NUTS1: return "NUTS 1";
                case GeographicLevels.NUTS2: return "NUTS 2";
                case GeographicLevels.NUTS3: return "NUTS 3";
                case GeographicLevels.Municipality: return "Concelhos";
                case GeographicLevels.Parish: return "Freguesias";
            }

            return null;
        }
    }
}