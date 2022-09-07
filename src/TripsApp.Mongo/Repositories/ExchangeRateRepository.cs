using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repositories
{
    public class ExchangeRateRepository : Repository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(IMongoContext mongoContext) : base(mongoContext)
        {
        }

        public async Task<ExchangeRate> GetByCountryIdAsync(Guid countryId)
        {
            var filter = Builders<ExchangeRate>.Filter.Eq("CountryId", countryId);

            var result = await _collection.FindAsync(filter);

            return result.First();
        }
    }
}
