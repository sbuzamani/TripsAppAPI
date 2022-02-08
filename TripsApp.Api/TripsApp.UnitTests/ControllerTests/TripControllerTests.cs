using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using TripsApp.Api.Controllers;
using TripsApp.Api.Dtos;
using TripsApp.ApplicationServices.Services;
using TripsApp.Domain.Repositories;
using TripsApp.UnitTests.MockData;
using Xunit;

namespace TripsApp.UnitTests.ControllerTests
{
    public class TripControllerTests
    {
        private readonly TripController _tripController;
        private readonly Mock<ITripService> _tripService;
        private readonly Mock<ITripRepository> _tripRepository;

        public TripControllerTests()
        {
            _tripService = new Mock<ITripService>();
            _tripRepository = new Mock<ITripRepository>();
            _tripController = new TripController(_tripService.Object);
        }

        [Fact]
        public async Task GetTrips_ValidRequest_ReturnsTripsResponse()
        {
            _tripService.Setup(x => x.GetTripsSummaryAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(DtoMocks.GetVehicleTrip());
            var tripRequestBody = DtoMocks.TripRequestMock();

            var result = (OkObjectResult)await _tripController.GetTripSummaryAsync(tripRequestBody);
            var value = (TripResponse)result?.Value;
            Assert.NotNull(result);
            Assert.Equal(5m, value?.TotalKms);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTrips_InvalidRequest_ReturnsNoContent()
        {
            _tripService.Setup(x => x.GetTripsSummaryAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync((VehicleTrip?)null);
            var tripRequestBody = DtoMocks.TripRequestMock();

            var result = await _tripController.GetTripSummaryAsync(tripRequestBody);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
