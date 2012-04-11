using System;
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
        [DataMember(EmitDefaultValue = false)] public IEnumerable<DimensionFilter> Projected { get; set; }

        public override bool Equals(object obj)
        {
            IndicatorValue ivalue = obj as IndicatorValue;
            if (ivalue == null) return false;

            return Value == ivalue.Value 
                && ((Filters == null && ivalue.Filters == null) || 
                    (Filters != null && ivalue.Filters != null && Enumerable.SequenceEqual<DimensionFilter>(Filters, ivalue.Filters)))
                && ((Projected == null && ivalue.Projected == null) ||
                    (Projected != null && ivalue.Projected != null && Enumerable.SequenceEqual<DimensionFilter>(Projected, ivalue.Projected)));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ Filters.GetHashCode() ^ Projected.GetHashCode();
        }
    }
}
