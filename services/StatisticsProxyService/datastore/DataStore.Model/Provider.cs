using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.Model
{
    public class Provider
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAbbr { get; set; }
        public string ServiceURL { get; set; }
        public string URL { get; set; }
    }
}
