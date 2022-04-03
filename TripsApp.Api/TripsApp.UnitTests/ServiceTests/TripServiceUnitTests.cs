//using AutoMapper;
//using Microsoft.Extensions.Logging;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using TripsApp.ApplicationServices.Mapper;
//using TripsApp.ApplicationServices.Services;
//using TripsApp.Mongo.Interfaces;
//using TripsApp.UnitTests.MockData;
//using Xunit;

//namespace TripsApp.UnitTests.ServiceTests
//{
//    public class TripServiceUnitTests
//    {
//        private readonly ITripService _tripService;
//        private Mock<ITripRepository> _mockTripRepository;
//        private Mock<IExchangeRateRepository> _mockExchangeRateRepository;
//        private Mock<ICountryRepository> _mockCountryRepository;
//        private Mock<IFuelRateRepository> _mockFuelRateRepository;
//        private Mock<IFuelPriceRepository> _mockFuelPriceRepository;
//        private Mock<ILogger<TripService>> _logger;
//        public TripServiceUnitTests()
//        {
//            var mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<DomainMappingProfile>()));
//            _logger = new Mock<ILogger<TripService>>();
//            _mockTripRepository = new Mock<ITripRepository>();
//            _mockExchangeRateRepository = new Mock<IExchangeRateRepository>();
//            _mockCountryRepository = new Mock<ICountryRepository>();
//            _mockFuelRateRepository = new Mock<IFuelRateRepository>();
//            _mockFuelPriceRepository = new Mock<IFuelPriceRepository>();
//            _tripService = new TripService(mapper, _logger.Object, _mockTripRepository.Object,
//                _mockExchangeRateRepository.Object, _mockCountryRepository.Object, _mockFuelRateRepository.Object,
//                _mockFuelPriceRepository.Object);
//        }

//        [Fact]
//        public async Task SaveTripAsync_ValidTrip_ReturnsTrue()
//        {
//            _mockTripRepository.Setup(x => x.SaveAsync(It.IsAny<Mongo.Entities.Trip>())).ReturnsAsync(true);
//            var trip = TripsMocks.GetTrip();

//            var result = await _tripService.SaveTripAsync(trip);

//            Assert.True(result);
//        }

//        [Fact]
//        public async Task SaveTripAsync_RepositoryReturnsFalse_ReturnsFalse()
//        {
//            _mockTripRepository.Setup(x => x.SaveAsync(It.IsAny<Mongo.Entities.Trip>())).ReturnsAsync(false);
//            var trip = TripsMocks.GetTrip();

//            var result = await _tripService.SaveTripAsync(trip);

//            Assert.False(result);
//        }

//        [Fact]
//        public async Task SaveTripAsync_RepositoryThrowsException_ReturnsFalse()
//        {
//            _mockTripRepository.Setup(x => x.SaveAsync(It.IsAny<Mongo.Entities.Trip>())).ThrowsAsync(new Exception());
//            var trip = TripsMocks.GetTrip();

//            var result = await _tripService.SaveTripAsync(trip);

//            Assert.False(result);
//        }

//        [Fact]
//        public async Task GetTripsSummaryAsync_ValidVehicleId_ReturnsVehicleTripSummary()
//        {
//            var vehicleId = Guid.NewGuid();
//            var tripEntities = TripsMocks.GetTripEntityList();
//            _mockTripRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);
//            _mockExchangeRateRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(ExchangeRateMocks.GetExchangeRate());
//            _mockFuelRateRepository.Setup(x => x.GetAsync()).ReturnsAsync(2M);
//            _mockCountryRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(CountryMocks.GetOneCountry());
//            _mockFuelPriceRepository.Setup(x => x.GetFuelPriceAsync(It.IsAny<int>())).ReturnsAsync(FuelPriceMocks.GetOneFuelPrice());
//            _mockFuelRateRepository.Setup(x => x.GetAsync()).ReturnsAsync(FuelRateMocks.GetOneFuelRate().Rate);

//            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

//            Assert.Equal(33M, result?.TotalKms);
//            Assert.Equal("11840433", result?.CalculatedCost.ToString().Where(char.IsDigit));
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task GetTripsSummaryAsync_NoExchangeRateAndCost_ReturnsVehicleTripSummaryWithZeroCost()
//        {
//            var vehicleId = Guid.NewGuid();
//            var tripEntities = TripsMocks.GetTripEntityList();
//            _mockTripRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);
//            _mockExchangeRateRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(ExchangeRateMocks.GetZeroExchangeRate());
//            _mockCountryRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(CountryMocks.GetOneCountry());
//            _mockFuelPriceRepository.Setup(x => x.GetFuelPriceAsync(It.IsAny<int>())).ReturnsAsync(FuelPriceMocks.GetOneFuelPrice());
//            _mockFuelRateRepository.Setup(x => x.GetAsync()).ReturnsAsync(FuelRateMocks.GetOneFuelRate().Rate);

//            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

//            Assert.Equal(33M, result?.TotalKms);
//            Assert.Equal(0M, result?.CalculatedCost);
//            Assert.NotNull(result);
//        }

//        [Fact]
//        public async Task GetTripsSummaryAsync_ZeroDistanceTrips_ReturnsVehicleTripSummaryWithZeroTotalDistance()
//        {
//            var vehicleId = Guid.NewGuid();
//            var tripEntities = TripsMocks.GetZeroDistanceTripEntityList();
//            _mockTripRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(tripEntities);
//            _mockExchangeRateRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(ExchangeRateMocks.GetExchangeRate());
//            _mockCountryRepository.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(CountryMocks.GetOneCountry());
//            _mockFuelPriceRepository.Setup(x => x.GetFuelPriceAsync(It.IsAny<int>())).ReturnsAsync(FuelPriceMocks.GetOneFuelPrice());
//            _mockFuelRateRepository.Setup(x => x.GetAsync()).ReturnsAsync(FuelRateMocks.GetOneFuelRate().Rate);

//            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

//            Assert.Equal(0M, result?.TotalKms);
//        }

//        [Fact]
//        public async Task GetTripsSummaryAsync_RepositoryThrowsException_ReturnsNull()
//        {
//            var vehicleId = Guid.NewGuid();
//            var tripEntities = TripsMocks.GetZeroDistanceTripEntityList();
//            _mockTripRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ThrowsAsync(new Exception());

//            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

//            Assert.Null(result);
//        }

//        [Fact]
//        public async Task GetTripsSummaryAsync_RepositoryReturnsNoZeroResults_ReturnsNull()
//        {
//            var vehicleId = Guid.NewGuid();
//            var tripEntities = TripsMocks.GetZeroDistanceTripEntityList();
//            _mockTripRepository.Setup(x => x.GetVehicleTripsAsync(It.IsAny<Guid>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(new List<Mongo.Entities.Trip>());

//            var result = await _tripService.GetTripsSummaryAsync(vehicleId, DateTime.Now.AddMonths(-2), DateTime.Now);

//            Assert.Null(result);
//        }
//    }
//}