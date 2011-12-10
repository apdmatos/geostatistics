using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    [KnownType(typeof(HierarchyAttribute))]
    public class Attribute
    {
        [DataMember(Name="id")] public string ID { get; set; }

        [DataMember(Name="name")] public string Name { get; set; }
    }
}
