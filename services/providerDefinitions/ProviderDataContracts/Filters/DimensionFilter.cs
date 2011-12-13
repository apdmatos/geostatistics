using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Filters
{
    [DataContract]
    public class DimensionFilter
    {
        [DataMember(EmitDefaultValue = false)] public string DimensionID { get; set; }
        [DataMember(EmitDefaultValue = false)] public Object ServerContextData { get; set; }
        [DataMember(EmitDefaultValue = false)] public IEnumerable<string> AttributeIDs { get; set; }
    }
}
