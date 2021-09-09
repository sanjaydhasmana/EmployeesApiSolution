using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Models
{
    public class CollectionResponse<T>
    {
        public List<T> Data { get; set; }
    }
}
