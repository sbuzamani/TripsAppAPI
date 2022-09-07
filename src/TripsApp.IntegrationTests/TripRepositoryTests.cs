using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repositories;
using Xunit;

namespace TripsApp.IntegrationTests
{
    [Trait("TestType", "Integration")]
    public class TripRepositoryTests : IClassFixture<DatabaseFixture<Trip>>
    {
        private readonly ITripRepository _tripRepository;

        public TripRepositoryTests(DatabaseFixture<Trip> databaseFixture)
        {
            _tripRepository = new TripRepository(databaseFixture.context);
        }

        [Fact]
        public async Task GetAsync_ValidId_ReturnsTripEntity()
        {
            var result = await _tripRepository.GetAsync(Guid.Parse("3c113906-941c-4781-baa3-e735f3c9800a"));

            Assert.NotNull(result);
            Assert.Equal(result.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_ReturnsTrue()
        {
            var result = await _tripRepository.DeleteAsync(new Guid());

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateAsync_ValidTrip_ReturnsTrue()
        {
            var result = await _tripRepository.UpdateAsync(new Trip());

            Assert.True(result);
        }

        [Fact]
        public async Task SaveAsync_ValidTrip_ReturnsTrue()
        {
            var result = await _tripRepository.SaveAsync(new Trip());

            Assert.True(result);
        }
    }
}