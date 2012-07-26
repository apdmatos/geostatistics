using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataStore.Common.Model
{
    [DataContract]
    public class Theme
    {
        [DataMember(EmitDefaultValue = false)]
        public int ID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int ProviderID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string NameAbbr { get; set; }

        public override bool Equals(object obj)
        {
            Theme theme = obj as Theme;
            if (theme == null) return false;
            return ID == theme.ID && ProviderID == theme.ProviderID && 
                String.Equals(Name, theme.Name) && String.Equals(NameAbbr, theme.NameAbbr);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }

    public class SubTheme
    {
        public int ID { get; set; }
        public int ThemeID { get; set; }
        public int ProviderID { get; set; }
        public string Name { get; set; }
        public string NameAbbr { get; set; }

        public override bool Equals(object obj)
        {
            SubTheme subtheme = obj as SubTheme;
            if (subtheme == null) return false;

            return ID == subtheme.ID && ThemeID == subtheme.ThemeID && ProviderID == subtheme.ProviderID &&
                String.Equals(Name, subtheme.Name) && String.Equals(NameAbbr, subtheme.NameAbbr);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
