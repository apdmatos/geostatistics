using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    public class HierarchyAttribute : DimensionAttribute
    {
        [DataMember(Name = "childAttributes", EmitDefaultValue = false)]
        public IEnumerable<DimensionAttribute> ChildAttributes { get; set; }

        [DataMember(Name = "lazyLoad", EmitDefaultValue = false)]
        public bool LazyLoad { get; set; }

        public void AddAttribute(DimensionAttribute attr) 
        {
            if (ChildAttributes == null) ChildAttributes = new List<DimensionAttribute>();
            if (!(ChildAttributes is List<DimensionAttribute>))
                ChildAttributes = new List<DimensionAttribute>(ChildAttributes);

            ((List<DimensionAttribute>)ChildAttributes).Add(attr);
        }

        public override bool Equals(object obj)
        {
            var attr = obj as HierarchyAttribute;
            if (attr == null) return false;

            return base.Equals(obj) &&
                (ChildAttributes == attr.ChildAttributes ||
                    ChildAttributes != null && 
                    attr.ChildAttributes != null && 
                    Enumerable.SequenceEqual<DimensionAttribute>(ChildAttributes, attr.ChildAttributes));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
