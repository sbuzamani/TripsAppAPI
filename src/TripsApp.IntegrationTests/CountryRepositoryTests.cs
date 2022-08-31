using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repositories;
using Xunit;

namespace TripsApp.IntegrationTests
{
    [Trait("TestType", "Integration")]
    public class CountryRepositoryTests : IClassFixture<DatabaseFixture<Country>>
    {
        private readonly ICountryRepository _countryRepository;

        public CountryRepositoryTests(DatabaseFixture<Country> databaseFixture)
        {
            _countryRepository = new CountryRepository(databaseFixture.context);
        }


        [Fact]
        public async Task GetAsync_ValidId_ReturnsCountryEntity()
        {
            var result = await _countryRepository.GetAsync(Guid.Parse("e2e9dfc1-0f1e-48cb-9878-ee89aa9e1283"));

            Assert.NotNull(result);
            Assert.Equal(result.Id, result.Id);
        }


        [Fact]
        public async Task UpdateAsync_ValidCountry_ReturnsTrue()
        {
            var result = await _countryRepository.UpdateAsync(new Country());

            Assert.True(result);
        }

        [Fact]
        public async Task SaveAsync_ValidTrip_ReturnsTrue()
        {
            var result = await _countryRepository.SaveAsync(new Country());

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_ReturnsTrue()
        {
            var result = await _countryRepository.DeleteAsync(Guid.Parse("16635a6d-b0c3-401f-b843-d552a2c01bbe"));

            Assert.True(result);
        }

    }
}