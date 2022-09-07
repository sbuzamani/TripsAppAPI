using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repositories;
using Xunit;

namespace TripsApp.IntegrationTests
{
    [Trait("TestType", "Integration")]
    public class VehicleRepositoryTests : IClassFixture<DatabaseFixture<Vehicle>>
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleRepositoryTests(DatabaseFixture<Vehicle> databaseFixture)
        {
            _vehicleRepository = new VehicleRepository(databaseFixture.context);
        }

        [Fact]
        public async Task GetAsync_ValidId_ReturnsVehicleEntity()
        {
            var result = await _vehicleRepository.GetAsync(Guid.Parse("97cb8d46-16a6-430b-b70a-157a928da6e1"));

            Assert.NotNull(result);
            Assert.Equal(result.Id, result.Id);
        }


        [Fact]
        public async Task UpdateAsync_ValidVehicleEntity_ReturnsTrue()
        {
            var result = await _vehicleRepository.UpdateAsync(new Vehicle { Id = Guid.Parse("97cb8d46-16a6-430b-b70a-157a928da6e1"), Make = "Mazda", Year = 2003 });

            var getResult = await _vehicleRepository.GetAsync(Guid.Parse("97cb8d46-16a6-430b-b70a-157a928da6e1"));

            Assert.True(result);
            Assert.Equal("Mazda", getResult.Make);
            Assert.Equal(2003, getResult.Year);
        }

        [Fact]
        public async Task SaveAsync_ValidVehicleEntity_ReturnsTrue()
        {
            var result = await _vehicleRepository.SaveAsync(new Vehicle
            {
                Id = Guid.Parse("674a4102-3be6-424b-a454-31b9391f81bb"),
                Make = "Yaris",
                Year = 2010,
                CountryId = Guid.Parse("cd0b26f7-b7c9-4c02-888c-daeaf1b86a45")
            });

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_ReturnsTrue()
        {
            var result = await _vehicleRepository.DeleteAsync(Guid.Parse("02cc7a5c-8496-4ee9-9260-0c5cd87d98fb"));

            Assert.True(result);
        }
    }
}