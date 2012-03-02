using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.DAO.utils
{
    internal class DbUtils
    {
        public static object ReturnsDefaultDbNumber(int? n)
        {
            if (n.HasValue) return n.Value;
            return DBNull.Value;
        }
    }
}
