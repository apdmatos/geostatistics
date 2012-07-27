using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStore.DAO.Tests
{
    public class BaseTestClass
    {
        static BaseTestClass()
        {
            ConnectionSettings.SetConnectionSettings(
                ConfigurationManager.ConnectionStrings["testdb"].ConnectionString,
                ConfigurationManager.ConnectionStrings["testdb"].ProviderName);
        }

        public DbConnection connnetion;

        [TestInitialize]
        public void SetUpConnection() {
            connnetion = ConnectionSettings.CreateDBConnection();
        }

        [TestCleanup]
        public void ShutDownConnection()
        {
            connnetion.Dispose();
        }
    }
}
