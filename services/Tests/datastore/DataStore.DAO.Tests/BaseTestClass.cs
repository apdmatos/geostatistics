using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

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
    }
}
