﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Filters
{
    [DataContract]
    public class DimensionFilter
    {
        [DataMember(EmitDefaultValue = false, Name = "dimensionId")] public string DimensionID { get; set; }
        [DataMember(EmitDefaultValue = false)] public Object ServerContextData { get; set; }
        [DataMember(EmitDefaultValue = false, Name="attributes")] public IEnumerable<string> AttributeIDs { get; set; }

        public override bool Equals(object obj)
        {
            DimensionFilter filter = obj as DimensionFilter;
            if (filter == null) return false;

            return string.Equals(DimensionID, filter.DimensionID) &&
                object.Equals(ServerContextData, filter.ServerContextData) &&
                Enumerable.SequenceEqual<string>(AttributeIDs, filter.AttributeIDs);
        }

        public override int GetHashCode()
        {
            return DimensionID.GetHashCode();
        }
    }
}
