using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using TripsApp.ApplicationServices.Mapper;
using TripsApp.ApplicationServices.Services;
using TripsApp.Domain.Repositories;
using TripsApp.UnitTests.MockData;
using Xunit;

namespace TripsApp.UnitTests.ServiceTests
{
    public class TripServiceUnitTests
    {
        private readonly ITripService _tripService;
        private Mock<ITripRepository> _mockRepository;
        public TripServiceUnitTests()
        {
            var mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<DomainMappingProfile>()));
            _mockRepository = new Mock<ITripRepository>();
            _tripService = new TripService(_mockRepository.Object, mapper);
        }

        [Fact]
        public async Task SaveTrip_ValidTrip_ReturnsTrue()
        {
            _mockRepository.Setup(x => x.SaveTrip(It.IsAny<Domain.Repositories.Entities.Trip>())).ReturnsAsync(true);
            var trip = TripsMocks.GetTrip();

            var result = await _tripService.SaveTripAsync(trip);

            Assert.True(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_ValidVehicleId_ReturnsVehicleTripSummary()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetTripEntityList();
            _mockRepository.Setup(x => x.GetTrips(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);
            _mockRepository.Setup(x => x.GetExchangeRate(It.IsAny<int>())).ReturnsAsync(5M);
            _mockRepository.Setup(x => x.GetCostPerKilometer()).ReturnsAsync(2M);

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Equal(33M, result?.TotalKms);
            Assert.Equal(330M, result?.CalculatedCost);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_NoExchangeRateAndCost_ReturnsVehicleTripSummaryWithZeroCost()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetTripEntityList();
            _mockRepository.Setup(x => x.GetTrips(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Equal(33M, result?.TotalKms);
            Assert.Equal(0M, result?.CalculatedCost);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_ZeroDistanceTrips_ReturnsVehicleTripSummaryWithZeroTotalDistance()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetZeroDistanceTripEntityList();
            _mockRepository.Setup(x => x.GetTrips(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Equal(0M, result?.TotalKms);
        }
    }
}