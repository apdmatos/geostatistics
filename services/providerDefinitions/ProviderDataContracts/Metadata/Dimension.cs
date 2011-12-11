using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    public class Dimension
    {
        [DataMember(Name="id")] 
        public string ID { get; set; }

        [DataMember(Name = "name")] 
        public string Name { get; set; }

        [DataMember(Name = "nameAbbr")]
        public string NameAbbr { get; set; }

        [DataMember(Name = "type")] 
        public DimensionType DimensionType { get; set; }

        [DataMember(Name = "attributes")] 
        public IEnumerable<DimensionAttribute> Attributes { get; set; }

        [DataMember(Name = "serverContextData")]
        public Object ServerContextData { get; set; }

        public void AddAttribute(DimensionAttribute attribute) {
            if (Attributes == null) Attributes = new List<DimensionAttribute>();
            
            List<DimensionAttribute> attrs = (Attributes as List<DimensionAttribute>);
            if (attrs == null) 
                Attributes = new List<DimensionAttribute>(Attributes);

            ((List<DimensionAttribute>)Attributes).Add(attribute);
        }

        public override bool Equals(object obj)
        {
            var dimension = obj as Dimension;
            if (dimension == null) return false;

            return dimension.ID == ID;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
