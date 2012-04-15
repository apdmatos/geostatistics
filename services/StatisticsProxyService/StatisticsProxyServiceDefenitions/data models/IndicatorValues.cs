using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ProviderDataContracts.Values;

namespace StatisticsProxyServiceDefenitions.data_models
{
    [DataContract]
    public class IndicatorValues
    {
        [DataMember(EmitDefaultValue = false, Name="location")] public Location Location { get; set; }
        [DataMember(EmitDefaultValue = false, Name="values")] public IEnumerable<IndicatorValue> Values { get; set; }

        public override bool Equals(object obj)
        {
            var ivalues = obj as IndicatorValues;
            if (ivalues == null) return false;

            return Location.Equals(Location, ivalues.Location)
                && (Values == ivalues.Values ||
                    (Values != null && ivalues.Values != null && Enumerable.SequenceEqual<IndicatorValue>(Values, ivalues.Values)));
        }

        public override int GetHashCode()
        {
            return Location.GetHashCode() ^ Values.GetHashCode();
        }
    }
}
