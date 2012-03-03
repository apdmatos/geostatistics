using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.Common.Model
{
    public class Configuration
    {
        public int ID { get; set; }
        public Shapefile Shapefile { get; set; }
        public string GeoLevel { get; set; }

        public override bool Equals(object obj)
        {
            Configuration conf = obj as Configuration;
            if (conf == null) return false;

            return ID == conf.ID && Shapefile.Equals(Shapefile, conf.Shapefile) && String.Equals(GeoLevel, conf.GeoLevel);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
