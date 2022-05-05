using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using TripsApp.ApplicationServices.Mapper;
using TripsApp.ApplicationServices.Services;
using TripsApp.Mongo.Interfaces;
using TripsApp.UnitTests.MockData;
using Xunit;

namespace TripsApp.UnitTests.ServiceTests
{
    public class TripServiceUnitTests
    {
        private readonly ITripService _tripService;
        private Mock<ITripRepository> _mockTripRepository;
        private Mock<IExchangeRateRepository> _mockExchangeRateRepository;
        private Mock<ICountryRepository> _mockCountryRepository;
        private Mock<IFuelPriceRepository> _mockFuelPriceRepository;
        private Mock<ILogger<TripService>> _logger;
        public TripServiceUnitTests()
        {
            var mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<DomainMappingProfile>()));
            _logger = new Mock<ILogger<TripService>>();
            _mockTripRepository = new Mock<ITripRepository>();
            _mockExchangeRateRepository = new Mock<IExchangeRateRepository>();
            _mockCountryRepository = new Mock<ICountryRepository>();
            _mockFuelPriceRepository = new Mock<IFuelPriceRepository>();
            _tripService = new TripService(mapper, _logger.Object, _mockTripRepository.Object,
                _mockExchangeRateRepository.Object, _mockCountryRepository.Object,
                _mockFuelPriceRepository.Object);
        }

        [Fact]
        public async Task SaveTripAsync_ValidTrip_ReturnsTrue()
        {
            _mockTripRepository.Setup(x => x.SaveAsync(It.IsAny<Mongo.Entities.Trip>())).ReturnsAsync(true);
            var trip = TripsMocks.GetTrip();

            var result = await _tripService.SaveTripAsync(trip);

            Assert.True(result);
        }

        [Fact]
        public async Task SaveTripAsync_RepositoryReturnsFalse_ReturnsFalse()
        {
            _mockTripRepository.Setup(x => x.SaveAsync(It.IsAny<Mongo.Entities.Trip>())).ReturnsAsync(false);
            var trip = TripsMocks.GetTrip();

            var result = await _tripService.SaveTripAsync(trip);

            Assert.False(result);
        }

        [Fact]
        public async Task SaveTripAsync_RepositoryThrowsException_ReturnsFalse()
        {
            _mockTripRepository.Setup(x => x.SaveAsync(It.IsAny<Mongo.Entities.Trip>())).ThrowsAsync(new Exception());
            var trip = TripsMocks.GetTrip();

            var result = await _tripService.SaveTripAsync(trip);

            Assert.False(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_ValidVehicleId_ReturnsVehicleTripSummary()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetTripAggregation();
            _mockTripRepository.Setup(x => x.GetTripAggregationAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);
            _mockExchangeRateRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(ExchangeRateMocks.GetExchangeRate());
            _mockCountryRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(CountryMocks.GetOneCountry());
            _mockFuelPriceRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(FuelPriceMocks.GetOneFuelPrice());

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Equal(35, result?.TotalDistance);
            Assert.Equal("12558035", result?.CalculatedCost.ToString().Where(char.IsDigit));
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_NoExchangeRateAndCost_ReturnsVehicleTripSummaryWithZeroCost()
        {
            var vehicleId = Guid.Parse("a5fcd4ae-13b5-4963-a9d3-619f0d390bee");
            var tripEntities = TripsMocks.GetTripAggregation();
            _mockTripRepository.Setup(x => x.GetTripAggregationAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);
            _mockExchangeRateRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(ExchangeRateMocks.GetZeroExchangeRate());
            _mockCountryRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(CountryMocks.GetOneCountry());
            _mockFuelPriceRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(FuelPriceMocks.GetOneFuelPrice());

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Equal(35, result?.TotalDistance);
            Assert.Equal(0, result?.CalculatedCost);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_ZeroDistanceTrips_ReturnsVehicleTripSummaryWithZeroTotalDistance()
        {
            var vehicleId = Guid.Parse("8ded079c-1ff5-4344-a4dc-a61368be057b");
            var tripEntities = TripsMocks.GetZeroTotalDistanceTripAggregation();
            _mockTripRepository.Setup(x => x.GetTripAggregationAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);
            _mockExchangeRateRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(ExchangeRateMocks.GetExchangeRate());
            _mockCountryRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(CountryMocks.GetOneCountry());
            _mockFuelPriceRepository.Setup(x => x.GetAsync(It.IsAny<Guid>())).ReturnsAsync(FuelPriceMocks.GetOneFuelPrice());

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Equal(0, result?.TotalDistance);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_RepositoryThrowsException_ReturnsNull()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetZeroTotalDistanceTripAggregation();
            _mockTripRepository.Setup(x => x.GetTripAggregationAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetTripsSummaryAsync_RepositoryReturnsNoZeroResults_ReturnsNull()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetZeroTotalDistanceTripAggregation();
            _mockTripRepository.Setup(x => x.GetTripAggregationAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync((Mongo.Entities.TripAggregation)null);

            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

            Assert.Null(result);
        }
    }
}