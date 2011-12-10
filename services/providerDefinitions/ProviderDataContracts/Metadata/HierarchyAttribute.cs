using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    public class HierarchyAttribute : Attribute
    {
        [DataMember(Name="childAttributes")] public List<Attribute> ChildAttributes { get; set; }
    }
}
