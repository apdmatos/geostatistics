using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    public class GeoAttributeConfiguration
    {
        [DataMember(EmitDefaultValue = false)] public string ID { get; set; }
        [DataMember(EmitDefaultValue = false)] public string Name { get; set; }
        [DataMember(EmitDefaultValue = false)] public int Level { get; set; }

        public override bool Equals(object obj)
        {
            var conf = obj as GeoAttributeConfiguration;
            if (conf == null) return false;

            return string.Equals(ID, conf.ID) &&
                string.Equals(Name, conf.Name) &&
                Level == conf.Level;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
