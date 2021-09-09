using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeesApi.Data;
using EmployeesApi.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class EfSqlServerEmployeeData : IManageEmployeeData
    {
        private readonly EmployeesDataContext _context;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfig;

        public EfSqlServerEmployeeData(EmployeesDataContext context, IMapper mapper, MapperConfiguration mapperConfig)
        {
            _context = context;
            _mapper = mapper;
            _mapperConfig = mapperConfig;
        }

        public async Task<GetEmployeesResponse> GetAllActiveEmployeesAsync()
        {
            var employees = await _context.Employees
               .Where(e => e.IsActive)
               .ProjectTo<GetEmployeeResponseItem>(_mapperConfig)
               .ToListAsync();

            var response = new GetEmployeesResponse
            {
                Data = employees
            };
            return response;
        }

        public async Task<GetEmployeeDetailsResponse> GetEmployeeDetailsAsync(int id)
        {
            var response = await _context.Employees
                .Where(e => e.Id == id && e.IsActive)
                .ProjectTo<GetEmployeeDetailsResponse>(_mapperConfig)
                .SingleOrDefaultAsync();

            return response;

        }

        public async Task<GetEmployeeDetailsResponse> HireAsync(PostEmployeeRequest request)
        {
            var employee = _mapper.Map<Employee>(request);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<GetEmployeeDetailsResponse>(employee);
            return response;
        }
    }
}
