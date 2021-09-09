using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesApi.Controllers
{
    public class DemoController : ControllerBase
    {
        // In the Url itself (RouteData)
        // GET /products/83989389
        [HttpGet("products/{sku:int}")]
        public ActionResult LookUpProduct(int sku)
        {
            return Ok($"Here is product {sku}");
        }

        [HttpGet("/orders/{year:int}/{month:int:range(1,12)}/{day:int:range(1,31)}")]
        public ActionResult GetOrderForDate(int year, int month, int day)
        {
            return Ok($"Getting orders for {year}-{month}-{day}");
        }

        [HttpGet("/orders")] // Query strings only make sens on "queries", which are GET requests on
        // collections. (this means  if you are using query strings on a post or something, you 
        // probably should rethink your design.
        public ActionResult GetOrders([FromQuery(Name = "sold-by")] string soldBy = "all")
        {
            return Ok($"Getting you all the orders sold by {soldBy}");
        }

        [HttpGet("/workers")]
        public ActionResult GetWorkers(string department = "all")
        {
            return Ok($"Getting workers in the department {department}");
        }

        [HttpGet("whoami")]
        public ActionResult GetUserAgent([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Ok($"You are telling me you are running {userAgent}");
        }

        [HttpPost("orders")]
        public ActionResult PlaceAnOrder([FromBody]PostOrderRequest order)
        {
            return Ok($"Placing an order for {order.For} for {order.Items.Count} items.");
        }


    }


    public class PostOrderRequest
    {
        public string For { get; set; }
        public List<int> Items { get; set; }
    }

}

