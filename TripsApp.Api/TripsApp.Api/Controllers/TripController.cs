using MediatR;
using Microsoft.AspNetCore.Mvc;
using TripsApp.Api.Commands;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.Api.Queries;

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
        [Route("/trip/vehicle/{id}/daterange/{startDate}/{endDate}")]
        public async Task<IActionResult> GetTripSummaryAsync([FromRoute] Guid id, [FromRoute] DateTime startDate, [FromRoute] DateTime endDate)
        {
            var query = new GetTripSummaryQuery(id, startDate, endDate);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
    }
}
