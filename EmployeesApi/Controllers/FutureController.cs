using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class FutureController : ControllerBase
    {

        private readonly IFeatureManager _featureManager;

        public FutureController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        [HttpGet("future")]
        [FeatureGate("future")]
        public ActionResult InTheFuture()
        {
          
            return Ok("This is not ready yet!!");
        }
    }
}
