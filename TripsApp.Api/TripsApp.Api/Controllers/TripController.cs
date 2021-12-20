using Microsoft.AspNetCore.Mvc;
using TripsApp.Domain.Models;

namespace TripsApp.Api.Controllers
{
    [ApiController]
    public class TripController : Controller
    {
        [HttpPost]
        [Route("/trip")]
        public IActionResult Index([FromBody] Trip trip)
        {
            return Ok();
        }

        [HttpGet]
        [Route("/trip/vehicle/{id}")]
        public IActionResult Index([FromQuery] int id)
        {

            return Ok();
        }
    }
}
