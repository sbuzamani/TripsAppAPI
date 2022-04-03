//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Threading.Tasks;
//using TripsApp.Api.Controllers;
//using TripsApp.Api.Dtos;
//using TripsApp.ApplicationServices.Services;
//using TripsApp.Domain.Models;
//using TripsApp.UnitTests.MockData;
//using Xunit;

//namespace TripsApp.UnitTests.ControllerTests
//{
//    public class TripControllerTests
//    {
//        private readonly TripController _tripController;
//        private readonly Mock<ITripService> _tripService;

//        public TripControllerTests()
//        {
//            _tripService = new Mock<ITripService>();
//            _tripController = new TripController(_tripService.Object);
//        }

//        [Fact]
//        public async Task SaveTripAsync_ServiceReturnsFalse_ReturnsBadRequest()
//        {
//            _tripService.Setup(x => x.SaveTripAsync(It.IsAny<Trip>())).ReturnsAsync(false);
//            var tripDto = DtoMocks.GetTripDto();

//            var result = await _tripController.SaveTripAsync(tripDto);

//            Assert.IsType<BadRequestObjectResult>(result);
//        }

//        [Fact]
//        public async Task SaveTripAsync_ValidRequest_ReturnsOKResponse()
//        {
//            _tripService.Setup(x => x.SaveTripAsync(It.IsAny<Trip>())).ReturnsAsync(true);
//            var tripDto = DtoMocks.GetTripDto();

//            var result = await _tripController.SaveTripAsync(tripDto);

//            Assert.IsType<OkObjectResult>(result);
//        }

//        [Fact]
//        public async Task SaveTripAsync_ValidRequest_ServiceMethodCalled()
//        {
//            _tripService.Setup(x => x.SaveTripAsync(It.IsAny<Trip>())).ReturnsAsync(true).Verifiable();
//            var tripDto = DtoMocks.GetTripDto();

//            var result = await _tripController.SaveTripAsync(tripDto);

//            Assert.IsType<OkObjectResult>(result);
//            _tripService.Verify();
//        }

//        [Fact]
//        public async Task GetTripSummaryAsync_ValidRequest_ReturnsTripsResponse()
//        {
//            _tripService.Setup(x => x.GetTripsSummaryAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(DtoMocks.GetVehicleTrip());
//            var tripRequestBody = DtoMocks.TripRequestMock();

//            var result = (OkObjectResult)await _tripController.GetTripSummaryAsync(tripRequestBody);
//            var value = (TripResponse)result?.Value;
//            Assert.NotNull(result);
//            Assert.Equal(5m, value?.TotalKms);
//            Assert.IsType<OkObjectResult>(result);
//        }

//        [Fact]
//        public async Task GetTripSummaryAsync_InvalidRequest_ReturnsNoContentResponse()
//        {
//            _tripService.Setup(x => x.GetTripsSummaryAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync((VehicleSummary?)null);
//            var tripRequestBody = DtoMocks.TripRequestMock();

//            var result = await _tripController.GetTripSummaryAsync(tripRequestBody);

//            Assert.IsType<NoContentResult>(result);
//        }
//    }
//}
