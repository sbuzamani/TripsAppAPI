using Microsoft.AspNetCore.Mvc;
using TripsApp.Api.Dtos;
using TripsApp.ApplicationServices.Services;
using TripsApp.Domain.Models;
//using MediatR;

namespace TripsApp.Api.Controllers
{
    [ApiController]
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        //private readonly IMedaitor _mediator;
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpPost]
        [Route("/trip")]
        public async Task<IActionResult> SaveTripAsync([FromBody] TripDto tripDto)
        {
            //Use service to write Trip into db.
            //TODO Validate dto
            var trip = new Trip
            {
                CountryId = tripDto.CountryId,
                Distance = tripDto.Distance,
                TimeStamp = tripDto.TimeStamp,
                VehicleId = tripDto.VehicleId
            };


            var result = await _tripService.SaveTripAsync(trip);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("/trip/vehicle/{id}/daterange/{startDate}/{endDate}")]
        public async Task<IActionResult> GetTripSummaryAsync(Guid id, DateTime startDate, DateTime endDate)
        {
            var result = await _tripService.GetTripsSummaryAsync(id, startDate, endDate);

            if (result == null)
            {
                return NoContent();
            }

            var value = new TripResponse
            {
                VehicleId = result.VehicleId,
                CalculatedCost = result.CalculatedCost,
                TotalKms = result.TotalKms,
                CountryName = result.Country,
                EstimatedCost = result.EstimatedCost
            };

            return Ok(value);
        }
    }
}
