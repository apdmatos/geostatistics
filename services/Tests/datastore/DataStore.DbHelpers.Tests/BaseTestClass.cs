using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Common;

namespace DataStore.DbHelpers.Tests
{
    public class BaseTestClass
    {

        public static string ConnectionString;
        public static string Provider;

        static BaseTestClass()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["testdb"].ConnectionString;
            Provider = ConfigurationManager.ConnectionStrings["testdb"].ProviderName;
        }

        public DbConnection CreateDBConnection()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = ConnectionString;

            return conn;
        }
    }
}
