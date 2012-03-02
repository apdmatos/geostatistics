using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.Model
{
    public class ShapefileGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Shapefile
    {
        public ShapefileGroup Group { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public int Level { get; set; }
    }
}
