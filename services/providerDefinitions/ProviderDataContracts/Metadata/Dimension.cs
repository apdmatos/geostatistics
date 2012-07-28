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
        [DataMember(Name="id", EmitDefaultValue=false)] 
        public string ID { get; set; }

        [DataMember(Name = "name", EmitDefaultValue=false)] 
        public string Name { get; set; }

        [DataMember(Name = "nameAbbr", EmitDefaultValue = false)]
        public string NameAbbr { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)] 
        public DimensionType DimensionType { get; set; }

        [DataMember(Name = "attributes", EmitDefaultValue = false)] 
        public IEnumerable<DimensionAttribute> Attributes { get; set; }

        [DataMember(Name = "aggregationLevels", EmitDefaultValue = false)]
        public IEnumerable<AggregationLevel> AggregationLevels { get; set; }

        [DataMember(Name = "serverContextData", EmitDefaultValue = false)]
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

            return string.Equals(dimension.ID, ID) &&
                string.Equals(dimension.Name, Name) &&
                string.Equals(dimension.NameAbbr, NameAbbr) &&
                DimensionType == dimension.DimensionType &&
                Enumerable.SequenceEqual<DimensionAttribute>(dimension.Attributes, Attributes) &&
                object.Equals(ServerContextData, dimension.ServerContextData);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
    }
}
