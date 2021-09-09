using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Data
{
    public class EmployeesDataContext : DbContext
    {
        public EmployeesDataContext(DbContextOptions<EmployeesDataContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasData(
                    new Employee {  Id=1, FirstName = "Bob", LastName="Smith", Department="QA", HireDate=DateTime.Now.AddDays(-300), IsActive=true, Salary=180000},
                    new Employee {  Id =2, FirstName="Sue", LastName = "Jones", Department="CEO", HireDate=DateTime.Now.AddDays(-(365*5)), IsActive = true, Salary = 250000},
                    new Employee {  Id=3, FirstName ="Ray", LastName="Palmer", Department=null, HireDate=DateTime.Now.AddDays(-200), Salary=0, IsActive=false}
                );
        }
    }
}
