using Microsoft.AspNetCore.Mvc;
using TripsApp.Api.Dtos;
using TripsApp.Domain.Models;

namespace TripsApp.Api.Controllers
{
    [ApiController]
    public class TripController : Controller
    {
        [HttpPost]
        [Route("/trip")]
        public async Task<IActionResult> SaveTrip([FromBody] Trip trip)
        {
            //Use service to write Trip into db.
            return Ok();
        }

        [HttpGet]
        [Route("/trip/vehicle/{id}")]
        public async Task<IActionResult> GetTrips([FromQuery] TripRequest tripRequest)
        {
            //return TripResponse from service with aggregated data.
            return Ok();
        }
    }
}
