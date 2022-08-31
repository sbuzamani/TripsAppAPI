using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repositories;
using Xunit;

namespace TripsApp.IntegrationTests
{
    [Trait("TestType", "Integration")]
    public class ExchangeRateRepositoryTests : IClassFixture<DatabaseFixture<ExchangeRate>>
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;

        public ExchangeRateRepositoryTests(DatabaseFixture<ExchangeRate> databaseFixture)
        {
            _exchangeRateRepository = new ExchangeRateRepository(databaseFixture.context);
        }

        [Fact]
        public async Task GetAsync_ValidId_ReturnsExchangeRateEntity()
        {
            var result = await _exchangeRateRepository.GetAsync(Guid.Parse("F6DF1136-91EA-483C-81DA-BD15C669676A"));

            Assert.NotNull(result);
            Assert.Equal(result.Id, result.Id);
        }

        [Fact]
        public async Task DeleteAsync_ValidId_ReturnsTrue()
        {
            var result = await _exchangeRateRepository.DeleteAsync(new Guid());

            Assert.True(result);
        }

        [Fact]
        public async Task UpdateAsync_ValidExchangeRate_ReturnsTrue()
        {
            var result = await _exchangeRateRepository.UpdateAsync(new ExchangeRate());

            Assert.True(result);
        }

        [Fact]
        public async Task SaveAsync_ValidExchangeRate_ReturnsTrue()
        {
            var result = await _exchangeRateRepository.SaveAsync(new ExchangeRate());

            Assert.True(result);
        }

        [Fact]
        public async Task GetByCountryId_ValidCountryId_ReturnsTrip()
        {
            var result = await _exchangeRateRepository.GetByCountryIdAsync(new Guid());

            Assert.NotNull(result);
            Assert.Equal(new Guid(), result.CountryId);

        }
    }
}