using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataStore.DTO.Data_Interfaces;
using System.Data.Common;
using System.Data;

namespace DataStore.DAO
{
    public class BaseDAO : IBaseDAO
    {
        public DbConnection Connection
        {
            get;
            set;
        }
    }
}
