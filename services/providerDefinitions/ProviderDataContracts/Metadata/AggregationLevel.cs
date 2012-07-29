using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    public class AggregationLevel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string ID { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "level", EmitDefaultValue = false)]
        public int Level { get; set; }

        public override bool Equals(object obj)
        {
            var conf = obj as AggregationLevel;
            if (conf == null) return false;

            return string.Equals(ID, conf.ID) &&
                string.Equals(Name, conf.Name) &&
                Level == conf.Level;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode() ^ Name.GetHashCode() ^ Level.GetHashCode();
        }
    }
}
