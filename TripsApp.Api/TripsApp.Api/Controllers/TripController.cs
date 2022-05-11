using MediatR;
using Microsoft.AspNetCore.Mvc;
using TripsApp.Api.Commands;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.Api.Queries;
using TripsApp.Api.Requests;

namespace TripsApp.Api.Controllers
{
    [ApiController]
    public class TripController : Controller
    {
        private readonly IMediator _mediator;

        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/trip")]
        public async Task<IActionResult> SaveTripAsync([FromBody] TripDto tripDto)
        {
            var command = new SaveTripCommand(tripDto);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("/trip/aggregation")]//REST Aggreetgation endpoint
        public async Task<IActionResult> GetTripSummaryAsync([FromQuery] TripSummaryRequest tripSummaryRequest)
        {
            var query = new GetTripSummaryQuery(tripSummaryRequest.VehicleId, tripSummaryRequest.StartDate, tripSummaryRequest.EndDate);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
