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
        [DataMember] public string DimensionID { get; set; }
        [DataMember] public Object ServerContextData { get; set; }
        [DataMember] public IEnumerable<string> AttributeIDs { get; set; }
    }
}
