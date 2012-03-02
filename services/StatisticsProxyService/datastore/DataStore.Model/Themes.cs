using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.Model
{
    public class Theme
    {
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public string Name { get; set; }
        public string NameAbbr { get; set; }
    }

    public class SubTheme
    {
        public int ID { get; set; }
        public int ThemeID { get; set; }
        public int ProviderID { get; set; }
        public string Name { get; set; }
        public string NameAbbr { get; set; }
    }
}
