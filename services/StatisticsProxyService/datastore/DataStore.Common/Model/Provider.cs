using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataStore.Common.Model
{
    [DataContract]
    public class Provider
    {
        [DataMember(EmitDefaultValue = false)]
        public int ID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string NameAbbr { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ServiceURL { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string URL { get; set; }

        public override bool Equals(object obj)
        {
            Provider prov = obj as Provider;
            if (prov == null) return false;
            return ID == prov.ID && String.Equals(Name, prov.Name) && String.Equals(NameAbbr, prov.NameAbbr) &&
                String.Equals(ServiceURL, prov.ServiceURL) && String.Equals(URL, prov.URL);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
