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
    }
}
