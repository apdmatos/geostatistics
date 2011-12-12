using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ProviderDataContracts.Metadata
{
    [DataContract]
    public class IndicatorMetadata
    {
        [DataMember(Name="id")] 
        public string ID { get; set; }

        [DataMember(Name = "sourceid")]
        public string SourceID { get; set; }

        [DataMember(Name = "sourceName")]
        public string SourceName { get; set; }

        [DataMember(Name = "sourceNameAbbr")]
        public string SourceNameAbbr { get; set; }

        [DataMember(Name = "sourceURL")]
        public string SourceURL { get; set; }

        [DataMember(Name = "name")]
        public string IndicatorName { get; set; }

        [DataMember(Name = "nameAbbr")]
        public string IndicatorNameAbbr { get; set; }

        [DataMember(Name = "dimensions")]
        public IEnumerable<Dimension> Dimensions { get; set; }

        [DataMember(Name = "lastUpdate")]
        public DateTime LastUpdate { get; set; }
    }
}
