using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataStore.Common.Model
{
    [DataContract]
    public class Configuration
    {
        [DataMember(EmitDefaultValue=false)]
        public int ID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Shapefile Shapefile { get; set; }

        [DataMember(EmitDefaultValue = false)]
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
