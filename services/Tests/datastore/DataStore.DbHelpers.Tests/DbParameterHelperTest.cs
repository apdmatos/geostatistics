using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStore.DbHelpers.templates;
using System.Data;
using System.Data.Common;

namespace DataStore.DbHelpers.Tests
{
    /// <summary>
    /// Summary description for DbParameterHelperTest
    /// </summary>
    [TestClass]
    public class DbParameterHelperTest : BaseTestClass
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

        [TestMethod]
        public void CanCreateAParameterHelperCorrectly()
        {
            DbParameterHelper parameter = new DbParameterHelper(DbType.String, "test", "somevalue");

            Assert.AreEqual(parameter.DbType,       DbType.String);
            Assert.AreEqual(parameter.Name,         "test");
            Assert.AreEqual(parameter.Value,        "somevalue");
            Assert.AreEqual(parameter.Direction,    ParameterDirection.Input);
        }

        [TestMethod]
        public void CreateAParameterWithParameterDirection()
        {
            DbParameterHelper parameter = new DbParameterHelper(DbType.String, "test", "somevalue", ParameterDirection.Output);

            Assert.AreEqual(parameter.DbType,       DbType.String);
            Assert.AreEqual(parameter.Name,         "test");
            Assert.AreEqual(parameter.Value,        "somevalue");
            Assert.AreEqual(parameter.Direction,    ParameterDirection.Output);
        }

        //[TestMethod]
        //public void CanCreateADbParameterByDbCommand()
        //{
        //    DbConnection conn = ConnectionHelper.CreateDBConnection();
        //    DbCommand cmd = conn.CreateCommand();

        //    DbParameterHelper parameter = new DbParameterHelper(DbType.String, "test", "somevalue");
        //    IDataParameter dbparam = parameter.ToDbParameter(cmd);

        //    Assert.AreEqual(dbparam.DbType,         DbType.String);
        //    Assert.AreEqual(dbparam.ParameterName,  "test");
        //    Assert.AreEqual(dbparam.Value,          "somevalue");
        //    Assert.AreEqual(dbparam.Direction,      ParameterDirection.Input);

        //}
    }
}
