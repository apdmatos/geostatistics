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
    }
}
