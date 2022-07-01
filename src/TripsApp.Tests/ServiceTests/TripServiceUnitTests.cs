using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using TripsApp.Domain.Models;
using TripsApp.Domain.Repositories;
using TripsApp.Domain.Services;
using Xunit;

namespace TripsApp.Tests.ServiceTests
{
    public class TripServiceUnitTests
    {
        private readonly ITripService _tripService;
        private Mock<ITripRepository> _mockRepository;
        public TripServiceUnitTests()
        {
            _mockRepository = new Mock<ITripRepository>();
            _tripService = new TripService(_mockRepository.Object);
        }

        [Fact]
        public async Task SaveTrip_ValidTrip_ReturnsSuccess()
        {
            _mockRepository.Setup(x => x.SaveTrip(It.IsAny<Domain.Repositories.Entities.Trip>())).ReturnsAsync(true);
            var trip = new Trip { Id = new Guid(), CountryId = 1, Distance = 3.3M, TimeStamp = DateTime.Now, VehicleId = new Guid() };

            var result = await _tripService.SaveTrip(trip);
            Assert.IsTrue(result);
        }
    }
}
