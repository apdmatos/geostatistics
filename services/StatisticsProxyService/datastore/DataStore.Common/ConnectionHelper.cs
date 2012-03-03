using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace DataStore.DbHelpers
{
    public class ConnectionHelper
    {
        public static string ConnectionString { get; set; }
        public static string Provider { get; set; }

        public static DbConnection CreateDBConnection()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(Provider);
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = ConnectionString;

            return conn;
        }
    }
}
