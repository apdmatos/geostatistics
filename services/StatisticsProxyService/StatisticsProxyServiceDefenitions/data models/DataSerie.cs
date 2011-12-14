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
    }
}
