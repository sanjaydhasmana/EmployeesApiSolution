using EmployeesApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeesApi.Services
{
    public class ApiOnCallService
    {
        private readonly HttpClient _client;

        public ApiOnCallService(HttpClient client)
        {
            _client = client;
        }

        public async Task<StandbyDeveloperInfo> GetDeveloperInfoAsync()
        {
            var response = await _client.GetAsync("/oncall");
            var content = await response.Content.ReadAsStringAsync();

            var developerInfo = JsonSerializer.Deserialize<StandbyDeveloperInfo>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return developerInfo;

        }
    }
}
