using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
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
        private Mock<ILogger<TripService>> _logger;
        public TripServiceUnitTests()
        {
            var mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<DomainMappingProfile>()));
            _mockRepository = new Mock<ITripRepository>();
            _logger = new Mock<ILogger<TripService>>();
            _tripService = new TripService(_mockRepository.Object, mapper, _logger.Object);
        }

        [Fact]
        public async Task SaveTripAsync_ValidTrip_ReturnsTrue()
        {
            _mockRepository.Setup(x => x.SaveTripAsync(It.IsAny<Domain.Repositories.Entities.Trip>())).ReturnsAsync(true);
            var trip = TripsMocks.GetTrip();

            var result = await _tripService.SaveTripAsync(trip);

            Assert.True(result);
        }

        [Fact]
        public async Task SaveTripAsync_RepositoryReturnsFalse_ReturnsFalse()
        {
            _mockRepository.Setup(x => x.SaveTripAsync(It.IsAny<Domain.Repositories.Entities.Trip>())).ReturnsAsync(false);
            var trip = TripsMocks.GetTrip();

            var result = await _tripService.SaveTripAsync(trip);

            Assert.False(result);
        }

        [Fact]
        public async Task SaveTripAsync_RepositoryThrowsException_ReturnsFalse()
        {
            _mockRepository.Setup(x => x.SaveTripAsync(It.IsAny<Domain.Repositories.Entities.Trip>())).ThrowsAsync(new Exception());
            var trip = TripsMocks.GetTrip();

            var result = await _tripService.SaveTripAsync(trip);

            Assert.False(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_ValidVehicleId_ReturnsVehicleTripSummary()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetTripEntityList();
            _mockRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);
            _mockRepository.Setup(x => x.GetExchangeRateAsync(It.IsAny<int>())).ReturnsAsync(5M);
            _mockRepository.Setup(x => x.GetCostPerKilometerAsync()).ReturnsAsync(2M);

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
            _mockRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);

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
            _mockRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Equal(0M, result?.TotalKms);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_RepositoryThrowsException_ReturnsNull()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetZeroDistanceTripEntityList();
            _mockRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_RepositoryReturnsNoZeroResults_ReturnsNull()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetZeroDistanceTripEntityList();
            _mockRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(new List<Domain.Repositories.Entities.Trip>());

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Null(result);
        }
    }
}