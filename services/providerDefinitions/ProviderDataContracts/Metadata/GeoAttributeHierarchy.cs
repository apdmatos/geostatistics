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

        public override bool Equals(object obj)
        {
            var attr = obj as GeoAttributeHierarchy;
            if (attr == null) return false;

            return base.Equals(obj) && 
                Level == attr.Level &&
                GeoAttributeHierarchy.Equals(GeoHierachyConfiguration, attr.GeoHierachyConfiguration);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
