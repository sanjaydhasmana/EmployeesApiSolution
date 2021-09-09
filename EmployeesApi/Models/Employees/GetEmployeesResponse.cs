using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Models.Employees
{
    public class GetEmployeesResponse: CollectionResponse<GetEmployeeResponseItem>
    {
    }

    public class GetEmployeeResponseItem
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
    }
}
