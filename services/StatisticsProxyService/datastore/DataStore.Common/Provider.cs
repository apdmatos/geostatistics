using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.Common
{
    public class Provider
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAbbr { get; set; }
        public string ServiceURL { get; set; }
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
