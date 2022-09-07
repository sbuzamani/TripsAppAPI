using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repositories;
using Xunit;

namespace TripsApp.IntegrationTests
{
    [Trait("TestType", "Integration")]
    public class FuelPriceRepositoryTests : IClassFixture<DatabaseFixture<FuelPrice>>
    {
        private readonly IFuelPriceRepository _fuelPriceRepository;

        public FuelPriceRepositoryTests(DatabaseFixture<FuelPrice> databaseFixture)
        {
            _fuelPriceRepository = new FuelPriceRepository(databaseFixture.context);
        }

        [Fact]
        public async Task GetAsync_ValidId_ReturnsFuelPriceEntity()
        {
            var result = await _fuelPriceRepository.GetAsync(Guid.Parse("55b84ff1-ef23-441e-99c5-d25f03c2a68a"));

            Assert.NotNull(result);
            Assert.Equal(result.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_ReturnsTrue()
        {
            var result = await _fuelPriceRepository.DeleteAsync(new Guid());

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateAsync_ValidFuelPrice_ReturnsTrue()
        {
            var result = await _fuelPriceRepository.UpdateAsync(new FuelPrice());

            Assert.True(result);
        }

        [Fact]
        public async Task SaveAsync_ValidTrip_ReturnsTrue()
        {
            var result = await _fuelPriceRepository.SaveAsync(new FuelPrice());

            Assert.True(result);
        }

        [Fact]
        public async Task GetByCountryId_ValidCountryId_ReturnsFuelPrice()
        {
            var result = await _fuelPriceRepository.GetByCountryIdAsync(new Guid());

            Assert.NotNull(result);
            Assert.Equal(new Guid(), result.CountryId);

        }
    }
}