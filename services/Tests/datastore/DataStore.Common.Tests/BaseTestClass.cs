﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataStore.Common.Tests
{
    public class BaseTestClass
    {
        static BaseTestClass()
        {
            ConnectionHelper.ConnectionString = ConfigurationManager.ConnectionStrings["testdb"].ConnectionString;
            ConnectionHelper.Provider = ConfigurationManager.ConnectionStrings["testdb"].ProviderName;
        }
    }
}