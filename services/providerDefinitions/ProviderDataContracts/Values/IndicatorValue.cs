﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ProviderDataContracts.Filters;

namespace ProviderDataContracts.Values
{
    [DataContract]
    public class IndicatorValue
    {
        [DataMember(EmitDefaultValue=false)] public double Value { get; set; }
        [DataMember(EmitDefaultValue=false)] public IEnumerable<DimensionFilter> Filters { get; set; }
    }
}
