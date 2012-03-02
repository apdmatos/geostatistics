using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Model;
using System.Collections.Generic;

namespace DataStore.DAO.Tests
{
    
    
    /// <summary>
    ///This is a test class for IndicatorDAOTest and is intended
    ///to contain all IndicatorDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IndicatorDAOTest
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
        ///A test for IndicatorDAO Constructor
        ///</summary>
        [TestMethod()]
        public void IndicatorDAOConstructorTest()
        {
            IndicatorDAO target = new IndicatorDAO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetIndicatorById
        ///</summary>
        [TestMethod()]
        public void GetIndicatorByIdTest()
        {
            IndicatorDAO target = new IndicatorDAO(); // TODO: Initialize to an appropriate value
            int indicatorId = 0; // TODO: Initialize to an appropriate value
            Indicator expected = null; // TODO: Initialize to an appropriate value
            Indicator actual;
            actual = target.GetIndicatorById(indicatorId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIndicatorsByProviderId
        ///</summary>
        [TestMethod()]
        public void GetIndicatorsByProviderIdTest()
        {
            IndicatorDAO target = new IndicatorDAO(); // TODO: Initialize to an appropriate value
            int providerId = 0; // TODO: Initialize to an appropriate value
            Nullable<int> page = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> recordsPerPage = new Nullable<int>(); // TODO: Initialize to an appropriate value
            IEnumerable<Indicator> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Indicator> actual;
            actual = target.GetIndicatorsByProviderId(providerId, page, recordsPerPage);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetIndicatorsBySubThemeId
        ///</summary>
        [TestMethod()]
        public void GetIndicatorsBySubThemeIdTest()
        {
            IndicatorDAO target = new IndicatorDAO(); // TODO: Initialize to an appropriate value
            int providerId = 0; // TODO: Initialize to an appropriate value
            int themeId = 0; // TODO: Initialize to an appropriate value
            int subthemeId = 0; // TODO: Initialize to an appropriate value
            Nullable<int> page = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> recordsPerPage = new Nullable<int>(); // TODO: Initialize to an appropriate value
            IEnumerable<Indicator> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Indicator> actual;
            actual = target.GetIndicatorsBySubThemeId(providerId, themeId, subthemeId, page, recordsPerPage);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTotalIndicators
        ///</summary>
        [TestMethod()]
        public void GetTotalIndicatorsTest()
        {
            IndicatorDAO target = new IndicatorDAO(); // TODO: Initialize to an appropriate value
            int providerId = 0; // TODO: Initialize to an appropriate value
            Nullable<int> themeId = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> subThemeId = new Nullable<int>(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetTotalIndicators(providerId, themeId, subThemeId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
