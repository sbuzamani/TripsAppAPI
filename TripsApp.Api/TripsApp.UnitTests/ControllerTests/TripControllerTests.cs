using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using TripsApp.Api.Commands;
using TripsApp.Api.Controllers;
using TripsApp.Api.Queries;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.UnitTests.MockData;
using Xunit;

namespace TripsApp.UnitTests.ControllerTests
{
    public class TripControllerTests
    {
        private readonly TripController _tripController;
        private readonly Mock<IMediator> _mockMediator;

        public TripControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _tripController = new TripController(_mockMediator.Object);
        }

        [Fact]
        public async Task SaveTripAsync_ServiceReturnsFalse_ReturnsBadRequest()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<SaveTripCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);
            var tripDto = DtoMocks.GetTripDto();

            var result = await _tripController.SaveTripAsync(tripDto);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task SaveTripAsync_ValidRequest_ReturnsOKResponse()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<SaveTripCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            var tripDto = DtoMocks.GetTripDto();

            var result = await _tripController.SaveTripAsync(tripDto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task SaveTripAsync_ValidRequest_ServiceMethodCalled()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<SaveTripCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(true).Verifiable();
            var tripDto = DtoMocks.GetTripDto();

            var result = await _tripController.SaveTripAsync(tripDto);

            Assert.IsType<OkObjectResult>(result);
            _mockMediator.Verify();
        }

        [Fact]
        public async Task GetTripSummaryAsync_ValidRequest_ReturnsTripsResponse()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<GetTripSummaryQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(DtoMocks.TripResponseMock());
            var requestParameters = new
            {
                VehicleId = new Guid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            var result = (OkObjectResult)await _tripController.GetTripSummaryAsync(requestParameters.VehicleId, requestParameters.StartDate, requestParameters.EndDate);
            var value = (TripSummaryDto)result?.Value;
            Assert.NotNull(result);
            Assert.Equal(99.9, value?.TotalDistance);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTripSummaryAsync_InvalidRequest_ReturnsNoContentResponse()
        {
            _mockMediator.Setup(x => x.Send(It.IsAny<GetTripSummaryQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((TripSummaryDto?)null);
            var requestParameters = new
            {
                VehicleId = new Guid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };

            var result = await _tripController.GetTripSummaryAsync(requestParameters.VehicleId, requestParameters.StartDate, requestParameters.EndDate);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
