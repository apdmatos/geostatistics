using System;
using System.Collections.Generic;
using DataStore.Common.Model;

namespace DataStore.Common.Data_Interfaces
{
    public interface IShapefileDAO
    {
        IEnumerable<ShapefileGroup> GetShapefileGroups(int? page, int? recordsPerPage);

        IEnumerable<Shapefile> GetShapefiles(int? shapefilegroupId, int? page, int? recordsPerPage);
    }
}
