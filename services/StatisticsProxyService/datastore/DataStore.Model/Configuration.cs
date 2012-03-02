using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.Model
{
    public class Configuration
    {
        public int ID { get; set; }
        public Shapefile Shapefile { get; set; }
        public string GeoLevel { get; set; }
    }
}
