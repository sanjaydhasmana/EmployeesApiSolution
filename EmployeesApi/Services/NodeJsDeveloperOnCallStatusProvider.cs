using EmployeesApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class NodeJsDeveloperOnCallStatusProvider : IProvideStatus
    {
        private readonly ApiOnCallService _service;

        public NodeJsDeveloperOnCallStatusProvider(ApiOnCallService service)
        {
            _service = service;
        }

        public async Task<GetStatusResponse> GetCurrentStatusAsync()
        {
            var response = new GetStatusResponse
            {
                Message = "Looks Good Yo.",
                WhenChecked = DateTime.Now,
                StandByDeveloper = await _service.GetDeveloperInfoAsync()
            };
            return response;
        }
    }
}
