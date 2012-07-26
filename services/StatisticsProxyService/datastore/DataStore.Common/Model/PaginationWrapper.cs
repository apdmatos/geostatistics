using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DataStore.Common.Model
{
    [DataContract]
    public class PaginationWrapper<T>
    {
        [DataMember(EmitDefaultValue = false)]
        public IEnumerable<T> Elements { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int Page { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int RecordsPerPage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public long Total { get; set; }
    }
}
