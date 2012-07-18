using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Values
{
    [DataContract]
    public class IndicatorValueRange
    {
        [DataMember] public IndicatorValue Maximum { get; set; }
        [DataMember] public IndicatorValue Minimum { get; set; }
    }
}
