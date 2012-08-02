using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataStore.Common.Model
{
    [DataContract]
    public class Indicator
    {
        [DataMember(EmitDefaultValue=false)]
        public int ID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Provider Provider { get; set; }

        //[DataMember(EmitDefaultValue = false)]
        public string SourceID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string NameAbbr { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int ThemeID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int SubThemeID { get; set; }


        public override bool Equals(object obj)
        {
            Indicator ind = obj as Indicator;
            if (ind == null) return false;

            return ID == ind.ID && Provider.Equals(Provider, ind.Provider) && String.Equals(SourceID, ind.SourceID) &&
                String.Equals(Name, ind.Name) && String.Equals(NameAbbr, ind.NameAbbr) && ThemeID == ind.ThemeID && 
                SubThemeID == ind.SubThemeID;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
