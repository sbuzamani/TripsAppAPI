using Microsoft.AspNetCore.Mvc;
using TripsApp.Api.Dtos;
using TripsApp.ApplicationServices.Services;
using TripsApp.Domain.Models;

namespace TripsApp.Api.Controllers
{
    [ApiController]
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpPost]
        [Route("/trip")]
        public async Task<IActionResult> SaveTripAsync([FromBody] Trip trip)
        {
            //Use service to write Trip into db.
            var result = await _tripService.SaveTripAsync(trip);

            if (!result)
            {
                return StatusCode(500);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("/trip/vehicle/{id}")]
        public async Task<IActionResult> GetTripSummaryAsync([FromQuery] TripRequest tripRequest)
        {
            //return TripResponse from service with aggregated data.
            var result = await _tripService.GetTripsSummaryAsync(tripRequest.VehicleId, tripRequest.StartDate, tripRequest.EndDate);

            if (result == null)
            {
                return NoContent();
            }

            var value = new TripResponse
            {
                VehicleId = result.VehicleId,
                CalculatedCost = result.CalculatedCost,
                TotalKms = result.TotalKms
            };

            return Ok(value);
        }
    }
}
