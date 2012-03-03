using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStore.Common.Model
{
    public class PaginationWrapper<T>
    {
        public List<T> Elements { get; set; }
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
        public int Total { get; set; }
    }
}
