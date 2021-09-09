using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Models.Employees
{
    //public class GetEmployeeDetailsResponse
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Department { get; set; }
    //    public decimal Salary { get; set; }
    //}
    public record GetEmployeeDetailsResponse(int Id, string FirstName, string LastName, string Department, decimal Salary);
}
