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

            var result = await _tripService.SaveTrip(trip);

            Assert.True(result);
        }

        [Fact]
        public async Task GetTrips_ValidVehicleId_ReturnsTripsList()
        {
            var vehicleId = Guid.NewGuid();
            var tripEntities = TripsMocks.GetTripEntityList();
            var tripModels = TripsMocks.GetTripList();
            _mockRepository.Setup(x => x.GetTrips(It.IsAny<Guid>())).ReturnsAsync(tripEntities);

            var result = await _tripService.GetTrips(vehicleId);

            //Assert.Equal(tripEntities.Count(), result.Count());
            //Assert.Contains(tripModels.First(), result);
            Assert.NotEmpty(result);
        }
    }
}