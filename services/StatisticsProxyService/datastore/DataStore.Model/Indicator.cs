using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.Model
{
    public class Indicator
    {
        public int ID { get; set; }
        public Provider Provider { get; set; }
        public string SourceID { get; set; }
        public string Name { get; set; }
        public string NameAbbr { get; set; }
        public int ThemeID { get; set; }
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
