using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StatisticsProxyServiceDefenitions.data_models
{
    [DataContract]
    public class Location
    {
        [DataMember(EmitDefaultValue = false)]
        public double Latitude { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public double Longitude { get; set; }

        public override bool Equals(object obj)
        {
            var loc = obj as Location;
            if (loc == null) return false;

            return Latitude == loc.Latitude && Longitude == loc.Longitude;
        }

        public override int GetHashCode()
        {
            return Longitude.GetHashCode() ^ Latitude.GetHashCode();
        }
    }
}
