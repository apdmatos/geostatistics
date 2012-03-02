using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Model;
using System.Collections.Generic;

namespace DataStore.DAO.Tests
{
    
    
    /// <summary>
    ///This is a test class for ThemesDAOTest and is intended
    ///to contain all ThemesDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ThemesDAOTest
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
        ///A test for ThemesDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ThemesDAOConstructorTest()
        {
            ThemesDAO target = new ThemesDAO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetProviderSubThemes
        ///</summary>
        [TestMethod()]
        public void GetProviderSubThemesTest()
        {
            ThemesDAO target = new ThemesDAO(); // TODO: Initialize to an appropriate value
            int providerId = 0; // TODO: Initialize to an appropriate value
            int themeId = 0; // TODO: Initialize to an appropriate value
            IEnumerable<Theme> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Theme> actual;
            actual = target.GetProviderSubThemes(providerId, themeId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetProviderThemes
        ///</summary>
        [TestMethod()]
        public void GetProviderThemesTest()
        {
            ThemesDAO target = new ThemesDAO(); // TODO: Initialize to an appropriate value
            int providerId = 0; // TODO: Initialize to an appropriate value
            IEnumerable<Theme> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Theme> actual;
            actual = target.GetProviderThemes(providerId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
