using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    [KnownType(typeof(HierarchyAttribute))]
    [KnownType(typeof(GeoAttributeHierarchy))]
    public class DimensionAttribute
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string ID { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }
    }
}
