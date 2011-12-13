using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    public class GeoAttributeHierarchy : HierarchyAttribute
    {
        [DataMember(EmitDefaultValue=false)] public int Level { get; set; }

        [DataMember(EmitDefaultValue=false)] public GeoAttributeHierarchy GeoHierachyConfiguration { get; set; }
    }
}
