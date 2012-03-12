using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ProviderDataContracts.Filters;

namespace StatisticsProxyServiceDefenitions.data_models
{
    [DataContract]
    public class DataSerie
    {
        [DataMember(EmitDefaultValue=false)]
        public Location Location { get; set; }

        [DataMember(EmitDefaultValue = false, Name="values")]
        public IEnumerable<DataSerieValues> Values { get; set; }

        public override bool Equals(object obj)
        {
            var dataserie = obj as DataSerie;
            if (dataserie == null) return false;
            
            return Location.Equals(Location, dataserie.Location) && 
                Enumerable.SequenceEqual<DataSerieValues>(Values, dataserie.Values);
        }

        public override int GetHashCode()
        {
            return Values.GetHashCode() ^ Location.GetHashCode();
        }
    }

    [DataContract]
    public class DataSerieValues
    {
        [DataMember(EmitDefaultValue = true, Name="value")]
        public double Value { get; set; }

        [DataMember(EmitDefaultValue = false, Name="axisDimension")]
        public DimensionFilter AxisDimension { get; set; }

        [DataMember(EmitDefaultValue = false, Name = "selectedDimensions")]
        public IEnumerable<DimensionFilter> SelectedDimensions { get; set; }

        public override bool Equals(object obj)
        {
            var dsValues = obj as DataSerieValues;
            if (dsValues == null) return false;

            return Value == dsValues.Value &&
                DimensionFilter.Equals(AxisDimension, dsValues.AxisDimension) &&
                Enumerable.SequenceEqual<DimensionFilter>(SelectedDimensions, dsValues.SelectedDimensions);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() ^ AxisDimension.GetHashCode() ^ SelectedDimensions.GetHashCode();
        }
    }
}
