//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Runtime.Serialization;

//namespace ProviderDataContracts.Metadata
//{
//    [DataContract]
//    public class GeoAttributeHierarchy : HierarchyAttribute
//    {
//        [DataMember(EmitDefaultValue = false)] public IEnumerable<GeoAttributeConfiguration> Configuration { get; set; }

//        public override bool Equals(object obj)
//        {
//            var attr = obj as GeoAttributeHierarchy;
//            if (attr == null) return false;

//            return base.Equals(obj) &&
//                (Configuration == null && attr.Configuration == null || Enumerable.SequenceEqual<GeoAttributeConfiguration>(Configuration, attr.Configuration));
//        }

//        public override int GetHashCode()
//        {
//            return base.GetHashCode();
//        }
//    }
//}
