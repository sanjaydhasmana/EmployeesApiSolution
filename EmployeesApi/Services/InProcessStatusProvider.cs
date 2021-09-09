using EmployeesApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class InProcessStatusProvider : IProvideStatus
    {
        public Task<GetStatusResponse> GetCurrentStatusAsync()
        {
            var response = new GetStatusResponse
            {
                Message = "Good as far as I can tell",
                WhenChecked = DateTime.Now,
                StandByDeveloper = new StandbyDeveloperInfo
                {
                    EmailAddress = "greg@aol",
                    Name = "Greg Noble"
                }

            };
            return Task.FromResult(response);
        }
    }
}
