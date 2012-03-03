using DataStore.DAO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataStore.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataStore.DAO.Tests
{
    /// <summary>
    ///This is a test class for ProviderDAOTest and is intended
    ///to contain all ProviderDAOTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProviderDAOTest : BaseTestClass
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
        ///A test for ProviderDAO Constructor
        ///</summary>
        [TestMethod()]
        public void ProviderDAOConstructorTest()
        {
            ProviderDAO target = new ProviderDAO();
            Assert.AreNotEqual(target, null);
        }

        /// <summary>
        ///A test for GetProviders
        ///</summary>
        [TestMethod()]
        public void GetProvidersTest()
        {
            ProviderDAO target = new ProviderDAO();
            Nullable<int> page = new Nullable<int>(1);
            Nullable<int> recordsPerPage = new Nullable<int>(1);
            Provider expected = new Provider
            {
                ID = 1,
                Name = "Instituto Nacional de Estatística",
                NameAbbr = "INE",
                ServiceURL = "http://localhost:42136/INEStatisticsProvider.svc",
                URL = "http://www.ine.pt"
            };
            IEnumerable<Provider> actual;
            actual = target.GetProviders(page, recordsPerPage);
            Assert.AreEqual(1, actual.Count());
            Assert.AreEqual(expected, actual.ElementAt(0));
        }

        /// <summary>
        ///A test for GetTotalProviders
        ///</summary>
        [TestMethod()]
        public void GetTotalProvidersTest()
        {
            ProviderDAO target = new ProviderDAO();
            long expected = 1; 
            long actual;
            actual = target.GetTotalProviders();
            Assert.AreEqual(expected, actual);
        }
    }
}
