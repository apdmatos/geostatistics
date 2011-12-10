using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    public enum DimensionType
    {
        [EnumMember] Geographic = 0,
        [EnumMember] Temporal = 1,
        [EnumMember] Other = 2
    }
}
