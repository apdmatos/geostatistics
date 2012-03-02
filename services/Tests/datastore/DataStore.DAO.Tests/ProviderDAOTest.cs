using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Model;
using System.Collections.Generic;

namespace DataStore.DAO.Tests
{
    
    
    /// <summary>
    ///This is a test class for ProviderDAOTest and is intended
    ///to contain all ProviderDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProviderDAOTest
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
        ///A test for ProviderDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ProviderDAOConstructorTest()
        {
            ProviderDAO target = new ProviderDAO();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetProviders
        ///</summary>
        [TestMethod()]
        public void GetProvidersTest()
        {
            ProviderDAO target = new ProviderDAO(); // TODO: Initialize to an appropriate value
            Nullable<int> page = new Nullable<int>(); // TODO: Initialize to an appropriate value
            Nullable<int> recordsPerPage = new Nullable<int>(); // TODO: Initialize to an appropriate value
            IEnumerable<Provider> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Provider> actual;
            actual = target.GetProviders(page, recordsPerPage);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetTotalProviders
        ///</summary>
        [TestMethod()]
        public void GetTotalProvidersTest()
        {
            ProviderDAO target = new ProviderDAO(); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.GetTotalProviders();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
