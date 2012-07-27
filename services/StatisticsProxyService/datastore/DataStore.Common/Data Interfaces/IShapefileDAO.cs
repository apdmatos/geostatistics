using System;
using System.Collections.Generic;
using DataStore.Common.Model;
using DataStore.DTO.Data_Interfaces;

namespace DataStore.Common.Data_Interfaces
{
    public interface IShapefileDAO : IBaseDAO
    {
        IEnumerable<ShapefileGroup> GetShapefileGroups(int? page, int? recordsPerPage);

        IEnumerable<Shapefile> GetShapefiles(int? shapefilegroupId, int? page, int? recordsPerPage);
    }
}
