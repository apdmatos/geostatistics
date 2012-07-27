using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.Common.Model;
using DataStore.DbHelpers.templates;
using DataStore.DAO.builders;
using System.Data;
using DataStore.DAO.utils;
using DataStore.Common.Data_Interfaces;
using System.Data.Common;

namespace DataStore.DAO
{
    public class ShapefileDAO : BaseDAO, IShapefileDAO
    {

        public ShapefileDAO() { }
        public ShapefileDAO(DbConnection connection) 
        {
            Connection = connection;
        }

        public IEnumerable<ShapefileGroup> GetShapefileGroups(int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<ShapefileGroup>.GetListByProcedure(
                    Connection,
                    DataStoreModelBuilders.DataReader2ShapefileGroup,
                    "config.getshapefilegroups",
                    new DbParameterHelper[]
                    {
                        new DbParameterHelper(DbType.Int32,     "p_page",               DbUtils.ReturnsDefaultDbNumber(page)),
                        new DbParameterHelper(DbType.Int32,     "p_recordsPerPage",     DbUtils.ReturnsDefaultDbNumber(recordsPerPage)),
                    });
        }

        public IEnumerable<Shapefile> GetShapefiles(int? shapefilegroupId, int? page, int? recordsPerPage)
        {
            return DbTemplateHelper<Shapefile>.GetListByProcedure(
                    Connection,
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
