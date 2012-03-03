using DataStore.DAO.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStore.DAO.Tests
{
    /// <summary>
    ///This is a test class for DbUtilsTest and is intended
    ///to contain all DbUtilsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DbUtilsTest
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
        ///A test for DbUtils Constructor
        ///</summary>
        [TestMethod()]
        public void DbUtilsConstructorTest()
        {
            DbUtils target = new DbUtils();
            Assert.AreNotEqual(target, null);
        }

        /// <summary>
        ///A test for ReturnsDefaultDbNumber
        ///</summary>
        [TestMethod()]
        public void ReturnsDefaultDbNumberShouldReturnANumberTest()
        {
            Nullable<int> n = new Nullable<int>(1);
            int expected = 1;
            object actual;
            actual = DbUtils.ReturnsDefaultDbNumber(n);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ReturnsDefaultDbNumber
        ///</summary>
        [TestMethod()]
        public void ReturnsDefaultDbNumberShouldReturnDbNull()
        {
            object expected = DBNull.Value;
            object actual;
            actual = DbUtils.ReturnsDefaultDbNumber(null);
            Assert.AreEqual(expected, actual);
        }
    }
}
