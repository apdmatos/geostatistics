using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Common.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataStore.DAO.Tests
{
    /// <summary>
    ///This is a test class for ShapefileDAOTest and is intended
    ///to contain all ShapefileDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShapefileDAOTest : BaseTestClass
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        /// <summary>
        ///A test for ShapefileDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ShapefileDAOConstructorTest()
        {
            ShapefileDAO target = new ShapefileDAO(connnetion);
            Assert.AreNotEqual(target, null);
        }

        /// <summary>
        ///A test for GetShapefile
        ///</summary>
        [TestMethod()]
        public void GetShapefilesByFileGroupTest()
        {
            ShapefileDAO target = new ShapefileDAO(connnetion);
            Nullable<int> shapefilegroupId = new Nullable<int>(1);
            Nullable<int> page = new Nullable<int>(1);
            Nullable<int> recordsPerPage = new Nullable<int>(1);
            Shapefile expected = new Shapefile
            {
                ID = 1,
                FileName = "distritos.shp",
                Group = new ShapefileGroup
                {
                    ID = 1,
                    Name = "concelhos distritos e freguesias de portugal"
                },
                Level = 1,
                Name = "distritos",
                Path = "D:\\Dropbox\\My Dropbox\\Tese\\shapefiles\\sapo\\GIS\\Distritos"
            };
            IEnumerable<Shapefile> actual = target.GetShapefiles(shapefilegroupId, page, recordsPerPage);
            
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.ElementAt(0));
        }

        /// <summary>
        ///A test for GetShapefile
        ///</summary>
        [TestMethod()]
        public void GetAllShapefilesTest()
        {
            ShapefileDAO target = new ShapefileDAO(connnetion);
            Nullable<int> shapefilegroupId = new Nullable<int>(1);
            Nullable<int> page = null;
            Nullable<int> recordsPerPage = null;
            IEnumerable<Shapefile> actual = target.GetShapefiles(shapefilegroupId, page, recordsPerPage);
            
            Assert.AreEqual(3, actual.Count());
        }

        /// <summary>
        ///A test for GetShapefileGroups
        ///</summary>
        [TestMethod()]
        public void GetShapefileGroupsByPageNumberTest()
        {
            ShapefileDAO target = new ShapefileDAO(connnetion);
            Nullable<int> page = new Nullable<int>(1);
            Nullable<int> recordsPerPage = new Nullable<int>(1);
            ShapefileGroup expected = new ShapefileGroup
            {
                ID = 1,
                Name = "concelhos distritos e freguesias de portugal"
            };
            IEnumerable<ShapefileGroup> actual = target.GetShapefileGroups(page, recordsPerPage);
            
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.ElementAt(0));
        }

        /// <summary>
        ///A test for GetShapefileGroups
        ///</summary>
        [TestMethod()]
        public void GetAllShapefileGroupsTest()
        {
            ShapefileDAO target = new ShapefileDAO(connnetion);
            Nullable<int> page = null;
            Nullable<int> recordsPerPage = null;
            IEnumerable<ShapefileGroup> actual = target.GetShapefileGroups(page, recordsPerPage);
            Assert.AreEqual(2, actual.Count());
        }
    }
}
