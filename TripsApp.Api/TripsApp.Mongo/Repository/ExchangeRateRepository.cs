using MongoDB.Driver;
using System.Linq.Expressions;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class ExchangeRateRepository : Repository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        public override async Task<ExchangeRate> GetAsync(Guid countryId)
        {
            var collection = GetCollection();

            var filter = Builders<ExchangeRate>.Filter.Eq(x => x.CountryId, countryId);

            var result = await collection.FindAsync(filter);

            return result.FirstOrDefault();
        }
    }
}
