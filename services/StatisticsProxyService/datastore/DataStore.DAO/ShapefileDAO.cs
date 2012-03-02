using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Model;
using DataStore.Common.templates;
using DataStore.DAO.builders;
using System.Data;
using DataStore.DAO.utils;

namespace DataStore.DAO
{
    public class ShapefileDAO
    {
        public IEnumerable<ShapefileGroup> GetShapefileGroups(int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<ShapefileGroup>.GetListByProcedure(
                    DataStoreModelBuilders.DataReader2ShapefileGroup,
                    "config.getshapefilegroups",
                    new DbParameterHelper[]
                    {
                        new DbParameterHelper(DbType.Int32,     "p_page",               DbUtils.ReturnsDefaultDbNumber(page)),
                        new DbParameterHelper(DbType.Int32,     "p_recordsPerPage",     DbUtils.ReturnsDefaultDbNumber(recordsPerPage)),
                    });
        }

        public IEnumerable<Shapefile> GetShapefile(int? shapefilegroupId, int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<Shapefile>.GetListByProcedure(
                    DataStoreModelBuilders.DataReader2Shapefile,
                    "config.getShapefiles",
                    new DbParameterHelper[]
                    {
                        new DbParameterHelper(DbType.Int32,     "p_shapefilegroupId",   DbUtils.ReturnsDefaultDbNumber(shapefilegroupId)),
                        new DbParameterHelper(DbType.Int32,     "p_page",               DbUtils.ReturnsDefaultDbNumber(page)),
                        new DbParameterHelper(DbType.Int32,     "p_recordsPerPage",     DbUtils.ReturnsDefaultDbNumber(recordsPerPage)),
                    });
        }
    }
}
