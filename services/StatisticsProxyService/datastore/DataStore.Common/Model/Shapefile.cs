using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataStore.Common.Model
{
    [DataContract]
    public class ShapefileGroup
    {
        [DataMember(EmitDefaultValue = false)]
        public int ID { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            ShapefileGroup group = obj as ShapefileGroup;
            if (group == null) return false;

            return ID == group.ID && String.Equals(Name, group.Name);
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }

    public class Shapefile
    {
        public ShapefileGroup Group { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public int Level { get; set; }

        public override bool Equals(object obj)
        {
            Shapefile shapefile = obj as Shapefile;
            if (shapefile == null) return false;
            
            return ShapefileGroup.Equals(Group, shapefile.Group) && ID == shapefile.ID && String.Equals(Name, shapefile.Name) &&
                String.Equals(Path, shapefile.Path) && String.Equals(FileName, shapefile.FileName) && Level == shapefile.Level;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
