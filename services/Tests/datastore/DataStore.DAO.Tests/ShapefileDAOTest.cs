using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Model;
using System.Collections.Generic;

namespace DataStore.DAO.Tests
{
    
    
    /// <summary>
    ///This is a test class for ShapefileDAOTest and is intended
    ///to contain all ShapefileDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ShapefileDAOTest
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

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ShapefileDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ShapefileDAOConstructorTest()
        {
            ShapefileDAO target = new ShapefileDAO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetShapefile
        ///</summary>
        [TestMethod()]
        public void GetShapefileTest()
        {
            ShapefileDAO target = new ShapefileDAO(); // TODO: Initialize to an appropriate value
            Nullable<int> shapefilegroupId = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> page = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> recordsPerPage = new Nullable<int>(); // TODO: Initialize to an appropriate value
            IEnumerable<Shapefile> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Shapefile> actual;
            actual = target.GetShapefile(shapefilegroupId, page, recordsPerPage);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetShapefileGroups
        ///</summary>
        [TestMethod()]
        public void GetShapefileGroupsTest()
        {
            ShapefileDAO target = new ShapefileDAO(); // TODO: Initialize to an appropriate value
            Nullable<int> page = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> recordsPerPage = new Nullable<int>(); // TODO: Initialize to an appropriate value
            IEnumerable<ShapefileGroup> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<ShapefileGroup> actual;
            actual = target.GetShapefileGroups(page, recordsPerPage);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
