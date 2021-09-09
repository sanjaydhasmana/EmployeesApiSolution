using AutoMapper;
using EmployeesApi.Data;
using EmployeesApi.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Profiles
{
    public class EmployeeAutomapperProfile : Profile
    {
        public EmployeeAutomapperProfile()
        {
            CreateMap<Employee, GetEmployeeResponseItem>();
            CreateMap<Employee, GetEmployeeDetailsResponse>();
            CreateMap<PostEmployeeRequest, Employee>()
                .ForMember(dest => dest.IsActive, conf => conf.MapFrom(_ => true))
                .ForMember(dest => dest.HireDate, conf => conf.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.Salary, conf => conf.MapFrom(e => e.Department == "DEV" ? 200000 : 100000));
        }
    }
}
