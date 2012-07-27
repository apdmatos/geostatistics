using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace DataStore.DAO
{
    public static class ConnectionSettings
    {
        public static string ConnectionString { get; set; }
        public static string Provider { get; set; }

        public static void SetConnectionSettings(string connectionString, string provider)
        {
            ConnectionString = connectionString;
            Provider = provider;
        }

        public static DbConnection CreateDBConnection()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = ConnectionString;

            return conn;
        }
    }
}
