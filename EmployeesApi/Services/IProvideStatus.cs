using EmployeesApi.Controllers;
using System.Threading.Tasks;

namespace EmployeesApi
{
    public interface IProvideStatus
    {
        Task<GetStatusResponse> GetCurrentStatusAsync();
    }
}