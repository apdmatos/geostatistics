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

        [DataMember(EmitDefaultValue = false)]
        public IEnumerable<DataSerieValues> Values { get; set; }
    }

    [DataContract]
    public class DataSerieValues
    {
        [DataMember(EmitDefaultValue = true)]
        public double Value { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DimensionFilter AxisDimension { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public IEnumerable<DimensionFilter> SelectedDimensions { get; set; }
    }
}
