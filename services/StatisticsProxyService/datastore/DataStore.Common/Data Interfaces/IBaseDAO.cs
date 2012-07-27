using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace DataStore.DTO.Data_Interfaces
{
    public interface IBaseDAO
    {
        DbConnection Connection { get; set; }
    }
}