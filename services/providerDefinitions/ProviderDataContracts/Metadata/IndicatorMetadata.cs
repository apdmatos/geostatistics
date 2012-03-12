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
        [DataMember(Name = "id", EmitDefaultValue = false)] 
        public string ID { get; set; }

        [DataMember(Name = "sourceid", EmitDefaultValue = false)]
        public int SourceID { get; set; }

        [DataMember(Name = "sourceName", EmitDefaultValue = false)]
        public string SourceName { get; set; }

        [DataMember(Name = "sourceNameAbbr", EmitDefaultValue = false)]
        public string SourceNameAbbr { get; set; }

        [DataMember(Name = "sourceURL", EmitDefaultValue = false)]
        public string SourceURL { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string IndicatorName { get; set; }

        [DataMember(Name = "nameAbbr", EmitDefaultValue = false)]
        public string IndicatorNameAbbr { get; set; }

        [DataMember(Name = "dimensions", EmitDefaultValue = false)]
        public IEnumerable<Dimension> Dimensions { get; set; }

        [DataMember(Name = "lastUpdate", EmitDefaultValue = false)]
        public DateTime LastUpdate { get; set; }

        public override bool Equals(object obj)
        {
            IndicatorMetadata metadata = obj as IndicatorMetadata;
            if (metadata == null) return false;       

            return string.Equals(ID, metadata.ID) && 
                string.Equals(SourceID, metadata.SourceID) && 
                string.Equals(SourceName, metadata.SourceName) &&
                string.Equals(SourceNameAbbr, metadata.SourceNameAbbr) && 
                string.Equals(SourceURL, metadata.SourceURL) && 
                string.Equals(IndicatorName, metadata.IndicatorName) &&
                string.Equals(IndicatorNameAbbr, metadata.IndicatorNameAbbr) && 
                Enumerable.SequenceEqual<Dimension>(Dimensions, metadata.Dimensions) && 
                DateTime.Equals(LastUpdate, metadata.LastUpdate);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode() ^ SourceID.GetHashCode();
        }
    }
}
