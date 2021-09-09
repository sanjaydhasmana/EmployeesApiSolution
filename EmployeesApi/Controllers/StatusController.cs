
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class StatusController : ControllerBase
    {
        private readonly IProvideStatus _statusProvider;

        public StatusController(IProvideStatus statusProvider)
        {
            _statusProvider = statusProvider;
        }



        // GET /status -> 200
        [HttpGet("status")] // Attributes
        public async Task<ActionResult> GetTheStatus()
        {
            // WTCYWYH
            GetStatusResponse response = await _statusProvider.GetCurrentStatusAsync();
            return Ok(response);
        }
    }


    public class GetStatusResponse
    {
        public string Message { get; set; }
        public DateTime WhenChecked { get; set; }
        public StandbyDeveloperInfo StandByDeveloper { get; set; }
    }

    public class StandbyDeveloperInfo
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
    }

}
